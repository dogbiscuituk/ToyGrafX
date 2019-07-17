namespace ToyGrafX
{
    using OpenTK;

    public static class Maths
    {
        public static Matrix4 CreateTransformationMatrix(
            Vector3 translation, float rx, float ry, float rz, float scale) =>
            Matrix4.CreateScale(scale) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rz)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(ry)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rx)) *
            Matrix4.CreateTranslation(translation);

        public static Matrix4 CreateViewMatrix(Camera camera) =>
            Matrix4.CreateTranslation(-camera.GetPosition()) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(camera.Pitch)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(camera.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(camera.Roll));
    }
}
