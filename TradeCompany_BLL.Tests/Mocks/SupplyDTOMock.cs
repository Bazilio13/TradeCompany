using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class SupplyDTOMock
    {
        public static List<SupplyDTO> DTOsFromDB { get; set; } = new List<SupplyDTO>()
        { new SupplyDTO() {ID = 1, DateTime = DateTimeMock.DateTimes[0], Comment = "Comment",
            SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsFromDB[0], SupplyListDTOMock.DTOsFromDB[1]} },
          new SupplyDTO() {ID = 2, DateTime = DateTimeMock.DateTimes[1],SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsFromDB[2]} },
          new SupplyDTO() {ID = 3, DateTime = DateTimeMock.DateTimes[2],SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsFromDB[3]}} 
        };

        public static List<SupplyDTO> DTOsToDB { get; set; } = new List<SupplyDTO>()
        { new SupplyDTO() {ID = 1, DateTime = DateTimeMock.DateTimes[0], Comment = "Comment",
            SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsToDB[0], SupplyListDTOMock.DTOsToDB[1]} },
          new SupplyDTO() {ID = 2, DateTime = DateTimeMock.DateTimes[1],SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsToDB[2]} },
          new SupplyDTO() {ID = 3, DateTime = DateTimeMock.DateTimes[2],SupplyLists = new List<SupplyListDTO>(){SupplyListDTOMock.DTOsToDB[3]}}
        };
    }
}
