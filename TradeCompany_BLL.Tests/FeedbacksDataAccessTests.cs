using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class FeedbacksDataAccessTests
    {
        Mock<FeedbacksDataInterface> mock = new Mock<FeedbacksDataInterface>();
        FeedbacksDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new FeedbacksDataAccess(mock.Object);
        }

        [TestCaseSource(typeof(GetFeedbacksSource))]
        public void GetFeedbacksByClientIDTests(int id, List<FeedbackModel> expected, List<FeedBacksDTO> feedbackDTOs)
        {
            mock.Setup(a => a.GetFeedbackByClientID(id)).Returns(feedbackDTOs);

            List<FeedbackModel> actual = dataAccess.GetFeedbacksByClientID(id);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetFeedbacksSource))]
        public void GetFeedbackByOrderIDTests(int id, List<FeedbackModel> expected, List<FeedBacksDTO> feedbackDTOs)
        {
            mock.Setup(a => a.GetFeedbackByOrderID(id)).Returns(feedbackDTOs);

            List<FeedbackModel> actual = dataAccess.GetFeedbackByOrderID(id);

            Assert.AreEqual(expected, actual);
        }

    }


    public class GetFeedbacksSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 
                1,
                new List<FeedbackModel> {  new FeedbackModel(){ID = 1, OrderID = 1, ClientID = 1, DateTime = DateTimeMock.DateTimes[0], Text = "feedbak" } },
                new List<FeedBacksDTO> { new FeedBacksDTO(){ID = 1, OrderID = 1, ClientID = 1, DateTime = DateTimeMock.DateTimes[0], Text = "feedbak"}}};

            yield return new object[] { 
                2,
                new List<FeedbackModel> {}, 
              new List<FeedBacksDTO> {}
            };

            yield return new object[] { 
                3,
                new List<FeedbackModel> { new FeedbackModel { ID = 1, OrderID = 2, ClientID = 3, DateTime = DateTimeMock.DateTimes[1], Text = "feedbak" } },
                new List<FeedBacksDTO> { new FeedBacksDTO { ID = 1, OrderID = 2, ClientID = 3, DateTime = DateTimeMock.DateTimes[1], Text = "feedbak"}} 
            };
        }
    }
}
