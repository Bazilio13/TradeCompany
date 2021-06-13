using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public string MeasureUnitName { get; set; }
        public int MeasureUnit { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public DateTime? LastSupplyDate { get; set; }
        public List<ProductGroupModel> Groups { get; set; } = new List<ProductGroupModel>();
        public string Description { get; set; }
        public string Comments { get; set; }
        public ProductModel()
        {
            Groups = new List<ProductGroupModel>();
        }

        public override bool Equals(object obj)
        {
            return obj is ProductModel model &&
                   ID == model.ID &&
                   Name == model.Name &&
                   StockAmount == model.StockAmount &&
                   MeasureUnitName == model.MeasureUnitName &&
                   MeasureUnit == model.MeasureUnit &&
                   WholesalePrice == model.WholesalePrice &&
                   RetailPrice == model.RetailPrice &&
                   LastSupplyDate == model.LastSupplyDate &&
                   Description == model.Description &&
                   Comments == model.Comments;
        }
    }
}
