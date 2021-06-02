using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI
{
    public class OrderRow: StackPanel
    {
        OrderModel OrderModel { get; set; }

        public OrderRow (OrderModel orderModel)
        {
            OrderModel = orderModel;
            Button orderID = new Button();
            orderID.Content = orderModel.ID;
            orderID.Width = 40;
            Button client = new Button();
            client.Content = orderModel.Client;
            client.Width = 200;
            Button sum = new Button();
            sum.Content = orderModel.Summ;
            sum.Width = 100;
            Button date = new Button();
            date.Content = orderModel.DateTime;
            date.Width = 100;
            this.Children.Add(orderID);
            this.Children.Add(date);
            this.Children.Add(client);
            this.Children.Add(sum);
            this.Orientation = Orientation.Horizontal;
        }
    }
}
