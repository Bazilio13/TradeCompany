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
        public string ConnectionString { get; set; }
        public OrdersData()
        {
            ConnectionString = null;
        }
        public OrdersData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public OrdersDTO AddOrder(OrdersDTO ordersDTO)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec [TradeCompany_DataBase].[AddOrder] @ClientsID, @Datetime, @AddressID, @Comment";
                ordersDTO.ID = dbConnection.Query<int>(query, new
                {
                    ordersDTO.ClientsID,
                    ordersDTO.Datetime,
                    ordersDTO.AddressID,
                    ordersDTO.Comment
                }).AsList<int>()[0];
                query = "exec TradeCompany_DataBase.AddOrderList @OrderID, @ProductID, @Amount, @Price";
                foreach (OrderListsDTO orderListDTO in ordersDTO.OrderLists)
                {
                    orderListDTO.OrderID = ordersDTO.ID;
                    orderListDTO.ID = dbConnection.Query<int>(query, new
                    {
                        orderListDTO.OrderID,
                        orderListDTO.ProductID,
                        orderListDTO.Amount,
                        orderListDTO.Price
                    }).AsList<int>()[0];
                }
            }
            return ordersDTO;
        }

        public List<OrderListsDTO> AddOrderList(List<OrderListsDTO> orderListsDTO)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.AddOrderList @OrderID, @ProductID, @Amount, @Price";
                foreach (OrderListsDTO orderListDTO in orderListsDTO)
                {
                    orderListDTO.ID = dbConnection.Query<int>(query, new
                    {
                        orderListDTO.OrderID,
                        orderListDTO.ProductID,
                        orderListDTO.Amount,
                        orderListDTO.Price
                    }).AsList<int>()[0];
                }
            }
            return orderListsDTO;
        }

        public void DeleteOrderByID(int id)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.DeleteOrderByID @ID";
                dbConnection.Query(query, new { id });
            }
        }
        public void DeleteOrderListByID(int id)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.DeleteOrderListByID @ID";
                dbConnection.Query(query, new { id });
            }
        }

        public List<OrdersDTO> GetOrders()
        {
            List<OrdersDTO> result = new List<OrdersDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetOrders";
                dbConnection.Query<OrdersDTO, OrderListsDTO, OrdersDTO>(query,
                    (order, orderList) =>
                    {
                        bool checkMatch = false;
                        foreach (var o in result)
                        {
                            if (o == order)
                            {
                                checkMatch = true;
                            }
                        }
                        if (!checkMatch)
                        {
                            result.Add(order);
                        }
                        order.OrderLists.Add(orderList);
                        return order;
                    });
            }
            return result;
        }
    }
}
