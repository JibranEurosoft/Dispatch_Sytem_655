using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls;

namespace Taxi_AppMain
{
    public partial class frmManageRecentAddresses : UI.SetupBase
    {
        RadDropDownMenu mnuGrd = null;

        public frmManageRecentAddresses()
        {
            InitializeComponent();
            FormatGrid();
            this.Load += new EventHandler(frmManageRecentAddresses_Load);

            grdLister.ContextMenuOpening += new ContextMenuOpeningEventHandler(grdLister_ContextMenuOpening);
        }

        private Button btnChar;
        void frmManageRecentAddresses_Load(object sender, EventArgs e)
        {
         

            if (AppVars.listUserRights.Count(c => c.functionId == "DELETE ALL RECENT ADDRESSES") == 0)
                btnClearAddresses.Visible = false;


            int x = 16;
            int y = 55;
            for(int i=0; i<26; i++ )
            {


                this.btnChar =new Button();
                this.panel1.Controls.Add(this.btnChar);
                // btnChar
                // 
                this.btnChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
                this.btnChar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnChar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
                this.btnChar.Location = new System.Drawing.Point(x, y);
                this.btnChar.Name = "btnChar";
                this.btnChar.Size = new System.Drawing.Size(42, 32);
                this.btnChar.TabIndex = 15;
                this.btnChar.Text = ((char)(65+i)).ToStr();
                this.btnChar.Click += BtnChar_Click;
             
                x += 68;


                if (this.btnChar.Text =="O")
                {
                    x = 16;
                    y = 95;

                }
            }

        }

        private void BtnChar_Click(object sender, EventArgs e)
        {
            try
            {
                Button obj=(Button) sender;

                if (obj.Tag == null)
                {
                    obj.Tag = obj.Text;

                    obj.BackColor = Color.GreenYellow;
                    LoadRecentAddress(obj.Text, "*");

                    foreach (var item in panel1.Controls)
                    {
                        if (item is Button)
                        {

                            if ((item as Button).Text != obj.Text)
                            {

                                (item as Button).Click -= BtnChar_Click;
                                (item as Button).Tag = null;
                                (item as Button).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
                                (item as Button).Click += BtnChar_Click;
                            }
                          
                        }

                    }
                }
                else
                {
                    obj.Tag = null;
                    obj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));


                }
            }
            catch (Exception ex)
            {

            }
        }

  
        public struct COLS
        {
            public static string Id = "Id";
            public static string AddressLine1 = "AddressLine1";
            public static string Address = "Address";
        }
        public void FormatGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.Id;
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.AddressLine1;
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.Address;
            col.HeaderText = COLS.Address;
            col.Width = 650;
            grdLister.Columns.Add(col);


            GridViewCommandColumn colD = new GridViewCommandColumn();
            colD.Width = 60;
            colD.Name = "btnDelete";
            colD.UseDefaultText = true;
            colD.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            colD.DefaultText = "Delete";
            colD.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdLister.Columns.Add(colD);

            //  grdLister.AddDeleteColumn();
            grdLister.Columns["btnDelete"].Width = 80;

            this.grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);

         //   this.grdLister.AutoCellFormatting = false;
            this.grdLister.ShowFilteringRow = true;
            this.grdLister.EnableFiltering = true;
        }

        private void AddCommandColumn(RadGridView grid, string colName, string caption)
        {

            if (grid.Columns.Contains(colName))
                return;


            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 60;

            col.Name = colName;
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = caption;
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }

        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;

                if (gridCell.ColumnInfo.Name == "btnDelete")
                {
                    DeleteAddresses();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        private void LoadRecentAddress(string keyword,string keywordType)
        {

            if (keyword.ToStr().Trim().Length == 0)
                return;
            try
            {

                if (keywordType == "*")
                    txtsearch.Text = string.Empty;


                List<Gen_RecentAddress> list = null;

                using (TaxiDataContext db = new TaxiDataContext())
                {


                    try
                    {
                        db.ExecuteQuery<int>("DELETE E    FROM Gen_RecentAddresses E INNER JOIN    (  SELECT *,   RANK() OVER(PARTITION BY ADDRESSLINE1     ORDER BY id) rank    FROM Gen_RecentAddresses ) T ON E.ID = t.ID  WHERE rank > 1; ");
                    }
                    catch
                    {

                    }

                    keyword = keyword.ToUpper();

                    if(keywordType.Contains("*"))
                    list= db.Gen_RecentAddresses.Where(c => c.AddressLine1.ToUpper().StartsWith("<add>" +keyword)).ToList();
                    else if(keywordType.Contains("%"))
                        list = db.Gen_RecentAddresses.Where(c => c.AddressLine1.ToUpper().Contains(keyword)).ToList();


                    List<Address> objAddress = new List<Address>();
                    foreach (var item in list.OrderByDescending(a => a.SearchedOn))
                    {
                        string add = "";
                        string[] result = item.AddressLine1.Split(new string[] { "</add>" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in result)
                        {
                            add = s;
                            add = add.Replace("<add>", "").ToStr();
                            objAddress.Add(new Address { AddressLine1 = item.AddressLine1, AddressName = add, Id = item.Id });
                        }
                    }


                    grdLister.Rows.Clear();
                    grdLister.RowCount = objAddress.Count;

                    //grdLister.BeginUpdate();
                    for (int i = 0; i < objAddress.Count; i++)
                    {
                        //if (grdLister.Rows.Count(c => c.Cells[COLS.Address].Value.ToStr().ToUpper() == objAddress[i].AddressName) == 0)
                        //{

                            grdLister.Rows[i].Cells[COLS.Id].Value = objAddress[i].Id;
                            grdLister.Rows[i].Cells[COLS.Address].Value = objAddress[i].AddressName;
                            grdLister.Rows[i].Cells[COLS.AddressLine1].Value = objAddress[i].AddressLine1;


                        //}
                        //else
                        //{
                        //    grdLister.Rows[i].Cells[COLS.Id].Value = objAddress[i].Id;
                        //    grdLister.Rows[i].Cells[COLS.Address].Value = objAddress[i].AddressName;
                        //    grdLister.Rows[i].Cells[COLS.AddressLine1].Value = objAddress[i].AddressLine1;
                        //    grdLister.Rows[i].IsVisible = false;

                        //}

                        if (keywordType == "*" && grdLister.Rows[i].Cells[COLS.Address].Value.ToStr().StartsWith(keyword) == false)
                        {
                            grdLister.Rows[i].IsVisible = false;

                        }
                        else if (keywordType == "%" && grdLister.Rows[i].Cells[COLS.Address].Value.ToStr().Contains(keyword) == false)
                        {
                            grdLister.Rows[i].IsVisible = false;
                        }










                        }

                 //   grdLister.EndUpdate();

                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void btnClearAddresses_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("are you sure you want to clear all recent addresses ?", "", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.stp_RunProcedure("delete  from Gen_RecentAddresses");
                    }


                    grdLister.Rows.Clear();

                }
                catch { }
            }
        }


        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {
                GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                if (cell == null) { return; }

                else if (cell.GridControl.Name == "grdLister")
                {
                    if (mnuGrd == null)
                    {
                        mnuGrd = new RadDropDownMenu();
                        mnuGrd.BackColor = Color.Orange;

                        RadMenuItem miCpyText = new RadMenuItem("Copy Text");
                        miCpyText.ForeColor = Color.DarkBlue;
                        miCpyText.BackColor = Color.Orange;
                        miCpyText.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        miCpyText.Click += new EventHandler(miCopyText_Click);
                        mnuGrd.Items.Add(miCpyText);

                        RadMenuItem miDeleteAllSimilar = new RadMenuItem("Delete all similar Address");
                        miDeleteAllSimilar.ForeColor = Color.DarkBlue;
                        miDeleteAllSimilar.BackColor = Color.Orange;
                        miDeleteAllSimilar.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        miDeleteAllSimilar.Click += new EventHandler(miDeleteAllSimilar_Click);
                        mnuGrd.Items.Add(miDeleteAllSimilar);
                    }

                    e.ContextMenu = mnuGrd;
                    return;
                }
            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }

        void miCopyText_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    GridViewRowInfo row = grdLister.CurrentRow;
                    string AddressName = row.Cells[COLS.Address].Value.ToStr();
                    Clipboard.SetText(AddressName);
                }
            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }


        void miDeleteAllSimilar_Click(object sender, EventArgs e)
        {
            DeleteAddresses();
        }


        private void DeleteAddresses()
        {

            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    GridViewRowInfo row = grdLister.CurrentRow;
                    string AddressName = row.Cells[COLS.Address].Value.ToStr();
                    string AddressLine1 = row.Cells[COLS.AddressLine1].Value.ToStr();
                    long Id = row.Cells[COLS.Id].Value.ToLong();
                    string lstIdRemove = string.Empty;
                    string lstIdUpdate = string.Empty;

                    StringBuilder sb = new StringBuilder();
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        var list = db.Gen_RecentAddresses.Where(c => c.AddressLine1.Contains("<add>" + AddressName + "</add>")).ToList();

                        foreach (var item in list)
                        {
                            string valueCkeck = item.AddressLine1.Replace("<add>" + AddressName + "</add>", "");
                            if (string.IsNullOrEmpty(valueCkeck))
                            {
                                lstIdRemove = lstIdRemove == string.Empty ? item.Id.ToString() : lstIdRemove + "," + item.Id.ToString();
                            }
                            else
                            {
                                lstIdUpdate = lstIdUpdate == string.Empty ? item.Id.ToString() : lstIdUpdate + "," + item.Id.ToString();
                            }
                        }

                        if (lstIdRemove.ToStr().Trim().Length > 0)
                        {
                            sb.Append("DELETE FROM Gen_RecentAddresses WHERE Id in (" + lstIdRemove + ");");
                        }

                        if (lstIdUpdate.ToStr().Trim().Length > 0)
                        {
                            sb.Append("UPDATE Gen_RecentAddresses SET AddressLine1=REPLACE(AddressLine1,'<add>" + AddressName.Replace("'", "''") + "</add>','') WHERE Id in (" + lstIdUpdate + ");");
                        }

                        if (sb.ToString().Length > 0)
                        {
                            db.ExecuteQuery<string>(sb.ToString());
                        }
                        // 1   <Add>aaaaa</Add><add>abbbb</Add>

                        List<int> ids = grdLister.Rows.Where(c => c.Cells[COLS.Address].Value.ToStr() == AddressName)
                            .Select(c => c.Cells[COLS.Id].Value.ToInt()).ToList<int>();

                        grdLister.BeginUpdate();
                        //foreach (var item in ids)
                        //{
                        //    grdLister.Rows.FirstOrDefault(c => c.Cells[COLS.Id].Value.ToInt() == item).Delete();


                        //}

                        List<GridViewRowInfo> rws = grdLister.Rows.Where(c => c.Cells[COLS.Address].Value.ToStr() == AddressName).ToList();
                        foreach (GridViewRowInfo r in rws) { grdLister.Rows.Remove(r); }


                        grdLister.EndUpdate();


                        try
                        {
                            //
                            if (AddressName.ToStr().Trim().Length > 0)
                            {

                                db.ExecuteQuery<int>("delete from Customer_History where  (Pickup='" + AddressName + "' OR Destination='" + AddressName + "')");
                            }
                        }
                        catch
                        {


                        }


                        //for (int i = 0; i < objAddress.Count; i++)
                        //{
                        //    grdLister.Rows[i].Cells[COLS.Id].Value = objAddress[i].Id;
                        //    grdLister.Rows[i].Cells[COLS.Address].Value = objAddress[i].AddressName;
                        //    grdLister.Rows[i].Cells[COLS.AddressLine1].Value = objAddress[i].AddressLine1;
                        //}

                        //foreach (var item in grdLister.Rows.Where(c => c.Cells[COLS.Address].Value.ToStr() == AddressName))
                        //{
                        //    item.Delete();
                        //}


                    }
                   // LoadRecentAddress();
                }
            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }


        private void DeleteWrongAddresses()
        {

            try
            {
               
                  
                   
                    string lstIdRemove = string.Empty;
                    string lstIdUpdate = string.Empty;

                    StringBuilder sb = new StringBuilder();
                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                    foreach (var itemX in grdLister.Rows.Where(c => General.GetPostCodeMatch(c.Cells[COLS.Address].Value.ToStr()) == string.Empty).Distinct().ToList())
                        {

                         lstIdRemove = string.Empty;
                         lstIdUpdate = string.Empty;
                        string postcode = General.GetPostCodeMatch(itemX.Cells[COLS.Address].Value.ToStr());


                            if (postcode.Length == 0 || postcode.Contains(" ") == false)
                            {
                                string AddressName = itemX.Cells[COLS.Address].Value.ToStr();

                                var list = db.Gen_RecentAddresses.Where(c => c.AddressLine1.Contains("<add>" + AddressName + "</add>")).ToList();

                                foreach (var item in list)
                                {
                                    string valueCkeck = item.AddressLine1.Replace("<add>" + AddressName + "</add>", "");
                                    if (string.IsNullOrEmpty(valueCkeck))
                                    {
                                        lstIdRemove = lstIdRemove == string.Empty ? item.Id.ToString() : lstIdRemove + "," + item.Id.ToString();
                                    }
                                    else
                                    {
                                        lstIdUpdate = lstIdUpdate == string.Empty ? item.Id.ToString() : lstIdUpdate + "," + item.Id.ToString();
                                    }
                                }

                                if (lstIdRemove.ToStr().Trim().Length > 0)
                                {
                                    sb.Append("DELETE FROM Gen_RecentAddresses WHERE Id in (" + lstIdRemove + ");");
                                }

                                if (lstIdUpdate.ToStr().Trim().Length > 0)
                                {
                                    sb.Append("UPDATE Gen_RecentAddresses SET AddressLine1=REPLACE(AddressLine1,'<add>" + AddressName.Replace("'", "''") + "</add>','') WHERE Id in (" + lstIdUpdate + ");");
                                }

                                if (sb.ToString().Length > 0)
                                {
                                    db.ExecuteQuery<string>(sb.ToString());
                                }


                               

                                try
                                {
                                    //
                                    if (AddressName.ToStr().Trim().Length > 0)
                                    {

                                        db.ExecuteQuery<int>("delete from Customer_History where  (Pickup='" + AddressName + "' OR Destination='" + AddressName + "')");
                                    }
                                }
                                catch
                                {


                                }


                          
                        }

                        }

                    LoadRecentAddress(txtsearch.Text.ToUpper(), "%");

                }
                   
                
            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }


        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(txtsearch.Text.Trim().Length==0)
            {

                MessageBox.Show("Required : Keyword");
                txtsearch.Focus();
                return;
            }

            LoadRecentAddress(txtsearch.Text.ToUpper(), "%");




        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DeleteWrongAddresses();
        }
    }
    class Address
    {
        public long Id { get; set; }
        public string AddressName { get; set; }
        public string AddressLine1 { get; set; }

    }
}
