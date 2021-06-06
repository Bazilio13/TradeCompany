using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ProductBaseModel lastProductInDB = _products.GetAllProducts()[_products.GetAllProducts().Count - 1];
            ID_Text.Text = (lastProductInDB.ID + 1).ToString();

            List<ProductGroupModel> productGroupName = _products.GetAllGroups();
            for (int i = 0; i < productGroupName.Count; i++)
            {
                Category.Items.Add(productGroupName[i].Name);
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingFieldsForData())
            {
                _product.Name = Name_Text.Text;
                _product.StockAmount = (float)Convert.ToDouble(Text_StockAmount.Text);
                _product.MeasureUnit = 1; //добавить подтягивание из таблицы MeasureUnit
                _product.RetailPrice = (float)Convert.ToDouble(Text_RetailPrice.Text);
                _product.WholesalePrice = (float)Convert.ToDouble(Text_WholesalePrice.Text);
                _product.Description = Text_Description.Text;
                _product.Comments = Text_Comments.Text;
                _product.LastSupplyDate = DateTime.Now;
                _products.AddNewProduct(_product);
            }
            else
            {
                MessageBox.Show("Вы ввели не все данные");
            }
        }


        private bool CheckingFieldsForData()
        {
            bool IsValid = true;
            if (Name_Text.Text == "")
            {
                Name_Text.Background = Brushes.Pink;
                IsValid = false;
            }

            if (Text_RetailPrice.Text == "")
            {
                Text_RetailPrice.Background = Brushes.Pink;
                IsValid = false;
            }

            if (Text_WholesalePrice.Text == "")
            {
                Text_WholesalePrice.Background = Brushes.Pink;
                IsValid = false;
            }

            if (Text_StockAmount.Text == "")
            {
                Text_StockAmount.Background = Brushes.Pink;
                IsValid = false;
            }
            if (_product.MeasureUnit is null)
            {
                MeasureUnit.Background = Brushes.Pink;
                IsValid = false;
            }
            if (_product.Groups is null)
            {
                Category.Background = Brushes.Pink;
                IsValid = false;
            }
            return IsValid;
        }

        private void Name_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Name_Text.Background == Brushes.Pink)
            {
                Name_Text.Background = Brushes.White;
            }
        }

        private void Text_RetailPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text_RetailPrice.Background == Brushes.Pink)
            {
                Text_RetailPrice.Background = Brushes.White;
            }
            InputValidation(Text_RetailPrice);
        }

        private void Text_WholesalePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text_WholesalePrice.Background == Brushes.Pink)
            {
                Text_WholesalePrice.Background = Brushes.White;
            }
            InputValidation(Text_WholesalePrice);
        }

        private void Text_StockAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text_StockAmount.Background == Brushes.Pink)
            {
                Text_StockAmount.Background = Brushes.White;
            }
            InputValidation(Text_StockAmount);
        }

        private void InputValidation(TextBox textbox)
        {
            textbox.Text = Regex.Replace(textbox.Text, @"[.]+", ",");
            textbox.Text = Regex.Replace(textbox.Text, @"[^0-9,.]+", "");
            textbox.SelectionStart = textbox.Text.Length;
            if(textbox.Text != "")
            {
                try
                {
                    float input = (float)Convert.ToDouble(textbox.Text);
                }
                catch (FormatException ex)
                {
                    textbox.Text = "";
                    MessageBox.Show("Неверный ввод");
                }
            }
        }

        private void Buton_Cancel_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ProductCatalog();
        }

        private void Category_DropDownClosed(object sender, EventArgs e)
        {

        }
    }
}
