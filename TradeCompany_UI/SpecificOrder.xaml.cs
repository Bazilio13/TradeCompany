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
        
        private OrderModel _orderModel;
        private int _orderId = 7 ;
        private string nameOfAddedProduct;
        private List<ProductDTO> newItem;

        private SpecificProductDTO _specificProductDTO;

        

        ContactInformation _clientInfo;
        OrderDataAccess _orderDataAccess;
        ProductsData _productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
       BindingList<OrderListModel> _bdOrderListModel = new BindingList<OrderListModel>();
        
        OrdersData od;

        RoutedEventArgs ee;



        public SpecificOrder()
        {

            _orderDataAccess = new OrderDataAccess();
            _clientInfo = new ContactInformation();
            _orderDataAccess = new OrderDataAccess();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            SetContactInformation();
            AddProductInTable();
        }

        private void AddProductInTable()
        {
            foreach (var product in _orderModel.OrderListModel)
            {
                _bdOrderListModel.Add(product);

            }
        }

        public SpecificOrder(int id)
        {
            InitializeComponent();
            _orderId = id;

            _orderDataAccess = new OrderDataAccess();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            SetContactInformation();
           

        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {
            ShowClientInformation();
            dgSpecificOrder.ItemsSource = _orderModel.OrderListModel;
            dgSpecificOrder.ItemsSource = _bdOrderListModel;
            ee = e;
            
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

        private void dgSpecificOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

        }

        private void dgSpecificOrder_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var x = e.Row;
        }

        private void dgSpecificOrder_KeyUp(object sender, KeyEventArgs e)
        {
            var x = e.OriginalSource.ToString();
        }

        

        private void dgSpecificOrder_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            OrderListModel i = (OrderListModel)e.Row.Item;
            _specificProductDTO = new SpecificProductDTO();
            newItem = new List<ProductDTO>();

            nameOfAddedProduct = i.ProductName;

            var item = _productsData.GetProductsByLetter(nameOfAddedProduct);
            if (item.Count == 0)
            {
                //return new window with information
            }

            newItem = item;

            FillInfoAboutAddedProduct(i);

            od = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            od.AddSpecificProductInOrder(_specificProductDTO);

            _orderModel = new OrderModel();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            AddProductInTable();

            dgSpecificOrder_Loaded(sender, ee);

        }

        private void FillInfoAboutAddedProduct(OrderListModel i)
        {
            _bdOrderListModel = new BindingList<OrderListModel>();
            _specificProductDTO.ProductID = newItem.First().ID;
            _specificProductDTO.Price = newItem.First().WholesalePrice;
            _specificProductDTO.Amount = i.Amount;
            _specificProductDTO.OrderID = _orderId;
  
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _orderModel = new OrderModel();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            AddProductInTable();
            dgSpecificOrder_Loaded(sender,e);
        }
    }
}
