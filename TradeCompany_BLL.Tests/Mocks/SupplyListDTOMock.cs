using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class SupplyListDTOMock
    {
        public static List<SupplyListDTO> DTOs { get; set; } = new List<SupplyListDTO>()
        { new SupplyListDTO { ID = 1, ProductID = 1, SupplyID = 1, Amount = 10, productDTO = ProductsDTOMock.DTOs[0] },
          new SupplyListDTO { ID = 2, ProductID = 2, SupplyID = 1, Amount = 50, productDTO = ProductsDTOMock.DTOs[1] },
          new SupplyListDTO { ID = 2, ProductID = 2, SupplyID = 2, Amount = 50, productDTO = ProductsDTOMock.DTOs[1] },
          new SupplyListDTO { ID = 3, ProductID = 3, SupplyID = 3, Amount = 20, productDTO = ProductsDTOMock.DTOs[2] },
          new SupplyListDTO { ID = 1, ProductID = 4, SupplyID = 4, Amount = 40, productDTO = ProductsDTOMock.DTOs[3] }};
    }
}
