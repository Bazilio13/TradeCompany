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
        PotentialClientsDataAccess _dataAcces = new PotentialClientsDataAccess();
        Page _priviosPage;
        UINavi _uiNavi;
        public PotentialClients(List<int> ids, Page priviosPage)
        {
            InitializeComponent();
            _priviosPage = priviosPage;
            _uiNavi = UINavi.GetUINavi();
            List<PotentialClientModel> clients = _dataAcces.GetPotentialClientsByProductsIDs(ids);
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
    }
}
