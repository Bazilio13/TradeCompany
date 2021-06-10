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

        public List<ClientBaseModel> MapClientDTOToClientsBaseModelList(List<ClientDTO> clientsDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ClientBaseModel> clientBaseModel = mapper.Map<List<ClientBaseModel>>(clientsDTO);

            return clientBaseModel;
        } 
        
        public ClientModel MapClientDTOToClientModel(ClientDTO clientDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);
            ClientModel clientModel = mapper.Map<ClientModel>(clientDTO);
            return clientModel;
        }


        public List<String> MapClientDTOToAddressesByID(int id)
        {
            AddressesData addresses = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<String> addressesList = addresses.GetAddressesByID(id);

            return addressesList;
        }

        public List<WishModel> MapWishesDTOToWishesModelList(List<WishDTO> wishListDTO) 
        { 
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WishDTO, WishModel>());
            Mapper mapper = new Mapper(config);
            List<WishModel> wishModelList = mapper.Map<List<WishModel>>(wishListDTO);

            return wishModelList;
        }

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

        public List<ProductsForOrderModel> Map_ProductsForOrderDTO_To_ProductsForOrderModel(List<ProductForOrderDTO> productForOrderDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductForOrderDTO, ProductsForOrderModel>());
            Mapper mapper = new Mapper(config);
            List<ProductsForOrderModel> productsForOrderModel;
            productsForOrderModel = mapper.Map<List<ProductsForOrderModel>>(productForOrderDTO);

            return productsForOrderModel;
        }


        public List<ProductBaseModel> MapProductDTOToProductBaseModel(List<ProductDTO> productDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductBaseModel>()
            .ForMember(dest => dest.Groups, option => option.MapFrom(sorse => MapProductGroupDTOToProductGroupModel(sorse.Group))));
            Mapper mapper = new Mapper(config);
            List<ProductBaseModel> productBaseModel = mapper.Map<List<ProductBaseModel>>(productDTO);
            return productBaseModel;
        }

        public List<ProductModel> MapProductDTOToProductModel(List<ProductDTO> productDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductModel>()
            .ForMember(dest => dest.Groups, option => option.MapFrom(sorse => MapProductGroupDTOToProductGroupModel(sorse.Group))));
            Mapper mapper = new Mapper(config);
            List<ProductModel> productModel = mapper.Map<List<ProductModel>>(productDTO);
            return productModel;
        }


        public List<ProductGroupModel> MapProductGroupDTOToProductGroupModel(List<ProductGroupDTO> groupDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductGroupDTO, ProductGroupModel>()
            .ForMember(dest => dest.Products, option => option.MapFrom(sorse => MapProductDTOToProductBaseModel(sorse.Products))));
            Mapper mapper = new Mapper(config);
            List<ProductGroupModel> groupModel = mapper.Map<List<ProductGroupModel>>(groupDTO);
            return groupModel;
        }

        public List<FeedbackModel> MapFeedbackDTOToFeedbackModel(List<FeedBacksDTO> feedBacksDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedBacksDTO, FeedbackModel>());
            Mapper mapper = new Mapper(config);
            List<FeedbackModel> feedbackModels = mapper.Map<List<FeedbackModel>>(feedBacksDTO);

            return feedbackModels;
        }

        public List<MeasureUnitsModel> MapMeasureUnitDTOToMeasureUnitModel(List<MeasureUnitsDTO> measureUnits)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeasureUnitsDTO, MeasureUnitsModel>());
            Mapper mapper = new Mapper(config);
            List<MeasureUnitsModel> measureUnitsModels = mapper.Map<List<MeasureUnitsModel>>(measureUnits);
            return measureUnitsModels;
        }


    }
}
