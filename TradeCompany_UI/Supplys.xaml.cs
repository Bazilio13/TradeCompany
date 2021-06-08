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
        Frame _frame;
        SupplysDataAccess _supplyDataAccess;
        List<SupplyModel> _supplyModels;
        public Supplys(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
            _supplyDataAccess = new SupplysDataAccess();
            _supplyModels = _supplyDataAccess.GetSupplyModelsByParams();
            dgSupplys.ItemsSource = _supplyModels;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ProductFiltr.Text = null;
            ProductGroupFiltr.Text = null;
            MinDate.SelectedDate = null;
            MaxDate.SelectedDate = null;
            FilterSupplys();
        }
        private void FilterSupplys()
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
            _frame.Content = new CertainSupply(_frame);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _supplyModels = _supplyDataAccess.SearchSupplyModels(SearchBox.Text);
            dgSupplys.ItemsSource = _supplyModels;
        }

        private void dgSupplys_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dgSupplys.CurrentItem != null)
            {
                SupplyModel crntModel = (SupplyModel)dgSupplys.CurrentItem;
                _frame.Content = new CertainSupply(_frame, crntModel.ID);
            }
        }
    }
}
