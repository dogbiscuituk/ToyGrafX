using System.ComponentModel;
using ToyGraf.Commands;

namespace ToyGraf.Models
{
    public class Trace
    {
        public double Xmax
        {
            get => _Xmax;
            set
            {
                Run(new TraceXmaxCommand(this, value));
            }
        }

        [Category("Trace")]
        [Description(@"Variable names X, Y, Z represent spatial co-ordinates, ranging from -1.0 to +1.0. 
Names are case-insensitive. Colours use these variables, ranging from 0.0 to 1.0:
  R, G, B (red, green, blue);
  H, S, L (hue, saturation, luminance);
  A (alpha): the opacity of a given colour, default 1 (fully opaque).
The default value any of the other variables is 0.
Finally, T represents time (elapsed seconds), and is read-only.")]
        public string[] Script { get; set; }

        #region Private Properties

        private double _Xmax, _Xmin, _Ymax, _Ymin, _Zmax, _Zmin;

        #endregion

        #region Private Methods

        private bool Run(ICommand command)
        {
            return true;
        }

        #endregion
    }
}
