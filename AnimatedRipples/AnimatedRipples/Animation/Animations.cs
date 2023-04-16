using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MaterialWinforms.Animations
{
    public enum AnimationType
    {
        Linear,
        EaseInOut,
        EaseOut,
        CustomQuadratic,
        SpringInteropolator
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
    public static class AnimationElasticBounce
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
            ? 1 : - Math.Pow(2, 10 * time - 10) * Math.Sin((time * 10 - 10.75) * c4);
        }
    }
}
