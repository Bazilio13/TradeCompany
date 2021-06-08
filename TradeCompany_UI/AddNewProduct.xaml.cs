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
        private ProductsDataAccess _productsData = new ProductsDataAccess();
        private ProductModel _product = new ProductModel();
        private ProductGroupModel _newGroup = new ProductGroupModel();
        private List<int> _chosenGroupsIDs = new List<int>();
        private List<ProductGroupModel> _chosenGroups = new List<ProductGroupModel>();
        private List<ProductGroupModel> _allGroups;
        private List<MeasureUnitsModel> _allMeasureUnits;
        private int _currentProductID;
        private int _measureUnitID;

        public AddNewProduct()
        {
            InitializeComponent();
            _currentProductID = GetCurrentProductID();

            ID_Text.Text = _currentProductID.ToString();

            RefreshGroupsCombobox();

            _allMeasureUnits = _productsData.GetAllMeasureUnits();
            MeasureUnit.ItemsSource = _allMeasureUnits;
            MeasureUnit.DisplayMemberPath = "Name";

            CreationDate.Text = DateTime.Now.ToString();
            Button_Save.IsEnabled = false;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            _product.Name = Name_Text.Text;
            _product.StockAmount = (float)Convert.ToDouble(Text_StockAmount.Text);
            _product.MeasureUnit = _measureUnitID;
            _product.RetailPrice = (float)Convert.ToDouble(Text_RetailPrice.Text);
            _product.WholesalePrice = (float)Convert.ToDouble(Text_WholesalePrice.Text);
            _product.Description = Text_Description.Text;
            _product.Comments = Text_Comments.Text;
            _product.LastSupplyDate = DateTime.Now;
            _productsData.AddNewProduct(_product);
            foreach (int ID in _chosenGroupsIDs)
            {
                _productsData.AddProductToProductGroup(_currentProductID, ID);
            }

            frame.Content = new ProductCatalog();
        }

        private void Name_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(NameLimit, Name_Text, e, 250);
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
            if (Name_Text.Text != "" || Text_RetailPrice.Text != "" || Text_WholesalePrice.Text != ""
                || Text_StockAmount.Text != "" || ChosenCategories.Text != "Не выбрано" || MeasureUnit.Text != ""
                || Text_Description.Text != "" || Text_Comments.Text != "")
            {
                if (MessageBox.Show("Есть заполненные поля. Отменить?",
                        "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    frame.Content = new ProductCatalog();
                }
            }
            else
            {
                frame.Content = new ProductCatalog();
            }
        }

        private void MeasureUnit_DropDownClosed(object sender, EventArgs e)
        {
            MeasureUnitsModel selectedItem = (MeasureUnitsModel)MeasureUnit.SelectedItem;
            _measureUnitID = selectedItem.ID;
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
            int lastProductInDBCount = _productsData.GetAllProducts().Count - 1;
            ProductBaseModel lastProductInDB = _productsData.GetAllProducts()[lastProductInDBCount];
            int currentProductID = lastProductInDB.ID + 1;
            return currentProductID;
        }

        private void ChangeCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_chosenGroups.Count > 0)
            {
                ChangeSelectedCategories changeCtaegoriesWindow = new ChangeSelectedCategories(_chosenGroups, ChosenCategories);

                if (changeCtaegoriesWindow.ShowDialog() == true)
                {
                    changeCtaegoriesWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной категории");
            }
        }

        private void CreateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewCategoryWindow addNewCategoryWindow = new AddNewCategoryWindow();

            if (addNewCategoryWindow.ShowDialog() == true)
            {
                _newGroup.Name = addNewCategoryWindow.NewCategoryName;
                _productsData.AddNewProductGroup(_newGroup);
                RefreshGroupsCombobox();
                addNewCategoryWindow.Close();
            }
        }

        private void RefreshGroupsCombobox()
        {
            _allGroups = _productsData.GetAllGroups();
            Category.ItemsSource = _allGroups;
            Category.DisplayMemberPath = "Name";
        }

        private void Text_Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(DescriptionLimit, Text_Description, e, 500);
        }

        private void Text_Comments_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(CommentsLimit, Text_Comments, e, 500);
        }

        private void TextBoxLengthCheck(TextBlock textBlock, TextBox textBox, TextChangedEventArgs e, int limit)
        {
            textBlock.Text = (limit - textBox.Text.Length).ToString();
            if (textBox.Text.Length >= limit)
            {
                MessageBox.Show("Введено аксимальное число символов");
            }
        }

        private void Category_DropDownClosed(object sender, EventArgs e)
        {
            ProductGroupModel selectedItem = (ProductGroupModel)Category.SelectedItem;
            if (!(selectedItem is null))
            {
                if (ChosenCategories.Text.Contains(Category.Text))
                {
                    Category.Text = "";
                    MessageBox.Show("Данная категория уже выбрана");
                    return;
                }
                if (ChosenCategories.Text == "Не выбрано")
                {
                    ChosenCategories.Text = "";
                }
                ChosenCategories.Text += Category.Text + " / ";
                Category.Text = "";

                _chosenGroups.Add(selectedItem);
                _chosenGroupsIDs.Add(selectedItem.ID);

                EnableSaveButton();
            }
        }

        

    }
}
