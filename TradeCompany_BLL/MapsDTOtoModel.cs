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

        public List<ProductBaseModel> MapProductDTOToProductBaseModel()
        {
            ProductsData products = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ProductDTO> productDTO = products.GetProducts();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ProductBaseModel> productBaseModel = mapper.Map<List<ProductBaseModel>>(productDTO);
            return productBaseModel;
        }

        public List<ProductBaseModel> MapProductDTOToProductBaseModelByLetter(string inputString)
        {
            ProductsData products = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ProductDTO> productDTO = products.GetProductsByLetter(inputString);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductBaseModel>());
            Mapper mapper = new Mapper(config);
            List<ProductBaseModel> productBaseModel = mapper.Map<List<ProductBaseModel>>(productDTO);
            return productBaseModel;
        }

        public List<ProductGroupModel> MapProductGroupToProductGroupModel()
        {
            ProductGroupsData groups = new ProductGroupsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            List<ProductGroupDTO> groupDTO = groups.GetProductGroups();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductGroupDTO, ProductGroupModel>());
            Mapper mapper = new Mapper(config);
            List<ProductGroupModel> groupModel = mapper.Map<List<ProductGroupModel>>(groupDTO);
            return groupModel;
        }
        
    }
}
