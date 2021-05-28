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

        public ClientDTO GetClientByID(int id)
        {
            ClientDTO client = new ClientDTO();
            string query = "exec TradeCompany_DataBase.GetClientByID @ID";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                client = dbConnection.Query<ClientDTO>(query, new { id }).Single<ClientDTO>();
            }

            return client;
        }

        public void AddClient(ClientDTO client)
        {
            string query = "exec TradeCompany_DataBase.AddClient @Name, @INN, @Email, @Phone, @Comment, @CorporateBody, @Type, @LastOrderDate";

            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<ClientDTO>(query, new {
                client.Name,
                client.INN,
                client.Email, 
                client.Phone,
                client.Type,
                client.CorporateBody,
                client.LastOrderDate,
                client.Comment
                });
            }
        }
    }
}
