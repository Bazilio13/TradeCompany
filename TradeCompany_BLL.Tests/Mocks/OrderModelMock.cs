using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class OrderModelMock
    {
        public static List<OrderModel> Models { get; set; } = new List<OrderModel>()
        {
            new OrderModel{ID = 1, ClientsID = 1,  AddressID = 1, Address = "aaa", DateTime  = DateTimeMock.DateTimes[0], Comment = "comment", Client = "ООО ULO",
                ClientsPhone = "89997777777", Summ = 177, OrderListModel = new List<OrderListModel>{ OrderListModelMock.Models[0], OrderListModelMock.Models[1] } },
            new OrderModel{ID = 2, ClientsID = 1,  AddressID = 1, Address = "bbb", DateTime  = DateTimeMock.DateTimes[1], Client = "ООО ULO", ClientsPhone = "89997777777",
            Summ = 195, OrderListModel = new List<OrderListModel>{ OrderListModelMock.Models[2] } },
            new OrderModel{ID = 3, ClientsID = 2, AddressID = 2, Address = "ccc", DateTime  = DateTimeMock.DateTimes[2], Comment = "text 123", Client = "Oleg", ClientsPhone = "+7(123)944-98-12",
            Summ = 195, OrderListModel = new List<OrderListModel>{ OrderListModelMock.Models[2] } },
            new OrderModel{ID = 4, ClientsID = 3, AddressID = 3, Address = "ddd", DateTime  = DateTimeMock.DateTimes[1], Client = "Belr", ClientsPhone = "0909012",
            OrderListModel = new List<OrderListModel>() }
        };
    }
}
