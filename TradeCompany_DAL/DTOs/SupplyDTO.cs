using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class SupplyDTO
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
        public List<SupplyListDTO> SupplyLists { get; set; } = new List<SupplyListDTO>();
    }
}
