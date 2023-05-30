using FrostyBee.FriskyRipples.Drawing;

namespace FrostyBee.FriskyRipples.Animation
{
    public interface IValueInterpolatable: IConstructable
    {
        double Interpolate(double value);
    }
}
