﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorOutElastic : IValueInterpolatable
    {
        private double c4 = (2 * Math.PI) / 3;
        public double Interpolate(double progress)
        {
            return progress == 0 ? 0 : progress == 1 ? 1 : Math.Pow(2, -10 * progress) * Math.Sin((progress * 10 - 0.75) * c4) + 1;
        }
    }
}
