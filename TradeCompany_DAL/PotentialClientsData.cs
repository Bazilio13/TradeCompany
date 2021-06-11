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
    public class PotentialClientsData
    {
        private string _connectionString;
        public PotentialClientsData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PotentialClientDTO> GetPotentialClientDTOs(List<int> idsList, DateTime dateTime, int groupMatchNumber)
        {
            string ids = "";
            foreach (int i in idsList)
            {
                ids += i + " ";
            }
            List<PotentialClientDTO> result = new List<PotentialClientDTO>();
            string query = "[TradeCompany_DataBase].[GetPotentialClientsByProductsIDs]";
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Query<PotentialClientDTO, ProductDTO, PotentialClientDTO>(query,
                    (client, product) =>
                    {
                        PotentialClientDTO crntClient = null;
                        foreach (var c in result)
                        {
                            if (c.ID == client.ID)
                            {
                                crntClient = c;
                                break;
                            }
                        }
                        if (crntClient is null)
                        {
                            crntClient = client;
                            result.Add(crntClient);
                        }
                        crntClient.Products.Add(product);
                        return crntClient;
                    },
                    new { ids, dateTime, groupMatchNumber },
                    splitOn: "id, ProductID",
                    commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
