using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.ClientMapSource;
using TradeCompany_BLL.Tests.StatisticMapSource;
using TradeCompany_BLL.Tests.SupplysMapsSourse;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class MapStatisticsDTOToStatisticsModelTests
    {
        MapsDTOtoModel mapDTOtoModel = new MapsDTOtoModel();


        [TestCaseSource(typeof(MapStatisticsGroursDTOToStatisticsGroursModel_Source))]
        public void MapStatisticsGroursDTOToStatisticsGroursModelTests(List<StatisticsGroupsDTO> statisticsDTO, List<StatisticsGroupsModel> expected)
        {
            List<StatisticsGroupsModel> actual = mapDTOtoModel.MapStatisticsGroursDTOToStatisticsGroursModel(statisticsDTO);
            Assert.AreEqual(expected, actual);
        }
        

        [TestCaseSource(typeof(MapStatisticsProductsDTOToStatisticsProductsModel_Source))]
        public void MapStatisticsProductsDTOToStatisticsProductsModelTests(List<StatisticsProductDTO> statisticsDTO, List<StatisticsProductModel> expected)
        {
            List<StatisticsProductModel> actual = mapDTOtoModel.MapStatisticsProductsDTOToStatisticsProductsModel(statisticsDTO);
            Assert.AreEqual(expected, actual);
        }



    }
}
