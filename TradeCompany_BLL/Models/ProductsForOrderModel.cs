using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ProductsForOrderModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int MeasureUnit { get; set; }
        public string ProductGroupName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductsForOrderModel model &&
                   ProductID == model.ProductID &&
                   Name == model.Name &&
                   Amount == model.Amount &&
                   Price == model.Price &&
                   MeasureUnit == model.MeasureUnit &&
                   ProductGroupName == model.ProductGroupName;
        }
    }
}
