namespace FrostyBee.FriskyRipples.Animation
{
    /// <summary>
    /// Linearly eases a <see cref="double"/> value.
    /// </summary>
    public class LinearEasing : Easing
    {
        /// <inheritdoc/>
        public override double Ease(double progress)
        {
            return progress;
        }
    }
}
