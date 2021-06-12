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
    class MapAddressDTOtoModelTests
    {
        MapsDTOtoModel mapsDTOtoModel = new MapsDTOtoModel();

        [SetUp]
        public void Setup()
        {
            
        }

        [TestCaseSource(typeof(GetAddressesByIDSource))]
        public void MapAddressDTOToAddressModelTest(List<AddressDTO> addressesDTO, List<AddressModel> expected)
        {
            List<AddressModel> actual = mapsDTOtoModel.MapAddressDTOToAddressModel(addressesDTO);

            Assert.AreEqual(expected, actual);
        }
    }


    public class MapAddressDTOToAddressModelSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" ), new AddressDTO(2, 1, "Москва, ул. Мира, 1"), new AddressDTO(3, 1, "Санкт-Петербург, ул. Пасечкина, 34/2"),
                new AddressDTO(4, 1, "Невский пр., 55" )},
                new List<AddressModel>(){new AddressModel(1, 1, "Lenina 1" ), new AddressModel(2, 1, "Москва, ул. Мира, 1"), new AddressModel(3, 1, "Санкт-Петербург, ул. Пасечкина, 34/2"),
                new AddressModel(4, 1, "Невский пр., 55" )}
            };

            yield return new object[]
            {
                new List<AddressDTO>(){ new AddressDTO(1, 1, "Lenina 1" )},
                new List<AddressModel>(){new AddressModel(1, 1, "Lenina 1")}
            };

            yield return new object[]
            {
                new List<AddressDTO>(){ new AddressDTO(1, 8, "Lenina 1" ), new AddressDTO(2, 8, "Москва, ул. Советская 3/1")},
                new List<AddressModel>(){ new AddressModel(1, 8, "Lenina 1"), new AddressModel(1, 8, "Москва, ул. Советская 3/1")}
            };
        }
    }
}
