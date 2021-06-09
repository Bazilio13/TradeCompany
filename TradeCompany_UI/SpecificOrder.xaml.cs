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
        private OrderModel _orderModel;
        private OrderListModel specificProduct;

        private List<OrderListModel> listOfProductForOrder = new List<OrderListModel>();
        BindingList<OrderListModel> bgOrderListModels = new BindingList<OrderListModel>();

        ProductsData _productsData = new ProductsData(ConnectionString);

        MapsDTOtoModel _mapsDTOtoModel = new MapsDTOtoModel();




        public SpecificOrder()
        {

        }

       


        public SpecificOrder(int id)
        {
            _orderId = id;
            InitializeComponent();
           
           

        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {
            
            //dgSpecificOrder.ItemsSource = _orderModel.OrderListModel;
            //dgSpecificOrder.ItemsSource = _bdOrderListModel;
            
            
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

            //OrderListModel i = (OrderListModel)e.Row.Item;
            //_specificProductDTO = new SpecificProductDTO(); //передалать
            //newItem = new List<ProductDTO>();

            //nameOfAddedProduct = i.ProductName;

            //var item = _productsData.GetProductsByLetter(nameOfAddedProduct);
            //if (item.Count == 0)
            //{
            //    //return new window with information
            //}

            //newItem = item;

            //FillInfoAboutAddedProduct(i);

            //od = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //od.AddSpecificProductInOrder(_specificProductDTO);

            //_orderModel = new OrderModel();
            //_orderModel = _orderDataAccess.GetOrderById(7)[0];
            //AddProductInTable();

            //dgSpecificOrder_Loaded(sender, ee);


            OrderListModel productInOrder = (OrderListModel)e.Row.Item;
            

            string nameOfAddedProduct = productInOrder.ProductName;
            var newItem = _productsData.GetProductsByLetter(nameOfAddedProduct);

            if (newItem.Count == 0)
            {
                //return new window with information
            }
            specificProduct = new OrderListModel();
            var i = newItem.First();

            specificProduct = _mapsDTOtoModel.MapProductDTOToOrderListModel(i);
            listOfProductForOrder.Add(specificProduct);








        }

        private void FillInfoAboutAddedProduct(OrderListModel i)
        {
           
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
