using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;
using System.Data;

namespace TradeCompany_DAL
{
    public class ProductsData
    {
        public string ConnectionString { get; set; }
        public ProductsData()
        {
            ConnectionString = null;
        }
        public ProductsData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            string query;
            using (System.Data.IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetProducts";
                dbConnection.Query<ProductDTO, ProductGroupDTO, ProductDTO>(query,
                    (product, group) =>
                    {
                        ProductDTO crntProduct = null;
                        foreach (var p in products)
                        {
                            if (p.ID == product.ID)
                            {
                                crntProduct = p;
                                break;
                            }
                        }
                        if (crntProduct is null)
                        {
                            crntProduct = product;
                            products.Add(crntProduct);
                        }
                        if (!(group is null))
                        {
                            crntProduct.Group.Add(group);
                        }
                        return crntProduct;
                    },
                    splitOn: "ID");
            }
            return products;
        }

        public ProductDTO GetProductByID(int id)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            ProductDTO crntProduct = null;
            string query;
            using (System.Data.IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetProductByID @ID";
                dbConnection.Query<ProductDTO, ProductGroupDTO, ProductDTO>(query,
                    (product, group) =>
                    {
                        if (crntProduct is null)
                        {
                            crntProduct = product;
                            products.Add(crntProduct);
                        }
                        if (!(group is null))
                        {
                            crntProduct.Group.Add(group);
                        }
                        return crntProduct;
                    }, new { id },
                    splitOn: "ID");
            }
            return crntProduct;
        }


        public List<ProductDTO> GetProductsByLetter(string inputString)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            string query;
            using (System.Data.IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetProductByLetter @InputString";
                dbConnection.Query<ProductDTO, ProductGroupDTO, ProductDTO>(query,
                    (product, group) =>
                    {
                        ProductDTO crntProduct = null;
                        foreach (var p in products)
                        {
                            if (p.ID == product.ID)
                            {
                                crntProduct = p;
                                break;
                            }
                        }
                        if (crntProduct is null)
                        {
                            crntProduct = product;
                            products.Add(crntProduct);
                        }
                        if (!(group is null))
                        {
                            crntProduct.Group.Add(group);
                        }
                        return crntProduct;
                    }, new { inputString },
                    splitOn: "ID");
            }
            return products;
        }

        public void DeleteProductByID(int id)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.DeleteProductByID @ID";
                dbConnection.Query(query, new { id });
            }
        }

        public void DeleteGroupFromProduct(int productID, int productGroupID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.DeleteGroupFromProduct @ProductID, @ProductGroupID";
                dbConnection.Query(query, new { productID, productGroupID });
            }
        }
    }
}
