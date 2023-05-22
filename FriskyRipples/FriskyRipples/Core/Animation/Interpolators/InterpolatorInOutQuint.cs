﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInOutQuint : IValueInterpolatable
    {        

        public double Interpolate(double time)
        {
            return time < 0.5 ? 16 * Math.Pow(time, 5) : 1 - Math.Pow(-2 * time + 2, 5) / 2;
        }
    }
}
