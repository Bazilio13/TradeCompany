using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class SupplyListModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductMeasureUnit { get; set; }
        public int Amount { get; set; }
        public List<ProductGroupModel> ProductGroups { get; set; } = new List<ProductGroupModel>();
}
}
