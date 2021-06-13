using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class SupplyModelMock
    {
        public static List<SupplyModel> Models { get; set; } = new List<SupplyModel>()
        { new SupplyModel{ID = 1, DateTime = DateTimeMock.DateTimes[0], Comment = "Comment",
            SupplyListModel = new List<SupplyListModel>{SupplyListModelMock.Models[0],SupplyListModelMock.Models[1] }},
        new SupplyModel{ID = 2, DateTime = DateTimeMock.DateTimes[1], SupplyListModel = new List<SupplyListModel>{SupplyListModelMock.Models[2] }},
        new SupplyModel{ID = 3, DateTime = DateTimeMock.DateTimes[2], SupplyListModel = new List<SupplyListModel>{SupplyListModelMock.Models[3] }}};
    }
}