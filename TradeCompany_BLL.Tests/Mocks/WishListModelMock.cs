using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class WishListModelMock
    {
        public static List<WishModel> Model { get; set; } = new List<WishModel>()
        { new WishModel(){ ID = 10, Name = "Name1"}, new WishModel(){ ID = 101, Name = "Name2"},
            new WishModel(){ ID = 99, Name = "Name3"}, new WishModel(){ ID = 65, Name = "Name4"}
        };
    }
}
