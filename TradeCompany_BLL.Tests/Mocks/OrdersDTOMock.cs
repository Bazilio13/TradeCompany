using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class OrdersDTOMock
    {
        public static List<OrdersDTO> dTOsFromDB { get; set; } = new List<OrdersDTO>()
        {
            new OrdersDTO{ID = 1, ClientsID = 1, ClientDTO = ClientListDTOMock.DTOsFromDB[0], AddressID = 1, Address = "aaa", DateTime  = DateTimeMock.DateTimes[0], Comment = "comment",
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsFromDB[0], OrderListDTOMock.dTOsFromDB[1] } },
            new OrdersDTO{ID = 2, ClientsID = 1, ClientDTO = ClientListDTOMock.DTOsFromDB[0], AddressID = 1, Address = "bbb", DateTime  = DateTimeMock.DateTimes[1],
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsFromDB[2] } },
            new OrdersDTO{ID = 3, ClientsID = 2, ClientDTO = ClientListDTOMock.DTOsFromDB[1], AddressID = 2, Address = "ccc", DateTime  = DateTimeMock.DateTimes[2], Comment = "text 123",
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsFromDB[2] } },
            new OrdersDTO{ID = 4, ClientsID = 3, ClientDTO = ClientListDTOMock.DTOsFromDB[2], AddressID = 3, Address = "ddd", DateTime  = DateTimeMock.DateTimes[1],
            OrderLists = new List<OrderListsDTO>() }
        };
        public static List<OrdersDTO> dTOsToDB { get; set; } = new List<OrdersDTO>()
        {
            new OrdersDTO{ID = 1, ClientsID = 1, AddressID = 1, Address = "aaa", DateTime  = DateTimeMock.DateTimes[0], Comment = "comment",
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsToDB[0], OrderListDTOMock.dTOsToDB[1] } },
            new OrdersDTO{ID = 2, ClientsID = 1, AddressID = 1, Address = "bbb", DateTime  = DateTimeMock.DateTimes[1],
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsToDB[2] } },
            new OrdersDTO{ID = 3, ClientsID = 2, AddressID = 2, Address = "ccc", DateTime  = DateTimeMock.DateTimes[2], Comment = "text 123",
            OrderLists = new List<OrderListsDTO>{ OrderListDTOMock.dTOsToDB[2] } },
            new OrdersDTO{ID = 4, ClientsID = 3, AddressID = 3, Address = "ddd", DateTime  = DateTimeMock.DateTimes[1],
            OrderLists = new List<OrderListsDTO>() }
        };
    }
}
