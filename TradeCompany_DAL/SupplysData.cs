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

        public List<SupplyDTO> GetSupplysByID(int id)
        {
            List<SupplyDTO> resultList = new List<SupplyDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.GetSupplyById";
                dbConnection.Query<SupplyDTO, SupplyListDTO, ProductDTO, ProductGroupDTO, SupplyDTO>(query,
                    (supply, supplyList, product, productGroup) => MapsSupplyDTO(supply, supplyList, product, productGroup, resultList),
                    new { id }, commandType: CommandType.StoredProcedure);
            }
            return resultList;
        }

        public List<SupplyDTO> SearchSupplys(string str)
        {
            List<SupplyDTO> result = new List<SupplyDTO>();
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.SearchSupplys";
                dbConnection.Query<SupplyDTO, SupplyListDTO, ProductDTO, ProductGroupDTO, SupplyDTO>(query,
                    (supply, supplyList, product, productGroup) => MapsSupplyDTO(supply, supplyList, product, productGroup, result),
                    new { str }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public SupplyDTO MapsSupplyDTO(SupplyDTO supply, SupplyListDTO supplyList, ProductDTO product, ProductGroupDTO productGroup, List<SupplyDTO> result)
        {

            SupplyDTO crntSupply = null;
            foreach (var s in result)
            {
                if (s.ID == supply.ID)
                {
                    crntSupply = s;
                }
            }
            if (crntSupply == null)
            {
                crntSupply = supply;
                result.Add(crntSupply);
            }
            SupplyListDTO crntSupplyList = null;
            foreach (var sl in crntSupply.SupplyLists)
            {
                if (sl.ID == supplyList.ID)
                {
                    crntSupplyList = sl;
                }
            }
            if (crntSupplyList == null)
            {
                crntSupplyList = supplyList;
                crntSupply.SupplyLists.Add(crntSupplyList);
            }
            if (crntSupplyList.productDTO == null)
            {
                crntSupplyList.productDTO = product;
            }
            crntSupplyList.productDTO.Group.Add(productGroup);
            return supply;
        }

        public int AddSupply(SupplyDTO supplyDTO)
        {
            int addedSupplysID;
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.AddSupply";
                addedSupplysID = dbConnection.QuerySingle<int>(query,
                    new { supplyDTO.DateTime, supplyDTO.Comment }, commandType: CommandType.StoredProcedure);
            }
            return addedSupplysID;
        }

        public void AddSupplyLists(List<SupplyListDTO> supplyListDTOs)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                foreach (SupplyListDTO slDTO in supplyListDTOs)
                {
                    query = "TradeCompany_DataBase.AddSupplyList";
                    dbConnection.Query<int>(query,
                        new { slDTO.SupplyID, slDTO.ProductID, slDTO.Amount }, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public void UpdateSupplyByID(SupplyDTO supplyDTO)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.UpdateSupplyByID";
                dbConnection.Query<int>(query,
                    new { supplyDTO.ID, supplyDTO.DateTime, supplyDTO.Comment }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteSupplyListsBySupplyID(int supplyID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.DeleteSupplyListsBySupplyID";
                dbConnection.Query<int>(query,
                    new { supplyID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteSupplyByID(int id)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.DeleteSupplyByID";
                dbConnection.Query<int>(query,
                    new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateProductStockBySupplyID_Plus(int SupplyID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.UpdateProductStockBySupplyID_Plus";
                dbConnection.Query<int>(query,
                    new { SupplyID }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateProductStockBySupplyID_Minus(int SupplyID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.UpdateProductStockBySupplyID_Minus";
                dbConnection.Query<int>(query,
                    new { SupplyID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateProductLastSupplyDate(int SupplyID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "TradeCompany_DataBase.UpdateProductLastSupplyDate";
                dbConnection.Query<int>(query,
                    new { SupplyID }, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateProductLastSupplyDateWhenDeleteSupply (int SupplyID)
        {
            string query;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                query = "[TradeCompany_DataBase].[UpdateProductLastSupplyDateWhenDeleteSupply]";
                dbConnection.Query<int>(query,
                    new { SupplyID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
