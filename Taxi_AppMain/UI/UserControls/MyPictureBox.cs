using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace UI.UserControls
{
    public partial class MyPictureBox : UserControl
    {

        private PictureBox _PictureBoxElement;

        public PictureBox PictureBoxElement
        {
            get { return this.pictureBox1; }
            set { _PictureBoxElement = value; }
        }


        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public bool ShowActionPanel
        {
            get { return pnlAction.Visible; }
            set { pnlAction.Visible = value; }
        }



      


        public MyPictureBox()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        public Image GetImage()
        {
            return this.pictureBox1.Image;

        }

        public byte[] GetByteArrayOfImage()
        {
            if (this.pictureBox1.Image == null) return null;
        
            MemoryStream ms = new MemoryStream();
            this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();

        }


        public void SetImage(byte[] _ImageInBytes)
        {
            if (_ImageInBytes == null) return;
            MemoryStream ms = new MemoryStream(_ImageInBytes);
            Image returnImage = Image.FromStream(ms);
            this.pictureBox1.Image = returnImage;
   
        }


        public void SetImage(Image image)
        {

            this.pictureBox1.Image = image;
          
        }

        public void Clear()
        {
            this.pictureBox1.Image = null;


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                this.FileName = openFileDialog1.SafeFileName;
                this.FilePath = openFileDialog1.FileName;

            }
            else
            {
                this.FileName = string.Empty;
                this.FilePath = string.Empty;

            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                RadMessageBox.Show("No Image to Preview");
                return;
            }

            frmPreview frm = new frmPreview();
            frm.ImageFile = pictureBox1.Image;
            frm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
