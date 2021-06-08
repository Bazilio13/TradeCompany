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
using System.ComponentModel;

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

        ObservableCollection<SupplyListModel> _ocSupplyListModels = new ObservableCollection<SupplyListModel>();
        public CertainSupply(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
            SupplyModel = new SupplyModel();
            _ocSupplyListModels = new ObservableCollection<SupplyListModel>();
            dgSupplyList.ItemsSource = _ocSupplyListModels;
        }

        public CertainSupply(Frame frame, int id)
        {
            _frame = frame;
            InitializeComponent();
            _supplysDataAccess = new SupplysDataAccess();
            SupplyModel = _supplysDataAccess.GetSupplyModelByID(id);
            SupplyComment.Text = SupplyModel.Comment;
            if (SupplyModel is null)
            {

            }
            else
            {
                _ocSupplyListModels = ConvertListToObservableCollection(SupplyModel.SupplyListModel);
                SupplysDate.SelectedDate = SupplyModel.DateTime;
                dgSupplyList.ItemsSource = _ocSupplyListModels;
            }
        }

        public void AddProductToCollection(int productID, string productName, string productMeasureUnit, List<ProductGroupModel> productGroupModels)
        {
            SupplyListModel supplyListModel = new SupplyListModel();
            supplyListModel.ProductID = productID;
            supplyListModel.ProductMeasureUnit = productMeasureUnit;
            supplyListModel.ProductName = productName;
            supplyListModel.ProductGroups = productGroupModels;
            _ocSupplyListModels.Add(supplyListModel);
        }

        private ObservableCollection<SupplyListModel> ConvertListToObservableCollection(List<SupplyListModel> supplyListModelsL)
        {
            ObservableCollection<SupplyListModel> supplyListModelsOC = new ObservableCollection<SupplyListModel>();
            supplyListModelsL.ForEach(supplyListModel => supplyListModelsOC.Add(supplyListModel));
            return supplyListModelsOC;
        }
        private List<SupplyListModel> ConvertObservableCollectionToList(ObservableCollection<SupplyListModel> supplyListModelsOC)
        {
            List<SupplyListModel> supplyListModelsL = new List<SupplyListModel>();
            foreach (SupplyListModel supplyListModel in supplyListModelsOC)
            {
                supplyListModelsL.Add(supplyListModel);
            }
            return supplyListModelsL;
        }

        private void SupplysDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //SupplyModel.DateTime = (DateTime)SupplysDate.SelectedDate;
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
            if (CheckTheFill())
            {
                SupplyModel.SupplyListModel = ConvertObservableCollectionToList(_ocSupplyListModels);
                SupplyModel.DateTime = (DateTime)SupplysDate.SelectedDate;
                SupplyModel.Comment = SupplyComment.Text;
                if (SupplyModel.ID == 0)
                {
                    _supplysDataAccess.AddSupply(SupplyModel);
                }
                else
                {
                    _supplysDataAccess.UpdateSupply(SupplyModel);
                }
            }
        }
        private bool CheckTheFill()
        {
            string message = "";
            bool checkResult = true;
            if (SupplysDate.SelectedDate is null)
            {
                checkResult = false;
                message = "не заполнена дата документа";
            }
            if (_ocSupplyListModels.Count == 0)
            {
                checkResult = false;
                message += "\nНе заполнен список товаров";
            }
            else
            {
                foreach (SupplyListModel supplyListModel in _ocSupplyListModels)
                {
                    if (supplyListModel.Amount == 0)
                    {
                        checkResult = false;

                        message += $"\nу Товара {supplyListModel.ProductName} не заполнено количество";
                    }
                }
            }
            if (!checkResult)
            {
                MessageBox.Show(message);
            }
            return checkResult;
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
