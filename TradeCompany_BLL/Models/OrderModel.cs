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
        public float Summ { get; set; }
        public string Comment { get; set; }
        public List<OrderListModel> OrderListModel { get; set; }

        public OrderModel()
        {
            OrderListModel = new List<OrderListModel>();
        }
    }
}
