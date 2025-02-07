using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using System.Data.Linq;
using System.Collections;
using Telerik.WinControls;

namespace Taxi_AppMain
{
	public partial class frmBookingFeeSettings : UI.SetupBase
	{

		public frmBookingFeeSettings()
		{
			InitializeComponent();
			InitializeConstructor();
            AddDeleteColumn();
        }



		private void InitializeConstructor()
		{
			this.Load += new EventHandler(frmBookingFeeSettings_Load);
			this.FormClosed += new FormClosedEventHandler(frmBookingFeeSettings_Closed);
		}

		// display data 
		public override void PopulateData()
		{

			using (TaxiDataContext db = new TaxiDataContext())
			{
				var list = (from c in db.Gen_ServiceCharges
							select new ClsServiceCharges
                            {
								Id = c.Id,
								FromValue = Convert.ToDecimal(c.FromValue),
								ToValue = Convert.ToDecimal(c.ToValue),
								ServiceChargeAmount = Convert.ToDecimal(c.ServiceChargeAmount)
								
							}).ToList();

                GridViewRowInfo row = null;
                foreach (var item in list)
                {
                    row = grdBookingFeeSettings.Rows.AddNew();
                    
					row.Cells["Id"].Value = item.Id.ToInt();
					row.Cells["FromValue"].Value = item.FromValue.ToDecimal();
					row.Cells["ToValue"].Value = item.ToValue.ToDecimal();
					row.Cells["ServiceChargeAmount"].Value = item.ServiceChargeAmount.ToDecimal();

                   
                }              

            }
		
		}
		// added delete button into grid
        private void AddDeleteColumn()
        {

            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 100;

            col.Name = "delete";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Delete";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grdBookingFeeSettings.Columns.Add(col);
            grdBookingFeeSettings.CommandCellClick += GrdFareIncreament_CommandCellClick;

        }
		// delete 
        private void GrdFareIncreament_CommandCellClick(object sender, EventArgs e)
		{
			try
			{

				GridCommandCellElement gridCell = (GridCommandCellElement)sender;


				if (gridCell.ColumnInfo.Name == "delete")
				{
					int id = gridCell.RowInfo.Cells["Id"].Value.ToInt();


					if (id > 0)
					{
						if (gridCell.ColumnInfo.Name.ToLower() == "delete")
						{
							if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Fee ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
							{
                                using (TaxiDataContext db = new TaxiDataContext())
                                {
                                    Gen_ServiceCharge objfare = db.Gen_ServiceCharges.FirstOrDefault(c => c.Id == id);
                                    db.Gen_ServiceCharges.DeleteOnSubmit(objfare);
                                    db.SubmitChanges();

                                    gridCell.RowInfo.Delete();
                                }
                            }
						}
                      

					}
				}


			}
			catch
			{

			}

		}

		void frmBookingFeeSettings_Load(object sender, EventArgs e)
		{
			PopulateData();
			//   DisplaySettings();
		}



		void frmLocations_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{

				this.Close();
			}
		}


		void frmBookingFeeSettings_Closed(object sender, FormClosedEventArgs e)
		{
			this.Dispose(true);
		}

		private void btnExitForm_Click(object sender, EventArgs e)
		{
			Close();
		}
		//save 
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (SaveSettings())
			{
                Close();            
			}
		}

		private bool SaveSettings()
		{
			bool rtn = false;

			try
			{				


				using (TaxiDataContext db = new TaxiDataContext())
				{
					List<int> Ids = grdBookingFeeSettings.Rows.Select(callnotification => Convert.ToInt32(callnotification.Cells["Id"].Value)).ToList();

					for (int i = 0; i < grdBookingFeeSettings.Rows.Count; i++)
					{

						int id = grdBookingFeeSettings.Rows[i].Cells["Id"].Value.ToInt();
                        Gen_ServiceCharge objFare = null;

						if (id.ToInt() > 0)
							objFare = db.Gen_ServiceCharges.FirstOrDefault(c => c.Id == id);
						else
							objFare = new Gen_ServiceCharge();


						objFare.FromValue = grdBookingFeeSettings.Rows[i].Cells["FromValue"].Value.ToDecimal();
						objFare.ToValue = grdBookingFeeSettings.Rows[i].Cells["ToValue"].Value.ToDecimal();
						objFare.ServiceChargeAmount = grdBookingFeeSettings.Rows[i].Cells["ServiceChargeAmount"].Value.ToDecimal();
                        objFare.SubCompanyId = 1;
                        objFare.AmountWise = true;
                        objFare.IsAccount = true;

                        if (objFare.Id == 0)
							db.Gen_ServiceCharges.InsertOnSubmit(objFare);

						db.SubmitChanges();

					}


				}


				return true;
			}		

			catch (Exception ex)
			{

				ENUtils.ShowMessage(ex.Message);
			}


			return rtn;

		}


		// data class
        public class ClsServiceCharges
		{
			public int Id { get; set; }
			public decimal? FromValue { get; set; }
			public decimal? ToValue { get; set; }
			public decimal? ServiceChargeAmount { get; set; }
            
        }

	}

   
}
