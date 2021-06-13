using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class ClientListModelMock
    {
        public static List<ClientModel> Model { get; set; } = new List<ClientModel>()
        { new ClientModel(){ ID = 4, Name = "ООО ULO", Phone = "89997777777", INN = "4815162342", RegistrationDate = DateTimeMock.DateTimes[1]},
          new ClientModel(){ ID = 11, Name = "Oleg", Phone = "+7(123)944-98-12", Type = false, ContactPerson = "Name_5", RegistrationDate = DateTimeMock.DateTimes[2]},
          new ClientModel(){ ID = 13, Name = "Belr", Phone = "0909012", INN = "48151", RegistrationDate = DateTimeMock.DateTimes[0]},
          new ClientModel(){ ID = 2, LastOrderDate = DateTimeMock.DateTimes[1] ,Name = "Name1", Phone = "000000",  RegistrationDate = DateTimeMock.DateTimes[0]},
          new ClientModel(){ ID = 1, LastOrderDate = DateTimeMock.DateTimes[0] ,Name = "Name2", Phone = "123123",  RegistrationDate = DateTimeMock.DateTimes[0]},
          new ClientModel(){ ID = 100, Name = "Name3", Phone = "+9(222)111-11-11",  RegistrationDate = DateTimeMock.DateTimes[0]}
        };

    }
}
