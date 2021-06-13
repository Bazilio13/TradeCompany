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
using TradeCompany_BLL.Interfaces;
using TradeCompany_BLL.Models;
using TradeCompany_UI.TableElements;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for PotentialClients.xaml
    /// </summary>
    public partial class PotentialClients : Page
    {
        private PotentialClientsDataAccess _dataAcces = new PotentialClientsDataAccess();
        private ClientsDataAccess _clientsDataAccess = new ClientsDataAccess();
        private Page _priviosPage;
        private UINavi _uiNavi;
        private List<int> _ids;
        public PotentialClients(List<int> ids, Page priviosPage)
        {
            InitializeComponent();
            _priviosPage = priviosPage;
            _uiNavi = UINavi.GetUINavi();
            _ids = ids;
            ShowPotentialClients();
        }
        public PotentialClients(int id, Page priviosPage)
        {
            InitializeComponent();
            _priviosPage = priviosPage;
            _uiNavi = UINavi.GetUINavi();
            _ids = new List<int> { id };
            ShowPotentialClients();
        }

        private void ShowPotentialClients()
        {
            string clientSearch;
            if (ClientSearch.Text == "")
            {
                clientSearch = null;
            }
            else
            {
                clientSearch = ClientSearch.Text;
            }
            List<PotentialClientModel> clients = _dataAcces.GetPotentialClientsByProductsIDs(_ids, clientSearch);
            if (clients.Count > 0)
            {
                List<IRowItem> items = new List<IRowItem>();
                foreach (PotentialClientModel model in clients)
                {
                    items.Add(model);
                }
                Panel.Children.Add(new CustomTable(items));
            }
            else
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Не удалось подобрать потенциальных клиентов";
                Panel.Children.Add(textBlock);
            }
        }

        private void ViewPotentialClients(List<PotentialClientModel> pClients)
        {
            Button but = new Button();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(_priviosPage);
        }

        private void ClientSearch_TextChange(object sender, TextChangedEventArgs e)
        {
            Panel.Children.Clear();
            ShowPotentialClients();
        }
    }
}
