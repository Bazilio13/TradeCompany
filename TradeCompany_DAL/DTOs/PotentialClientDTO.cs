using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class PotentialClientDTO
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public bool Type { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is PotentialClientDTO dTO && Products.Count == dTO.Products.Count)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i] is null || dTO.Products[i] is null)
                    {
                        result = Products[i] == dTO.Products[i];
                    }
                    else if (Products[i].Equals(dTO.Products[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == dTO.ID &&
                   ClientName == dTO.ClientName &&
                   E_mail == dTO.E_mail &&
                   Phone == dTO.Phone &&
                   ContactPerson == dTO.ContactPerson &&
                   Type == dTO.Type &&
                   LastOrderDate == dTO.LastOrderDate;
            }
            return false;
        }
    }
}
