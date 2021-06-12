using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class OrderListModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductMeasureUnit { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderListModel model &&
                   ID == model.ID &&
                   ProductID == model.ProductID &&
                   ProductName == model.ProductName &&
                   ProductMeasureUnit == model.ProductMeasureUnit &&
                   Amount == model.Amount &&
                   Price == model.Price;
        }
    }
}
