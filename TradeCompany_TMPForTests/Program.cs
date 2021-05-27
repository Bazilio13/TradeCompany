using System;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_TMPForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdersData ordersData = new OrdersData(@"Data Source=80.78.240.16;Initial Catalog=TradeCompany_DataBase;Integrated Security=True");
            OrdersDTO ordersDTO = new OrdersDTO();
            ordersDTO.AddressID = 1;
            ordersDTO.ClientsID = 1;
            ordersDTO.Comment = "awfsadg";
            ordersDTO.Datetime = DateTime.Now;
            OrderListDTO orderListDTO = new OrderListDTO();
            orderListDTO.Amount = 10;
            orderListDTO.Price = 15;
            orderListDTO.ProductID = 1;
            ordersDTO.OrderLists.Add(orderListDTO);
            orderListDTO.Amount = 4;
            orderListDTO.Price = 10;
            orderListDTO.ProductID = 2;
            ordersDTO.OrderLists.Add(orderListDTO);
            ordersData.AddOrder(ordersDTO);
        }
    }
}
