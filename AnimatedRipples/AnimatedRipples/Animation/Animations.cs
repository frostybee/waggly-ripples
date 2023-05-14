using System;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MaterialWinforms.Animations
{
    public enum InterpolationType
    {
        [Description("Linear")]
        Linear,
        [Description("Ease In Out")]
        EaseInOut,
        [Description("Ease Out")]
        EaseOut,
        [Description("Custom Quadratic")]
        CustomQuadratic,
        [Description("Ease In Elastic")]
        EaseInElastic,
        [Description("Ease In Out Bounce")]
        EaseInOutBounce,
        [Description("Ease Out Bounce")]
        EaseOutBounce,
    }

    static class AnimationLinear
    {
        public static double CalculateProgress(double progress)
        {
            return progress;
        }
    }

    static class AnimationEaseInOut
    {
        public static double PI = Math.PI;
        public static double PI_HALF = Math.PI / 2;

        public static double CalculateProgress(double progress)
        {
            return EaseInOut(progress);
        }

        private static double EaseInOut(double s)
        {
            return s - Math.Sin(s * 2 * PI) / (2 * PI);
        }
    }

    public static class AnimationEaseOut
    {
        public static double CalculateProgress(double progress)
        {
            return -1 * progress * (progress - 2);
        }
    }

    public static class AnimationCustomQuadratic
    {
        public static double CalculateProgress(double progress)
        {
            //double kickoff = 0.6;
            double kickoff = 0.3;
            return 1 - Math.Cos((Math.Max(progress, kickoff) - kickoff) * Math.PI / (2 - (2 * kickoff)));
        }
    }
    public static class AnimationEaseInElastic
    {
        /// <summary>
        /// Implements a spring-like interpolation function.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateProgress(double time)
        {
            double c4 = (2 * Math.PI) / 3;
            //return Math.abs(0.5 - t) * 2;
            return time == 0
            ? 0
            : time == 1
            ? 1 : -Math.Pow(2, 10 * time - 10) * Math.Sin((time * 10 - 10.75) * c4);
        }
    }

    public static class AnimationEaseInOutBounce
    {
        /// <summary>
        /// Implements a spring-like interpolation function.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateProgress(double t)
        {
            return t < 0.5
                 ? (1 - EaseOutBounceInterpolator.CalculateProgress(1 - 2 * t)) / 2
                 : (1 + EaseOutBounceInterpolator.CalculateProgress(2 * t - 1)) / 2;
        }
    }
    public static class EaseOutBounceInterpolator
    {
        /// <summary>
        /// Implements a spring-like interpolation function.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateProgress(double time)
        {
            double n1 = 7.5625;
            double d1 = 2.75;

            if (time < 1 / d1)
            {
                return n1 * time * time;
            }
            else if (time < 2 / d1)
            {
                return n1 * (time -= 1.5 / d1) * time + 0.75;
            }
            else if (time < 2.5 / d1)
            {
                return n1 * (time -= 2.25 / d1) * time + 0.9375;
            }
            else
            {
                return n1 * (time -= 2.625 / d1) * time + 0.984375;
            }
        }
    }
}
