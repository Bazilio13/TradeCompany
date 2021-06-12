using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class OrdersDTO
    {
        public int ID { get; set; }
        public int ClientsID { get; set; }
        public DateTime DateTime { get; set; }
        public int AddressID { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public ClientDTO ClientDTO { get; set; }
        public List<OrderListsDTO> OrderLists { get; set; } = new List<OrderListsDTO>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is OrdersDTO dTO && OrderLists.Count == dTO.OrderLists.Count)
            {
                for (int i = 0; i < OrderLists.Count; i++)
                {
                    if (OrderLists[i] != dTO.OrderLists[i])
                    {
                        result = false;
                    }
                }

                return result &&
                       ID == dTO.ID &&
                       ClientsID == dTO.ClientsID &&
                       DateTime == dTO.DateTime &&
                       AddressID == dTO.AddressID &&
                       Comment == dTO.Comment &&
                       Address == dTO.Address &&
                       ClientDTO == dTO.ClientDTO;
            }
            return false;
        }
    }
}
