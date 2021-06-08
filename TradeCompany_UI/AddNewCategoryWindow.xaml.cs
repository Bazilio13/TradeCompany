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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for AddNewCategoryWindow.xaml
    /// </summary>
    public partial class AddNewCategoryWindow : Window
    {
        public AddNewCategoryWindow()
        {
            InitializeComponent();
            if(NewCategory.Text == "")
            {
                SaveButton.IsEnabled = false;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string NewCategoryName
        {
            get
            {
                return NewCategory.Text;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MessageBox.Show("Категория добавлена");
        }

        private void NewCategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!(String.IsNullOrEmpty(NewCategory.Text)))
            {
                SaveButton.IsEnabled = true;
            }
            else
            {
                SaveButton.IsEnabled = false;
            }
        }

        
    }
}
