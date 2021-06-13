using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class SpecificProductDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        ////private int _Amount;
        ////public int ID { get; set; }
        ////public int ProductID { get; set; }
        ////public string ProductName { get; set; }
        ////public string ProductMeasureUnit { get; set; }
        ////public int Amount { get; set; }

        ////public int Price { get; set; }
    }
}
