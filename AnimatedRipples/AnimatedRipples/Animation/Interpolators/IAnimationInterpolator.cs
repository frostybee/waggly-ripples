using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    public interface IAnimationInterpolator
    {
        double Interpolate(double value);
    }
}
