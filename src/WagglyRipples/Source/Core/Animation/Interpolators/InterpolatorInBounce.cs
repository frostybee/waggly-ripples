namespace FrostyBee.FriskyRipples.Animation
{
    internal class InterpolatorInBounce 
    {
        private readonly InterpolatorOutBounce _outBounceInterpolator = new InterpolatorOutBounce();
        public double Interpolate(double progress)
        {
            return 1 - _outBounceInterpolator.Interpolate(1 - progress);            
        }
    }
}
