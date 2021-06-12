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
        private MapsDTOtoModel _mapDTOtoModel = new MapsDTOtoModel();
        private MapsModelToDTO _mapModelToDTO = new MapsModelToDTO();


        public List<ClientBaseModel> GetClients()
        {
            List<ClientDTO> clientDTOs= _clientData.GetClients();
            List<ClientBaseModel> clinetsModel = _mapDTOtoModel.MapClientDTOToClientsBaseModelList(clientDTOs);
            return clinetsModel;
        }

        public List<ClientBaseModel> GetClientsBySearch(string textSearh)
        {
            List<ClientDTO> clientDTOs = _clientData.GetClientsByName(textSearh);
            List<ClientBaseModel> clinetsModel = _mapDTOtoModel.MapClientDTOToClientsBaseModelList(clientDTOs);
            return clinetsModel;
        }

        public List<ClientBaseModel> GetClientsByParam(int? person, int? sale, DateTime? minData, DateTime? maxData)
        {
            List<ClientDTO> clientDTOs = _clientData.GetClientsByParams(person, sale, minData, maxData);
            List<ClientBaseModel> clinetsModel = _mapDTOtoModel.MapClientDTOToClientBaseModelListByParam(clientDTOs);
            return clinetsModel;
        }

        public List<WishModel> GetWishListByClientID(int id)
        {
            List<WishDTO> wishDTOs = _clientData.GetWishesListByClientID(id);
            List<WishModel> wishModelList = _mapDTOtoModel.MapWishesDTOToWishesModelListByID(wishDTOs);
            return wishModelList;
        }

        public ClientModel GetClientByClientID(int id)
        {
            ClientDTO clientDTO = _clientData.GetClientByID(id);
            ClientModel clientModel = _mapDTOtoModel.MapClientDTOToClientModelByID(clientDTO);
            return clientModel;
        }

        public void SaveClient(ClientModel clientModel)
        {
            ClientDTO clientDTO = _mapModelToDTO.MapClientModelToClientDTO(clientModel);
            if(clientDTO.ID != -1)
            {
                _clientData.UpdateClientByID(clientDTO);
            }
            else
            {
                clientDTO.RegistrationDate = DateTime.Now;
                _clientData.AddClient(clientDTO);
            }
        }

        public ClientModel GetLastClient()
        {
            ClientDTO clientDTO = _clientData.GetLastClient();
            ClientModel clientModel = _mapDTOtoModel.MapClientDTOToClientModelByID(clientDTO);
            return clientModel;
        }

        public void SaveWishListByClientID(List<WishModel> wishListModel, int id)
        {
            _clientData.DeleteWishListByID(id);
            List<WishDTO> wishListDTO = _mapModelToDTO.MapWishListModelToWishListDTO(wishListModel);
            foreach (WishDTO wishDTO in wishListDTO)
            {
                _clientData.AddWishByID(id, wishDTO.ID);
            }
        }

        public void SoftDeleteClientByID(int id)
        {
            _clientData.DeleteClientByID(id);
        }

    }
}
