using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Tests.Mocks;

namespace TradeCompany_BLL.Tests.ClientMapSource
{
    class MapClientModelToClientDTO_Source:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { ClientListModelMock.Model[0], ClientListDTOMock.DTOsFromDB[0]};
            yield return new object[] { ClientListModelMock.Model[1], ClientListDTOMock.DTOsFromDB[1] };
            yield return new object[] { ClientListModelMock.Model[2], ClientListDTOMock.DTOsFromDB[2] };
        }
    }

}

