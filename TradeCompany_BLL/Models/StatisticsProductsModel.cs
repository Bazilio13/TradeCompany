using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class StatisticsProductsModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public float Summ { get; set; }
        public DateTime LastSupplyDate { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
}
