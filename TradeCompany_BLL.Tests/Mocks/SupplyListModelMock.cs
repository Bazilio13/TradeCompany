using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class SupplyListModelMock
    {
        public static List<SupplyListModel> Models { get; set; } = new List<SupplyListModel>()
        { new SupplyListModel{ ID = 1, ProductID = 1, Amount = 10, ProductMeasureUnit = "firstMU", ProductName = "firstN"},
          new SupplyListModel{ ID = 2, ProductID = 2, Amount = 50, ProductMeasureUnit = "secondMU", ProductName = "secondN"},
          new SupplyListModel{ ID = 3, ProductID = 2, Amount = 50, ProductMeasureUnit = "secondMU", ProductName = "secondN"},
          new SupplyListModel{ ID = 4, ProductID = 3, Amount = 20, ProductMeasureUnit = "secondMU", ProductName = "thirdN"},
          new SupplyListModel{ ID = 5, ProductID = 4, Amount = 40, ProductMeasureUnit = "thirdMU", ProductName = "forthN"}};
    }
}
