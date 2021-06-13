using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.OrderMapSourse
{
    public class MapOrdersDTOToOrderModel_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new List<OrdersDTO> { OrdersDTOMock.dTOsFromDB[0] }, new List<OrderModel> { OrderModelMock.Models[0] } };
            yield return new object[] { new List<OrdersDTO> { OrdersDTOMock.dTOsFromDB[1], OrdersDTOMock.dTOsFromDB[2] },
                new List<OrderModel> { OrderModelMock.Models[1] , OrderModelMock.Models[2] } };
            yield return new object[] { new List<OrdersDTO> { OrdersDTOMock.dTOsFromDB[3] }, new List<OrderModel> { OrderModelMock.Models[3] } };
        }
    }
}
