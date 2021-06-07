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
            int? person = null;
            int? sale = null;
            MapsDTOtoModel map = new MapsDTOtoModel();
            if (CheckBoxF.IsChecked != CheckBoxU.IsChecked)
            {
                if(CheckBoxF.IsChecked == true)
                {
                    person = 1;
                }
                else
                {
                    person = 0;
                }
            }
            if (CheckBoxOpt.IsChecked != CheckBoxRetail.IsChecked)
            {
                if (CheckBoxOpt.IsChecked == true)

                {
                    sale = 1;
                }
                else
                {
                    sale = 0;
                }
            }


            DateTime? maxDate = null;

            if (MaxDate.SelectedDate != null)
            {
                DateTime timeTmp = (DateTime)MaxDate.SelectedDate;
                timeTmp = timeTmp.AddDays(1);
                timeTmp = timeTmp.AddMilliseconds(-1);
                maxDate = (DateTime?)timeTmp;
            }


            dgClientsTable.ItemsSource = map.MapClientDTOToClientBaseModelListByParam(person, sale, MinDate.SelectedDate, maxDate);
        }




        private void ButtonFiltr_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxF.IsChecked = false;
            CheckBoxU.IsChecked = false;
            CheckBoxOpt.IsChecked = false;
            CheckBoxRetail.IsChecked = false;
            MinDate.SelectedDate = null;
            MinDate.SelectedDate = null;
            ClientsFiltr(sender, e);
        }


        private void dgClientsTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            ClientBaseModel item = (ClientBaseModel)dg.CurrentItem;
            if(item != null)
            {
                int id = item.ID;
                frame.Content = new OneClient(id);
            }
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            frame.Content = new OneClient();
        }
    }
}
