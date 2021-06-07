using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Models
{
    public class OrderListModel 
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
             
            }
        }
            
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if (_ProductName == value) return;

                _ProductName = value;
              
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
              
            }  
        }
        public int Price { get; set; }

        public decimal Sum { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
