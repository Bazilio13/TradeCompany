using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class OrderListsDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public ProductDTO productDTO { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderListsDTO dTO &&
                   ID == dTO.ID &&
                   OrderID == dTO.OrderID &&
                   ProductID == dTO.ProductID &&
                   Amount == dTO.Amount &&
                   Price == dTO.Price &&
                   productDTO == dTO.productDTO;
        }
    }
}
