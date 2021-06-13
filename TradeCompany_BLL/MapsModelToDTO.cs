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

        public ClientDTO MapClientModelToClientDTO(ClientModel clientModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientModel, ClientDTO>());
            Mapper mapper = new Mapper(config);
            ClientDTO clientDTO = mapper.Map<ClientDTO>(clientModel);
            return clientDTO;
        }

        public List<WishDTO> MapWishListModelToWishListDTO(List<WishModel> wishListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WishModel, WishDTO>());
            Mapper mapper = new Mapper(config);
            List<WishDTO> wishListDTO = mapper.Map<List<WishDTO>>(wishListModel);
            return wishListDTO;
        }


        public List<OrderListsDTO> MapOrderListModelToOrderDTO(List<OrderListModel> orderListModels)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderListModel , OrderListsDTO>()
            .ForMember(dest => dest.ID, option => option.MapFrom(sorse => sorse.ID))
            .ForMember(dest => dest.ProductID, option => option.MapFrom(sorse => sorse.ProductID))
            .ForMember(dest => dest.Amount, option => option.MapFrom(sorse => sorse.Amount))
            .ForMember(dest => dest.Price, option => option.MapFrom(sorse => sorse.Price))
            .ForMember(dest => dest.OrderID,option =>option.MapFrom(sorse=> sorse.OrderID)));
            Mapper mapper = new Mapper(config);

            List<OrderListsDTO> _orderListsDTO;
           
            _orderListsDTO = mapper.Map<List<OrderListsDTO>>(orderListModels); 
            return _orderListsDTO;
        }

        public OrdersDTO MapOrderModelToOrdersDTO(OrderModel orderModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, OrdersDTO>()
            .ForMember(dest => dest.OrderLists, option => option.MapFrom(sorse => MapOrderListModelToOrderListDTO(sorse.OrderListModel))));
           
            Mapper mapper = new Mapper(config);
            OrdersDTO ordersDTO = new OrdersDTO();
            ordersDTO = mapper.Map< OrdersDTO>(orderModel);
            return ordersDTO;
        }
        public List<OrderListsDTO> MapOrderListModelToOrderListDTO(List<OrderListModel> orderListModels)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderListModel, OrderListsDTO>());

            Mapper mapper = new Mapper(config);
            List<OrderListsDTO> orderListsDTO = new List<OrderListsDTO>();
            orderListsDTO = mapper.Map<List<OrderListsDTO>>(orderListModels);

            return orderListsDTO;
        }



    }

}
