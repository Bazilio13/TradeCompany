using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public class StatisticsData
    {
        public string ConnectionString { get; set; }

        public StatisticsData()
        {
            ConnectionString = null;
        }

        public StatisticsData(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public List<StatisticsGroupsDTO> GetStatisticsProducts(DateTime? minDateSupply, DateTime? maxDateSupply, DateTime? minDateOrder, DateTime? maxDateOrder, float? minAmount, float? maxAmount, float? minSum, float? maxSum, DateTime? periodFor, DateTime? periodUntil)
        {
            List<StatisticsGroupsDTO> statisticsList = new List<StatisticsGroupsDTO>();
            string query = "exec TradeCompany_DataBase.GetStatisticsProducts @MinDateSupply, @MaxDateSupply, @MinDateOrder, @MaxDateOrder, @MinAmount, @MaxAmount, @MinSum, @MaxSum, @PeriodFor, @PeriodUntil";

            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                statisticsList = dbConnection.Query<StatisticsGroupsDTO>(query, new {
                minDateSupply,
                maxDateSupply,
                minDateOrder,
                maxDateOrder,
                minAmount,
                maxAmount,
                minSum,
                maxSum,
                periodFor,
                periodUntil
                }
                    ).AsList<StatisticsGroupsDTO>();
            }

            return statisticsList;
        }

        public List<StatisticsProductDTO> GetStatisticsProductsByGroupID(int id, DateTime? minDateSupply, DateTime? maxDateSupply, DateTime? minDateOrder, DateTime? maxDateOrder, float? minAmount, float? maxAmount, float? minSum, float? maxSum, DateTime? periodFor, DateTime? periodUntil)
        {
            List<StatisticsProductDTO> statisticsList = new List<StatisticsProductDTO>();
            string query = "exec TradeCompany_DataBase.GetStatisticsProductsByGroupID @id, @MinDateSupply, @MaxDateSupply, @MinDateOrder, @MaxDateOrder, @MinAmount, @MaxAmount, @MinSum, @MaxSum, @PeriodFor, @PeriodUntil";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                statisticsList = dbConnection.Query<StatisticsProductDTO>(query, new { 
                    id,
                    minDateSupply,
                    maxDateSupply,
                    minDateOrder,
                    maxDateOrder,
                    minAmount,
                    maxAmount,
                    minSum,
                    maxSum,
                    periodFor,
                    periodUntil
                }).AsList<StatisticsProductDTO>();
            }

            return statisticsList;
        }

    }
}
