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
    /// Interaction logic for StatisticsByClients.xaml
    /// </summary>
    public partial class StatisticsByClients : Page
    {
        private UINavi _uiNavi;
        private ClientsDataAccess _clientsData;
        private Page _priviosPage;
        private FilterGroupModel _filter;
        private ProductsDataAccess _products;

        public StatisticsByClients(Page priviosPage)
        {
            InitializeComponent();
            _priviosPage = priviosPage;
            _uiNavi = UINavi.GetUINavi();
            _clientsData = new ClientsDataAccess();
            _filter = new FilterGroupModel();
            _products = new ProductsDataAccess();
            dgClientsStat.ItemsSource = _clientsData.GetClientsStatistics();
            ProductGroupSelect.Text = "Выбор категории";
            ProductGroupSelect.ItemsSource = _products.GetAllGroups();
            ProductGroupSelect.DisplayMemberPath = "Name";
            ProductGroupSelect.Text = "Выбор категории";
        }

        private void StatisticsByProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
        }


        private void SetUpFilters()
        {
            _filter.FromOrdersCount = ConvertStringToInt(FromOrdersAmount.Text);
            _filter.ToOrdersCount = ConvertStringToInt(ToOrdersAmount.Text);
            _filter.MinAmount = ValidateInput(FromPrice);
            _filter.MaxAmount = ValidateInput(ToPrice);
            _filter.MaxDateOrder = CorrectMaxDate(DateUntilForOrder.SelectedDate);
            _filter.MinDateOrder = DateFromForOrder.SelectedDate;
            _filter.PeriodFor = DateFromForSupply.SelectedDate;
            _filter.PeriodUntil = DateUntilForSupply.SelectedDate;

        }


        private void OrdersAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Sum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FilterTextInput(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Regex.Replace(tb.Text, @"[.]+", ",");
            tb.SelectionStart = tb.Text.Length;
            ApplyFilters();
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            _filter.Null();
            FromOrdersAmount.Text = "";
            ToOrdersAmount.Text = "";
            FromPrice.Text = "";
            ToPrice.Text = "";
            DateUntilForOrder.SelectedDate = null;
            DateFromForOrder.SelectedDate = null;
            RadioButtonWholesalePrice.IsChecked = false;
            RadioButtonRetailPrice.IsChecked = false;
            NullifyPeriodCalendars();
            ProductGroupSelect.Text = "Выбор категории";
            ProductGroupSelect.SelectedItem = null;
            ApplyFilters();
            ButtonPicked(sender);
        }

        private void ApplyFilters()
        {
            SetUpFilters();
            ProductGroupModel item = (ProductGroupModel)ProductGroupSelect.SelectedItem;
            if (item is null)
            {
                _filter.ID = null;
                dgClientsStat.ItemsSource = _clientsData.GetClientsStatisticsByParams(_filter);
            }
            else
            {
                _filter.ID = item.ID;
                dgClientsStat.ItemsSource = _clientsData.GetClientsStatisticsByProductGroups(_filter);
            }
        }

        private float? ValidateInput(TextBox tb)
        {
            float? filtr;
            try
            {
                filtr = ConvertStringToFloat(tb.Text);
            }
            catch
            {
                filtr = null;
                tb.Text = "";
                MessageBox.Show("Неверный ввод");
            }
            return filtr;
        }

        private float? ConvertStringToFloat(string str)
        {
            if (str == "" || str == null)
            {
                return null;
            }
            else
            {
                return (float)Convert.ToDouble(str);
            }

        }

        private int? ConvertStringToInt(string str)
        {
            if (str == "" || str == null)
            {
                return null;
            }
            else
            {
                return (int)Convert.ToInt32(str);
            }
        }

        private void RadioButtonWholesalePrice_Checked(object sender, RoutedEventArgs e)
        {
            _filter.Type = 0;
            ApplyFilters();
        }

        private void RadioButtonRetailPrice_Checked(object sender, RoutedEventArgs e)
        {
            _filter.Type = 1;
            ApplyFilters();
        }


        private DateTime? CorrectMaxDate(DateTime? date)
        {
            DateTime? correctDate = null;
            if (date != null)
            {
                DateTime timeTmp = (DateTime)date;
                timeTmp = timeTmp.AddDays(1);
                timeTmp = timeTmp.AddMilliseconds(-2);
                correctDate = (DateTime?)timeTmp;
            }
            return correctDate;
        }

        private void LastOrderDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateFromForOrder.SelectedDate > DateUntilForOrder.SelectedDate)
            {
                DateFromForOrder.SelectedDate = null;
                DateUntilForOrder.SelectedDate = null;
                MessageBox.Show("Неверный выбор даты");
            }
            ApplyFilters();
        }

        private void Period_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateFromForSupply.SelectedDate > DateUntilForSupply.SelectedDate)
            {
                DateFromForSupply.SelectedDate = null;
                DateUntilForSupply.SelectedDate = null;
                MessageBox.Show("Неверный выбор даты");
            }
            ApplyFilters();
            ButtonPicked(sender);
        }

        private void ButtonDate(int date)
        {
            _filter.PeriodFor = ChangeDateTime(date);
            DateFromForSupply.SelectedDate = _filter.PeriodFor;

            _filter.PeriodUntil = CorrectMaxDate(DateTime.Today);
            if (date == 1)
            {
                _filter.PeriodUntil = CorrectMaxDate(ChangeDateTime(date));
            }

            DateUntilForSupply.SelectedDate = _filter.PeriodUntil;
            ApplyFilters();  
        }

        private DateTime? ChangeDateTime(int time)
        {
            DateTime timeTmp = DateTime.Today;
            timeTmp = timeTmp.AddDays(-time);
            DateTime? correctDate = (DateTime?)timeTmp;
            return correctDate;
        }

        private void OneYearButtonClick(object sender, RoutedEventArgs e)
        {
            NullifyPeriodCalendars();
            ButtonDate(365);
            ButtonPicked(sender);
        }

        private void HalfYearButtonClick(object sender, RoutedEventArgs e)
        {
            NullifyPeriodCalendars();
            ButtonDate(182);
            ButtonPicked(sender);
        }

        private void MonthButtonClick(object sender, RoutedEventArgs e)
        {
            NullifyPeriodCalendars();
            ButtonDate(31);
            ButtonPicked(sender);
        }

        private void YesterdayButtonClick(object sender, RoutedEventArgs e)
        {
            NullifyPeriodCalendars();
            ButtonDate(1);
            ButtonPicked(sender);
        }

        private void TodayButtonClick(object sender, RoutedEventArgs e)
        {
            NullifyPeriodCalendars();
            ButtonDate(0);
            ButtonPicked(sender);
        }

        private void NullifyPeriodCalendars()
        {
            DateFromForSupply.SelectedDate = null;
            DateUntilForSupply.SelectedDate = null;
        }

        private void ProductGroupSelect_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ProductGroupModel item = (ProductGroupModel)comboBox.SelectedItem;
            if (item != null)
            {
                if(comboBox.Text == "Выбор категории")
                {
                    _filter.ID = null;
                    dgClientsStat.ItemsSource = _clientsData.GetClientsStatisticsByParams(_filter);
                }
                else
                {
                    _filter.ID = item.ID;
                    dgClientsStat.ItemsSource = _clientsData.GetClientsStatisticsByProductGroups(_filter);
                }
                
            }
        }

        private void dgClientsStat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClientsStatisticsModel statModel = (ClientsStatisticsModel)dgClientsStat.SelectedItem;
            if (!(statModel is null))
            {
                _uiNavi.GoToThePage(new OneClient(statModel.ID, this));
            }
        }

        private void ButtonPicked(object sender)
        {
            TodayButton.Style = (Style)TodayButton.FindResource("ResetButtonStyle");
            YesterdayButton.Style = (Style)YesterdayButton.FindResource("ResetButtonStyle");
            MonthButton.Style = (Style)MonthButton.FindResource("ResetButtonStyle");
            HalfYearButton.Style = (Style)HalfYearButton.FindResource("ResetButtonStyle");
            OneYearButton.Style = (Style)OneYearButton.FindResource("ResetButtonStyle");


            if (sender == TodayButton)
            {
                TodayButton.Style = (Style)TodayButton.FindResource("StatButton");
            }
            if (sender == YesterdayButton)
            {
                YesterdayButton.Style = (Style)YesterdayButton.FindResource("StatButton");
            }
            if (sender == MonthButton)
            {
                MonthButton.Style = (Style)MonthButton.FindResource("StatButton");
            }
            if (sender == HalfYearButton)
            {
                HalfYearButton.Style = (Style)HalfYearButton.FindResource("StatButton");
            }
            if (sender == OneYearButton)
            {
                OneYearButton.Style = (Style)OneYearButton.FindResource("StatButton");
            }

        }
    }
}
