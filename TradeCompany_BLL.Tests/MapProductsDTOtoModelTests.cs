using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.ProductsSource;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    class MapProductsDTOtoModelTests
    {
        MapsDTOtoModel mapsDTOtoModel = new MapsDTOtoModel();

        [SetUp]
        public void Setup()
        {

        }

        [TestCaseSource(typeof(Map_ProductsForOrderDTO_To_ProductsForOrderModelSource))]
        public void Map_ProductsForOrderDTO_To_ProductsForOrderModelTests(List<ProductForOrderDTO> productForOrderDTO, List<ProductsForOrderModel>  expected )
        {
            List<ProductsForOrderModel> actual = mapsDTOtoModel.Map_ProductsForOrderDTO_To_ProductsForOrderModel(productForOrderDTO);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapProductDTOToProductBaseModelSource))]
        public void MapProductDTOToProductBaseModelTests(List<ProductDTO> productDTO, List<ProductBaseModel> expected)
        {
            List<ProductBaseModel> actual = mapsDTOtoModel.MapProductDTOToProductBaseModel(productDTO);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapProductDTOToProductModelSource))]
        public void MapProductDTOToProductModelTests(List<ProductModel> expected, List<ProductDTO> productDTO)
        {
            List<ProductModel> actual = mapsDTOtoModel.MapProductDTOToProductModel(productDTO);

            Assert.AreEqual(expected, actual);
        }
    }


}
