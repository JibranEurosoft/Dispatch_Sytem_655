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
    public partial class PickCardDetails : Form
    {

        List<ClsCCDetails> cardList;

        public string SelectedCard;
        public PickCardDetails(List<ClsCCDetails> list)
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

            dataGridView1.RowCount = cardList.Count;

            for(int i=0;i<cardList.Count; i++)
            {

                var card = cardList[i].CCDetails.ToStr().Trim();

                if (card.Length > 0)
                {

                    try
                    {
                        string[] arr = card.Split(new string[] { "<<<" }, StringSplitOptions.None);
                        var lastfour = arr[3];
                        var expiry=arr[4];





                        dataGridView1.Rows[i].Cells[0].Value = lastfour.Split('|')[1].ToStr();
                        dataGridView1.Rows[i].Cells[2].Value = expiry.Split('|')[1].ToStr();


                        dataGridView1.Rows[i].Cells[1].Value = card.ToStr();

                    }
                    catch
                    {

                    }

                }
               // dataGridView1.Rows[i].Cells[0].Value=item.CCDetails, item.CCDetails);
            
            }

            dataGridView1.Rows[0].Selected = true ;

        }
    }
}
