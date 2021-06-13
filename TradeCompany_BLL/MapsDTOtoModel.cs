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
            //.ForMember(dest => dest.Sum, option => option.MapFrom(sorse => sorse.Amount * sorse.Price)));
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
        public OrderListModel MapProductDTOToOrderListModel(ProductDTO productDTO)
        { //.ForMember(dest => dest.ProductName, option => option.MapFrom(sorse => sorse.productDTO.Name))
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, OrderListModel>()
            .ForMember(dest => dest.ProductName, option => option.MapFrom(sorse => sorse.Name))
            .ForMember(dest => dest.ProductMeasureUnit, option => option.MapFrom(sorse => sorse.MeasureUnitName))
            .ForMember(dest => dest.ProductID,option => option.MapFrom(sorse => sorse.ID))
            .ForMember(dest => dest.Price, option => option.MapFrom(sorse => sorse.WholesalePrice)));
            Mapper mapper = new Mapper(config);
            OrderListModel orderListModel = mapper.Map<OrderListModel>(productDTO);
            return orderListModel;
        }

        public List<ClientsStatisticsModel> MapClientsStatDTOToClientsStatModel(List<ClientsStatisticsDTO> clientsStatDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientsStatisticsDTO, ClientsStatisticsModel>());
            Mapper mapper = new Mapper(config);
            List<ClientsStatisticsModel> clientsStatModel = mapper.Map<List<ClientsStatisticsModel>>(clientsStatDTO);
            return clientsStatModel;
        }
        public List<String> MapAddressDTOToAddressString(List<AddressDTO> addressesDTO)
        {
            List<String> addressesList = new List<string>();
            foreach (AddressDTO address in addressesDTO)
            {
                addressesList.Add(address.Address);
            }
            return addressesList;
        }

        public List<AddressModel> MapAddressDTOToAddressModel(List<AddressDTO> addressesDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressModel>());
            Mapper mapper = new Mapper(config);
            List<AddressModel> addressModels = mapper.Map<List<AddressModel>>(addressesDTO);
            return addressModels;
        }
        public List<StatisticsGroupsModel> MapStatisticsGroursDTOToStatisticsGroursModel(List<StatisticsGroupsDTO> statisticsDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatisticsGroupsDTO, StatisticsGroupsModel>());
            Mapper mapper = new Mapper(config);
            List<StatisticsGroupsModel> statisticsProductsModel = mapper.Map<List<StatisticsGroupsModel>>(statisticsDTO);
            return statisticsProductsModel;

        }
        
        public List<StatisticsProductModel> MapStatisticsProductsDTOToStatisticsProductsModel(List<StatisticsProductDTO> statisticsDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatisticsProductDTO, StatisticsProductModel>());
            Mapper mapper = new Mapper(config);
            List<StatisticsProductModel> statisticsProductsModel = mapper.Map<List<StatisticsProductModel>>(statisticsDTO);
            return statisticsProductsModel;

        }


    }
}
