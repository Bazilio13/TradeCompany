using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class ClientDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string Comment { get; set; }
        public bool Type { get; set; }
        public bool CorporateBody { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }
}
