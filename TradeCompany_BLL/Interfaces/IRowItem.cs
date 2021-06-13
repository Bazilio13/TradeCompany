using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Interfaces
{
    public interface IRowItem
    {
        List<string> GetTextView();
        List<string> GetHeaders();
        public List<IRowItem> GetDetalization();
        List<int> GetColomnSizes();
    }
}
