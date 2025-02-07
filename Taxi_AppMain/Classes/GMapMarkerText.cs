using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Taxi_AppMain
{
    public class GMapMarkerText : GMapMarker
    {





        private string _MarkerText;

        public string MarkerText
        {
            get { return _MarkerText; }
            set { _MarkerText = value; }
        }


        private string _DefaultMarkerText;

        public string DefaultMarkerText
        {
            get { return _DefaultMarkerText; }
            set { _DefaultMarkerText = value; }
        }



        private string _MarkerText2;

        public string MarkerText2
        {
            get { return _MarkerText2; }
            set { _MarkerText2 = value; }
        }




        public GMapMarkerText(GMap.NET.PointLatLng pos, string text)   : base(pos)
        {

            this.MarkerText = text;
        }




        public override void OnRender(System.Drawing.Graphics g)
        {
            


            ToolTipText = this.MarkerText;
           
           // ToolTip.Fill = new SolidBrush(Color.FromArgb(10, Color.Red));
            ToolTip.Offset = new Point(4, -1);

            ToolTip.Font = new Font("Arial", 9, FontStyle.Bold);
            ToolTipMode = MarkerTooltipMode.Always;
          
            base.OnRender(g);
        }





    }
}
