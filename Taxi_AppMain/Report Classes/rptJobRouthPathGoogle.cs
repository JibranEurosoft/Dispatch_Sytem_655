using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Utils;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using Taxi_App;
using System.Xml;
using Taxi_BLL;
using System.IO;
using System.Drawing.Imaging;
using Taxi_AppMain.Forms;
using Taxi_BLL.Classes;

namespace Taxi_AppMain
{
    public partial class rptJobRouthPathGoogle : Form
    {
        private Booking _ObjBooking;

        public Booking ObjBooking
        {
            get { return _ObjBooking; }
            set { _ObjBooking = value; }
        }

        public rptJobRouthPathGoogle()
        {
            InitializeComponent();
        }


        private int _DriverId;
        private long? _EscortId;

        private bool IsTrackDriver;


        System.Threading.Timer timerRecording = null;


        public rptJobRouthPathGoogle(Booking obj, bool TrackDriver)
        {
            InitializeComponent();
            this.ObjBooking = obj;
            IsTrackDriver = TrackDriver;

            if (TrackDriver && obj != null)
            {
                this._DriverId = obj.DriverId.ToInt();

            }



            this.FormClosing += new FormClosingEventHandler(rptJobRouthPath_FormClosing);
            this.Load += new EventHandler(rptJobRouthPath_Load);
        }

        public rptJobRouthPathGoogle(Booking obj, bool TrackDriver, int driverId, long? escortId = null)
        {
            InitializeComponent();
            this.ObjBooking = obj;
            IsTrackDriver = TrackDriver;
            this._DriverId = driverId;
            this._EscortId = escortId;
            this.FormClosing += new FormClosingEventHandler(rptJobRouthPath_FormClosing);
            this.Load += new EventHandler(rptJobRouthPath_Load);
            this.Shown += new EventHandler(rptJobRouthPathGoogle_Shown);
        }

        void rptJobRouthPathGoogle_Shown(object sender, EventArgs e)
        {
            BringToFront();


        }


        private void DrawPlotsOnMap(bool drawAll)
        {

            //       return;
            try
            {


                List<Gen_Zone_PolyVertice> listofVertices = null;

                if (listofVertices == null)
                {

                    listofVertices = new List<Gen_Zone_PolyVertice>();

                    if (drawAll)
                    {
                        listofVertices = new TaxiDataContext().Gen_Zone_PolyVertices.ToList();
                        // getAll = true;

                    }


                }



                gMapControl1.MarkersEnabled = true;
                gMapControl1.PolygonsEnabled = true;


                List<PointLatLng> points = new List<PointLatLng>();

                GMapOverlay polyOverlay = gMapControl1.Overlays.FirstOrDefault();
                bool IsVisible;


                if (drawAll == false)
                {
                    if (polyOverlay.Polygons.Where(c => c.Tag.ToStr() == "Zone").Count() > 0)
                    {
                        polyOverlay.Polygons.Where(c => c.Tag.ToStr() == "Zone").ToList().ForEach(c => c.IsVisible = false);
                        polyOverlay.Markers.Where(c => c.Tag.ToStr() == "Zone").ToList().ForEach(c => c.IsVisible = false);
                        return;
                    }

                }
                else
                {
                    if (polyOverlay.Polygons.Where(c => c.Tag.ToStr() == "Zone").Count() > 0)
                    {
                        polyOverlay.Polygons.Where(c => c.Tag.ToStr() == "Zone").ToList().ForEach(c => c.IsVisible = true);
                        polyOverlay.Markers.Where(c => c.Tag.ToStr() == "Zone").ToList().ForEach(c => c.IsVisible = true);
                        return;
                    }
                }


                var plots = new TaxiDataContext().Gen_Zones.ToList();

                foreach (var zone in plots)
                {

                    //if (drawAll == false)
                    //{
                    //    if (listofPlots.Count(c => c == zone.Id) == 0)
                    //        continue;
                    //}

                    IsVisible = true;
                    points.Clear();


                    var zonepOLY = listofVertices.Where(c => c.ZoneId == zone.Id).ToList();

                    points = zonepOLY
                           .Select(args => new PointLatLng
                           {
                               Lat = Convert.ToDouble(args.Latitude),
                               Lng = Convert.ToDouble(args.Longitude)

                           }).ToList();


                    if (points.Count > 0)
                    {

                        //if (zone.BlockDropOff.ToBool())
                        //{
                        //    if (listofPlots.Count(c => c == zone.Id) > 0)
                        //        outoftownPlots += zone.ZoneName.ToStr() + ",";

                        //}
                        //else
                        //{
                        //    if (listofPlots.Count(c => c == zone.Id) > 0)
                        //        localPlots += zone.ZoneName.ToStr() + ",";

                        //}


                        string label = zone.ZoneName.ToStr();
                        if (points.Count == 1)
                        {
                            List<PointLatLng> gpollist = new List<PointLatLng>();



                            double R = 6378.1;    //#Radius of the Earth
                            for (int i = 0; i <= 360; i++)
                            {



                                double brng = (Math.PI / 180) * i;   //#Bearing is 90 degrees converted to radians.
                                double d = (Convert.ToDouble(zonepOLY[0].Diameter) / 2) * 1.60;  // #Distance in km



                                double lat1 = (Math.PI / 180) * (Convert.ToDouble(zonepOLY[0].Latitude));// #Current lat point converted to radians
                                double lon1 = (Math.PI / 180) * (Convert.ToDouble(zonepOLY[0].Longitude)); //#Current long point converted to radians

                                double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(d / R) + Math.Cos(lat1) * Math.Sin(d / R) * Math.Cos(brng));


                                double lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(d / R) * Math.Cos(lat1), Math.Cos(d / R) - Math.Sin(lat1) * Math.Sin(lat2));

                                lat2 = lat2 * (180 / Math.PI);
                                lon2 = lon2 * (180 / Math.PI);


                                gpollist.Add(new PointLatLng(lat2, lon2));

                            }


                            GMapPolygon polygon = new GMapPolygon(gpollist, zone.ZoneName);
                            polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));
                            polygon.Stroke = new Pen(Color.DarkGreen, 1);
                            polygon.Tag = "Zone";
                            polyOverlay.Polygons.Add(polygon);




                        }
                        else
                        {



                            GMapPolygon polygon = new GMapPolygon(points, zone.ZoneName);
                            polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));

                            polygon.Stroke = new Pen(Color.DarkGreen, 1);
                            polygon.Tag = zone.Id;
                            polygon.Tag = "Zone";
                            polyOverlay.Polygons.Add(polygon);






                        }



                        GMapMarkerText marker = new GMapMarkerText(new PointLatLng(points.Sum(c => c.Lat) / points.Count, points.Sum(c => c.Lng) / points.Count), label.ToStr());
                        //    marker.ToolTip = new GMapMarkerText(marker);
                        marker.IsVisible = IsVisible;
                        marker.Tag = zone.Id;
                        marker.MarkerText2 = zone.OrderNo.ToStr();
                        marker.DefaultMarkerText = marker.MarkerText;
                        marker.Tag = "Zone";


                        polyOverlay.Markers.Add(marker);

                    }

                }


            }
            catch (Exception ex)
            {


            }

        }

        void rptJobRouthPath_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {



                if (worker != null)
                {
                    if (worker.IsBusy)
                    {
                        worker.CancelAsync();

                    }

                    worker.Dispose();


                }

                if (timer1 != null)
                {
                    timer1.Stop();
                }

                if (gMapControl1 != null)
                {
                    gMapControl1.Overlays.Clear();
                    //  gMapControl1.Dispose();
                    gMapControl1 = null;
                }

                if (IsTrackDriver == false)
                {
                    this.Dispose(true);
                }
            }
            catch (Exception ex)
            {


            }
        }


        delegate void UIParameterizedDelegate(List<PointLatLng> points);

        private void CreateJobRouteDirection()
        {
            if (ObjBooking == null)
                return;
            try
            {


                string origin = General.GetPostCodeMatch(ObjBooking.FromAddress);
                string destination = General.GetPostCodeMatch(ObjBooking.ToAddress);


                List<PointLatLng> points = new List<PointLatLng>();




                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {


                        if (string.IsNullOrEmpty(origin))
                        {

                            string baseAddress = General.GetPostCodeMatch(AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper());

                            if (!string.IsNullOrEmpty(baseAddress))
                            {

                                var objCoordinate = db.Gen_Coordinates.Where(c => c.PostCode == baseAddress).FirstOrDefault();

                                if (objCoordinate != null)
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude), Convert.ToDouble(objCoordinate.Longitude)));

                                }


                            }

                        }
                        else if (!string.IsNullOrEmpty(origin))
                        {

                            string pickup = General.GetPostCodeMatch(ObjBooking.FromAddress.ToStr().ToUpper());

                            if (!string.IsNullOrEmpty(pickup))
                            {

                                var objCoordinate = db.Gen_Coordinates.Where(c => c.PostCode == pickup).FirstOrDefault();

                                if (objCoordinate != null)
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude), Convert.ToDouble(objCoordinate.Longitude)));
                                }
                                else
                                {


                                    var objX = db.stp_getCoordinatesByAddress(pickup.ToStr().ToUpper(), pickup.ToStr().ToUpper()).FirstOrDefault();


                                    if (objX == null)
                                    {
                                        var obj = GetDistance.PostCodeToLongLat(pickup, "GB");


                                        if (obj != null)
                                        {

                                            points.Add(new PointLatLng(Convert.ToDouble(obj.Value.Latitude), Convert.ToDouble(obj.Value.Longitude)));


                                        }
                                    }
                                    else
                                    {
                                        points.Add(new PointLatLng(Convert.ToDouble(objX.Latitude), Convert.ToDouble(objX.Longtiude)));

                                    }






                                }

                            }

                        }


                        if (string.IsNullOrEmpty(destination))
                        {


                            var objCoord = db.stp_getCoordinatesByAddress(ObjBooking.ToAddress.ToStr(), destination).FirstOrDefault(); ;


                            if (objCoord != null)
                            {
                                if (objCoord != null)
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(objCoord.Latitude), Convert.ToDouble(objCoord.Longtiude)));

                                }

                            }


                        }


                        else if (!string.IsNullOrEmpty(destination))
                        {

                            var objCoordinate = db.Gen_Coordinates.Where(c => c.PostCode == destination).FirstOrDefault();

                            if (objCoordinate != null)
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude), Convert.ToDouble(objCoordinate.Longitude)));
                            }
                            else
                            {




                                var objX = db.stp_getCoordinatesByAddress(destination.ToStr().ToUpper(), destination.ToStr().ToUpper()).FirstOrDefault();


                                if (objX == null)
                                {
                                    var obj = GetDistance.PostCodeToLongLat(destination, "GB");


                                    if (obj != null)
                                    {

                                        points.Add(new PointLatLng(Convert.ToDouble(obj.Value.Latitude), Convert.ToDouble(obj.Value.Longitude)));


                                    }
                                }
                                else
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(objX.Latitude), Convert.ToDouble(objX.Longtiude)));

                                }







                            }

                        }

                    }


                    //if(ObjBooking!=null && ObjBooking.Booking_ViaLocations.Count>0)
                    //{
                    //    foreach (var item in ObjBooking.Booking_ViaLocations.Select(c=>c.ViaLocValue))
                    //    {
                    //        using (TaxiDataContext db = new TaxiDataContext())
                    //        {

                    //            var objX = db.stp_getCoordinatesByAddress(item.ToStr().ToUpper(), General.GetPostCodeMatch(item.ToStr().ToUpper())).FirstOrDefault();


                    //            if (objX == null)
                    //            {
                    //                var obj = GetDistance.PostCodeToLongLat(destination, "GB");


                    //                if (obj != null)
                    //                {

                    //                    points.Add(new PointLatLng(Convert.ToDouble(obj.Value.Latitude), Convert.ToDouble(obj.Value.Longitude)));


                    //                }
                    //            }
                    //            else
                    //            {
                    //                points.Add(new PointLatLng(Convert.ToDouble(objX.Latitude), Convert.ToDouble(objX.Longtiude)));

                    //            }

                    //        }

                    //    }




                    //}


                }
                catch
                {

                }




                if (points.Count > 0)
                {

                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new UIParameterizedDelegate(OnDisplayMap), points);


                    }
                    else
                    {
                        OnDisplayMap(points);


                    }



                    if (IsTrackDriver)
                    {

                        if (AppVars.etaKey.ToStr().Length == 0)
                        {

                            try
                            {
                                using (TaxiDataContext db = new TaxiDataContext())
                                {

                                    AppVars.etaKey = db.ExecuteQuery<string>("select apikey from mapkeys where maptype='here'").FirstOrDefault();


                                    if (AppVars.etaKey.ToStr().Trim().Length == 0)
                                        AppVars.etaKey = " ";

                                    else
                                    {
                                        chkETA.Visible = true;


                                    }
                                }
                            }
                            catch
                            {
                                AppVars.etaKey = " ";

                            }


                        }
                        else
                        {
                            if (AppVars.etaKey.ToStr().Trim().Length > 0)
                                chkETA.Visible = true;

                        }

                    }

                }


            }
            catch (Exception ex)
            {


            }

        }

        private void OnDisplayMap(List<PointLatLng> points)
        {
            try
            {





                if (ObjBooking != null && points.Count > 0)
                {
                    bool showBookingMarkers = true;
                    GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlayJob");



                    gMapControl1.MinZoom = 0;
                    gMapControl1.MaxZoom = 24;
                    gMapControl1.Zoom = 18;
                    gMapControl1.DragButton = MouseButtons.Left;




                    GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(points[0].Lat), Convert.ToDouble(points[0].Lng)), Resources.Resource1.arrived);
                    marker1.ToolTipText = "PICKUP : " + Environment.NewLine + ObjBooking.FromAddress.ToStr();
                    marker1.ToolTipMode = MarkerTooltipMode.Always;
                    marker1.ToolTip.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    marker1.Tag = new PointLatLng(points[0].Lat, points[0].Lng);
                    marker1.Tag = "Pickup";


                    if (ObjBooking.DriverId == null || ObjBooking.DriverId != this._DriverId)
                    {
                        showBookingMarkers = false;
                    }

                    polyOverlay.Markers.Add(marker1);


                    if (points.Count > 1)
                    {
                        if (points.Count == 2)
                        {
                            gMapControl1.Position = new PointLatLng(points[1].Lat, points[1].Lng);
                        }
                        else
                            gMapControl1.Position = new PointLatLng(points[points.Count - 1].Lat, points[points.Count - 1].Lng);



                        if (points.Count > 2)
                        {
                            GMapRoute route = new GMapRoute(points, "routeJob");
                            route.Stroke = new Pen(Color.CornflowerBlue, 8);

                            polyOverlay.Routes.Add(route);
                        }


                        GMapMarkerCustom marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(points[points.Count - 1].Lat), Convert.ToDouble(points[points.Count - 1].Lng)), Resources.Resource1.clear);
                        marker2.ToolTipText = "DESTINATION : " + Environment.NewLine + ObjBooking.ToAddress.ToStr();
                        marker2.ToolTipMode = MarkerTooltipMode.Always;
                        marker2.ToolTip.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        marker2.Tag = "Destination";
                        polyOverlay.Markers.Add(marker2);



                        if (showBookingMarkers == false)
                        {

                            marker1.IsVisible = false;
                            marker2.IsVisible = false;
                            HideJobDetailsZoomPanel();
                        }


                    }
                    else
                        gMapControl1.Position = new PointLatLng(points[0].Lat, points[0].Lng);


                    //if(IsTrackDriver)
                    //{


                    //    var fojList=  ((Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard") as frmBookingDashBoard).GetFOJPickups(this._DriverId));

                    //    if (fojList.Count > 0)
                    //    {
                    //        using (TaxiDataContext db = new TaxiDataContext())
                    //        {
                    //            foreach (var item in fojList)
                    //            {
                    //                var arr = item.Split('|');

                    //               var coord=  db.stp_getCoordinatesByAddress(arr[1], General.GetPostCodeMatch(arr[1])).FirstOrDefault();

                    //                if (coord != null && coord.Latitude != null)
                    //                {



                    //                    GMapMarkerCustom marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(coord.Latitude), Convert.ToDouble(coord.Longtiude)), Resources.Resource1.Track);
                    //                    marker2.ToolTipText = "FOJ - " + arr[0] ;
                    //                    marker2.ToolTipMode = MarkerTooltipMode.Always;
                    //                    marker2.ToolTip.Font = new Font("Tahoma", 11, FontStyle.Bold);

                    //                    marker2.Tag = "FOJ";
                    //                    polyOverlay.Markers.Add(marker2);
                    //                }
                    //            }


                    //        }
                    //    }


                    //}


                    gMapControl1.Overlays.Add(polyOverlay);




                }
                else
                {

                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new UIParameterizedDelegate(OnDisplayMap), null);


                    }
                    else
                    {





                        if (gMapControl1.Overlays[0].Markers.Count > 0)
                        {
                            gMapControl1.Position = new PointLatLng(gMapControl1.Overlays[0].Markers[0].Position.Lat, gMapControl1.Overlays[0].Markers[0].Position.Lng);

                            gMapControl1.MinZoom = 0;
                            gMapControl1.MaxZoom = 24;

                            if (gMapControl1.Zoom == 0)
                                gMapControl1.Zoom = 22;

                            gMapControl1.DragButton = MouseButtons.Left;

                            optPickup.Visible = false;
                            optDestination.Visible = false;
                            pnlZoom.Size = new Size(pnlZoom.Size.Width, 60);

                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void HideJobDetailsZoomPanel()
        {

            optPickup.Visible = false;
            optDestination.Visible = false;
            pnlZoom.Size = new Size(pnlZoom.Size.Width, 60);

        }


        delegate void UIVoidDelegate();
        GMapMarkerCustom markerDrv = null;


        private void GetDriverLocation()
        {
            try
            {

                if (IsClosed)
                    return;

                new System.Threading.Thread(delegate ()
                {
                    try
                    {
                        //if (this.InvokeRequired)
                        //{
                        //    this.BeginInvoke(new UIVoidDelegate(OnDisplayDriverLocation));


                        //}
                        //else
                        //{
                        if (gettingLocation == false)
                            OnDisplayDriverLocation();


                        //  }
                    }
                    catch
                    {

                    }
                }).Start();
            }
            catch (Exception ex)
            {


            }

        }

        private bool gettingLocation = false;

        int oddCnt = 1;
        string lastETA = string.Empty;
        double? LastSpeed = null;
        private void OnDisplayDriverLocation()
        {
            try
            {


                if (IsClosed)
                {
                    gettingLocation = false;
                    return;

                }


                if (this._DriverId == 0)
                {
                    gettingLocation = false;
                    return;

                }


                gettingLocation = true;


                using (TaxiDataContext db = new TaxiDataContext())
                {
                    Fleet_Driver_Location obj = null;
                    //var obj = db.Fleet_Driver_Locations.Where(c => c.DriverId == this._DriverId).Select(c => new { c.DriverId, c.Speed, c.Latitude, c.Longitude, c.LocationName }).FirstOrDefault();
                    if (_EscortId != null)
                    {
                        obj = db.ExecuteQuery<Fleet_Driver_Location>("Select * from Gen_Escort_Location where EscortId = {0}", _EscortId).LastOrDefault();
                        optDriver.Text = "Escort";
                    }
                    else
                    {
                        obj = db.ExecuteQuery<Fleet_Driver_Location>("Select * from Fleet_Driver_Location where DriverId = {0}", _DriverId).FirstOrDefault();
                        optDriver.Text = "Driver";
                    }

                    if (obj != null)
                    {
                        string locName = obj.LocationName;

                        if (markerDrv == null)
                        {
                            markerDrv = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(obj.Latitude), Convert.ToDouble(obj.Longitude)), null);




                            if (gMapControl1.Overlays.Count == 0)
                            {
                                GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlayJob");
                                gMapControl1.Overlays.Add(polyOverlay);

                            }

                            gMapControl1.Overlays[0].Markers.Add(markerDrv);
                        }
                        else
                            markerDrv.Position = new PointLatLng(Convert.ToDouble(obj.Latitude), Convert.ToDouble(obj.Longitude));


                        if (_EscortId == null)
                        {
                            markerDrv.Tag = "Driver";
                        }
                        else
                        {

                            markerDrv.Tag = "Escort";
                        }

                        string EstimatedTimeLeft = "";
                        //if (AppVars.objPolicyConfiguration.ClientType == "new")
                        //{

                        //if (AppVars.etaKey.ToStr().Length == 0)
                        //{

                        //        try
                        //        {

                        //            AppVars.etaKey = db.ExecuteQuery<string>("select apikey from mapkeys where maptype='here'").FirstOrDefault();


                        //            if (AppVars.etaKey.ToStr().Trim().Length == 0)
                        //                AppVars.etaKey = " ";

                        //            else
                        //            {
                        //                chkETA.Visible = true;


                        //            }
                        //        }
                        //        catch
                        //        {
                        //            AppVars.etaKey = " ";

                        //        }


                        //}
                        //else if (AppVars.etaKey.ToStr().Trim().Length > 0)
                        //{

                        //    chkETA.Visible = true;
                        //}

                        if (obj.Speed > 0 || (string.IsNullOrEmpty(markerDrv.PDALocationName)))
                        {

                            if (chkFullDetails.Checked || chkETA.Checked)
                            {


                                if (locName.ToStr().Trim().Length == 0)
                                {

                                    if (AppVars.googleKey.ToStr().Length == 0)
                                    {

                                        AppVars.googleKey = "&key=" + db.ExecuteQuery<string>("select apikey from mapkeys where maptype='google'").FirstOrDefault();
                                    }

                                    if (AppVars.googleKey.ToStr().Trim().Length > 8)
                                    {
                                        locName = GetLocationName(obj.Latitude, obj.Longitude);
                                    }

                                    if (locName.ToStr().Trim().Length == 0)
                                    {
                                        locName = db.PostCodesNearLatLong(obj.Latitude, obj.Longitude).FirstOrDefault().DefaultIfEmpty().Street.ToStr();
                                    }
                                }
                            }



                            if (chkETA.Checked)
                            {

                                if ((LastSpeed == null || LastSpeed != obj.Speed))
                                {

                                    if (oddCnt % 2 == 1)
                                    {

                                        try
                                        {


                                            GetDistance.Coords obj1 = new GetDistance.Coords { Latitude = obj.Latitude, Longitude = obj.Longitude };

                                            if (markerDrv.WorkStatus.ToStr() == "On Route" || markerDrv.WorkStatus.ToStr() == "Arrived")
                                            {
                                                GetDistance.Coords obj2 = new GetDistance.Coords { Latitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Pickup").Position.Lat, Longitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Pickup").Position.Lng };

                                                // EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);
                                                EstimatedTimeLeft = General.GetETATime(obj1.Latitude + "," + obj1.Longitude, obj2.Latitude + "," + obj2.Longitude, AppVars.etaKey);


                                                if (EstimatedTimeLeft.ToStr().Trim().Length > 0)
                                                {
                                                    EstimatedTimeLeft = "Pickup ETA : " + EstimatedTimeLeft;

                                                }

                                            }
                                            else if (markerDrv.WorkStatus.ToStr() == "Passenger On Board" || markerDrv.WorkStatus.ToStr() == "Soon To Clear")
                                            {
                                                if (gMapControl1.Overlays[0].Markers.Count > 2)
                                                {
                                                    GetDistance.Coords obj2 = new GetDistance.Coords { Latitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Destination").Position.Lat, Longitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Destination").Position.Lng };
                                                    //EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);
                                                    EstimatedTimeLeft = General.GetETATime(obj1.Latitude + "," + obj1.Longitude, obj2.Latitude + "," + obj2.Longitude, AppVars.etaKey);


                                                    if (EstimatedTimeLeft.ToStr().Trim().Length > 0)
                                                    {
                                                        EstimatedTimeLeft = "DropOff ETA : " + EstimatedTimeLeft;

                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        chkETA.Visible = false;
                                                    }
                                                    catch
                                                    {


                                                    }
                                                }
                                            }

                                        }
                                        catch
                                        {


                                        }

                                        lastETA = EstimatedTimeLeft;
                                    }
                                    else
                                        EstimatedTimeLeft = lastETA;


                                    oddCnt++;
                                }
                            }
                            else
                            {

                                EstimatedTimeLeft = lastETA;
                            }



                        }
                        else
                        {
                            if (obj.Speed == 0)
                            {

                                if (chkETA.Checked)
                                {

                                    if ((LastSpeed == null || lastETA == "" || LastSpeed != obj.Speed))
                                    {

                                        if (oddCnt % 2 == 1)
                                        {

                                            try
                                            {




                                                GetDistance.Coords obj1 = new GetDistance.Coords { Latitude = obj.Latitude, Longitude = obj.Longitude };

                                                if (markerDrv.WorkStatus.ToStr() == "On Route" || markerDrv.WorkStatus.ToStr() == "Arrived")
                                                {
                                                    GetDistance.Coords obj2 = new GetDistance.Coords { Latitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Pickup").Position.Lat, Longitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Pickup").Position.Lng };

                                                    // EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);
                                                    EstimatedTimeLeft = General.GetETATime(obj1.Latitude + "," + obj1.Longitude, obj2.Latitude + "," + obj2.Longitude, AppVars.etaKey);

                                                    if (EstimatedTimeLeft.ToStr().Trim().Length > 0)
                                                    {
                                                        EstimatedTimeLeft = "Pickup ETA : " + EstimatedTimeLeft;

                                                    }

                                                }
                                                else if (markerDrv.WorkStatus.ToStr() == "Passenger On Board" || markerDrv.WorkStatus.ToStr() == "Soon To Clear")
                                                {
                                                    if (gMapControl1.Overlays[0].Markers.Count > 2)
                                                    {
                                                        GetDistance.Coords obj2 = new GetDistance.Coords { Latitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Destination").Position.Lat, Longitude = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == "Destination").Position.Lng };

                                                        // EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);
                                                        EstimatedTimeLeft = General.GetETATime(obj1.Latitude + "," + obj1.Longitude, obj2.Latitude + "," + obj2.Longitude, AppVars.etaKey);


                                                        if (EstimatedTimeLeft.ToStr().Trim().Length > 0)
                                                        {
                                                            EstimatedTimeLeft = "DropOff ETA : " + EstimatedTimeLeft;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            chkETA.Visible = false;
                                                        }
                                                        catch
                                                        {


                                                        }
                                                    }
                                                }

                                            }
                                            catch
                                            {


                                            }

                                            lastETA = EstimatedTimeLeft;
                                        }
                                        else
                                            EstimatedTimeLeft = lastETA;


                                        oddCnt++;
                                    }
                                    else
                                        EstimatedTimeLeft = lastETA;
                                }

                            }


                        }
                        //    }

                        if (locName == "")
                        {
                            locName = markerDrv.PDALocationName.ToStr().Trim();


                        }




                        if (locName != "" && (string.IsNullOrEmpty(markerDrv.PDALocationName) || markerDrv.PDALocationName.Equals(locName) == false))
                        {
                            markerDrv.IsVisible = false;
                            markerDrv.PDALocationName = locName;
                            markerDrv.IsVisible = true;
                        }


                        if (DriverNo.ToStr().Trim().Length == 0)
                        {


                            try
                            {
                                if (_EscortId != null)
                                {
                                    var escort = db.ExecuteQuery<Gen_Escort>("Select * from Gen_Escort where Id = {0}", _EscortId).FirstOrDefault();
                                    DriverNo = escort.EscortNo.ToStr();
                                    DriverNo = "Escort : " + DriverNo.ToStr();
                                    if (escort.EscortName.ToStr().Trim().Length > 0)
                                    {
                                        DriverNo = "VehicleID :" + escort.EscortName.ToStr() + Environment.NewLine + DriverNo;
                                    }
                                }
                                else
                                {
                                    var drv = db.Fleet_Drivers.Where(c => c.Id == _DriverId).Select(c => new { c.DriverNo, c.DisplayName }).FirstOrDefault();
                                    DriverNo = drv.DriverNo.ToStr();
                                    DriverNo = "Driver : " + DriverNo.ToStr();

                                    if (drv.DisplayName.ToStr().Trim().Length > 0)
                                    {
                                        DriverNo = "VehicleID :" + drv.DisplayName.ToStr() + Environment.NewLine + DriverNo;
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        markerDrv.ToolTipText = DriverNo;

                        if (chkFullDetails.Checked || chkETA.Checked)
                        {
                            markerDrv.ToolTip.Font = smallFont;

                            markerDrv.ToolTipText += Environment.NewLine + locName.ToStr().ToUpper() + Environment.NewLine + "Speed: " + Math.Round(Convert.ToDouble(obj.Speed), 0) + "mph";
                        }
                        else if (chkFullDetails.Visible == false)
                        {
                            markerDrv.ToolTipText += Environment.NewLine + "Speed: " + Math.Round(Convert.ToDouble(obj.Speed), 0) + "mph";
                            markerDrv.ToolTip.Font = smallFont;

                        }
                        else if (chkFullDetails.Visible)
                        {

                            markerDrv.ToolTip.Font = largeFont;

                        }

                        if (ObjBooking != null && ObjBooking.DriverId != null && ObjBooking.DriverId == this._DriverId && !string.IsNullOrEmpty(EstimatedTimeLeft))
                        {
                            markerDrv.ToolTipText += Environment.NewLine + EstimatedTimeLeft;
                        }


                        LastSpeed = obj.Speed;

                        string imagePath = System.Windows.Forms.Application.StartupPath + "\\VehicleImages\\";
                        var queue = db.Fleet_DriverQueueLists.Where(c => c.Status == true && c.DriverId == this._DriverId)
                                    .Select(args => new { args.DriverWorkStatusId }).FirstOrDefault();
                        // var queue=obj.Fleet_Driver.Fleet_DriverQueueLists.OrderByDescending(c => c.Status == true).FirstOrDefault();



                        if (queue != null)
                        {

                            string status = "";

                            int StatusId = queue.DriverWorkStatusId.ToInt();



                            if (StatusId == Enums.Driver_WORKINGSTATUS.AVAILABLE)
                            {
                                imagePath += "diamond_Available.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "Available";
                            }

                            else if (StatusId == Enums.Driver_WORKINGSTATUS.ONROUTE)
                            {
                                imagePath += "diamond_OnRoute.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "On Route";
                            }
                            else if (StatusId == Enums.Driver_WORKINGSTATUS.ONBREAK)
                            {
                                imagePath += "diamond_OnBreak.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "OnBreak";
                            }


                            else if (StatusId == Enums.Driver_WORKINGSTATUS.ARRIVED)
                            {

                                imagePath += "diamond_Arrived.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "Arrived";
                            }

                            else if (StatusId == Enums.Driver_WORKINGSTATUS.NOTAVAILABLE)
                            {

                                imagePath += "diamond_PassengerOnBoard.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "Passenger On Board";
                            }
                            else if (StatusId == Enums.Driver_WORKINGSTATUS.SOONTOCLEAR)
                            {

                                imagePath += "diamond_SoonToClear.png";  //+ item.workstatus.Strip(' ') + ".png"
                                status = "Soon To Clear";
                            }


                            if (string.IsNullOrEmpty(markerDrv.WorkStatus) || markerDrv.WorkStatus.Equals(status) == false)
                            {
                                markerDrv.IsVisible = false;
                                markerDrv.WorkStatus = status.ToStr();
                                markerDrv.IsVisible = true;


                            }

                        }


                        if (File.Exists(imagePath))
                        {
                            markerDrv.MarkerImage = Image.FromFile(imagePath);
                        }

                        //   marker1.ToolTipText = "START at : " + string.Format("{0:HH:mm}", acceptDateTime);
                        markerDrv.ToolTipMode = MarkerTooltipMode.Always;



                        if (optDriver.Checked && markerDrv.Position.Lat != 0)
                        {


                            if (btnZoom.Tag != null || optDriver.Tag == null || ObjBooking == null)
                            {
                                optDriver.Tag = true;
                                SetPosition(markerDrv.Position.Lat, markerDrv.Position.Lng);
                            }

                        }

                        //if (ObjBooking == null)
                        //{
                        //    OnDisplayMap(null);

                        //}

                        gettingLocation = false;

                    }
                }
                gettingLocation = false;
            }
            catch (Exception ex)
            {

                gettingLocation = false;

            }


        }

        Font smallFont = new Font("Tahoma", 8, FontStyle.Bold);
        Font largeFont = new Font("Tahoma", 12, FontStyle.Bold);


        delegate void UIVoidDelegate2(double lat, double lng);

        private void SetPosition(double lat, double lng)
        {
            try
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new UIVoidDelegate2(SetPosition), lat, lng);
                else
                {
                    gMapControl1.Position = new PointLatLng(lat, lng);

                    if (gMapControl1.MinZoom == 2 && IsTrackDriver && ObjBooking == null)
                    {



                        gMapControl1.MinZoom = 0;
                        gMapControl1.MaxZoom = 24;
                        gMapControl1.Zoom = 18;
                        gMapControl1.DragButton = MouseButtons.Left;

                    }
                }
            }
            catch (Exception ex)
            {

                gettingLocation = false;

            }
        }




        private string DriverNo = "";


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (IsClosed)
                    return;


                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new UIVoidDelegate(RunUIThread));


                }
                else
                {
                    RunUIThread();


                }


            }
            catch (Exception ex)
            {




            }
        }


        private void RunUIThread()
        {

            try
            {
                gMapControl1.MapProvider = GMapProviders.BingMap;

                if (IsTrackDriver)
                {


                    CreateJobRouteDirection();

                    GetDriverLocation();
                    System.Threading.Thread.Sleep(1000);

                    if (timer1 == null)
                    {

                        timer1 = new Timer();
                        timer1.Interval = 6000;
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Start();

                    }
                }
                else
                {


                    try
                    {

                        DrawPolyVertices(7, 1, this.ObjBooking.Booking_RoutePaths);
                    }
                    catch (Exception ex)
                    {

                        if (ex.Message.ToLower().Contains("cross-thread"))
                        {
                            if (this.InvokeRequired)
                            {
                                this.BeginInvoke(new DrawUI(DrawPolyVertices), 7, 1, this.ObjBooking.Booking_RoutePaths);


                            }
                            else
                            {
                                DrawPolyVertices(7, 1, this.ObjBooking.Booking_RoutePaths);


                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {


            }
        }



        private bool IsClosed = false;
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IsClosed)
                    return;




                gMapControl1.Enabled = true;

                this.Size = new Size(this.Size.Width + 10, this.Size.Height + 10);


                if (IsAttached == false && IsTrackDriver)
                {
                    IsAttached = true;
                    optDriver.CheckedChanged += new EventHandler(optDriver_CheckedChanged);
                    optPickup.CheckedChanged += new EventHandler(optPickup_CheckedChanged);
                    optDestination.CheckedChanged += new EventHandler(optDestination_CheckedChanged);



                }





            }
            catch (Exception ex)
            {

            }
        }




        Timer timer1 = null;

        BackgroundWorker worker = null;
        private bool IsAttached = false;
        void rptJobRouthPath_Load(object sender, EventArgs e)
        {

            try
            {

                if (this.ObjBooking != null)
                {


                    if (IsTrackDriver)
                    {

                        if (worker == null)
                        {
                            worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                            worker.WorkerSupportsCancellation = true;
                        }

                        pnlZoom.BringToFront();
                        gMapControl1.Enabled = false;
                        grdLister.Visible = false;
                        worker.RunWorkerAsync();


                        //optDriver.CheckedChanged += new EventHandler(optDriver_CheckedChanged);
                        //optPickup.CheckedChanged += new EventHandler(optPickup_CheckedChanged);
                        //optDestination.CheckedChanged += new EventHandler(optDestination_CheckedChanged);
                    }
                    else
                    {

                        try
                        {

                            if (File.Exists(Application.StartupPath + "\\MapReportRecorder\\MapReportRecorder.exe"))
                            {
                                paths = Application.StartupPath + "\\MapReportRecorder\\ImagesOfVideo\\ImagesArray\\"; // @"E:\saveimage\New folder\"; 
                            }

                            trackBar1.Visible = true;
                            lblStart.Text = "(" + this.ObjBooking.AcceptedDateTime.ToDateTime().ToString("HH:mm") + ")";



                            trackBar1.Minimum = this.ObjBooking.AcceptedDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                            trackBar1.Value = this.ObjBooking.AcceptedDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                            if (ObjBooking.ClearedDateTime == null)
                            {
                                if (ObjBooking.STCDateTime == null)
                                {
                                    if (ObjBooking.POBDateTime == null)
                                    {
                                        if (ObjBooking.ArrivalDateTime == null)
                                        {
                                            trackBar1.Maximum = this.ObjBooking.AcceptedDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                            lblEnd.Text = "(" + this.ObjBooking.AcceptedDateTime.ToDateTime().ToString("HH:mm") + ")";
                                        }
                                        else
                                        {
                                            trackBar1.Maximum = this.ObjBooking.ArrivalDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                            lblEnd.Text = "(" + this.ObjBooking.ArrivalDateTime.ToDateTime().ToString("HH:mm") + ")";
                                        }
                                    }
                                    else
                                    {
                                        trackBar1.Maximum = this.ObjBooking.POBDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                                        lblEnd.Text = "(" + this.ObjBooking.POBDateTime.ToDateTime().ToString("HH:mm") + ")";
                                    }
                                }
                                else
                                {
                                    trackBar1.Maximum = this.ObjBooking.STCDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                                    lblEnd.Text = "(" + this.ObjBooking.STCDateTime.ToDateTime().ToString("HH:mm") + ")";
                                }
                            }
                            else
                            {
                                trackBar1.Maximum = this.ObjBooking.ClearedDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                lblEnd.Text = "(" + this.ObjBooking.ClearedDateTime.ToDateTime().ToString("HH:mm") + ")";
                            }
                        }
                        catch
                        {

                        }

                        pnlRouteActions.Visible = true;
                        pnlRouteActions.BringToFront();
                        int len = ObjBooking.FromAddress.ToStr().Length > ObjBooking.ToAddress.ToStr().Length ? ObjBooking.FromAddress.ToStr().Length
                                     : ObjBooking.ToAddress.ToStr().Length;

                        grdLister.AllowEditRow = false;
                        grdLister.AllowAddNewRow = false;

                        if (len >= 20 && len <= 30)
                        {
                            grdLister.Size = new Size(grdLister.Width, grdLister.Height - 28);
                        }
                        else if (len < 20)
                        {
                            grdLister.Size = new Size(grdLister.Width, grdLister.Height - 38);
                        }
                        else if (len > 60)
                        {
                            grdLister.Size = new Size(grdLister.Width, grdLister.Height + 25);
                        }

                        var row = grdLister.Rows.AddNew();

                        row.Cells["Drv"].Value = _EscortId == null ? ObjBooking.Fleet_Driver.DefaultIfEmpty().DriverNo : ObjBooking.Gen_Escort.DefaultIfEmpty().EscortNo;
                        row.Cells["Pickup"].Value = ObjBooking.FromAddress.ToStr();
                        row.Cells["Destination"].Value = ObjBooking.ToAddress.ToStr();
                        row.Cells["Accepted"].Value = string.Format("{0:dd/MM HH:mm}", ObjBooking.AcceptedDateTime);
                        row.Cells["Arrived"].Value = string.Format("{0:dd/MM HH:mm}", ObjBooking.ArrivalDateTime);
                        row.Cells["POB"].Value = string.Format("{0:dd/MM HH:mm}", ObjBooking.POBDateTime);
                        row.Cells["STC"].Value = string.Format("{0:dd/MM HH:mm}", ObjBooking.STCDateTime);
                        row.Cells["Cleared"].Value = string.Format("{0:dd/MM HH:mm}", ObjBooking.ClearedDateTime);
                        row.Cells["Miles"].Value = ObjBooking.TotalTravelledMiles;
                        grdLister.CellDoubleClick += GrdLister_CellDoubleClick;

                        if (worker == null)
                        {
                            worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                            worker.WorkerSupportsCancellation = true;
                        }



                        worker.RunWorkerAsync();

                    }
                }
                else
                {

                    if (IsTrackDriver)
                    {
                        this.Text = _EscortId == null ? "Track Driver" : "Track Escort";

                        if (worker == null)
                        {
                            worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                            worker.WorkerSupportsCancellation = true;
                        }

                        gMapControl1.Enabled = false;
                        grdLister.Visible = false;
                        chkFullDetails.Visible = true;
                        chkFullDetails.BringToFront();
                        worker.RunWorkerAsync();


                    }
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void GrdLister_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column != null)
                {
                    if (e.Column.Name.ToStr().ToUpper() == "POB")
                    {



                        if (this.ObjBooking.POBDateTime != null)
                        {
                            dtTrackBar = this.ObjBooking.POBDateTime.ToDateTime();



                            NavScrollBar(dtTrackBar);
                            try
                            {
                                trackBar1.Value = dtTrackBar.ToDateTime().Ticks.ToInt();
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (e.Column.Name.ToStr().ToUpper() == "ARRIVED")
                    {
                        if (this.ObjBooking.ArrivalDateTime != null)
                        {
                            dtTrackBar = this.ObjBooking.ArrivalDateTime.ToDateTime();
                            NavScrollBar(dtTrackBar);

                        }
                    }
                    else if (e.Column.Name.ToStr().ToUpper() == "STC")
                    {
                        if (this.ObjBooking.STCDateTime != null)
                        {
                            dtTrackBar = this.ObjBooking.STCDateTime.ToDateTime();

                            NavScrollBar(dtTrackBar);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        void optDestination_CheckedChanged(object sender, EventArgs e)
        {
            if (optDestination.Checked)
            {

                ZoomTo("Destination");
            }
        }

        void optPickup_CheckedChanged(object sender, EventArgs e)
        {
            if (optPickup.Checked)
            {

                ZoomTo("Pickup");
            }

        }

        void optDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (optDriver.Checked)
            {

                ZoomTo(_EscortId == null ? "Driver" : "Escort");
            }
        }

        private void ZoomTo(string option)
        {
            try
            {
                var obj = gMapControl1.Overlays[0].Markers.FirstOrDefault(c => c.Tag.ToStr() == option);

                if (obj != null)
                {
                    if (obj.Position != null && obj.Position.Lat != 0)
                    {

                        gMapControl1.Position = obj.Position;
                        gMapControl1.Zoom = 18;
                    }
                }

            }
            catch (Exception ex)
            {


            }

        }

        private void ZoomToPickup()
        {


        }


        private void ZoomToDestination()
        {



        }

        void timer1_Tick(object sender, EventArgs e)
        {
            GetDriverLocation();
        }



        delegate void DrawUI(int lineWeight, int lineForeColor, IList<Booking_RoutePath> list);

        private void DrawPolyVertices(int lineWeight, int lineForeColor, IList<Booking_RoutePath> listOfLocations)
        {
            try
            {
                pnlZoom.Visible = false;

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


                DateTime? acceptDateTime = this.ObjBooking.AcceptedDateTime;
                DateTime? arriveDateTime = this.ObjBooking.ArrivalDateTime;
                DateTime? pobDateTime = this.ObjBooking.POBDateTime;
                DateTime? stcDateTime = this.ObjBooking.STCDateTime;
                DateTime? clearedDateTime = this.ObjBooking.ClearedDateTime;

                Booking_RoutePath objRoute = null;


                if (acceptDateTime != null)
                {
                    objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == acceptDateTime || c.UpdateDate.Value.AddSeconds(30) > acceptDateTime);

                    if (objRoute != null)
                    {


                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objRoute.Latitude), Convert.ToDouble(objRoute.Longitude)), null);
                        marker1.ToolTipText = "START at : " + string.Format("{0:HH:mm}", acceptDateTime);
                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker1);
                    }

                }

                if (arriveDateTime != null)
                {
                    objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == arriveDateTime || c.UpdateDate.Value.AddSeconds(30) > arriveDateTime);

                    if (objRoute != null)
                    {

                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objRoute.Latitude), Convert.ToDouble(objRoute.Longitude)), Resources.Resource1.arrived);
                        marker1.ToolTipText = "ARRIVED at : " + string.Format("{0:HH:mm}", arriveDateTime);
                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker1);
                    }

                }


                if (pobDateTime != null)
                {
                    objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == pobDateTime || c.UpdateDate.Value.AddSeconds(30) > pobDateTime);

                    if (objRoute != null)
                    {



                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objRoute.Latitude), Convert.ToDouble(objRoute.Longitude)), Resources.Resource1.pob);
                        marker1.ToolTipText = "POB at : " + string.Format("{0:HH:mm}", pobDateTime);
                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker1);
                    }



                    try
                    {
                        if (grdLister.Rows[0].Cells["Miles"].Value.ToDecimal() == 0)
                        {

                            var listMiles = listOfLocations.Where(c => c.UpdateDate >= pobDateTime)
                                  .Select(a => new { a.Latitude, a.Longitude, a.UpdateDate }).ToList();


                            double mile = 0;
                            double mileValue = 0;
                            for (int i = 0; i < listMiles.Count; i++)
                            {
                                if (i + 1 < listMiles.Count)
                                {
                                    mileValue = new DotNetCoords.LatLng(Convert.ToDouble(listMiles[i].Latitude), Convert.ToDouble(listMiles[i].Longitude))
                                        .DistanceMiles(new DotNetCoords.LatLng(Convert.ToDouble(listMiles[i + 1].Latitude), Convert.ToDouble(listMiles[i + 1].Longitude)));


                                    if (mileValue > 0)
                                        mile += mileValue;

                                }
                            }


                            if (mile > 0)
                            {
                                grdLister.Rows[0].Cells["Miles"].Value = Math.Round(mile, 2);

                            }


                        }
                    }
                    catch
                    {

                    }
                }


                if (stcDateTime != null)
                {
                    objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == stcDateTime || c.UpdateDate.Value.AddSeconds(30) > stcDateTime);

                    if (objRoute != null)
                    {

                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objRoute.Latitude), Convert.ToDouble(objRoute.Longitude)), Resources.Resource1.stc);
                        marker1.ToolTipText = "STC at : " + string.Format("{0:HH:mm}", stcDateTime);
                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker1);
                    }

                }




                if (clearedDateTime != null)
                {
                    objRoute = listOfLocations.LastOrDefault();

                    if (objRoute != null)
                    {


                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objRoute.Latitude), Convert.ToDouble(objRoute.Longitude)), Resources.Resource1.clear);
                        marker1.ToolTipText = "FINISH at : " + string.Format("{0:HH:mm}", clearedDateTime);
                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker1);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //ENUtils.ShowMessage(ex.Message);

            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            SendEmail();
        }


        private void SendEmail()
        {
            try
            {
                string bookingNo = ObjBooking.BookingNo.ToStr().Replace("/", "").Replace("-", "");


                string path = Application.StartupPath + "\\" + "MapReportRef" + bookingNo + ".jpg";

                if (File.Exists(path))
                    File.Delete(path);

                System.Drawing.Point sp = gMapControl1.Location;
                System.Drawing.Size ds = gMapControl1.Size;
                System.Drawing.Rectangle sr = new System.Drawing.Rectangle(sp, ds);
                //Convert the Image to a JPG
                Image tmpImage;
                tmpImage = CaptureImage(sp, System.Drawing.Point.Empty, sr, "");
                tmpImage.Save(path);


                frmEmail frm = new frmEmail(tmpImage, path);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();


                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

            //General.ShowEmailForm(reportViewer1, "Account Invoice # " + invoiceNo, email);

        }

        SaveFileDialog sfd = new SaveFileDialog();


        private void SaveImage()
        {



        }

        public Image CaptureImage(System.Drawing.Point SourcePoint, System.Drawing.Point DestinationPoint, System.Drawing.Rectangle SelectionRectangle, string FilePath)
        {
            Image tmpImage;
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                //Convert the Image to a JPG
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                tmpImage = Image.FromStream(ms);
                return tmpImage;
            }
        }

        public bool stop = false;
        public bool pause = false;
        int startFrom = 0;
        GMapOverlay polyOverlay = null;
        GMapMarkerCustom marker14 = null;


        List<Booking_RoutePath> queryData = null;
        public void Navigation()
        {
            try
            {

                polyOverlay = gMapControl1.Overlays[0];
                //List<PointLatLng> points = new List<PointLatLng>();
                //polyOverlay = new GMapOverlay(gMapControl1, "overlay1");
                //IList<Booking_RoutePath> listOfLocations = this.ObjBooking.Booking_RoutePaths;

                //points = listOfLocations
                //       .Select(args => new PointLatLng
                //       {
                //           Lat = Convert.ToDouble(args.Latitude),
                //           Lng = Convert.ToDouble(args.Longitude)

                //       }).ToList();

                //GMapRoute route = new GMapRoute(points, "route1");
                //route.Stroke = new Pen(Color.DodgerBlue, 7);


                //polyOverlay.Routes.Add(route);

                //gMapControl1.Overlays.Add(polyOverlay);


                DateTime? acceptDateTime = this.ObjBooking.AcceptedDateTime;
                DateTime? arriveDateTime = this.ObjBooking.ArrivalDateTime;
                DateTime? pobDateTime = this.ObjBooking.POBDateTime;
                DateTime? stcDateTime = this.ObjBooking.STCDateTime;
                DateTime? clearedDateTime = this.ObjBooking.ClearedDateTime;

                var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);


                List<Booking_RoutePath> queryData2 = null;

                if (queryData == null)
                    queryData = General.GetQueryable<Booking_RoutePath>(c => c.BookingId == ObjBooking.Id).ToList();



                queryData2 = queryData.Where(c => c.BookingId == ObjBooking.Id && c.UpdateDate >= dtTrackBar).ToList();


                // var query = General.GetQueryable<Booking_RoutePath>(c => c.BookingId == ObjBooking.Id).ToList();
                var driverno = _EscortId == null ? ObjBooking.Fleet_Driver.DriverNo : ObjBooking.Gen_Escort?.EscortNo;
                // var driverno = General.GetObject<Fleet_Driver>(c=>c.booking

                Font f = new Font("Tahoma", 6, FontStyle.Bold);



                bool isTrue = false;
                for (int i = startFrom; i < queryData2.Count(); i++)
                {
                    if (pause)
                    {

                        startFrom = i;


                        if (marker14 == null)
                            marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude)), null);
                        else
                            marker14.Position = new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude));

                        marker14.MarkerImage = bmp;
                        marker14.ToolTipText = _EscortId == null ? "Driver " : "Escort" + driverno;
                        marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", queryData2[i].UpdateDate);

                        marker14.ToolTipMode = MarkerTooltipMode.Always;
                        marker14.ToolTip.Font = f;

                        if (polyOverlay.Markers.Count == 0)
                            polyOverlay.Markers.Add(marker14);

                        break;

                    }
                    else
                    {
                        if (stop == true)
                        {


                            //   polyOverlay.Markers.Remove(marker14);
                            //  marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(query[0].Latitude), Convert.ToDouble(query[0].Longitude)), null);

                            if (marker14 == null)
                                marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude)), null);
                            else
                            {
                                marker14.Position = new PointLatLng(Convert.ToDouble(queryData2[0].Latitude), Convert.ToDouble(queryData2[0].Longitude));

                                //  marker14.Position.Lat = marker14.P(Convert.ToDouble(query[0].Latitude));

                            }


                            marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;
                            marker14.ToolTipText = _EscortId == null ? "Driver " : "Escort" + driverno;
                            marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", queryData2[i].UpdateDate);

                            marker14.ToolTipMode = MarkerTooltipMode.Always;
                            marker14.ToolTip.Font = f;

                            if (polyOverlay.Markers.Count == 0)
                                polyOverlay.Markers.Add(marker14);


                            this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                gMapControl1.Position = new PointLatLng(Convert.ToDouble(queryData2[0].Latitude), Convert.ToDouble(queryData2[0].Longitude));
                                if (ObjBooking.TotalTravelledMiles <= 5)
                                {
                                    gMapControl1.MinZoom = 0;
                                    gMapControl1.MaxZoom = 24;
                                    gMapControl1.Zoom = 15;
                                }
                                else
                                {
                                    gMapControl1.MinZoom = 0;
                                    gMapControl1.MaxZoom = 24;
                                    gMapControl1.Zoom = 13;
                                }

                            });



                            break;

                        }
                        if (stop == false)
                        {

                            isTrue = false;

                            //marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(query[i].Latitude), Convert.ToDouble(query[i].Longitude)), null);

                            if (marker14 == null)
                            {
                                marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude)), null);
                                polyOverlay.Markers.Add(marker14);
                            }
                            else
                                marker14.Position = new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude));



                            if (marker14.MarkerImage == null)
                                marker14.MarkerImage = bmp;

                            marker14.ToolTipText = _EscortId == null ? "Driver " : "Escort" + driverno;
                            marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", queryData2[i].UpdateDate);

                            marker14.ToolTipMode = MarkerTooltipMode.Always;
                            marker14.ToolTip.Font = f;



                            if (clearedDateTime != null)
                            {
                                if (i == queryData2.Count || queryData2[i].UpdateDate.Value >= clearedDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(15) > clearedDateTime.Value)
                                {

                                    isTrue = true;
                                    //  polyOverlay.Markers.Remove(marker14);
                                    //    bmp = new Bitmap();
                                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;
                                }
                            }


                            if (isTrue == false && stcDateTime != null)
                            {

                                if (queryData2[i].UpdateDate.Value >= stcDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > stcDateTime.Value)
                                {
                                    isTrue = true;
                                    //   polyOverlay.Markers.Remove(marker14);
                                    //  bmp = new Bitmap();
                                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;
                                    //    polyOverlay.Markers.Add(marker14);
                                }

                            }

                            if (isTrue == false && pobDateTime != null)
                            {
                                if (queryData2[i].UpdateDate.Value >= pobDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > pobDateTime.Value)
                                {
                                    isTrue = true;
                                    //   polyOverlay.Markers.Remove(marker14);
                                    //  bmp = new Bitmap();
                                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;
                                    //    polyOverlay.Markers.Add(marker14);
                                }

                            }


                            if (isTrue == false && arriveDateTime != null)
                            {
                                if (queryData[i].UpdateDate.Value >= arriveDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(10) > arriveDateTime.Value)
                                {
                                    isTrue = true;
                                    //  polyOverlay.Markers.Remove(marker14);
                                    //   bmp = new Bitmap();
                                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;
                                    //  polyOverlay.Markers.Add(marker14);
                                }

                            }

                            if (isTrue == false && acceptDateTime != null)
                            {
                                //objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == acceptDateTime || c.UpdateDate.Value.AddSeconds(30) > acceptDateTime);

                                if (acceptDateTime != null)
                                {
                                    if (queryData2[i].UpdateDate.Value >= acceptDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > acceptDateTime.Value)
                                    {
                                        isTrue = true;
                                        //    isTrue = true;
                                        //   polyOverlay.Markers.Remove(marker14);
                                        marker14.MarkerImage = bmp;
                                        //   polyOverlay.Markers.Add(marker14);
                                    }
                                }

                            }



                            if (i < queryData2.Count)
                                this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude));
                                    //if (ObjBooking.TotalTravelledMiles <= 5)
                                    //{
                                    //    gMapControl1.MinZoom = 0;
                                    //    gMapControl1.MaxZoom = 24;
                                    //    gMapControl1.Zoom = 15;
                                    //}
                                    //else
                                    //{
                                    //    gMapControl1.MinZoom = 0;
                                    //    gMapControl1.MaxZoom = 24;
                                    //    gMapControl1.Zoom = 13;
                                    //}

                                });



                            //  polyOverlay.Markers.Remove(marker14);

                            if (polyOverlay.Markers.Count == 0)
                                polyOverlay.Markers.Add(marker14);
                            if (ObjBooking.TotalTravelledMiles <= 5)
                            {
                                System.Threading.Thread.Sleep(100);
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(50);

                            }

                            //   polyOverlay.Markers.Remove(marker14);

                        }


                        GC.Collect();
                    }


                }

                DisposeTimer();

                if (btnPlayNav.Enabled == false && pause == false)
                {
                    this.btnPlayNav.BeginInvoke((MethodInvoker)delegate () { btnPlayNav.Enabled = true; });
                }
                if (btnRecordingPlay.Enabled == false)
                {


                    //this.btnPauseNav.BeginInvoke((MethodInvoker)delegate() { btnPauseNav.Enabled = true; btnPlayNav.Enabled = true; btnStopNav.Enabled = true; btnRecordingPlay.Enabled = true; timer2.Stop();
                    //int port = Int32.Parse(AppVars.objSubCompany.SmtpPort);

                    //string host = AppVars.objSubCompany.SmtpHost.ToStr() + "," + AppVars.objSubCompany.SmtpPort.ToInt() + "," + AppVars.objSubCompany.SmtpUserName.ToStr();// objLic.HostName.ToStr() + " , " + objLic.SmtpPort.ToStr() + " , " + objLic.EnableSSL.ToBool();
                    //string username = AppVars.objSubCompany.SmtpPassword.ToStr();
                    //System.Diagnostics.Process p = new System.Diagnostics.Process();
                    //p.StartInfo.FileName = Application.StartupPath + "\\MapReportRecorder.exe";
                    //p.StartInfo.Arguments = host + "," + username;
                    //p.Start();

                    //this.MaximizeBox = true;
                    //this.MinimizeBox = true;
                    //this.Close();
                    //});



                    if (IsEmailRecording)
                    {


                        this.btnPauseNav.BeginInvoke((MethodInvoker)delegate ()
                        {
                            btnPauseNav.Enabled = true; btnPlayNav.Enabled = true; btnStopNav.Enabled = true; btnRecordingPlay.Enabled = true; timer2.Stop();
                            int port = Int32.Parse(AppVars.objSubCompany.SmtpPort);

                            string host = AppVars.objSubCompany.SmtpHost.ToStr() + "," + AppVars.objSubCompany.SmtpPort.ToInt() + "," + AppVars.objSubCompany.SmtpUserName.ToStr();// objLic.HostName.ToStr() + " , " + objLic.SmtpPort.ToStr() + " , " + objLic.EnableSSL.ToBool();
                            string username = AppVars.objSubCompany.SmtpPassword.ToStr();
                            System.Diagnostics.Process p = new System.Diagnostics.Process();




                            string path = Application.StartupPath + "\\MapReportRecorder.exe";



                            if (File.Exists(Application.StartupPath + "\\MapReportRecorder\\MapReportRecorder.exe"))
                            {


                                path = Application.StartupPath + "\\MapReportRecorder\\MapReportRecorder.exe";
                            }

                            p.StartInfo.FileName = path;
                            p.StartInfo.Arguments = host + "," + username + "," + AppVars.objSubCompany.SmtpHasSSL.ToBool().ToStr();
                            p.Start();

                            this.MaximizeBox = true;
                            this.MinimizeBox = true;
                            this.Close();
                        });

                    }

                }

            }
            catch
            {


            }
            //                   query[i].Latitude

        }

        bool IsEmailRecording;

        private void btnPlayNav_Click(object sender, EventArgs e)
        {
            try
            {
                PlayRecordingByTrackBar();

                IsEmailRecording = false;
                trackBar1.Enabled = false;
                btnRecordingPlay.Enabled = false;
                btnPlayNav.Enabled = false;
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(Navigation));
                if (th.ThreadState != System.Threading.ThreadState.Running)
                {
                    stop = false;
                    pause = false;
                    startFrom = 0;


                    if (btnPauseNav.Text == "Resume")
                    {
                        btnPauseNav.Text = "Pause";
                        pause = false;

                    }


                    //  th.IsBackground = true;
                    th.Start();
                } //  th.IsBackground = true;
                btnPlayNav.Enabled = false;
            }
            catch (Exception ex)
            { }

        }

        private void btnPauseNav_Click(object sender, EventArgs e)
        {
            try
            {
                if (pause == false)
                {
                    btnPauseNav.Text = "Resume";
                    pause = true;
                }
                else if (pause == true)
                {
                    //  polyOverlay.Markers.Remove(marker14);
                    btnPauseNav.Text = "Pause";
                    pause = false;
                    System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(Navigation));

                    th.Start();

                }
            }
            catch (Exception ex)
            { }
        }

        private void btnStopNav_Click(object sender, EventArgs e)
        {
            try
            {
                btnRecordingPlay.Enabled = true;
                trackBar1.Enabled = true;
                trackBar1.Value = this.ObjBooking.AcceptedDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                stop = true;

                var query = General.GetObject<Booking_RoutePath>(c => c.BookingId == ObjBooking.Id);

                if (query != null)
                {

                    if (marker14 == null)
                        marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(query.Latitude), Convert.ToDouble(query.Longitude)), null);
                    else
                        marker14.Position = new PointLatLng(Convert.ToDouble(query.Latitude), Convert.ToDouble(query.Longitude));


                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;
                    marker14.ToolTipText = _EscortId == null ? "Driver " + ObjBooking.Fleet_Driver.DriverNo : "Escort" + ObjBooking.Gen_Escort?.EscortNo;
                    marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", query.UpdateDate);

                    marker14.ToolTipMode = MarkerTooltipMode.Always;
                    marker14.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);

                    btnPauseNav.Text = "Pause";
                    pause = false;


                    this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        gMapControl1.Position = new PointLatLng(Convert.ToDouble(query.Latitude), Convert.ToDouble(query.Longitude));
                        if (ObjBooking.TotalTravelledMiles <= 5)
                        {
                            gMapControl1.MinZoom = 0;
                            gMapControl1.MaxZoom = 24;
                            gMapControl1.Zoom = 15;
                        }
                        else
                        {
                            gMapControl1.MinZoom = 0;
                            gMapControl1.MaxZoom = 24;
                            gMapControl1.Zoom = 13;
                        }

                    });
                }


                if (btnPlayNav.Enabled == false)
                {
                    btnPlayNav.Enabled = true;

                    GC.Collect();

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PlayRecordingByTrackBar()
        {
            try
            {

                DateTime dt = ObjBooking.AcceptedDateTime.ToDateTime();

                int val = trackBar1.Value.ToInt();

                TimeSpan time = TimeSpan.FromSeconds(val);

                DateTime date = ObjBooking.AcceptedDateTime.ToDate();
                dtTrackBar = date + time;
                if (scroll == false)
                {
                    if (this.grdLister.CurrentCell.ColumnInfo.Name == "Arrived" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
                    {
                        dtTrackBar = ObjBooking.ArrivalDateTime.ToDateTime();

                    }
                    else if (this.grdLister.CurrentCell.ColumnInfo.Name == "POB" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
                    {

                        dtTrackBar = ObjBooking.POBDateTime.ToDateTime();
                    }
                    else if (this.grdLister.CurrentCell.ColumnInfo.Name == "STC" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
                    {
                        dtTrackBar = ObjBooking.STCDateTime.ToDateTime();
                    }
                }



            }
            catch (Exception ex)
            { }
        }

        private void DisposeTimer()
        {
            try
            {
                if (timerRecording != null)
                {
                    timerRecording.Dispose();
                    timerRecording = null;


                }
            }
            catch
            {

            }
        }

        private void btnRecordingPlay_Click(object sender, EventArgs e)
        {

            try
            {

                PlayRecordingByTrackBar();

                stop = false;
                //if (ObjBooking.TotalTravelledMiles <= 5)
                //{

                //    timer2.Start();
                //}
                //if (ObjBooking.TotalTravelledMiles > 5 && ObjBooking.TotalTravelledMiles <= 15)
                //{
                //    timer2.Interval = 330;
                //    timer2.Start();
                //}
                //if (ObjBooking.TotalTravelledMiles > 15)
                //{
                //    timer2.Interval = 530;
                //    timer2.Start();
                //}


                DisposeTimer();
                timerRecording = new System.Threading.Timer(new System.Threading.TimerCallback(CaptureScreen), null, 650, 650);


                btnPauseNav.Enabled = false;
                btnPlayNav.Enabled = false;
                btnStopNav.Enabled = false;
                trackBar1.Enabled = false;
                btnRecordingPlay.Enabled = false;

                System.IO.DirectoryInfo di = new DirectoryInfo(paths);

                if (Directory.Exists(paths) == false)
                {
                    Directory.CreateDirectory(paths);
                }
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                IsEmailRecording = true;

                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(Navigation));
                if (th.IsAlive == false)
                {
                    //  th.IsBackground = true;
                    th.Start();
                }
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                this.MaximizeBox = false;
                this.MinimizeBox = false;

            }
            catch (Exception ex)
            { }


        }

        int i = 0;


        Bitmap bmp;
        Graphics gr;
        public static void SaveJpeg(string path, Image img, int quality, string value)
        {
            try
            {
                if (quality < 0 || quality > 100)
                    throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

                // Encoder parameter for image quality 
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                // JPEG image codec 
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                img.Save(path + value, jpegCodec, encoderParams);
            }
            catch (Exception ex)
            { }
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            try
            {
                // Get image codecs for all image formats 
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

                // Find the correct image codec 
                for (int i = 0; i < codecs.Length; i++)
                    if (codecs[i].MimeType == mimeType)
                        return codecs[i];

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        string paths = Application.StartupPath + "\\ImagesOfVideo\\ImagesArray\\"; // @"E:\saveimage\New folder\"; 
        private void timer2_Tick_1(object sender, EventArgs e)
        {

            CaptureScreen(null);
        }

        private void CaptureScreen(object o)
        {
            try
            {

                bmp = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));

                i++;


                SaveJpeg(paths, bmp, 50, "mygif" + i + " .png");

                //  bmp.Save("mygif" + i +" .gif", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            { }
        }

        private void rptJobRouthPathGoogle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                Close();
            }
            else
            {
                if (IsTrackDriver)
                {
                    if (e.KeyCode == Keys.Subtract)
                    {
                        int zoom = gMapControl1.Zoom.ToInt() - 1;
                        if (gMapControl1.MinZoom <= zoom)
                            gMapControl1.Zoom = zoom;
                    }
                    else if (e.KeyCode == Keys.Add)
                    {
                        int zoom = gMapControl1.Zoom.ToInt() + 1;

                        if (gMapControl1.MaxZoom >= zoom)
                            gMapControl1.Zoom = zoom;
                    }

                    //else if(e.KeyCode== Keys.A)
                    //{
                    //    ZoomClick();

                    //}
                    //else if(e.KeyCode== Keys.E)
                    //{

                    //    chkETA.Checked = chkETA.Checked ? false : true;

                    //}
                    pnlZoom.Focus();



                }


            }
        }

        public string GetLocationName(double? latitude, double? longitude)
        {
            string locationName = string.Empty;
            try
            {
                // Starts Google Geocoding Webservice

                string url2 = string.Empty;
                DataTable dt = null;
                XmlTextReader reader = null;
                System.Data.DataSet ds = null;


                try
                {

                    url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + AppVars.googleKey + "&sensor=false";

                    reader = new XmlTextReader(url2);
                    reader.WhitespaceHandling = WhitespaceHandling.Significant;
                    ds = new System.Data.DataSet();
                    ds.ReadXml(reader);

                    dt = ds.Tables["result"];

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        DataRow row = dt.Rows.OfType<DataRow>().FirstOrDefault();
                        if (row != null)
                        {
                            locationName = row[1].ToStr().Trim();
                        }
                    }

                    ds.Dispose();


                }
                catch (Exception ex)
                {
                    try
                    {

                        File.AppendAllText(System.Windows.Forms.Application.StartupPath + "\\" + "exception_google.txt", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ":" + ex.Message + Environment.NewLine);
                    }
                    catch
                    {


                    }
                }

            }
            catch (Exception ex)
            {


            }


            return locationName;
        }

        private void chkETA_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {

                GetDriverLocation();
            }

            SetFocus();
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            ZoomClick();
        }


        private void ZoomClick()
        {
            if (btnZoom.Tag == null)
            {
                btnZoom.Tag = true;
                btnZoom.Text = "&Auto On";
            }
            else
            {
                btnZoom.Tag = null;
                btnZoom.Text = "&Auto Off";
            }

            if (btnZoom.Tag != null)
            {

                if (optDriver.Checked)
                    ZoomTo(_EscortId == null ? "Driver" : "Escort");
                else if (optPickup.Checked)
                    ZoomToPickup();
                else if (optDestination.Checked)
                    ZoomToDestination();

            }


            SetFocus();
        }


        private void SetFocus()
        {

            if (optDriver.Checked)
                optDriver.Focus();
            else if (optPickup.Checked)
                optPickup.Focus();
            else if (optDestination.Checked)
                optDestination.Focus();
        }

        DateTime dtTrackBar = DateTime.Now;
        private void grdLister_Click(object sender, EventArgs e)
        {


            if (grdLister.CurrentCell.ColumnInfo.Name == "Arrived" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
            {
                dtTrackBar = ObjBooking.ArrivalDateTime.ToDateTime();
                trackBar1.Value = ObjBooking.ArrivalDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                scroll = false;
            }
            else if (grdLister.CurrentCell.ColumnInfo.Name == "POB" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
            {
                scroll = false;
                dtTrackBar = ObjBooking.POBDateTime.ToDateTime();
                trackBar1.Value = ObjBooking.POBDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
            }
            else if (grdLister.CurrentCell.ColumnInfo.Name == "STC" && grdLister.CurrentCell.Value.ToStr() != string.Empty)
            {
                dtTrackBar = ObjBooking.STCDateTime.ToDateTime();
                trackBar1.Value = ObjBooking.STCDateTime.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                scroll = false;
            }
            NavScrollBar(dtTrackBar);
        }
        bool scroll = true;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                scroll = true;

                int val = trackBar1.Value.ToInt();

                TimeSpan time = TimeSpan.FromSeconds(val);

                DateTime date = ObjBooking.AcceptedDateTime.ToDate();
                dtTrackBar = date + time;

                NavScrollBar(dtTrackBar);


            }
            catch (Exception)
            {

                //   throw;
            }
        }

        private string DriverNo2 = "";

        private void NavScrollBar(DateTime dt)
        {

            DateTime? acceptDateTime = this.ObjBooking.AcceptedDateTime;
            DateTime? arriveDateTime = this.ObjBooking.ArrivalDateTime;
            DateTime? pobDateTime = this.ObjBooking.POBDateTime;
            DateTime? stcDateTime = this.ObjBooking.STCDateTime;
            DateTime? clearedDateTime = this.ObjBooking.ClearedDateTime;
            var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

            polyOverlay = gMapControl1.Overlays[0];



            if (DriverNo2.Length == 0)
                DriverNo2 = _EscortId == null ? ObjBooking.Fleet_Driver.DriverNo : ObjBooking.Gen_Escort?.EscortNo;





            List<Booking_RoutePath> queryData2 = null;

            if (queryData == null)
                queryData = General.GetQueryable<Booking_RoutePath>(c => c.BookingId == ObjBooking.Id).ToList();



            queryData2 = queryData.Where(c => c.BookingId == ObjBooking.Id && c.UpdateDate >= dtTrackBar).ToList();


            Font f = new Font("Tahoma", 6, FontStyle.Bold);

            bool isTrue = false;
            if (queryData2.Count > 0)
            {


                if (marker14 == null)
                {
                    marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude)), null);
                    polyOverlay.Markers.Add(marker14);
                }
                else
                    marker14.Position = new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude));



                if (marker14.MarkerImage == null)
                    marker14.MarkerImage = bmp;

                marker14.ToolTipText = _EscortId == null ? "Driver " : "Escort " + DriverNo2;
                marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", queryData2[i].UpdateDate);

                marker14.ToolTipMode = MarkerTooltipMode.Always;
                marker14.ToolTip.Font = f;



                this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                {
                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(queryData2[i].Latitude), Convert.ToDouble(queryData2[i].Longitude));
                    if (ObjBooking.TotalTravelledMiles <= 5)
                    {
                        gMapControl1.MinZoom = 0;
                        gMapControl1.MaxZoom = 24;
                        gMapControl1.Zoom = 15;
                    }
                    else
                    {
                        gMapControl1.MinZoom = 0;
                        gMapControl1.MaxZoom = 24;
                        gMapControl1.Zoom = 13;
                    }

                });

                if (clearedDateTime != null)
                {
                    if (i == queryData2.Count || queryData2[i].UpdateDate.Value >= clearedDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(15) > clearedDateTime.Value)
                    {

                        isTrue = true;
                        //  polyOverlay.Markers.Remove(marker14);
                        //    bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;
                    }
                }


                if (isTrue == false && stcDateTime != null)
                {

                    if (queryData2[i].UpdateDate.Value >= stcDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > stcDateTime.Value)
                    {
                        isTrue = true;
                        //   polyOverlay.Markers.Remove(marker14);
                        //  bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;
                        //    polyOverlay.Markers.Add(marker14);
                    }

                }

                if (isTrue == false && pobDateTime != null)
                {
                    if (queryData2[i].UpdateDate.Value >= pobDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > pobDateTime.Value)
                    {
                        isTrue = true;
                        //   polyOverlay.Markers.Remove(marker14);
                        //  bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;
                        //    polyOverlay.Markers.Add(marker14);
                    }

                }


                if (isTrue == false && arriveDateTime != null)
                {
                    if (queryData2[i].UpdateDate.Value >= arriveDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(10) > arriveDateTime.Value)
                    {
                        isTrue = true;
                        //  polyOverlay.Markers.Remove(marker14);
                        //   bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;
                        //  polyOverlay.Markers.Add(marker14);
                    }

                }

                if (isTrue == false && acceptDateTime != null)
                {
                    //objRoute = listOfLocations.FirstOrDefault(c => c.UpdateDate == acceptDateTime || c.UpdateDate.Value.AddSeconds(30) > acceptDateTime);

                    if (acceptDateTime != null)
                    {
                        if (queryData2[i].UpdateDate.Value >= acceptDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > acceptDateTime.Value)
                        {
                            isTrue = true;
                            //    isTrue = true;
                            //   polyOverlay.Markers.Remove(marker14);
                            marker14.MarkerImage = bmp;
                            //   polyOverlay.Markers.Add(marker14);
                        }
                    }

                }

                //  polyOverlay.Markers.Remove(marker14);

                if (polyOverlay.Markers.Count == 0)
                    polyOverlay.Markers.Add(marker14);
                if (ObjBooking.TotalTravelledMiles <= 5)
                {
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    System.Threading.Thread.Sleep(50);

                }

            }
        }

        private void chkShowPlots_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPlots.Checked)
                DrawPlotsOnMap(true);
            else
                DrawPlotsOnMap(false);
        }
    }
}
