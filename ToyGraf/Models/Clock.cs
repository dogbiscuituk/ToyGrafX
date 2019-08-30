// <copyright file="Clock.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Models
{
    using System;
    using System.Windows.Forms;

    public class Clock
    {
        public Clock()
        {
            Timer = new Timer { Enabled = false };
            Timer.Tick += Timer_Tick;
        }

        public bool Running
        {
            get => _Running;
            set
            {
                if (Running != value)
                {
                    var now = DateTime.Now;
                    if (Running)
                    {
                        Timer.Enabled = false;
                        var elapsed = now - _StartedAt;
                        _RealTimeElapsed += elapsed;
                        _VirtualTimeElapsed += GetVirtualIncrement(now);
                    }
                    _Running = value;
                    if (Running)
                    {
                        _StartedAt = now;
                        Timer.Enabled = true;
                    }
                }
            }
        }

        public double RealSecondsElapsed => RealTimeElapsed.TotalSeconds;
        public double VirtualSecondsElapsed => VirtualTimeElapsed.TotalSeconds;

        public int Interval_ms
        {
            get => Timer.Interval;
            set => Timer.Interval = value;
        }

        public TimeSpan RealTimeElapsed => Running
            ? _RealTimeElapsed + (DateTime.Now - _StartedAt)
            : _RealTimeElapsed;

        public TimeSpan VirtualTimeElapsed => Running
            ? _VirtualTimeElapsed + GetVirtualIncrement(DateTime.Now)
            : _VirtualTimeElapsed;

        public double VirtualTimeFactor
        {
            get => _VirtualTimeFactor;
            set
            {
                if (VirtualTimeFactor != value)
                {
                    var running = Running;
                    Stop();
                    _VirtualTimeFactor = value;
                    if (running)
                        Start();
                }
            }
        }

        public event EventHandler<EventArgs> Tick;

        public void Accelerate() => VirtualTimeFactor = +Scale(+VirtualTimeFactor);
        public void Decelerate() => VirtualTimeFactor = -Scale(-VirtualTimeFactor);

        public void Reset()
        {
            Running = false;
            _RealTimeElapsed = TimeSpan.Zero;
            _VirtualTimeElapsed = TimeSpan.Zero;
            _VirtualTimeFactor = 1;
        }

        public void Resume()
        {
            if (_SuspendCount > 0 && --_SuspendCount == 0)
                Running = true;
        }

        public void Start()
        {
            _SuspendCount = 0;
            Running = true;
        }

        public void Stop()
        {
            _SuspendCount = 0;
            Running = false;
        }

        public void Suspend()
        {
            _SuspendCount++;
            Running = false;
        }

        private const int LimitFactor = 32;
        private bool _Running;
        private DateTime _StartedAt;
        private TimeSpan _RealTimeElapsed, _VirtualTimeElapsed;
        private int _SuspendCount;
        private readonly Timer Timer;
        private double _VirtualTimeFactor = 1;

        private void Timer_Tick(object sender, EventArgs e) => Tick?.Invoke(this, EventArgs.Empty);



        private TimeSpan GetVirtualIncrement(DateTime now) =>
            TimeSpan.FromSeconds((now - _StartedAt).TotalSeconds * VirtualTimeFactor);

        private static double Scale(double factor)
        {
            switch (factor)
            {
                case double f when f < -1.0 / LimitFactor:
                    return factor / 2;
                case -1.0 / LimitFactor:
                    return 0;
                case 0:
                    return 1.0 / LimitFactor;
                case double f when f < LimitFactor:
                    return factor * 2;
                default:
                    return LimitFactor;
            }
        }
    }
}
