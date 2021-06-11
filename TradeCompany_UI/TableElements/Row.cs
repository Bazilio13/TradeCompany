using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TradeCompany_BLL.Interfaces;
using TradeCompany_BLL.Models;

namespace TradeCompany_UI.TableElements
{
    public class Row: Button
    {
        private CustomTable _parentTable;
        private Border _border;
        private StackPanel _stackPanel;
        
        public IRowItem Item { get; set; }
        int Index { get; set; }
        public Row(IRowItem item, CustomTable parent, int index, string style)
        {
            Style = FindResource(style) as Style;
            Index = index;
            _parentTable = parent;
            Item = item;
            Height = 23;
            BorderThickness = new Thickness(0);
            _border = new Border() { BorderThickness = new Thickness(1, 0, 0, 1), Height = 23, BorderBrush = Brushes.Black };
            AddChild(_border);
            _stackPanel = new StackPanel();
            _border.Child = _stackPanel;
            _border.BorderBrush = Brushes.Black; 
            _stackPanel.Orientation = Orientation.Horizontal;
            List<string> content = Item.GetTextView();
            List<int> cSizes = Item.GetColomnSizes();
            
            for (int i = 0; i < content.Count; i++)
            {
             _stackPanel.Children.Add(new Cell(content[i], cSizes[i]));
                Width += cSizes[i];                
            }
            Click += (sender, e) => ShowDeatils();
            
            //< Border BorderBrush = "Black" BorderThickness = "0,1,1,0"  Height = "23" >
        }
        public void ShowDeatils()
        {
            CustomTable details = new CustomTable(Item.GetDetalization(), "InnerButton");
            _parentTable.ChangeDetailsVisibility(details, Index);
        }

    }
}
