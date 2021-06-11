using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TradeCompany_UI.TableElements
{
    public class Cell: Border
    {
        public TextBlock Text { get; set; }

        public Cell(string text, int width)
        {
            BorderThickness = new Thickness(0, 0, 1, 0);
            Width = width;
            Text = new TextBlock();
            Text.Text = text;
            Text.Height = 21;
            Child = Text;
            BorderBrush = Brushes.Black;
            Text.Margin = new Thickness(5,0,5,0);
            HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
}
