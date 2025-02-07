using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public partial class WeekDay
    {


        private int _Id;

        private string _Name;



        public WeekDay()
        {

        }

        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {

                    this._Id = value;

                }
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {

                    this._Name = value;

                }
            }
        }
    }
}
    
