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


        public List<StatisticsProductsDTO> GetStatisticsProducts()
        {
            List<StatisticsProductsDTO> statisticsList = new List<StatisticsProductsDTO>();
            string query = "exec TradeCompany_DataBase.GetStatisticsProducts";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                statisticsList = dbConnection.Query<StatisticsProductsDTO>(query).AsList<StatisticsProductsDTO>();
            }

            return statisticsList;
        }
    }
}
