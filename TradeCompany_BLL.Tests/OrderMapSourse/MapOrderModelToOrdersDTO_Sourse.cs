using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Tests.Mocks;

namespace TradeCompany_BLL.Tests.OrderMapSourse
{
    public class MapOrderModelToOrdersDTO_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { OrderModelMock.Models[0], OrdersDTOMock.dTOsToDB[0] };
            yield return new object[] { OrderModelMock.Models[1], OrdersDTOMock.dTOsToDB[1] };
            yield return new object[] { OrderModelMock.Models[2], OrdersDTOMock.dTOsToDB[2] };
            yield return new object[] { OrderModelMock.Models[3], OrdersDTOMock.dTOsToDB[3] };
        }
    }
}
