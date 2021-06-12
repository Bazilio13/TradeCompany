using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TradeCompany_BLL;
using TradeCompany_BLL.DataAccess;
using TradeCompany_BLL.Models;
using TradeCompany_UI.Interfaces;
using TradeCompany_UI.Pop_ups;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for SpecificOrder.xaml
    /// </summary>
    public partial class SpecificOrder : Page, IProductAddable, IClientAddable
    {
        private int _orderId;
        private int _clientId;
        private int _addresId; 
        private string _adress;
        private float _sum = 0;
        ProductBaseModel _productBaseModel;

        private OrderModel newOrder;
        private OrderModel _infoAboutOrder;
        private OrderListModel specificProduct;

        private ClientModel _clientFullInfo;
        private AddressModel _clientAdress;

        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        private List<OrderListModel> listOfLastAddedProducts = new List<OrderListModel>();
        public List<AddressModel> listOAddressModel = new List<AddressModel>();
        public List<ProductModel> _productModel = new List<ProductModel>();

        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();
       
        OrderDataAccess _orderDataAccess = new OrderDataAccess();
        ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();
        AddressesDataAccess _addressesDataAccess = new AddressesDataAccess();
        ProductsDataAccess _productsDataAccess = new ProductsDataAccess();

        private UINavi _uinavi;

        public SpecificOrder()
        {
            InitializeComponent();
            _uinavi = UINavi.GetUINavi();
            newOrder = new OrderModel();

        }
        public SpecificOrder(int id)
        {
            InitializeComponent();

            _uinavi = UINavi.GetUINavi();
            GetOrderById(id);
            SetInfoAboutClient();
            ShowAllInfoAboutOrder();
        }

        private void ShowAllInfoAboutOrder()
        {
            ShowInfoAboutClient();
            FillComboBoxAddress();
        }

        private void GetOrderById(int id)
        {
            _infoAboutOrder = _orderDataAccess.GetOrderById(id).First();
            Sum.Text = "Сумма заказа: " + _infoAboutOrder.Summ.ToString();
            _sum = _infoAboutOrder.Summ;
            Comment.Text = _infoAboutOrder.Comment;
            _orderId = id;
            _clientId = _infoAboutOrder.ClientsID;
            DataPicker.SelectedDate = _infoAboutOrder.DateTime;

            foreach (var item in _infoAboutOrder.OrderListModel)
            {
                bgOrderListModels.Add(item);
            }
        }

        private void ShowInfoAboutClient()
        {
            ID.Text = "ID заказа : " + _orderId;
            ClientName.Text = _clientFullInfo.Name;
            Phone.Text = _clientFullInfo.Phone;
            Button_AddExistingProduct.IsEnabled = true;
        }

        private void SetInfoAboutClient() 
        {
            _clientFullInfo = new ClientModel()
            {
                ID = _infoAboutOrder.ID,
                Name = _infoAboutOrder.Client,
                Phone = _infoAboutOrder.ClientsPhone
            };

            _clientAdress = new AddressModel()
            {
                Address = _infoAboutOrder.Address,
                ID = _infoAboutOrder.ID
            };
        }

        private void FillComboBoxAddress()
        {
            listOAddressModel = _addressesDataAccess.GetAddressByClientID(_clientId);
            cbAdress.ItemsSource = listOAddressModel;
            cbAdress.DisplayMemberPath = "Address";
            cbAdress.Text = "Адрес";
        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {
            dgSpecificOrder.ItemsSource = bgOrderListModels;
        }

        private void dgSpecificOrder_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //OrderListModel productInOrder = (OrderListModel)e.Row.Item;

            //_orderId = 7;
            //string nameOfAddedProduct = productInOrder.ProductName;
            //var addedProduct = _orderDataAccess.GetProductsByLetter(nameOfAddedProduct);
            //if (addedProduct == null)
            //{
            //    //return new window with information
            //}
            //addedProduct.Amount = productInOrder.Amount;
            //addedProduct.OrderID = _orderId;

            //listOfProductForOrder.Add(addedProduct);

        }

        private void SaveProductInOrder_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (listOfProductForOrder.Equals(listOfLastAddedProducts))
            {
                return; // после сохранения отчистить список
            }

            if (_orderId == 0)
            {
                bool check = VerifyWhetherDateAndAddress(); 
                if (!check)
                {
                    new MessageWindow("Заполните все поля").ShowDialog();
                    return;
                }

                FillInfoAboutNewOrder();
                _orderDataAccess.AddOrder(newOrder);
            }
            else
            {
                _orderDataAccess.AddOrderList(listOfProductForOrder);
                listOfLastAddedProducts = listOfProductForOrder;
                ReduceProductsAmountInStock(listOfLastAddedProducts);
               // listOfProductForOrder.Clear(); 
            }

            new MessageWindow("Продукты добавлены в базу").ShowDialog();
        }

        private void ReduceProductsAmountInStock(List<OrderListModel> orderListModels)
        {
            foreach (var product in orderListModels)
            {
                _productsDataAccess.ReduceProductAmountInStockByID(product.ProductID, (int)product.Amount);
            }
        }

        private float CountOrderSumm(List<OrderListModel> orderListModels)
        {
            return orderListModels.Sum(s => s.Price * s.Amount); //вариант суммы
            //float summ = 0;
            //foreach (var item in orderListModels)
            //{
            //    summ += (item.Price * item.Amount);
            //}
            //return summ;
        }

        private void AddProduct_ButtonClick(object sender, RoutedEventArgs e) 
        {
            if (bgOrderListModels.Count > 0)
            {
                if (bgOrderListModels.Last().Amount == 0 && bgOrderListModels.Count >= 1)
                {
                    Button_AddExistingProduct.IsEnabled = false;
                    new MessageWindow("Введите количество товара").ShowDialog();
                }
                else
                {
                    _uinavi.GoToThePage(new ProductCatalog(this));
                }

            }
            else
            {
                _uinavi.GoToThePage(new ProductCatalog(this));
            }

        }

        public void AddProductToCollection(ProductBaseModel productBaseModel)
        {
            specificProduct = new OrderListModel();
            specificProduct.ProductID = productBaseModel.ID;
            specificProduct.ProductName = productBaseModel.Name;
            specificProduct.Price = _clientFullInfo.Type ? productBaseModel.WholesalePrice : productBaseModel.RetailPrice; //почему не использовали enum, _clientFullInfo.Type переименовать Type
            specificProduct.ProductMeasureUnit = productBaseModel.MeasureUnitName;
            specificProduct.OrderID = _orderId;
            _productBaseModel = productBaseModel;

            bgOrderListModels.Add(specificProduct);
        }

        public void AddClientToOrder(ClientBaseModel clientBaseModel)
        {
            _clientId = clientBaseModel.ID;
            _clientFullInfo = _clientsDataAccess.GetClientByClientID(_clientId);
            ShowAllInfoAboutOrder();
        }

        private void FillInfoAboutNewOrder()
        {
            newOrder.DateTime = (DateTime)DataPicker.SelectedDate;
            newOrder.ClientsID = _clientId;
            newOrder.Client = _clientFullInfo.Name;
            newOrder.ClientsPhone = _clientFullInfo.Phone;
            newOrder.Summ = CountOrderSumm(listOfProductForOrder);
            newOrder.OrderListModel = listOfProductForOrder;
            newOrder.AddressID = _addresId;
            newOrder.Address = _adress;
            newOrder.Comment = Comment.Text;
        }

        private void ChooseClient_Click(object sender, RoutedEventArgs e)
        {
            _uinavi.GoToThePage(new Clients(this));
        }

        private void cbAdress_Loaded(object sender, RoutedEventArgs e)
        {
            if (_orderId != 0)
            {
                cbAdress.SelectedIndex = 0;
            }
        }

        private void cbAdress_DropDownClosed(object sender, EventArgs e)
        {
            var addresInfo = (AddressModel)cbAdress.SelectedItem;

            if (addresInfo == null)
            {
                return;
            }

            if (_clientFullInfo == null) //перенести в open event
            {
                new MessageWindow("Выберите клиента").ShowDialog();
                return;
            }

            if (listOAddressModel.Count == 0) //перенести в open event
            {
                new MessageWindow("У клиента нет адресов").ShowDialog();
                return;
            }

            _addresId = addresInfo.ID;
            _adress = addresInfo.Address;
        }

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            throw new NotImplementedException();
        }

        private void dgSpecificOrder_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            VerifyWhetherInputHasDigits(e);
            var product = (OrderListModel)e.Row.Item; 

            if (product.Amount == 0) return;

            if(_productBaseModel.StockAmount - product.Amount < 0)
            {
                bgOrderListModels.Remove(bgOrderListModels.Last());
                new MessageWindow("На складе нет столько товара").ShowDialog();
                return;
            }
            
            listOfProductForOrder.Add(specificProduct);
            _sum += specificProduct.Price * product.Amount;
            Sum.Text = "Сумма заказа: " + _sum;
            Button_AddExistingProduct.IsEnabled = true;
            AddProductInOrder.IsEnabled = true;
        }

        private void VerifyWhetherInputHasDigits(DataGridCellEditEndingEventArgs e)
        {
            TextBox textBox = (TextBox)e.EditingElement;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                return;
            }

            if (!int.TryParse(textBox.Text, out var inputText))
            {
                new MessageWindow("В поле количество можно вводить только числа").ShowDialog();
                textBox.Text = "0";
            }
        }

        private bool VerifyWhetherDateAndAddress() 
        {
            if (_orderId != 0)
            {
                return true;
            }

            return _addresId != 0 && DataPicker.SelectedDate != null;
        }
    }
}
