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

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is SupplyModel model && SupplyListModel.Count == model.SupplyListModel.Count)
            {
                for (int i = 0; i < SupplyListModel.Count; i++)
                {
                    if (!SupplyListModel[i].Equals(model.SupplyListModel[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == model.ID &&
                   DateTime == model.DateTime &&
                   Comment == model.Comment;
            }
            return false;
        }
    }
}
