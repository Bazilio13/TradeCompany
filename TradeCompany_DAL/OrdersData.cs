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
                dbConnection.Query<OrdersDTO, OrderListsDTO, ClientDTO, ProductDTO, OrdersDTO>(query,
                    (order, orderList, client, product) =>
                    {
                        orderList.productDTO = product;
                        OrdersDTO crntOrder = null;
                        foreach (var o in result)
                        {
                            if (o.ID == order.ID)
                            {
                                crntOrder = o;
                            }
                        }
                        if (crntOrder == null)
                        {
                            crntOrder = order;
                            crntOrder.ClientDTO = client;
                            result.Add(crntOrder);
                        }
                        if (orderList != null)
                        {
                            crntOrder.OrderLists.Add(orderList);
                        }
                        return order;
                    });
            }
            return result;
        }

        public List<OrdersDTO> GetOrdersByID(int id)
        {
            List<OrdersDTO> result = new List<OrdersDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetOrdersByID @ID";
                dbConnection.Query<OrdersDTO, OrderListsDTO, ClientDTO, ProductDTO, OrdersDTO>(query,
                    (order, orderList, client, product) =>
                    {
                        orderList.productDTO = product;
                        OrdersDTO crntOrder = null;
                        foreach (var o in result)
                        {
                            if (o.ID == order.ID)
                            {
                                crntOrder = o;
                            }
                        }
                        if (crntOrder == null)
                        {
                            crntOrder = order;
                            crntOrder.ClientDTO = client;
                            result.Add(crntOrder);
                        }
                        if (orderList != null)
                        {
                            crntOrder.OrderLists.Add(orderList);
                        }
                        return order;
                    },
                    new { id });
            }
            return result;
        }

        public List<ProductForOrderDTO> GetProductsByOrderId(int ID)
        {
            List<ProductForOrderDTO> result = new List<ProductForOrderDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                //query = "exec TradeCompany_DataBase.GetProductsInOrderByOrderId @ID";
                query = "exec TradeCompany_DataBase.GetProductsByOrderId @ID";
                result = dbConnection.Query<ProductForOrderDTO>(query, new { ID }).ToList();
            }
            return result;
        }

        public List<OrdersDTO> GetOrdersByParams(int? clientsID, DateTime? minDateTime, DateTime? maxDateTime, int? addressID, int? productID)
        {
            List<OrdersDTO> result = new List<OrdersDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetOrdersByParams @ClientsID, @MinDateTime, @MaxDateTime, @AddressID, @ProductID";
                dbConnection.Query<OrdersDTO, OrderListsDTO, OrdersDTO>(query,
                    (order, orderList) =>
                    {
                        OrdersDTO crntOrder = null;
                        foreach (var o in result)
                        {
                            if (o.ID == order.ID)
                            {
                                crntOrder = o;
                            }
                        }
                        if (crntOrder == null)
                        {
                            crntOrder = order;
                            result.Add(crntOrder);
                        }
                        if (orderList != null)
                        {
                            crntOrder.OrderLists.Add(orderList);
                        }
                        return order;
                    },
                    new { 
                        clientsID,
                        minDateTime,
                        maxDateTime,
                        addressID,
                        productID
                    });
            }
            return result;
        }
        public void UpdateOrdersByID(OrdersDTO ordersDTO)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.UpdateOrder @ID, @ClientsID, @Datetime, @AddressID, @Comment";
                dbConnection.Query(query,new {
                    ordersDTO.ID,
                    ordersDTO.ClientsID,
                    ordersDTO.Datetime,
                    ordersDTO.AddressID,
                    ordersDTO.Comment
                });
                query = "exec TradeCompany_DataBase.UpdateOrderListByID @ID, @OrderID, @ProductID, @Amount, @Price";
                foreach (OrderListsDTO olDTO in ordersDTO.OrderLists)
                {
                    dbConnection.Query(query, new
                    {
                        olDTO.ID,
                        olDTO.OrderID,
                        olDTO.ProductID,
                        olDTO.Amount,
                        olDTO.Price
                    });
                }
            }
        }        
    }
}
