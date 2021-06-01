using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public int MeasureUnit { get; set; }
        public string MeasureUnitName { get; set; }
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
        public DateTime LastSupplyDate { get; set; }
        public List<ProductGroupDTO> Group { get; set; } = new List<ProductGroupDTO>();
    }
}
