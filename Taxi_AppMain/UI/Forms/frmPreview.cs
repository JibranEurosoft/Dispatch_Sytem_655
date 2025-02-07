using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class frmPreview : Form
    {
        private Image _ImageFile;

        public Image ImageFile
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }


        public frmPreview()
        {
            InitializeComponent();
        }
    }
} 
