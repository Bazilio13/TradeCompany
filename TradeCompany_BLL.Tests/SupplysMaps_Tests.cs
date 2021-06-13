using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.SypplysMaps;
using TradeCompany_BLL.Tests.SupplysMapsSourse;
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

        [TestCaseSource(typeof(MapSupplyDTOToSupplyModel_Sourse))]
        public void MapSupplyDTOToSupplyModel_Test(List<SupplyDTO> supplyDTO, List<SupplyModel> expected)
        {
            List<SupplyModel> actual = _map.MapSupplyDTOToSupplyModel(supplyDTO);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapSupplyListDTOToSupplyListModel_Sourse))]
        public void MapSupplyListDTOToSupplyListModel_Test(List<SupplyListDTO> supplyListsDTO, List<SupplyListModel> expected)
        {
            List<SupplyListModel> actual = _map.MapSupplyListDTOToSupplyListModel(supplyListsDTO);
            Assert.AreEqual(expected, actual);
        }

    }
}
