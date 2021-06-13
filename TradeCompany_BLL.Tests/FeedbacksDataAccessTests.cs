using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL;

namespace TradeCompany_BLL.Tests
{
    class FeedbacksDataAccessTests
    {
        Mock<FeedbacksDataInterface> mock = new Mock<FeedbacksDataInterface>();
        FeedbacksDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new ClientsDataAccess(mock.Object);
        }
    }
}
