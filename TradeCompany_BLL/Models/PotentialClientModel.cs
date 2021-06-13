using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Interfaces;

namespace TradeCompany_BLL.Models
{
    public class PotentialClientModel : IRowItem
    {
        public int ID { get; set; } = -1;
        public string ClientName { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public bool Type { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public List<ProductBaseModel> Products { get; set; } = new List<ProductBaseModel>();


        public List<string> GetTextView()
        {
            List<string> textView = new List<string>();
            textView.Add($"{ID}");
            textView.Add(ClientName);
            textView.Add(ContactPerson);
            textView.Add(Phone);
            textView.Add(E_mail);
            if (Type)
            {
                textView.Add("Оптовый клиент");
            }
            else
            {
                textView.Add("Розничный клиент");
            }
            return textView;
        }
        public List<IRowItem> GetDetalization()
        {
            List<IRowItem> products = new List<IRowItem>();
            IRowItem row = new PotentialClientModel();
            foreach (ProductBaseModel productBaseModel in Products)
            {
                products.Add(productBaseModel);
            }
            return products;
        }

        public List<string> GetHeaders()
        {
            List<string> headers = new List<string>();
            headers.Add("ID");
            headers.Add("Клиент");
            headers.Add("Контактное лицо");
            headers.Add("Телефон");
            headers.Add("E-mail");
            headers.Add("Опт/розница");
            return headers;
        }

        public List <int> GetColomnSizes()
        {
            List<int> sizes = new List<int>();
            sizes.Add(30);
            sizes.Add(200);
            sizes.Add(200);
            sizes.Add(120);
            sizes.Add(150);
            sizes.Add(150);
            return sizes;
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is PotentialClientModel model && Products.Count == model.Products.Count)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (!Products[i].Equals(model.Products[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == model.ID &&
                   ClientName == model.ClientName &&
                   E_mail == model.E_mail &&
                   Phone == model.Phone &&
                   ContactPerson == model.ContactPerson &&
                   Type == model.Type &&
                   LastOrderDate == model.LastOrderDate;
            }
            return false;
        }
    }
}
