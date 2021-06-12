using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class StatisticsGroupsModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public float Summ { get; set; }
        public DateTime LastSupplyDate { get; set; }
        public DateTime LastOrderDate { get; set; }
        public float Amount { get; set; }
        public int StockAmount { get; set; }
    }
}
