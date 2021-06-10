using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Maps;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.DataAccess
{
    public class AddressesDataAccess
    {
        private AddressesData _addressesData= new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        private AddressMaps _map = new AddressMaps();

        public List<AddressModel> GetAdressByClientID(int id)
        {
            List<AddressDTO> addressDTO = new List<AddressDTO>();
            List<AddressModel> addressModels = new List<AddressModel>();

            addressDTO = _addressesData.GetAddressesByClientID(id);

            addressModels = _map.MapListAdressDTOTOListAdressModel(addressDTO);

            return addressModels;
        }

    }
}
