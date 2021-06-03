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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            MapsDTOtoModel map = new MapsDTOtoModel();
            dgClientsTable.ItemsSource = map.MapClientDTOToClientBaseModelList();
        }

        private void dgAllClientsTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void textInput(object sender, TextCompositionEventArgs e)
        {
            MapsDTOtoModel map = new MapsDTOtoModel();
            if (ClientFiltr.Text == "")
            {
                dgClientsTable.ItemsSource = map.MapClientDTOToClientBaseModelList();

            }
            else
            {
                dgClientsTable.ItemsSource = map.MapClientDTOToClientBaseModelListByName(ClientFiltr.Text + e.Text);
            }
        }


        private void ClientsFiltr(object sender, RoutedEventArgs e)
        {
            DateTime minDate = MinDate.DisplayDate;
            DateTime maxDate = MaxDate.DisplayDate;
            bool? ChechF = CheckBoxF.IsChecked;
            bool? ChechU = CheckBoxU.IsChecked;
            bool? ChechOpt = CheckBoxOpt.IsChecked;
            bool? ChechRoz = CheckBoxRetail.IsChecked;
            if (minDate < maxDate)
            {
                ChechRoz = CheckBoxRetail.IsChecked;
            }
            if (minDate > maxDate)
            {
                ChechRoz = CheckBoxRetail.IsChecked;
            }

        }
    }
}
