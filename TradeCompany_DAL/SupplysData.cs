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
    public class SupplysData
    {
        public string ConnectionString { get; set; }
        public SupplysData()
        {
            ConnectionString = null;
        }
        public SupplysData(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<SupplyDTO> GetSupplysByParams(DateTime? minDateTime, DateTime? maxDateTime, string product, string productGroup)
        {
            List<SupplyDTO> result = new List<SupplyDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.GetSupplysByParams";
                dbConnection.Query<SupplyDTO, SupplyListDTO, ProductDTO, ProductGroupDTO, SupplyDTO>(query,
                    (supply, supplyList, product, productGroup) => MapsSupplyDTO(supply, supplyList, product, productGroup, result),
                    new
                    {
                        minDateTime,
                        maxDateTime,
                        product,
                        productGroup
                    }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public List<SupplyDTO> SearchOrders(string str)
        {
            List<SupplyDTO> result = new List<SupplyDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.SearchOrders";
                dbConnection.Query<SupplyDTO, SupplyListDTO, ProductDTO, ProductGroupDTO, SupplyDTO>(query,
                    (supply, supplyList, product, productGroup) => MapsSupplyDTO(supply, supplyList, product, productGroup, result),
                    new { str }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public SupplyDTO MapsSupplyDTO(SupplyDTO supply, SupplyListDTO supplyList, ProductDTO product, ProductGroupDTO productGroup, List<SupplyDTO> result)
        {
            supplyList.productDTO = product;
            product.Group.Add(productGroup);
            SupplyDTO crntSupply = null;
            foreach (var o in result)
            {
                if (o.ID == supply.ID)
                {
                    crntSupply = o;
                }
            }
            if (crntSupply == null)
            {
                crntSupply = supply;
                result.Add(crntSupply);
            }
            if (supplyList != null)
            {
                crntSupply.SupplyLists.Add(supplyList);
            }
            return supply;
        }

    }
}
