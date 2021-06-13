using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.SypplysMaps;
using TradeCompany_BLL.DataAccess;
using TradeCompany_BLL.Tests.SupplysMapsSourse;
using TradeCompany_DAL.DTOs;
using TradeCompany_DAL;
using Moq;
using System.Collections;
using TradeCompany_BLL.Tests.Mocks;

namespace TradeCompany_BLL.Tests
{
    public class SupplysDataAccess_Tests
    {
        Mock<SupplysDataInterface> mock = new Mock<SupplysDataInterface>();
        SupplysDataAccess dataAccess;    

        [SetUp]
        public void Setup()
        {
            dataAccess = new SupplysDataAccess(mock.Object);
        }

        [TestCaseSource(typeof(GetSupplyModelsByParamsSource))]
        public void GetSupplyModelsByParamsTests(List<SupplyDTO> supplyDTOs, List<SupplyModel> expected, DateTime? minDateTime = null, DateTime? maxDateTime = null, string product = null, string productGroup = null)
        {
            mock.Setup(a => a.GetSupplysByParams(minDateTime, maxDateTime, product, productGroup)).Returns(supplyDTOs);

            List<SupplyModel> actual = dataAccess.GetSupplyModelsByParams(minDateTime, maxDateTime, product, productGroup);
         
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetSupplyModelByIDSource))]
        public void GetSupplyModelByIDTests(int id, List<SupplyDTO> supplyDTOs, SupplyModel expected)
        {
            mock.Setup(a => a.GetSupplysByID(id)).Returns(supplyDTOs);

            SupplyModel actual = dataAccess.GetSupplyModelByID(id);

            Assert.AreEqual(expected, actual);
        }

    }

    public class GetSupplyModelsByParamsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[0] }, 
                new List<SupplyModel>() { SupplyModelMock.Models[0] },
                DateTimeMock.DateTimes[0],
                DateTimeMock.MaxDataTimes[0],
                "кофе",
                "продукты"

            };

            yield return new object[] { 
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[1] },
                new List<SupplyModel>() { SupplyModelMock.Models[1] },
                DateTimeMock.DateTimes[1],
                DateTimeMock.MaxDataTimes[1],
                "молоко",
                "продукты"
            };

            yield return new object[] {
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[2] }, 
                new List<SupplyModel>() { SupplyModelMock.Models[2] },
                DateTimeMock.DateTimes[2],
                DateTimeMock.MaxDataTimes[2],
                "чай",
                "продукты"
            };

        }
    }

    public class GetSupplyModelByIDSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {
                1,
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[0] },
                SupplyModelMock.Models[0],


            };

            yield return new object[] {
                2,
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[1] },
                SupplyModelMock.Models[1],

            };

            yield return new object[] {
                3,
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[2] },
                SupplyModelMock.Models[2],
            };

        }
    }

    public class SearchSupplyModelsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {
                "a",
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[0] },
                new List<SupplyModel>() { SupplyModelMock.Models[0] },
            };

            yield return new object[] {
                "b",
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[1] },
                new List<SupplyModel>() { SupplyModelMock.Models[1] },
            };

            yield return new object[] {
                "c",
                new List<SupplyDTO>() { SupplyDTOMock.DTOsFromDB[2] },
                new List<SupplyModel>() { SupplyModelMock.Models[2] },
            };

        }
    }

}