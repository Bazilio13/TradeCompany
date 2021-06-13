using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class ClientListDTOMock
    {
        public static List<ClientDTO> DTOsFromDB { get; set; } = new List<ClientDTO>()
        { new ClientDTO(){ ID = 4, Name = "ООО ULO", Phone = "89997777777", INN = "4815162342"},
          new ClientDTO(){ ID = 11, Name = "Oleg", Phone = "+7(123)944-98-12", Type = false, ContactPerson = "Name_5"},
          new ClientDTO(){ ID = 13, Name = "Belr", Phone = "0909012", INN = "48151"},
          new ClientDTO(){ ID = 2, LastOrderDate = DateTimeMock.DateTimes[1] ,Name = "Name1", Phone = "000000"},
          new ClientDTO(){ ID = 1, LastOrderDate = DateTimeMock.DateTimes[0] ,Name = "Name2", Phone = "123123"},
          new ClientDTO(){ ID = 100, Name = "Name3", Phone = "+9(222)111-11-11" }
        };

    }
}
