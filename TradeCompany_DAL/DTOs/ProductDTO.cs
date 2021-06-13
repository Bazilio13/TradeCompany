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
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public DateTime? LastSupplyDate { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public List<ProductGroupDTO> Group { get; set; } = new List<ProductGroupDTO>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is ProductDTO dTO && Group.Count == dTO.Group.Count)
            {
                for (int i = 0; i < Group.Count; i++)
                {
                    if (Group[i] is null || dTO.Group[i] is null)
                    {
                        result = Group[i] == dTO.Group[i];
                    }
                    else if (Group[i].Equals(dTO.Group[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == dTO.ID &&
                   Name == dTO.Name &&
                   StockAmount == dTO.StockAmount &&
                   MeasureUnit == dTO.MeasureUnit &&
                   MeasureUnitName == dTO.MeasureUnitName &&
                   WholesalePrice == dTO.WholesalePrice &&
                   RetailPrice == dTO.RetailPrice &&
                   LastSupplyDate == dTO.LastSupplyDate &&
                   Description == dTO.Description &&
                   Comments == dTO.Comments;
            }
            return false;;
        }
    }
}
