using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Taxi_AppMain.Classes;
using Taxi_Model;
using Telerik.WinControls.UI;
using System.Net.NetworkInformation;
using System.Threading;
using UI;
using System.Xml.Linq;
using System.IO;

namespace Taxi_AppMain
{
    public partial class frmMessages : Form
    {
        delegate void UIDelegate();

        private int _driverId;
    
        public int DriverId
        {
            get { return _driverId; }
            set { _driverId = value; }
        }

        //private Fleet_Driver _ObjDriver;

        //public Fleet_Driver ObjDriver
        //{
        //    get { return _ObjDriver; }
        //    set { _ObjDriver = value; }
        //}

        public frmMessages(int driverId)
        {
            InitializeComponent();

            this.DriverId = driverId;
            InitializeConstructor();
         

            txtMessage.TextChanged += new EventHandler(txt_TextChanged);
            txtMessage.ListBoxElement.Width = 500;
            txtMessage.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtMessage.ListBoxElement.Height = 100;
           // txtMessage.ListBoxElement.Show();
           // txtMessage.KeyDown += new KeyEventHandler(txtFromAddress_KeyDown);

            txtMessage.KeyDown += new KeyEventHandler(txtMessage_KeyDown);
        }






        private string DriverNo,MobileNo,DriverName, PDAMobileNo;
        private bool HasPDA;

        private void InitializeConstructor()
        {

            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var obj = db.Fleet_Drivers.Where(c => c.Id == this.DriverId).Select(args => new { args.Id, args.DriverNo, args.DriverName, args.HasPDA, args.MobileNo, args.PDAMobileNo }).FirstOrDefault();

                    PDAMobileNo = obj.PDAMobileNo.ToStr().Trim();
                    MobileNo = obj.MobileNo.ToStr().Trim();
                    DriverNo = obj.DriverNo.ToStr().Trim();
                    DriverName = obj.DriverName.ToStr().Trim();
                    HasPDA = obj.HasPDA.ToBool();

                }

                //  this.ObjDriver = General.GetObject<Fleet_Driver>(c => c.Id == this.DriverId);

                btnTestConn.Enabled = Convert.ToBoolean(HasPDA);
                if (btnTestConn.Enabled == false)
                    txtTitle.Width += 112;


                LoadConversation();



                //   timer1.Start();
                this.Shown += new EventHandler(frmMessages_Shown);

                txtTitle.Text = DriverNo + " - " + DriverName;


                RadListDataItem item = new RadListDataItem();
                item.Text = "Today";
                item.Value = "0";
                item.Selected = true;
                ddlShow.Items.Add(item);


                item = new RadListDataItem();
                item.Text = "Yesterday";
                item.Value = "1";
                ddlShow.Items.Add(item);


                item = new RadListDataItem();
                item.Text = "Customer";
                item.Value = "2";
                ddlShow.Items.Add(item);

                item = new RadListDataItem();
                item.Text = "All";
                item.Value = "365";
                ddlShow.Items.Add(item);


                ddlShow.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlShow_SelectedIndexChanged);
                //   this.FormClosing += new FormClosingEventHandler(frmMessages_FormClosing);


                if (AppVars.listUserRights.Count(c => c.functionId == "DISABLE VIEW ALL MESSAGES") > 0)
                {


                    ddlShow.Visible = false;
                }

            }
            catch
            {

            }
        }


        
        //void frmMessages_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //  //  IsOnClosed = true;
        //}

        void frmMessages_Shown(object sender, EventArgs e)
        {
            txtMessage.Focus();
        }


        private void LoadConversation()
        {
            try
            {
                txtConversation.Clear();
                string result=string.Empty;

                int val=ddlShow.SelectedValue.ToInt();

                //try
                //{
                //    File.AppendAllText(Application.StartupPath + "\\message_step1.txt", DateTime.Now + Environment.NewLine);

                //}
                //catch
                //{

                //}

                using (TaxiDataContext db = new TaxiDataContext())
                {


                    if (val == 2)
                    {
                        string[] data =db.Booking_Notes.Where(c => c.AddBy != null && c.AddOn != null && c.AddBy == DriverId)
                                .OrderBy(c => c.AddOn)
                                    .Select(a => "[Ref #:" + a.Booking.BookingNo + "] <b> " + a.Booking.CustomerName + "(" + a.Booking.CustomerMobileNo + ")" + ": </b>" + a.notes).ToArray<string>();

                        result = string.Join("\n\n", data);


                    }

                    else
                    {

                        DateTime filterDate = DateTime.Now.AddDays(-val).ToDate();
                        string dateFormat = ddlShow.SelectedValue.ToInt() == 0 ? "{0:HH:mm}" : "{0:dd/MM HH:mm}";

                        //try
                        //{
                        //    File.AppendAllText(Application.StartupPath + "\\message_step2.txt", DateTime.Now + Environment.NewLine);

                        //}
                        //catch
                        //{

                        //}

                        string[] data = null;
                        if (ddlShow.SelectedValue.ToInt() == 0)
                        {
                            data = (from a in db.Messages

                                    where a.MessageCreatedOn.Value.Date >= filterDate.Date &&

                               ((a.SenderId != null && a.SenderId == DriverId && a.SendFrom == "pda") || (a.ReceiverId != null && a.ReceiverId == DriverId))
                                    orderby a.MessageCreatedOn
                                    orderby a.Id
                                    select ("[" + a.MessageSource.Substring(a.MessageSource.IndexOf(' ') + 1) + "] <b>" + a.SenderName + ": </b>" + a.MessageBody))

                                        .ToArray<string>();

                            //try
                            //{
                            //    File.AppendAllText(Application.StartupPath + "\\message_step3.txt", DateTime.Now + Environment.NewLine);

                            //}
                            //catch
                            //{

                            //}
                        }
                        else
                        {
                            data = (from a in db.Messages

                                    where a.MessageCreatedOn.Value.Date >= filterDate.Date &&

                               ((a.SenderId != null && a.SenderId == DriverId && a.SendFrom == "pda") || (a.ReceiverId != null && a.ReceiverId == DriverId))
                                    orderby a.MessageCreatedOn
                                    orderby a.Id
                                    select ("[" + a.MessageSource + "] <b>" + a.SenderName + ": </b>" + a.MessageBody))

                                        .ToArray<string>();

                            //try
                            //{
                            //    File.AppendAllText(Application.StartupPath + "\\message_step4.txt", DateTime.Now + Environment.NewLine);

                            //}
                            //catch
                            //{

                            //}

                        }


                        if (data != null)
                        {
                            result = string.Join("\n\n", data);
                        }


                    }
                }

                //try
                //{
                //    File.AppendAllText(Application.StartupPath + "\\message_step5.txt", DateTime.Now + Environment.NewLine);

                //}
                //catch
                //{

                //}
                txtConversation.AddHTML(result);
                //try
                //{
                //    File.AppendAllText(Application.StartupPath + "\\message_step6.txt", DateTime.Now + Environment.NewLine);

                //}
                //catch
                //{

                //}
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }




        private void btnSend_Click(object sender, EventArgs e)
        {
            SendAndClear();

        }

        private void SendAndClear()
        {
            new Thread(delegate()
            {
                SendMessage();
                ClearText();
            }).Start(); 
            

        }


        private void SendMessage()
        {

            try
            {
             

                string text = txtMessage.Text.Trim();

           

                if(string.IsNullOrEmpty(text))
                    return;

                bool IsPdaMsg =HasPDA;

                if (IsPdaMsg)
                {
                

                    SendData(text,IsPdaMsg);

                                  
                }
                else
                {

                    General.SP_SendMessage(AppVars.LoginObj.LuserId.ToInt(), DriverId, AppVars.LoginObj.UserName.ToStr(), DriverNo, text, DateTime.Now, "", MobileNo.ToStr().Trim(), PDAMobileNo.ToStr().Trim(), IsPdaMsg);



                }


                General.SaveTemplate(text, DriverNo);

                if (text.ToStr().ToLower().Trim() == "unpanic")
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.stp_PanicUnPanicDriver(DriverId, false);

                    }
                    new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);

                }

               // General.SaveSentSMS(text, "Drv " + ObjDriver.DriverNo + " (" + ObjDriver.MobileNo.ToStr().Trim()+")");


            }
            catch (Exception ex)
            {


            }
        }

      

        private void SendData(string text, bool IsPdaMsg)
        {


           

                try
                {

                    int loopCnt = 1;


                    while (loopCnt < 3)
                    {

                        bool success = General.SP_SendMessage(AppVars.LoginObj.LuserId.ToInt(), DriverId, AppVars.LoginObj.UserName.ToStr(), DriverNo, text, DateTime.Now, "", MobileNo.ToStr().Trim(), PDAMobileNo.ToStr().Trim(), IsPdaMsg);

                        if (success)
                        {
                            break;

                        }
                        else
                             loopCnt++;


                    }

                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new UIDelegate(LoadConversation));
                    }
                    else
                    {

                        LoadConversation();
                    }
                }
                catch (Exception ex)
                {


                }

            

        }

    

        private void CallConnectionError()
        {


            if (this.IsHandleCreated == false || this.IsDisposed)
                return;

            MethodInvoker mi = new MethodInvoker(delegate() { ShowConnectionError(); });
            this.Invoke(mi);


        }


        private void ShowConnectionError()
        {

            RadDesktopAlert alert = new Telerik.WinControls.UI.RadDesktopAlert();

            alert.AutoCloseDelay = 5;
            alert.FadeAnimationType = FadeAnimationType.None;

            alert.ShowOptionsButton = false;
            alert.ShowPinButton = false;

            alert.FixedSize = new Size(250, 100);

            alert.CaptionText = "Connection Problem";
            alert.ContentText = "<html> <b><span style=font-size:medium><color=Red>Your Internet Connection is not working..</span></b></html>";
            alert.Show();

        }     

    

        private void ClearText()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UIDelegate(OnClearText));
            }
            else
            {

                OnClearText();
            }

            

          
        }

        private void OnClearText()
        {

            txtMessage.Clear();

            txtMessage.ResetText();

        }


        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Shift && e.KeyCode == Keys.Enter)
                {
                    txtMessage.AppendText(Environment.NewLine);

                }
                else if (e.KeyCode == Keys.Enter)
                {


                    SendAndClear();

                }
            }
            catch (Exception ex)
            {
             //   ENUtils.ShowMessage(ex.Message);

            }
        }

        private void ddlShow_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            LoadConversation();
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "test connection from server";


           
                SendAndClear();
            
        }


     

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                frmDrivertemplet frm = new frmDrivertemplet();
                frm.ShowDialog();

                this.txtMessage.Text = frm.SelectedTemplate.ToStr();
                frm.Dispose();

            }
            catch (Exception ex)
            {


            }
        }

        private void addTemplatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                frmAddDrivertemplet frmadd = new frmAddDrivertemplet();
                frmadd.ShowDialog();
                frmadd.Dispose();


            }
            catch (Exception ex)
            {

            }
        }

   
       
        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {

               



                TextSelect();
              
            }
            catch (Exception ex)
            {

            }
        }

        private void TextSelect()
        {

            try
            {

                if (txtMessage.Text.Trim().Length == 0)
                {

                    txtMessage.ListBoxElement.Items.Clear();
                    this.Size = new Size(this.Size.Width, 388);
                    radPanel2.Size = new Size(radPanel2.Size.Width, 56);
                    return;
                }

                txtMessage.ListBoxElement.Items.Clear();
                string[] res = null;
                using (Taxi_Model.TaxiDataContext con = new TaxiDataContext())
                {
                    con.CommandTimeout = 4;
                    if (txtMessage.Text == "")
                    { res = con.Fleet_DriverTemplets.Take(0).Select(w => w.Templets).ToArray(); }
                    else
                        res = con.Fleet_DriverTemplets.Where(w => w.Templets.StartsWith(txtMessage.Text)).Select(w => w.Templets).ToArray();

                }
                txtMessage.ListBoxElement.Items.AddRange(res);

                if (res.Count() > 0)
                {
                    txtMessage.ShowListBox();

                    txtMessage.ListBoxElement.BringToFront();
                    txtMessage.ListBoxElement.ScrollAlwaysVisible = true;

                    this.Size = new Size(this.Size.Width, 490);
                    radPanel2.Size = new Size(radPanel2.Size.Width, 160);
                    txtMessage.ListBoxElement.Height = 100;
                }
                else
                {
                    txtMessage.ListBoxElement.Hide();
                    txtMessage.ListBoxElement.Items.RemoveAt(0);

                    this.Size = new Size(this.Size.Width, 388);
                    radPanel2.Size = new Size(radPanel2.Size.Width, 56);
                }
                if (txtMessage.Text != txtMessage.FormerValue)
                {
                    txtMessage.FormerValue = txtMessage.Text;
                }
            }
            catch
            {
                this.Size = new Size(this.Size.Width, 388);
                radPanel2.Size = new Size(radPanel2.Size.Width, 56);
            }
          
        }

       

       
    }
}
