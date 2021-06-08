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
using TradeCompany_BLL.DataAccess;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for Supplys.xaml
    /// </summary>
    public partial class Supplys : Page
    {
        private Frame _frame;
        private SupplysDataAccess _supplyDataAccess;
        private Page _previosPage;
        private Window _mainWindow;
        public List<SupplyModel> SupplyModels { get; set; }
        public Supplys(Frame frame, Window mainWindow, Page previousPage = null)
        {
            _frame = frame;
            _previosPage = previousPage;
            _mainWindow = mainWindow;
            InitializeComponent();
            _supplyDataAccess = new SupplysDataAccess();
            SupplyModels = _supplyDataAccess.GetSupplyModelsByParams();
            dgSupplys.ItemsSource = SupplyModels;
        }
        public void FilterSupplys()
        {
            string product = null;
            string productGroup = null;
            if (ProductFiltr.Text != "")
            {
                product = ProductFiltr.Text;
            }
            if (ProductGroupFiltr.Text != "")
            {
                productGroup = ProductGroupFiltr.Text;
            }
            DateTime? maxDate = null;

            if (MaxDate.SelectedDate != null)
            {
                DateTime dateTimeTmp = (DateTime)MaxDate.SelectedDate;
                dateTimeTmp = dateTimeTmp.AddDays(1);
                dateTimeTmp = dateTimeTmp.AddMilliseconds(-2);
                maxDate = (DateTime?)dateTimeTmp;
            }
            List<SupplyModel> orderModels = _supplyDataAccess.GetSupplyModelsByParams(MinDate.SelectedDate, maxDate, product, productGroup);
            dgSupplys.ItemsSource = orderModels;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ProductFiltr.Text = null;
            ProductGroupFiltr.Text = null;
            MinDate.SelectedDate = null;
            MaxDate.SelectedDate = null;
            FilterSupplys();
        }

        private void ProductGroupFiltr_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterSupplys();
        }

        private void ProductFiltr_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterSupplys();
        }

        private void MinDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterSupplys();
        }

        private void MaxDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterSupplys();
        }

        private void CreateSupply_Click(object sender, RoutedEventArgs e)
        {
           _frame.Content = new CertainSupply(_frame, _mainWindow, this);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SupplyModels = _supplyDataAccess.SearchSupplyModels(SearchBox.Text);
            dgSupplys.ItemsSource = SupplyModels;
        }

        private void dgSupplys_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void dgSupplys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgSupplys.CurrentItem != null)
            {
                TextBlock textBlock = (TextBlock)e.OriginalSource;
                SupplyModel crntModel = (SupplyModel)textBlock.DataContext;
                _frame.Content = new CertainSupply(_frame, _mainWindow, this, crntModel.ID);
            }
        }
    }
}
