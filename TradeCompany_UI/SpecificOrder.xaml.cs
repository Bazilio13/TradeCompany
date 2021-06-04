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
        
        private OrderModel _orderModel;
       
        ContactInformation _clientInfo;
        OrderDataAccess _orderDataAccess;
        public SpecificOrder()
        {

            _orderDataAccess = new OrderDataAccess();
            _clientInfo = new ContactInformation();
            _orderDataAccess = new OrderDataAccess();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            SetContactInformation();
        }  
        public SpecificOrder(int id)
        {
            InitializeComponent();

            _orderDataAccess = new OrderDataAccess();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            SetContactInformation();

        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {
            ShowClientInformation();
            dgSpecificOrder.ItemsSource = _orderModel.OrderListModel;
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SetContactInformation()
        {
            _clientInfo.ID = _orderModel.ClientsID;
            _clientInfo.Client = _orderModel.Client;
            _clientInfo.ClientsPhone = _orderModel.ClientsPhone;
            _clientInfo.dateTime = _orderModel.DateTime;
            _clientInfo.Address = _orderModel.Address;
        }
        private void ShowClientInformation()
        {
            Data.Text = _clientInfo.dateTime.ToString();
            ID.Text = _clientInfo.ID.ToString();
            ClientName.Text = _clientInfo.Client;
            Phone.Text = _clientInfo.ClientsPhone;
            Adress.Text = _clientInfo.Address;

        }
    }
}
