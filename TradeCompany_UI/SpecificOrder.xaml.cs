using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradeCompany_BLL;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for SpecificOrder.xaml
    /// </summary>
    public partial class SpecificOrder : Page
    {
        private InformationAboutOrderList informationAboutOrderList;
        private int orderId = 1;
        private BindingList<ProductsForOrderModel> productsInOrder;
        public SpecificOrder()
        {

        }
        public SpecificOrder(int id)
        {
            InitializeComponent();
            //orderId = id;
            //var connectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
            //informationAboutOrderList = new InformationAboutOrderList(connectionString);
        }

        private void dgSpecificOrder_Loaded(object sender, RoutedEventArgs e)
        {
            
            var connectionString = @"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16";
            informationAboutOrderList = new InformationAboutOrderList(connectionString);
            var productsForOrder = informationAboutOrderList.GetProductsForOrderByOrderId(7);
            productsInOrder = new BindingList<ProductsForOrderModel>();
            // либо сделать маппер для ui либо сразу использовать productsForOrder
            foreach (var product in productsForOrder)
            {
                productsInOrder.Add(product);
                
            }

            ClientName.Text = productsForOrder.First().Name;
            dgSpecificOrder.ItemsSource = productsInOrder;
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
