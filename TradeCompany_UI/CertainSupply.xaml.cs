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
using TradeCompany_UI.DialogWindows;
using TradeCompany_UI.Pop_ups;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for CertainSupply.xaml
    /// </summary>
    public partial class CertainSupply : Page, IProductAddable
    {
        private UINavi _uiNavi;
        private SupplysDataAccess _supplysDataAccess;
        public SupplyModel SupplyModel { get; set; }
        private Page _priviosPage;

        ObservableCollection<SupplyListModel> _ocSupplyListModels = new ObservableCollection<SupplyListModel>();
        public CertainSupply(Page priviosPage)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _priviosPage = priviosPage;
            _supplysDataAccess = new SupplysDataAccess();
            SupplyModel = new SupplyModel();
            _ocSupplyListModels = new ObservableCollection<SupplyListModel>();
            dgSupplyList.ItemsSource = _ocSupplyListModels;
        }

        public CertainSupply(Page priviosPage, int id)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _priviosPage = priviosPage;
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

        public void AddProductToCollection(ProductBaseModel productBaseModel)
        {
            SupplyListModel supplyListModel = new SupplyListModel();
            supplyListModel.ProductID = productBaseModel.ID;
            supplyListModel.ProductMeasureUnit = productBaseModel.MeasureUnitName;
            supplyListModel.ProductName = productBaseModel.Name;
            supplyListModel.ProductGroups = productBaseModel.Groups;
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
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new ProductCatalog(this));
        }

        private void PotentialClients_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new PotentialClients());
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
                Supplys supply = (Supplys)_priviosPage;
                supply.FilterSupplys();
                _uiNavi.GoToThePage(_priviosPage);
            }
        }
        private bool CheckTheFill()
        {
            string message = "";
            bool checkResult = true;
            if (SupplysDate.SelectedDate is null)
            {
                checkResult = false;
                message = "Не заполнена дата документа";
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

                        message += $"\nУ товара {supplyListModel.ProductName} не заполнено количество";
                    }
                }
            }
            if (!checkResult)
            {
                new MessageWindow(message).ShowDialog();
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

        private void DeleteSupply_Click(object sender, RoutedEventArgs e)
        {
            ConfirmitionWindow confirmitionWindow = new ConfirmitionWindow("Вы уверены, что хотите удалить поставку?");     
            if (confirmitionWindow.ShowDialog() == true)
            {
                _supplysDataAccess.DeleteSupply(SupplyModel.ID);
                Supplys supply = (Supplys)_priviosPage;
                supply.FilterSupplys();
                _uiNavi.GoToThePage(_priviosPage);
            }

        }

        private void dgSupplyList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox textBox = (TextBox)e.EditingElement;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
            else
            {
                foreach(char ch in textBox.Text)
                {
                    if (!char.IsDigit(ch))
                    {
                        new MessageWindow("В поле количество можно вводить только числа").ShowDialog();
                        textBox.Text = "0";
                        break;
                    }
                }
            }
        }
    }
}
