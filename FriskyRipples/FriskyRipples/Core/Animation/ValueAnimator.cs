﻿namespace FrostyBee.FriskyRipples.Animation
{
    using FrostyBee.FriskyRipples.Drawing;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    internal class ValueAnimator
    {
        #region Animation Properties
        private IValueInterpolatable _interpolator;
        /// <summary>
        /// Gets or sets a value indicating whether InterruptAnimation
        /// </summary>
        public bool InterruptAnimation { get; set; }

        /// <summary>
        /// Gets/sets the value by which the progress of the animation is increased.         
        /// </summary>
        public double Increment { get; set; }

        /// <summary>
        /// Gets or sets the SecondaryIncrement
        /// </summary>
        public double SecondaryIncrement { get; set; }

        /// <summary>
        /// Sets the Interpolation mode of the animation.
        /// When is set, an instance of the selected interpolator will be created. 
        /// </summary>
        public InterpolationType InterpolationType
        {
            set
            {
                SetInterpolator(value);
            }
        }
        #endregion

        public delegate void AnimationFinished(object sender);

        /// <summary>
        /// Occurs when the animation's progress value reaches the target value.
        /// The target value is 0 if the animation direction is In.
        /// The target value is 1 if the animation direction is Out.
        /// </summary>
        public event AnimationFinished OnAnimationFinished;

        public delegate void AnimationProgress(object sender);

        /// <summary>
        /// Occurs whenever the animation progresses inward or outward over time.
        /// </summary>
        public event AnimationProgress OnAnimationProgress;

        /// <summary>
        /// Holds the values that indicates the progress of the animation.
        /// The value ranges between 0 and 1. 
        /// </summary>
        private double _animationProgress = 0;

        /// <summary>
        /// Defines the _animationDirections
        /// </summary>
        private AnimationDirection _animationDirection = AnimationDirection.In;

        /// <summary>
        /// The lower bound of the animation.
        /// </summary>
        private const double MIN_VALUE = 0.00;

        /// <summary>
        /// The upper bound of the animation.
        /// </summary>
        private const double MAX_VALUE = 1.00;

        /// <summary>
        /// Controls the animation progress within the specified interval. 
        /// </summary>
        private readonly Timer _animationTimer = new Timer { Interval = 5, Enabled = false };

        public ValueAnimator()
        {
            Increment = 0.03;
            SecondaryIncrement = 0.03;
            InterpolationType = InterpolationType.Linear;
            InterruptAnimation = true;
            // Set the animation direction to inward by default. 
            _animationDirection = AnimationDirection.In;
            _animationTimer.Tick += AnimationTimer_OnTick;
        }

        /// <summary>
        /// Starts a new animation.
        /// If the spe
        /// </summary>
        /// <param name="direction">The direction of the animation.</param>
        public void StartNewAnimation(AnimationDirection direction)
        {
            if (!IsAnimating() || InterruptAnimation)
            {
                _animationProgress =
                    (direction == AnimationDirection.Out ||
                    direction == AnimationDirection.InOutOut) ? 1 : 0;
                _animationDirection = direction;
                _animationTimer.Start();
            }
        }

        private void AnimationTimer_OnTick(object sender, EventArgs eventArgs)
        {
            UpdateProgress();
            ResetDirection();
            OnAnimationProgress?.Invoke(this);
        }

        private void ResetDirection()
        {
            if ((_animationDirection == AnimationDirection.InOutIn && _animationProgress == MAX_VALUE))
            {
                _animationDirection = AnimationDirection.InOutOut;
            }
            else if ((_animationDirection == AnimationDirection.InOutRepeatingIn && _animationProgress == MAX_VALUE))
            {
                _animationDirection = AnimationDirection.InOutRepeatingOut;
            }
            else if ((_animationDirection == AnimationDirection.InOutRepeatingOut && _animationProgress == MIN_VALUE))
            {
                _animationDirection = AnimationDirection.InOutRepeatingIn;
            }
        }
              

        /// <summary>
        /// Updates the progress of the animation. 
        /// The progress value will be either incremented or decremented depending
        /// on the current direction of the animation.
        /// </summary>
        /// <exception cref="Exception">
        /// Throws an exception if no animation direction is specified.
        /// </exception>
        private void UpdateProgress()
        {
            switch (_animationDirection)
            {
                case AnimationDirection.InOutRepeatingIn:
                case AnimationDirection.InOutIn:
                case AnimationDirection.In:
                    IncrementProgress();
                    break;

                case AnimationDirection.InOutRepeatingOut:
                case AnimationDirection.InOutOut:
                case AnimationDirection.Out:
                    DecrementProgress();
                    break;

                default:
                    throw new Exception("No AnimationDirection has been set");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void IncrementProgress()
        {
            _animationProgress += Increment;
            if (_animationProgress > MAX_VALUE)
            {
                // The animation progressed outward and has reached 1. 
                _animationProgress = MAX_VALUE;
                if (IsLooping())
                {
                    return;
                }
                if ((_animationDirection == AnimationDirection.InOutOut
                    || _animationDirection == AnimationDirection.In)
                    && _animationProgress != MAX_VALUE)
                {
                    return;
                }

                _animationTimer.Stop();
                OnAnimationFinished?.Invoke(this);
            }
        }        

        /// <summary>
        /// 
        /// </summary>
        private void DecrementProgress()
        {
            _animationProgress -= (_animationDirection == AnimationDirection.InOutOut ||
                _animationDirection == AnimationDirection.InOutRepeatingOut) ? SecondaryIncrement : Increment;
            if (_animationProgress < MIN_VALUE)
            {
                // The animation progressed inward and has reached 0. 
                _animationProgress = MIN_VALUE;

                if (IsLooping())
                {
                    return;
                }
                if ((_animationDirection == AnimationDirection.InOutOut
                    || _animationDirection == AnimationDirection.Out)
                    && _animationProgress != MIN_VALUE)
                {
                    return;
                }
                _animationTimer.Stop();
                OnAnimationFinished?.Invoke(this);
            }
        }
        private bool IsLooping()
        {
            return (_animationDirection == AnimationDirection.InOutIn
                    || _animationDirection == AnimationDirection.InOutRepeatingIn
                    || _animationDirection == AnimationDirection.InOutRepeatingOut);
        }
        /// <summary>
        /// Determines whether the animation is running or not.
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsAnimating()
        {
            return _animationTimer.Enabled;
        }
        /// <summary>
        /// Interpolates and returns the progressed value of the animation.
        /// The returned values ranges between 0 and 1.
        /// </summary>
        /// <returns>An interpolated value between 0 and 1.</returns>
        public double GetProgress()
        {
            return _interpolator.Interpolate(_animationProgress);
        }

        /// <summary>
        /// Stops the actively running animation and fires the OnFinished event.
        /// </summary>
        public void Stop()
        {
            _animationTimer.Stop();
            OnAnimationFinished?.Invoke(this);
        }

        /// <summary>
        /// Creates an instance of an interpolator specified by its enum type.
        /// </summary>
        /// <param name="pInterpolatorType">The type of interpolator to be instantiated.</param>
        private void SetInterpolator(InterpolationType pInterpolatorType)
        {
            IValueInterpolatable newInterpolator = ConstructableFactory.GetInstanceOf<IValueInterpolatable>(pInterpolatorType);
            // Create a linear interpolator if the dynamic instantiation fails.
            _interpolator = newInterpolator ?? new InterpolatorLinear();
        }
    }
}