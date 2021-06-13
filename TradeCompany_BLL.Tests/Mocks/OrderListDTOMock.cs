using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class OrderListDTOMock
    {
        public static List<OrderListsDTO> dTOsFromDB { get; set; } = new List<OrderListsDTO>()
        {
            new OrderListsDTO {ID = 1, OrderID = 1, ProductID = 1, Amount = 10, Price = 15, productDTO = ProductsDTOMock.DTOsFromDB[0]},
            new OrderListsDTO {ID = 2, OrderID = 1, ProductID = 2, Amount = 3, Price = 9, productDTO = ProductsDTOMock.DTOsFromDB[1]},
            new OrderListsDTO {ID = 3, OrderID = 2, ProductID = 4, Amount = 13, Price = 15, productDTO = ProductsDTOMock.DTOsFromDB[3]},
            new OrderListsDTO {ID = 4, OrderID = 3, ProductID = 5, Amount = 24, Price = 44, productDTO = ProductsDTOMock.DTOsFromDB[4]},
            new OrderListsDTO {ID = 5, OrderID = 4, ProductID = 3, Amount = 32, Price = 25, productDTO = ProductsDTOMock.DTOsFromDB[2]}
        };
        public static List<OrderListsDTO> dTOsToDB { get; set; } = new List<OrderListsDTO>()
        {
            new OrderListsDTO {ID = 1, OrderID = 1, ProductID = 1, Amount = 10, Price = 15},
            new OrderListsDTO {ID = 2, OrderID = 1, ProductID = 2, Amount = 3, Price = 9},
            new OrderListsDTO {ID = 3, OrderID = 2, ProductID = 4, Amount = 13, Price = 15},
            new OrderListsDTO {ID = 4, OrderID = 3, ProductID = 5, Amount = 24, Price = 44},
            new OrderListsDTO {ID = 5, OrderID = 4, ProductID = 3, Amount = 32, Price = 25}
        };
    }
}