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
        private AddressesDataInterface _addressesData; 
        private MapsDTOtoModel _mapDTOtoModel = new MapsDTOtoModel();

        public AddressesDataAccess(AddressesDataInterface addressesData)
        {
            _addressesData = addressesData;
        }

        public AddressesDataAccess()
        {
            _addressesData = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        }

        public List<AddressModel> GetAddressesByID (int id)
        {
            List<AddressDTO> addressesDTO = _addressesData.GetAddressesByID(id);
            List<AddressModel> addressModels = _mapDTOtoModel.MapAddressDTOToAddressModel(addressesDTO);
            return addressModels;
        }

        public List<String> GetListAddressesByID(int id)
        {
            List<AddressDTO> addressesDTO = _addressesData.GetAddressesByID(id);
            List<String> addressesList = _mapDTOtoModel.MapAddressDTOToAddressString(addressesDTO);
            return addressesList;
        }

        public int AddAddressByID(int clientID, String address)
        {
            int setID = 1;
            List<AddressDTO> addressesDTO = _addressesData.GetAddressesByID(clientID);
            List<String> oldAddresses = _mapDTOtoModel.MapAddressDTOToAddressString(addressesDTO);
            if (oldAddresses.Contains(address) && _addressesData.IsDeletedAddress(clientID, address))
            {
                setID = _addressesData.SetIsDeleted(clientID, address, 0);
            }
            else if (!oldAddresses.Contains(address))
            {
                setID = _addressesData.AddAddress(clientID, address);
            }

            return setID;
        }

        public int AddAddressByID(int clientID, List<String> addressesList)
        {
            int setID = -1;
            List<AddressDTO> addressesDTO = _addressesData.GetAddressesByID(clientID);
            List<String> oldAddresses = _mapDTOtoModel.MapAddressDTOToAddressString(addressesDTO);
            foreach (String address in addressesList)
            {
                if (oldAddresses.Contains(address) && _addressesData.IsDeletedAddress(clientID, address))
                {
                    setID = _addressesData.SetIsDeleted(clientID, address, 0);
                }
                else if (!oldAddresses.Contains(address))
                {
                    setID = _addressesData.AddAddress(clientID, address);
                }

            }

            foreach(String address in oldAddresses)
            {
                if (!addressesList.Contains(address))
                {
                    _addressesData.SetIsDeleted(clientID, address, 1);
                }
            }

            return setID;
        }

        public void DeleteAddressByClintID(int clientID, String address)
        {
            _addressesData.DeleteAddressByIDAndAddress(clientID, address);
        }
    }
}
