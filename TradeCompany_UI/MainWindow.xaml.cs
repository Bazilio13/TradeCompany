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

namespace TradeCompany_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Orders();
            OrdersButton.Content = new Orders();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StartPage();
            //MainFrame.Content = new SpecificOrder(7);
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Clients();
        }
    }
}
