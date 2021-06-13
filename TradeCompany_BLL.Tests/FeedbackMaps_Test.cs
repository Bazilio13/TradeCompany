using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Maps;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    public class FeedbackMaps_Test
    {
        FeedbackMaps _map;
        [SetUp]
        public void Setup()
        {
            _map = new FeedbackMaps();
        }

        [TestCaseSource(typeof(MapsFeedbackModelToFeedbackDTO_Sourse))]
        public void MapsFeedbackModelToFeedbackDTO(FeedbackModel feedback, FeedBacksDTO expected)
        {
            FeedBacksDTO actual = _map.MapsFeedbackModelToFeedbackDTO(feedback);
            Assert.AreEqual(expected, actual);
        }

    }

    public class MapsFeedbackModelToFeedbackDTO_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new FeedbackModel { ID = 1, OrderID = 1, ClientID = 1, DateTime = DateTimeMock.DateTimes[0], Text = "feedbak" },
            new FeedBacksDTO { ID = 1, OrderID = 1, ClientID = 1, DateTime = DateTimeMock.DateTimes[0], Text = "feedbak"}};
            yield return new object[] { new FeedbackModel(), new FeedBacksDTO() };
            yield return new object[] { new FeedbackModel { ID = 1, OrderID = 2, ClientID = 3, DateTime = DateTimeMock.DateTimes[1], Text = "feedbak" },
            new FeedBacksDTO { ID = 1, OrderID = 2, ClientID = 3, DateTime = DateTimeMock.DateTimes[1], Text = "feedbak"}};
        }
    }
}
