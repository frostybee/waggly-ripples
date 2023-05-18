namespace MaterialSkin.Animations
{
    using System;
    using System.ComponentModel;

    // TODO: Automate the creation of these interpolators.
    // Make the instantiation process dynamic.
    static class AnimationEaseInCubic
    {
        public static double CalculateProgress(double progress)
        {
            return Math.Pow(progress, 3);            
        }
    }
    static class AnimationInQuint
    {
        public static double CalculateProgress(double t)
        {
            return Math.Pow(t, 5);
        }
    }
    static class AnimationInOutQuint
    {
        public static double CalculateProgress(double t)
        {
            return t < 0.5 ? 16 * Math.Pow(t, 5) : 1 - Math.Pow(-2 * t + 2, 5) / 2;
        }
    }
    static class AnimationEaseInOutCubic
    {
        public static double CalculateProgress(double progress)
        {
            return progress < 0.5 ? 4 * Math.Pow(progress, 3) : 1 - Math.Pow(-2 * progress + 2, 3) / 2;
        }
    }

    static class AnimationEaseOutCubic
    {
        public static double CalculateProgress(double progress)
        {
            return 1 - Math.Pow(1 - progress, 3);
        }
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
        private static double c4 = (2 * Math.PI) / 3;
        public static double CalculateProgress(double time)
        {          
            return time == 0 ? 0 : time == 1 ? 1 : -Math.Pow(2, 10 * time - 10) * Math.Sin((time * 10 - 10.75) * c4);
        }
    }
    public static class AnimationOutElastic
    {
        private static double c4 = (2 * Math.PI) / 3;
        public static double CalculateProgress(double x)
        {           
            return x == 0 ? 0 : x == 1 ? 1 : Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75) * c4) + 1;
        }
    }
    public static class AnimationInOutElastic
    {
        private static double c5 = (2 * Math.PI) / 4.5;
        public static double CalculateProgress(double x)
        {
            return x == 0
              ? 0
              : x == 1
              ? 1
              : x < 0.5
              ? -(Math.Pow(2, 20 * x - 10) * Math.Sin((20 * x - 11.125) * c5)) / 2
              : (Math.Pow(2, -20 * x + 10) * Math.Sin((20 * x - 11.125) * c5)) / 2 + 1;
        }
    }
    static class AnimationEaseInBounce
    {
        public static double CalculateProgress(double progress)
        {
            return 1 - EaseOutBounceInterpolator.CalculateProgress(1 - progress);
        }
    }


    public static class AnimationEaseInOutBounce
    {        
        public static double CalculateProgress(double t)
        {
            return t < 0.5
                 ? (1 - EaseOutBounceInterpolator.CalculateProgress(1 - 2 * t)) / 2
                 : (1 + EaseOutBounceInterpolator.CalculateProgress(2 * t - 1)) / 2;
        }
    }
    public static class EaseOutBounceInterpolator
    {        
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