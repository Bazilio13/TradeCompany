using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class AddressDTO
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Address { get; set; }
    }
}
