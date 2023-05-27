using FrostyBee.FriskyRipples.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    public interface IValueInterpolatable: IConstructable
    {
        double Interpolate(double value);
    }
}
