//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using TradeCompany_BLL.Models;
//using TradeCompany_DAL.DTOs;

//namespace TradeCompany_BLL.Tests
//{
//    public class ClientsDataAccess
//    {

//        MapsDTOtoModel map;

//        [SetUp]
//        public void Setup()
//        {
//        }


//        public void MapClientDTOToClientModelTests(ClientDTO clientDTO, ClientModel expected)
//        {
//            ClientModel actual = map.MapClientDTOToClientModel(clientDTO);
//            Assert.AreEqual(expected, actual);
//        }



//        [TestCaseSource(typeof(MapClientsDTOToClientsModelSourse))]
//        public void MapClientsDTOToClientsModelTests(List<ClientDTO> clientsDTO, List<ClientBaseModel> expected)
//        {
//            List<ClientBaseModel> actual = map.MapClientDTOToClientsBaseModelList(clientsDTO);
//            Assert.AreEqual(expected, actual);
//        }


//        public class MapClientsDTOToClientsModelSourse : IEnumerable
//        {
//            public IEnumerator GetEnumerator()
//            {
//                yield return new object[] {
//                new List<ClientDTO>(){
//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777"},
//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777"},

//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" } },

//                new List<ClientBaseModel>(){
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" },
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" },
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" }
//                }

//            };
//                yield return new object[] {
//                new List<ClientDTO>(){
//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777"},
//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777"},

//                new ClientDTO(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" } },

//                new List<ClientBaseModel>(){
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" },
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" },
//                new ClientBaseModel(){
//                ID = 1,
//                Name = "Oleg",
//                LastOrderDate = null,
//                Phone = "89997777777" }
//                }

//            };
//            }
//        }




//        public static class ModelMock
//        {
//            public static ClientModel GetClientModelMock()
//            {
//                ClientModel clientModel = new ClientModel();
//                clientModel.ID = 1;
//                clientModel.Name = "Oleg";
//                clientModel.INN = "111111";
//                clientModel.LastOrderDate = null;
//                clientModel.Phone = "89997777777";
//                clientModel.CorporateBody = false;
//                return clientModel;
//            }

//            public static List<ClientBaseModel> GetClientsBaseModelMock()
//            {
//                List<ClientBaseModel> listClients = new List<ClientBaseModel>();
//                ClientBaseModel clientBaseModel = new ClientBaseModel();
//                clientBaseModel.ID = 1;
//                clientBaseModel.Name = "Oleg";
//                clientBaseModel.LastOrderDate = null;
//                clientBaseModel.Phone = "89997777777";
//                listClients.Add(clientBaseModel);

//                clientBaseModel.ID = 2;
//                clientBaseModel.Name = "Petya";
//                clientBaseModel.Phone = "8129090";
//                clientBaseModel.E_mail = "petya@petya.com";
//                clientBaseModel.ContactPerson = "Oleg";
//                listClients.Add(clientBaseModel);

//                clientBaseModel.ID = 3;
//                clientBaseModel.Name = "Victor";
//                listClients.Add(clientBaseModel);

//                return listClients;
//            }

//        }

//        public static class DTOMock
//        {
//            public static ClientDTO GetClientDTOMock()
//            {
//                ClientDTO clientDTO = new ClientDTO();
//                clientDTO.ID = 1;
//                clientDTO.Name = "Oleg";
//                clientDTO.INN = "111111";
//                clientDTO.LastOrderDate = null;
//                clientDTO.Phone = "89997777777";
//                return clientDTO;
//            }


//            public static List<ClientDTO> GetClientsDTOsMock()
//            {
//                List<ClientDTO> listClients = new List<ClientDTO>();
//                ClientDTO clientDTO = new ClientDTO();
//                clientDTO.ID = 1;
//                clientDTO.Name = "Oleg";
//                clientDTO.LastOrderDate = null;
//                clientDTO.Phone = "89997777777";
//                listClients.Add(clientDTO);

//                clientDTO.ID = 2;
//                clientDTO.Name = "Petya";
//                clientDTO.Phone = "8129090";
//                clientDTO.E_mail = "petya@petya.com";
//                clientDTO.ContactPerson = "Oleg";
//                listClients.Add(clientDTO);

//                clientDTO.ID = 3;
//                clientDTO.Name = "Victor";
//                clientDTO.Phone = null;
//                clientDTO.E_mail = null;
//                clientDTO.ContactPerson = null;

//                listClients.Add(clientDTO);

//                return listClients;
//            }
//        }
//    }
//}
