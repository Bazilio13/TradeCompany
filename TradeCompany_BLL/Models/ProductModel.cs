using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public int MeasureUnit { get; set; }
        public float StockAmount { get; set; }
        public string MeasureUnitName { get; set; }
        public DateTime? LastSupplyDate { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
