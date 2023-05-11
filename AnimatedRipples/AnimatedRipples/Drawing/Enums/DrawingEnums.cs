using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    public enum RippleProfileType : uint
    {
        [Description("Single")]
        Single,        
        [Description("Star ripple")]
        Star,
        [Description("Ripple")]
        Ripple,
        [Description("Spotlight")]
        Spotlight,
        [Description("Sonar Pulse")]
        SonarPulse,
        [Description("Squared Pulse")]
        SquaredPulse,
        [Description("Square")]
        Square,
        [Description("Hexagon")]
        Hexagon,
        [Description("Crosshair")]
        Crosshair,
        [Description("Concentric Circles")]
        Concentric // Core circle in the middle.          
    }

    public enum ShapeType : uint
    {
        Ellipse,        
        Rectangle,
        Polygon,
    }
}
