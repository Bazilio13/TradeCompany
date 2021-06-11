using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Interfaces;

namespace TradeCompany_BLL.Models
{
    public class ProductBaseModel: IRowItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public string MeasureUnitName { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public DateTime? LastSupplyDate { get; set; }
        public List<ProductGroupModel> Groups { get; set; } = new List<ProductGroupModel>();

        public ProductBaseModel()
        {
            Groups = new List<ProductGroupModel>();
        }
        public List<string> GetTextView()
        {
            List<string> TextView = new List<string>();
            TextView.Add(Name);
            TextView.Add($"{StockAmount}");
            TextView.Add(MeasureUnitName);
            TextView.Add($"{WholesalePrice}");
            TextView.Add($"{RetailPrice}");
            TextView.Add($"{LastSupplyDate}");
            return TextView;
        }
        public List<string> GetHeaders()
        {
            List<string> TextView = new List<string>();
            TextView.Add("Название");
            TextView.Add("Остаток");
            TextView.Add("Ед. изм.");
            TextView.Add("Розн. цена");
            TextView.Add("Опт. цена");
            TextView.Add("Последняя поставка");
            return TextView;
        }

        public List<IRowItem> GetDetalization()
        {
            return new List<IRowItem>();
        }

        public List<int> GetColomnSizes()
        {
            List<int> sizes = new List<int>();
            sizes.Add(250);
            sizes.Add(100);
            sizes.Add(100);
            sizes.Add(100);
            sizes.Add(150);
            sizes.Add(150);
            return sizes;
        }
    }
}
