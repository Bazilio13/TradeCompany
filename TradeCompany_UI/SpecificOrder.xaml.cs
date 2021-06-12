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
        private int _addresId; // можно в Модельку оформить
        private string _adress;
        private float _sum = 0;
        ProductBaseModel _productBaseModel;

        private OrderModel newOrder;
        private OrderModel _infoAboutOrder;
        private OrderListModel specificProduct;
       

        private ClientBaseModel _clientBaseInfo;
        private ClientModel _clientFullInfo;
        private AddressModel _clientAdress;

        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        private List<OrderListModel> listOfLastAddedProducts = new List<OrderListModel>();
        public List<AddressModel> listOAddressModel = new List<AddressModel>();
        public List<ProductModel> _productModel = new List<ProductModel>();

        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();
        BindingList<AddressModel> cbAddressModel = new BindingList<AddressModel>();

        OrderDataAccess _orderDataAccess = new OrderDataAccess();
        ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();
        AddressesDataAccess _addressesDataAccess = new AddressesDataAccess();
        ProductsDataAccess _ProductsDataAccess = new ProductsDataAccess();

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

            GetInfoAboutClient();
            ShowInfoAboutClient();
            FillComboBoxAdress();

        }
        private void GetOrderById(int id)
        {
            _infoAboutOrder = _orderDataAccess.GetOrderById(id).First();
            Sum.Text = "Сумма заказа: " + _infoAboutOrder.Summ.ToString();
            _sum = _infoAboutOrder.Summ;
            Comment.Text = _infoAboutOrder.Comment;
            _orderId = id;
            _clientId = _infoAboutOrder.ClientsID;

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


        }

        private void GetInfoAboutClient()
        {
            _clientFullInfo = new ClientModel();
            _clientAdress = new AddressModel();

            _clientFullInfo.ID = _infoAboutOrder.ID;
            _clientFullInfo.Name = _infoAboutOrder.Client;
            _clientFullInfo.Phone = _infoAboutOrder.ClientsPhone;

            _clientAdress.Address = _infoAboutOrder.Address;
            _clientAdress.ID = _infoAboutOrder.ID;

        }


        private void FillComboBoxAdress()
        {
            listOAddressModel = _addressesDataAccess.GetAdressByClientID(_clientId);
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
        private void AddProductInOrder_Click(object sender, RoutedEventArgs e)
        {

            if (listOfProductForOrder.Equals(listOfLastAddedProducts))
            {
                return;
            }
            else
            {
                if (_orderId == 0)
                {
                    FillInfoAboutNewOrder();
                    _orderDataAccess.AddOrder(newOrder);
                    ReduceProductsAmountInStock(newOrder.OrderListModel);

                }
                else
                {
                    _orderDataAccess.AddOrderList(listOfProductForOrder);
                    listOfLastAddedProducts = listOfProductForOrder;
                    ReduceProductsAmountInStock(listOfLastAddedProducts);
                }

                new MessageWindow("Продукты добавлены в базу").ShowDialog();
            }

        }
        private void ReduceProductsAmountInStock(List<OrderListModel> orderListModels)
        {
            foreach (var product in orderListModels)
            {
                _ProductsDataAccess.ReduceProductAmountInStockByID(product.ProductID, (int)product.Amount); 
            }
        }

        private float CountOrderSumm(List<OrderListModel> orderListModels)
        {
            float summ = 0;
            foreach (var item in orderListModels)
            {
                summ += (item.Price * item.Amount);
            }
            return summ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (bgOrderListModels.Count != 0)
            {
                if (bgOrderListModels.Last().Amount == 0 && bgOrderListModels.Count >=1)
                {
                    Button_AddExistingProduct.IsEnabled = false;
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
            //_uinavi.GoToThePage(new ProductCatalog(this));
        }

        public void AddProductToCollection(ProductBaseModel productBaseModel)
        {

            specificProduct = new OrderListModel();
            specificProduct.ProductID = productBaseModel.ID;
            specificProduct.ProductName = productBaseModel.Name;
            if (_clientFullInfo.Type == true)
            {
                specificProduct.Price = productBaseModel.WholesalePrice; // переписать 
            }
            else
            {
                specificProduct.Price = productBaseModel.RetailPrice;
            }

            specificProduct.ProductMeasureUnit = productBaseModel.MeasureUnitName;
            specificProduct.OrderID = _orderId;
            _productBaseModel = productBaseModel;

            bgOrderListModels.Add(specificProduct);
            
        }


        public void AddClientToOrder(ClientBaseModel clientBaseModel)
        {
            _clientId = clientBaseModel.ID;
            _clientFullInfo = _clientsDataAccess.GetClientByClientID(_clientId);
            FillComboBoxAdress();
            ShowInfoAboutClient();

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
            _addresId = addresInfo.ID;
            _adress = addresInfo.Address;
        }
        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            throw new NotImplementedException();
        }

        private void dgSpecificOrder_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var i = (OrderListModel)e.Row.Item;
            if (_productBaseModel.StockAmount - i.Amount >= 0)
            {
                listOfProductForOrder.Add(specificProduct);
                _sum += specificProduct.Price * i.Amount;
                Sum.Text ="Сумма заказа: " + _sum;
                Button_AddExistingProduct.IsEnabled = true;
            }
            else
            {
                bgOrderListModels.Remove(bgOrderListModels.Last());
                new MessageWindow("На складе нет столько товара").ShowDialog();
            }
           


        }
    }
}
