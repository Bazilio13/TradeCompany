using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class WishListDTOMock
    {
        public static List<WishDTO> DTOsFromDB { get; set; } = new List<WishDTO>()
        { new WishDTO(){ ID = 10, Name = "Name1"}, new WishDTO(){ ID = 101, Name = "Name2"},
            new WishDTO(){ ID = 99, Name = "Name3"}, new WishDTO(){ ID = 65, Name = "Name4"}
        };
    }
}
