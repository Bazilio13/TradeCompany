using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.ClientMapSource;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class ClientDataAccessTests
    {
        Mock<ClientsDataInterface> mock = new Mock<ClientsDataInterface>();
        ClientsDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new ClientsDataAccess(mock.Object);
        }

        [TestCaseSource(typeof(GetClientsSource))]
        public void GetClientsTest(List<ClientDTO> clientDTOs, List<ClientBaseModel> expected)
        {
            mock.Setup(a => a.GetClients()).Returns(clientDTOs);

            List<ClientBaseModel> actual = dataAccess.GetClients();

            Assert.AreEqual(expected, actual);
        }


        [TestCaseSource(typeof(GetClientsBySearchTests))]
        public void GetClientsBySearchTests(string textSearh, List<ClientDTO> clientDTOs, List<ClientBaseModel> expected)
        {
            mock.Setup(a => a.GetClientsByName(textSearh)).Returns(clientDTOs);

            List<ClientBaseModel> actual = dataAccess.GetClientsBySearch(textSearh);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetWishListByClientIDSource))]
        public void GetWishListByClientIDTests(int id, List<WishDTO> wishDTOs, List<WishModel> expected)
        {
            mock.Setup(a => a.GetWishesListByClientID(id)).Returns(wishDTOs);

            List<WishModel> actual = dataAccess.GetWishListByClientID(id);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetClientByClientIDSource))]
        public void GetClientByClientIDTests(int id, ClientModel expected, ClientDTO clientDTO)
        {
            mock.Setup(a => a.GetClientByID(id)).Returns(clientDTO);

            ClientModel actual = dataAccess.GetClientByClientID(id);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetLastClientSource))]
        public void GetLastClientTests(ClientModel expected, ClientDTO clientDTO)
        {
            mock.Setup(a => a.GetLastClient()).Returns(clientDTO);

            ClientModel actual = dataAccess.GetLastClient();

            Assert.AreEqual(expected, actual);
        }


    }
}
