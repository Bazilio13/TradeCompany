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
using TradeCompany_BLL.Models;

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for ChangeSelectedCategories.xaml
    /// </summary>
    public partial class ChangeSelectedCategories : Window
    {
        private List<ProductGroupModel> _chosenGroups;
        private TextBox _textBox;
        public ChangeSelectedCategories(List<ProductGroupModel> chosenGroups, TextBox textBox)
        {
            InitializeComponent();
            _chosenGroups = chosenGroups;
            _textBox = textBox;
            for (int i = 0; i < _chosenGroups.Count; i++)
            {
                StackPanel.Children.Add(new CheckBox {Name = @"i", Content = _chosenGroups[i].Name });;
            }
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(CheckBox chbox in StackPanel.Children)
            {
                if(chbox.IsChecked ?? true)
                {
                    for (int i = 0; i < _chosenGroups.Count; i++)
                    {
                        if((string)chbox.Content == _chosenGroups[i].Name)
                        {
                            _chosenGroups.Remove(_chosenGroups[i]);
                            i--;
                        }
                    }
                }
            }
            if (_chosenGroups.Count == 0)
            {
                _textBox.Text = "Не выбрано";
                return;
            } 

            _textBox.Text = "";
            for (int i = 0; i < _chosenGroups.Count; i++)
            {
                _textBox.Text += _chosenGroups[i].Name + " / ";
            }
        }
    }
}
