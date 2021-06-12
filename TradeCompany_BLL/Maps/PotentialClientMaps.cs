using AutoMapper;
using System.Collections.Generic;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Maps
{
    public class PotentialClientMaps
    {
        public List<PotentialClientModel> MapPotentialClientDTOsToPotentialClientModels(List<PotentialClientDTO> potentialClientDTOs)
        {
            MapsDTOtoModel productsMap = new MapsDTOtoModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PotentialClientDTO, PotentialClientModel>()
            .ForMember(dest => dest.Products, option => option.MapFrom(sorse => productsMap.MapProductDTOToProductBaseModel(sorse.Products))));
            Mapper mapper = new Mapper(config);
            return mapper.Map<List<PotentialClientModel>>(potentialClientDTOs);
        }
    }
}
