using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface AddressesDataInterface
    {
        public  List<AddressDTO> GetAddresses();

        public List<AddressDTO> GetAddressesByID(int clientId);

        public int AddAddress(int clientId, String address);

        public void DeleteAddressByIDAndAddress(int clientId, String address);

        public void DeleteAddressByID(int clientId);

        public int SetIsDeleted(int clientId, String address, byte isDeleted);

        public bool IsDeletedAddress(int clientId, String address);
    }
}
