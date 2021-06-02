﻿using System;
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
            //ClientsData clientsData = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ClientsData clientsData = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            
            FeedBacksData feedBacksData = new FeedBacksData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            FeedBacksDTO feedBacksDTO = new FeedBacksDTO();
            feedBacksDTO.ID = 17;
            feedBacksDTO.ClientID = 5;
            feedBacksDTO.OrderID = 7;
            feedBacksDTO.DateTime = DateTime.Now;
            feedBacksDTO.Text = "проба";

            //List<ClientDTO> clientList = new List<ClientDTO>();
            //ClientDTO client = new ClientDTO();
            //feedBacksData.AddFeedback(feedBacksDTO);
            feedBacksData.UpdateFeedBackById(feedBacksDTO);

           // feedBacksDTO = feedBacksData.GetFeedbackByID(4);



            List<ClientDTO> clientList = new List<ClientDTO>();
            ClientDTO client = new ClientDTO();

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
            //OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
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
            //ordersData.GetOrders();
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

                                                            //Test AddressData//
            AddressesData addressesData = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<AddressDTO> addressesList = new List<AddressDTO>();
            //addressesList = addressesData.GetAddresses();
            //addressesList = addressesData.GetAddressesByID(1);
            //addressesList = addressesData.GetAddressesByID(5);         
            //addressesData.AddAddress(5, "hsf 18");
            //addressesData.AddAddress(3, "ujsdn 56");
            //addressesList = addressesData.GetAddresses();
            addressesData.DeleteAddressByIDAndAddress(3, "ujsdn 56");
            addressesList = addressesData.GetAddresses();


        }
    }
}
