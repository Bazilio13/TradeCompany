using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradeCompany_BLL;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;
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
        private OrderModel newOrder;
        private OrderModel _infoAboutOrder;
        private OrderListModel specificProduct;

       
       
        private ClientBaseModel _clientBaseInfo;
        private ClientModel _clientFullInfo;
        private AddressModel _clientAdress;


        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        private List<AddressModel> listOAddressModel = new List<AddressModel>();
        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();
        BindingList<AddressModel> cbAddressModel = new BindingList<AddressModel>();

       
        OrderDataAccess _orderDataAccess = new OrderDataAccess();
        ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();

       

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

            _orderId = id;

            _infoAboutOrder = _orderDataAccess.GetOrderById(id).First();

            foreach (var item in _infoAboutOrder.OrderListModel)
            {
                bgOrderListModels.Add(item);
            }
            GetInfoAboutClient();
            ShowInfoAboutClient();
            

        }
        private void ShowInfoAboutClient()
        {
            ID.Text = "ID: " + _clientFullInfo.ID;
            ClientName.Text = _clientFullInfo.Name;
            Phone.Text = _clientFullInfo.Phone;
            cbAdress.Text = _infoAboutOrder.Address;

        }
       


        private void GetInfoAboutClient()
        {
            _clientFullInfo = new ClientModel();
            _clientAdress = new AddressModel();

            dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            dgSpecificOrder.ItemsSource = bgOrderListModels;
            _clientFullInfo.ID = _infoAboutOrder.ID;
            _clientFullInfo.Name = _infoAboutOrder.Client;
            _clientFullInfo.Phone = _infoAboutOrder.ClientsPhone;

            _clientAdress.Address = _infoAboutOrder.Address;
            _clientAdress.ID = _infoAboutOrder.ID;
            //cbAddressModel.Add(_clientAdress.Address);
        }
        
        private void FillComboBoxAdress()
        {
            
        }


        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {

            //dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            dgSpecificOrder.ItemsSource = bgOrderListModels;


        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

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
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //добавить проверку на одинаковость добавляемого списка
            if (_orderId == 0)
            {
                newOrder.OrderListModel = listOfProductForOrder; // возможно стоит конкретно добавить в список, а не ссылку делать
                newOrder.DateTime = DateTime.Now;
                newOrder.Client = ClientName.Text; // тут поменяется
                newOrder.ClientsID = _clientsDataAccess.GetClientsBySearch(ClientName.Text).First().ID; 
                newOrder.ClientsPhone = Phone.Text;
                newOrder.Address = Adress.Text;
               
                newOrder.Summ = CountOrderSumm();

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

        }

        private void ChooseClient_Click(object sender, RoutedEventArgs e)
        {
            _uinavi.GoToThePage(new Clients(this));
        }
    }
}
