using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public  class MyErrorProvider : ErrorProvider
    {


        public bool HasErrors()
        {
         //  string error=   this.GetError(this.contr);
         //  return string.IsNullOrEmpty(error) ? false : true;
            return true;
        }

    }
}
