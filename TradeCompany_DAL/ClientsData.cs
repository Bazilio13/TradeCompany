using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;
using Dapper;
using System.Data.SqlClient;

namespace TradeCompany_DAL
{
    public class ClientsData
    {
        public string ConnectionString { get; set; }


        public ClientsData()
        {
            ConnectionString = null;
        } 

        public ClientsData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<ClientDTO> GetClients()
        {
            List<ClientDTO> clientsList = new List<ClientDTO>();
            string query = "exec TradeCompany_DataBase.GetClients";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                clientsList = dbConnection.Query<ClientDTO>(query).AsList<ClientDTO>();
            }

            return clientsList;
        }
    }
}
