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
    public class MapsSupplyModelToSupplyDTO_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { SupplyModelMock.Models[0], SupplyDTOMock.DTOsToDB[0] };
            yield return new object[] { SupplyModelMock.Models[1], SupplyDTOMock.DTOsToDB[1] };
            yield return new object[] { SupplyModelMock.Models[2], SupplyDTOMock.DTOsToDB[2] };
        }
    }
}
