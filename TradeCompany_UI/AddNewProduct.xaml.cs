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
        List<int> chosenCategoriesIDs = new List<int>();
        List<ProductGroupModel> allGroups;

        public AddNewProduct()
        {
            InitializeComponent();
            ID_Text.Text = GetCurrentProductID().ToString();

            allGroups = _products.GetAllGroups();
            Category.ItemsSource = allGroups;
            Category.DisplayMemberPath = "Name";

            CreationDate.Text = DateTime.Now.ToString();
            Button_Save.IsEnabled = false;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
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
            foreach(int ID in chosenCategoriesIDs)
            {
                _products.AddProductToProductGroup(GetCurrentProductID() - 1, ID);
            }

            frame.Content = new ProductCatalog();
        }

        private void Name_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void Text_RetailPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputValidation(Text_RetailPrice);

            EnableSaveButton();
        }

        private void Text_WholesalePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputValidation(Text_WholesalePrice);

            EnableSaveButton();
        }

        private void Text_StockAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputValidation(Text_StockAmount);

            EnableSaveButton();
        }


        private void Buton_Cancel_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ProductCatalog();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            //формируем список ID категорий, которые надо присвоить нашему продукту
            ProductGroupModel selectedItem = (ProductGroupModel)Category.SelectedItem;
            chosenCategoriesIDs.Add(selectedItem.ID);

            if (ChosenCategories.Text == "Не выбрано")
            {
                ChosenCategories.Text = "";
            }
            if (ChosenCategories.Text.Contains(Category.Text))
            {
                Category.Text = "";
                MessageBox.Show("Данная категория уже выбрана");
                return;
            }
            ChosenCategories.Text += Category.Text + " / ";
            Category.Text = "";            

            EnableSaveButton();
        }

        private void MeasureUnit_DropDownClosed(object sender, EventArgs e)
        {
            EnableSaveButton();
        }

        private bool CheckingFieldsForData()
        {
            bool IsValid = true;
            if (Name_Text.Text == "")
            {
                IsValid = false;
            }

            if (Text_RetailPrice.Text == "")
            {
                IsValid = false;
            }

            if (Text_WholesalePrice.Text == "")
            {
                IsValid = false;
            }

            if (Text_StockAmount.Text == "")
            {
                IsValid = false;
            }
            if (ChosenCategories.Text == "" || ChosenCategories.Text == "Не выбрано")
            {
                IsValid = false;
            }
            if (MeasureUnit.Text == "")
            {
                IsValid = false;
            }
            return IsValid;
        }

        private void EnableSaveButton()
        {
            if (CheckingFieldsForData())
            {
                Button_Save.IsEnabled = true;
            }
            else
            {
                Button_Save.IsEnabled = false;
            }
        }

        private void InputValidation(TextBox textbox)
        {
            textbox.Text = Regex.Replace(textbox.Text, @"[.]+", ",");
            textbox.Text = Regex.Replace(textbox.Text, @"[^0-9,.]+", "");
            textbox.SelectionStart = textbox.Text.Length;
            if (textbox.Text != "")
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

        private int GetCurrentProductID()
        {
            ProductBaseModel lastProductInDB = _products.GetAllProducts()[_products.GetAllProducts().Count - 1];
            int currentProductID = lastProductInDB.ID + 1;
            return currentProductID;
        }

        
    }
}
