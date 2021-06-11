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
    /// Interaction logic for PotentialClients.xaml
    /// </summary>
    public partial class PotentialClients : Page
    {
        PotentialClientsDataAccess _dataAcces = new PotentialClientsDataAccess();
        public PotentialClients()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> ids = new List<int> { 2, 3, 6, 10 };
            List<PotentialClientModel> clients = _dataAcces.GetPotentialClientsByProductsIDs(ids);
        }

        private void ViewPotentialClients(List<PotentialClientModel> pClients)
        {
            //mainPanel.Children.
        }
    }
}
