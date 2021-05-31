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
using System.Windows.Shapes;
using TradeCompany_BLL;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for AllClientsForm.xaml
    /// </summary>
    public partial class AllClientsForm : Window
    {
        public AllClientsForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MapsDTOtoModel map = new MapsDTOtoModel();
            dgAllClientsTable.ItemsSource = map.MapClientsDTOToClientsModelList();
        }
    }
}
