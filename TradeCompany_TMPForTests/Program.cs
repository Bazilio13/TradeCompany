using System;
using System.Collections.Generic;
using TradeCompany_BLL;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;


namespace TradeCompany_TMPForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //OrdersDTO ordersDTO = new OrdersDTO();
            ProductGroupsData groupsData = new ProductGroupsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //groupsData.DeleteProductGroupByID(3);
            groupsData.GetProductGroups();
            ProductsData productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ProductDTO product = new ProductDTO();
            productsData.DeleteProductByID(8);
            productsData.GetProducts();
            //productsData.GetProducts();
            //productsData.GetProductsByLetter("o");
            // productsData.GetProducts();
            //productsData.GetProductByID(2);
            //OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //ClientsData clientsData = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

            //List<ClientDTO> clientList = new List<ClientDTO>();
            //ClientDTO client = new ClientDTO();

            //clientsData.AddClient(client);
            //clientsData.AddClient(client);
            //clientsData.DeleteClientByID(4);
            //clientsData.UpdateClientByID(client);
            //clientList = clientsData.GetClients();
            //clientList = clientsData.GetClientsByName("v");
            //clientsData.GetClientByID(3);
            //OrdersDTO ordersDTO = new OrdersDTO();
            //ordersDTO.AddressID = 1;
            //ordersDTO.ClientsID = 1;
            //ordersDTO.Comment = "awfsadg";
            OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //OrdersDTO ordersDTO = new OrdersDTO();
            //ordersDTO.AddressID = 2;
            //ordersDTO.ClientsID = 2;
            //ordersDTO.Comment = "Petya chto-to kypil";
            //ordersDTO.Datetime = DateTime.Now;
            //OrderListsDTO orderListDTO = new OrderListsDTO();
            //orderListDTO.Amount = 7;
            //orderListDTO.Price = 20;
            //orderListDTO.ProductID = 3;
            //ordersDTO.OrderLists.Add(orderListDTO);
            //orderListDTO = new OrderListsDTO();
            //orderListDTO.Amount = 9;
            //orderListDTO.Price = 25;
            //orderListDTO.ProductID = 2;
            //ordersDTO.OrderLists.Add(orderListDTO);
            //ordersData.AddOrder(ordersDTO);
            List<OrdersDTO> ordersDTOs = new List<OrdersDTO>();
            ordersDTOs = ordersData.GetOrders();
            MapsDTOtoModel map = new MapsDTOtoModel();
            List<OrderModel> orderModels = map.MapOrdersDTOToOrderModel(ordersDTOs);
            //for (int i = 0; i < orderModels.Count; i++)
            //{
            //    orderModels[i].OrderListModel = map.MapOrderListsDTOToOrderListModel(ordersDTOs[i].OrderLists)
            //}
            //DateTime min = DateTime.Now;
            //min.AddYears(-100);
            //DateTime max = DateTime.Now;
            //max.AddYears(100);
            //ordersData.GetOrdersByParams(1, min, max, 1);
            //DateTime? min = DateTime.Now;
            //min = null;
            ////min.AddYears(-100);
            //DateTime? max = DateTime.Now;
            ////max.AddYears(100);
            //ordersData.GetOrdersByParams(1, min, max, 1, 2);
            //ordersData.GetOrdersByParams(null, null, null, null, null);
            //ordersDTO = ordersData.GetOrdersByID(6)[0];
            //ordersDTO.Comment = "Test";
            //ordersData.UpdateOrdersByID(ordersDTO);
        }
    }
}
