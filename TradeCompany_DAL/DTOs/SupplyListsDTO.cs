using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class SupplyListsDTO
    {
        public int ID { get; set; }
        public int SupplyID { get; set; }
        public int ProductID { get; set; }
        public float Amount { get; set; }
    }
}
