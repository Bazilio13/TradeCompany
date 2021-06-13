using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.PotentialClientsSourse
{
    public class MapPotentialClientDTOsToPotentialClientModels_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new List<PotentialClientDTO> { },
                                        new List<PotentialClientModel> { } };
            yield return new object[] { new List<PotentialClientDTO> { PotentialClientsDTOMock.DTOs[0] }, 
                                        new List<PotentialClientModel> { PotentialClientsModelMock.Models[0] } };
            yield return new object[] { new List<PotentialClientDTO> { PotentialClientsDTOMock.DTOs[1], PotentialClientsDTOMock.DTOs[2] },
                                        new List<PotentialClientModel> { PotentialClientsModelMock.Models[1], PotentialClientsModelMock.Models[2] } };
            yield return new object[] { new List<PotentialClientDTO> { PotentialClientsDTOMock.DTOs[3], PotentialClientsDTOMock.DTOs[4] },
                                        new List<PotentialClientModel> { PotentialClientsModelMock.Models[3], PotentialClientsModelMock.Models[4] } };
        }
    }
}
