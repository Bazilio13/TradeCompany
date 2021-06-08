﻿using Dapper;
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
            SupplyDTO result = null;
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

    }
}