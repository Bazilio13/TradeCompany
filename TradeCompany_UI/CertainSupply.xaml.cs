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
    /// Interaction logic for CertainSupply.xaml
    /// </summary>
    public partial class CertainSupply : Page
    {
        private SupplyModel _supplyModel;
        SupplysDataAccess _supplysDataAccess;
        public CertainSupply(Frame frame)
        {
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
        }

        public CertainSupply(Frame frame, int id)
        {
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
            _supplyModel = _supplysDataAccess.GetSupplyModelByID(id);
            if (_supplyModel is null)
            {

            }
            else
            {
                dgSupplyList.ItemsSource = _supplyModel.SupplyListModel;
                SupplysDate.SelectedDate = _supplyModel.DateTime;
            }
        }

        private void SupplysDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _supplyModel.DateTime = (DateTime)SupplysDate.SelectedDate;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PotentialClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgSupplys_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
