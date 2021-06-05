using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class OrderListModel : INotifyPropertyChanged
    {
        private int _ProductID;
        private string _ProductName;
        private int _Amount;
        public int ID { get; set; }
        public int ProductID
        {
            get { return _ProductID; }
            set
            {
                if (_ProductID == value) return;

                _ProductID = value;
                OnPropertyChanged("ProductID");
            }
        }
            
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if (_ProductName == value) return;

                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public string ProductMeasureUnit { get; set; }
        public int Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount == value) return;

                _Amount = value;
                OnPropertyChanged("Amount");
            }  
        }
        public int Price { get; set; }

        public decimal Sum { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
