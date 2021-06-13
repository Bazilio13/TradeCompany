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
    class MapStatisticsProductsDTOToStatisticsProductsModel_Source:IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { StatisticsDTOMock.ProductDTO, StatisticsModelMock.ProductModel };
            yield return new object[] { new List<StatisticsProductDTO>() { StatisticsDTOMock.ProductDTO[1], StatisticsDTOMock.ProductDTO[1] } ,
                new List<StatisticsProductModel>(){ StatisticsModelMock.ProductModel[1], StatisticsModelMock.ProductModel[1] }  };
            yield return new object[] { new List<StatisticsProductDTO>() { StatisticsDTOMock.ProductDTO[1], StatisticsDTOMock.ProductDTO[0] } ,
                new List<StatisticsProductModel>(){ StatisticsModelMock.ProductModel[1], StatisticsModelMock.ProductModel[0] }  };

        }


    }
}
