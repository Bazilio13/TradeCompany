using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class AddressModel
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Address { get; set; }

        public AddressModel(int id, int clientID, String address)
        {
            ID = id;
            ClientID = clientID;
            Address = address;

        }
        public AddressModel()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is AddressModel model &&
                   ID == model.ID &&
                   ClientID == model.ClientID &&
                   Address == model.Address;
        }
    }
}
