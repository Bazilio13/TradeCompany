using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class MapsDTOtoModel
    {

        public ClientModel MapClientDTOToClientModel(ClientDTO clientDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);
            ClientModel clientModel = mapper.Map<ClientModel>(clientDTO);
            return clientModel;
        }

        public ClientDTO MapClientModelToClientDTO(ClientModel clientModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientModel, ClientDTO>());
            Mapper mapper = new Mapper(config);
            ClientDTO clientDTO = mapper.Map<ClientDTO>(clientModel);
            return clientDTO;
        }

        public List<ClientModel> MapClientsDTOToClientsModelList()
        {
            ClientsData clients = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ClientDTO> clientsDTO = clients.GetClients();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);
            List<ClientModel> clientModel = mapper.Map<List<ClientModel>>(clientsDTO);

            return clientModel;
        }

        public List<ClientBaseModel> MapClientDTOToClientBaseModelList()
        {
            ClientsData clients = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ClientDTO> clientsDTO = clients.GetClients();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ClientBaseModel> clientBaseModel = mapper.Map<List<ClientBaseModel>>(clientsDTO);

            return clientBaseModel;
        }

        public List<ClientBaseModel> MapClientDTOToClientBaseModelListByName(string partOfTheName)
        {
            ClientsData clients = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ClientDTO> clientsDTO = clients.GetClientsByName(partOfTheName);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ClientBaseModel> clientBaseModel = mapper.Map<List<ClientBaseModel>>(clientsDTO);

            return clientBaseModel;
        }

        public List<ClientBaseModel> MapClientDTOToClientBaseModelListByParam(int? person, int? sale, DateTime? minData, DateTime? maxData)
        {
            ClientsData clients = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ClientDTO> clientsDTO = clients.GetClientsByParams(person, sale, minData, maxData);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ClientBaseModel> clientBaseModel = mapper.Map<List<ClientBaseModel>>(clientsDTO);

            return clientBaseModel;
        }

    }
}