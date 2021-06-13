using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class ClientModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string Comment { get; set; }
        public bool Type { get; set; }
        public bool CorporateBody { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public override bool Equals(object obj)
        {

            return obj is ClientModel model &&
                   ID == model.ID &&
                   Name == model.Name &&
                   INN == model.INN &&
                   E_mail == model.E_mail &&
                   Phone == model.Phone &&
                   ContactPerson == model.ContactPerson &&
                   Comment == model.Comment &&
                   Type == model.Type &&
                   CorporateBody == model.CorporateBody &&
                   LastOrderDate == model.LastOrderDate &&
                   RegistrationDate == model.RegistrationDate;
        }

    }

}
