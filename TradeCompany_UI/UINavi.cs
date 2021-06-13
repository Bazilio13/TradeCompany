using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TradeCompany_UI
{
    public class UINavi
    {
        private static UINavi _uiNavi;

        public MainWindow MainWindow;

        private UINavi()
        {

        }

        public static UINavi GetUINavi()
        {
            if (_uiNavi is null)
            {
                _uiNavi = new UINavi();
            }
            return _uiNavi;
        }

        public void GoToThePage(Page page)
        {
            MainWindow.MainFrame.Content = page;
        }


    }
}
