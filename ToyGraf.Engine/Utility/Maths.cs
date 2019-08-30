// <copyright file="Maths.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Engine.Utility
{
    using OpenTK;
    using System.Drawing;
    using ToyGraf.Engine.Types;

    public static class Maths
    {
        public static Matrix4 CreateCameraView(Camera camera) =>
            CreateCameraView(camera.Position, camera.Rotation);

        public static Matrix4 CreateCameraView(Point3F position, Euler3F rotation) =>
            Matrix4.CreateTranslation(-position.ToVector3()) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Roll)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.Pitch));

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
            Point3F location, Euler3F orientation, Point3F scale) =>
            Matrix4.CreateScale(scale.X, scale.Y, scale.Z) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Roll)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(orientation.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(orientation.Pitch)) *
            Matrix4.CreateTranslation(location.ToVector3());

        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        public static Euler3F ToEuler3F(this Vector3 v) => new Euler3F(v.X, v.Y, v.Z);
        public static Euler3F ToEuler3F(this Quaternion v) => new Euler3F(v.X, v.Y, v.Z);
        public static Point3F ToPoint3F(this Vector3 v) => new Point3F(v.X, v.Y, v.Z);
        public static Vector3 ToVector3(this Euler3F e) => new Vector3(e.Pitch, e.Yaw, e.Roll);
        public static Vector3 ToVector3(this Point3F p) => new Vector3(p.X, p.Y, p.Z);
    }
}
