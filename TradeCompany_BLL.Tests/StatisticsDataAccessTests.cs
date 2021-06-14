using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.DataAccess;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class StatisticsDataAccessTests
    {
        Mock<StatisticsDataInterface> mock = new Mock<StatisticsDataInterface>();
        StatisticsDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new StatisticsDataAccess(mock.Object);
        }

        [TestCaseSource(typeof(GetStatisticsProductsSource))]
        public void GetStatisticsProductsTests(FilterGroupModel filter, List<StatisticsGroupsDTO> statisticsProductsDTOs, List<StatisticsGroupsModel> expected)
        {
            mock.Setup(a => a.GetStatisticsProducts(filter.MinDateSupply, filter.MaxDateSupply, filter.MinDateOrder, filter.MaxDateOrder, 
                filter.MinAmount, filter.MaxAmount, filter.MinSum, filter.MaxSum, filter.PeriodFor, filter.PeriodUntil)).Returns(statisticsProductsDTOs);

            List<StatisticsGroupsModel> actual = dataAccess.GetStatisticsProducts(filter);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetStatisticsProductsByGroupIDSource))]
        public void GetStatisticsProductsByGroupIDTests(int id, FilterGroupModel filter, List<StatisticsProductDTO> statisticsProductsDTOs, List<StatisticsProductModel> expected)
        {
            mock.Setup(a => a.GetStatisticsProductsByGroupID(id, filter.MinDateSupply, filter.MaxDateSupply, filter.MinDateOrder,
                filter.MaxDateOrder, filter.MinAmount, filter.MaxAmount, filter.MinSum, filter.MaxSum,
                filter.PeriodFor, filter.PeriodUntil)).Returns(statisticsProductsDTOs);

            List<StatisticsProductModel> actual = dataAccess.GetStatisticsProductsByGroupID(id, filter);

            Assert.AreEqual(expected, actual);
        }
    }

    class GetStatisticsProductsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 
                new FilterGroupModel()
                {
                    MinDateSupply = DateTimeMock.DateTimes[0],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[0],
                    MinDateOrder = DateTimeMock.DateTimes[0],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[0],
                    MinAmount = 20,
                    MaxAmount = 60,
                    MinSum = 200,
                    MaxSum = 2000,
                    PeriodFor = DateTimeMock.DateTimes[0],
                    PeriodUntil = DateTimeMock.MaxDataTimes[0]
                },
                StatisticsDTOMock.GroupDTO, 
                StatisticsModelMock.GroupModel
            };

            yield return new object[] {
                 new FilterGroupModel()
                 {
                    MinDateSupply = DateTimeMock.DateTimes[1],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[1],
                    MinDateOrder = DateTimeMock.DateTimes[1],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[1],
                    MinAmount = 50,
                    MaxAmount = 60,
                    MinSum = 100,
                    MaxSum = 150,
                    PeriodFor = DateTimeMock.DateTimes[1],
                    PeriodUntil = DateTimeMock.MaxDataTimes[1]
                 },
                new List<StatisticsGroupsDTO>() { StatisticsDTOMock.GroupDTO[1], StatisticsDTOMock.GroupDTO[1] } ,
                new List<StatisticsGroupsModel>(){ StatisticsModelMock.GroupModel[1], StatisticsModelMock.GroupModel[1] }  
            };
            yield return new object[] {
                 new FilterGroupModel()
                 {
                    MinDateSupply = DateTimeMock.DateTimes[2],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[2],
                    MinDateOrder = DateTimeMock.DateTimes[2],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[2],
                    MinAmount = 10,
                    MaxAmount = 60,
                    MinSum = 5000,
                    MaxSum = 10000,
                    PeriodFor = DateTimeMock.DateTimes[2],
                    PeriodUntil = DateTimeMock.MaxDataTimes[2]
                 },
                new List<StatisticsGroupsDTO>() {StatisticsDTOMock.GroupDTO[1], StatisticsDTOMock.GroupDTO[0] } ,
                new List<StatisticsGroupsModel>(){ StatisticsModelMock.GroupModel[1], StatisticsModelMock.GroupModel[0] }  };

        }
    }


    class GetStatisticsProductsByGroupIDSource : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            yield return new object[] {
                1,
                new FilterGroupModel()
                {
                    MinDateSupply = DateTimeMock.DateTimes[0],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[0],
                    MinDateOrder = DateTimeMock.DateTimes[0],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[0],
                    MinAmount = 20,
                    MaxAmount = 60,
                    MinSum = 200,
                    MaxSum = 2000,
                    PeriodFor = DateTimeMock.DateTimes[0],
                    PeriodUntil = DateTimeMock.MaxDataTimes[0]
                },
                StatisticsDTOMock.ProductDTO, 
                StatisticsModelMock.ProductModel };
            yield return new object[] {
                 2,
                 new FilterGroupModel()
                 {
                    MinDateSupply = DateTimeMock.DateTimes[1],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[1],
                    MinDateOrder = DateTimeMock.DateTimes[1],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[1],
                    MinAmount = 50,
                    MaxAmount = 60,
                    MinSum = 100,
                    MaxSum = 150,
                    PeriodFor = DateTimeMock.DateTimes[1],
                    PeriodUntil = DateTimeMock.MaxDataTimes[1]
                 },
                new List<StatisticsProductDTO>() { StatisticsDTOMock.ProductDTO[1], StatisticsDTOMock.ProductDTO[1] } ,
                new List<StatisticsProductModel>(){ StatisticsModelMock.ProductModel[1], StatisticsModelMock.ProductModel[1] }  };
            yield return new object[] {
                 3,
                 new FilterGroupModel()
                 {
                    MinDateSupply = DateTimeMock.DateTimes[2],
                    MaxDateSupply = DateTimeMock.MaxDataTimes[2],
                    MinDateOrder = DateTimeMock.DateTimes[2],
                    MaxDateOrder = DateTimeMock.MaxDataTimes[2],
                    MinAmount = 10,
                    MaxAmount = 60,
                    MinSum = 5000,
                    MaxSum = 10000,
                    PeriodFor = DateTimeMock.DateTimes[2],
                    PeriodUntil = DateTimeMock.MaxDataTimes[2]
                 },
                new List<StatisticsProductDTO>() { StatisticsDTOMock.ProductDTO[1], StatisticsDTOMock.ProductDTO[0] } ,
                new List<StatisticsProductModel>(){ StatisticsModelMock.ProductModel[1], StatisticsModelMock.ProductModel[0] }  };

        }


    }
}
