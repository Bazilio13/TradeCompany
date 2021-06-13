using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class ClientsStatisticsDTO
    {
        public int ID { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Name { get; set; }
        public int OrdersСount { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }
}
