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
    public class OrdersData
    {
        private static string _query;
        public string ConnectionString { get; set; }
        public OrdersData()
        {
            ConnectionString = null;
            _query = null;
        }
        public OrdersData(string connectionString)
        {
            ConnectionString = connectionString;
            _query = null;
        }

        public List<int> AddOrder(OrdersDTO ordersDTO)
        {
            List<int> indexesOfNewOrder = new List<int>();
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                _query = "exec TradeCompany_DataBase.AddOrder";
                indexesOfNewOrder = dbConnection.Query<int>(_query, new { ordersDTO.ClientsID, ordersDTO.Datetime, ordersDTO.AddressID,
                    ordersDTO.Comment }).AsList<int>();
                _query = "exec TradeCompany_DataBase.AddOrderList";
                foreach (OrderListDTO orderListDTO in ordersDTO.OrderLists)
                {
                    indexesOfNewOrder.Add(dbConnection.Query<int>(_query, new { orderListDTO.OrderID, orderListDTO.ProductID, orderListDTO.Amount,
                        orderListDTO.Price }).AsList<int>()[0]);
                }
            }
            return indexesOfNewOrder;
        }
    }
}
