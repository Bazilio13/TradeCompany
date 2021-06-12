using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI.Interfaces
{
    interface IProductAddable
    {
        void AddProductToCollection(ProductBaseModel productBaseModel);
    }
}
