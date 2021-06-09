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
        private ProductModel _currentProduct = new ProductModel();
        private ProductGroupModel _newGroup = new ProductGroupModel();
        //private List<int> _chosenGroupsIDs = new List<int>();
        private List<ProductGroupModel> _chosenGroups = new List<ProductGroupModel>();
        private List<ProductGroupModel> _allGroups;
        private Frame _frame;
        private int _currentProductID;
        private int _measureUnitID;
        private UINavi _uiNavi;
        private Page _priviosPage;
        private int _id;

        public AddNewProduct(Page priviosPage)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _priviosPage = priviosPage;
            _currentProductID = GetCurrentProductID();
            Button_Delete.IsEnabled = false;
            Button_Save.IsEnabled = false;
        }

        public AddNewProduct(int id, Frame frame, Page priviosPage, Window mainWindow)
        {
            InitializeComponent();
            _id = id;
            _frame = frame;
            _mainWindow = mainWindow;
            _priviosPage = priviosPage;
            _currentProduct = _productsData.GetProductByID(_id);
            _currentProductID = _id;
            PageTitle.Text = "Информация о товаре";
            Button_Save.Content = "Изменить";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MeasureUnit.ItemsSource = _productsData.GetAllMeasureUnits();
            MeasureUnit.DisplayMemberPath = "Name";
            RefreshGroupsCombobox();
            if (_id == 0)
            {
                ID_Text.Text = _currentProductID.ToString();
                CreationDate.Text = DateTime.Now.ToString();
            }
            else
            {
                ID_Text.Text = _id.ToString();
                CreationDate.Text = _currentProduct.LastSupplyDate.ToString();
                MeasureUnit.Text = _currentProduct.MeasureUnitName;
                Name_Text.Text = _currentProduct.Name;
                ChosenCategories.Text = "";
                foreach (ProductGroupModel group in _currentProduct.Groups)
                {
                    ChosenCategories.Text += group.Name + " / ";
                }
                Text_RetailPrice.Text = _currentProduct.RetailPrice.ToString();
                Text_WholesalePrice.Text = _currentProduct.RetailPrice.ToString();
                Text_StockAmount.Text = _currentProduct.StockAmount.ToString();
                Text_Description.Text = _currentProduct.Description;
                Text_Comments.Text = _currentProduct.Comments;
                foreach (ProductGroupModel group in _currentProduct.Groups)
                {
                    _chosenGroups.Add(group);
                }
            }
            PositionCursor();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            MeasureUnitsModel selectedItem = (MeasureUnitsModel)MeasureUnit.SelectedItem;
            _measureUnitID = selectedItem.ID;
            _currentProduct.Name = Name_Text.Text;
            _currentProduct.StockAmount = (float)Convert.ToDouble(Text_StockAmount.Text);
            _currentProduct.MeasureUnit = _measureUnitID;
            _currentProduct.RetailPrice = (float)Convert.ToDouble(Text_RetailPrice.Text);
            _currentProduct.WholesalePrice = (float)Convert.ToDouble(Text_WholesalePrice.Text);
            _currentProduct.Description = Text_Description.Text;
            _currentProduct.Comments = Text_Comments.Text;
            if (_id == 0)
            {
                _currentProduct.LastSupplyDate = DateTime.Now;
                _productsData.AddNewProduct(_currentProduct);
            }
            else
            {
                //удалить все группы из товара
                foreach(ProductGroupModel group in _currentProduct.Groups)
                {
                    _productsData.DeleteGroupFromProduct(_currentProduct.ID, group.ID);
                }
                _productsData.UpdateProductByID(_currentProduct);
            }

            foreach (ProductGroupModel group in _chosenGroups)
            {
                _productsData.AddProductToProductGroup(_currentProductID, group.ID);
            }


            _frame.Content = _priviosPage;
            ProductCatalog prodCatalog = (ProductCatalog)_priviosPage;
            prodCatalog.ApplyFilters();
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
            if(_id != 0)
            {
                _frame.Content = _priviosPage;
                return;
            }
            if (Name_Text.Text != "" || Text_RetailPrice.Text != "" || Text_WholesalePrice.Text != ""
                || Text_StockAmount.Text != "" || ChosenCategories.Text != "Не выбрано" || MeasureUnit.Text != ""
                || Text_Description.Text != "" || Text_Comments.Text != "")
            {
                if (MessageBox.Show("Отменить изменения?",
                        "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _frame.Content = _priviosPage;
                }
            }
            else
            {
                _frame.Content = _priviosPage;
            }
        }

        private void MeasureUnit_DropDownClosed(object sender, EventArgs e)
        {
            MeasureUnitsModel selectedItem = (MeasureUnitsModel)MeasureUnit.SelectedItem;
            if(!(selectedItem is null))
            {
                _measureUnitID = selectedItem.ID;
            }
            EnableSaveButton();
        }

        private void ChangeCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_chosenGroups.Count > 0)
            {
                ChangeSelectedCategories changeCtaegoriesWindow = new ChangeSelectedCategories(_chosenGroups, ChosenCategories);
                //вынести в само окно 
                changeCtaegoriesWindow.Owner = _mainWindow;
                changeCtaegoriesWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (changeCtaegoriesWindow.ShowDialog() == true)
                {
                    changeCtaegoriesWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной категории", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            EnableSaveButton();
        }

        private void CreateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewCategoryWindow addNewCategoryWindow = new AddNewCategoryWindow();
            //вынести в само окно
            addNewCategoryWindow.Owner = _mainWindow;
            addNewCategoryWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (addNewCategoryWindow.ShowDialog() == true)
            {
                _newGroup.Name = addNewCategoryWindow.NewCategoryName;
                _productsData.AddNewProductGroup(_newGroup);
                RefreshGroupsCombobox();
                addNewCategoryWindow.Close();
            }
        }

        private void Text_Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(DescriptionLimit, Text_Description, e, 500);
        }

        private void Text_Comments_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(CommentsLimit, Text_Comments, e, 500);
        }


        private void Category_DropDownClosed(object sender, EventArgs e)
        {
            ProductGroupModel selectedItem = (ProductGroupModel)Category.SelectedItem;
            if (!(selectedItem is null))
            {
                if (ChosenCategories.Text.Contains(selectedItem.Name))
                {
                    MessageBox.Show($"Категория \"{selectedItem.Name}\" уже выбрана", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Category.Text = "";
                    return;
                }
                if (ChosenCategories.Text == "Не выбрано")
                {
                    ChosenCategories.Text = "";
                }
                ChosenCategories.Text += Category.Text + " / ";
                Category.Text = "";

                _chosenGroups.Add(selectedItem);
                //_chosenGroupsIDs.Add(selectedItem.ID);
                EnableSaveButton();
            }
        }


        private void PositionCursor()
        {
            Name_Text.Select(Name_Text.Text.Length, 0);
            Text_StockAmount.Select(Text_StockAmount.Text.Length, 0);
            Text_RetailPrice.Select(Text_StockAmount.Text.Length, 0);
            Text_WholesalePrice.Select(Text_StockAmount.Text.Length, 0);
            Text_Description.Select(Text_StockAmount.Text.Length, 0);
            Text_Comments.Select(Text_StockAmount.Text.Length, 0);
        }

        private void TextBoxLengthCheck(TextBlock textBlock, TextBox textBox, TextChangedEventArgs e, int limit)
        {
            textBlock.Text = (limit - textBox.Text.Length).ToString();
            if (textBox.Text.Length >= limit)
            {
                MessageBox.Show("Введено аксимальное число символов", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshGroupsCombobox()
        {
            _allGroups = _productsData.GetAllGroups();
            Category.ItemsSource = _allGroups;
            Category.DisplayMemberPath = "Name";
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
                    MessageBox.Show("Неверный ввод", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //рефактор вместе с cancel button
        private bool CheckingFieldsForData()
        {
            bool IsValid = true;
            if (Name_Text.Text == "" || Text_RetailPrice.Text == "" || Text_WholesalePrice.Text == ""
                || Text_StockAmount.Text == "" || ChosenCategories.Text == "Не выбрано" 
                || MeasureUnit.Text == "")
            {
                IsValid = false;
            }
            return IsValid;
        }

        public void EnableSaveButton()
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

        private int GetCurrentProductID()
        {
            int lastProductInDBCount = _productsData.GetAllProducts().Count - 1;
            ProductBaseModel lastProductInDB = _productsData.GetAllProducts()[lastProductInDBCount];
            int currentProductID = lastProductInDB.ID + 1;
            return currentProductID;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция удаления в разработке");
        }
    }
}
