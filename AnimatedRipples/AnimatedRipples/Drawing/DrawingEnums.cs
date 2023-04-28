using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
 public enum RippleType: int
    {
        Single,
        Multiple,        
        Star,
        Circle,
        Square,
        Crosshair,
        Concentric // Core circle in the middle.          
    }
}
