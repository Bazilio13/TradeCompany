using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class FeedbackModel
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int ClientID { get; set; }
        public int OrderID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FeedbackModel model &&
                   ID == model.ID &&
                   DateTime == model.DateTime &&
                   Text == model.Text &&
                   ClientID == model.ClientID &&
                   OrderID == model.OrderID;
        }
    }
}
