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
    /// Interaction logic for StatisticsByProducts.xaml
    /// </summary>
    public partial class StatisticsByProducts : Page
    {
        private StatisticsDataAccess _dataAccess = new StatisticsDataAccess();

        UINavi _uiNavi;
        public StatisticsByProducts()
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            DGAllGroups.ItemsSource = _dataAccess.GetStatisticsProducts();
            DGProducts.Visibility = Visibility.Collapsed;
            ButtonExit.Visibility = Visibility.Collapsed;
            textBlockLabel.Visibility = Visibility.Collapsed;



        }

        private void DateFromForSupply_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StatisticsByClientsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByClients());
        }

        private void DGCategory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            StatisticsGroupsModel item = (StatisticsGroupsModel)dg.CurrentItem;
            if (item != null)
            {
                int id = item.ID;
                DGProducts.ItemsSource = _dataAccess.GetStatisticsProductsByGroupID(id);
                DGAllGroups.Visibility = Visibility.Collapsed;
                DGProducts.Visibility = Visibility.Visible;
                ButtonExit.Visibility = Visibility.Visible;
                textBlockLabel.Visibility = Visibility.Visible;
                textBlockLabel.Text = item.CategoryName;

            }

        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            DGAllGroups.Visibility = Visibility.Visible;
            DGProducts.Visibility = Visibility.Collapsed;
            ButtonExit.Visibility = Visibility.Collapsed;
            textBlockLabel.Visibility = Visibility.Collapsed;
        }
    }
}
