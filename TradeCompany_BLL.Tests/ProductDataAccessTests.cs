using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;
using Moq;
using NUnit.Framework;
using TradeCompany_BLL.Tests.ProductsSource;

namespace TradeCompany_BLL.Tests
{
    public class ProductDataAccessTests
    {
        ProductsData data = new ProductsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        Mock<ProductsDataInterface> mock = new Mock<ProductsDataInterface>();
        ProductsDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new ProductsDataAccess(mock.Object);
        }


        [TestCaseSource(typeof(GetAllProductsByAllParamsSource))]
        public void GetAllProductsByAllParamsTests(string inputString, int productGroupID,
            float fromStockAmount, float toStockAmount, float fromWholesalePrice, float toWholesalePrice,
            float fromRetailPrice, float toRetailPrice, DateTime minDateTime, DateTime maxDateTime, List<ProductDTO> products, List<ProductBaseModel> expected)
        {
            mock.Setup(a => a.GetProductsByAllParams(inputString, productGroupID,
                     fromStockAmount, toStockAmount, fromWholesalePrice, toWholesalePrice, fromRetailPrice,
                     toRetailPrice, minDateTime, maxDateTime)).Returns(products);

            List<ProductBaseModel> actual = dataAccess.GetAllProductsByAllParams(inputString, productGroupID,
                     fromStockAmount, toStockAmount, fromWholesalePrice, toWholesalePrice, fromRetailPrice,
                     toRetailPrice, minDateTime, maxDateTime);

            Assert.AreEqual(expected, actual);
        }
    }
}
