using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class SupplyModel
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
        public List<SupplyListModel> SupplyListModel { get; set; }

        public SupplyModel()
        {
            SupplyListModel = new List<SupplyListModel>();
        }
    }
}
