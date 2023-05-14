using FriskyMouse.UI;
using MaterialWinforms.Animations;
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
    public partial class RippleViewerForm : Form
    {
        RippleProfilesManager _profilesManager;
        List<RippleProfileType> _rippleTypes;
        public RippleViewerForm()
        {
            InitializeComponent();
            //_layeredWindow = new LayeredFrom();
            _profilesManager = new RippleProfilesManager();
            _rippleTypes = Enum.GetValues(typeof(RippleProfileType)).Cast<RippleProfileType>().ToList();
            this.Load += RippleViewerForm_Load;
            cboxRipplesList.SelectedIndexChanged += CboxRipplesList_SelectedIndexChanged;
        }

        private void CboxRipplesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(cboxRipplesList.SelectedIndex);
            Enum.TryParse<RippleProfileType>(cboxRipplesList.SelectedValue.ToString(), out RippleProfileType proc);
            int nValue = (int)proc;
            _profilesManager.SwitchProfile(proc);
        }

        private void RippleViewerForm_Load(object sender, EventArgs e)
        {
            // Populate the combo box with the ripple profiles descriptions.            
            cboxRipplesList.PopulateFromEnum(typeof(RippleProfileType));
            cmbAnimDirection.PopulateFromEnum(typeof(AnimationDirection));
            cmbInterpolationMode.PopulateFromEnum(typeof(InterpolationType));           
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            _profilesManager.ShowRipplesAt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_layeredWindow.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Test a shadow around a circle.

        }

        private void SliderAnimSpeed_Scroll(object sender, EventArgs e)
        {
            lblAnimSpeed.Text = sliderAnimSpeed.Value.ToString();
        }
    }
}
