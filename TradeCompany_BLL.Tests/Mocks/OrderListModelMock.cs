using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class OrderListModelMock
    {
        public static List<OrderListModel> Models { get; set; } = new List<OrderListModel>()
        {
            new OrderListModel {ID = 1, OrderID = 1, ProductID = 1, Amount = 10, Price = 15, ProductName = "firstN", ProductMeasureUnit = "firstMU" },
            new OrderListModel {ID = 2, OrderID = 1, ProductID = 2, Amount = 3, Price = 9, ProductName = "secondN", ProductMeasureUnit = "secondMU"},
            new OrderListModel {ID = 3, OrderID = 2, ProductID = 4, Amount = 13, Price = 15, ProductName = "forthN", ProductMeasureUnit = "thirdMU"},
            new OrderListModel {ID = 4, OrderID = 3, ProductID = 5, Amount = 24, Price = 44},
            new OrderListModel {ID = 5, OrderID = 4, ProductID = 3, Amount = 32, Price = 25, ProductName = "thirdN", ProductMeasureUnit = "secondMU"}
        };
    }
}
