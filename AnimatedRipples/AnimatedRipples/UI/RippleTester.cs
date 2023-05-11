using FriskyMouse.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLayered.Drawing;
using WinFormLayered.Drawing.Extensions;
using WinFormLayered.LayeredForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormLayered
{
    public partial class RippleTester : Form
    {
        RippleProfilesManager _profilesManager;
        List<RippleProfileType> rippleTypes;
        public RippleTester()
        {
            InitializeComponent();
            //_layered = new LayeredFrom();
            _profilesManager = new RippleProfilesManager();
            rippleTypes = Enum.GetValues(typeof(RippleProfileType)).Cast<RippleProfileType>().ToList();
            this.Load += RippleTester_Load;
            cboxRipplesList.SelectedIndexChanged += CboxRipplesList_SelectedIndexChanged;
        }

        private void CboxRipplesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(cboxRipplesList.SelectedIndex);
            Enum.TryParse<RippleProfileType>(cboxRipplesList.SelectedValue.ToString(), out RippleProfileType proc);
            int nValue = (int)proc;
            _profilesManager.SwitchProfile(proc);
        }

        private void RippleTester_Load(object sender, EventArgs e)
        {
            // Populate the combo box with the ripple profiles descriptions.
            //this.rippleTypes.ForEach((d) =>  cboxRipplesList.Items.Add(d.ToString()));
            cboxRipplesList.PopulateFromEnum(typeof(RippleProfileType));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _profilesManager.ShowRipplesAt();
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
