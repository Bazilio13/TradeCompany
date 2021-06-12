using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_BLL.Tests.Mocks
{
    public static class DateTimeMock
    {
        public static List<DateTime> DateTimes { get; set; } = new List<DateTime>() 
        { new DateTime(2021, 2, 3, 13, 20, 35),
          new DateTime(2021, 4, 10, 8, 30, 10),
          new DateTime(2021, 10, 18, 22, 5, 55)};
    }
}
