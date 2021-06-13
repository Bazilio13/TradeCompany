using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class SupplyListModel : ViewModel
    {
        private int _amount;
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductMeasureUnit { get; set; }
        public int Amount
        {
            get => _amount;
            
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public List<ProductGroupModel> ProductGroups { get; set; } = new List<ProductGroupModel>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is SupplyListModel model && ProductGroups.Count == model.ProductGroups.Count)
            {
                for (int i = 0; i < ProductGroups.Count; i++)
                {
                    if (!ProductGroups[i].Equals(model.ProductGroups[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   _amount == model._amount &&
                   ID == model.ID &&
                   ProductID == model.ProductID &&
                   ProductName == model.ProductName &&
                   ProductMeasureUnit == model.ProductMeasureUnit &&
                   Amount == model.Amount; ;
            }
            return false;
        }
    }
}
