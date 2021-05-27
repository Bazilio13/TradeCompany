using System;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_TMPForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            //OrdersDTO ordersDTO = new OrdersDTO();
            //ordersDTO.AddressID = 1;
            //ordersDTO.ClientsID = 1;
            //ordersDTO.Comment = "awfsadg";
            //ordersDTO.Datetime = DateTime.Now;
            //OrderListsDTO orderListDTO = new OrderListsDTO();
            //orderListDTO.Amount = 10;
            //orderListDTO.Price = 15;
            //orderListDTO.ProductID = 3;
            //ordersDTO.OrderLists.Add(orderListDTO);
            //orderListDTO = new OrderListsDTO();
            //orderListDTO.Amount = 4;
            //orderListDTO.Price = 10;
            //orderListDTO.ProductID = 2;
            //ordersDTO.OrderLists.Add(orderListDTO);
            //ordersData.AddOrder(ordersDTO);
            //ordersData.GetOrders();
            DateTime min = DateTime.Now;
            min.AddYears(-100);
            DateTime max = DateTime.Now;
            max.AddYears(100);
            ordersData.GetOrdersByParams(1, min, max, 1);
        }
    }
}
