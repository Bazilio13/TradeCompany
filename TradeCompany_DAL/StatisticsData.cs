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


        public List<StatisticsGroupsDTO> GetStatisticsProducts()
        {
            List<StatisticsGroupsDTO> statisticsList = new List<StatisticsGroupsDTO>();
            string query = "exec TradeCompany_DataBase.GetStatisticsProducts";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                statisticsList = dbConnection.Query<StatisticsGroupsDTO>(query).AsList<StatisticsGroupsDTO>();
            }

            return statisticsList;
        }

        public List<StatisticsProductDTO> GetStatisticsProductsByGroupID(int id)
        {
            List<StatisticsProductDTO> statisticsList = new List<StatisticsProductDTO>();
            string query = "exec TradeCompany_DataBase.GetStatisticsProductsByGroupID @id";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                statisticsList = dbConnection.Query<StatisticsProductDTO>(query, new { id}).AsList<StatisticsProductDTO>();
            }

            return statisticsList;
        }

    }
}
