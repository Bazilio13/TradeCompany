using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI.TableElements
{
    public class Row: StackPanel
    {
        //List<string>;
        public int ID { get; set; }
        //public string Name { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public bool Type { get; set; }
        public DateTime? LastOrderDate { get; set; }

        public Row(PotentialClientModel model)
        {
            //_model = model;
            //Orientation = Orientation.Horizontal;
            //Children.
        }

    }
}
