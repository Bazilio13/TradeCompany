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



    }
}
