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
            ProductsData productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ProductDTO product = new ProductDTO();

            ClientsData cd = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            cd.GetClientsStatistics();
        }
    }
}
