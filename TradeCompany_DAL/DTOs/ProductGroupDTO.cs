using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class ProductGroupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List <ProductDTO> Products { get; set; } = new List<ProductDTO>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is ProductGroupDTO dTO && Products.Count == dTO.Products.Count)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i] != dTO.Products[i])
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == dTO.ID &&
                   Name == dTO.Name;
            }
            return false;
        }
    }
}
