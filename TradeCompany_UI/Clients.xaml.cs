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
            bool? person = null;
            bool? sale = null;
            MapsDTOtoModel map = new MapsDTOtoModel();
            if (CheckBoxF.IsChecked != CheckBoxU.IsChecked)
            {
                if(CheckBoxF.IsChecked == true)
                {
                    person = true;
                }
                else
                {
                    person = false;
                }
            }

            if (CheckBoxOpt.IsChecked != CheckBoxRetail.IsChecked)
            {
                if (CheckBoxOpt.IsChecked == true)
                {
                    sale = true;
                }
                else
                {
                    sale = false;
                }
            }
            dgClientsTable.ItemsSource = map.MapClientDTOToClientBaseModelListByParam(person, sale, MinDate.SelectedDate, MaxDate.SelectedDate);


        }
    }
}
