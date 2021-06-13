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
    class MapWishesDTOToWishesModelList_Source : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { WishListDTOMock.DTOsFromDB, WishListModelMock.Model};
            yield return new object[] { new List<WishDTO>() { WishListDTOMock.DTOsFromDB[1], WishListDTOMock.DTOsFromDB[2] }, 
                new List<WishModel>(){WishListModelMock.Model[1], WishListModelMock.Model[2] }};
            yield return new object[] { new List<WishDTO>() { WishListDTOMock.DTOsFromDB[0], WishListDTOMock.DTOsFromDB[3] }, 
                new List<WishModel>(){WishListModelMock.Model[0], WishListModelMock.Model[3] }};
        }
    }
}
