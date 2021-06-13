using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.Mocks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests.SupplysMapsSourse
{
    public class MapsSupplyListModelsToSupplyListDTOs_Sourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new List<SupplyListModel>() { SupplyListModelMock.Models[0] }, 1, new List<SupplyListDTO>() { SupplyListDTOMock.DTOsToDB[0] } };
            yield return new object[] { new List<SupplyListModel>() { SupplyListModelMock.Models[1] }, 1, new List<SupplyListDTO>() { SupplyListDTOMock.DTOsToDB[1] } };
            yield return new object[] { new List<SupplyListModel>() { SupplyListModelMock.Models[2] }, 2, new List<SupplyListDTO>() { SupplyListDTOMock.DTOsToDB[2] } };
        }
    }
}
