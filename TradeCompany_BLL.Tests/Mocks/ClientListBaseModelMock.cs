using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class ClientListBaseModelMock
    {
        public static List<ClientBaseModel> Model { get; set; } = new List<ClientBaseModel>()
        { new ClientBaseModel(){ ID = 4, Name = "ООО ULO", Phone = "89997777777"},
          new ClientBaseModel(){ ID = 11, Name = "Oleg", Phone = "+7(123)944-98-12", ContactPerson = "Name_5"},
          new ClientBaseModel(){ ID = 13, Name = "Belr", Phone = "0909012"},
          new ClientBaseModel(){ ID = 2, LastOrderDate = DateTimeMock.DateTimes[1] ,Name = "Name1", Phone = "000000"},
          new ClientBaseModel(){ ID = 1, LastOrderDate = DateTimeMock.DateTimes[0] ,Name = "Name2", Phone = "123123"},
          new ClientBaseModel(){ ID = 100, Name = "Name3", Phone = "+9(222)111-11-11" }
        };
    }
}
