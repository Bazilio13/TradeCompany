using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

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
    }
}
