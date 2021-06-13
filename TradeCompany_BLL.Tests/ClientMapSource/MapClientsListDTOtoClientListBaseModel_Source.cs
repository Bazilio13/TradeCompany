using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.ClientMapSource
{
    class MapClientsListDTOtoClientListBaseModel_Source:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { ClientListDTOMock.DTOsFromDB, ClientListBaseModelMock.Model };
            yield return new object[] { new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[0], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[0], ClientListBaseModelMock.Model[2] } };
            yield return new object[] { new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[1], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[1], ClientListBaseModelMock.Model[2] } };
        }
    }
}
