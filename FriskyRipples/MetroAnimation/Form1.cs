using ReaLTaiizor.Animate.Metro;
using ReaLTaiizor.Enum.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroAnimation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Updating....");
            IntAnimate animate = new IntAnimate();
            //animate.Start(int duration, T initial, T end, EasingType easing = EasingType.Linear)
            animate.Start(5000, 1, 50, EasingType.CubeInOut);
            animate.Complete = OnAnimationCompleted;
            animate.Update += OnAnimationUpdated; 
            animate.Start(1000);

        }

        private void OnAnimationUpdated(int value)
        {
            Debug.WriteLine("Updated value: "+ value);
        }

        private void OnAnimationCompleted()
        {
            Debug.WriteLine("Animation Completed");
        }
    }
}
