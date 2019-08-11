namespace ToyGraf.Engine.Utility
{
    using OpenTK;

    public static class Maths
    {
        public static Matrix4 CreateCameraView(Camera camera) =>
            CreateCameraView(camera.Position, camera.Rotation);

        public static Matrix4 CreateCameraView(Vector3 location, Vector3 orientation) =>
            Matrix4.CreateTranslation(-location) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Z)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(orientation.Y)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(orientation.X));

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
            Vector3 location, Vector3 orientation, float scale) =>
            Matrix4.CreateScale(scale) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Z)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(orientation.Y)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(orientation.X)) *
            Matrix4.CreateTranslation(location);
    }
}
