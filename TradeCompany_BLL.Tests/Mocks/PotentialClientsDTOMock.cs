using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class PotentialClientsDTOMock
    {
        public static List<PotentialClientDTO> DTOs { get; set; } = new List<PotentialClientDTO>()
        { 
            new PotentialClientDTO{ ID = 1, ClientName = "firstN", ContactPerson = "firstCP", Phone = "111", E_mail = "1@1", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductDTO>{ ProductsDTOMock.DTOsFromDB[0], ProductsDTOMock.DTOsFromDB[1] } },
            new PotentialClientDTO{ ID = 2, ClientName = "secondN", ContactPerson = "secondCP", Phone = "222", E_mail = "2@2", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[1], Products = new List<ProductDTO>{ ProductsDTOMock.DTOsFromDB[2] } },
            new PotentialClientDTO{ ID = 3, ClientName = "thirdN", ContactPerson = "thirdCP", Phone = "333", E_mail = "3@3", Type = true,
            LastOrderDate = DateTimeMock.DateTimes[2], Products = new List<ProductDTO>() },
            new PotentialClientDTO{ ID = 4, ClientName = "fourthN", ContactPerson = "fourthCP", Phone = "444", E_mail = "4@4", Type = false,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductDTO>{ ProductsDTOMock.DTOsFromDB[1], ProductsDTOMock.DTOsFromDB[2], ProductsDTOMock.DTOsFromDB[3] } },
            new PotentialClientDTO{ ID = 5, ClientName = "fifthN", ContactPerson = "fifthCP", Phone = "555", E_mail = "5@5", Type = true,
            LastOrderDate = DateTimeMock.DateTimes[0], Products = new List<ProductDTO>{ ProductsDTOMock.DTOsFromDB[4] } }
        };
    }
}
