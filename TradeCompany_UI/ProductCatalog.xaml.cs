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
using TradeCompany_UI.Interfaces;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for ProductCatalog.xaml
    /// </summary>
    public partial class ProductCatalog : Page
    {
        private ProductsDataAccess _products;
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
        private UINavi _uiNavi;
        private Page _previosPage;

        public ProductCatalog(Page previosPage = null)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _products = new ProductsDataAccess();
            _previosPage = previosPage;
            dgProductCatalog.ItemsSource = _products.GetAllProducts();

            List<ProductGroupModel> allGroups = _products.GetAllGroups();
            ProductGroupSelect.ItemsSource = allGroups;
            ProductGroupSelect.DisplayMemberPath = "Name";
            ProductGroupSelect.Text = "";
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductSearch_TextChange(object sender, TextChangedEventArgs e)
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


        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
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

        private void FromPrice_TextChange(object sender, TextChangedEventArgs e)
        {
            SetUpPriceFilters();
        }

        private void ToPrice_TextChange(object sender, TextChangedEventArgs e)
        {
            SetUpPriceFilters();
        }

        private void RadioButtonRetailPrice_Checked(object sender, RoutedEventArgs e)
        {
            PricesTextBoxesEnabled(true);
            SetUpRetailPrice();
            NullifyWholesalePrices();
        }

        private void RadioButtonWholesalePrice_Checked(object sender, RoutedEventArgs e)
        {
            PricesTextBoxesEnabled(true);
            SetUpWholesalePrice();
            NullifyRetailPrices();
        }

        private void DateFrom_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            CheckDates();
            _filtrMinDateTime = DateFrom.SelectedDate;
        }

        private void DateUntil_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            CheckDates();
            if(!(DateUntil.SelectedDate is null))
            {
                DateTime timeTmp = (DateTime)DateUntil.SelectedDate;
                timeTmp = timeTmp.AddDays(1);
                timeTmp = timeTmp.AddMilliseconds(-1);
                _filtrMaxDateTime = (DateTime?)timeTmp;
            }
            
        }

        private void ResetFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            FromStockAmount.Text = "";
            ToStockAmount.Text = "";
            FromPrice.Text = "";
            ToPrice.Text = "";
            RadioButtonRetailPrice.IsChecked = false;
            RadioButtonWholesalePrice.IsChecked = false;
            PricesTextBoxesEnabled(false);
            ProductSearch.Text = "";
            ProductGroupSelect.Text = "";
            DateFrom.SelectedDate = null;
            DateUntil.SelectedDate = null;
            _filtrByText = null;
            _filtrByGategory = null;
            _filtrFromStockAmount = null;
            _filtrToStockAmount = null;
            _filtrFromWholesalePrice = null;
            _filtrToWholesalePrice = null;
            _filtrFromRetailPrice = null;
            _filtrToRetailPrice = null;
            _filtrMinDateTime = null;
            _filtrMaxDateTime = null;
            dgProductCatalog.ItemsSource = _products.GetAllProducts();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new AddNewProduct(_previosPage));
        }

        private float? InputValidation(float? filtr, TextBox textbox)
        {
            if(textbox != null)
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

            return filtr;
        }  
        private void SetUpPriceFilters()
        {
            if (RadioButtonRetailPrice.IsChecked == true)
            {
                SetUpRetailPrice();
                NullifyWholesalePrices();
            }
            if (RadioButtonWholesalePrice.IsChecked == true)
            {
                SetUpWholesalePrice();
                NullifyRetailPrices();
            }
        }
        private void NullifyWholesalePrices()
        {
            _filtrToWholesalePrice = null;
            _filtrFromWholesalePrice = null;
        }
        private void NullifyRetailPrices()
        {
            _filtrToRetailPrice = null;
            _filtrFromRetailPrice = null;
        }

        private void SetUpWholesalePrice()
        {
            _filtrFromWholesalePrice = InputValidation(_filtrFromWholesalePrice, FromPrice);
            _filtrToWholesalePrice = InputValidation(_filtrToWholesalePrice, ToPrice);
        }

        private void SetUpRetailPrice()
        {
            _filtrFromRetailPrice = InputValidation(_filtrFromRetailPrice, FromPrice);
            _filtrToRetailPrice = InputValidation(_filtrToRetailPrice, ToPrice);
        }

        private void CheckDates()
        {
            if (DateFrom.SelectedDate > DateUntil.SelectedDate)
            {
                DateFrom.SelectedDate = null;
                DateUntil.SelectedDate = null;
                MessageBox.Show("Неверный выбор даты");
            }
        }

        private void PricesTextBoxesEnabled(bool isChecked)
        {
            if (isChecked)
            {
                FromPrice.IsEnabled = true;
                ToPrice.IsEnabled = true;
            }
            else
            {
                FromPrice.IsEnabled = false;
                ToPrice.IsEnabled = false;
            }
        }

        private void dgProductCatalog_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            ProductBaseModel item = (ProductBaseModel)dg.CurrentItem;
            if (item != null)
            {
                int id = item.ID;
                frame.Content = new SelectedProductPage();
                MessageBox.Show("kjdfvh");
            }
        }

        private void dgProductCatalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_previosPage is IProductAddable)
            {
                ProductBaseModel productBaseModel = (ProductBaseModel)dgProductCatalog.SelectedItem;
                IProductAddable productAddable = (IProductAddable)_previosPage;
                productAddable.AddProductToCollection(productBaseModel);
                _uiNavi.GoToThePage(_previosPage);
            }
        }
    }
}
