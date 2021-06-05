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

        public List<ClientDTO> GetClientsByParams(int? person, int? sale, DateTime? minData, DateTime? maxData)
        {
            List<ClientDTO> clientsList = new List<ClientDTO>();
            string query = "exec TradeCompany_DataBase.GetClientsByParams @Person, @Sale, @MinData, @MaxData";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                clientsList = dbConnection.Query<ClientDTO>(query, new { 
                person,
                sale,
                minData,
                maxData
                }).AsList<ClientDTO>();
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
            string query = "exec TradeCompany_DataBase.AddClient @Name, @INN, @E_mail, @Phone, @Comment, @CorporateBody, @Type, @LastOrderDate, @ContactPerson";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<ClientDTO>(query, new {
                client.Name,
                client.INN,
                client.E_mail, 
                client.Phone,
                client.Comment,
                client.CorporateBody,
                client.Type,
                client.LastOrderDate,
                client.ContactPerson
                });
            }
        }

        public void DeleteClientByID(int id)
        {
            ClientDTO client = new ClientDTO();
            string query = "exec TradeCompany_DataBase.DeleteClientByID @ID";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<ClientDTO>(query, new { id });
            }
        }

        public void UpdateClientByID(ClientDTO client)
        {
            string query1 = "exec TradeCompany_DataBase.UpdateClientByID @ID, @Name, @INN, @E_mail, @Phone,  @Comment, @CorporateBody, @Type, @LastOrderDate, @ContactPerson";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<ClientDTO>(query1, new
                {
                    client.ID,
                    client.Name,
                    client.INN,
                    client.E_mail,
                    client.Phone,
                    client.Comment,
                    client.CorporateBody,
                    client.Type,
                    client.LastOrderDate,
                    client.ContactPerson
                }) ;
            }

        }

        public List<ClientDTO> GetClientsByName(string partOfTheName)
        {
            List<ClientDTO> clientsList = new List<ClientDTO>();

            string query = "exec TradeCompany_DataBase.GetClientsByName @PartOfTheName";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                clientsList = dbConnection.Query<ClientDTO>(query, new { partOfTheName }).AsList<ClientDTO>();
            }

            return clientsList;
        }

        public List<WishDTO> GetWishesListByClientID(int id)
        {
            List<WishDTO> wishList = new List<WishDTO>();

            string query = "exec TradeCompany_DataBase.GetWishesListByClientID @id";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                wishList = dbConnection.Query<WishDTO>(query, new { id }).AsList<WishDTO>();
            }

            return wishList;
        }

        public void DeleteWishListByID(int id)
        {
            string query = "exec TradeCompany_DataBase.DeleteWishListByID @id";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<WishDTO>(query, new { id });
            }
        }

        public void AddWishByID(int id, WishDTO wish)
        {
            string query = "exec TradeCompany_DataBase.AddWishByID @id, @IDProduct";
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Query<WishDTO>(query, new 
                { 
                    id,
                    wish.ID
                });
            }
        }



    }
}
