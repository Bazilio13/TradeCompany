using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Maps
{
    class AddressMaps
    {
        public AddressDTO MapAddressModelToAddressDTO(AddressModel addressModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressModel, AddressDTO>());
           
            Mapper mapper = new Mapper(config);
            AddressDTO addressDTO;
            addressDTO = mapper.Map<AddressDTO>(addressModel);

            return addressDTO;
        }
        
        public AddressModel MapAdressDTOTOAdressModel(AddressDTO addressDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressModel>());
            
            Mapper mapper = new Mapper(config);
            AddressModel addressModel;
            addressModel = mapper.Map<AddressModel>(addressDTO);

            return addressModel;

        }
        public List<AddressModel> MapListAdressDTOTOListAdressModel(List<AddressDTO> addressDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressModel>());
            Mapper mapper = new Mapper(config);
            List<AddressModel> addressModels;
            addressModels = mapper.Map<List<AddressModel>>(addressDTO);
            return addressModels;
        }
    }
}
