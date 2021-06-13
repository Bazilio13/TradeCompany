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

        private ProductsData _productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        private MapsDTOtoModel _map = new MapsDTOtoModel();

        private MapsModelToDTO _mapsModelToDTO = new MapsModelToDTO();
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


        public List<OrderModel> GetOrderModelsByClientID(int id)
        {
            List<OrdersDTO> ordersDTOs;
            ordersDTOs = _ordersData.GetOrdersByClientID(id);
            List<OrderModel> orderModels = _map.MapOrdersDTOToOrderModel(ordersDTOs);
            return orderModels;
        }


        public List<OrderModel> GetOrderById(int id)
        {
            List<OrderModel> result = new List<OrderModel>();

            List<OrdersDTO> ordersDTOs = _ordersData.GetOrdersByID(id);

            result = _map.MapOrdersDTOToOrderModel(ordersDTOs);
            return result;
        }
        public OrderListModel GetProductsByLetter(string input)
        {
            var newItem = _productsData.GetProductsByLetter(input).First();

            OrderListModel orderListModel = _map.MapProductDTOToOrderListModel(newItem);


            return orderListModel;
        }
        public void AddOrderList(List<OrderListModel> orderListModels)
        {
            List<OrderListsDTO> order = _mapsModelToDTO.MapOrderListModelToOrderDTO(orderListModels);
            _ordersData.AddOrderList(order);
        }
        public void AddOrder(OrderModel orderModel)
        {
            OrdersDTO ordersDTO= new OrdersDTO();
            ordersDTO = _mapsModelToDTO.MapOrderModelToOrdersDTO(orderModel);
            _ordersData.AddOrder(ordersDTO);
        }

        public void DeleteOrderListByID(int id)
        {
            _ordersData.DeleteOrderListByID(id);
        }

        public void UpdateOrdersByID(OrderModel order)
        {
            OrdersDTO orderDTO = _mapsModelToDTO.MapOrderModelToOrdersDTO(order);
            _ordersData.UpdateOrdersByID(orderDTO);
        }


    }
}
