using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.ProductsSource
{

    public class Map_ProductsForOrderDTO_To_ProductsForOrderModelSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new List<ProductForOrderDTO>{
                        new ProductForOrderDTO{ProductID = 1, Name = "Мыло", Amount = 20, Price = 30, MeasureUnit = 1, ProductGroupName = "Хоз"},
                        new ProductForOrderDTO{ProductID = 2, Name = "Ручка", Amount = 100, Price = 15, MeasureUnit = 1, ProductGroupName = "Канцелярия"},
                        new ProductForOrderDTO{ ProductID = 3, Name = "Карандаш", Amount = 50, Price = 40, MeasureUnit = 1, ProductGroupName = "Канцелярия"}},
                    new List<ProductsForOrderModel>{
                        new ProductsForOrderModel{ProductID = 1, Name = "Мыло", Amount = 20, Price = 30, MeasureUnit = 1, ProductGroupName = "Хоз"},
                        new ProductsForOrderModel{ ProductID = 2, Name = "Ручка", Amount = 100, Price = 15, MeasureUnit = 1, ProductGroupName = "Канцелярия"},
                        new ProductsForOrderModel{ ProductID = 3, Name = "Карандаш", Amount = 50, Price = 40, MeasureUnit = 1, ProductGroupName = "Канцелярия" }}
            };

            yield return new object[]
            {
                        new List<ProductForOrderDTO>{
                        new ProductForOrderDTO{ ProductID = 1, Name = "Кофе", Amount = 20, Price = 1000, MeasureUnit = 3, ProductGroupName = "Продукты" },
                        new ProductForOrderDTO{ ProductID = 2, Name = "Молоко", Amount = 100, Price = 80, MeasureUnit = 2, ProductGroupName = "Продукты" },
                        new ProductForOrderDTO{ ProductID = 3, Name = "Сахар", Amount = 50, Price = 150, MeasureUnit = 3, ProductGroupName = "Продукты" } },
                    new List<ProductsForOrderModel>{
                        new ProductsForOrderModel{ ProductID = 1, Name = "Кофе", Amount = 20, Price = 1000, MeasureUnit = 3, ProductGroupName = "Продукты"},
                        new ProductsForOrderModel{ ProductID = 2, Name = "Молоко", Amount = 100, Price = 80, MeasureUnit = 2, ProductGroupName = "Продукты" },
                        new ProductsForOrderModel{ ProductID = 3, Name = "Сахар", Amount = 50, Price = 150, MeasureUnit = 3, ProductGroupName = "Продукты" }}
            };

            yield return new object[]
            {
                    new List<ProductForOrderDTO>{},
                    new List<ProductsForOrderModel>{ }
            };
        }
    }

    public class MapProductDTOToProductBaseModelSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new List<ProductDTO>{
                        new ProductDTO{ ID = 1, Name = "Мыло", StockAmount = 20,  MeasureUnit = 1, MeasureUnitName = "шт.",
                            WholesalePrice = 30, RetailPrice = 15 ,  LastSupplyDate = null, Description = "qwertyuio", Comments = "wfwkwlok",
                            Group = new List<ProductGroupDTO>{ } },
                        new ProductDTO{ ID = 2, Name = "Ручка", StockAmount = 100,  MeasureUnit = 1, MeasureUnitName = "шт.",
                            WholesalePrice = 15, RetailPrice = 50 ,  LastSupplyDate = null, Description = "qwertyuio", Comments = "wfwkwlok",
                            Group = new List<ProductGroupDTO>{ } },
                        new ProductDTO{ ID = 3, Name = "Карандаш", StockAmount = 50,  MeasureUnit = 1, MeasureUnitName = "шт.",
                            WholesalePrice = 40, RetailPrice = 50 ,  LastSupplyDate = null, Description = "qwertyuio", Comments = "wfwkwlok",
                            Group = new List<ProductGroupDTO>{ } }
                    },
                    new List<ProductBaseModel>{
                        new ProductBaseModel{ID = 1, Name = "Мыло", StockAmount = 20,  MeasureUnitName = "шт.", WholesalePrice = 30,
                            RetailPrice = 15 ,  LastSupplyDate = null, Groups = new List<ProductGroupModel>{ } },
                        new ProductBaseModel{ ID = 2, Name = "Ручка", StockAmount = 100, MeasureUnitName = "шт.", WholesalePrice = 15,
                            RetailPrice = 50 ,  LastSupplyDate = null,
                            Groups = new List<ProductGroupModel>{ } },
                        new ProductBaseModel{ID = 3, Name = "Карандаш", StockAmount = 50,   MeasureUnitName = "шт.",
                            WholesalePrice = 40, RetailPrice = 50 ,  LastSupplyDate = null,
                            Groups = new List<ProductGroupModel>{ } }                        
                    }
            };

            yield return new object[]
            {
                    new List<ProductDTO>{},
                    new List<ProductBaseModel>{ }
            };
        }
    }

    public class MapProductDTOToProductModelSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new List<ProductModel>() { ProductModelMock.models[0] }, new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[0] } };
            yield return new object[] { new List<ProductModel>() { ProductModelMock.models[1] }, new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[1] } };
            yield return new object[] { new List<ProductModel>() { ProductModelMock.models[2] }, new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[2] } };
            yield return new object[] { new List<ProductModel>() { ProductModelMock.models[3] }, new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[3] } };
            yield return new object[] { new List<ProductModel>(), new List<ProductDTO>() };

        }
    }

    public class GetAllProductsByAllParamsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "input", 1, 20, 50, 100, 300, 200, 400, DateTimeMock.DateTimes[0], DateTimeMock.MaxDataTimes[0],
                 new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[0] }, new List<ProductBaseModel>() { ProductBaseModelMock.Models[0]} };
            yield return new object[] { "inputs", 5, 21, 50, 105, 320, 200, 4, DateTimeMock.DateTimes[1], DateTimeMock.MaxDataTimes[1],
                 new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[1] }, new List<ProductBaseModel>() { ProductBaseModelMock.Models[1]} };
            yield return new object[] { "inputtt", 3, 12, 55, 100, 300, 250, 40, DateTimeMock.DateTimes[2], DateTimeMock.MaxDataTimes[2],
                 new List<ProductDTO>() { ProductsDTOMock.DTOsFromDB[2] }, new List<ProductBaseModel>() { ProductBaseModelMock.Models[2]} };
        }
    }
}
