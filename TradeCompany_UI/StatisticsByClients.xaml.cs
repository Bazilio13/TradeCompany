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

        public StatisticsByClients(Page priviosPage)
        {
            InitializeComponent();
            _priviosPage = priviosPage;
            _uiNavi = UINavi.GetUINavi();
            _clientsData = new ClientsDataAccess();
            dgClientsStat.ItemsSource = _clientsData.GetClientsStatistics();
            ProductGroupSelect.Text = "Выбор категории";
        }

        private void StatisticsByProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
        }
    }
}
