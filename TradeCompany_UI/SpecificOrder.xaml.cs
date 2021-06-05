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
        private string text;
        private OrderListsDTO old;
       
        ContactInformation _clientInfo;
        OrderDataAccess _orderDataAccess;
        ProductsData _productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        BindingList<OrderListModel> _bdOrderListModel = new BindingList<OrderListModel>();
        OrdersData od;
        List<OrderListsDTO> orderListsDTOs;
       
        public SpecificOrder()
        {

            _orderDataAccess = new OrderDataAccess();
            _clientInfo = new ContactInformation();
            _orderDataAccess = new OrderDataAccess();
            _orderModel = _orderDataAccess.GetOrderById(7)[0];
            SetContactInformation();
            foreach (var product in _orderModel.OrderListModel)
            {
                _bdOrderListModel.Add(product);
            //dgSpecificOrder.ItemsSource = _orderModel.OrderListModel;
            
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
            //_bdOrderListModel.ListChanged += _bdOrderListModel_ListChanged;

        }

        //private void _bdOrderListModel_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    switch (e.ListChangedType)
        //    {
        //        case ListChangedType.Reset:
        //            break;
        //        case ListChangedType.ItemAdded:
                    
        //            //ProductDTO newItem = new ProductDTO();
        //            List<ProductDTO> newItem = new List<ProductDTO>();
        //            OrderListsDTO newOrderList = new OrderListsDTO();
                    
        //            newOrderList.OrderID = _orderId;
        //            //string name = dgSpecificOrder.

                    
                    
        //            newItem = _productsData.GetProductsByLetter(text);


        //            //newOrderList.ProductID = _productsData.GetProductsByLetter(text);

        //            break;
        //        case ListChangedType.ItemDeleted:
        //            break;
        //        case ListChangedType.ItemMoved:
        //            break;
        //        case ListChangedType.ItemChanged:
        //            break;
        //        case ListChangedType.PropertyDescriptorAdded:
        //            break;
        //        case ListChangedType.PropertyDescriptorDeleted:
        //            break;
        //        case ListChangedType.PropertyDescriptorChanged:
        //            break;
        //        default:
        //            break;
        //    }
        //}

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

        private void dgSpecificOrder_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Only handles cases where the cell contains a TextBox
            var editedTextbox = e.EditingElement as TextBox;

            if (editedTextbox != null)
            {
                text = editedTextbox.Text;
            }
           // ProductDTO newItem = new ProductDTO();
            List<ProductDTO> newItem = new List<ProductDTO>();
            OrderListsDTO newOrderList = new OrderListsDTO();

            newOrderList.OrderID = _orderId;
            //string name = dgSpecificOrder.



            newItem = _productsData.GetProductsByLetter(text);
            old = new OrderListsDTO();
            old.OrderID = _orderId;
            old.ProductID = newItem.First().ID;
            old.Amount = 1;
            old.Price = newItem.First().RetailPrice;
            orderListsDTOs.Add(old);
            od = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            od.AddOrderList(orderListsDTOs);



        }
    }
}
