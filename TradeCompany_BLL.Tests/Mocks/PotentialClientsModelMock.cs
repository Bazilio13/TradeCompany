using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class PotentialClientsModelMock
    {
        public static List<PotentialClientModel> Models { get; set; } = new List<PotentialClientModel>()
        {
            new PotentialClientModel{ ID = 1, ClientName = "firstN", ContactPerson = "firstCP", Phone = "111", E_mail = "1@1", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductBaseModel>{ ProductBaseModelMock.Models[0], ProductBaseModelMock.Models[1] } },
            new PotentialClientModel{ ID = 2, ClientName = "secondN", ContactPerson = "secondCP", Phone = "222", E_mail = "2@2", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[1], Products = new List<ProductBaseModel>{ ProductBaseModelMock.Models[2] } },
            new PotentialClientModel{ ID = 3, ClientName = "thirdN", ContactPerson = "thirdCP", Phone = "333", E_mail = "3@3", Type = true,
            LastOrderDate = DateTimeMock.DateTimes[2], Products = new List<ProductBaseModel>() },
            new PotentialClientModel{ ID = 4, ClientName = "fourthN", ContactPerson = "fourthCP", Phone = "444", E_mail = "4@4", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductBaseModel>{ ProductBaseModelMock.Models[1], ProductBaseModelMock.Models[2], ProductBaseModelMock.Models[3] } },
            new PotentialClientModel{ ID = 5, ClientName = "fifthN", ContactPerson = "fifthCP", Phone = "555", E_mail = "5@5", Type = true,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductBaseModel>{ ProductBaseModelMock.Models[4] } }
        };
    }
}