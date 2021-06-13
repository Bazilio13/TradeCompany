using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class ProductsDataAccess
    {
        private ProductsData _productsData = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        private ProductGroupsData _groupsData = new ProductGroupsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        private MapsDTOtoModel _mapsDTOtoModel = new MapsDTOtoModel();
        private MapModelToDTO _mapsModelToDTO = new MapModelToDTO();

        public List<ProductBaseModel> GetAllProducts()
        {
            List<ProductDTO> productDTO = _productsData.GetProducts();
            List <ProductBaseModel> productsModel = _mapsDTOtoModel.MapProductDTOToProductBaseModel(productDTO);
            return productsModel;
        }

        public List<ProductBaseModel> GetAllProductsByAllParams(string? inputString, int? productGroupID,
            float? fromStockAmount, float? toStockAmount, float? fromWholesalePrice, float? toWholesalePrice,
            float? fromRetailPrice, float? toRetailPrice, DateTime? minDateTime, DateTime? maxDateTime)
        {
            List<ProductDTO> productDTO = _productsData.GetProductsByAllParams(inputString, productGroupID, 
                     fromStockAmount, toStockAmount, fromWholesalePrice, toWholesalePrice, fromRetailPrice,
                     toRetailPrice, minDateTime, maxDateTime);
            List<ProductBaseModel> productsModel = _mapsDTOtoModel.MapProductDTOToProductBaseModel(productDTO);
            return productsModel;
        }

        public List<ProductGroupModel> GetAllGroups()
        {
            List<ProductGroupDTO> groupsDTO = _groupsData.GetProductGroups();
            List<ProductGroupModel> groupsModel = _mapsDTOtoModel.MapProductGroupDTOToProductGroupModel(groupsDTO);
            return groupsModel;
        }

        public ProductModel GetProductByID(int id)
        {
            List<ProductDTO> productDTO = new List<ProductDTO>();
            productDTO.Add(_productsData.GetProductByID(id));
            List<ProductModel> productsModel = _mapsDTOtoModel.MapProductDTOToProductModel(productDTO);
            return productsModel[0];
        }

        public int GetLastProductID()
        {
            return _productsData.GetLastProductID();
        }

        public void AddNewProduct(ProductModel productModel)
        {
            ProductDTO productDTO = _mapsModelToDTO.MapProductModelToProductDTO(productModel);
            _productsData.AddProduct(productDTO);
        }

        public void AddNewProductGroup(ProductGroupModel groupModel)
        {
            ProductGroupDTO groupDTO = _mapsModelToDTO.MapProductGroupModelToProductGroupDTO(groupModel);
            _groupsData.AddProductGroup(groupDTO);
        }

        public void HardDeleteProductByID(int productID)
        {
            _productsData.DeleteProductByID(productID);
        }

        public void SoftDeleteProductByID(int productID)
        {
            _productsData.SoftDeleteProductByID(productID);
        }

        public void AddProductToProductGroup(int ProductID, int ProductGroupID)
        {
            _productsData.AddProductToProductGroup(ProductID, ProductGroupID);
        }

        public void DeleteGroupFromProduct(int ProductID, int ProductGroupID)
        {
            _productsData.DeleteGroupFromProduct(ProductID, ProductGroupID);
        }

        public List<MeasureUnitsModel> GetAllMeasureUnits()
        {
            List<MeasureUnitsDTO> measureUnitsDTO = _productsData.GetAllMeasureUnits();
            List<MeasureUnitsModel> measureUnitsModel = _mapsDTOtoModel.MapMeasureUnitDTOToMeasureUnitModel(measureUnitsDTO);
            return measureUnitsModel;
        }

        public void UpdateProductByID(ProductModel productModel)
        {
            ProductDTO productDTO = _mapsModelToDTO.MapProductModelToProductDTO(productModel);
            _productsData.UpdateProductByID(productDTO);
        }
        public void ReduceProductAmountInStockByID(int id, int minusAmount)
        {
            _productsData.ReduceProductAmountInStockByID(id, minusAmount);

        }
    }
}
