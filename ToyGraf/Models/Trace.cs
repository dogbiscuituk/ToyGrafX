namespace ToyGraf.Models
{
    using System.ComponentModel;
    using ToyGraf.Commands;

    public class Trace
    {
        #region Public Interface

        public Trace(Scene scene) => Scene = scene;

        #endregion

        #region Persistent Properties

        [Category("Domain")]
        public double Xmax { get => _Xmax; set => Run(new TraceXmaxCommand(this, value)); }

        [Category("Domain")]
        public double Xmin { get => _Xmin; set => Run(new TraceXminCommand(this, value)); }

        [Category("Domain")]
        public double Ymax { get => _Ymax; set => Run(new TraceYmaxCommand(this, value)); }

        [Category("Domain")]
        public double Ymin { get => _Ymin; set => Run(new TraceYminCommand(this, value)); }

        [Category("Domain")]
        public double Zmax { get => _Zmax; set => Run(new TraceZmaxCommand(this, value)); }

        [Category("Domain")]
        public double Zmin { get => _Zmin; set => Run(new TraceZminCommand(this, value)); }

        [Category("Trace")]
        [Description(@"Variable names X, Y, Z represent spatial co-ordinates.
Names are case-insensitive. Colours use these variables, ranging from 0.0 to 1.0:
  R, G, B (red, green, blue);
  H, S, L (hue, saturation, luminance);
  A (alpha): the opacity of a given colour, default 1 (fully opaque).
The default value any of the other variables is 0.
Finally, T represents time (elapsed seconds), and is read-only.")]
        public string[] Script { get => _Script; set => Run(new TraceScriptCommand(this, value)); }

        [Category("Trace")]
        [Description("Take a wild guess.")]
        public bool Visible { get => _Visible; set => Run(new TraceVisibleCommand(this, value)); }

        #endregion

        #region Private Properties

        internal bool _Visible;
        internal double _Xmax, _Xmin, _Ymax, _Ymin, _Zmax, _Zmin;
        internal string[] _Script;

        private ICommandProcessor CommandProcessor => Scene.CommandProcessor;
        private Scene Scene;

        #endregion

        #region Private Methods

        private void Run(ICommand command) => CommandProcessor.Run(command);

        #endregion
    }
}
