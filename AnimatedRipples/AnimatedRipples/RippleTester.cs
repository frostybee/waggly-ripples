using FriskyMouse.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLayered.LayeredForm;

namespace WinFormLayered
{
    public partial class RippleTester : Form
    {
        RipplesController ripplesController;
        public RippleTester()
        {
            InitializeComponent();
            //layered = new LayeredFrom();
            ripplesController = new RipplesController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ripplesController.ShowRipplesAt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //layered.Hide();

        }
    }
}
