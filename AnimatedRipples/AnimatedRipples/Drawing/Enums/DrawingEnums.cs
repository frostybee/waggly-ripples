using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Attributes;
using WinFormLayered.Drawing.Profiles;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    public enum RippleProfileType : uint
    {
        [Description("Expanding Ripple"), ConstructableEnum(typeof(CircleProfile))]
        Single,
        [Description("Cherry Blossom"), ConstructableEnum(typeof(SingleProfile))]
        Cherry,
        [Description("Diamond"), ConstructableEnum(typeof(DiamondProfile))]
        Diamond,
        [Description("Star ripple"), ConstructableEnum(typeof(StarProfile))]
        Star,        
        [Description("Fading Spotlight"), ConstructableEnum(typeof(SpotlightProfile))]
        Spotlight,
        [Description("Sonar Pulse"), ConstructableEnum(typeof(SonarPulseProfile))]
        SonarPulse,
        [Description("Squared Pulse"), ConstructableEnum(typeof(SquaredPulseProfile))]
        SquaredPulse,
        [Description("Expanding Square"), ConstructableEnum(typeof(SquareProfile))]
        Square,
        [Description("Hexagon"), ConstructableEnum(typeof(HexagonProfile))]
        Hexagon,
        [Description("Crosshair"), ConstructableEnum(typeof(CrosshairProfile))]
        Crosshair,
        [Description("Concentric Circles"), ConstructableEnum(typeof(ConcentricProfile))]
        Concentric // Core circle in the middle.          
    }

    public enum ShapeType : uint
    {
        Ellipse,        
        Rectangle,
        Polygon,
        Crosshair
    }

    public enum PolygonType : uint
    {
        Diamond,
        Hexagon,
        Star,
    }
}
