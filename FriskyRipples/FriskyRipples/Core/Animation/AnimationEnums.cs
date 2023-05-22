using FrostyBee.FriskyRipples.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Animation
{
    /// <summary>
    /// Defines the AnimationDirection
    /// </summary>
    public enum AnimationDirection
    {
        [Description("In")]
        In, //In. Stops if finished.
        [Description("Out")]
        Out, //Out. Stops if finished.
        [Description("In Out In")]
        InOutIn, //Same as In, but changes to InOutOut if finished.
        [Description("In Out Out")]
        InOutOut, //Same as Out.
        [Description("In Out Repeating In")]
        InOutRepeatingIn, // Same as In, but changes to InOutRepeatingOut if finished.
        [Description("In Out Repeating Out ")]
        InOutRepeatingOut // Same as Out, but changes to InOutRepeatingIn if finished.
    }
    public enum InterpolationType
    {
        [Description("Linear"), ConstructableEnum(typeof(InterpolatorLinear))]
        Linear,
        [Description("In Cubic"), ConstructableEnum(typeof(InterpolatorInCubic))]
        InCubic,
        [Description("Out Cubic"), ConstructableEnum(typeof(InterpolatorOutCubic))]
         OutCubic,
         [Description("In Out Cubic"), ConstructableEnum(typeof(InterpolatorInOutCubic))]
         InOutCubic,
        [Description("Custom Quadratic"), ConstructableEnum(typeof(InterpolatorCustomQuadratic))]
        CustomQuadratic,
        [Description("In Elastic"), ConstructableEnum(typeof(InterpolatorInElastic))]
        InElastic,
        [Description("Out Elastic"), ConstructableEnum(typeof(InterpolatorOutElastic))]
        OutElastic,
        [Description("In Out Elastic"), ConstructableEnum(typeof(InterpolatorInOutElastic))]
        InOutElastic,        
        [Description("In Bounce"), ConstructableEnum(typeof(InterpolatorInBounce))]
        InBounce,
        [Description("Out Bounce"), ConstructableEnum(typeof(InterpolatorOutBounce))]
        OutBounce,
        [Description("In Out Bounce"), ConstructableEnum(typeof(InterpolatorOutBounce))]
        InOutBounce,
        [Description("In Quint"), ConstructableEnum(typeof(InterpolatorInQuint))]
        InQuint,
        [Description("In Out Quint"), ConstructableEnum(typeof(InterpolatorInOutQuint))]
        InOutQuint,
        [Description("Ease Out"), ConstructableEnum(typeof(InterpolatorEaseOut))]
        EaseOut,
        [Description("Ease In Out"), ConstructableEnum(typeof(InterpolatorEaseInOut))]
        InOut
    }
}
