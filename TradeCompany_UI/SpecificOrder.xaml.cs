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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for SpecificOrder.xaml
    /// </summary>
    public partial class SpecificOrder : Page,  IProductAddable , IClientAddable
    {
        private int _orderId;
        private int _clientId;
        private int _addresId; // можно в Модельку оформить
        private string _adress;

        private OrderModel newOrder;
        private OrderModel _infoAboutOrder;
        private OrderListModel specificProduct;

       
       
        private ClientBaseModel _clientBaseInfo;
        private ClientModel _clientFullInfo;
        private AddressModel _clientAdress;


        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        public List<AddressModel> listOAddressModel = new List<AddressModel>();

        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();
        BindingList<AddressModel> cbAddressModel = new BindingList<AddressModel>();

       
        OrderDataAccess _orderDataAccess = new OrderDataAccess();
        ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();
        AddressesDataAccess _addressesDataAccess = new AddressesDataAccess();


        private UINavi _uinavi;




        public SpecificOrder()
        {
            InitializeComponent();
            _uinavi = UINavi.GetUINavi();
            newOrder = new OrderModel();
            
            
        }
        public SpecificOrder(int id )
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

            _orderId = id;
            _clientId = _infoAboutOrder.ClientsID;

            foreach (var item in _infoAboutOrder.OrderListModel)
            {
                bgOrderListModels.Add(item);
            }
        }

        private void ShowInfoAboutClient()
        {
            ID.Text = "ID: " + _clientFullInfo.ID;
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
            //добавить проверку на одинаковость добавляемого списка
            if (_orderId == 0)
            {
                //newOrder.OrderListModel = listOfProductForOrder; // возможно стоит конкретно добавить в список, а не ссылку делать
                //newOrder.DateTime = DateTime.Now;
                //newOrder.Client = ClientName.Text; // тут поменяется
                //newOrder.ClientsID = _clientsDataAccess.GetClientsBySearch(ClientName.Text).First().ID; 
                //newOrder.ClientsPhone = Phone.Text;
                //newOrder.Address = cbAdress.Text;

                //newOrder.Summ = CountOrderSumm();

                FillInfoAboutNewOrder();
                _orderDataAccess.AddOrder(newOrder);
                
            }
            else
            {
                _orderDataAccess.AddOrderList(listOfProductForOrder);
            }
           
        }

        private float CountOrderSumm()
        {
            float summ = 0;
            foreach (var item in listOfProductForOrder)
            {
                summ += (item.Price * item.Amount);
            }
            return summ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _uinavi.GoToThePage(new ProductCatalog(this));

        }

        public void AddProductToCollection(ProductBaseModel productBaseModel)
        {
            specificProduct = new OrderListModel();
            specificProduct.ProductID = productBaseModel.ID;
            specificProduct.ProductName = productBaseModel.Name;
            specificProduct.Price = productBaseModel.WholesalePrice; // сделать обратку какой клиент
            specificProduct.ProductMeasureUnit = productBaseModel.MeasureUnitName;
            specificProduct.OrderID = _orderId;
            bgOrderListModels.Add(specificProduct);
            listOfProductForOrder.Add(specificProduct);
        }

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            throw new NotImplementedException();
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
            newOrder.DateTime = DateTime.Now; // возможно стоит переделать на календарь
            newOrder.ClientsID = _clientId;
            newOrder.Client = _clientFullInfo.Name;
            newOrder.ClientsPhone = _clientFullInfo.Phone;
            newOrder.Summ = CountOrderSumm();
            newOrder.OrderListModel = listOfProductForOrder;
            newOrder.AddressID = _addresId;
            newOrder.Address = _adress;

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
    }
}
