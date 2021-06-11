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
        private ProductsDataAccess _products;
        private FilterGroupModel _filter = new FilterGroupModel();

        UINavi _uiNavi;
        public StatisticsByProducts()
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            DGAllGroups.ItemsSource = _dataAccess.GetStatisticsProducts(_filter);
            DGProducts.Visibility = Visibility.Collapsed;
            ButtonExit.Visibility = Visibility.Collapsed;
            textBlockLabel.Visibility = Visibility.Collapsed;
            _products = new ProductsDataAccess();
            List<ProductGroupModel> allGroups = _products.GetAllGroups();
            ProductGroupSelect.ItemsSource = allGroups;
            ProductGroupSelect.DisplayMemberPath = "Name";
            ProductGroupSelect.Text = "";
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
                SetCategory(item.ID, item.CategoryName);
            }

        }
        public void SetCategory(int id, string name)
        {

            DGProducts.ItemsSource = _dataAccess.GetStatisticsProductsByGroupID(id);
            DGAllGroups.Visibility = Visibility.Collapsed;
            DGProducts.Visibility = Visibility.Visible;
            ButtonExit.Visibility = Visibility.Visible;
            textBlockLabel.Visibility = Visibility.Visible;
            textBlockLabel.Text = name;

        }


        private void ClickExit(object sender, RoutedEventArgs e)
        {
            DGAllGroups.Visibility = Visibility.Visible;
            DGProducts.Visibility = Visibility.Collapsed;
            ButtonExit.Visibility = Visibility.Collapsed;
            textBlockLabel.Visibility = Visibility.Collapsed;
            ProductGroupSelect.Text = "";
        }

        private void ProductGroupSelect_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox dg = (ComboBox)sender;
            ProductGroupModel item = (ProductGroupModel)dg.SelectedItem;
            if (item != null)
            {
                SetCategory(item.ID, item.Name);
            }
        }

        private void clearFilter(object sender, RoutedEventArgs e)
        {
            _filter.Null();
            DGAllGroups.ItemsSource = _dataAccess.GetStatisticsProducts(_filter);
            DateFromForSupply.SelectedDate = null;
            DateUntilForSupply.SelectedDate = null;
            DateFromForOrder.SelectedDate = null;
            DateUntilForOrder.SelectedDate = null;
            FromOrdersAmount.Text = "";
            ToOrdersAmount.Text = "";
            FromPrice.Text = "";
            ToPrice.Text = "";
        }

        private void GroupFilter(object sender, RoutedEventArgs e)
        {
            _filter.MinDateSupply = DateFromForSupply.SelectedDate;
            _filter.MaxDateSupply = CorrectMaxDate(DateUntilForSupply.SelectedDate); 
            _filter.MinDateOrder = DateFromForOrder.SelectedDate;
            _filter.MaxDateOrder = CorrectMaxDate(DateUntilForOrder.SelectedDate);
            _filter.MinAmount = ConvertStringToFloat(FromOrdersAmount.Text);
            _filter.MaxAmount = ConvertStringToFloat(ToOrdersAmount.Text);     
            _filter.MinSum = ConvertStringToFloat(FromPrice.Text);
            _filter.MaxSum = ConvertStringToFloat(ToPrice.Text);
            DGAllGroups.ItemsSource = _dataAccess.GetStatisticsProducts(_filter);
        }

        private float? ConvertStringToFloat(string str)
        {
            if(str == "" || str == null)
            {
                return null;
            }
            else
            {
                return (float?)Convert.ToDouble(str);
            }
        }
        private void ValidationByNumber(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private DateTime? CorrectMaxDate(DateTime? date)
        {
            DateTime? correctDate = null;
            if (date != null)
            {
                DateTime timeTmp = (DateTime)date;
                timeTmp = timeTmp.AddDays(1);
                timeTmp = timeTmp.AddMilliseconds(-1);
                correctDate = (DateTime?)timeTmp;
            }
            return correctDate;
        }


    }

}
