using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ClientsStatisticsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OrdersСount { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public double? AverageCheck { get; set; }
        public double? Percentage { get; set; }
    }
}
