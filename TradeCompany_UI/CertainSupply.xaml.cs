using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TradeCompany_UI.Interfaces;
using System.Xml.Linq;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for CertainSupply.xaml
    /// </summary>
    public partial class CertainSupply : Page, IProductAddable
    {
        private Frame _frame;
        private SupplysDataAccess _supplysDataAccess;
        public SupplyModel SupplyModel { get; set; }

        ObservableCollection<SupplyListModel> _osSupplyListModels = new ObservableCollection<SupplyListModel>();
        public CertainSupply(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
        }

        public CertainSupply(Frame frame, int id)
        {
            _frame = frame;
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
            SupplyModel = _supplysDataAccess.GetSupplyModelByID(id);
            if (SupplyModel is null)
            {

            }
            else
            {
                SupplyModel.SupplyListModel.ForEach(supplyListModel => _osSupplyListModels.Add(supplyListModel));
                SupplysDate.SelectedDate = SupplyModel.DateTime;
                dgSupplyList.ItemsSource = _osSupplyListModels;
                _osSupplyListModels.CollectionChanged += _osSupplyListModels_CollectionChanged;
            }
        }

        private void _osSupplyListModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

        }

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            SupplyListModel supplyListModel = new SupplyListModel();
            supplyListModel.ProductID = productID;
            supplyListModel.ProductMeasureUnit = productMeasureUnit;
            supplyListModel.ProductName = productName;
            supplyListModel.ProductGroups = productGroupModels;
            SupplyModel.SupplyListModel.Add(supplyListModel);
            //_osSupplyListModels.Add(supplyListModel);
            //dgSupplyList.Items.Refresh();
        }

        private void SupplysDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplyModel.DateTime = (DateTime)SupplysDate.SelectedDate;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProductCatalog(_frame, this);

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

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
        }

        private void dgSupplyList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void dgSupplyList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
