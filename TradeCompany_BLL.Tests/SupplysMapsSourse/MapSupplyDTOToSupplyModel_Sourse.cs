using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.SupplysMapsSourse
{
    public class MapSupplyDTOToSupplyModel_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {new List<SupplyDTO>(){SupplyDTOMock.DTOs[0], SupplyDTOMock.DTOs[1], SupplyDTOMock.DTOs[2] },
                                       new List<SupplyModel>(){ SupplyModelMock.Models[0], SupplyModelMock.Models[1] , SupplyModelMock.Models[2] }
            };
        }
    }
}

