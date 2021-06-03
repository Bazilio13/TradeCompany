using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class ProductForOrderDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int MeasureUnit { get; set; }
        public string ProductGroupName { get; set; }
    }
}
