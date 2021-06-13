using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface ProductsDataInterface
    {
        public List<ProductDTO> GetProducts();

        public List<ProductDTO> GetProductsByAllParams(string inputString, int? ProductGroupID, float? fromStockAmount, float? toStockAmount,
            float? fromWholesalePrice, float? toWholesalePrice, float? fromRetailPrice, float? toRetailPrice,
            DateTime? minDateTime, DateTime? maxDateTime);

        public ProductDTO GetProductByID(int id);

        public int GetLastProductID();
        public List<ProductDTO> GetProductsByLetter(string inputString);

        public void DeleteProductByID(int id);

        public void SoftDeleteProductByID(int id);

        public void DeleteGroupFromProduct(int id, int productGroupID);

        public void AddProduct(ProductDTO product);

        public void AddProductToProductGroup(int id, int productGroupID);
        public void UpdateProductByID(ProductDTO product);

        public List<MeasureUnitsDTO> GetAllMeasureUnits();
        public void ReduceProductAmountInStockByID(int id, int amount);
    }
}
