namespace ToyGraf.Controllers
{
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class CameraController
    {
        internal CameraController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneForm.CameraZoomIn.Click += CameraZoomIn_Click;
            SceneForm.CameraZoomOut.Click += CameraZoomOut_Click;
        }

        private void CameraZoomIn_Click(object sender, System.EventArgs e) => ZoomBy(+0.1f);
        private void CameraZoomOut_Click(object sender, System.EventArgs e) => ZoomBy(-0.1f);

        private void Move()
        {
            // Find the camera axes using the Gram–Schmidt process:
            // https://en.wikipedia.org/wiki/Gram%E2%80%93Schmidt_process
            Vector3f
                cameraDirection = (Camera.Position - Target).Normalize(),
                cameraRight = new Vector3f(0, 1, 0).Cross(cameraDirection).Normalize(),
                cameraUp = cameraDirection.Cross(cameraRight);

        }

        private void ZoomBy(float distance) { }

        private Camera Camera => Scene.Camera;
        private Scene Scene => SceneController.Scene;
        private readonly SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;
        private Vector3f Target = new Vector3f();
    }
}
