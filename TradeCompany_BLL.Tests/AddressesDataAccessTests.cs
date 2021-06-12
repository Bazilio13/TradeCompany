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
        private AddressesData _addressesData = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(GetAddressesTestSource))]
        public void GetAddressesByIDTest(int id, List<AddressDTO> addressDTOs, List<AddressModel> addressModels)
        {
            Mock<AddressesData> 
        }
    }

    public class GetAddressesTestSource : IEnumerable
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

}
