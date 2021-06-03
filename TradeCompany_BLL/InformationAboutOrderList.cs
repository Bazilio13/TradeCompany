using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;

namespace TradeCompany_BLL
{
    public class InformationAboutOrderList
    {
        private MapsDTOtoModel mapsDTOtoModel;
        private OrdersData ordersData;

        public InformationAboutOrderList(string connectionString)
        {
            mapsDTOtoModel = new MapsDTOtoModel();
            ordersData = new OrdersData(connectionString);
        }

        public void createOrderList()
        {          
            //_order = mapsDTOtoModel.GetOrderById(7);
        }

        public List<ProductsForOrderModel> GetProductsForOrderByOrderId(int id)
        {
            var productsForOrderDTO = ordersData.GetProductsByOrderId(id);
            var productsForOrderModel = mapsDTOtoModel.Map_ProductsForOrderDTO_To_ProductsForOrderModel(productsForOrderDTO);
            // ProductsForOrderModel в bll.models
            return productsForOrderModel;
        }
    }
}
