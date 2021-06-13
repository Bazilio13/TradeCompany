using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface SupplysDataInterface
    {
        public List<SupplyDTO> GetSupplysByParams(DateTime? minDateTime, DateTime? maxDateTime, string product, string productGroup);

        public List<SupplyDTO> GetSupplysByID(int id);

        public List<SupplyDTO> SearchSupplys(string str);

        public SupplyDTO MapsSupplyDTO(SupplyDTO supply, SupplyListDTO supplyList, ProductDTO product, ProductGroupDTO productGroup, List<SupplyDTO> result);

        public int AddSupply(SupplyDTO supplyDTO);

        public void AddSupplyLists(List<SupplyListDTO> supplyListDTOs);

        public void UpdateSupplyByID(SupplyDTO supplyDTO);

        public void DeleteSupplyListsBySupplyID(int supplyID);

        public void DeleteSupplyByID(int id);

        public void UpdateProductStockBySupplyID_Plus(int SupplyID);

        public void UpdateProductStockBySupplyID_Minus(int SupplyID);

        public void UpdateProductLastSupplyDate(int SupplyID);

        public void UpdateProductLastSupplyDateWhenDeleteSupply(int SupplyID);
    }
}
