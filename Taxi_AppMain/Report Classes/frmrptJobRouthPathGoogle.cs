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
using Taxi_AppMain.Classes;
using GMap.NET.WindowsForms.ToolTips;
using Telerik.WinControls.UI;
using System.Globalization;

namespace Taxi_AppMain
{
    public partial class frmrptJobRouthPathGoogle : Form
    {
        private const string Format = "yyyyMMddHHmmss";
        private Booking _ObjBooking;

        public Booking ObjBooking
        {
            get { return _ObjBooking; }
            set { _ObjBooking = value; }
        }

        public struct COLS
        {
            public static string ID = "Id";
            public static string BookingNo = "BookingNo";
            public static string Pickupdatetime = "Pickupdatetime";
            public static string AcceptedDateTime = "AcceptedDateTime";
            public static string Cleareddatetime = "Cleareddatetime";
            public static string POBDateTime = "POBDateTime";
            public static string STCDateTime = "STCDateTime";
            public static string ArrivalDateTime = "ArrivalDateTime";


        }


        public frmrptJobRouthPathGoogle()
        {
            InitializeComponent();
        }


        private int _DriverId;

        private bool IsTrackDriver;


        System.Threading.Timer timerRecording = null;

        //for
        public frmrptJobRouthPathGoogle(Booking obj, bool TrackDriver)
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

        //-------------------------------------------------------------------------------------------------
        //ToDo: Added by noshad 08/07/2021
        List<PointLatLng> newpoints = new List<PointLatLng>();
        public LatLngDateFrmAndTo objset = new LatLngDateFrmAndTo();
        public StringBuilder strbobj = null;
        public static string bookingid = string.Empty;
        IList<Gen_Zone> zonelist = null;
        IList<Fleet_Driver> DriverList = null;
        public List<CoordinatesWithUpdatedDate> cooddt = null;
        public List<CoordinatesWithUpdatedDate> dynami = null;

        public frmrptJobRouthPathGoogle(LatLngDateFrmAndTo obj, List<CoordinatesWithUpdatedDate> lst)
        {
            InitializeComponent();

            IsTrackDriver = false;

            newpoints = obj.latlnglist;

            objset.latlnglist = obj.latlnglist;
            objset.ListOfUpdatedDate = obj.ListOfUpdatedDate;

            var firstcount = lst.FirstOrDefault();
            var lastcount = lst.LastOrDefault();
            this._DriverId = (int)firstcount.driverid;
            this.DriverNo2 = firstcount.driverid.ToStr();
            objset.BookId = obj.BookId;
            var list = obj.BookId.ToString();

            bookingid = list.Remove(list.Length - 1);
            cooddt = lst;
            using (TaxiDataContext db = new TaxiDataContext())
            {
                zonelist = db.Gen_Zones.ToList();
                DriverList = db.Fleet_Drivers.ToList();

            }

            grdLister.Visible = false;
            this.FormClosing += new FormClosingEventHandler(rptJobRouthPath_FormClosing);
            this.Load += new EventHandler(rptJobRouthPath_Load);

        }

        //ToDo:Added By Noshad Ali

        private void CreateJobRouteDirectionOnLatLng(List<PointLatLng> points)
        {
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



                if (IsTrackDriver && AppVars.objPolicyConfiguration.ClientType == "new")
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

        //-------------------------------------------------------------------------------------------------

        public frmrptJobRouthPathGoogle(Booking obj, bool TrackDriver, int driverId)
        {
            InitializeComponent();
            this.ObjBooking = obj;
            IsTrackDriver = TrackDriver;
            this._DriverId = driverId;
            this.FormClosing += new FormClosingEventHandler(rptJobRouthPath_FormClosing);
            this.Load += new EventHandler(rptJobRouthPath_Load);
            this.Shown += new EventHandler(rptJobRouthPathGoogle_Shown);
        }

        void rptJobRouthPathGoogle_Shown(object sender, EventArgs e)
        {
            BringToFront();
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
                    gMapControl1.Dispose();

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
            //if (ObjBooking == null)
            //  return;
            try
            {

                //string origin =General.GetPostCodeMatch(ObjBooking.FromAddress);
                //string destination = General.GetPostCodeMatch(ObjBooking.ToAddress);

                List<PointLatLng> points = new List<PointLatLng>();

                try
                {
                    /*
                    if (string.IsNullOrEmpty(origin)  )
                    {

                        string baseAddress =General.GetPostCodeMatch( AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper());

                        if (!string.IsNullOrEmpty(baseAddress))
                        {

                            var objCoordinate = General.GetObject<Gen_Coordinate>(c => c.PostCode == baseAddress);

                            if (objCoordinate != null)
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude),Convert.ToDouble(objCoordinate.Longitude)));

                            }
                        
                        
                        }

                    }
                    else if(!string.IsNullOrEmpty(origin) )
                    {

                        string pickup =General.GetPostCodeMatch( ObjBooking.FromAddress.ToStr().ToUpper());

                        if (!string.IsNullOrEmpty(pickup))
                        {

                            var objCoordinate = General.GetObject<Gen_Coordinate>(c => c.PostCode == pickup);

                            if (objCoordinate != null)
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude), Convert.ToDouble(objCoordinate.Longitude)));
                            }
                            else
                            {

                                using (TaxiDataContext db = new TaxiDataContext())
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

                    }


                    if (string.IsNullOrEmpty(destination))
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {

                            var objCoord=  db.stp_getCoordinatesByAddress(ObjBooking.ToAddress.ToStr(), destination).FirstOrDefault(); ;


                            if (objCoord != null)
                            {
                                if (objCoord != null)
                                {
                                    points.Add(new PointLatLng(Convert.ToDouble(objCoord.Latitude), Convert.ToDouble(objCoord.Longtiude)));

                                }

                            }
                        }                 

                    }


                    else if (!string.IsNullOrEmpty(destination))
                    {

                        var objCoordinate = General.GetObject<Gen_Coordinate>(c => c.PostCode == destination);

                        if (objCoordinate != null)
                        {
                            points.Add(new PointLatLng(Convert.ToDouble(objCoordinate.Latitude), Convert.ToDouble(objCoordinate.Longitude)));
                        }
                        else
                        {


                            using (TaxiDataContext db = new TaxiDataContext())
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
                   
                    */

                }
                catch
                {

                }




                if (objset.latlnglist.Count > 0)
                {

                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new UIParameterizedDelegate(OnDisplayMap), objset.latlnglist);


                    }
                    else
                    {
                        OnDisplayMap(objset.latlnglist);


                    }

                    if (IsTrackDriver && AppVars.objPolicyConfiguration.ClientType == "new")
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

                if (points.Count > 0)
                {

                    bool showBookingMarkers = true;
                    GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlayJob");


                    gMapControl1.MinZoom = 0;
                    gMapControl1.MaxZoom = 24;
                    gMapControl1.Zoom = 18;
                    gMapControl1.DragButton = MouseButtons.Left;




                    GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(points[0].Lat), Convert.ToDouble(points[0].Lng)), Resources.Resource1.arrived);
                    //marker1.ToolTipText = "PICKUP : " + Environment.NewLine + ObjBooking.FromAddress.ToStr();
                    marker1.ToolTipMode = MarkerTooltipMode.Always;
                    //marker1.ToolTip.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    marker1.Tag = new PointLatLng(objset.latlnglist[0].Lat, objset.latlnglist[0].Lng);
                    marker1.Tag = "Pickup";

                    //ObjBooking.DriverId==null || ObjBooking.DriverId != this._DriverId

                    if (this._DriverId > 0)
                    {
                        showBookingMarkers = false;
                    }

                    polyOverlay.Markers.Add(marker1);


                    if (objset.latlnglist.Count > 1)
                    {
                        if (objset.latlnglist.Count == 2)
                        {
                            gMapControl1.Position = new PointLatLng(objset.latlnglist[1].Lat, objset.latlnglist[1].Lng);
                        }
                        else
                            gMapControl1.Position = new PointLatLng(objset.latlnglist[objset.latlnglist.Count - 1].Lat, objset.latlnglist[objset.latlnglist.Count - 1].Lng);


                        if (objset.latlnglist.Count > 2)
                        {
                            GMapRoute route = new GMapRoute(objset.latlnglist, "routeJob");
                            route.Stroke = new Pen(Color.CornflowerBlue, 8);

                            polyOverlay.Routes.Add(route);
                        }


                        GMapMarkerCustom marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objset.latlnglist[objset.latlnglist.Count - 1].Lat), Convert.ToDouble(objset.latlnglist[objset.latlnglist.Count - 1].Lng)), Resources.Resource1.clear);
                        // marker2.ToolTipText = "DESTINATION : " + Environment.NewLine + ObjBooking.ToAddress.ToStr();
                        marker2.ToolTipMode = MarkerTooltipMode.Always;
                        //marker2.ToolTip.Font = new Font("Tahoma", 10, FontStyle.Bold);
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
                        gMapControl1.Position = new PointLatLng(objset.latlnglist[0].Lat, objset.latlnglist[0].Lng);



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
                    var obj = db.Fleet_Driver_Locations.Where(c => c.DriverId == this._DriverId).Select(c => new { c.DriverId, c.Speed, c.Latitude, c.Longitude, c.LocationName }).FirstOrDefault();


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



                        markerDrv.Tag = "Driver";

                        string EstimatedTimeLeft = "";
                        if (AppVars.objPolicyConfiguration.ClientType == "new")
                        {

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

                                                    EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);


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
                                                        EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);



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

                                                        EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);


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

                                                            EstimatedTimeLeft = GetDistance.GetLocationDetailsByMapHere(obj1, obj2, AppVars.etaKey, null);



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
                        }

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
                                DriverNo = db.Fleet_Drivers.Where(c => c.Id == _DriverId).Select(c => c.DriverNo).FirstOrDefault();
                                DriverNo = "Driver : " + DriverNo.ToStr();
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
                gMapControl1.MapProvider = GMapProviders.GoogleMap;

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
                                             
                        DrawPolyVertices(7, 1, cooddt);

                    }
                    catch (Exception ex)
                    {

                        if (ex.Message.ToLower().Contains("cross-thread"))
                        {
                            if (this.InvokeRequired)
                            {
                                //this.ObjBooking.Booking_RoutePaths
                                // this.BeginInvoke(new DrawUI(DrawPolyVertices), 7, 1, objset.latlnglist);


                            }
                            else
                            {   //this.ObjBooking.Booking_RoutePaths
                                // DrawPolyVertices(7, 1, objset.latlnglist);


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

        public int percentComplete = 0;
        public int min = 0;
        public int max = 0;
        void rptJobRouthPath_Load(object sender, EventArgs e)
        {

            try
            {
               
                if (cooddt != null)
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
                        
                        worker.RunWorkerAsync();

                        
                    }
                    else
                    {

                        try
                        {
                            trackBar1.Visible = true;
                            trackBar1.Enabled = true;
                            gMapControl1.BringToFront();

                            
                            
                            var first = cooddt.First();
                            var last = cooddt.Last();
                            DateTime dtfrom = first.UpdateDate.ToDateTime();

                            DateTime dtto = last.UpdateDate.ToDateTime();
                            lblStart.Text = "(" + dtfrom.ToDateTime().ToString("HH:mm") + ")";
                                                     

                            trackBar1.Minimum = dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                           
                            trackBar1.Value = dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                            min = dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                            max = dtto.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                            percentComplete = (int)Math.Round((double)(100 * min) / max);


                            
                            if (dtto.ToDateTime() == null)
                            {
                                
                            }
                            else
                            {     
                                trackBar1.Maximum = dtto.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                
                                lblEnd.Text = "(" + dtto.ToDateTime().ToString("HH:mm") + ")";

                            }


                        }
                        catch
                        {

                        }

                        pnlRouteActions.Visible = true;
                        pnlRouteActions.BringToFront();

                                               


                        if (worker == null)
                        {
                            worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                            worker.WorkerSupportsCancellation = true;
                        }



                        worker.RunWorkerAsync();

                    }
                }//main if end
                else
                {

                    if (IsTrackDriver)
                    {
                        this.Text = "Track Driver";

                        if (worker == null)
                        {
                            worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                            worker.WorkerSupportsCancellation = true;
                        }

                        gMapControl1.Enabled = false;
                        //grdLister.Visible = false;
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

                ZoomTo("Driver");
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

        public GMapRoute groute = null;
        public static double? distance = 0;
                
        private void DrawPolyVertices(int lineWeight, int lineForeColor, List<CoordinatesWithUpdatedDate> listOfLocations)
        {
            try
            {
                pnlZoom.Visible = false;


                gMapControl1.MarkersEnabled = true;
                
                List<PointLatLng> points = new List<PointLatLng>();
                for (int i = 0; i < gMapControl1.Overlays.Count; i++)
                {
                    gMapControl1.Overlays.RemoveAt(i);
                }

                GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlay1");

                var firstdt = listOfLocations.FirstOrDefault();
                var lastdt = listOfLocations.LastOrDefault();

                DateTime dtfrom = firstdt.UpdateDate.ToDateTime();
                DateTime dtto = lastdt.UpdateDate.ToDateTime();
                var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);

                points = listOfLocations.Select(args => new PointLatLng
                {
                    Lat = Convert.ToDouble(args.Lat),
                    Lng = Convert.ToDouble(args.Lng)

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
                groute = route;
                distance = route.Distance;
                polyOverlay.Routes.Add(route);

                gMapControl1.Overlays.Add(polyOverlay);



                DateTime? acceptDateTime = dtfrom;

                DateTime? clearedDateTime = dtto;

                if (acceptDateTime != null)
                {
                    var objacc = listOfLocations.FirstOrDefault();
                    if (objacc != null)
                    {


                        
                        marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objacc.Lat), Convert.ToDouble(objacc.Lng)), null);
                        marker14.ToolTipText = "Shift Start At : " + string.Format("{0:dd/MM/yyyy HH:mm}", acceptDateTime);

                        marker14.ToolTipMode = MarkerTooltipMode.Always;
                        marker14.ToolTip.Font = new Font("Tahoma", 9, FontStyle.Bold);

                        bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond, new Size(40, 40));

                        marker14.MarkerImage = bmp;
                        marker14.IsVisible = false;
                     

                        marker15 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objacc.Lat), Convert.ToDouble(objacc.Lng)), null);
                        marker15.ToolTipText = "Shift Start At : " + string.Format("{0:dd/MM/yyyy HH:mm}", acceptDateTime);
                        marker15.ToolTipMode = MarkerTooltipMode.Always;
                        marker15.ToolTip.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        //marker15.MarkerImage = bmp;

                        marker15.IsVisible = true;

                        
                        polyOverlay.Markers.Add(marker14);
                        polyOverlay.Markers.Add(marker15);

                    }

                }



                if (clearedDateTime != null)
                {
                    List<PointLatLng> lat = new List<PointLatLng>();

                    var objld = listOfLocations.LastOrDefault();

                    if (objld != null)
                    {
                        //GMapMarkerCustom 
                        marker7 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(objld.Lat), Convert.ToDouble(objld.Lng)), null);
                        marker7.ToolTipText = "Shift Finish At : " + string.Format("{0:dd/MM/yyyy HH:mm}", clearedDateTime);
                        marker7.Tag = "8";
                        marker7.ToolTipMode = MarkerTooltipMode.Always;
                        marker7.ToolTip.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        polyOverlay.Markers.Add(marker7);

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


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
        GMapOverlay polyOverlay1 = null;

        GMapMarkerCustom marker14 = null;

        GMapMarkerCustom marker7 = null;
        List<Booking_RoutePath> queryData = null;

        GMapMarkerCustom marker15 = null;
        
        List<CoordinatesWithUpdatedDate> pointsAndDates = null;
        DateTime? acceptDateTime = null;
        DateTime? clearedDateTime = null;
        public void Navigation()
        {
            try
            {


                polyOverlay = gMapControl1.Overlays[0];

                var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond, new Size(40, 40));

                if (btnShowJobDetail.Checked)
                {
                    bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

                }

                var lst = cooddt.FirstOrDefault();
                var last = cooddt.LastOrDefault();


                acceptDateTime = lst.UpdateDate.ToDateTime();
                clearedDateTime = last.UpdateDate.ToDateTime();


                var driverno = lst.driverid;

                if (btnSkipZeroSpeed.Checked)
                {
                    if (CheckTag == "visited")
                    {
                        pointsAndDates = datalst;

                        lst = pointsAndDates.FirstOrDefault();
                        last = pointsAndDates.LastOrDefault();
                        acceptDateTime = lst.UpdateDate.ToDateTime();
                        clearedDateTime = last.UpdateDate.ToDateTime();


                    }
                    else
                    {
                        pointsAndDates = cooddt.Where(x => x.UpdateDate >= dtTrackBar).ToList();// && x.Speed > 0).ToList();
                    }

                }
                else
                {
                    if (CheckTag == "visited")
                    {
                        pointsAndDates = datalst;
                        lst = pointsAndDates.FirstOrDefault();
                        last = pointsAndDates.LastOrDefault();
                        acceptDateTime = lst.UpdateDate.ToDateTime();
                        clearedDateTime = last.UpdateDate.ToDateTime();

                    }
                    else
                    {
                        pointsAndDates = cooddt.Where(x => x.UpdateDate >= dtTrackBar).ToList();
                    }

                }

                Font f = new Font("Tahoma", 8, FontStyle.Bold);
                bool isTrue = false;


                long? jobid = 0;
                string refno = "";

                if (CheckTag != "visited")
                {

                    marker14.IsVisible = true;
                    marker7.IsVisible = true;

                    for (int i = startFrom; i < pointsAndDates.Count; i++)
                    {

                        if (btnSkipZeroSpeed.Checked)
                        {
                            if (pointsAndDates[i].Speed <= 0)
                            {
                                continue;

                            }
                        }



                        if (radchkAll.Checked)
                        {

                            if (grdLister.RowCount > 0)
                            {
                                DiableTrackBar();


                                jobid = pointsAndDates[i].JobId == null ? 0 : (long)pointsAndDates[i].JobId;

                                
                                if (jobid > 0)
                                {
                                    var row = grdLister.Rows.Where(x => x.Cells[COLS.ID].Value.ToStr() == jobid.ToStr()).FirstOrDefault();

                                    bookingNum = row.Cells[COLS.BookingNo].Value.ToStr();
                                    _pickupDateTime = row.Cells[COLS.Pickupdatetime].Value.ToDateTime();
                                    _acceptDateTime = row.Cells[COLS.AcceptedDateTime].Value.ToDateTime();

                                    _arriveDateTime = row.Cells[COLS.ArrivalDateTime].Value.ToDateTime();
                                    _pobDateTime = row.Cells[COLS.POBDateTime].Value.ToDateTime();
                                    _stcDateTime = row.Cells[COLS.STCDateTime].Value.ToDateTime();
                                    _clearedDateTime = row.Cells[COLS.Cleareddatetime].Value.ToDateTime();
                                    acceptDateTime = row.Cells[COLS.AcceptedDateTime].Value.ToDateTime();
                                    clearedDateTime = row.Cells[COLS.Cleareddatetime].Value.ToDateTime();


                                }
                            }


                        }



                        var lstZoneName = zonelist.Where(x => x.Id == Convert.ToInt32(pointsAndDates[i].ZoneId)).Select(c => c.ZoneName).ToList();

                        var lstdrivername = DriverList.Where(x => x.Id == Convert.ToInt32(pointsAndDates[i].driverid)).Select(c => c.DriverName).ToList();

                        string zonename = "";
                        string driver = "";
                        if (lstZoneName.Count > 0)
                        {
                            zonename = lstZoneName[0].ToStr();
                            if (!string.IsNullOrEmpty(zonename))
                            {
                                zonename = Environment.NewLine + "Plot : " + zonename;
                            }
                        }


                        if (lstdrivername.Count > 0)
                        {
                            driver = lstdrivername[0].ToStr();
                        }
                        else
                        {
                            driver = "-";
                        }

                        string driverinfo = "Driver :" + " " + driverno.ToStr() + " " + "{" + driver + "}";

                        if (!string.IsNullOrEmpty(bookingNum))
                        {
                            refno = Environment.NewLine + "Ref No: " + bookingNum;
                        }


                        if (pause)
                        {

                            startFrom = i;


                            if (marker14 == null)
                                marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng)), null);
                            else

                                marker14.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                            marker14.MarkerImage = bmp;

                            
                            marker14.ToolTipText = driverinfo + refno + zonename + Environment.NewLine + "Speed : " + pointsAndDates[i].Speed.ToStr() + " mph" + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", pointsAndDates[i].UpdateDate);

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

                                if (marker14 == null)

                                    marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[0].Lat), Convert.ToDouble(pointsAndDates[0].Lng)), null);

                                else
                                {

                                    marker14.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[0].Lat), Convert.ToDouble(pointsAndDates[0].Lng));

                                }

                                //Added on 27/07/2021

                                if (btnShowJobDetail.Checked)
                                {
                                    bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

                                }
                                else
                                {
                                    bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);

                                    if (gMapControl1.Overlays[0].Markers.Count > 0)
                                    {
                                        var m = gMapControl1.Overlays[0].Markers.ToList();
                                        foreach (var val in m)
                                        {
                                            if (val != null)
                                            {
                                                if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                                    || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6")
                                                {
                                                    polyOverlay1.Markers.Remove(val);
                                                }

                                            }
                                        }

                                    }


                                }


                                if (CheckTag == "visited")
                                {

                                    bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                                    //marker2.MarkerImage = bmp;
                                    marker14.IsVisible = false;
                                    marker15.IsVisible = false;

                                    marker7.IsVisible = false;
                                    //marker14.ToolTipText = "Shift Start At : " + string.Format("{0:dd/MM/yyyy HH:mm}", pointsAndDates[0].UpdateDate);
                                    //marker14.ToolTipMode = MarkerTooltipMode.Always;
                                    //marker14.ToolTip.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    //marker14.MarkerImage = bmp;


                                }

                                
                                
                                if (polyOverlay.Markers.Count == 0)
                                    polyOverlay.Markers.Add(marker14);


                                this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[0].Lat), Convert.ToDouble(pointsAndDates[0].Lng));

                                    /*
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
                                   */

                                });
                                EnableTrackBar();


                                break;

                            }


                            if (stop == false)
                            {

                                isTrue = false;

                                
                                if (marker14 == null)
                                {
                                    marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng)), null);
                                    polyOverlay.Markers.Add(marker14);
                                }
                                else

                                    marker14.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                                if (marker14.MarkerImage == null)
                                    marker14.MarkerImage = bmp;



                                marker14.ToolTipText = driverinfo + refno + zonename + Environment.NewLine + "Speed : " + pointsAndDates[i].Speed.ToStr() + " mph" + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", pointsAndDates[i].UpdateDate);

                                marker14.MarkerImage = bmp;
                                marker14.ToolTipMode = MarkerTooltipMode.Always;
                                marker14.ToolTip.Font = f;

                                if (clearedDateTime != null)
                                {
                                    
                                                                                                      
                                    if (i == pointsAndDates.Count || pointsAndDates[i].UpdateDate >= clearedDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(15) > clearedDateTime.Value)
                                    {

                                        Font f1 = new Font("Tahoma", 8, FontStyle.Bold);
                                        marker14.ToolTip.Font = f1;
                                        isTrue = true;

                                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;
                                        EnableTrackBar();
                                    }
                                }

                                if (isTrue == false && _stcDateTime != null)
                                {
                                    
                                    if (pointsAndDates[i].UpdateDate >= _stcDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > _stcDateTime.Value)
                                    {
                                        isTrue = true;
                                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;

                                    }

                                }

                                if (isTrue == false && _pobDateTime != null)
                                {
                                    
                                    if (pointsAndDates[i].UpdateDate >= _pobDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > _pobDateTime.Value)
                                    {
                                        isTrue = true;
                                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;

                                    }

                                }
                                if (isTrue == false && _arriveDateTime != null)
                                {   
                                    if (pointsAndDates[i].UpdateDate >= _pickupDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(10) > _pickupDateTime.Value)
                                    {
                                        isTrue = true;

                                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;

                                    }

                                }

                                if (isTrue == false && acceptDateTime != null)
                                {

                                    if (acceptDateTime != null)
                                    {

                                        if (pointsAndDates[i].UpdateDate >= acceptDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > acceptDateTime.Value)
                                        {
                                            isTrue = true;
                                            //isTrue = true;


                                            marker14.MarkerImage = bmp;
                                            
                                        }
                                    }

                                }

                                                            

                                   if (i < pointsAndDates.Count)

                                    if (btnAutoZoom.Checked)
                                    {
                                         this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                                         {
                                           gMapControl1.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));


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

                                    }

                                

                                if (polyOverlay.Markers.Count == 0)
                                    polyOverlay.Markers.Add(marker14);
                                                                                                
                                
                                if (CheckTag == "visited")
                                {
                                    System.Threading.Thread.Sleep(120);
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(100);
                                }


                            }


                            GC.Collect();
                        }



                    }

                }
                else
                {
                    ZoomEachJobJourney();
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
                            p.StartInfo.FileName = Application.StartupPath + "\\MapReportRecorder.exe";
                            p.StartInfo.Arguments = host + "," + username + "," + AppVars.objSubCompany.SmtpHasSSL.ToBool().ToStr();
                            p.Start();

                            this.MaximizeBox = true;
                            this.MinimizeBox = true;
                            this.Close();
                        });

                    }

                }

            }
            catch (Exception ex)
            {


            }
            

        }










        public void ZoomEachJobJourney()
        {

            Font f = new Font("Tahoma", 8, FontStyle.Bold);
            bool isTrue = false;

            var driverno = pointsAndDates[0].driverid;
            long? jobid = 0;
            string refno = "";
            string speed = "";
            for (int i = startFrom; i < pointsAndDates.Count; i++)
            {

                marker14.IsVisible = false;
                marker7.IsVisible = false;

                if (btnSkipZeroSpeed.Checked)
                {
                    if (pointsAndDates[i].Speed <= 0)
                    {
                        continue;

                    }
                    else
                    {

                        speed = Environment.NewLine + "Speed : " + pointsAndDates[i].Speed.ToStr() + " mph";
                    }

                }

                var lstZoneName = zonelist.Where(x => x.Id == Convert.ToInt32(pointsAndDates[i].ZoneId)).Select(c => c.ZoneName).ToList();
                var lstdrivername = DriverList.Where(x => x.Id == Convert.ToInt32(pointsAndDates[i].driverid)).Select(c => c.DriverName).ToList();

                string zonename = "";
                string driver = "";
                if (lstZoneName.Count > 0)
                {
                    zonename = lstZoneName[0].ToStr();
                    if (!string.IsNullOrEmpty(zonename))
                    {
                        zonename = Environment.NewLine + "Plot : " + zonename;
                    }
                }


                if (lstdrivername.Count > 0)
                {
                    driver = lstdrivername[0].ToStr();
                }
                else
                {
                    driver = "-";
                }

                string driverinfo = "Driver :" + " " + driverno.ToStr() + " " + "{" + driver + "}";

                if (!string.IsNullOrEmpty(bookingNum))
                {
                    refno = Environment.NewLine + "Ref No: " + bookingNum;
                }


                if (pause)
                {

                    startFrom = i;


                    if (marker2 == null)
                        marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng)), null);
                    else

                        marker2.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                    marker2.MarkerImage = bmp;

                    marker2.ToolTipText = driverinfo + refno + zonename + speed + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", pointsAndDates[i].UpdateDate);

                    marker2.ToolTipMode = MarkerTooltipMode.Always;
                    marker2.ToolTip.Font = f;

                    if (polyOverlay.Markers.Count == 0)
                        polyOverlay.Markers.Add(marker14);

                    break;

                }
                else
                {
                    if (stop == true)
                    {

                        if (marker2 == null)

                            marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[0].Lat), Convert.ToDouble(pointsAndDates[0].Lng)), null);

                        else
                        {

                            marker2.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[0].Lat), Convert.ToDouble(pointsAndDates[0].Lng));

                        }

                        //Added on 27/07/2021

                        if (btnShowJobDetail.Checked)
                        {

                            bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

                        }
                        else
                        {
                            bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);
                            marker15.IsVisible = true;
                            marker7.IsVisible = true;
                            if (gMapControl1.Overlays[0].Markers.Count > 0)
                            {
                                var m = gMapControl1.Overlays[0].Markers.ToList();
                                foreach (var val in m)
                                {
                                    if (val != null)
                                    {
                                        if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                            || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6")
                                        {
                                            polyOverlay1.Markers.Remove(val);
                                        }

                                    }
                                }

                            }

                        }


                        if (CheckTag == "visited")
                        {

                            bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                            //marker2.MarkerImage = bmp;
                            marker14.IsVisible = false;
                            marker15.IsVisible = false;

                            marker7.IsVisible = false;
                            marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;

                        }

                        

                        
                        if (polyOverlay.Markers.Count == 0)
                            polyOverlay.Markers.Add(marker14);


                        this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                        {
                            gMapControl1.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[accepteddateindex].Lat), Convert.ToDouble(pointsAndDates[accepteddateindex].Lng));
                            /*
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
                            */
                        });



                        break;

                    }
                    if (stop == false)
                    {

                        isTrue = false;

                        
                        if (marker2 == null)
                        {
                            marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng)), null);
                            polyOverlay.Markers.Add(marker2);
                        }
                        else

                            marker2.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                        if (marker2.MarkerImage == null)
                            marker2.MarkerImage = bmp;



                        marker2.ToolTipText = driverinfo + refno + zonename + Environment.NewLine + "Speed : " + pointsAndDates[i].Speed.ToStr() + " mph" + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", pointsAndDates[i].UpdateDate);
                        //
                       // bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

                        marker2.MarkerImage = bmp;
                        marker2.ToolTipMode = MarkerTooltipMode.Always;
                        marker2.ToolTip.Font = f;




                        if (isTrue == false && acceptDateTime != null)
                        {

                            if (acceptDateTime != null)
                            {

                                if (pointsAndDates[i].UpdateDate >= acceptDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > acceptDateTime.Value)
                                {
                                    // isTrue = true;
                                    //isTrue = true;

                                    marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;


                                }
                            }

                        }


                        
                        if (isTrue == false && _arriveDateTime != null)
                        {
                                                                   
                            if (pointsAndDates[i].UpdateDate >= _arriveDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(18) > _arriveDateTime.Value)
                            {
                                string m = pointsAndDates[i].UpdateDate.ToString();
                                isTrue = true;
                                marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;

                            }

                        }

                       

                        if (_pobDateTime != null)
                        {
                                  
                            if (pointsAndDates[i].UpdateDate >= _pobDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > _pobDateTime.Value)
                            {
                                isTrue = true;

                                marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;

                            }

                        }



                        // 
                        if (_stcDateTime != null)
                        {

                            if (pointsAndDates[i].UpdateDate >= _stcDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(20) > _stcDateTime.Value)
                            {
                                isTrue = true;

                                marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;

                            }

                        }

                      
                        if (clearedDateTime != null)
                        {            
                          


                            if (i == ((pointsAndDates.Count)) || pointsAndDates[i].UpdateDate >= clearedDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(15) > clearedDateTime.Value)
                            {

                                Font f1 = new Font("Tahoma", 8, FontStyle.Bold);
                                marker2.ToolTip.Font = f1;
                                isTrue = true;

                                marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;
                                EnableTrackBar();
                               
                                break;
                            }
                        }



                        //}

                        //---------------------------------------------------------------------------------------------------------------------------------



                        if (i < pointsAndDates.Count)

                            if (btnAutoZoom.Checked)
                            {
                                this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));




                                });

                            }



                        if (polyOverlay.Markers.Count == 0)
                            polyOverlay.Markers.Add(marker14);

                        if (CheckTag == "visited")
                        {
                            System.Threading.Thread.Sleep(120);
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(100);
                        }


                    }


                    GC.Collect();
                }



            }


        }





        private void TrackBar()
        {
            trackBar1.Value = val;
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

                val = trackBar1.Value.ToInt();

                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(Navigation));

                if (th.ThreadState != System.Threading.ThreadState.Running)
                {
                    stop = false;
                    pause = false;

                    if (CheckTag != "visited")
                    {
                        startFrom = 0;
                    }
                    if (CheckTag.Equals("visited"))
                    {
                        startFrom = checkindex;
                    }

                    //startFrom = 0;

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
                    //polyOverlay.Markers.Remove(marker14);
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
                stop = true;
               
                
                if (cooddt.Count > 0)
                {

                    if (CheckTag.Equals("visited"))
                    {


                        if (marker2 == null)
                            marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[0].Lat), Convert.ToDouble(datalst[0].Lng)), null);
                        else
                            marker2.Position = new PointLatLng(Convert.ToDouble(datalst[0].Lat), Convert.ToDouble(datalst[0].Lng));

                        marker2.ToolTip.Font = new Font("Tahoma", 6, FontStyle.Bold);
                        marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;

                        marker2.ToolTipText = "Accepted at : " + string.Format("{0:dd/MM/yyyy HH:mm}", _acceptDateTime);
                        btnPauseNav.Text = "Pause";
                        pause = false;
                        this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                        {
                            gMapControl1.Position = new PointLatLng(Convert.ToDouble(datalst[0].Lat), Convert.ToDouble(datalst[0].Lng));
                            //gMapControl1.MinZoom = 0;
                            //gMapControl1.MaxZoom = 24;
                            gMapControl1.Zoom = 14;
                            gMapControl1.DragButton = MouseButtons.Left;

                        });


                    }
                    else
                    {
                        var first = cooddt.FirstOrDefault();
                        var last = cooddt.LastOrDefault();

                        string driverno = first.driverid.ToStr();
                        

                        if (marker14 == null)
                            marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng)), null);
                        else
                            marker14.Position = new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng));


                        if (marker15 == null)
                            marker15 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng)), null);
                        else
                            marker15.Position = new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng));





                        if (btnShowJobDetail.Checked)
                        {
                            bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);

                        }
                        else
                        {
                            bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);
                        }

                        marker14.ToolTipText = "Shift Start At : " + string.Format("{0:dd/MM/yyyy HH:mm}", cooddt[0].UpdateDate);
                        marker14.ToolTipMode = MarkerTooltipMode.Always;
                        marker14.ToolTip.Font = new Font("Tahoma", 8, FontStyle.Bold);

                        marker14.MarkerImage = null;
                        //marker14.MarkerImage = bmp;
                        marker15.IsVisible = true;
                        marker14.IsVisible = false;
                        btnPauseNav.Text = "Pause";
                        pause = false;
                        this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                        {
                            gMapControl1.Position = new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng));

                            gMapControl1.DragButton = MouseButtons.Left;

                            //gMapControl1.MinZoom = 0;
                            //gMapControl1.MaxZoom = 24;
                            gMapControl1.Zoom = 13;


                        });
                        trackBar1.Enabled = true;
                        CheckTag = "";
                        checkindex = 0;
                        _pickupDateTime = null;
                        _acceptDateTime = null;
                        _arriveDateTime = null;
                        _pobDateTime = null;
                        _stcDateTime = null;
                        _clearedDateTime = null;
                        acceptDateTime = null;
                        clearedDateTime = null;
                        EnableTrackBar();
                    }
                }


        /*---------------------End---ToDo:Added on 13-07-2021 to clear job marking when stop button is pressed--------------------------------------------------------*/




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


        public void StopNavigationOnZoomChange()
        {
            try
            {
                btnRecordingPlay.Enabled = true;
                trackBar1.Enabled = true;
                var first = cooddt.FirstOrDefault();
                var last = cooddt.LastOrDefault();

                trackBar1.Value = first.UpdateDate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                stop = true;
                marker14.ToolTipText = "";
                if (cooddt.Count > 0)
                {
                    marker14.ToolTipText = "";
                    if (marker14 == null)

                        marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng)), null);
                    else
                        marker14.Position = new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng));


                    marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;

                    marker14.ToolTipText = "Driver " + DriverNo2;

                    marker14.ToolTipText = "START at : " + string.Format("{0:dd/MM/yyyy HH:mm}", cooddt[0].UpdateDate);

                    marker14.ToolTipMode = MarkerTooltipMode.Always;
                    marker14.ToolTip.Font = new Font("Tahoma", 8, FontStyle.Bold);

                    btnPauseNav.Text = "Pause";
                    pause = false;


                    this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        gMapControl1.Position = new PointLatLng(Convert.ToDouble(cooddt[0].Lat), Convert.ToDouble(cooddt[0].Lng));

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



                if (CheckTag != "visited")
                {

                    var lst = cooddt.FirstOrDefault();
                    var last = cooddt.LastOrDefault();
                    DateTime dtfrom = lst.UpdateDate.ToDateTime();
                    DateTime dtto = last.UpdateDate.ToDateTime();


                    int val = trackBar1.Value.ToInt();

                    TimeSpan time = TimeSpan.FromSeconds(val);

                    DateTime date = dtfrom.ToDate(); //objset.UpdateDate; //ObjBooking.AcceptedDateTime.ToDate();

                    dtTrackBar = date + time;


                }
                else
                {

                    var lst = datalst.FirstOrDefault();
                    var last = datalst.LastOrDefault();
                    DateTime dtfrom = lst.UpdateDate.ToDateTime();
                    DateTime dtto = last.UpdateDate.ToDateTime();


                    int val = trackBar1.Value.ToInt();

                    TimeSpan time = TimeSpan.FromSeconds(val);

                    DateTime date = dtfrom.ToDate(); //objset.UpdateDate; //ObjBooking.AcceptedDateTime.ToDate();

                    dtTrackBar = date + time;

                }


                if (scroll == false)
                {
                    /*
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
               */
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


                if (AppVars.objPolicyConfiguration.DefaultClientId.ToStr() == "4-star")
                {
                    try
                    {

                        url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyA_OU-prdptvQWov4lkbUCXeB5ATuXByzk";

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
                    catch
                    {

                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyA_otaK2_m8hixryiig5GCWHMohdOERgZ4";

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
                    }
                    catch
                    {


                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyCDmuKvTJXS-w-oh2xCc8VAfgvfG86gMXY";

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
                    }
                    catch
                    {


                    }



                }
                else if (AppVars.objPolicyConfiguration.DefaultClientId.ToStr() == "cA$tle_A$$oc!Ate$_wm_l!m!ted")
                {
                    try
                    {

                        url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyD3Mr8oT3nCQsv_mlr1SQ28Sjo_cO0Y0eM";

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
                    catch
                    {

                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyDgzIbskFzGfbCBEgZH3vQFTsku3kvz7hw";

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
                    }
                    catch
                    {


                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyCyUbbFmKw6VdyEY5JECheAKO_bbQRXlUg";

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
                    }
                    catch
                    {


                    }



                }

                else if (AppVars.objPolicyConfiguration.DefaultClientId.ToStr() == "Prn-cb")
                {
                    try
                    {

                        url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyAJNEi3iOct1LBsFC6m-zFpFwxPapF10bQ";

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
                    catch
                    {

                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyAn2zwqsWHc0qoHEayw_j57Xa52Osk-cmA";

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
                    }
                    catch
                    {


                    }


                    try
                    {
                        if (string.IsNullOrEmpty(locationName.Trim()))
                        {

                            url2 = "https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false&key=AIzaSyBqCNXb64ZmIDAzE7WFGcFGjIiC9zdKQP0";

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
                    }
                    catch (Exception ex)
                    {


                    }



                }
                else
                {

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



                        //if (locationName.ToStr().Trim().Length == 0)
                        //{
                        //    try
                        //    {

                        //        File.AppendAllText(System.Windows.Forms.Application.StartupPath + "\\" + "exception_google.txt", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ":" + url2 + Environment.NewLine);
                        //    }
                        //    catch
                        //    {


                        //    }
                        //}
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



                // Starts Bing WebService
                //if (string.IsNullOrEmpty(locationName))
                //{
                //    try
                //    {
                //        if (bingkey.Length > 0)
                //        {

                //            url2 = "http://dev.virtualearth.net/REST/v1/Locations/" + latitude + "," + longitude + "?o=xml&key=At9uWeg3Sk_C611VLD0cc6i9oYu7IioNxvjNUN6-blcjKIX_L2n5G2ObOgEVlNZ_";


                //            reader = new XmlTextReader(url2);
                //            reader.WhitespaceHandling = WhitespaceHandling.Significant;
                //            ds = new System.Data.DataSet();
                //            ds.ReadXml(reader);
                //            dt = ds.Tables["Address"];

                //            if (dt != null)
                //            {

                //                DataRow row = dt.Rows.OfType<DataRow>().FirstOrDefault();
                //                if (row != null)
                //                {
                //                    locationName = row["FormattedAddress"].ToString().Trim();
                //                }
                //            }

                //            ds.Dispose();
                //        }
                //    }
                //    catch
                //    {
                //        locationName = string.Empty;
                //    }
                //}






                // Starts openstreetmap Geocoding Webservice

                //if (string.IsNullOrEmpty(locationName.Trim()))
                //{
                //    try
                //    {
                //        if (openstreetkey.Length > 0)
                //        {


                //            url2 = "http://nominatim.openstreetmap.org/reverse?lat=" + latitude + "&lon=" + longitude;

                //            reader = new XmlTextReader(url2);

                //            ds = new System.Data.DataSet();
                //            ds.ReadXml(reader);
                //            DataTable table = ds.Tables["addressparts"];

                //            if (table != null)
                //            {

                //                DataRow row = table.Rows.OfType<DataRow>().FirstOrDefault();
                //                if (row != null)
                //                {
                //                    if (table.Columns.Contains("road") && table.Columns.Contains("village")
                //                            && table.Columns.Contains("county") && table.Columns.Contains("postcode"))
                //                    {
                //                        locationName = row["road"].ToStr() + ", " + row["village"].ToStr() + ", " + row["county"].ToStr() + ", " + row["postcode"].ToStr();
                //                    }
                //                    else if (table.Columns.Contains("road") && table.Columns.Contains("city")
                //                            && table.Columns.Contains("county") && table.Columns.Contains("postcode"))
                //                    {
                //                        locationName = row["road"].ToStr() + ", " + row["city"].ToStr() + ", " + row["county"].ToStr() + ", " + row["postcode"].ToStr();
                //                    }
                //                    else if (table.Columns.Contains("road") && table.Columns.Contains("town")
                //                            && table.Columns.Contains("county") && table.Columns.Contains("postcode"))
                //                    {
                //                        locationName = row["road"].ToStr() + ", " + row["town"].ToStr() + ", " + row["county"].ToStr() + ", " + row["postcode"].ToStr();
                //                    }
                //                    else if (table.Columns.Contains("road") && table.Columns.Contains("city")
                //                            && table.Columns.Contains("county") && table.Columns.Contains("country"))
                //                    {
                //                        locationName = row["road"].ToStr() + ", " + row["city"].ToStr() + ", " + row["county"].ToStr() + ", " + row["country"].ToStr();
                //                    }
                //                    else if (table.Columns.Contains("city") && table.Columns.Contains("county")
                //                            && table.Columns.Contains("postcode") && table.Columns.Contains("country"))
                //                    {
                //                        locationName = row["city"].ToStr() + ", " + row["county"].ToStr() + ", " + row["postcode"].ToStr() + ", " + row["country"].ToStr();
                //                    }
                //                }
                //            }
                //            ds.Dispose();
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        locationName = string.Empty;

                //    }
                //}





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
                    ZoomTo("Driver");
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

            /*
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
            */
        }
        bool scroll = true;


        /*_____________ToDo:Added By Noshad date:7th july 2021 _____________*/
        int val = 0;
        public void EnableTrackBar()
        {

            try
            {

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new EnableTrackBarOnJobCleared(EnableTrackBar));

                }
                else
                {
                    trackBar1.Enabled = true;


                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void DiableTrackBar()
        {

            try
            {

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new DisableTrackBarOnJobCleared(DiableTrackBar));

                }
                else
                {
                    trackBar1.Enabled = false;


                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }



        /*_____________End ToDo:Added By Noshad date:7th july 2021 _____________*/






        delegate void PlayTrackBarAutoDelegate();
        delegate void EnableTrackBarOnJobCleared();
        delegate void DisableTrackBarOnJobCleared();

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                scroll = true;

                int val = trackBar1.Value.ToInt();

                TimeSpan time = TimeSpan.FromSeconds(val);

                if (CheckTag.Equals("visited"))
                {

                    var first = datalst.FirstOrDefault();
                    DateTime date = first.UpdateDate.ToDate(); //ObjBooking.AcceptedDateTime.ToDate();
                    dtTrackBar = date + time;

                    ScrollBarWhenZoombtnSelected(dtTrackBar);
                }
                else
                {
                    var first = cooddt.FirstOrDefault();
                    DateTime date = first.UpdateDate.ToDate(); //ObjBooking.AcceptedDateTime.ToDate();
                    dtTrackBar = date + time;
                    NavScrollBar(dtTrackBar);
                }





            }
            catch (Exception)
            {

                throw;
            }

        }

        private string DriverNo2 = "";

        private void NavScrollBar(DateTime dt)
        {

            var first = cooddt.FirstOrDefault();
            var last = cooddt.LastOrDefault();
            DateTime? acceptDateTime = first.UpdateDate.ToDateTime();
            DateTime? clearedDateTime = last.UpdateDate.ToDateTime();
            long? jobid = 0;
            string zonename = "";
            string refno = "";
            string speed = "";


            var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond, new Size(35, 35));
            if (btnShowJobDetail.Checked == true)
            {

                bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute, new Size(35, 35));
            }
            else
            {
                bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond, new Size(35, 35));
            }


            var lstdrivername = DriverList.Where(x => x.Id == Convert.ToInt32(_DriverId)).Select(c => c.DriverName).ToList();
            string driver = "";
            if (lstdrivername.Count > 0)
            {
                driver = lstdrivername[0].ToStr();
            }
            else
            {
                driver = "-";
            }

            string driverinfo = "Driver :" + " " + _DriverId.ToStr() + " " + "{" + driver + "}";


            polyOverlay = gMapControl1.Overlays[0];

            if (DriverNo2.Length == 0)
                DriverNo2 = _DriverId.ToStr();

            List<CoordinatesWithUpdatedDate> pointsAndDates = null;

            pointsAndDates = cooddt.Where(x => x.UpdateDate >= dtTrackBar).ToList();

            //------------------------------------------------------------------------

            jobid = pointsAndDates[i].JobId == null ? 0 : (long)pointsAndDates[i].JobId;
            var lstZoneName = zonelist.Where(x => x.Id == Convert.ToInt32(pointsAndDates[i].ZoneId)).Select(c => c.ZoneName).ToList();

            decimal? sp = pointsAndDates[i].Speed;
            if (sp > 0)
            {
                speed = Environment.NewLine + "Speed : " + pointsAndDates[i].Speed.ToStr() + " mph";

            }


            if (lstZoneName.Count > 0)
            {
                zonename = lstZoneName[0].ToStr();
                if (!string.IsNullOrEmpty(zonename))
                {
                    zonename = Environment.NewLine + "Plot : " + zonename;
                }
            }
            using (TaxiDataContext db = new TaxiDataContext())
            {
                var result = db.ExecuteQuery<GetBookingByDriverShifts>(@"exec GetBookingByDriverShifts {0}", jobid.ToStr()).ToList();


                if (btnShowJobDetail.Checked == true)
                {

                    if (CheckTag != "visited")
                    {
                        _pickupDateTime = result[0].Pickupdatetime;
                        //_acceptDateTime = result[0].AcceptedDateTime;
                        _arriveDateTime = result[0].ArrivalDateTime;
                        _pobDateTime = result[0].POBDateTime;
                        _stcDateTime = result[0].STCDateTime;
                        //_clearedDateTime = result[0].Cleareddatetime;
                    }
                }

                if (result.Count > 0)
                {
                    refno = Environment.NewLine + "Ref No: " + result[0].BookingNo.ToStr();
                }



            }
            //------------------------------------------------------------------------

            Font f = new Font("Tahoma", 8, FontStyle.Bold);

            bool isTrue = false;
            if (CheckTag == "visited")
            {
                i = checkindex;
            }


            if (pointsAndDates.Count > 0)
            {

                //if (CheckTag != "visited")
                // {
                marker14.IsVisible = true;

                if (marker14 == null)
                {                                                                                   //queryData2[i].Longitude
                    marker14 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng)), null);
                    polyOverlay.Markers.Add(marker14);
                }
                else
                    marker14.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                if (marker14.MarkerImage == null)
                {
                    marker14.MarkerImage = bmp;
                }


                // marker14.ToolTipText = driverinfo;

                //queryData2[i].UpdateDate
                //marker14.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", dt);
                marker14.ToolTipText = driverinfo + refno + zonename + speed + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", dt);

                marker14.ToolTipMode = MarkerTooltipMode.Always;
                marker14.ToolTip.Font = f;

                marker14.MarkerImage = bmp;

                this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                {
                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(pointsAndDates[i].Lat), Convert.ToDouble(pointsAndDates[i].Lng));

                    /*
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
                    */


                });


                if (clearedDateTime != null)
                {      //i == queryData2.Count || queryData2[i].UpdateDate.Value >= clearedDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(15) > clearedDateTime.Value


                    if (i == pointsAndDates.Count || pointsAndDates[i].UpdateDate.AddSeconds(15) > clearedDateTime.Value)
                    {

                        isTrue = true;
                        //  polyOverlay.Markers.Remove(marker14);
                        //    bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;

                    }
                }


                if (isTrue == false && _stcDateTime != null)
                {

                    if (pointsAndDates[i].UpdateDate >= _stcDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > _stcDateTime.Value)
                    {
                        isTrue = true;
                        //   polyOverlay.Markers.Remove(marker14);
                        //  bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;
                        //    polyOverlay.Markers.Add(marker14);
                    }

                }

                if (isTrue == false && _pobDateTime != null)
                {
                    if (pointsAndDates[i].UpdateDate >= _pobDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(30) > _pobDateTime.Value)
                    {
                        isTrue = true;
                        //   polyOverlay.Markers.Remove(marker14);
                        //  bmp = new Bitmap();
                        marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;
                        //    polyOverlay.Markers.Add(marker14);
                    }

                }


                if (isTrue == false && _arriveDateTime != null)
                {
                    if (pointsAndDates[i].UpdateDate >= _arriveDateTime.Value || pointsAndDates[i].UpdateDate.AddSeconds(10) > _arriveDateTime.Value)
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

                    if (acceptDateTime != null)
                    {
                        //queryData2[i].UpdateDate.Value >= acceptDateTime.Value || queryData2[i].UpdateDate.Value.AddSeconds(30) > acceptDateTime.Value

                        if (pointsAndDates[i].UpdateDate >= pointsAndDates[i].UpdateDate || pointsAndDates[i].UpdateDate.AddSeconds(30) > acceptDateTime.Value)
                        {
                            isTrue = true;
                            //    isTrue = true;
                            //   polyOverlay.Markers.Remove(marker14);
                            marker14.MarkerImage = bmp;
                            //   polyOverlay.Markers.Add(marker14);
                        }
                    }

                }




                if (polyOverlay.Markers.Count == 0)
                    polyOverlay.Markers.Add(marker14);
                /*
                if (ObjBooking.TotalTravelledMiles <= 5)
                {
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    System.Threading.Thread.Sleep(50);

                }
                */


                //below line written by noshad
                if (CheckTag == "visited")
                {
                    System.Threading.Thread.Sleep(250);
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }


                //}//if checktag
                // else
                //{
                //ScrollBarWhenZoombtnSelected(pointsAndDates);

                //}
            }











        }

        //List<CoordinatesWithUpdatedDate> pointsAndDates was as parameter
        public void ScrollBarWhenZoombtnSelected(DateTime dt)
        {

            string zonename = "";
            long? jobid = 0;
            string refno = "";
            string speed = "";



            List<CoordinatesWithUpdatedDate> lst = null;

            lst = datalst.Where(x => x.UpdateDate >= dtTrackBar).ToList();


            decimal? sp = lst[i].Speed;

            Font f = new Font("Tahoma", 8, FontStyle.Bold);

            bool isTrue = false;
            var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute, new Size(32, 32));

            if (marker2 == null)
            {
                //accepteddateindex
                marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(lst[i].Lat), Convert.ToDouble(lst[i].Lng)), null);
                polyOverlay.Markers.Add(marker2);
            }
            else
                marker2.Position = new PointLatLng(Convert.ToDouble(lst[i].Lat), Convert.ToDouble(lst[i].Lng));



            if (marker2.MarkerImage == null)
            {
                marker2.MarkerImage = bmp;
            }




            if (sp > 0)
            {
                speed = Environment.NewLine + "Speed : " + lst[i].Speed.ToStr() + " mph";

            }


            //accepteddateindex is replaced by
            jobid = lst[i].JobId == null ? 0 : (long)lst[i].JobId;
            using (TaxiDataContext db = new TaxiDataContext())
            {
                var result = db.ExecuteQuery<GetBookingByDriverShifts>(@"exec GetBookingByDriverShifts {0}", jobid.ToStr()).ToList();
                _pickupDateTime = result[0].Pickupdatetime;
                //_acceptDateTime = result[0].AcceptedDateTime;
                _arriveDateTime = result[0].ArrivalDateTime;
                _pobDateTime = result[0].POBDateTime;
                _stcDateTime = result[0].STCDateTime;

                if (result.Count > 0)
                {
                    refno = Environment.NewLine + "Ref No: " + result[0].BookingNo.ToStr();
                }



            }

            //accepteddateindex
            var lstZoneName = zonelist.Where(x => x.Id == Convert.ToInt32(lst[i].ZoneId)).Select(c => c.ZoneName).ToList();

            var lstdrivername = DriverList.Where(x => x.Id == Convert.ToInt32(lst[i].driverid)).Select(c => c.DriverName).ToList();

            string driver = "";
            if (lstZoneName.Count > 0)
            {
                zonename = lstZoneName[0].ToStr();
                if (!string.IsNullOrEmpty(zonename))
                {
                    zonename = Environment.NewLine + "Plot : " + zonename;
                }
            }


            if (lstdrivername.Count > 0)
            {
                driver = lstdrivername[0].ToStr();
            }
            else
            {
                driver = "-";
            }

            string driverinfo = "Driver :" + " " + DriverNo2.ToStr() + " " + "{" + driver + "}";

            //------------------------------------------------------------------------

            marker2.ToolTipText = driverinfo + refno + zonename + speed + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", lst[i].UpdateDate);



            //marker2.ToolTipText = "Driver  :" + "  " + DriverNo2;
            //marker2.ToolTipText += Environment.NewLine + "Time : " + string.Format("{0:HH:mm:ss}", pointsAndDates[accepteddateindex].UpdateDate);


            marker2.ToolTipMode = MarkerTooltipMode.Always;
            marker2.ToolTip.Font = f;

            marker2.MarkerImage = bmp;

            this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
            {
                gMapControl1.Position = new PointLatLng(Convert.ToDouble(lst[i].Lat), Convert.ToDouble(lst[i].Lng));

                /*
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
                */


            });


            if (_clearedDateTime != null)
            {

                if (i == lst.Count || lst[i].UpdateDate.AddSeconds(15) > _clearedDateTime.Value)
                {

                    isTrue = true;
                    marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond;

                }
            }


            if (isTrue == false && _stcDateTime != null)
            {

                if (lst[i].UpdateDate >= _stcDateTime.Value || lst[i].UpdateDate.AddSeconds(30) > _stcDateTime.Value)
                {
                    isTrue = true;

                    marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_SoonToClear;

                }

            }

            if (isTrue == false && _pobDateTime != null)
            {
                if (lst[i].UpdateDate >= _pobDateTime.Value || lst[i].UpdateDate.AddSeconds(30) > _pobDateTime.Value)
                {
                    isTrue = true;

                    marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard;

                }

            }


            if (isTrue == false && _arriveDateTime != null)
            {
                if (lst[i].UpdateDate >= _arriveDateTime.Value || lst[i].UpdateDate.AddSeconds(10) > _arriveDateTime.Value)
                {
                    isTrue = true;

                    marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;

                }

            }

            if (isTrue == false && _acceptDateTime != null)
            {

                if (_acceptDateTime != null)
                {

                    if (lst[i].UpdateDate >= lst[i].UpdateDate || lst[i].UpdateDate.AddSeconds(30) > _acceptDateTime.Value)
                    {
                        isTrue = true;

                        marker2.MarkerImage = bmp;

                    }
                }

            }



            //if (polyOverlay.Markers.Count == 0)
            //  polyOverlay.Markers.Add(marker2);

            //if (CheckTag == "visited")
            //{
            //    System.Threading.Thread.Sleep(250);
            //}
            //else
            //{
            //    System.Threading.Thread.Sleep(100);
            //}



        }
        private void radChkShowPlots_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {

                DrawPlotsOnMap(true, 0);


                //chkShowPlotNoOnly.Visible = true;

            }
            else
            {
                DrawPlotsOnMap(false, 0);
                //chkShowPlotNoOnly.Visible = false;

            }

        }

        private void DrawPlotsOnMap(bool showPlots, int zoneId)
        {
            try
            {


                if (gMapControl1.Overlays.Count > 1)
                {


                    if (zoneId > 0)
                    {

                        if (showPlots)
                        {

                            foreach (var item in gMapControl1.Overlays.Where(c => c.Id != "overlay1").ToList())
                            {
                                item.IsVisibile = true;


                                GMapMarkerText mark = (GMapMarkerText)item.Markers.FirstOrDefault(c => c.Tag.ToInt() == zoneId);


                                //chkShowPlotNoOnly.Checked


                                if (showPlots)
                                {
                                    mark.MarkerText = mark.MarkerText2;
                                }
                                else
                                {
                                    mark.MarkerText = mark.DefaultMarkerText;

                                }


                                foreach (var item2 in item.Polygons)
                                {
                                    if (item2.Tag.ToInt() == zoneId)
                                    {
                                        item2.IsVisible = true;

                                        if (mark != null)
                                        {
                                            mark.IsVisible = true;

                                        }

                                    }
                                    else
                                    {

                                        item2.IsVisible = false;

                                        if (mark != null)
                                        {
                                            mark.IsVisible = false;

                                        }
                                    }

                                }

                            }
                        }
                    }

                    else
                    {

                        // gMapControl1.Overlays.Where(c => c.Id != "overlay1").ToList().ForEach(c => c.IsVisibile = showPlots);

                        foreach (var overlay in gMapControl1.Overlays.Where(c => c.Id != "overlay1").ToList())
                        {



                            overlay.IsVisibile = showPlots;

                            foreach (var polygon in overlay.Polygons)
                            {
                                polygon.IsVisible = showPlots;

                            }

                            foreach (GMapMarkerText marker in overlay.Markers)
                            {


                                //chkShowPlotNoOnly.Checked
                                if (showPlots)
                                {
                                    marker.MarkerText = marker.MarkerText2;

                                }
                                else
                                {
                                    marker.MarkerText = marker.DefaultMarkerText;

                                }

                                marker.IsVisible = showPlots;
                            }
                        }
                    }
                }
                else
                {
                    if (showPlots == false)
                        return;

                    gMapControl1.MarkersEnabled = true;
                    gMapControl1.PolygonsEnabled = true;


                    List<PointLatLng> points = new List<PointLatLng>();

                    GMapOverlay polyOverlay = new GMapOverlay(gMapControl1, "overlayplot");
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
                                //Color.GreenYellow
                                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));
                                polygon.Stroke = new Pen(Color.DarkGreen, 1);
                                polyOverlay.Polygons.Add(polygon);




                            }
                            else
                            {


                                GMapPolygon polygon = new GMapPolygon(points, zone.ZoneName);
                                //Color.GreenYellow

                                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.GreenYellow));

                                polygon.Stroke = new Pen(Color.DarkGreen, 1);
                                polygon.Tag = zone.Id;

                                if (zoneId > 0)
                                {
                                    if (zoneId == zone.Id)
                                    {
                                        IsVisible = true;
                                        polygon.IsVisible = true;
                                    }
                                    else
                                    {
                                        IsVisible = false;
                                        polygon.IsVisible = false;

                                    }
                                }


                                polyOverlay.Polygons.Add(polygon);

                            }



                            GMapMarkerText marker = new GMapMarkerText(new PointLatLng(points.Sum(c => c.Lat) / points.Count, points.Sum(c => c.Lng) / points.Count), zone.ZoneName.ToStr());
                            //marker.ToolTip = new GMapBaloonToolTip(marker);
                            //--------------------edited section----------------------
                            marker.ToolTip = new GMapToolTip(marker);
                            marker.ToolTip.Stroke = new Pen(Color.Transparent);
                            marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                            Point offset = new Point(0, 0);
                            marker.ToolTip.Offset = offset;
                            //--------------------end edited section-------------------------



                            marker.IsVisible = IsVisible;
                            marker.Tag = zone.Id;
                            marker.MarkerText2 = zone.OrderNo.ToStr();
                            marker.DefaultMarkerText = marker.MarkerText;
                            //polyOverlay.Markers.Add(m);
                            polyOverlay.Markers.Add(marker);


                        }

                    }


                    gMapControl1.Overlays.Add(polyOverlay);

                }
            }
            catch (Exception ex)
            {


            }

        }


        string CheckTag = "";
        public static int checkindex = 0;
        public static int accepteddateindex = 0;

        public static int accepteddateindex1 = 0;



        public string bookingNum = "";
        GMapMarkerCustom marker2 = null;
        DateTime? _pickupDateTime = null;
        DateTime? _acceptDateTime = null;
        DateTime? _arriveDateTime = null;
        DateTime? _pobDateTime = null;
        DateTime? _stcDateTime = null;
        DateTime? _clearedDateTime = null;

        List<CoordinatesWithUpdatedDate> datalst;

        private void grdLister_CommandCellClick(object sender, EventArgs e)
        {

            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            try
            {
                if (gridCell.ColumnInfo.Name.ToString() == "btnViewMap")
                {


                    if (gMapControl1.Overlays[0].Markers.Count > 0)
                    {
                        var m = gMapControl1.Overlays[0].Markers.ToList();
                        foreach (var val in m)
                        {
                            if (val != null)
                            {
                                if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                    //|| val.Tag.ToStr() == "8" || val.Tag.ToStr() == "9"
                                    || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6" || val.Tag.ToStr() == "7")
                                {
                                    polyOverlay1.Markers.Remove(val);
                                }

                            }
                        }

                    }


                    radchkAll.Checked = false;
                    _arriveDateTime = null;
                    _pobDateTime = null;
                    _stcDateTime = null;

                    if (btnPlayNav.Enabled == false)
                    {
                        stop = true;
                        //StopNavigationOnZoomChange();
                        marker15.IsVisible = false;
                        marker14.IsVisible = false;
                        _pickupDateTime = null;
                        _acceptDateTime = null;
                        _arriveDateTime = null;
                        _pobDateTime = null;
                        _stcDateTime = null;
                        _clearedDateTime = null;


                    }

                    marker14.IsVisible = false;
                    marker15.IsVisible = false;
                    marker7.IsVisible = false;


                    long? jobid = Convert.ToInt64(grdLister.CurrentRow.Cells[COLS.ID].Value.ToStr());
                    DateTime acceptedate = grdLister.CurrentRow.Cells[COLS.AcceptedDateTime].Value.ToDateTime();
                    DateTime arriveddate = grdLister.CurrentRow.Cells[COLS.ArrivalDateTime].Value.ToDateTime();
                    DateTime picupdate = grdLister.CurrentRow.Cells[COLS.Pickupdatetime].Value.ToDateTime();
                    DateTime pobdate = grdLister.CurrentRow.Cells[COLS.POBDateTime].Value.ToDateTime();
                    DateTime stcdate = grdLister.CurrentRow.Cells[COLS.STCDateTime].Value.ToDateTime();
                    DateTime cleareddate = grdLister.CurrentRow.Cells[COLS.Cleareddatetime].Value.ToDateTime();

                    //----------------------------new code-------------------------------------------------

                    datalst = cooddt.Where(x => x.JobId == jobid).ToList();

                    if (datalst.Count <= 0)
                    {
                        ENUtils.ShowMessage("Job does not exists!");
                        return;
                    }
                    //---------------------------tracker new values assignment---------------------------------------
                    if (cleareddate == "01/01/0001 00:00".ToDateTime())
                    {
                        if (stcdate == "01/01/0001 00:00".ToDateTime())
                        {
                            if (pobdate == "01/01/0001 00:00".ToDateTime())
                            {
                                if (arriveddate == "01/01/0001 00:00".ToDateTime())
                                {
                                    trackBar1.Maximum = acceptedate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                    lblEnd.Text = "(" + acceptedate.ToDateTime().ToString("HH:mm") + ")";
                                }
                                else
                                {
                                    trackBar1.Maximum = arriveddate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                    lblEnd.Text = "(" + arriveddate.ToDateTime().ToString("HH:mm") + ")";
                                }
                            }
                            else
                            {
                                trackBar1.Maximum = pobdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                                lblEnd.Text = "(" + pobdate.ToDateTime().ToString("HH:mm") + ")";
                            }
                        }
                        else
                        {
                            trackBar1.Maximum = stcdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();

                            lblEnd.Text = "(" + stcdate.ToDateTime().ToString("HH:mm") + ")";
                        }
                    }
                    else
                    {
                        trackBar1.Maximum = cleareddate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                        lblEnd.Text = "(" + cleareddate.ToDateTime().ToString("HH:mm") + ")";
                    }


               //-------------------------------------------------------------------------------------------
                    if (acceptedate == "01/01/0001 00:00".ToDateTime())
                    {
                        if (arriveddate == "01/01/0001 00:00".ToDateTime())
                        {
                            if (picupdate == "01/01/0001 00:00".ToDateTime())
                            {
                                if (pobdate == "01/01/0001 00:00".ToDateTime())
                                {

                                    if (stcdate == "01/01/0001 00:00".ToDateTime())
                                    {
                                        trackBar1.Minimum = cleareddate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                        lblStart.Text = "(" + cleareddate.ToDateTime().ToString("HH:mm") + ")";
                                    }
                                    else
                                    {
                                        trackBar1.Minimum = stcdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                        lblStart.Text = "(" + stcdate.ToDateTime().ToString("HH:mm") + ")";
                                    }

                                }
                                else
                                {

                                    trackBar1.Minimum = pobdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                    lblStart.Text = "(" + pobdate.ToDateTime().ToString("HH:mm") + ")";
                                }


                            }
                            else
                            {

                                trackBar1.Minimum = picupdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                                lblStart.Text = "(" + picupdate.ToDateTime().ToString("HH:mm") + ")";
                            }
                        }
                        else
                        {
                            trackBar1.Minimum = arriveddate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                            lblStart.Text = "(" + arriveddate.ToDateTime().ToString("HH:mm") + ")";
                        }

                    }
                    else
                    {
                        trackBar1.Minimum = acceptedate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                        lblStart.Text = "(" + acceptedate.ToDateTime().ToString("HH:mm") + ")";
                    }


                    //---------------------------------------------------------------------------------------------



                    trackBar1.Visible = true;
                    trackBar1.Enabled = true;
                    var first = datalst.First();
                    var last = datalst.Last();

                    DateTime dtfrom = first.UpdateDate.ToDateTime();// cooddtListOfUpdatedDate.FirstOrDefault();
                    //DateTime dtto = last.UpdateDate.ToDateTime(); //objset.ListOfUpdatedDate.LastOrDefault();
                    //lblStart.Text = "(" + dtfrom.ToDateTime().ToString("HH:mm") + ")";
                    //trackBar1.Minimum = dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                    trackBar1.Value = trackBar1.Minimum; //dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                    min = trackBar1.Minimum;//dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                    max = trackBar1.Maximum;
                    percentComplete = (int)Math.Round((double)(100 * min) / max);


                    //-----------------------------------------------------------------------------------------------


                    GMapOverlay obj = new GMapOverlay(gMapControl1, "overlay1");

                    gMapControl1.Overlays.Remove(obj);
                    gMapControl1.Overlays[0].Markers.Clear();
                    gMapControl1.Overlays[0].Routes.Clear();
                    polyOverlay1.Routes.Clear();


                    DrawPolyVertices(1, 7, datalst);

                    pnlRouteActions.Visible = true;
                    pnlRouteActions.BringToFront();
                    gMapControl1.BringToFront();

                    //----------------------------


                     

                    //----------------------------


                    accepteddateindex = acceptedate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate >= acceptedate);
                    int arriveddateindex = arriveddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate >= arriveddate);
                    int pickupindex = picupdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate >= picupdate);
                    int pobdateindex = pobdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate >= pobdate);
                    int stcddateindex = stcdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate >= stcdate);

                    //
                    int clearddateindex = cleareddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindLastIndex(x => x.UpdateDate.AddSeconds(60) >= cleareddate);





                    //cleareddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate.AddSeconds(90) >= cleareddate);
                    //if (clearddateindex == -1)
                    //{                       
                    //    clearddateindex = datalst.FindLastIndex(x => x.UpdateDate <= cleareddate);
                    //    clearddateindex = cleareddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindLastIndex(x => x.UpdateDate <= cleareddate);
                    //}
                    //if (stcddateindex == -1)
                    //{
                    //    stcddateindex = stcdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : datalst.FindIndex(x => x.UpdateDate <= stcdate);

                    //}



                    //----------------------------new code-------------------------------------------------


                    /*
                    accepteddateindex = acceptedate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= acceptedate); 
                    int arriveddateindex = arriveddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= arriveddate);
                    int pickupindex = picupdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= picupdate);
                    int pobdateindex = pobdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= pobdate);
                    int stcddateindex = stcdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= stcdate);
                    int clearddateindex = cleareddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= cleareddate);
                    */



                    marker14.IsVisible = false;
                    marker15.IsVisible = false;
                    marker7.IsVisible = false;

                    //--------------------------------------------------------------------------------------------------------------

                    int? index = 0;

                    index = accepteddateindex == -1 ? arriveddateindex : accepteddateindex;
                    //index = index == -1 ? pickupindex : index;
                    index = index == -1 ? pobdateindex : index;
                    index = index == -1 ? stcddateindex : index;
                    index = index == -1 ? clearddateindex : index;

                    if (accepteddateindex.Equals(-1))
                    {
                        _acceptDateTime = null;
                    }
                    else
                    {
                        _acceptDateTime = datalst[accepteddateindex].UpdateDate.ToDateTime();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute, new Size(30, 30));
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = acceptedate;
                        //DateTime date = acceptedate.ToDate();
                        //dtTrackBar = date + time;

                        marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[accepteddateindex].Lat), Convert.ToDouble(datalst[accepteddateindex].Lng)), null);
                        marker2.Tag = "2";
                        marker2.Position = new PointLatLng(Convert.ToDouble(datalst[accepteddateindex].Lat), Convert.ToDouble(datalst[accepteddateindex].Lng));
                        marker2.ToolTipText = "Accepted at : " + string.Format("{0:dd/MM/yyyy HH:mm}", acceptedate);
                        marker2.ToolTipMode = MarkerTooltipMode.Always;

                        marker2.ToolTip.Font = f;
                        marker2.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_OnRoute;
                        polyOverlay1.Markers.Add(marker2);

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }

                    /*
                    if (arriveddateindex.Equals(-1))
                    {
                        _arriveDateTime = null;
                    }
                    else
                    {
                        _arriveDateTime = cooddt[arriveddateindex].UpdateDate.ToDateTime();

                        polyOverlay1 = gMapControl1.Overlays[0];

                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        DateTime date = acceptedate;

                        GMapMarkerCustom marker6 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[arriveddateindex].Lat), Convert.ToDouble(cooddt[arriveddateindex].Lng)), null);


                        marker6.Tag = "6";
                        marker6.Position = new PointLatLng(Convert.ToDouble(cooddt[arriveddateindex].Lat), Convert.ToDouble(cooddt[arriveddateindex].Lng));

                        marker6.ToolTipText = "Destination at : " + string.Format("{0:dd/MM/yyyy HH:mm}", arriveddate);
                        marker6.MarkerImage = null;
                        marker6.ToolTipMode = MarkerTooltipMode.Always;
                        marker6.ToolTip.Font = f;
                        polyOverlay1.Markers.Add(marker6);
                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }


                    }
                    */



                    //pickupindex
                    if (arriveddateindex.Equals(-1))
                    {
                        //_pickupDateTime = null;
                        _arriveDateTime = null;
                    }
                    else
                    {
                        //_pickupDateTime = cooddt[pickupindex].UpdateDate.ToDateTime();

                        _arriveDateTime = datalst[arriveddateindex].UpdateDate.ToDateTime();


                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_Arrived);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);

                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);

                        //DateTime date = picupdate.ToDate();
                        //pickupindex
                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[arriveddateindex].Lat), Convert.ToDouble(datalst[arriveddateindex].Lng)), null);


                        marker1.Tag = "1";                                       //pickupindex                              //pickupindex
                        marker1.Position = new PointLatLng(Convert.ToDouble(datalst[arriveddateindex].Lat), Convert.ToDouble(datalst[arriveddateindex].Lng));

                        //picupdate was replaced with arrieveddate
                        marker1.ToolTipText = "Arrived at : " + string.Format("{0:dd/MM/yyyy HH:mm}", arriveddate);

                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = f;
                        marker1.MarkerImage = Resources.Resource1.arrived;
                        polyOverlay1.Markers.Add(marker1);






                        this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                        {
                            gMapControl1.Position = marker1.Position;
                            //pickupindex                                   //pickupindex
                            gMapControl1.Position = new PointLatLng(Convert.ToDouble(datalst[arriveddateindex].Lat), Convert.ToDouble(datalst[arriveddateindex].Lng));

                            /*
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
                            */
                        });

                    }


                    if (pobdateindex.Equals(-1))
                    {
                        _pobDateTime = null;
                    }
                    else
                    {
                        _pobDateTime = datalst[pobdateindex].UpdateDate.ToDateTime();

                        //int pobindx = pobdateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        //var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = acceptedate;
                        //dtTrackBar = date + time;


                        GMapMarkerCustom marker4 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[pobdateindex].Lat), Convert.ToDouble(datalst[pobdateindex].Lng)), Resources.Resource1.pob);


                        marker4.Tag = "4";
                        marker4.Position = new PointLatLng(Convert.ToDouble(datalst[pobdateindex].Lat), Convert.ToDouble(datalst[pobdateindex].Lng));
                        marker4.ToolTipText = "POB at : " + string.Format("{0:dd/MM/yyyy HH:mm}", pobdate);

                        marker4.ToolTipMode = MarkerTooltipMode.Always;
                        marker4.ToolTip.Font = f;
                        polyOverlay1.Markers.Add(marker4);

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }

                    if (stcddateindex.Equals(-1))
                    {
                        _stcDateTime = null;
                    }
                    else
                    {

                        _stcDateTime = datalst[stcddateindex].UpdateDate.ToDateTime();


                        polyOverlay1 = gMapControl1.Overlays[0];
                        // var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = stcdate;
                        //dtTrackBar = date + time;
                        //cooddt
                        GMapMarkerCustom marker5 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[stcddateindex].Lat), Convert.ToDouble(datalst[stcddateindex].Lng)), Resources.Resource1.stc);
                        marker5.Position = new PointLatLng(Convert.ToDouble(datalst[stcddateindex].Lat), Convert.ToDouble(datalst[stcddateindex].Lng));
                        marker5.ToolTipText = "STC at : " + string.Format("{0:dd/MM/yyyy HH:mm}", stcdate);


                        marker5.ToolTipMode = MarkerTooltipMode.Always;
                        marker5.ToolTip.Font = f;
                        marker5.Tag = "5";
                        polyOverlay1.Markers.Add(marker5);

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }



                    }


                    if (clearddateindex.Equals(-1))
                    {
                        _clearedDateTime = null;
                    }
                    else
                    {
                        _clearedDateTime = datalst[clearddateindex].UpdateDate.ToDateTime();

                        int clearedindx = clearddateindex.ToInt();
                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = cleareddate;
                        //dtTrackBar = date + time;

                        // if (marker14 == null)
                        //{

                        GMapMarkerCustom marker3 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(datalst[clearddateindex].Lat), Convert.ToDouble(datalst[clearddateindex].Lng)), Resources.Resource1.clear);

                        //}
                        //else
                        marker3.Tag = "3";
                        marker3.Position = new PointLatLng(Convert.ToDouble(datalst[clearddateindex].Lat), Convert.ToDouble(datalst[clearddateindex].Lng));
                        marker3.ToolTipText = "Cleared at : " + string.Format("{0:dd/MM/yyyy HH:mm}", cleareddate);

                        marker3.ToolTipMode = MarkerTooltipMode.Always;
                        marker3.ToolTip.Font = f;
                        polyOverlay1.Markers.Add(marker3);
                        //marker14.MarkerImage = Taxi_AppMain.Properties.Resources.clear;

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }


                    if (index != -1)
                    {
                        //accepteddateindex arriveddateindex pickupindex pobdateindex stcddateindex clearddateindex


                        startFrom = (int)index;
                        checkindex = (int)index;
                        marker14.IsVisible = false;
                        bookingNum = grdLister.CurrentRow.Cells["BookingNo"].Value.ToStr();
                        CheckTag = "visited";
                        pnlRouteActions.Visible = true;
                        pnlRouteActions.BringToFront();


                        //if (gMapControl1.MaxZoom != 18)
                        //{
                        //    double z = gMapControl1.Zoom;
                        //    gMapControl1.Zoom = 15;
                        //}




                        if (datalst.Count > 0)
                        {

                            //gMapControl1.Position = new PointLatLng(datalst[0].Lat, datalst[0].Lng);

                            // gMapControl1.MinZoom = 0;//actual value=0
                            // gMapControl1.MaxZoom = 24;//actual value=24
                            // gMapControl1.Zoom = 14;//actual value=13
                            //gMapControl1.Position= new PointLatLng(datalst[0].Lat, datalst[0].Lng);

                            //gMapControl1.DragButton = MouseButtons.Left;


                            this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                gMapControl1.DragButton = MouseButtons.Left;
                                gMapControl1.Zoom = 14;
                                gMapControl1.Position = new PointLatLng(Convert.ToDouble(datalst[0].Lat), Convert.ToDouble(datalst[0].Lng));



                            });
                        }




                    }


                    else
                    {
                        startFrom = 0;
                        checkindex = 0;
                        CheckTag = "";
                        bookingNum = "";
                        gMapControl1.MinZoom = 0;
                        gMapControl1.MaxZoom = 30;
                        gMapControl1.Zoom = 15;
                    }

                    /*
                    if (btnPlayNav.Enabled == false)
                    {
                        StopNavigationOnZoomChange();
                    }
                    PlotMarkersForEachPosition();
                    */
                }
                else
                {
                    //ENUtils.ShowMessage("Please select a record");
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message.ToString());
            }
            GC.Collect();


        }

        private void PlotMarkersForEachPosition()
        {
            try
            {


                if (gMapControl1.Overlays[0].Markers.Count > 0)
                {
                    var m = gMapControl1.Overlays[0].Markers.ToList();
                    foreach (var val in m)
                    {
                        if (val != null)
                        {
                            if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6")
                            {
                                polyOverlay1.Markers.Remove(val);
                            }

                        }
                    }

                }


                DrawPolyVertices(1, 7, cooddt);

                var first = cooddt.FirstOrDefault();
                string speed = first.Speed.ToStr();
                string driverno = first.driverid.ToStr();

                var lstZoneName = zonelist.Where(x => x.Id == Convert.ToInt32(first.ZoneId)).Select(c => c.ZoneName).ToList();
                var lstdrivername = DriverList.Where(x => x.Id == Convert.ToInt32(_DriverId)).Select(c => c.DriverName).ToList();
                string zonename = "";
                string driver = "";
                if (lstZoneName.Count > 0)
                {
                    zonename = lstZoneName[0].ToStr();
                }
                else
                {
                    zonename = "-";
                }
                if (lstdrivername.Count > 0)
                {
                    driver = lstdrivername[0].ToStr();
                }
                else
                {
                    driver = "-";
                }

                var bmp1 = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                marker14.MarkerImage = bmp1;



                for (int i = 0; i < grdLister.RowCount; i++)
                {

                    DateTime acceptedate = grdLister.Rows[i].Cells[COLS.AcceptedDateTime].Value.ToDateTime();
                    DateTime arriveddate = grdLister.Rows[i].Cells[COLS.ArrivalDateTime].Value.ToDateTime();
                    DateTime picupdate = grdLister.Rows[i].Cells[COLS.Pickupdatetime].Value.ToDateTime();
                    DateTime pobdate = grdLister.Rows[i].Cells[COLS.POBDateTime].Value.ToDateTime();
                    DateTime stcdate = grdLister.Rows[i].Cells[COLS.STCDateTime].Value.ToDateTime();
                    DateTime cleareddate = grdLister.Rows[i].Cells[COLS.Cleareddatetime].Value.ToDateTime();

                    int accepteddateindex = acceptedate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= acceptedate);
                    int arriveddateindex = arriveddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= arriveddate);
                    int pickupindex = picupdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= picupdate);
                    int pobdateindex = pobdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= pobdate);
                    int stcddateindex = stcdate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= stcdate);
                    int clearddateindex = cleareddate.Equals("01/01/0001 00:00".ToDateTime()) ? -1 : cooddt.FindIndex(x => x.UpdateDate >= cleareddate);

                    /*
                    int accepteddateindex = cooddt.FindIndex(x => x.UpdateDate >= acceptedate);
                    int arriveddateindex = cooddt.FindIndex(x => x.UpdateDate >= arriveddate);
                    int pickupindex = cooddt.FindIndex(x => x.UpdateDate >= picupdate);
                    int pobdateindex = cooddt.FindIndex(x => x.UpdateDate >= pobdate);
                    int stcddateindex = cooddt.FindIndex(x => x.UpdateDate >= stcdate);
                    int clearddateindex = cooddt.FindIndex(x => x.UpdateDate >= cleareddate);
                    */


                    if (accepteddateindex != -1)
                    {

                        int accpindx = accepteddateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = acceptedate;
                        //DateTime date = acceptedate.ToDate();
                        //dtTrackBar = date + time;

                        //if (marker14 == null)
                        //{

                        //GMapMarkerCustom 
                        marker2 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[accpindx].Lat), Convert.ToDouble(cooddt[accpindx].Lng)), null);
                        polyOverlay1.Markers.Add(marker2);
                        //}
                        //else
                        marker2.Tag = "2";
                        marker2.Position = new PointLatLng(Convert.ToDouble(cooddt[accpindx].Lat), Convert.ToDouble(cooddt[accpindx].Lng));

                        marker2.ToolTipText = "Accepted at : " + string.Format("{0:dd/MM/yyyy HH:mm}", acceptedate);

                        // marker14.ToolTipText = "Driver  :" + driver + Environment.NewLine + "Plot : " + zonename + Environment.NewLine + "Speed : " + speed + " mph" + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", acceptedate);
                        marker2.ToolTipMode = MarkerTooltipMode.Always;
                        marker2.ToolTip.Font = f;
                        //marker14.MarkerImage = Taxi_AppMain.Properties.Resources.acceptJob; ;
                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }



                    }

                    if (arriveddateindex != -1)
                    {

                        int arrievedindx = arriveddateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        //var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = acceptedate;
                        //dtTrackBar = date + time;

                        //if (marker14 == null)
                        //{

                        GMapMarkerCustom marker6 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[arrievedindx].Lat), Convert.ToDouble(cooddt[arrievedindx].Lng)), Resources.Resource1.arrived);
                        polyOverlay1.Markers.Add(marker6);
                        //}
                        //else
                        marker6.Tag = "6";
                        marker6.Position = new PointLatLng(Convert.ToDouble(cooddt[arrievedindx].Lat), Convert.ToDouble(cooddt[arrievedindx].Lng));

                        marker6.ToolTipText = "Destination at : " + string.Format("{0:dd/MM/yyyy HH:mm}", arriveddate);

                        marker6.ToolTipMode = MarkerTooltipMode.Always;
                        marker6.ToolTip.Font = f;
                        //marker14.MarkerImage = Taxi_AppMain.Properties.Resources.diamond_Arrived;
                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }

                    if (pickupindex != -1)
                    {

                        int indx = pickupindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_Arrived);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);

                        // trackBar1.Value = picupdate.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);




                        GMapMarkerCustom marker1 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[indx].Lat), Convert.ToDouble(cooddt[indx].Lng)), null);
                        polyOverlay1.Markers.Add(marker1);

                        marker1.Tag = "1";
                        marker1.Position = new PointLatLng(Convert.ToDouble(cooddt[indx].Lat), Convert.ToDouble(cooddt[indx].Lng));


                        marker1.ToolTipText = "Arrived at : " + string.Format("{0:dd/MM/yyyy HH:mm}", picupdate);

                        marker1.ToolTipMode = MarkerTooltipMode.Always;
                        marker1.ToolTip.Font = f;
                        marker1.MarkerImage = Resources.Resource1.arrived;

                        this.gMapControl1.BeginInvoke((MethodInvoker)delegate ()
                        {
                            gMapControl1.Position = marker1.Position;

                            gMapControl1.Position = new PointLatLng(Convert.ToDouble(cooddt[indx].Lat), Convert.ToDouble(cooddt[indx].Lng));

                            /*
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
                            */

                        });




                    }

                    if (pobdateindex != -1)
                    {

                        int pobindx = pobdateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_PassengerOnBoard);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = acceptedate;
                        //dtTrackBar = date + time;

                        //if (marker14 == null)
                        //{

                        GMapMarkerCustom marker4 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[pobindx].Lat), Convert.ToDouble(cooddt[pobindx].Lng)), Resources.Resource1.pob);
                        polyOverlay1.Markers.Add(marker4);

                        marker4.Tag = "4";
                        marker4.Position = new PointLatLng(Convert.ToDouble(cooddt[pobindx].Lat), Convert.ToDouble(cooddt[pobindx].Lng));
                        marker4.ToolTipText = "POB at : " + string.Format("{0:dd/MM/yyyy HH:mm}", pobdate);

                        marker4.ToolTipMode = MarkerTooltipMode.Always;
                        marker4.ToolTip.Font = f;

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }

                    if (stcddateindex != -1)
                    {

                        int stcindx = stcddateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        // var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond_OnRoute);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = stcdate;
                        //dtTrackBar = date + time;

                        //if (marker14 == null)
                        //{

                        GMapMarkerCustom marker5 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[stcindx].Lat), Convert.ToDouble(cooddt[stcindx].Lng)), Resources.Resource1.stc);
                        polyOverlay1.Markers.Add(marker5);
                        //}
                        //else
                        marker5.Tag = "5";
                        marker5.Position = new PointLatLng(Convert.ToDouble(cooddt[stcindx].Lat), Convert.ToDouble(cooddt[stcindx].Lng));
                        marker5.ToolTipText = "STC at : " + string.Format("{0:dd/MM/yyyy HH:mm}", stcdate);

                        //marker14.ToolTipText = "Driver  :" + driver + Environment.NewLine + "Plot : " + zonename + Environment.NewLine + "Speed : " + speed + " mph" + Environment.NewLine + "Date Time : " + string.Format("{0:dd/MMM/yy HH:mm:ss}", stcdate);
                        marker5.ToolTipMode = MarkerTooltipMode.Always;
                        marker5.ToolTip.Font = f;
                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }

                    if (clearddateindex != -1)
                    {

                        int clearedindx = clearddateindex.ToInt();

                        polyOverlay1 = gMapControl1.Overlays[0];
                        var bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);
                        Font f = new Font("Tahoma", 6, FontStyle.Bold);
                        int val = trackBar1.Value.ToInt();
                        TimeSpan time = TimeSpan.FromSeconds(val);
                        //DateTime date = cleareddate;
                        //dtTrackBar = date + time;

                        // if (marker14 == null)
                        //{

                        GMapMarkerCustom marker3 = new GMapMarkerCustom(new PointLatLng(Convert.ToDouble(cooddt[clearedindx].Lat), Convert.ToDouble(cooddt[clearedindx].Lng)), Resources.Resource1.clear);
                        polyOverlay1.Markers.Add(marker3);
                        //}
                        //else
                        marker3.Tag = "3";
                        marker3.Position = new PointLatLng(Convert.ToDouble(cooddt[clearedindx].Lat), Convert.ToDouble(cooddt[clearedindx].Lng));
                        marker3.ToolTipText = "Cleared at : " + string.Format("{0:dd/MM/yyyy HH:mm}", cleareddate);

                        marker3.ToolTipMode = MarkerTooltipMode.Always;
                        marker3.ToolTip.Font = f;
                        //marker14.MarkerImage = Taxi_AppMain.Properties.Resources.clear;

                        if (CheckTag != "visited")
                        {
                            checkindex = 0;

                        }

                    }


                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage("Some thing went wrong");
            }
        }


        public void ShowGrid()
        {

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();

            try
            {
                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Id";
                col.ReadOnly = true;
                col.Width = 50;
                col.Name = COLS.ID;
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.IsVisible = true;
                col.ReadOnly = true;
                col.HeaderText = "Ref No";
                col.Width = 50;
                col.Name = COLS.BookingNo;
                grdLister.Columns.Add(col);

                GridViewTextBoxColumn colD = new GridViewTextBoxColumn();

                colD.ReadOnly = true;
                colD.HeaderText = "Pick Up Date";
                colD.Name = COLS.Pickupdatetime;
                colD.Width = 118;
                grdLister.Columns.Add(colD);


                colD = new GridViewTextBoxColumn();
                colD.IsVisible = false;
                colD.ReadOnly = true;
                colD.HeaderText = "Accepted Date Time";
                colD.Name = COLS.AcceptedDateTime;
                colD.Width = 100;
                grdLister.Columns.Add(colD);


                colD = new GridViewTextBoxColumn();
                colD.IsVisible = false;
                colD.ReadOnly = true;
                colD.HeaderText = "Cleared Date Time";
                colD.Name = COLS.Cleareddatetime;
                colD.Width = 100;
                grdLister.Columns.Add(colD);


                colD = new GridViewTextBoxColumn();
                colD.IsVisible = false;
                colD.ReadOnly = true;
                colD.HeaderText = "POB Date Time";
                colD.Name = COLS.POBDateTime;
                colD.Width = 100;
                grdLister.Columns.Add(colD);

                colD = new GridViewTextBoxColumn();
                colD.IsVisible = false;
                colD.ReadOnly = true;
                colD.HeaderText = "STC Date Time";
                colD.Name = COLS.STCDateTime;
                colD.Width = 100;
                grdLister.Columns.Add(colD);


                colD = new GridViewTextBoxColumn();
                colD.IsVisible = false;
                colD.ReadOnly = true;
                colD.HeaderText = "Arrival Date Time";
                colD.Name = COLS.ArrivalDateTime;
                colD.Width = 100;
                grdLister.Columns.Add(colD);


                AddColumn(grdLister);
                grdLister.EnableFiltering = true;
                grdLister.ShowFilteringRow = true;

            }
            catch (Exception ex)
            {


            }
        }

        private void AddColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();
            col.Width = 50;

            col.Name = "btnViewMap";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "zoom";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }


        private void LoadBookingDetail(string bookinglist)
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {


                    btnShowJobDetail.Checked = true;

                    string str = bookinglist;
                    List<string> uniques = new List<string>();
                    uniques = str.Split(',').Reverse().Distinct().ToList();
                    string newStr = string.Join(",", uniques);

                    bookinglist = newStr;


                    var result = db.ExecuteQuery<GetBookingByDriverShifts>(@"exec GetBookingByDriverShifts {0}", bookinglist.ToStr()).ToList();


                    if (result.Count > 0)
                    {
                        grdLister.Visible = true;

                        grdLister.RowCount = result.Count;
                        for (int i = 0; i < result.Count; i++)
                        {
                            grdLister.Rows[i].Cells[COLS.ID].Value = result[i].Id;
                            grdLister.Rows[i].Cells[COLS.BookingNo].Value = result[i].BookingNo;




                            string accpdt = string.IsNullOrEmpty(result[i].AcceptedDateTime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].AcceptedDateTime));
                            grdLister.Rows[i].Cells[COLS.AcceptedDateTime].Value = accpdt; //result[i].AcceptedDateTime;

                            string arriveddt = string.IsNullOrEmpty(result[i].ArrivalDateTime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].ArrivalDateTime));
                            grdLister.Rows[i].Cells[COLS.ArrivalDateTime].Value = arriveddt; //result[i].ArrivalDateTime;

                            string pickupdt = string.IsNullOrEmpty(result[i].Pickupdatetime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].Pickupdatetime));
                            grdLister.Rows[i].Cells[COLS.Pickupdatetime].Value = pickupdt;// result[i].Pickupdatetime;

                            string pobdt = string.IsNullOrEmpty(result[i].POBDateTime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].POBDateTime));
                            grdLister.Rows[i].Cells[COLS.POBDateTime].Value = pobdt; //result[i].POBDateTime;


                            string stcdt = string.IsNullOrEmpty(result[i].STCDateTime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].STCDateTime));
                            grdLister.Rows[i].Cells[COLS.STCDateTime].Value = stcdt;// result[i].STCDateTime;

                            string cleardt = string.IsNullOrEmpty(result[i].Cleareddatetime.ToString()) ? null : (string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].Cleareddatetime));
                            //string.Format("{0:dd/MM/yyyy HH:mm:ss}", result[i].Cleareddatetime);
                            grdLister.Rows[i].Cells[COLS.Cleareddatetime].Value = cleardt;// result[i].Cleareddatetime;


                        }
                    }

                    this.grdLister.ClearSelection();
                }

            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }

        private void radSkipZero_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void radchkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            if (radchkAll.Checked)
            {
                if (grdLister.RowCount > 0)
                {
                    gMapControl1.MinZoom = 0;
                    gMapControl1.MaxZoom = 24;
                    gMapControl1.Zoom = 13;

                    if (gMapControl1.Overlays[0].Markers.Count > 0)
                    {
                        var m = gMapControl1.Overlays[0].Markers.ToList();
                        foreach (var val in m)
                        {
                            if (val != null)
                            {
                                if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                    || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6")
                                {
                                    polyOverlay1.Markers.Remove(val);
                                }

                            }
                        }

                    }
                    this.grdLister.ClearSelection();

                    CheckTag = "";
                    marker14.IsVisible = true;
                    marker7.IsVisible = true;
                    PlotMarkersForEachPosition();
                }
            }
            else
            {


            }

        }

        private void btnShowJobDetail_Click(object sender, EventArgs e)
        {
            if (btnShowJobDetail.Checked == true)
            {
                if (btnPlayNav.Enabled == false)
                {
                    stop = true;
                }
                grdLister.Visible = true;


                if (bookingid != "")
                {

                    this.grdLister.Columns.Clear();
                    ShowGrid();
                    LoadBookingDetail(bookingid);
                    if (grdLister.RowCount > 0)
                    {
                        radchkAll.Checked = true;
                        PlotMarkersForEachPosition();
                    }

                }
            }
            else
            {
                grdLister.Visible = false;
                marker14.IsVisible = false;
                marker7.IsVisible = true;
                if (CheckTag == "visited")
                {
                    marker15.IsVisible = true;
                    marker14.IsVisible = false;

                }

                CheckTag = "";
                checkindex = 0;
                bookingNum = "";

                if (btnPlayNav.Enabled == false)
                {

                    stop = true;
                    marker14.IsVisible = false;

                }

                _pickupDateTime = null;
                _acceptDateTime = null;
                _arriveDateTime = null;
                _pobDateTime = null;
                _stcDateTime = null;
                _clearedDateTime = null;
                acceptDateTime = null;
                clearedDateTime = null;


                this.grdLister.ClearSelection();
                this.grdLister.DataSource = null;
                this.grdLister.Columns.Clear();
                this.grdLister.Rows.Clear();

                gMapControl1.MinZoom = 0;
                gMapControl1.MaxZoom = 24;
                gMapControl1.Zoom = 13;

                bmp = new Bitmap(Taxi_AppMain.Properties.Resources.diamond);
                pointsAndDates = cooddt;

                //marker14.MarkerImage =bmp;
                //marker14.IsVisible = true;
                //marker7.IsVisible = true;

                if (gMapControl1.Overlays[0].Markers.Count > 0)
                {
                    var m = gMapControl1.Overlays[0].Markers.ToList();
                    foreach (var val in m)
                    {
                        if (val != null)
                        {
                            if (val.Tag.ToStr() == "1" || val.Tag.ToStr() == "2" || val.Tag.ToStr() == "3"
                                || val.Tag.ToStr() == "4" || val.Tag.ToStr() == "5" || val.Tag.ToStr() == "6")
                            {
                                polyOverlay1.Markers.Remove(val);
                            }

                        }
                    }

                }

                var first = cooddt.FirstOrDefault();
                DateTime dtfrom = first.UpdateDate.ToDateTime();
                var last = cooddt.LastOrDefault();
                DateTime dtto = last.UpdateDate.ToDateTime();
                               
                lblStart.Text = "(" + dtfrom.ToDateTime().ToString("HH:mm") + ")";
                trackBar1.Minimum = dtfrom.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                lblEnd.Text = "(" + dtto.ToDateTime().ToString("HH:mm") + ")";
                trackBar1.Maximum = dtto.ToDateTime().TimeOfDay.TotalSeconds.ToInt();
                trackBar1.Value = trackBar1.Minimum;
           
                min = trackBar1.Minimum;
                max = trackBar1.Maximum;
                percentComplete = (int)Math.Round((double)(100 * min) / max);
                             


                DrawPolyVertices(7, 1, cooddt);
            }
        }

        private void btnShowPlots_Click(object sender, EventArgs e)
        {
            if (btnShowPlots.Checked)
            {

                DrawPlotsOnMap(true, 0);

            }
            else
            {
                DrawPlotsOnMap(false, 0);


            }
        }

        private void btnSkipZeroSpeed_Click(object sender, EventArgs e)
        {
            if (btnSkipZeroSpeed.Checked)
            {
                btnSkipZeroSpeed.Checked = true;

            }
            else
            {
                btnSkipZeroSpeed.Checked = false;

            }
        }

        private void btnAutoZoom_Click(object sender, EventArgs e)
        {

        }





    }
}
