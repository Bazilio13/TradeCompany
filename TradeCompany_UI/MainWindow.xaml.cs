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
        UINavi _uiNavi;
        public MainWindow()
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            _uiNavi.MainWindow = this;
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Orders());
            this.Title = "Заказы";
            ButtonPicked(sender);
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Clients());
            this.Title = "Клиенты";
            ButtonPicked(sender);
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new ProductCatalog());
            this.Title = "Продукты";
            ButtonPicked(sender);
        }

        private void SupplysButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new Supplys());
            this.Title = "Поставки";
            ButtonPicked(sender);
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            _uiNavi.GoToThePage(new StatisticsByProducts());
            this.Title = "Статистика";
            ButtonPicked(sender);
        }

        private void ButtonPicked(object sender)
        {
            Brush brushPicked = new SolidColorBrush(Color.FromRgb(249, 240, 220));
            Brush brushReset = new SolidColorBrush(Color.FromRgb(249, 249, 249));

            OrdersButton.Background = brushReset;
            ClientsButton1.Background = brushReset;
            ProductButton.Background = brushReset;
            SupplysButton.Background = brushReset;
            StatisticsButton.Background = brushReset;

            if (sender == OrdersButton)
            {
                OrdersButton.Background = brushPicked;
            }
            if (sender == ClientsButton1)
            {
                ClientsButton1.Background = brushPicked;
            }
            if (sender == ProductButton)
            {
                ProductButton.Background = brushPicked;
            }
            if (sender == SupplysButton)
            {
                SupplysButton.Background = brushPicked;
            }
            if (sender == StatisticsButton)
            {
                StatisticsButton.Background = brushPicked;
            }
        }
    }
}
