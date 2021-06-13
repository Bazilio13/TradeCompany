using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class ProductBaseModelMock
    {
        public static List<ProductBaseModel> Models { get; set; } = new List<ProductBaseModel>()
        {
            new ProductBaseModel{ ID = 1, Name = "firstN", StockAmount = 10, MeasureUnitName = "firstMU", WholesalePrice = 50, RetailPrice = 25,
            LastSupplyDate = DateTimeMock.DateTimes[0] },
            new ProductBaseModel{ ID = 2, Name = "secondN", StockAmount = 0, MeasureUnitName = "secondMU", WholesalePrice = 40, RetailPrice = 20,
            LastSupplyDate = DateTimeMock.DateTimes[1] },
            new ProductBaseModel{ ID = 3, Name = "thirdN", StockAmount = 20, MeasureUnitName = "secondMU", WholesalePrice = 10, RetailPrice = 5,
            LastSupplyDate = DateTimeMock.DateTimes[2] },
            new ProductBaseModel{ ID = 4, Name = "forthN", StockAmount = 30, MeasureUnitName = "thirdMU", WholesalePrice = 20, RetailPrice = 15,
            LastSupplyDate = DateTimeMock.DateTimes[2] },
            new ProductBaseModel{ }
        };
    }
}