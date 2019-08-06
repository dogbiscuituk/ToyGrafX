namespace ToyGraf.Engine.Utility
{
    using OpenTK;
    using ToyGraf.Engine.Controllers;

    public static class Maths
    {
        public static Matrix4 CreateOrthographicProjection(
            float width, float height, float zNear, float zFar) =>
            Matrix4.CreateOrthographic(width, height, zNear, zFar);

        public static Matrix4 CreateOrthographicProjection(
            float left, float right, float bottom, float top, float zNear, float zFar) =>
            Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar);

        public static Matrix4 CreatePerspectiveProjection(
            float fovy, float aspect, float zNear, float zFar) =>
            Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovy), aspect, zNear, zFar);

        public static Matrix4 CreatePerspectiveProjection(
            float left, float right, float bottom, float top, float zNear, float zFar) =>
            Matrix4.CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar);

        public static Matrix4 CreateTransformation(
            Vector3 translation, Vector3 rotation, float scale) =>
            Matrix4.CreateScale(scale) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X)) *
            Matrix4.CreateTranslation(translation);

        public static Matrix4 CreateCameraView(Camera camera) =>
            Matrix4.CreateTranslation(-camera.Position) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(camera.Roll)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(camera.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(camera.Pitch));
    }
}
