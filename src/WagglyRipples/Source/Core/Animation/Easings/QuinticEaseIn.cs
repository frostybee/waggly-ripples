namespace FrostyBee.FriskyRipples.Animation
{
    /// <summary>
    /// Eases in a <see cref="double"/> value 
    /// using a quartic equation.
    /// </summary>
    public class QuinticEaseIn : Easing
    {
        /// <inheritdoc/>
        public override double Ease(double progress)
        {
            double p2 = progress * progress;
            return p2 * p2 * progress;
        }
    }
}
