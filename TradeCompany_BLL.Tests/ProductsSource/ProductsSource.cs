using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.ProductsSource
{
    class ProductsSource
    {
        public class Map_ProductsForOrderDTO_To_ProductsForOrderModelSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new List<ProductForOrderDTO>{
                        ProductID = 1,
                        Name = "Мыло",
                        Amount = 20,
                        Price = 30,
                        MeasureUnit = 5
                        ProductGroupName = "Хоз"
                     },
                    new List<ProductsForOrderModel>{ }
                };

                yield return new object[]
                {

                };

                yield return new object[]
                {

                };
            }
        }

    }
}
