using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.StatisticMapSource
{
    class MapStatisticsGroursDTOToStatisticsGroursModel_Source : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { StatisticsDTOMock.GroupDTO, StatisticsModelMock.GroupModel };
            yield return new object[] { new List<StatisticsGroupsDTO>() { StatisticsDTOMock.GroupDTO[1], StatisticsDTOMock.GroupDTO[1] } ,
                new List<StatisticsGroupsModel>(){ StatisticsModelMock.GroupModel[1], StatisticsModelMock.GroupModel[1] }  };
            yield return new object[] { new List<StatisticsGroupsDTO>() { StatisticsDTOMock.GroupDTO[1], StatisticsDTOMock.GroupDTO[0] } ,
                new List<StatisticsGroupsModel>(){ StatisticsModelMock.GroupModel[1], StatisticsModelMock.GroupModel[0] }  };

        }
    }
}
