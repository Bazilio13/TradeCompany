using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ClientBaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public DateTime? LastOrderDate { get; set; }


        public override bool Equals(object obj)
        {
            ClientBaseModel model = (ClientBaseModel)obj;
            return 
            ID == model.ID &&
            Name == model.Name &&
            E_mail == model.E_mail &&
            Phone == model.Phone &&
            ContactPerson == model.ContactPerson &&
            LastOrderDate == model.LastOrderDate;
        }

    }

}
