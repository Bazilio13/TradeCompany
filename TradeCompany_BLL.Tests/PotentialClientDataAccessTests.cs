using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.DataAccess;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class PotentialClientDataAccessTests
    {
        Mock<PotentialClientDataInterface> mock = new Mock<PotentialClientDataInterface>();
        PotentialClientsDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new PotentialClientsDataAccess(mock.Object);
        }


        [TestCaseSource(typeof(GetPotentialClientsByProductsIDsSource))]
        public void GetPotentialClientsByProductsIDsTests(List<PotentialClientDTO> potencialClientDTOs, List<PotentialClientModel> expected, List<int> ids, DateTime clientsActivityStart, string clientSearch = null)
        {
            mock.Setup(a => a.GetPotentialClientDTOs(ids, clientsActivityStart, 2, clientSearch)).Returns(potencialClientDTOs);

            List<PotentialClientModel> actual = dataAccess.GetPotentialClientsByProductsIDs(ids, clientSearch);

            Assert.AreEqual(expected, actual);
        }

    }


    public class GetPotentialClientsByProductsIDsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 
                new List<PotentialClientDTO> { },
                new List<PotentialClientModel> { },
                new List<int>(){ 1, 2, 3},
                DateTimeMock.DateTimes[0],
                "a"
            };

        }
    }
}
