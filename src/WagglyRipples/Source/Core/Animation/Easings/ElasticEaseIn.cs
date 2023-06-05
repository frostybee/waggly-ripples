using System;
using Avalonia.Animation.Utils;

namespace FrostyBee.FriskyRipples.Animation
{
    /// <summary>
    /// Eases in a <see cref="double"/> value 
    /// using a damped sine function.
    /// </summary>
    public class ElasticEaseIn : Easing
    {
        /// <inheritdoc/>
        public override double Ease(double progress)
        {
            double p = progress;
            return Math.Sin(13d * EasingUtils.HALFPI * p) * Math.Pow(2d, 10d * (p - 1));            
        }
    }
}
