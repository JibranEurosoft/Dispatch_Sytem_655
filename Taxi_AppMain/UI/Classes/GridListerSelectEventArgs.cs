using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace UI
{
    public class GridListerSelectEventArgs
    {
        private int _rowIndex;

        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private GridViewRowInfo _row;

        public GridViewRowInfo Row
        {
            get { return _row; }
            set { _row = value; }
        }
        private GridViewDataColumn _column;

        public GridViewDataColumn Column
        {
            get { return _column; }
            set { _column = value; }
        }
        private GridDataCellElement _cell;

        public GridDataCellElement Cell
        {
            get { return _cell; }
            set { _cell = value; }
        }

        private string _selectBy;

        public string SelectBy
        {
            get { return _selectBy; }
            set { _selectBy = value; }
        }


    }
}
