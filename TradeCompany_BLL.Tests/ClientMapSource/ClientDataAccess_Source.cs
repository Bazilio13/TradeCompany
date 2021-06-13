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
    class GetClientsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { ClientListDTOMock.DTOsFromDB, ClientListBaseModelMock.Model };
            yield return new object[] { new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[0], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[0], ClientListBaseModelMock.Model[2] } };
            yield return new object[] { new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[1], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[1], ClientListBaseModelMock.Model[2] } };
        }
    }

    class GetClientsBySearchTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {"цветы", ClientListDTOMock.DTOsFromDB, ClientListBaseModelMock.Model };
            yield return new object[] {"красный", new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[0], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[0], ClientListBaseModelMock.Model[2] } };
            yield return new object[] {"желтые", new List<ClientDTO>() { ClientListDTOMock.DTOsFromDB[1], ClientListDTOMock.DTOsFromDB[2] }, new List<ClientBaseModel>() { ClientListBaseModelMock.Model[1], ClientListBaseModelMock.Model[2] } };
        }
    }

    class GetWishListByClientIDSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {1,  WishListDTOMock.DTOsFromDB, WishListModelMock.Model };
            yield return new object[] {2,  new List<WishDTO>() { WishListDTOMock.DTOsFromDB[1], WishListDTOMock.DTOsFromDB[2] },
                new List<WishModel>(){WishListModelMock.Model[1], WishListModelMock.Model[2] }};
            yield return new object[] {3,  new List<WishDTO>() { WishListDTOMock.DTOsFromDB[0], WishListDTOMock.DTOsFromDB[3] },
                new List<WishModel>(){WishListModelMock.Model[0], WishListModelMock.Model[3] }};
        }
    }

    class GetClientByClientIDSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {1, ClientListModelMock.Model[0], ClientListDTOMock.DTOsFromDB[0] };
            yield return new object[] {2,  ClientListModelMock.Model[1], ClientListDTOMock.DTOsFromDB[1] };
            yield return new object[] {3,  ClientListModelMock.Model[2], ClientListDTOMock.DTOsFromDB[2] };
        }
    }

    class GetLastClientSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { ClientListModelMock.Model[0], ClientListDTOMock.DTOsFromDB[0] };
            yield return new object[] { ClientListModelMock.Model[1], ClientListDTOMock.DTOsFromDB[1] };
            yield return new object[] { ClientListModelMock.Model[2], ClientListDTOMock.DTOsFromDB[2] };
        }
    }
}
