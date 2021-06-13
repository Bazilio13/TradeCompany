using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{

        public class StatisticsProductModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public float Summ { get; set; }
            public DateTime? LastSupplyDate { get; set; }
            public DateTime? LastOrderDate { get; set; }
            public float Amount { get; set; }
            public int StockAmount { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StatisticsProductModel model &&
                   ID == model.ID &&
                   Name == model.Name &&
                   Summ == model.Summ &&
                   LastSupplyDate == model.LastSupplyDate &&
                   LastOrderDate == model.LastOrderDate &&
                   Amount == model.Amount &&
                   StockAmount == model.StockAmount;
        }
    }
}
