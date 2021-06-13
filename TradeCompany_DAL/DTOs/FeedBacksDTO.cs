using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class FeedBacksDTO
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int ClientID { get; set; }
        public int OrderID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FeedBacksDTO dTO &&
                   ID == dTO.ID &&
                   DateTime == dTO.DateTime &&
                   Text == dTO.Text &&
                   ClientID == dTO.ClientID &&
                   OrderID == dTO.OrderID;
        }
    }
}
