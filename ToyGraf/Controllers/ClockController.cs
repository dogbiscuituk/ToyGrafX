namespace ToyGraf.Controllers
{
    using System;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class ClockController
    {
        #region Internal Interface

        internal ClockController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneForm.TimeDecelerate.Click += TimeDecelerate_Click;
            SceneForm.tbDecelerate.Click += TimeDecelerate_Click;
            SceneForm.TimeReverse.Click += TimeReverse_Click;
            SceneForm.tbReverse.Click += TimeReverse_Click;
            SceneForm.TimeStop.Click += TimeStop_Click;
            SceneForm.tbStop.Click += TimeStop_Click;
            SceneForm.TimePause.Click += TimePause_Click;
            SceneForm.tbPause.Click += TimePause_Click;
            SceneForm.TimeForward.Click += TimeForward_Click;
            SceneForm.tbForward.Click += TimeForward_Click;
            SceneForm.TimeAccelerate.Click += TimeAccelerate_Click;
            SceneForm.tbAccelerate.Click += TimeAccelerate_Click;
            Clock = new Clock { Sync = SceneForm };
            Clock.Tick += Clock_Tick;
            UpdateTimeControls();
        }

        internal Clock Clock;
        internal double VirtualSecondsElapsed => Clock.VirtualSecondsElapsed;
        internal bool ClockRunning => Clock.Running;

        internal double VirtualTimeFactor
        {
            get => Clock.VirtualTimeFactor;
            set => Clock.VirtualTimeFactor = value;
        }

        internal void UpdateTimeControls()
        {
            if (ClockRunning)
                ClockStop();
            SceneForm.TimeAccelerate.Enabled = SceneForm.tbAccelerate.Enabled = CanAccelerate;
            SceneForm.TimeDecelerate.Enabled = SceneForm.tbDecelerate.Enabled = CanDecelerate;
            SceneForm.TimeForward.Enabled = SceneForm.tbForward.Enabled = CanStart;
            SceneForm.TimePause.Enabled = SceneForm.tbPause.Enabled = CanPause;
            SceneForm.TimeReverse.Enabled = SceneForm.tbReverse.Enabled = CanReverse;
            SceneForm.TimeStop.Enabled = SceneForm.tbStop.Enabled = CanStop;
            UpdateTimeFactor();
        }

        #endregion

        #region Private Properties

        private SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => !Clock.Running || VirtualTimeFactor > 0;
        private bool CanStart => !Clock.Running || VirtualTimeFactor < 0;
        private bool CanStop => Clock.Running;

        #endregion

        #region Private Event Handlers

        private void Clock_Tick(object sender, EventArgs e) => UpdateTimeDisplay();
        private void TimeDecelerate_Click(object sender, EventArgs e) => ClockDecelerate();
        private void TimeReverse_Click(object sender, EventArgs e) => ClockReverse();
        private void TimeStop_Click(object sender, EventArgs e) => ClockStop();
        private void TimePause_Click(object sender, EventArgs e) => ClockPause();
        private void TimeForward_Click(object sender, EventArgs e) => ClockForward();
        private void TimeAccelerate_Click(object sender, EventArgs e) => ClockAccelerate();

        #endregion

        #region Private Methods

        private void ClockAccelerate()
        {
            Clock.Accelerate();
            UpdateTimeControls();
        }

        private void ClockDecelerate()
        {
            Clock.Decelerate();
            UpdateTimeControls();
        }

        private void ClockForward()
        {
            VirtualTimeFactor = Math.Abs(VirtualTimeFactor);
            ClockStart();
            UpdateTimeControls();
        }

        private void ClockPause()
        {
            Clock.Stop();
            UpdateTimeControls();
        }

        private void ClockReverse()
        {
            VirtualTimeFactor = -Math.Abs(VirtualTimeFactor);
            ClockStart();
            UpdateTimeControls();
        }

        private void ClockStart() => Clock.Start();

        private void ClockStop()
        {
            Clock.Reset();
            UpdateTimeDisplay();
            UpdateTimeControls();
        }

        private void UpdateTimeDisplay()
        {
            Clock.UpdateFPS();
            SceneForm.Tlabel.Text = string.Format("t={0:f1}", VirtualSecondsElapsed);
            SceneForm.FPSlabel.Text = string.Format("fps={0:f1}", Clock.FramesPerSecond);
        }

        private void UpdateTimeFactor()
        {
            string speed;
            var factor = VirtualTimeFactor;
            if (factor == 0)
                speed = "time × 0";
            else
            {
                var divide = Math.Abs(factor) < 1;
                if (divide)
                    factor = 1 / factor;
                speed = divide ? $"time ÷ {factor}" : $"time × {factor}";
            }
            SceneForm.SpeedLabel.Text = speed;
        }

        #endregion
    }
}
