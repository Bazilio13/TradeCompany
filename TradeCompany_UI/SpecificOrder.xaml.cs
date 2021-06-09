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
    public partial class SpecificOrder : Page,  IProductAddable
    {
        private int _orderId;
        private static string ConnectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
        private OrderModel _infoAboutOrder;
       
        private OrderListModel specificProduct;
        private ClientBaseModel _clientInfo = new ClientBaseModel();
        private OrderModel newOrder;


        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();

        ProductsData _productsData = new ProductsData(ConnectionString);
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
            dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            dgSpecificOrder.ItemsSource = bgOrderListModels;
            ShowClientInformation();//



        }
        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {

            //dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            dgSpecificOrder.ItemsSource = bgOrderListModels;


        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SetContactInformation()
        {
            _clientInfo.ID = _infoAboutOrder.ClientsID;
            _clientInfo.Name = _infoAboutOrder.Client;
            _clientInfo.Phone = _infoAboutOrder.ClientsPhone;
            //_clientInfo. = _infoAboutOrder.DateTime;
            //_clientInfo.Address = _infoAboutOrder.Address;

        }
        private void ShowClientInformation()
        {
            Data.Text = _infoAboutOrder.DateTime.ToString();
            ID.Text = _infoAboutOrder.ID.ToString();
            ClientName.Text = _infoAboutOrder.Client;
            Phone.Text = _infoAboutOrder.ClientsPhone;
            Adress.Text = _infoAboutOrder.Address;

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

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            //specificProduct = new OrderListModel();
            //specificProduct.ProductID = productID;
            //specificProduct.ProductName = productName;
            ////specificProduct.
            //specificProduct.ProductMeasureUnit = productMeasureUnit;
            //bgOrderListModels.Add(specificProduct);
        }

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, float pprice, List<ProductGroupModel> productGroupModels)
        {
            specificProduct = new OrderListModel();
            specificProduct.ProductID = productID;
            specificProduct.ProductName = productName;
            specificProduct.Price = pprice;
            specificProduct.ProductMeasureUnit = productMeasureUnit;
            specificProduct.OrderID = _orderId;
            bgOrderListModels.Add(specificProduct);
            listOfProductForOrder.Add(specificProduct);
        }
    }
}
