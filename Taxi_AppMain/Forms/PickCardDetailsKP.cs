using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Taxi_AppMain
{
    public partial class PickCardDetailsKP : Form
    {

        List<ClsCCDetails> cardList;

        public string SelectedCard;
        public PickCardDetailsKP(List<ClsCCDetails> list)
        {
            InitializeComponent();
            this.Load += PickCardDetails_Load;
            cardList = list;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               SelectedCard= dataGridView1.CurrentRow.Cells[1].Value.ToStr();
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void PickCardDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.RowCount = cardList.Count;

                for (int i = 0; i < cardList.Count; i++)
                {

                    var card = cardList[i].CCDetails.ToStr().Trim();

                    if (card.Length > 0)
                    {
                        if (card != null && card.ToLower().Contains("konnectpaytoken"))
                        {
                            try
                            {
                                var lastfour = "";
                                var expiry = "";

                                dataGridView1.Rows[i].Cells[1].Value = card.ToStr();

                                var CCDetails = card.Split('|');
                                if (!string.IsNullOrEmpty(CCDetails[1]))
                                {
                                    var CardInfo = CCDetails[1].Split(',');
                                    if (CardInfo != null)
                                    {
                                        if (CardInfo[0] != null && CardInfo[0].ToLower().Contains("last four"))
                                        {
                                            lastfour = CardInfo[0].Replace("last four", "");
                                            lastfour = lastfour.Replace(":", "").Trim();
                                            dataGridView1.Rows[i].Cells[0].Value = lastfour.ToStr();
                                        }
                                        if (CardInfo[1] != null && CardInfo[1].ToLower().Contains("expiry"))
                                        {
                                            expiry = CardInfo[1].Replace("expiry", "");
                                            expiry = expiry.Replace(":", "").Trim();
                                            dataGridView1.Rows[i].Cells[2].Value = expiry.ToStr();
                                        }

                                    }
                                }
                            }
                            catch
                            {
                            }
                        }

                    }
                    // dataGridView1.Rows[i].Cells[0].Value=item.CCDetails, item.CCDetails);

                }

                dataGridView1.Rows[0].Selected = true;
            }
            catch 
            {
            
            }
        }
    }
}
