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
    public class CustomTable : StackPanel
    {
        private List<IRowItem> _items;
        private List<Row> _rows;
        private CustomTable _details;
        private int _startIndexOfDetails;
        private bool _detailsShown = false;

        public CustomTable()
        {

        }
        public CustomTable(List<IRowItem> items, string rowStyle = "RowButton")
        {
            _items = items;
            _rows = new List<Row>();
            _details = new CustomTable();
            
            if (_items.Count > 0)
            {
                Children.Add(new Headers(_items[0].GetHeaders(), _items[0].GetColomnSizes(), this));
                int index = 1;
                foreach(IRowItem item in _items)
                {
                    Row row = new Row(item, this, index, rowStyle);                    
                    _rows.Add(row);
                    Children.Add(row);
                    index++;
                }
            }
            Border border = new Border();
            border.BorderThickness = new Thickness(0,0,0,1);
            border.BorderBrush = Brushes.Black;
            Children.Add(border);
        }

        public void ChangeDetailsVisibility(CustomTable details, int rowIndex)
        {
            if (!_detailsShown)
            {
                _startIndexOfDetails = rowIndex + 1;
                _details = details;
                Children.Insert(rowIndex + 1, details);
                _detailsShown = true;
            }
            else if (_startIndexOfDetails != rowIndex + 1)
            {
                Children.Remove(_details);
                _startIndexOfDetails = rowIndex + 1;
                _details = details;
                Children.Insert(rowIndex + 1, details);
                _detailsShown = true;
            }
            else
            {
                Children.Remove(_details);
                _detailsShown = false;
            }
        }
    }
}
