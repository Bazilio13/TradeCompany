using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class FilterGroupModel
    {
        public DateTime? MinDateSupply { get; set; }
        public DateTime? MaxDateSupply { get; set; }
        public DateTime? MinDateOrder { get; set; }
        public DateTime? MaxDateOrder { get; set; }
        public DateTime? PeriodFor { get; set; }
        public DateTime? PeriodUntil { get; set; }

        public float? MinAmount { get; set; }
        public float? MaxAmount { get; set; } 
        public float? MinSum { get; set; }
        public float? MaxSum { get; set; }

        public FilterGroupModel()
        {
        }

        public void Null()
        {
            MinDateSupply = null;
            MaxDateSupply = null;
            MinDateOrder = null;
            MaxDateOrder = null;
            MinAmount = null;
            MaxAmount = null;
            MinSum = null;
            MaxSum = null;
            PeriodFor = null;
            PeriodUntil = null;
        }
    }
}
