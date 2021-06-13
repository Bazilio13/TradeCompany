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
using System.Windows.Input;
using TradeCompany_BLL.DataAccess;

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
        //private string _oldComment = "";

        private OrderModel _orderModel = new OrderModel();
        private OrderListModel specificProduct;
        private ProductBaseModel _crntProductBaseModel = new ProductBaseModel();
        private FeedbackModel _feedbackModel;

        private ClientModel _client;
        private AddressModel _clientAdress;

        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        private List<OrderListModel> originalListOfProduct = new List<OrderListModel>();
        private List<AddressModel> listOAddressModel = new List<AddressModel>();
        private List<ProductModel> _productModel = new List<ProductModel>();
        private List<OrderListModel> _deletedProductFromOrder = new List<OrderListModel>();

        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();
       
        OrderDataAccess _orderDataAccess = new OrderDataAccess();
        ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();
        TradeCompany_BLL.DataAccess.AddressesDataAccess _addressesDataAccess = new TradeCompany_BLL.DataAccess.AddressesDataAccess();
        ProductsDataAccess _productsDataAccess = new ProductsDataAccess();
        FeedbacksDataAccess _FeedbacksDataAccess = new FeedbacksDataAccess();

        private UINavi _uinavi;

        public SpecificOrder()
        {
            InitializeComponent();
            _uinavi = UINavi.GetUINavi();
        }
        public SpecificOrder(int id)
        {
            InitializeComponent();
            _orderModel.ID = id;
            _uinavi = UINavi.GetUINavi();
            GetOrderById(id);
            _client = _clientsDataAccess.GetClientByClientID(_orderModel.ClientsID);
            ShowAllInfoAboutOrder();
        }

        private void ShowAllInfoAboutOrder()
        {
            ShowInfoAboutClient();
            FillComboBoxAddress();
        }

        private void GetOrderById(int id)
        {
            _orderModel = _orderDataAccess.GetOrderById(id).First();            
            Sum.Text = "Сумма заказа: " + _orderModel.Summ.ToString();
            _sum = _orderModel.Summ;
            Comment.Text = _orderModel.Comment;
            DataPicker.SelectedDate = _orderModel.DateTime;
            originalListOfProduct = _orderModel.OrderListModel;

            foreach (var item in _orderModel.OrderListModel)
            {
                bgOrderListModels.Add(item);
            }
        }

        private void ShowInfoAboutClient()
        {
            ID.Text = "ID заказа : " + _orderModel.ID;
            ClientName.Text = _client.Name;
            Phone.Text = _client.Phone;
            Button_AddExistingProduct.IsEnabled = true;
        }


        private void FillComboBoxAddress()
        {
            listOAddressModel = _addressesDataAccess.GetAddressByClientID(_orderModel.ClientsID);
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

        }

        private void SaveProductInOrder_ButtonClick(object sender, RoutedEventArgs e)
        {

            if (_orderModel.ID == 0)
            {
                bool check = VerifyWhetherDateAndAddress();
                if (!check)
                {
                    new MessageWindow("Заполните все поля").ShowDialog();
                    return;
                }

                FillInfoAboutNewOrder();
                _orderDataAccess.AddOrder(_orderModel);
                NotifyAboutSuccessfulAdditionInBase();
                return;

            }

            if (_orderModel.ID > 0) 
            {
                FillProductListFromDateGrid();
               
                FillInfoAboutNewOrder();
                _orderDataAccess.DeleteOrderListByID(_orderModel.ID);
                SetIdForOrderLists();
                //_orderDataAccess.AddOrderList(newOrder.OrderListModel);
                _orderDataAccess.UpdateOrdersByID(_orderModel);
                NotifyAboutSuccessfulAdditionInBase();
                IncreaseProductAmountInStockByID(_deletedProductFromOrder);
                return;
             }

            _orderDataAccess.AddOrderList(_orderModel.OrderListModel);
            NotifyAboutSuccessfulAdditionInBase();
        }

        private void NotifyAboutSuccessfulAdditionInBase()
        {
            ReduceProductsAmountInStock(_orderModel.OrderListModel);
            new MessageWindow("Продукты добавлены в базу").ShowDialog();            
        }

        private void FillProductListFromDateGrid()
        {
            _orderModel.OrderListModel = new List<OrderListModel>();
            foreach (var product in bgOrderListModels)
            {
                _orderModel.OrderListModel.Add(product);
            }
        }

        private void ReduceProductsAmountInStock(List<OrderListModel> orderListModels)
        {
            foreach (var product in orderListModels)
            {
                _productsDataAccess.ReduceProductAmountInStockByID(product.ProductID, (int)product.Amount);
            }
        }
        private void IncreaseProductAmountInStockByID(List<OrderListModel> deletedProduct)
        {
            if (deletedProduct.Count == 0) return;
            foreach (var product in deletedProduct)
            {
                _productsDataAccess.IncreaseProductAmountInStockByID(product.ProductID, (int)product.Amount);
            }
        }

        private float CountSummProductsOfBindingList()
        {
            return bgOrderListModels.Sum(s => s.Price * s.Amount); 
        }
        private float CountOrderSumm(List<OrderListModel> orderListModels)
        {
            return orderListModels.Sum(s => s.Price * s.Amount);
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
            specificProduct.Price = _client.Type ? productBaseModel.WholesalePrice : productBaseModel.RetailPrice; //почему не использовали enum, _clientFullInfo.Type переименовать Type
            specificProduct.ProductMeasureUnit = productBaseModel.MeasureUnitName;
            specificProduct.OrderID = _orderId;
            _crntProductBaseModel = productBaseModel;

            bgOrderListModels.Add(specificProduct);
        }

        public void AddClientToOrder(ClientBaseModel clientBaseModel)
        {
            _orderModel.ClientsID = clientBaseModel.ID;
            _client = _clientsDataAccess.GetClientByClientID(_orderModel.ClientsID);
            ShowAllInfoAboutOrder();
        }

        private void FillInfoAboutNewOrder()
        {
            _orderModel.DateTime = (DateTime)DataPicker.SelectedDate;
            _orderModel.Summ = CountSummProductsOfBindingList();
            _orderModel.Comment = Comment.Text;
        }

        private void ChooseClient_Click(object sender, RoutedEventArgs e)
        {
            _uinavi.GoToThePage(new Clients(this));
        }

        private void cbAdress_Loaded(object sender, RoutedEventArgs e)
        {
            if (_orderModel.ID != 0)
            {
                for (int i = 0; i < listOAddressModel.Count; i++)
                {
                    if (listOAddressModel[i].ID == _orderModel.AddressID)
                    {
                        cbAdress.SelectedIndex = i;
                        return;
                    }
                }
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

            if (_client == null) //перенести в open event
            {
                new MessageWindow("Выберите клиента").ShowDialog();
                return;
            }

            if (listOAddressModel.Count == 0) //перенести в open event
            {
                new MessageWindow("У клиента нет адресов").ShowDialog();
                return;
            }

            _orderModel.AddressID = addresInfo.ID;
            _orderModel.Address = addresInfo.Address;
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
            ProductsDataAccess productsDataAccess = new ProductsDataAccess();
            _crntProductBaseModel.StockAmount = productsDataAccess.GetProductByID(product.ProductID).StockAmount;
            if (_crntProductBaseModel.StockAmount - product.Amount < 0)
            {
                bgOrderListModels.Remove(bgOrderListModels.Last());
                new MessageWindow("На складе нет столько товара").ShowDialog();
                Button_AddExistingProduct.IsEnabled = true;
                return;
            }
            
            listOfProductForOrder.Add(specificProduct);
            _sum = CountSummProductsOfBindingList();
            Sum.Text = "Сумма заказа: " + _sum;
            Button_AddExistingProduct.IsEnabled = true;
            AddProductInOrder.IsEnabled = true;
        }

        private void SetIdForOrderLists()
        {
            foreach (OrderListModel orderList in _orderModel.OrderListModel)
            {
                orderList.OrderID = _orderModel.ID;
            }
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
            if (_orderModel.ID != 0)
            {
                return true;
            }

            return _orderModel.AddressID != 0 && DataPicker.SelectedDate != null;
        }

        private void FillFeedback()
        {
            if (string.IsNullOrWhiteSpace(FeedbackTextBox.Text) || _orderModel.ID == 0)
            {
                return;
            }
            if (FeedbackTextBox.Text.Length > 1500)
            {
                new MessageWindow("Привышен лимит символов. Максимальное значение 1500 символов").ShowDialog();
                return;
            }

            _feedbackModel = new FeedbackModel()
            {
                OrderID = _orderModel.ID,
                ClientID = _orderModel.ClientsID,
                DateTime = DateTime.Now,
                Text = FeedbackTextBox.Text

            };
        }

        private void SendFeedback_Button_Click(object sender, RoutedEventArgs e)
        {
            if(_orderModel.ID == 0)
            {
                new MessageWindow("Зайдите в раздел заказы и выберете данный заказ, тогда вы сможете оставить отзыв").ShowDialog();
                return;
            }
            FillFeedback();
           _FeedbacksDataAccess.AddFeedbackByOrderId(_orderModel.ID, _feedbackModel);
            new MessageWindow("Отзыв отправлен").ShowDialog();

        }

        private void FeedbackTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if(_orderModel.ID ==  0) { return; }

            List<FeedbackModel> feedbackModel = new List<FeedbackModel>();
            feedbackModel = _FeedbacksDataAccess.GetFeedbackByOrderID(_orderModel.ID);
            if(feedbackModel.Count == 0) { return; }
            FeedbackTextBox.Text = feedbackModel.Last().Text;

        }

        private void dgSpecificOrder_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                var index = dgSpecificOrder.SelectedIndex;
                _deletedProductFromOrder.Add(bgOrderListModels[index]);
                bgOrderListModels.RemoveAt(index);
                Sum.Text = bgOrderListModels.Sum(s => s.Price * s.Amount).ToString();

            }
        }

        private void DataPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datetime= (DateTime)e.Source;
            if (!(_orderModel.DateTime.Equals(datetime.Date)))
            {
                AddProductInOrder.IsEnabled = true;
            }

        }

        private void Comment_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var text = (TextBox)e.Source;
            if (!(_orderModel.Comment.Equals(text.Text)))
            {
                AddProductInOrder.IsEnabled = true;
                _orderModel.Comment = text.Text;
            }
        }

        private void DataPicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var datetime = e.Source;
            if (!(_orderModel.DateTime.ToString().Equals(datetime.ToString())))
            {
                AddProductInOrder.IsEnabled = true;
            }
        }
    }
}

