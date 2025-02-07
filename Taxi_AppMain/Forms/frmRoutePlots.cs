using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi_Model;
using Utils;

namespace Taxi_AppMain.Forms
{
    public partial class frmRoutePlots : Form
    {
        public frmRoutePlots()
        {
            InitializeComponent();
            this.Load += FrmRoutePlots_Load;
        }

        private void FrmRoutePlots_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;

            gMapControl1.MarkersEnabled = true;

            List<PointLatLng> points = new List<PointLatLng>();
            GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlay1");


            points = listOfLocations
                   .Select(args => new PointLatLng
                   {
                       Lat = Convert.ToDouble(args.Latitude),
                       Lng = Convert.ToDouble(args.Longitude)

                   }).ToList();


            if (points.Count > 0)
            {

                gMapControl1.Position = new PointLatLng(points[0].Lat, points[0].Lng);

                gMapControl1.MinZoom = 0;
                gMapControl1.MaxZoom = 24;
                gMapControl1.Zoom = 13;
                gMapControl1.DragButton = MouseButtons.Left;
            }

            GMapRoute route = new GMapRoute(points, "route1");
            route.Stroke = new Pen(Color.DodgerBlue, 7);


            polyOverlay.Routes.Add(route);

            gMapControl1.Overlays.Add(polyOverlay);
        }


        private void DrawPlotsOnMap()
        {
            try
            {

                
                    gMapControl1.MarkersEnabled = true;
                    gMapControl1.PolygonsEnabled = true;


                    List<PointLatLng> points = new List<PointLatLng>();

                    GMapOverlay polyOverlay = new GMapOverlay("overlayplot");
                    bool IsVisible;

                    foreach (var zone in General.GetQueryable<Gen_Zone>(c => c.MaxLatitude != null))
                    {
                        IsVisible = true;
                        points.Clear();

                        points = zone.Gen_Zone_PolyVertices
                               .Select(args => new PointLatLng
                               {
                                   Lat = Convert.ToDouble(args.Latitude),
                                   Lng = Convert.ToDouble(args.Longitude)

                               }).ToList();


                        if (points.Count > 0)
                        {


                            if (points.Count == 1)
                            {
                                List<PointLatLng> gpollist = new List<PointLatLng>();



                                double R = 6378.1;    //#Radius of the Earth
                                for (int i = 0; i <= 360; i++)
                                {



                                    double brng = (Math.PI / 180) * i;   //#Bearing is 90 degrees converted to radians.
                                    double d = (Convert.ToDouble(zone.Gen_Zone_PolyVertices[0].Diameter) / 2) * 1.60;  // #Distance in km



                                    double lat1 = (Math.PI / 180) * (Convert.ToDouble(zone.Gen_Zone_PolyVertices[0].Latitude));// #Current lat point converted to radians
                                    double lon1 = (Math.PI / 180) * (Convert.ToDouble(zone.Gen_Zone_PolyVertices[0].Longitude)); //#Current long point converted to radians

                                    double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(d / R) + Math.Cos(lat1) * Math.Sin(d / R) * Math.Cos(brng));


                                    double lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(d / R) * Math.Cos(lat1), Math.Cos(d / R) - Math.Sin(lat1) * Math.Sin(lat2));

                                    lat2 = lat2 * (180 / Math.PI);
                                    lon2 = lon2 * (180 / Math.PI);


                                    gpollist.Add(new PointLatLng(lat2, lon2));

                                }


                                GMapPolygon polygon = new GMapPolygon(gpollist, zone.ZoneName);
                                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));
                                polygon.Stroke = new Pen(Color.DarkGreen, 1);
                                polyOverlay.Polygons.Add(polygon);




                            }
                            else
                            {


                                GMapPolygon polygon = new GMapPolygon(points, zone.ZoneName);
                                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));

                                polygon.Stroke = new Pen(Color.DarkGreen, 1);
                                polygon.Tag = zone.Id;

                               


                                polyOverlay.Polygons.Add(polygon);

                            }



                            GMapMarkerText marker = new GMapMarkerText(new PointLatLng(points.Sum(c => c.Lat) / points.Count, points.Sum(c => c.Lng) / points.Count), zone.ZoneName.ToStr());
                            marker.ToolTip = new GMapBaloonToolTip(marker);
                            marker.IsVisible = IsVisible;
                            marker.Tag = zone.Id;
                            marker.MarkerText2 = zone.OrderNo.ToStr();
                            marker.DefaultMarkerText = marker.MarkerText;



                            polyOverlay.Markers.Add(marker);

                        }

                    }


                    gMapControl1.Overlays.Add(polyOverlay);

              //  }
            }
            catch (Exception ex)
            {


            }

        }





    }
}
