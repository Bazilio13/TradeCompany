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
using TradeCompany_BLL.Models;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for OneClient.xaml
    /// </summary>
    public partial class OneClient : Page
    {
        int _id;

        public OneClient(int id)
        {
            InitializeComponent();
            _id = id;
        } 

        public OneClient()
        {
            InitializeComponent();
            _id = -1;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(_id != -1)
            {
                MapsDTOtoModel map = new MapsDTOtoModel();
                ClientModel client = map.MapClientDTOToClientModelByID(_id);
                textBoxName.Text = client.Name;
                if (client.INN != null)
                {
                    textBoxINN.Text = client.INN.ToString();
                }
                if (client.Phone != null)
                {
                    textBoxPhone.Text = client.Phone;
                }
                if (client.E_mail != null)
                {
                    textBoxE_mail.Text = client.E_mail;
                }
                if (client.ContactPerson != null)
                {
                    textBoxContactPerson.Text = client.ContactPerson;
                }
                List<AddressModel> addresses = map.MapClientDTOToAddressesModelByID(_id);

            }
            else
            {
                ButtonChange.IsEnabled = false;
                Panel.IsEnabled = true;
            }
        }


        private void ChangeClient(object sender, RoutedEventArgs e)
        {
            Panel.IsEnabled = true;
        }

        private void SaveClient(object sender, RoutedEventArgs e)
        {
            Panel.IsEnabled = false;

        }
    }
}
