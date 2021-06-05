using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_UI
{
    public class ContactInformation
    {
        
        public int ID { get; set; }
        public string Client { get; set; }
        public string ClientsPhone { get; set; }
        public DateTime dateTime { get; set; }
        public string Address { get; set; }

        //public string _deafaultInformation = "Информация отсутствует";
        public ContactInformation()
        {
           // Client = _deafaultInformation;
           // ClientsPhone = _deafaultInformation;
           //Address = _deafaultInformation;

        }
    }
}
