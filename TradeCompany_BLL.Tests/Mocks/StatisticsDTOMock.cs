using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class StatisticsDTOMock
    {
        public static List<StatisticsGroupsDTO> GroupDTO { get; set; } = new List<StatisticsGroupsDTO>()
        {
            new StatisticsGroupsDTO(){ Amount = 10, CategoryName = "categoryName_1", ID =10, Summ = 100, LastOrderDate = DateTimeMock.DateTimes[1], LastSupplyDate = DateTimeMock.DateTimes[0] , StockAmount = 100},
            new StatisticsGroupsDTO(){ Amount = 100, CategoryName = "categoryName_2", ID =101, Summ = 600, LastOrderDate = DateTimeMock.DateTimes[0], LastSupplyDate = DateTimeMock.DateTimes[1] , StockAmount = 1000},
            new StatisticsGroupsDTO(){ Amount = 12, CategoryName = "categoryName_3", ID =11, Summ = 6000, LastOrderDate = DateTimeMock.DateTimes[1], LastSupplyDate = DateTimeMock.DateTimes[2] , StockAmount = 1000}
        };

        public static List<StatisticsProductDTO> ProductDTO { get; set; } = new List<StatisticsProductDTO>()
        {
            new StatisticsProductDTO(){ Amount = 10, Name = "categoryName_1", ID =10, Summ = 100, LastOrderDate = DateTimeMock.DateTimes[1], LastSupplyDate = DateTimeMock.DateTimes[0] , StockAmount = 100},
            new StatisticsProductDTO(){ Amount = 100, Name = "categoryName_2", ID =101, Summ = 600, LastOrderDate = DateTimeMock.DateTimes[0], LastSupplyDate = DateTimeMock.DateTimes[1] , StockAmount = 1000},
            new StatisticsProductDTO(){ Amount = 12, Name = "categoryName_3", ID =11, Summ = 6000, LastOrderDate = DateTimeMock.DateTimes[1], LastSupplyDate = DateTimeMock.DateTimes[2] , StockAmount = 1000}
        };

    }
}
