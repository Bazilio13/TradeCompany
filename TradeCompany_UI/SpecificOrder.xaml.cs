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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for SpecificOrder.xaml
    /// </summary>
    public partial class SpecificOrder : Page
    {
        //private InformationAboutOrderList informationAboutOrderList;
        
        //private BindingList<ProductsForOrderModel> productsInOrder;
        //private BindingList<OrderListModel> productsInOrder;
        private OrderModel _orderModel;

        private string _client;
        private string _clientsPhone;


        OrderDataAccess _orderDataAccess;
        public SpecificOrder()
        {
            _orderDataAccess = new OrderDataAccess();
        }  
        public SpecificOrder(int id)
        {
            InitializeComponent();
            //orderId = id;
            //var connectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
            //informationAboutOrderList = new InformationAboutOrderList(connectionString);
            _orderDataAccess = new OrderDataAccess();
            //_orderModel = _orderDataAccess.GetOrderById(id);
        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {

            //var connectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
            //informationAboutOrderList = new InformationAboutOrderList(connectionString);
            //var productsForOrder = informationAboutOrderList.GetProductsForOrderByOrderId(7);
            //productsInOrder = new BindingList<ProductsForOrderModel>();
            //// либо сделать маппер для ui либо сразу использовать productsForOrder
            //foreach (var product in productsForOrder)
            //{
            //    productsInOrder.Add(product);

            //}

            //ClientName.Text = productsForOrder.First().Name;
            //dgSpecificOrder.ItemsSource = productsInOrder;
            
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            _client = _orderModel.Client;
            _clientsPhone = _orderModel.ClientsPhone;
            if(_clientsPhone == null)
            
            ClientName.Text = _client;
            Phone.Text = _clientsPhone;
            dgSpecificOrder.ItemsSource = _orderModel.OrderListModel;


        }

    private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
