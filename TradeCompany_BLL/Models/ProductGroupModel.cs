using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ProductGroupModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ProductBaseModel> Products { get; set; } = new List<ProductBaseModel>();

        public ProductGroupModel()
        {
            Products = new List<ProductBaseModel>();
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is ProductGroupModel model && Products.Count == model.Products.Count)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i] != model.Products[i])
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == model.ID &&
                   Name == model.Name;
            }
            return false;
        }
    }
}
