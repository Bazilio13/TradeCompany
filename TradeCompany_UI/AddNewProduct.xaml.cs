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
using TradeCompany_UI.DialogWindows;
using TradeCompany_UI.Pop_ups;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Page
    {
        private ProductsDataAccess _productsData = new ProductsDataAccess();
        private ProductModel _currentProduct = new ProductModel();
        private List<ProductBaseModel> _allProducts = new List<ProductBaseModel>();
        private ProductGroupModel _newGroup = new ProductGroupModel();
        private List<ProductGroupModel> _chosenGroups = new List<ProductGroupModel>();
        private List<ProductGroupModel> _allGroups;
        private int _currentProductID;
        private int _measureUnitID;
        private UINavi _uiNavi;
        private Page _priviosPage;
        private int _id;
        private ProductCatalog _prodCatalog;

        public AddNewProduct(Page priviosPage)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _priviosPage = priviosPage;
            _allProducts = _productsData.GetAllProducts();
            _currentProductID = GetCurrentProductID();
            Button_Delete.IsEnabled = false;
            Button_Save.IsEnabled = false;
            DateText.Text = "Дата создания";
        }

        public AddNewProduct(int id, Page priviosPage)
        {
            InitializeComponent();
            _id = id;
            _uiNavi = UINavi.GetUINavi();
            _priviosPage = priviosPage;
            _currentProduct = _productsData.GetProductByID(_id);
            _currentProductID = _id;
            PageTitle.Text = "Информация о товаре";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _prodCatalog = (ProductCatalog)_priviosPage;
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
                Text_WholesalePrice.Text = _currentProduct.WholesalePrice.ToString();
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
            if(!MeasureUnit.Items.Contains(selectedItem))
            {                
                new MessageWindow("Неверно выбрана единица измерения").ShowDialog();
                return;
            }
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
                _productsData.AddNewProduct(_currentProduct);
            }
            else
            {
                //удаление всех группы из товара
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


            _prodCatalog.ApplyFilters();
            _uiNavi.GoToThePage(_priviosPage);
        }



        private void Name_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(NameLimit, Name_Text, e);
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
                _uiNavi.GoToThePage(_priviosPage);
                return;
            }
            if (Name_Text.Text != "" || Text_RetailPrice.Text != "" || Text_WholesalePrice.Text != ""
                || Text_StockAmount.Text != "" || ChosenCategories.Text != "Не выбрано" || MeasureUnit.Text != ""
                || Text_Description.Text != "" || Text_Comments.Text != "")
            {
                ConfirmitionWindow confirmitionWindow = new ConfirmitionWindow("Отменить изменения?");
                if (confirmitionWindow.ShowDialog() == true)
                {
                    _uiNavi.GoToThePage(_priviosPage);
                }                
            }
            else
            {
                _uiNavi.GoToThePage(_priviosPage);
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

                if (changeCtaegoriesWindow.ShowDialog() == true)
                {
                    changeCtaegoriesWindow.Close();
                }
            }
            else
            {
                new MessageWindow("Не выбрано ни одной категории").ShowDialog();
            }
            EnableSaveButton();
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


        private void Text_Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(DescriptionLimit, Text_Description, e);
        }

        private void Text_Comments_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLengthCheck(CommentsLimit, Text_Comments, e);
        }


        private void Category_DropDownClosed(object sender, EventArgs e)
        {
            ProductGroupModel selectedItem = (ProductGroupModel)Category.SelectedItem;
            if (!(selectedItem is null))
            {
                if (ChosenCategories.Text.Contains(selectedItem.Name))
                {                    
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

        private void TextBoxLengthCheck(TextBlock textBlock, TextBox textBox, TextChangedEventArgs e)
        {
            textBlock.Text = (textBox.MaxLength - textBox.Text.Length).ToString();
            ErrorMessageBox(textBox);
        }

        private void ErrorMessageBox(TextBox textBox)
        {
            if (textBox.Text.Length >= textBox.MaxLength)
            {
                new MessageWindow("Введено максимальное число символов").ShowDialog();
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
            textbox.Text = Regex.Replace(textbox.Text, @"[^0-9,.-]+", "");
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
                    new MessageWindow("Неверный ввод").ShowDialog();
                }
            }
        }


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
            int currentProductID = _productsData.GetLastProductID() + 1;
            return currentProductID;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmitionWindow confirmitionWindow = new ConfirmitionWindow("Удалить из каталога?");
            if (confirmitionWindow.ShowDialog() == true)
            {
                try
                {
                    _productsData.HardDeleteProductByID(_currentProductID);
                }
                catch (Exception)
                {
                    _productsData.SoftDeleteProductByID(_currentProductID);
                }
                new MessageWindow("Товар удален").ShowDialog();
                _prodCatalog.ApplyFilters();
                _uiNavi.GoToThePage(_priviosPage);
            }
        }

        private void Text_RetailPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            ErrorMessageBox(tb);
        }
    }
}
