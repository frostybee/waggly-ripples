using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    public enum RippleProfileType : uint
    {
        Single,
        Multiple,
        Star,
        Circle,
        Spotlight,
        SonarPulse,
        Square,
        Hexagon,
        Crosshair,
        Concentric // Core circle in the middle.          
    }

    public enum ShapeType : uint
    {
        Circle,        
        Rectangle,
        Polygon,
    }
}
