﻿using System;
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
                List<String> addresses = map.MapClientDTOToAddressesModelByID(_id);
                if(addresses.Count != 0)
                {
                    foreach (String address in addresses)
                    {
                        comboBoxAddresses.Items.Add(address);
                    }
                }
                else
                {
                    comboBoxAddresses.Items.Add("Адрес");
                }

                comboBoxAddresses.SelectedIndex = 0;
                DenyAccessForPanel();
            }
            else
            {
                ButtonChange.IsEnabled = false;

            }
        }

        private void DenyAccessForPanel()
        {
            foreach (UIElement item in Panel.Children)
            {
                if (item is ComboBox)
                {
                    ComboBox itemComboBox = (ComboBox)item;                 
                    itemComboBox.IsReadOnly = true;
                    itemComboBox.IsEditable = false;
                }

                if (item is TextBox)
                {
                    TextBox itemTextBox = (TextBox)item;
                    itemTextBox.IsEnabled = false;
                }
            }
        }



        private void GiveAccessForPanel()
        {
            foreach (UIElement item in Panel.Children)
            {
                if (item is ComboBox)
                {
                    ComboBox itemComboBox = (ComboBox)item;
                    itemComboBox.IsReadOnly = false;
                    itemComboBox.IsEditable = true;
                }

                if (item is TextBox)
                {
                    TextBox itemTextBox = (TextBox)item;
                    itemTextBox.IsEnabled = true;
                }
            }
        }

        private void ChangeClient(object sender, RoutedEventArgs e)
        {
            GiveAccessForPanel();
            ButtonChange.IsEnabled = false;
        }

        private void SaveClient(object sender, RoutedEventArgs e)
        {
            if (FieldValidation())
            {
                ClientModel client = new ClientModel();
                client = ToFormClientModel();
                DenyAccessForPanel();
                MapsModelToDTO maps = new MapsModelToDTO();
                maps.MapClientModelToClientDTO(client);
            }
        }

        private ClientModel ToFormClientModel()
        {
            ClientModel client = new ClientModel();
            client.ID = _id;
            client.Name = textBoxName.Text.Trim();
            client.INN = Convert.ToInt32(textBoxINN.Text);
            client.E_mail = textBoxE_mail.Text.Trim(' ');
            client.Phone = textBoxPhone.Text;
            client.ContactPerson = textBoxContactPerson.Text;
            client.Comment = textBoxComments.Text;
            client.LastOrderDate = DateTime.Now; // что-то нужно сделат с нулевой датой 
            client.Type = false; //добавить флажок 
            client.CorporateBody = false; //добавить флажок 
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
            int member;
            if(textBoxINN.Text.Trim(' ') != null)
            {
                if (!Int32.TryParse(textBoxINN.Text, out member))
                {
                    textBoxINN.Background = Brushes.Pink;
                    validation = false;
                }
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
            e.Handled = !(e.Text=="0" || e.Text == "1" || e.Text == "2" || e.Text == "3" || e.Text == "4" ||
                e.Text == "5" || e.Text == "6" || e.Text == "7" || e.Text == "8" || e.Text == "9" || e.Text == "+" ||
                e.Text == "(" || e.Text == ")" );
        }

        private void ValidationByINN(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
