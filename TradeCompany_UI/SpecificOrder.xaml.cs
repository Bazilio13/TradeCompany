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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for SpecificOrder.xaml
    /// </summary>
    public partial class SpecificOrder : Page
    {
        private int _orderId;
        private static string ConnectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
        private OrderModel _infoAboutOrder;
        //private List<OrderModel> infoAboutOrder;
        private OrderListModel specificProduct;

        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();

        ProductsData _productsData = new ProductsData(ConnectionString);
        OrderDataAccess _orderDataAccess = new OrderDataAccess();

        MapsDTOtoModel _mapsDTOtoModel = new MapsDTOtoModel();




        public SpecificOrder()
        {
            //_infoAboutOrder = _orderDataAccess.GetOrderById(7).First();
            //foreach (var item in _infoAboutOrder.OrderListModel)
            //{
            //    bgOrderListModels.Add(item);
            //}
        }
        public SpecificOrder(int  id = 7)
        {
            InitializeComponent();
            _orderId = id;
            //infoAboutOrder = _orderDataAccess.GetOrderById(7);
            _infoAboutOrder = _orderDataAccess.GetOrderById(7).First();
           
            foreach (var item in _infoAboutOrder.OrderListModel)
            {
                bgOrderListModels.Add(item);
            }
            dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            dgSpecificOrder.ItemsSource = bgOrderListModels;

           
        }
        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {

            //dgSpecificOrder.ItemsSource = _infoAboutOrder.OrderListModel;
            //dgSpecificOrder.ItemsSource = bgOrderListModels;


        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SetContactInformation()
        {
            //_clientInfo.ID = _orderModel.ClientsID;
            //_clientInfo.Client = _orderModel.Client;
            //_clientInfo.ClientsPhone = _orderModel.ClientsPhone;
            //_clientInfo.dateTime = _orderModel.DateTime;
            //_clientInfo.Address = _orderModel.Address;
        }
        private void ShowClientInformation()
        {
            //Data.Text = _clientInfo.dateTime.ToString();
            //ID.Text = _clientInfo.ID.ToString();
            //ClientName.Text = _clientInfo.Client;
            //Phone.Text = _clientInfo.ClientsPhone;
            //Adress.Text = _clientInfo.Address;

        }

        

        private void dgSpecificOrder_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            OrderListModel productInOrder = (OrderListModel)e.Row.Item;

            _orderId = 7;
            string nameOfAddedProduct = productInOrder.ProductName;
            var addedProduct = _orderDataAccess.GetProductsByLetter(nameOfAddedProduct);
            if (addedProduct == null)
            {
                //return new window with information
            }
            addedProduct.Amount = productInOrder.Amount;
            addedProduct.OrderID = _orderId;

            listOfProductForOrder.Add(addedProduct);
        }

        private void FillInfoAboutAddedProduct(OrderListModel i)
        {
           
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _orderDataAccess.AddOrderList(listOfProductForOrder);
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
