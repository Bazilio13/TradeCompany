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
    public class AddressesDataAccess
    {
        private  AddressesData _addressesData = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        private MapsDTOtoModel _mapDTOtoModel = new MapsDTOtoModel();
        private MapsModelToDTO _mapModelToDTO = new MapsModelToDTO();

        public List<String> GetAddressesByID (int id)
        {
            List<String> addressesList = _addressesData.GetAddressesByID(id);

            return addressesList;
        }

        public int AddAddressByID(int clientID, String address)
        {
            int setID = _addressesData.AddAddress(clientID, address);

            return setID;
        }

        public int AddAddressByID(int clientID, List<String> addressesList)
        {
            int setID = -1;
            foreach (String address in addressesList)
            {
                setID =_addressesData.AddAddress(clientID, address);
            }
            return setID;
        }
    }
}
