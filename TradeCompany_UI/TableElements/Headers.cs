using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TradeCompany_BLL.Interfaces;

namespace TradeCompany_UI.TableElements
{
    class Headers : Button
    {
        private CustomTable _parentTable;
        private Border _border;
        private StackPanel _stackPanel;
        public List<string> HeadersText { get; set; }
        public List<int> ColumnSizes { get; set; }
        public Headers(List<string> headers, List<int> columnSizes, CustomTable parent)
        {
            Style = FindResource("HeaderButton") as Style;
            _parentTable = parent;
            HeadersText = headers;
            ColumnSizes = columnSizes;
            BorderThickness = new Thickness(0);
            Height = 23;            
            _border = new Border() { BorderThickness = new Thickness(1, 1, 0, 0), Height = 23, BorderBrush = Brushes.Black };
            AddChild(_border);
            _stackPanel = new StackPanel();
            _border.Child = _stackPanel;
            _stackPanel.Orientation = Orientation.Horizontal;
            Width = 0;
            for (int i = 0; i < HeadersText.Count; i++)
            {
                _stackPanel.Children.Add(new Cell(HeadersText[i], ColumnSizes[i]));
                Width += ColumnSizes[i];
            }
            Width += 1;
        }
    }
}
