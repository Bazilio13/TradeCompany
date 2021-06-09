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
    }
}