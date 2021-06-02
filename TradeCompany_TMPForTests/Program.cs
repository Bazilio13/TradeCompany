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
            //OrdersDTO ordersDTO = new OrdersDTO();
            ProductGroupsData groupsData = new ProductGroupsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            groupsData.DeleteProductGroupByID(3);
            ProductsData productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ProductDTO product = new ProductDTO();
            productsData.GetProducts();
            //productsData.GetProductsByLetter("o");
            // productsData.GetProducts();
            //productsData.GetProductByID(2);

            //productsData.GetProducts();
            //product.Name = "kolbasa";
            //product.StockAmount = 20;
            //product.MeasureUnit = 1;
            //product.MinPrice = 300;
            //DateTime date = DateTime.Now;
            //product.LastSupplyDate = date;
            //productsData.AddProduct(product);
            //productsData.GetProducts();
            //productsData.AddProductToProductGroup(8, 4);
            //product = productsData.GetProductByID(8);
            //product.Name = "maslo slivochnoe";
            //productsData.UpdateProductByID(product);
            //productsData.AddProductToProductGroup(9, 3);
            //productsData.GetProductsByLetter("mas");


            //groupsData.GetProductGroupByID(4);
            //groupsData.GetProductGroupByID(3);
            //ProductGroupDTO group = new ProductGroupDTO();
            //group.Name = "electronika";
            //groupsData.AddProductGroup(group);
            //ProductGroupDTO group = groupsData.GetProductGroupByID(5);
            //group.Name = "электроника";
            //groupsData.UpdateProductGroupByID(group);
            //groupsData.DeleteProductGroupByID(5);
            //groupsData.GetProductGroups();

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
