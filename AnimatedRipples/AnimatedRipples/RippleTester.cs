using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormLayered
{
    public partial class RippleTester : Form
    {
        LayeredFrom layered;
        public RippleTester()
        {
            InitializeComponent();
            layered = new LayeredFrom();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            layered.ShowForm();                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            layered.Hide();

        }
    }
}
