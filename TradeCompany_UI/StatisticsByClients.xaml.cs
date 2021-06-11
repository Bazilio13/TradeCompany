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
    /// Interaction logic for StatisticsByClients.xaml
    /// </summary>
    public partial class StatisticsByClients : Page
    {
        UINavi _uiNavi;

        public StatisticsByClients()
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
        }

        private void StatisticsByProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
        }
    }
}
