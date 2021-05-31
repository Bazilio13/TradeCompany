using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
   public class ClientModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? INN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public bool Type { get; set; }
        public bool CorporateBody { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
}
