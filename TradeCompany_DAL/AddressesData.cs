using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace TradeCompany_DAL
{
    public class AddressesData
    {
        public string ConnectionString { get; set; }

        public AddressesData()
        {
            ConnectionString = null;
        }

        public AddressesData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<AddressDTO> GetAddresses()
        {
            List<AddressDTO> addressesList = new List<AddressDTO>();
            string query = "exec TradeCompany_DataBase.GetAddresses";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                addressesList = dbConnection.Query<AddressDTO>(query).AsList<AddressDTO>();
            }

            return addressesList;
        }

        public List<String> GetAddressesByID(int clientId)
        {
            List<String> addressesList = new List<String>();
            string query = "exec TradeCompany_DataBase.GetAddressesByClientID @ClientID";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                addressesList = dbConnection.Query<String>(query, new { clientId}).AsList<String>();
            }

            return addressesList;
        }

        public void AddAddress(int clientId, String address) // почему тут String, а не string и нужно вернуть индекс
        {
            string query = "exec TradeCompany_DataBase.AddAddress @ClientId, @Address";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<AddressDTO>(query, new
                {
                    clientId,
                    address
                });
            }
        }

        public void DeleteAddressByIDAndAddress(int clientId, String address)
        {
            string query = "exec TradeCompany_DataBase.DeleteAddressByIDAndAddress @ClientId, @Address";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<AddressDTO>(query, new {
                    clientId,
                    address
                });
            }
        }

        public void DeleteAddressByID(int clientId)
        {
            string query = "exec TradeCompany_DataBase.DeleteAllAddressesByID @ClientId";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<AddressDTO>(query, new
                {
                    clientId
                });
            }
        }

    }
}
