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
using WinFormLayered.Drawing;
using WinFormLayered.LayeredForm;

namespace WinFormLayered
{
    public partial class RippleTester : Form
    {
        RippleProfilesManager ripplesController;
        List<RippleProfileType> rippleTypes;
        public RippleTester()
        {
            InitializeComponent();
            //_layered = new LayeredFrom();
            ripplesController = new RippleProfilesManager();
            rippleTypes = Enum.GetValues(typeof(RippleProfileType)).Cast<RippleProfileType>().ToList();
            this.Load += RippleTester_Load;
        }

        private void RippleTester_Load(object sender, EventArgs e)
        {
            this.rippleTypes.ForEach((d) =>  cboxRipplesList.Items.Add(d.ToString()));            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ripplesController.ShowRipplesAt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_layered.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Test a shadow around a circle.

        }
    }
}
