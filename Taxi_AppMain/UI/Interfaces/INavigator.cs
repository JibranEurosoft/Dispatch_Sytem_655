using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
    public interface INavigator
    {
        void Save();
        void Delete();
        void AddNew();
        void Print();
       
        void DisplayRecord();
        void RefreshData();

     
    }
}
