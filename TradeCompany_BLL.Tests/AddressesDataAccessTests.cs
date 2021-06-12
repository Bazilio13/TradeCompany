using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;


namespace TradeCompany_BLL.Tests
{
    public class AddressesDataAccessTests
    {
        AddressesData data = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        Mock<AddressesDataInterface> mock = new Mock<AddressesDataInterface>();
        AddressesDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new AddressesDataAccess(mock.Object);
        }

        [TestCaseSource(typeof(GetAddressesByIDSource))]
        public void GetAddressesByIDTest(int id, List<AddressDTO> addressDTOs, List<AddressModel> expected)
        {
            mock.Setup(a => a.GetAddressesByID(id)).Returns(addressDTOs);

            List<AddressModel>  actual = dataAccess.GetAddressesByID(id);

            Assert.AreEqual(expected, actual);
        }


        [TestCaseSource(typeof(GetListAddressesByIDSource))]
        public void GetListAddressesByIDTestsD(int id, List<AddressDTO> addressDTOs, List<String> expected)
        {
            mock.Setup(a => a.GetAddressesByID(id)).Returns(addressDTOs);

            List<String> actual = dataAccess.GetListAddressesByID(id);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetAddressesByIDSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                1, 
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" ), new AddressDTO(2, 1, "Москва, ул. Мира, 1"), new AddressDTO(3, 1, "Санкт-Петербург, ул. Пасечкина, 34/2"),
                new AddressDTO(4, 1, "Невский пр., 55" )},
                new List<AddressModel>(){new AddressModel(1, 1, "Lenina 1" ), new AddressModel(2, 1, "Москва, ул. Мира, 1"), new AddressModel(3, 1, "Санкт-Петербург, ул. Пасечкина, 34/2"),
                new AddressModel(4, 1, "Невский пр., 55" )}
            };

            yield return new object[]
            {
                1, 
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" )},
                new List<AddressModel>(){new AddressModel(1, 1, "Lenina 1")}
            };
        }
    }


    public class GetListAddressesByIDSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                1,
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" ), new AddressDTO(2, 1, "Москва, ул. Мира, 1"), new AddressDTO(3, 1, "Санкт-Петербург, ул. Пасечкина, 34/2"),
                new AddressDTO(4, 1, "Невский пр., 55" )},
                new List<String>(){ "Lenina 1" ,  "Москва, ул. Мира, 1","Санкт-Петербург, ул. Пасечкина, 34/2","Невский пр., 55" }
            };

            yield return new object[]
            {
                1,
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" )},
                new List<String>(){"Lenina 1"}
            };
        }
    }

}
