using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.SypplysMaps
{
    public class SupplysMaps
    {
        public List<SupplyModel> MapSupplyDTOToSupplyModel(List<SupplyDTO> supplyDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SupplyDTO, SupplyModel>()
            .ForMember(dest => dest.SupplyListModel, option => option.MapFrom(sorse => MapSupplyListDTOToSupplyListModel(sorse.SupplyLists)))
            );
            Mapper mapper = new Mapper(config);
            List<SupplyModel> supplyModels;
            supplyModels = mapper.Map<List<SupplyModel>>(supplyDTO);
            return supplyModels;
        }

        public List<SupplyListModel> MapSupplyListDTOToSupplyListModel(List<SupplyListDTO> supplyListsDTO)
        {
            MapsDTOtoModel mapsDTOtoModel = new MapsDTOtoModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SupplyListDTO, SupplyListModel>()
            .ForMember(dest => dest.ProductName, option => option.MapFrom(sorse => sorse.productDTO.Name))
            .ForMember(dest => dest.ProductMeasureUnit, option => option.MapFrom(sorse => sorse.productDTO.MeasureUnitName))
            .ForMember(dest => dest.ProductGroups, option => option.MapFrom(sorse => mapsDTOtoModel.MapProductGroupToProductGroupModel(sorse.productDTO.Group))));
            Mapper mapper = new Mapper(config);
            List<SupplyListModel> supplyListModel;
            supplyListModel = mapper.Map<List<SupplyListModel>>(supplyListsDTO);
            return supplyListModel;
        }
    }
}
