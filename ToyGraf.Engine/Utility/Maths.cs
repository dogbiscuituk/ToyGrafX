namespace ToyGraf.Engine.Utility
{
    using OpenTK;
    using System;
    using System.Drawing;
    using ToyGraf.Engine.Types;

    public static class Maths
    {
        public static Matrix4 CreateCameraView(Camera camera) => CreateCameraView(camera.Position, camera.Focus);

        public static Matrix4 CreateCameraView(Vector3f position, Vector3f focus) =>
            Matrix4.LookAt(position.ToVector3(), focus.ToVector3(), new Vector3(0, 1, 0));

        public static Matrix4 CreateProjection(Projection p) => CreateProjection(p, new Size(16, 9));

        public static Matrix4 CreateProjection(Projection p, Size s)
        {
            switch (p.ProjectionType)
            {
                case ProjectionType.Orthographic:
                    return Matrix4.CreateOrthographic(p.Width, p.Height, p.Near, p.Far);
                case ProjectionType.OrthographicOffset:
                    return Matrix4.CreateOrthographicOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
                case ProjectionType.Perspective:
                    return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(p.FieldOfView), (float)s.Width / s.Height, p.Near, p.Far);
                case ProjectionType.PerspectiveOffset:
                    return Matrix4.CreatePerspectiveOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
            }
            return Matrix4.Identity;
        }

        public static Matrix4 CreateTransformation(
            Vector3f location, Euler3f orientation, Vector3f scale) =>
            Matrix4.CreateScale(scale.X, scale.Y, scale.Z) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Roll)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(orientation.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(orientation.Pitch)) *
            Matrix4.CreateTranslation(location.ToVector3());

        public static Vector3f Cross(this Vector3f p, Vector3f q) =>
            new Vector3f(p.Y * q.Z - p.Z * q.Y, p.Z * q.X - p.X * q.Z, p.X * q.Y - p.Y * q.X);

        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        public static Vector3f Normalize(this Vector3f p)
        {
            var size = (float)Math.Sqrt(p.X * p.X + p.Y * p.Y + p.Z * p.Z);
            return size == 0 ? new Vector3f() : new Vector3f(p.X / size, p.Y / size, p.Z / size);
        }

        public static Euler3f ToEuler3f(this Vector3 p) => new Euler3f(p.X, p.Y, p.Z);
        public static Euler3f ToEuler3f(this Quaternion p) => new Euler3f(p.X, p.Y, p.Z);
        public static Vector3 ToVector3(this Euler3f p) => new Vector3(p.Pitch, p.Yaw, p.Roll);
        public static Vector3 ToVector3(this Vector3f p) => new Vector3(p.X, p.Y, p.Z);
        public static Vector3f ToVector3f(this Vector3 p) => new Vector3f(p.X, p.Y, p.Z);
    }
}
