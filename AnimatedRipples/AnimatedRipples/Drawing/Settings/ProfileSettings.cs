using MaterialWinforms.Animations;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Profiles
{
    internal class RippleProfileSettings
    {
        #region Animation Settings
        public InterpolationType AnimInteroplation { get; set; } = InterpolationType.Linear;
        public AnimationDirection AnimationDirection { get; set; } = AnimationDirection.In;
        public double AnimationSpeed { get; set; } = 0.010;
        #endregion        

        #region Visual Appearance
        public bool IsColorTransition { get; set; } = true;
        public int InitialOpacity { get; set; } = 100;
        public int MaxRadius { get; set; }
        #endregion

    }
}
