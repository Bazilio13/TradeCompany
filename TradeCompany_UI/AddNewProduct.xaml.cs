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
            if (CheckingFieldsForData())
            {
                _product.Name = Name_Text.Text;
                _product.RetailPrice = (float)Convert.ToDouble(Text_RetailPrice.Text);
                _product.WholesalePrice = (float)Convert.ToDouble(Text_WholesalePrice.Text);
                _product.StockAmount = (float)Convert.ToDouble(Text_StockAmount.Text);
                _product.MeasureUnit = 1;
                _product.Comments = Text_Description.Text;
                _product.LastSupplyDate = DateTime.Now;
                _products.AddNewProduct(_product);
            }
            else
            {
                MessageBox.Show("Вы ввели не все данные");
            }
        }

        private void Name_Text_TextInput(object sender, TextCompositionEventArgs e)
        {
            Name_Text.Clear();
        }

        private bool CheckingFieldsForData()
        {
            if (Name_Text.Text == "Название*" || Name_Text.Text == null)
            {
                return false;
            }

            if (Text_RetailPrice.Text == "Розничная цена*" || Name_Text.Text == null)
            {
                return false;
            }

            if (Text_WholesalePrice.Text == "Оптовая цена*" || Text_WholesalePrice.Text == null)
            {
                return false;
            }

            if (Text_StockAmount.Text == "Количество*" || Text_StockAmount.Text == null)
            {
                return false;
            }

            if (Category.SelectedItem == null)
            {
                return false;
            }

            return true;
        }
    }
}
