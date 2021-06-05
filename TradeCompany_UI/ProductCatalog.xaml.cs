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
    /// Interaction logic for ProductCatalog.xaml
    /// </summary>
    public partial class ProductCatalog : Page
    {
        private ProductsDataAccess _products = new ProductsDataAccess();
        private string _filtrByText;
        private int? _filtrByGategory;
        private float? _filtrFromStockAmount;
        private float? _filtrToStockAmount;
        private float? _filtrFromWholesalePrice;
        private float? _filtrToWholesalePrice;
        private float? _filtrFromRetailPrice;
        private float? _filtrToRetailPrice;
        private DateTime? _filtrMinDateTime;
        private DateTime? _filtrMaxDateTime;
        Regex _regexForNumbers = new Regex(@"[^0-9.]+");

        public ProductCatalog()
        {
            InitializeComponent();
            dgProductCatalog.ItemsSource = _products.GetAllProducts();

            List<ProductGroupModel> productGroupName = _products.GetAllGroups();
            ProductGroupSelect.Items.Add("Категория");
            for (int i = 0; i < productGroupName.Count; i++)
            {
                ProductGroupSelect.Items.Add(productGroupName[i].Name);
            }
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textChange(object sender, TextChangedEventArgs e)
        {
            if (ProductSearch.Text == "")
            {
                _filtrByText = null;
                dgProductCatalog.ItemsSource = _products.GetAllProductsByAllParams(_filtrByText, _filtrByGategory, _filtrFromStockAmount, _filtrToStockAmount, _filtrFromWholesalePrice, _filtrToWholesalePrice, _filtrFromRetailPrice, _filtrToRetailPrice, _filtrMinDateTime, _filtrMaxDateTime);
            }
            else
            {
                _filtrByText = ProductSearch.Text;
                dgProductCatalog.ItemsSource = _products.GetAllProductsByAllParams(_filtrByText, _filtrByGategory, _filtrFromStockAmount, _filtrToStockAmount, _filtrFromWholesalePrice, _filtrToWholesalePrice, _filtrFromRetailPrice, _filtrToRetailPrice, _filtrMinDateTime, _filtrMaxDateTime);
            }
        }

        //private void selectionChanged(object sender, RoutedEventArgs e)
        //{

        //}

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            dgProductCatalog.ItemsSource = _products.GetAllProductsByAllParams(_filtrByText, _filtrByGategory, _filtrFromStockAmount, _filtrToStockAmount, _filtrFromWholesalePrice, _filtrToWholesalePrice, _filtrFromRetailPrice, _filtrToRetailPrice, _filtrMinDateTime, _filtrMaxDateTime);
        }


        private void ProductGroupSelect_DropDownClosed(object sender, EventArgs e)
        {
            if (ProductGroupSelect.Text == "Категория")
            {
                _filtrByGategory = null;
            }
            else
            {
                List<ProductGroupModel> productsOfGroup = _products.GetAllGroups();
                for (int i = 0; i < productsOfGroup.Count; i++)
                {
                    if (productsOfGroup[i].Name == ProductGroupSelect.Text)
                    {
                        _filtrByGategory = productsOfGroup[i].ID;
                    }
                }
            }
        }

        private void FromStockAmount_TextChange(object sender, TextChangedEventArgs e)
        {
            _filtrFromStockAmount = InputValidation(_filtrFromStockAmount, FromStockAmount);    
        }

        private void ToStockAmount_TextChange(object sender, TextChangedEventArgs e)
        {
            _filtrToStockAmount = InputValidation(_filtrToStockAmount, ToStockAmount);
        }



        private float? InputValidation(float? filtr, TextBox textbox)
        {
            textbox.Text = Regex.Replace(textbox.Text, @"[.]+", ",");
            textbox.Text = Regex.Replace(textbox.Text, @"[^0-9,.]+", "");
            textbox.SelectionStart = textbox.Text.Length;
            if (textbox.Text == "")
            {
                filtr = null;
            }
            else
            {
                try
                {
                    filtr = (float)Convert.ToDouble(textbox.Text);
                }
                catch (FormatException ex)
                {
                    textbox.Text = "";
                    MessageBox.Show("Неверный ввод");
                }
            }

            return filtr;
        }

        
    }
}
