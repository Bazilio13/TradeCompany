using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Tests.Mocks;

namespace TradeCompany_BLL.Tests.ClientMapSource
{
    class MapClientDTOToClientModel_Source:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { ClientListDTOMock.DTOsFromDB[0], ClientListModelMock.Model[0] };
            yield return new object[] { ClientListDTOMock.DTOsFromDB[1], ClientListModelMock.Model[1] };
            yield return new object[] { ClientListDTOMock.DTOsFromDB[2], ClientListModelMock.Model[2] };
        }
    }
}
