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
using System.Runtime;
using TradeCompany_DAL.DTOs;
using System.Globalization;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for OneClient.xaml
    /// </summary>
    public partial class OneClient : Page
    {
        private Page _previosPage;
        private UINavi _uiNavi;
        private int _id;
        private ClientsDataAccess _clientsData = new ClientsDataAccess();
        private List<WishModel> _wishList = new List<WishModel>();
        private List<OrderModel> _orderList = new List<OrderModel>();
        private List<String> _oldAddresses = new List<String>();
        private List<String> _newAddresses = new List<String>();
        private MapsDTOtoModel _map = new MapsDTOtoModel();
        private List<FeedbackModel> _feedback = new List<FeedbackModel>();
        private ClientModel client = new ClientModel();
        private Clients _clientsPage;
        



        public OneClient(int id, Page previosPage = null)
        {
            _clientsPage = (Clients)_previosPage;

            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _previosPage = previosPage;
            _id = id;
            _wishList = _clientsData.GetWishListByClientID(_id);
            FeedbacksDataAccess fda = new FeedbacksDataAccess();
            OrderDataAccess dataAccess = new OrderDataAccess();
            _orderList = dataAccess.GetOrderModelsByClientID(_id);
            _feedback = fda.GetFeedbacksByClientID(_id); 
        }



        public OneClient(Page previosPage = null)
        {
            _clientsPage = (Clients)_previosPage;
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _previosPage = previosPage;
            dgOrdersTable.Visibility = Visibility.Collapsed;
            SPFeedbackPanel.Visibility = Visibility.Collapsed;
            ButtonFeedback.Visibility = Visibility.Collapsed;
            ButtonStory.Visibility = Visibility.Collapsed;
            _id = -1;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _clientsPage = (Clients)_previosPage;
            MapsDTOtoModel map = new MapsDTOtoModel();

            if (_id != -1)
            {
                dgOrdersTable.ItemsSource = _orderList;
                ClientModel client = _clientsData.GetClientByClientID(_id);
                TBRegistrarionDate.Text = "Дата регистрации: " + client.RegistrationDate.ToString("dd.MM.yyyy",CultureInfo.InvariantCulture);
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
                if (client.Comment != null)
                {
                    textBoxComments.Text = client.Comment;
                }
                if (client.Type)
                {
                    RadioButtonTypePersonF.IsChecked = true;
                }
                else { RadioButtonTypePersonU.IsChecked = true; }

                if (client.CorporateBody)
                {
                    RadioButtonTypeBayO.IsChecked = true;
                }
                else { RadioButtonTypeBayR.IsChecked = true; }


                _oldAddresses = map.MapClientDTOToAddressesByID(_id); //нужно исправить 
                AddAddress();
                LoadWishPanel();
                LoadFeedback();
            }
            else
            {
                RadioButtonTypePersonF.IsChecked = true;
                RadioButtonTypeBayR.IsChecked = true;
                TBRegistrarionDate.Visibility = Visibility.Collapsed;
                RadioButtonTypeBayO.IsChecked = true;
                RadioButtonTypeBayR.IsChecked = true;
            }
            ProductsDataAccess product = new ProductsDataAccess();
            List<ProductBaseModel> allProducts = product.GetAllProducts(); 
            cbWish.ItemsSource = allProducts;

        }


        private void SaveClient(object sender, RoutedEventArgs e)

        {
            if (FieldValidation())
            {
                ClientModel client = ToFormClientModel();
                MapsModelToDTO maps = new MapsModelToDTO();
                _clientsData.SaveClient(client);
                if (_id == -1)
                {
                    _id = _clientsData.GetLastClient().ID;
                }
                _clientsData.SaveWishListByClientID(_wishList, _id);
                maps.MapAddressesListModelToAddressesListDTO(_newAddresses, _id); //нужно исправить

                if (MessageBox.Show("Клиент сохранен", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _clientsPage.UpdateDG();
                    _uiNavi.GoToThePage(_previosPage);
                }
            }
        }

        private ClientModel ToFormClientModel()
        {
            client.ID = _id;
            client.Name = textBoxName.Text.Trim();
            client.INN = textBoxINN.Text.Trim();
            client.E_mail = textBoxE_mail.Text.Trim(' ');
            client.Phone = textBoxPhone.Text;
            client.ContactPerson = textBoxContactPerson.Text;
            client.Comment = textBoxComments.Text;
            client.Type = (bool)RadioButtonTypePersonF.IsChecked;
            client.CorporateBody = (bool)RadioButtonTypeBayO.IsChecked;

            return client;
        }

        private bool FieldValidation()
        {
            bool validation = true;
            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                textBoxName.Background = Brushes.Pink;
                validation = false;
            }
            if (string.IsNullOrEmpty(textBoxPhone.Text.Trim()))
            {
                textBoxPhone.Background = Brushes.Pink;
                validation = false;
            }
            if (string.IsNullOrEmpty(textBoxContactPerson.Text.Trim()))
            {
                textBoxContactPerson.Background = Brushes.Pink;
                validation = false;
            }

            return validation;
        }

        private void Focus(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Background = Brushes.White;
        }

        private void ValidationByNumber(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(e.Text == "0" || e.Text == "1" || e.Text == "2" || e.Text == "3" || e.Text == "4" ||
                e.Text == "5" || e.Text == "6" || e.Text == "7" || e.Text == "8" || e.Text == "9" || e.Text == "+" ||
                e.Text == "(" || e.Text == ")");
        }

        private void ValidationByINN(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void clicNewWishProduct(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ProductBaseModel selectedItem = (ProductBaseModel)comboBox.SelectedItem;
            if (selectedItem != null && comboBox.Text.Length >= 3)
            {
                WishModel wish = new WishModel();
                wish.ID = selectedItem.ID;
                wish.Name = selectedItem.Name;
                _wishList.Add(wish);
                WPWish.Children.Clear();
                LoadWishPanel();
            }

        }

        private void LoadWishPanel()
        {
            int i = 0;
            foreach (WishModel wish in _wishList)
            {
                i++;
                Button tag = new Button();
                tag.Content = wish.Name;
                tag.Margin = new Thickness(5, 5, 5, 5);
                tag.Padding = new Thickness(5, 3, 5, 3);
                tag.Background = new SolidColorBrush(Color.FromRgb(243, 223, 196));
                tag.TabIndex = i;
                tag.Click += (sender, e) =>
                  {
                      Button tmp = (Button)sender;
                      ChangeWishList(tmp.Content.ToString());
                  };
                WPWish.Children.Add(tag);
            }
        }

        private void ChangeWishList(string name)
        {
            foreach (WishModel wish in _wishList)
            {
                if (wish.Name == name)
                {
                    _wishList.Remove(wish);
                    break;
                }
            }
            WPWish.Children.Clear();
            LoadWishPanel();
        }

        private void AddAddress()
        {
            foreach (String address in _oldAddresses)
            {
                stackPanelAddresses.Children.Add(new TextBox
                {
                    Text = address,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextWrapping = TextWrapping.Wrap,
                    Width = 390,
                    Height = 21,
                    Margin = new Thickness(0, 5, 0, 0),
                    IsEnabled = false
                });
            }
        }

        private void buttonAddAddress_Click(object sender, RoutedEventArgs e)
        {
            String addedAddress = ((TextBox)stackPanelAddresses.Children[0]).Text;
            if (addedAddress != "")
            {
                stackPanelAddresses.Children.Add(new TextBox
                {
                    Text = addedAddress,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextWrapping = TextWrapping.Wrap,
                    Width = 390,
                    Height = 21,
                    Margin = new Thickness(0, 5, 0, 0),
                    IsEnabled = false
                }); ;
                ((TextBox)stackPanelAddresses.Children[0]).Text = "";
                _newAddresses.Add(addedAddress);
            }
        }

        public void LoadFeedback()
        {
            foreach (FeedbackModel feedback in _feedback)
            {
                TextBlock fb = new TextBlock();
                fb.TextWrapping = TextWrapping.Wrap;
                fb.Text = feedback.DateTime + "    " + "Заказ №  " + feedback.OrderID + "\n" +feedback.Text;
                fb.Margin = new Thickness(5, 5, 5, 5);
                fb.Padding = new Thickness(5, 3, 5, 3);
                fb.Background = new SolidColorBrush(Color.FromRgb(243, 223, 196));
                SPFeedbackPanel.Children.Add(fb);
            }
        }

        private void VisibilityStory(object sender, RoutedEventArgs e)
        {
            if(dgOrdersTable.Visibility == Visibility.Visible)
            {
                dgOrdersTable.Visibility = Visibility.Collapsed;
            }
            else 
            {
                dgOrdersTable.Visibility = Visibility.Visible;
            }
        }

        private void VisibilityFeedback(object sender, RoutedEventArgs e)
        {
            if (SPFeedbackPanel.Visibility == Visibility.Visible)
            {
                SPFeedbackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                SPFeedbackPanel.Visibility = Visibility.Visible;
            }

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(_previosPage);
        }

        private void DeleteClients(object sender, RoutedEventArgs e)
        {
            if(_id != -1)
            {
                if (MessageBox.Show("Удалить из каталога?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _clientsData.SoftDeleteClientByID(_id);
                }                   
                MessageBox.Show("Клиент удален", "", MessageBoxButton.OK, MessageBoxImage.Information);
                _clientsPage.UpdateDG();
                _uiNavi.GoToThePage(_previosPage);

            }
            else
            {
                if (MessageBox.Show("Клиент не сохранен", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _clientsData.SoftDeleteClientByID(_id);
                }
            }

        }
       
    }
}
