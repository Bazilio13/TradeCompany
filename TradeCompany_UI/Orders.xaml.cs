using System;
using System.Collections.Generic;
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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<OrdersDTO> ordersDTOs = new List<OrdersDTO>();
            ordersDTOs = ordersData.GetOrders();
            MapsDTOtoModel map = new MapsDTOtoModel();
            List<OrderModel> orderModels = map.MapOrdersDTOToOrderModel(ordersDTOs);
            foreach (OrderModel orderModel in orderModels)
            {
                this.OrdersPanel.Children.Add(new OrderRow(orderModel));
            }
        }

    }
}
