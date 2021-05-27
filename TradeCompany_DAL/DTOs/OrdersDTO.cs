using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class OrdersDTO
    {
        public int ID { get; set; }
        public int ClientsID { get; set; }
        public DateTime Datetime { get; set; }
        public int AddressID { get; set; }
        public string Comment { get; set; }
        public List<OrderListDTO> OrderLists { get; set; } = new List<OrderListDTO>();
    }
}
