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
    public class MapsModelToDTO
    {
        public void MapClientModelToClientDTO(ClientModel clientModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientModel, ClientDTO>());
            Mapper mapper = new Mapper(config);
            ClientDTO clientDTO = mapper.Map<ClientDTO>(clientModel);
            ClientsData data = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            if(clientDTO.ID == -1)
            {
                data.AddClient(clientDTO);
            }
            else
            {
                data.UpdateClientByID(clientDTO);
            }
         
        }
        public List<OrderListsDTO> MapOrderListModelToOrderDTO(List<OrderListModel> orderListModels)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderListModel , OrderListsDTO>()
            .ForMember(dest => dest.ID, option => option.MapFrom(sorse => sorse.ID))
            .ForMember(dest => dest.ProductID, option => option.MapFrom(sorse => sorse.ProductID))
            .ForMember(dest => dest.Amount, option => option.MapFrom(sorse => sorse.Amount))
            .ForMember(dest => dest.Price, option => option.MapFrom(sorse => sorse.Price)));
            Mapper mapper = new Mapper(config);

            List<OrderListsDTO> _orderListsDTO;
           // orderListModel = mapper.Map<List<OrderListModel>>(orderListsDTO);
            _orderListsDTO = mapper.Map<List<OrderListsDTO>>(orderListModels); 
            return _orderListsDTO;


            //return null;
        }

    }
}
