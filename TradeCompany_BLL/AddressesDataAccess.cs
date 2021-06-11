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


        public List<String> GetAddressesByID (int id)
        {
            List<String> addressesList = _addressesData.GetAddressesByID(id);

            return addressesList;
        }

        public int AddAddressByID(int clientID, String address)
        {
            int setID = 1;
            List<String> oldAddresses = _addressesData.GetAddressesByID(clientID);
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
            List<String> oldAddresses = _addressesData.GetAddressesByID(clientID);
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
