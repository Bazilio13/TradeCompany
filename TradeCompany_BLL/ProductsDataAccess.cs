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
            List<ProductGroupModel> groupsModel = _mapsDTOtoModel.MapProductGroupToProductGroupModel(groupsDTO);
            return groupsModel;
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

        public void AddProductToProductGroup(int ProductID, int ProductGroupID)
        {
            _productsData.AddProductToProductGroup(ProductID, ProductGroupID);
        }

    }
}
