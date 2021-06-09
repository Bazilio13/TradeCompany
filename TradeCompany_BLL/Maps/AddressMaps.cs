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
    }
}
