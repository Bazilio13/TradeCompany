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
    public class AddressesData: AddressesDataInterface
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

        public List<AddressDTO> GetAddressesByID(int clientId)
        {
            List<AddressDTO> addressesList = new List<AddressDTO>();
            string query = "exec TradeCompany_DataBase.GetAddressesByClientID @ClientID";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                addressesList = dbConnection.Query<AddressDTO>(query, new { clientId}).AsList<AddressDTO>();
            }

            return addressesList;
        }

        public int AddAddress(int clientId, String address)
        {
            int id;
            string query = "exec TradeCompany_DataBase.AddAddress @ClientId, @Address";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                id = dbConnection.Query<int>(query, new
                {
                    clientId,
                    address
                }).AsList<int>()[0];
            }
            return id;
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

        public int SetIsDeleted(int clientId, String address, byte isDeleted)
        {
            int id;
            string query = "exec TradeCompany_DataBase.SetAddressIsDeleted @ClientId, @Address, @isDeleted";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                id = dbConnection.Query<int>(query, new
                {
                    clientId,
                    address,
                    isDeleted
                }).AsList<int>()[0];
            }

            return id;
        }

        public bool IsDeletedAddress(int clientId, String address)
        {
            bool isDeleted;
            byte flag;
            string query = "exec TradeCompany_DataBase.GetAddressIsDeleted @ClientId, @Address";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                flag = dbConnection.Query<byte>(query, new
                {
                    clientId,
                    address
                }).AsList<byte>()[0];
            }
            if(flag == 1)
            {
                isDeleted = true;
            }
            else
            {
                isDeleted = false;
            }
            return isDeleted;
        }
    }
}
