using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_BLL.Tests.OrderMapSourse;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Tests
{
    public class OrderMapsTests
    {
        private MapsDTOtoModel _mapsDTOtoModel = new MapsDTOtoModel();
        private MapsModelToDTO _mapsModelToDTO = new MapsModelToDTO();

        [TestCaseSource(typeof(MapOrdersDTOToOrderModel_Sourse))]
        public void MapOrdersDTOToOrderModelTest(List<OrdersDTO> ordersDTO, List<OrderModel> expected)
        {
            List<OrderModel> actual = _mapsDTOtoModel.MapOrdersDTOToOrderModel(ordersDTO);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapOrderListsDTOToOrderListModel_Sourse))]
        public void MapOrderListsDTOToOrderListModelTest(List<OrderListsDTO> orderListsDTOs, List<OrderListModel> expected)
        {
            List<OrderListModel> actual = _mapsDTOtoModel.MapOrderListsDTOToOrderListModel(orderListsDTOs);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapOrderListModelToOrderDTO_Sourse))]
        public void MapOrderListModelToOrderDTOTest(List<OrderListModel> orderListModels, List<OrderListsDTO> expected)
        {
            List<OrderListsDTO> actual = _mapsModelToDTO.MapOrderListModelToOrderDTO(orderListModels);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapOrderModelToOrdersDTO_Sourse))]
        public void MapOrderModelToOrdersDTOTest(OrderModel orderModel, OrdersDTO expected)
        {
            OrdersDTO actual = _mapsModelToDTO.MapOrderModelToOrdersDTO(orderModel);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MapOrderListModelToOrderListDTO_Sourse))]
        public void MapOrderListModelToOrderListDTOTest(List<OrderListModel> orderListModels, List<OrderListsDTO> expected)
        {
            List<OrderListsDTO> actual = _mapsModelToDTO.MapOrderListModelToOrderListDTO(orderListModels);
            Assert.AreEqual(expected, actual);
        }

    }
}
