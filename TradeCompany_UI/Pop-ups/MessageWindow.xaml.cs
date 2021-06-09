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

namespace TradeCompany_UI.Pop_ups
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        private UINavi _uiNavi;
        public MessageWindow(string text)
        {
            InitializeComponent();
            _uiNavi = UINavi.GetUINavi();
            Text.Text = text;
            Owner = _uiNavi.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
