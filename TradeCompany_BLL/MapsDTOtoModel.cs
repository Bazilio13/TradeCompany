using AutoMapper;
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
    public class MapsDTOtoModel
    {
        public List<OrderModel> MapOrdersDTOToOrderModel(List<OrdersDTO> ordersDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrdersDTO, OrderModel>()
            .ForMember(dest => dest.ClientsPhone, option => option.MapFrom(sorse => sorse.ClientDTO.Phone))
            .ForMember(dest => dest.Client, option => option.MapFrom(sorse => sorse.ClientDTO.Name))
            .ForMember(dest => dest.Client, option => option.MapFrom(sorse => sorse.ClientDTO.Name))
            .ForMember(dest => dest.Summ, option => option.MapFrom(sorse => sorse.OrderLists.Sum(order => order.Price * order.Amount)))
            .ForMember(dest => dest.OrderListModel, option => option.MapFrom(sorse => MapOrderListsDTOToOrderListModel(sorse.OrderLists)))
            );
            Mapper mapper = new Mapper(config);
            List<OrderModel> orderModels;
            orderModels = mapper.Map<List<OrderModel>>(ordersDTO);
            return orderModels;
        }

        public List<OrderListModel> MapOrderListsDTOToOrderListModel(List<OrderListsDTO> orderListsDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderListsDTO, OrderListModel>()
            .ForMember(dest => dest.ProductName, option => option.MapFrom(sorse => sorse.productDTO.Name))
            .ForMember(dest => dest.ProductMeasureUnit, option => option.MapFrom(sorse => sorse.productDTO.MeasureUnitName)));
            Mapper mapper = new Mapper(config);
            List<OrderListModel> orderListModel;
            orderListModel = mapper.Map<List<OrderListModel>>(orderListsDTO);
            return orderListModel;
        }

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
        public List<ProductsForOrderModel> Map_ProductsForOrderDTO_To_ProductsForOrderModel(List<ProductForOrderDTO> productForOrderDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductForOrderDTO, ProductsForOrderModel>());
            Mapper mapper = new Mapper(config);
            List<ProductsForOrderModel> productsForOrderModel;
            productsForOrderModel = mapper.Map<List<ProductsForOrderModel>>(productForOrderDTO);

            return productsForOrderModel;
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

        public ClientModel MapClientDTOToClientModelByID(int id)
        {
            ClientsData clients = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            ClientDTO clientDTO = clients.GetClientByID(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);
            ClientModel clientModel = mapper.Map<ClientModel>(clientDTO);

            return clientModel;
        }


        public List<String> MapClientDTOToAddressesModelByID(int id)
        {
            AddressesData addresses = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<String> addressesList = addresses.GetAddressesByID(id);

            return addressesList;
        }
        
        public void MapAddressesDeleteByID(int id)
        {
            AddressesData addresses = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            addresses.DeleteAllAddressByID(id);
        }
    }
}