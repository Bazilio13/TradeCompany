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
    public class ProductGroupsData
    {
        public string ConnectionString { get; set; }
        public ProductGroupsData()
        {
            ConnectionString = null;
        }
        public ProductGroupsData(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<ProductGroupDTO> GetProductGroups()
        {
            List<ProductGroupDTO> groups = new List<ProductGroupDTO>();
            string query;
            using (System.Data.IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetProductGroups";
                dbConnection.Query<ProductGroupDTO, ProductDTO, ProductGroupDTO>(query,
                    (group, product) =>
                    {
                        ProductGroupDTO crntGroup = null;
                        foreach (var g in groups)
                        {
                            if (g.ID == group.ID)
                            {
                                crntGroup = g;
                                break;
                            }
                        }
                        if (crntGroup is null)
                        {
                            crntGroup = group;
                            groups.Add(crntGroup);
                        }
                        if (!(product is null))
                        {
                            crntGroup.Products.Add(product);
                        }
                        return crntGroup;
                    },
                    splitOn: "ID");
            }
                return groups;
        }

        public ProductGroupDTO GetProductGroupByID(int id)
        {
            List<ProductGroupDTO> groups = new List<ProductGroupDTO>();
            ProductGroupDTO crntGroup = null;
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.GetProductGroupByID @ID";
                dbConnection.Query<ProductGroupDTO, ProductDTO, ProductGroupDTO>(query,
                    (group, product) =>
                    {
                        if (crntGroup is null)
                        {
                            crntGroup = group;
                            groups.Add(crntGroup);
                        }
                        if (!(product is null))
                        {
                            crntGroup.Products.Add(product);
                        }
                        return crntGroup;
                    }, new { id },
                    splitOn: "ID");
            }
            return crntGroup;
        }

        public void AddProductGroup(ProductGroupDTO group)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.AddProductGroup @Name";
                dbConnection.Query<ProductGroupDTO>(query, new
                {
                    group.Name
                });
            }
        }

        public void UpdateProductGroupByID(ProductGroupDTO group)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.UpdateProductGroupByID @ID, @Name";
                dbConnection.Query<ProductGroupDTO>(query, new
                {
                    group.ID,
                    group.Name,
                });
            }
        }

        public void DeleteProductGroupByID(int id)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "exec TradeCompany_DataBase.DeleteProductGroupByID @ID";
                dbConnection.Query(query, new { id });
            }
        }
    }
}
