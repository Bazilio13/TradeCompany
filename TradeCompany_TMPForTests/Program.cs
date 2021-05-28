using System;
using System.Collections.Generic;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_TMPForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ClientsData clientsData = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

            List<ClientDTO> clientList = new List<ClientDTO>();
            ClientDTO client = new ClientDTO();
            client.Name = "Oleg";
            client.INN = 12345678;
            client.LastOrderDate = DateTime.Now;
            client.Phone = "8999090123";
            client.Type = true;
            client.CorporateBody = false;
            //clientsData.AddClient(client);
            //clientsData.AddClient(client);
            //clientsData.DeleteClientByID(4);

            client.Name = "No Oleg2";
            client.Type = false;
            client.ID = 6;
            client.LastOrderDate = DateTime.Now;
            clientsData.UpdateClientByID(client);
            clientList = clientsData.GetClients();
            //clientsData.GetClientByID(3);
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
            //DateTime min = DateTime.Now;
            //min.AddYears(-100);
            //DateTime max = DateTime.Now;
            //max.AddYears(100);
            //ordersData.GetOrdersByParams(1, min, max, 1);
        }
    }
}
