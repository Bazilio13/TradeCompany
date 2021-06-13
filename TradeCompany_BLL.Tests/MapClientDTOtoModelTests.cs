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
    class MapClientDTOtoModelTests
    {
        MapsDTOtoModel mapsDTOtoModel = new MapsDTOtoModel();


        [TestCaseSource(typeof(MapClientDTOToClientModel_Source))]
        public void MapClientDTOToClientModelTests(ClientDTO clientsDTO, ClientModel expected)
        {
            ClientModel actual = mapsDTOtoModel.MapClientDTOToClientModel(clientsDTO);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapClientsListDTOtoClientListBaseModel_Source))]
        public void MapClientsDTOToClientsModelTests(List<ClientDTO> clientsDTO, List<ClientBaseModel> expected)
        {
            List<ClientBaseModel> actual = mapsDTOtoModel.MapClientDTOToClientsBaseModelList(clientsDTO);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapWishesDTOToWishesModelList_Source))]
        public void MapWishesDTOToWishesModelListTests(List<WishDTO> wishDTO, List<WishModel> expected)
        {
            List<WishModel> actual = mapsDTOtoModel.MapWishesDTOToWishesModelList(wishDTO);
            Assert.AreEqual(expected, actual);
        }





    }
}
