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
    public class MapOrderListsDTOToOrderListModel_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new List<OrderListsDTO> { OrderListDTOMock.dTOsFromDB[0], OrderListDTOMock.dTOsFromDB[1] },
                                        new List<OrderListModel> { OrderListModelMock.Models[0], OrderListModelMock.Models[1] } };            
            
            yield return new object[] { new List<OrderListsDTO> { OrderListDTOMock.dTOsFromDB[2], OrderListDTOMock.dTOsFromDB[3] },
                                        new List<OrderListModel> { OrderListModelMock.Models[2], OrderListModelMock.Models[3] } };
            
            yield return new object[] { new List<OrderListsDTO> { OrderListDTOMock.dTOsFromDB[4] },
                                        new List<OrderListModel> { OrderListModelMock.Models[4]} };
        }
    }
}
