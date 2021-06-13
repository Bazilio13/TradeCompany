using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class SupplyListDTO
    {
        public int ID { get; set; }
        public int SupplyID { get; set; }
        public int ProductID { get; set; }
        public float Amount { get; set; }
        public ProductDTO productDTO { get; set; }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is SupplyListDTO dTO)
            {
                if (!(productDTO is null && dTO.productDTO is null))
                {
                    result = productDTO.Equals(dTO.productDTO);
                }

                return result &&
                       ID == dTO.ID &&
                       SupplyID == dTO.SupplyID &&
                       ProductID == dTO.ProductID &&
                       Amount == dTO.Amount;
            }
            return false;
        }
    }
}
