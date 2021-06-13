using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.ClientMapSource;
using TradeCompany_BLL.Tests.SupplysMapsSourse;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class MapClientModelToClientDTOTests
    {
        MapsModelToDTO mapModelToDTO = new MapsModelToDTO();


        [TestCaseSource(typeof(MapClientModelToClientDTO_Source))]
        public void MapClientModelToClientDTOTest(ClientModel clientModel, ClientDTO expected)
        {
            ClientDTO actual = mapModelToDTO.MapClientModelToClientDTO(clientModel);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapWishListModelToWishListDTO_Source))]
        public void MapWishListModelToWishListDTOTests(List<WishModel> wishListModel, List<WishDTO> expected)
        {
            List<WishDTO> actual = mapModelToDTO.MapWishListModelToWishListDTO(wishListModel);
            Assert.AreEqual(expected, actual);
        }

    }
}
