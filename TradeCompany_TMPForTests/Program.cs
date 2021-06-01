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
            OrdersData ordersData = new OrdersData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            OrdersDTO ordersDTO = new OrdersDTO();

            ProductsData productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ProductDTO product = new ProductDTO();
            //productsData.GetProductByID(2);
            //productsData.GetProductsByLetter("o");
            // productsData.GetProducts();
            //productsData.DeleteGroupFromProduct(2, 2);
            //productsData.GetProducts();
            //product.Name = "maslo";
            //product.StockAmount = 30;
            //product.MeasureUnit = 1;
            //product.MinPrice = 200;
            //product.MaxPrice = 500;
            //DateTime date = DateTime.Now;
            //product.LastSupplyDate = date;
            //productsData.AddProduct(product);
            //productsData.GetProducts();
            productsData.AddProductToProductGroup(8, 3);
            productsData.GetProducts();


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
