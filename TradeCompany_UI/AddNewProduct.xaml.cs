using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Page
    {
        private ProductsDataAccess _products = new ProductsDataAccess();
        private ProductModel _product = new ProductModel();
        public AddNewProduct()
        {
            InitializeComponent();
            
        }

        private void Name_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Name_Text.Clear();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            _product.Name = Name_Text.Text;
            _product.RetailPrice = 100;
            _product.WholesalePrice = 500;
            _product.StockAmount = 20;
            _product.MeasureUnit = 1;
            _product.Comments = "top";
            _product.LastSupplyDate = DateTime.Now;
            _products.AddNewProduct(_product);
        }

        private void Name_Text_TextInput(object sender, TextCompositionEventArgs e)
        {
            Name_Text.Clear();
        }
    }
}
