using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkin.Animations
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
        [Description("Linear")]
        Linear,
        [Description("In Cubic")]
        InCubic,
        [Description("Out Cubic")]
        OutCubic,
        [Description("In Out Cubic")]
        InOutCubic,
        [Description("In Out")]
        InOut,
        [Description("Ease Out")]
        EaseOut,
        [Description("Custom Quadratic")]
        CustomQuadratic,
        [Description("In Elastic")]
        InElastic,
        [Description("Out Elastic")]
        OutElastic,
        [Description("In Out Elastic")]
        InOutElastic,
        [Description("In Bounce")]
        InBounce,
        [Description("Out Bounce")]
        OutBounce,
        [Description("In Out Bounce")]
        InOutBounce,
        [Description("In Quint")]
        InQuint,
        [Description("In Out Quint")]
        InOutQuint        
    }
}
