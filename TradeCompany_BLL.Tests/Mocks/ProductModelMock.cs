using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public class ProductModelMock
    {
        public static List<ProductModel> models { get; set; } = new List<ProductModel>()
        {
            new ProductModel { ID = 1, Name = "firstN", StockAmount = 10, MeasureUnit = 1, MeasureUnitName = "firstMU", WholesalePrice = 50, RetailPrice = 25,
            LastSupplyDate = DateTimeMock.DateTimes[0], Comments = "Comment", Description = "Description"},
        new ProductModel { ID = 2, Name = "secondN", StockAmount = 0, MeasureUnit = 2, MeasureUnitName = "secondMU", WholesalePrice = 40, RetailPrice = 20,
            LastSupplyDate = DateTimeMock.DateTimes[1], Comments = "Comment", Description = "Description"},
        new ProductModel { ID = 3, Name = "thirdN", StockAmount = 20, MeasureUnit = 2, MeasureUnitName = "secondMU", WholesalePrice = 10, RetailPrice = 5,
            LastSupplyDate = DateTimeMock.DateTimes[2], Comments = null, Description = null},
        new ProductModel { ID = 4, Name = "forthN", StockAmount = 30, MeasureUnit = 3, MeasureUnitName = "thirdMU", WholesalePrice = 20, RetailPrice = 15,
            LastSupplyDate = DateTimeMock.DateTimes[2], Comments = null, Description = null},
        new ProductModel { }
        };
    }
}
