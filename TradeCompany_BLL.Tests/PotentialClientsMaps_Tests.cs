using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Maps;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.PotentialClientsSourse;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    public class PotentialClientsMaps_Tests
    {
        PotentialClientMaps _map;

        [SetUp]
        public void Setup()
        {
            _map = new PotentialClientMaps();
        }

        [TestCaseSource(typeof(MapPotentialClientDTOsToPotentialClientModels_Sourse))]
        public void MapPotentialClientDTOsToPotentialClientModels_Test(List<PotentialClientDTO> potentialClientDTOs, List<PotentialClientModel> expected)
        {
            List<PotentialClientModel> actual = _map.MapPotentialClientDTOsToPotentialClientModels(potentialClientDTOs);
            Assert.AreEqual(expected, actual);
        }

    }
}
