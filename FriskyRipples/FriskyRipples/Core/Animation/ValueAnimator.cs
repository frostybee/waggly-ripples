namespace FrostyBee.FriskyRipples.Animation
{
    using FrostyBee.FriskyRipples.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="ValueAnimator" />
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
        /// Gets or sets the Increment
        /// </summary>
        public double Increment { get; set; }

        /// <summary>
        /// Gets or sets the SecondaryIncrement
        /// </summary>
        public double SecondaryIncrement { get; set; }

        /// <summary>
        /// Gets or sets the InterpolationType.
        /// When the values changes, an instance of the selected interpolator 
        /// will be created. 
        /// </summary>
        public InterpolationType InterpolationType
        {
            set
            {
                CreateInterpolator(value);
            }
        }

        #endregion

        /// <summary>
        /// The AnimationFinished
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        public delegate void AnimationFinished(object sender);

        /// <summary>
        /// Defines the OnAnimationFinished
        /// </summary>
        public event AnimationFinished OnAnimationFinished;

        /// <summary>
        /// The AnimationProgress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        public delegate void AnimationProgress(object sender);

        /// <summary>
        /// Defines the OnAnimationProgress
        /// </summary>
        public event AnimationProgress OnAnimationProgress;

        /// <summary>
        /// Defines the _animationProgresses
        /// </summary>
        private readonly List<double> _animationProgresses;

        /// <summary>
        /// Defines the _animationDirections
        /// </summary>
        private readonly List<AnimationDirection> _animationDirections;

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
            _animationProgresses = new List<double>();            
            _animationDirections = new List<AnimationDirection>();            
            // Default interpolator.
            _interpolator = new InterpolatorLinear();
            Increment = 0.03;
            SecondaryIncrement = 0.05;
            InterpolationType = InterpolationType.Linear;
            InterruptAnimation = true;
            _animationProgresses.Add(0);            
            // Set the animation direction to inward by default. 
            _animationDirections.Add(AnimationDirection.In);
            _animationTimer.Tick += AnimationTimerOnTick;
        }

        /// <summary>
        /// The AnimationTimerOnTick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="eventArgs">The eventArgs<see cref="EventArgs"/></param>
        private void AnimationTimerOnTick(object sender, EventArgs eventArgs)
        {
            for (var i = 0; i < _animationProgresses.Count; i++)
            {
                UpdateProgress(i);
                if ((_animationDirections[i] == AnimationDirection.InOutIn && _animationProgresses[i] == MAX_VALUE))
                {
                    _animationDirections[i] = AnimationDirection.InOutOut;
                }
                else if ((_animationDirections[i] == AnimationDirection.InOutRepeatingIn && _animationProgresses[i] == MAX_VALUE))
                {
                    _animationDirections[i] = AnimationDirection.InOutRepeatingOut;
                }
                else if ((_animationDirections[i] == AnimationDirection.InOutRepeatingOut && _animationProgresses[i] == MIN_VALUE))
                {
                    _animationDirections[i] = AnimationDirection.InOutRepeatingIn;
                }
            }

            OnAnimationProgress?.Invoke(this);
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
        /// The StartNewAnimation
        /// </summary>
        /// <param name="animationDirection">The animationDirection<see cref="AnimationDirection"/></param>
        /// <param name="data">The data<see cref="object[]"/></param>
        public void StartNewAnimation(AnimationDirection animationDirection, object[] data = null)
        {
            if (animationDirection == AnimationDirection.Out || animationDirection == AnimationDirection.InOutOut)
            {
                SetProgress(1);
            }
            else
            {
                SetProgress(0);
            }
            StartNewAnimation(animationDirection, new Point(0, 0), data);
        }

        /// <summary>
        /// The StartNewAnimation
        /// </summary>
        /// <param name="animationDirection">The animationDirection<see cref="AnimationDirection"/></param>
        /// <param name="animationSource">The animationSource<see cref="Point"/></param>
        /// <param name="data">The data<see cref="object[]"/></param>
        public void StartNewAnimation(AnimationDirection animationDirection, Point animationSource, object[] data = null)
        {
            if (!IsAnimating() || InterruptAnimation)
            {
                if (_animationDirections.Count > 0)
                {
                    _animationDirections[0] = animationDirection;
                }
                else
                {
                    _animationDirections.Add(animationDirection);
                }                
            }
            _animationTimer.Start();
        }

        /// <summary>
        /// The UpdateProgress
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        public void UpdateProgress(int index)
        {
            switch (_animationDirections[index])
            {
                case AnimationDirection.InOutRepeatingIn:
                case AnimationDirection.InOutIn:
                case AnimationDirection.In:
                IncrementProgress(index);
                break;

                case AnimationDirection.InOutRepeatingOut:
                case AnimationDirection.InOutOut:
                case AnimationDirection.Out:
                DecrementProgress(index);
                break;

                default:
                throw new Exception("No AnimationDirection has been set");
            }
        }

        /// <summary>
        /// The IncrementProgress
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        private void IncrementProgress(int index)
        {
            _animationProgresses[index] += Increment;
            if (_animationProgresses[index] > MAX_VALUE)
            {
                _animationProgresses[index] = MAX_VALUE;

                for (int i = 0; i < GetAnimationCount(); i++)
                {
                    if (_animationDirections[i] == AnimationDirection.InOutIn)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutRepeatingIn)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutRepeatingOut)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutOut && _animationProgresses[i] != MAX_VALUE)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.In && _animationProgresses[i] != MAX_VALUE)
                    {
                        return;
                    }
                }

                _animationTimer.Stop();
                OnAnimationFinished?.Invoke(this);
            }
        }

        /// <summary>
        /// The DecrementProgress
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        private void DecrementProgress(int index)
        {
            _animationProgresses[index] -= (_animationDirections[index] == AnimationDirection.InOutOut || _animationDirections[index] == AnimationDirection.InOutRepeatingOut) ? SecondaryIncrement : Increment;
            if (_animationProgresses[index] < MIN_VALUE)
            {
                _animationProgresses[index] = MIN_VALUE;

                for (var i = 0; i < GetAnimationCount(); i++)
                {
                    if (_animationDirections[i] == AnimationDirection.InOutIn)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutRepeatingIn)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutRepeatingOut)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.InOutOut && _animationProgresses[i] != MIN_VALUE)
                    {
                        return;
                    }

                    if (_animationDirections[i] == AnimationDirection.Out && _animationProgresses[i] != MIN_VALUE)
                    {
                        return;
                    }
                }

                _animationTimer.Stop();
                OnAnimationFinished?.Invoke(this);
            }
        }

        /// <summary>
        /// The GetProgress
        /// </summary>
        /// <returns>The <see cref="double"/></returns>
        public double GetProgress()
        {

            if (_animationProgresses.Count == 0)
            {
                throw new Exception("Invalid animation");
            }

            return GetProgress(0);
        }

        /// <summary>
        /// The GetProgress
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="double"/></returns>
        public double GetProgress(int index)
        {
            if (!(index < GetAnimationCount()))
            {
                throw new IndexOutOfRangeException("Invalid animation index");
            }
            return _interpolator.Interpolate(_animationProgresses[index]);
        }               

        /// <summary>
        /// The GetDirection
        /// </summary>
        /// <returns>The <see cref="AnimationDirection"/></returns>
        public AnimationDirection GetDirection()
        {
            if (_animationDirections.Count == 0)
            {
                throw new Exception("Invalid animation");
            }

            return _animationDirections[0];
        }

        /// <summary>
        /// The GetDirection
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="AnimationDirection"/></returns>
        public AnimationDirection GetDirection(int index)
        {
            if (!(index < _animationDirections.Count))
            {
                throw new IndexOutOfRangeException("Invalid animation index");
            }

            return _animationDirections[index];
        }
        
        /// <summary>
        /// The GetAnimationCount
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int GetAnimationCount()
        {
            return _animationProgresses.Count;
        }

        /// <summary>
        /// The SetProgress
        /// </summary>
        /// <param name="progress">The progress<see cref="double"/></param>
        public void SetProgress(double progress)
        {
            if (_animationProgresses.Count == 0)
            {
                throw new Exception("Invalid animation");
            }

            _animationProgresses[0] = progress;
        }

        /// <summary>
        /// The SetDirection
        /// </summary>
        /// <param name="direction">The direction<see cref="AnimationDirection"/></param>
        public void SetDirection(AnimationDirection direction)
        {
            if (_animationProgresses.Count == 0)
            {
                throw new Exception("Invalid animation");
            }

            _animationDirections[0] = direction;
        }
                
        public void Stop()
        {
            _animationTimer.Stop();
            if (OnAnimationFinished != null) OnAnimationFinished(this);
        }
        /// <summary>
        /// Creates an instance of an interpolator specified by its enum type.
        /// </summary>
        /// <param name="pInterpolatorType">The type of interpolator to be instantiated.</param>
        private void CreateInterpolator(InterpolationType pInterpolatorType)
        {
            IValueInterpolatable newInterpolator = ConstructableFactory.GetInstanceOf<IValueInterpolatable>(pInterpolatorType);
            if (newInterpolator == null)
            {
                // Create a linear interpolator if the dynamic instantiation fails.
                newInterpolator = new InterpolatorLinear();
            }
            _interpolator = newInterpolator;
        }
    }
}