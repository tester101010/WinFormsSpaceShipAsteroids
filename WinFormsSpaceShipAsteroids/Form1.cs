using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSpaceShipAsteroids
{
    public partial class Form1 : Form
    {
        Image BackgrndSpaceImage;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
