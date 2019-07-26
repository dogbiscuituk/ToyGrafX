namespace ToyGraf.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
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
            Clock = new Clock { Sync = SceneController.SceneForm };
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

        internal void AfterDraw()
        {
            if (Stopwatch != null)
            {
                Stopwatch.Stop();
                // That Graph.Draw() operation took ms = stopwatch.ElapsedMilliseconds.
                // Add 10% & round up to multiple of 10ms to get the time to next Draw.
                double
                    t = 10 * Math.Ceiling(Stopwatch.ElapsedMilliseconds * 0.11),
                    fps = 2000 / (t + Clock.Interval);
                Clock.NextInterval = t;
                Stopwatch = null;
            }
        }

        internal void BeforeDraw()
        {
            if (Clock.Running)
            {
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
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
            SceneForm.SpeedLabel.Enabled = SceneForm.TimeLabel.Enabled = SceneForm.FpsLabel.Enabled = true;
            UpdateTimeFactor();
        }

        #endregion

        #region Private Properties

        private SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;
        private Stopwatch Stopwatch;

        private bool CanAccelerate => VirtualTimeFactor < +32;
        private bool CanDecelerate => VirtualTimeFactor > -32;
        private bool CanPause => Clock.Running;
        private bool CanReverse => (!Clock.Running || VirtualTimeFactor > 0);
        private bool CanStart => (!Clock.Running || VirtualTimeFactor < 0);
        private bool CanStop => Clock.Running;

        private bool EpilepsyWarningAcknowledged
        {
            get => AppController.EpilepsyWarningAcknowledged;
            set => AppController.EpilepsyWarningAcknowledged = value;
        }

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

        private void ClockStart()
        {
            if (!EpilepsyWarningAcknowledged)
                EpilepsyWarningAcknowledged = MessageBox.Show(
                    SceneForm,
                    "The Time function can be used to create fast flashing images which may cause discomfort, " +
                    "and have the potential to trigger seizures in people with photosensitive epilepsy. " +
                    "User discretion is advised.\n\nDo you wish to proceed?",
                    "Warning - Photosensitive Epilepsy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes;
            if (EpilepsyWarningAcknowledged)
                Clock.Start();
        }

        private void ClockStop()
        {
            Clock.Reset();
            UpdateTimeDisplay();
            UpdateTimeControls();
        }

        private void UpdateTimeDisplay()
        {
            Clock.UpdateFPS();
            SceneForm.TimeLabel.Text = string.Format("t={0:f1}", VirtualSecondsElapsed);
            SceneForm.FpsLabel.Text = string.Format("fps={0:f1}", Clock.FramesPerSecond);
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
