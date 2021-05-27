using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class OrderListDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
    }
}
