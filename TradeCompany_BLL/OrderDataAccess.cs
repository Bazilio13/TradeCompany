using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class OrderDataAccess
    {
        private OrdersData _ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        private MapsDTOtoModel _map = new MapsDTOtoModel();
        public List<OrderModel> GetOrderModelsByParams(string client = null, DateTime? minDateTime = null, DateTime? maxDateTime = null, string address = null)
        {
            List<OrdersDTO> ordersDTOs;
            ordersDTOs = _ordersData.GetOrdersByParams(client, minDateTime, maxDateTime, address);
            List<OrderModel> orderModels = _map.MapOrdersDTOToOrderModel(ordersDTOs);
            return orderModels;
        }

        public List<OrderModel> SearchOrderModels(string str)
        {
            List<OrdersDTO> ordersDTOs;
            ordersDTOs = _ordersData.SearchOrders(str);
            List<OrderModel> orderModels = _map.MapOrdersDTOToOrderModel(ordersDTOs);
            return orderModels;
        }
    }
}
