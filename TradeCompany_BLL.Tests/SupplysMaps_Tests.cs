using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.SypplysMaps;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    public class SupplysMaps_Tests
    {
        SupplysMaps _map;

        [SetUp]
        public void Setup()
        {
            _map = new SupplysMaps();
        }

        public void MapSupplyDTOToSupplyModel_Test(List<SupplyDTO> supplyDTO, List<SupplyModel> expected)
        {
            List<SupplyModel> actual = _map.MapSupplyDTOToSupplyModel(supplyDTO);
            Assert.AreEqual(expected, actual);
        }

    }
}
