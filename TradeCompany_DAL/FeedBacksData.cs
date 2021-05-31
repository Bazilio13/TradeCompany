using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TradeCompany_DAL
{
    public class FeedBacksData
    {
        public string ConnectionString { get; set; }
        public FeedBacksData()
        {
            ConnectionString = null;
        }
        public FeedBacksData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public FeedBacksDTO AddFeedback(FeedBacksDTO feedBacksDTO)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[AddFeedback] @Datetime,@Text,@ClientID,@OrderID";

                feedBacksDTO.ID = dbConnection.Query<int>(query, new
                {
                    feedBacksDTO.DateTime,
                    feedBacksDTO.Text,
                    feedBacksDTO.ClientID,
                    feedBacksDTO.OrderID,

                }).AsList<int>()[0];
            }
            return feedBacksDTO;
        }

        public void DeleteFeedbackById(int id)
        {
            string query;

            using(IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[DeleteFeedbackById] @ID";
                dbConnection.Query(query, new { id });
            }

        }

        public void DeleteFeedbackByOrderID(int orderID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[DeleteFeedbackByOrderID] @OrderID";
                dbConnection.Query(query, new { orderID });
            }
        }

        public void DeleteAllFeedbacksByClientId(int clientID)
        {
            string query;
            using(IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[DeleteAllFeedbacksByClientId] @ClientID";
                dbConnection.Query(query, new { clientID });
            }
        }
        public FeedBacksDTO GetFeedbackByID(int feedbackId)
        {
            string query;
            FeedBacksDTO result = new FeedBacksDTO();
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[GetFeedbackByID] @FeedbackId";
                result = dbConnection.QueryFirst<FeedBacksDTO>(query, new { feedbackId });
            }

            return result;
        }


    }
}
