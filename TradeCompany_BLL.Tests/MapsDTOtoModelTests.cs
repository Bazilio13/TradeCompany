using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    public class MapsDTOtoModelTests
    {
        public MapsDTOtoModel map = new MapsDTOtoModel();


        [TestCaseSource(typeof(MapClientsDTOToClientsModelSourse))]
        public void MapClientsDTOToClientsModelTests(List<ClientDTO> clientsDTO, List<ClientBaseModel> expected)
        {
            List<ClientBaseModel> actual = map.MapClientDTOToClientsBaseModelList(clientsDTO);
            Assert.AreEqual(expected, actual);
        }


        [TestCaseSource(typeof(MapClientDTOToClientModelSourse))]
        public void MapClientDTOToClientModelTests(ClientDTO clientsDTO, ClientModel expected)
        {
            ClientModel actual = map.MapClientDTOToClientModel(clientsDTO);
            Assert.AreEqual(expected, actual);
        }
    }



    public class MapClientDTOToClientModelSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClientDTO()
                {
                ID = 1,
                Name = "Oleg",
                LastOrderDate = null,
                Phone = "8999777"},
                new ClientModel()
                {
                ID = 1,
                Name = "Oleg",
                LastOrderDate = null,
                Phone = "8999777"}
                };

            yield return new object[]
            {
                new ClientDTO()
                {
                ID = 2,
                Name = "O",
                LastOrderDate = null,
                Phone = "777"},
                new ClientModel()
                {
                ID = 2,
                Name = "O",
                LastOrderDate = null,
                Phone = "777"}};
        }
    }



    public class MapClientsDTOToClientsModelSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {
                new List<ClientDTO>(){
                new ClientDTO(){
                ID = 1,
                Name = "Oleg",
                LastOrderDate = null,
                Phone = "89997777777"},

                new ClientDTO(){
                ID = 3,
                Name = "Петр",
                LastOrderDate = null,
                Phone = "+8777232",
                INN = "663211"},

                new ClientDTO(){
                ID = 6,
                Name = "Федор",
                LastOrderDate = null,
                Phone = "+9(123)123-12-12" } },

                new List<ClientBaseModel>(){
                new ClientBaseModel(){
                ID = 1,
                Name = "Oleg",
                LastOrderDate = null,
                Phone = "89997777777" },

                new ClientBaseModel(){
                ID = 3,
                Name = "Петр",
                LastOrderDate = null,
                Phone = "+8777232" },

                new ClientBaseModel(){
                ID = 6,
                Name = "Федор",
                LastOrderDate = null,
                Phone = "+9(123)123-12-12" }}
            };

            yield return new object[] {
                new List<ClientDTO>(){
                new ClientDTO(){
                ID = 4,
                Name = "ООО ULO",
                Phone = "89997777777"},

                new ClientDTO(){
                ID = 11,
                Name = "Oleg",
                Phone = "+7(123)944-98-12"},

                new ClientDTO(){
                ID = 13,
                Name = "Belr",
                Phone = "0909012" } },

                new List<ClientBaseModel>(){
                new ClientBaseModel(){
                ID = 4,
                Name = "ООО ULO",
                LastOrderDate = null,
                Phone = "89997777777" },

                new ClientBaseModel(){
                ID = 11,
                Name = "Oleg",
                LastOrderDate = null,
                Phone = "+7(123)944-98-12" },

                new ClientBaseModel(){
                ID = 13,
                Name =  "Belr",
                LastOrderDate = null,
                Phone = "0909012" }
                }

            };
        }
    }
}
