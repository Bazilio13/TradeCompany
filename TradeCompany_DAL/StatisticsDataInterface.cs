using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface StatisticsDataInterface
    {
        public List<StatisticsGroupsDTO> GetStatisticsProducts(DateTime? minDateSupply, DateTime? maxDateSupply, DateTime? minDateOrder, DateTime? maxDateOrder, float? minAmount, float? maxAmount, float? minSum, float? maxSum, DateTime? periodFor, DateTime? periodUntil);


        public List<StatisticsProductDTO> GetStatisticsProductsByGroupID(int id, DateTime? minDateSupply, DateTime? maxDateSupply, DateTime? minDateOrder, DateTime? maxDateOrder, float? minAmount, float? maxAmount, float? minSum, float? maxSum, DateTime? periodFor, DateTime? periodUntil);


    }
}
