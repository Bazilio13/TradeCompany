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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UINavi _uiNavi;
        public MainWindow()
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _uiNavi.MainWindow = this;
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Orders());
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StartPage());
        }
        

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Clients());
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new ProductCatalog());
        }

        private void SupplysButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Supplys());
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
        }
    }
}
