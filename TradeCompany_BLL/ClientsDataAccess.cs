using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class ClientsDataAccess
    {

        private ClientsData _clientData = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        private MapsDTOtoModel _map = new MapsDTOtoModel();

        public List<ClientBaseModel> GetClients()
        {
            List<ClientDTO> clientDTOs= _clientData.GetClients();
            List<ClientBaseModel> clinetsModel = _map.MapClientDTOToClientsBaseModelList(clientDTOs);
            return clinetsModel;
        }

        public List<ClientBaseModel> GetClientsBySearch(string textSearh)
        {
            List<ClientDTO> clientDTOs = _clientData.GetClientsByName(textSearh);
            List<ClientBaseModel> clinetsModel = _map.MapClientDTOToClientsBaseModelList(clientDTOs);
            return clinetsModel;
        }

        public List<ClientBaseModel> GetClientsByParam(int? person, int? sale, DateTime? minData, DateTime? maxData)
        {
            List<ClientDTO> clientDTOs = _clientData.GetClientsByParams(person, sale, minData, maxData);
            List<ClientBaseModel> clinetsModel = _map.MapClientDTOToClientBaseModelListByParam(clientDTOs);
            return clinetsModel;
        }
    }
}
