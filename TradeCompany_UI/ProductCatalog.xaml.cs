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
    /// Interaction logic for ProductCatalog.xaml
    /// </summary>
    public partial class ProductCatalog : Page
    {
        private ProductsDataAccess _products = new ProductsDataAccess();


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
                dgProductCatalog.ItemsSource = _products.GetAllProducts();
            }
            else
            {
                dgProductCatalog.ItemsSource = _products.GetProductsByLetter(ProductSearch.Text);
            }
        }

        //private void selectionChanged(object sender, RoutedEventArgs e)
        //{

        //}

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ProductGroupSelect_DropDownClosed(object sender, EventArgs e)
        {
            if (ProductGroupSelect.Text == "Категория")
            {
                dgProductCatalog.ItemsSource = _products.GetAllProducts();
            }
            else
            {
                List<ProductGroupModel> productsOfGroup = _products.GetAllGroups();
                for (int i = 0; i < productsOfGroup.Count; i++)
                {
                    if (productsOfGroup[i].Name == ProductGroupSelect.Text)
                    {
                        dgProductCatalog.ItemsSource = productsOfGroup[i].Products;
                    }
                }
            }
        }
    }
}
