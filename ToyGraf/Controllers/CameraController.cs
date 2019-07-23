namespace ToyGraf.Controllers
{
    using OpenTK;
    using ToyGraf.Controls;
    using ToyGraf.Engine.Controllers;

    public class CameraController
    {
        public CameraController(Renderer renderer, CameraControl cameraControl)
        {
            Renderer = renderer;
            CameraControl = cameraControl;
        }

        private Renderer _Renderer;
        public Renderer Renderer
        {
            get => _Renderer;
            set
            {
                if (Renderer != null)
                {

                }
                _Renderer = value;
                if (Renderer != null)
                {

                }
            }
        }

        private CameraControl _CameraControl;
        public CameraControl CameraControl
        {
            get => _CameraControl;
            set
            {
                if (CameraControl != null)
                {
                }
                _CameraControl = value;
                if (CameraControl != null)
                {
                    CameraControl.seX.ValueChanged += Control_ValueChanged;

                }
            }
        }

        private Camera Camera => Renderer.Camera;

        private bool Updating;

        private void Control_ValueChanged(object sender, System.EventArgs e) => CameraWrite();

        private void CameraRead()
        {
            if (!Updating)
            {
                CameraControl.seX.Value = (decimal)Camera.X;
                CameraControl.seY.Value = (decimal)Camera.Y;
                CameraControl.seZ.Value = (decimal)Camera.Z;
                CameraControl.sePitch.Value = (decimal)Camera.Pitch;
                CameraControl.seYaw.Value = (decimal)Camera.Yaw;
                CameraControl.seRoll.Value = (decimal)Camera.Roll;
                Updating = false;
            }
        }

        private void CameraWrite()
        {
            lock (Renderer)
                if (!Updating)
                {
                    Updating = true;
                    Camera.Position = new Vector3(
                        (float)CameraControl.seX.Value,
                        (float)CameraControl.seY.Value,
                        (float)CameraControl.seZ.Value);
                    Camera.Pitch = (float)CameraControl.sePitch.Value;
                    Camera.Yaw = (float)CameraControl.seYaw.Value;
                    Camera.Roll = (float)CameraControl.seRoll.Value;
                    Updating = false;
                }
        }
    }
}
