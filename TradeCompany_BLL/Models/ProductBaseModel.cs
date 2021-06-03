using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ProductBaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public int MeasureUnitName { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public DateTime? LastSupplyDate { get; set; }
    }
}
