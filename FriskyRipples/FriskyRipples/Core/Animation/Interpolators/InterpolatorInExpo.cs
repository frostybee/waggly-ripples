using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInExpo : IValueInterpolatable
    {        

        public double Interpolate(double progress)
        {
            return progress == 0 ? 0 : Math.Pow(2, 10 * progress - 10);
        }
    }
}
