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
using TradeCompany_UI.Pop_ups;


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
        private List<ProductBaseModel> _crntProduct = null;

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
            ProductGroupSelect.Text = "Выбор категории";
        }

        private void ProductSearch_TextChange(object sender, TextChangedEventArgs e)
        {
            _filtrByText = ProductSearch.Text;
            ApplyFilters();
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
            ApplyFilters();
        }

        private void FromStockAmount_TextChange(object sender, TextChangedEventArgs e)
        {
            _filtrFromStockAmount = InputValidation(_filtrFromStockAmount, FromStockAmount);
            ApplyFilters();
        }

        private void ToStockAmount_TextChange(object sender, TextChangedEventArgs e)
        {
            _filtrToStockAmount = InputValidation(_filtrToStockAmount, ToStockAmount);
            ApplyFilters();
        }

        private void FromPrice_TextChange(object sender, TextChangedEventArgs e)
        {
            SetUpPriceFilters();
            ApplyFilters();
        }

        private void ToPrice_TextChange(object sender, TextChangedEventArgs e)
        {
            SetUpPriceFilters();
            ApplyFilters();
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
            ApplyFilters();
        }

        private void DateUntil_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            CheckDates();
            if(!(DateUntil.SelectedDate is null))
            {
                DateTime timeTmp = (DateTime)DateUntil.SelectedDate;
                timeTmp = timeTmp.AddDays(1);
                timeTmp = timeTmp.AddMilliseconds(-2);
                _filtrMaxDateTime = (DateTime?)timeTmp;
            }
            ApplyFilters();
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
            ProductGroupSelect.Text = "Выбор категории";
            DateFrom.SelectedDate = null;
            DateUntil.SelectedDate = null;
            _filtrByGategory = null;
            dgProductCatalog.ItemsSource = _products.GetAllProducts();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new AddNewProduct(this));
        }

        public void ApplyFilters()
        {
            dgProductCatalog.ItemsSource = _products.GetAllProductsByAllParams(_filtrByText, _filtrByGategory, _filtrFromStockAmount, _filtrToStockAmount, _filtrFromWholesalePrice, _filtrToWholesalePrice, _filtrFromRetailPrice, _filtrToRetailPrice, _filtrMinDateTime, _filtrMaxDateTime);
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
                    catch (Exception)
                    {
                        filtr = null;
                        textbox.Text = "";
                        new MessageWindow("Неверный ввод").ShowDialog();
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
                new MessageWindow("Неверный выбор даты").ShowDialog();                
            }
        }

        private void PricesTextBoxesEnabled(bool isChecked)
        {
            FromPrice.IsEnabled = isChecked;
            ToPrice.IsEnabled = isChecked;
        }


        private void dgProductCatalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductBaseModel productBaseModel = (ProductBaseModel)dgProductCatalog.SelectedItem;
            if (_previosPage is IProductAddable)
            {
                IProductAddable productAddable = (IProductAddable)_previosPage;
                productAddable.AddProductToCollection(productBaseModel);
                _uiNavi.GoToThePage(_previosPage);
            }
            else
            {
                if(!(productBaseModel is null))
                {
                    _uiNavi.GoToThePage(new AddNewProduct(productBaseModel.ID, this));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> ints = new List<int>();
            foreach (object obj in dgProductCatalog.SelectedItems)
            {
                ProductBaseModel product = (ProductBaseModel)obj;
                ints.Add(product.ID);
            }
            if (ints.Count > 0)
            {
                _uiNavi.GoToThePage(new PotentialClients(ints, this));
            }
            else
            {
                new MessageWindow("Не выбрано ни одного товара").ShowDialog();
            }
        }

        private void ProductCatalogPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dgProductCatalog.UnselectAll();
        }

        private void ProductCatalogPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dgProductCatalog.UnselectAll();
        }


        private void LengthCheck_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            ErrorMessageBox(tb);
        }

        private void ErrorMessageBox(TextBox textBox)
        {
            if (textBox.Text.Length >= textBox.MaxLength)
            {
                new MessageWindow("Введено максимальное число символов").ShowDialog();
            }
        }
    }
}
