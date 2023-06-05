using System;

namespace FrostyBee.FriskyRipples.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class EasingInfoAttribute : Attribute
    {
        public int Speed { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }        
        public Type Type { get; set; }
        public EasingInfoAttribute()
        {
            
        }
    }
}