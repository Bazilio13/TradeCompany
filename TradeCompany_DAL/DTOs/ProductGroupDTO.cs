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
        public List <ProductDTO> Products { get; set; }
    }
}
