using FrostyBee.FriskyRipples.Attributes;
using FrostyBee.FriskyRipples.Source.Core.Attributes;
using System.ComponentModel;

namespace FrostyBee.FriskyRipples.Animation
{
    public enum InterpolationType
    {
        [Description("Linear"), ConstructableEnum(typeof(InterpolatorLinear)), AnimationSpeed(25)]
        Linear,
        [Description("In Expo"), ConstructableEnum(typeof(InterpolatorInExpo)), AnimationSpeed(10)]
        InExpo,
        [Description("Out Back"), ConstructableEnum(typeof(InterpolatorOutBack)), AnimationSpeed(10)]
        OutBack,
        [Description("In Out Back"), ConstructableEnum(typeof(InterpolatorInOutBack)), AnimationSpeed(15)]
        InOutBack,
        [Description("In Cubic"), ConstructableEnum(typeof(InterpolatorInCubic)), AnimationSpeed(15)]
        InCubic,
        [Description("Out Cubic"), ConstructableEnum(typeof(InterpolatorOutCubic)), AnimationSpeed(15)]
        OutCubic,
        [Description("In Out Cubic"), ConstructableEnum(typeof(InterpolatorInOutCubic)), AnimationSpeed(20)]
        InOutCubic,
        [Description("Custom Quadratic"), ConstructableEnum(typeof(InterpolatorCustomQuadratic)), AnimationSpeed(20)]
        CustomQuadratic,
        [Description("In Elastic"), ConstructableEnum(typeof(InterpolatorInElastic)), AnimationSpeed(10)]
        InElastic,
        [Description("Out Elastic"), ConstructableEnum(typeof(InterpolatorOutElastic)), AnimationSpeed(10)]
        OutElastic,
        [Description("In Out Elastic"), ConstructableEnum(typeof(InterpolatorInOutElastic)), AnimationSpeed(12)]
        InOutElastic,
        [Description("In Bounce"), ConstructableEnum(typeof(InterpolatorInBounce)), AnimationSpeed(15)]
        InBounce,
        [Description("Out Bounce"), ConstructableEnum(typeof(InterpolatorOutBounce)), AnimationSpeed(20)]
        OutBounce,
        [Description("In Out Bounce"), ConstructableEnum(typeof(InterpolatorOutBounce)), AnimationSpeed(15)]
        InOutBounce,
        [Description("In Quint"), ConstructableEnum(typeof(InterpolatorInQuint)), AnimationSpeed(15)]
        InQuint,
        [Description("Out Quint"), ConstructableEnum(typeof(InterpolatorOutQuint)), AnimationSpeed(15)]
        OutQuint,
        [Description("In Out Quint"), ConstructableEnum(typeof(InterpolatorInOutQuint)), AnimationSpeed(17)]
        InOutQuint,
        [Description("Ease Out"), ConstructableEnum(typeof(InterpolatorEaseOut)), AnimationSpeed(25)]
        EaseOut,
        [Description("In Out"), ConstructableEnum(typeof(InterpolatorEaseInOut)), AnimationSpeed(20)]
        InOut
    }
}
