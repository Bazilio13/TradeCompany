using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientsID { get; set; }
        public string Client { get; set; }
        public string ClientsPhone { get; set; }
        public int AddressID { get; set; }
        public string Address { get; set; }
        public int Summ { get; set; }
        public string Comment { get; set; }
        public List<OrderListModel> OrderListModel { get; set; }

        public OrderModel()
        {
            OrderListModel = new List<OrderListModel>();
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is OrderModel model && OrderListModel.Count == model.OrderListModel.Count)
            {
                for (int i = 0; i < OrderListModel.Count; i++)
                {
                    if (!OrderListModel[i].Equals(model.OrderListModel[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == model.ID &&
                   DateTime == model.DateTime &&
                   ClientsID == model.ClientsID &&
                   Client == model.Client &&
                   ClientsPhone == model.ClientsPhone &&
                   AddressID == model.AddressID &&
                   Address == model.Address &&
                   Summ == model.Summ &&
                   Comment == model.Comment;
            }
            return false;
        }
    }
}
