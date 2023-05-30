using System;

namespace FrostyBee.FriskyRipples.Source.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class AnimationSpeedAttribute : Attribute
    {
        public int Speed { get; set; }
        public AnimationSpeedAttribute(int pSpeed) {
            Speed = pSpeed;
        }
    }
}
