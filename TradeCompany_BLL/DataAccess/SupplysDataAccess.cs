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
        private SupplysDataInterface _supplysData; 

        private SupplysMaps _map = new SupplysMaps();

        public SupplysDataAccess()
        {
            _supplysData = new SupplysData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        }

        public SupplysDataAccess(SupplysDataInterface supplysData)
        {
            _supplysData = supplysData;
        }

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

        public void AddSupply(SupplyModel supplyModel)
        {
            SupplyDTO supplyDTO = new SupplyDTO();
            supplyDTO = _map.MapsSupplyModelToSupplyDTO(supplyModel);
            supplyModel.ID = _supplysData.AddSupply(supplyDTO);
            foreach (SupplyListDTO slDTO in supplyDTO.SupplyLists)
            {
                slDTO.SupplyID = supplyModel.ID;
            }
            _supplysData.AddSupplyLists(supplyDTO.SupplyLists);
            _supplysData.UpdateProductStockBySupplyID_Plus(supplyModel.ID);
            _supplysData.UpdateProductLastSupplyDate(supplyModel.ID);
        }
        
        public void UpdateSupply(SupplyModel supplyModel)
        {
            SupplyDTO supplyDTO = new SupplyDTO();
            supplyDTO = _map.MapsSupplyModelToSupplyDTO(supplyModel);
            foreach (SupplyListDTO slDTO in supplyDTO.SupplyLists)
            {
                slDTO.SupplyID = supplyModel.ID;
            }
            _supplysData.UpdateSupplyByID(supplyDTO);
            _supplysData.DeleteSupplyListsBySupplyID(supplyDTO.ID);
            _supplysData.AddSupplyLists(supplyDTO.SupplyLists);
            _supplysData.UpdateProductStockBySupplyID_Minus(supplyModel.ID);
            _supplysData.UpdateProductStockBySupplyID_Plus(supplyModel.ID);
            _supplysData.UpdateProductLastSupplyDate(supplyModel.ID);
        }

        public void DeleteSupply(int id)
        {
            _supplysData.UpdateProductStockBySupplyID_Minus(id);
            _supplysData.DeleteSupplyByID(id);
            _supplysData.UpdateProductLastSupplyDateWhenDeleteSupply(id);
        }
    }
}
