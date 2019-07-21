﻿namespace ToyGrafX.Engine.Utility
{
    using OpenTK;
    using ToyGrafX.Engine.Controllers;

    public static class Maths
    {
        public static Matrix4 CreateTransformationMatrix(
            Vector3 translation, Vector3 rotation, float scale) =>
            Matrix4.CreateScale(scale) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X)) *
            Matrix4.CreateTranslation(translation);

        public static Matrix4 CreateViewMatrix(Camera camera) =>
            Matrix4.CreateTranslation(-camera.GetPosition()) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(camera.Pitch)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(camera.Yaw)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(camera.Roll));
    }
}
