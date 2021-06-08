using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.SypplysMaps;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.DataAccess
{
    public class SupplysDataAccess
    {
        private SupplysData _supplysData = new SupplysData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        private SupplysMaps _map = new SupplysMaps();
        public List<SupplyModel> GetSupplyModelsByParams(DateTime? minDateTime = null, DateTime? maxDateTime = null, string product = null, string productGroup = null)
        {
            List<SupplyDTO> supplyDTOs;
            supplyDTOs = _supplysData.GetSupplysByParams(minDateTime, maxDateTime, product, productGroup);
            List<SupplyModel> orderModels = _map.MapSupplyDTOToSupplyModel(supplyDTOs);
            return orderModels;
        }
        public SupplyModel GetSupplyModelByID(int id)
        {
            List<SupplyDTO> supplyDTOs;
            supplyDTOs = _supplysData.GetSupplysByID(id);
            List<SupplyModel> orderModels = _map.MapSupplyDTOToSupplyModel(supplyDTOs);
            if (orderModels.Count > 0)
            {
                return orderModels[0];
            }
            return null;
        }

        public List<SupplyModel> SearchSupplyModels(string str)
        {
            List<SupplyDTO> supplyDTOs;
            supplyDTOs = _supplysData.SearchSupplys(str);
            List<SupplyModel> supplyModels = _map.MapSupplyDTOToSupplyModel(supplyDTOs);
            return supplyModels;
        }
    }
}
