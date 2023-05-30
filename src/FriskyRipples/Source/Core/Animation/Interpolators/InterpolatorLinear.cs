namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorLinear : IValueInterpolatable
    {        

        public double Interpolate(double progress)
        {
            return progress;
        }
    }
}
