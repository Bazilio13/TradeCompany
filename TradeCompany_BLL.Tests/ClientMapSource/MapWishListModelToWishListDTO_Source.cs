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
    class MapWishListModelToWishListDTO_Source : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { WishListModelMock.Model, WishListDTOMock.DTOsFromDB};
            yield return new object[] { new List<WishModel>() { WishListModelMock.Model[1], WishListModelMock.Model[0] }, new List<WishDTO>() { WishListDTOMock.DTOsFromDB[1], WishListDTOMock.DTOsFromDB[0] } };
            yield return new object[] { new List<WishModel>() { WishListModelMock.Model[1], WishListModelMock.Model[2] }, new List<WishDTO>() { WishListDTOMock.DTOsFromDB[1], WishListDTOMock.DTOsFromDB[2] } };
        }
    }
}
