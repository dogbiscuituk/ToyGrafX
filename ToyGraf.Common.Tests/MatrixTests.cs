namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenTK;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;

    /// <summary>
    /// Get the projection matrix for a general frustum.
    /// </summary>
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateOrthographicProjection()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -0.002002002f, 0, 0, 0, -1.002002f, 1);
            var projection = new Projection(width: 2, height: 2, near: 1, far: 1000);
            var actual = Maths.CreateProjection(projection);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateOrthographicProjectionEccentric()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -0.002002002f, 0, 0, 0, -1.002002f, 1);
            var projection = new Projection(ProjectionType.OrthographicOffset, left: -1, right: +1, bottom: -1, top: +1, near: 1, far: 1000);
            var actual = Maths.CreateProjection(projection);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePerspectiveProjection()
        {
            var expected = new Matrix4(0.8033332f, 0, 0, 0, 0, 1.428148f, 0, 0, 0, 0, -1.002002f, -1, 0, 0, -2.002002f, 0);
            var projection = new Projection(fieldOfView: 70, width: 16, height: 9, near: 1, far: 1000);
            var actual = Maths.CreateProjection(projection);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePerspectiveProjectionEccentric()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1.002002f, -1, 0, 0, -2.002002f, 0);
            var projection = new Projection(ProjectionType.PerspectiveOffset, left: -1, right: +1, bottom: -1, top: +1, near: 1, far: 1000);
            var actual = Maths.CreateProjection(projection);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for the identity transformation.
        /// </summary>
        [TestMethod]
        public void CreateTransformationDefault()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: new Euler3f(), scale: Unity);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a 90° rotation about the x axis.
        /// </summary>
        [TestMethod]
        public void CreateRotationX()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 0, 1, 0, 0, -1, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateX, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a 90° rotation about the y axis.
        /// </summary>
        [TestMethod]
        public void CreateRotationY()
        {
            var expected = new Matrix4(0, 0, -1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateY, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a 90° rotation about the z axis.
        /// </summary>
        [TestMethod]
        public void CreateRotationZ()
        {
            var expected = new Matrix4(0, 1, 0, 0, -1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateZ, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for 90° rotations about the x & y axes.
        /// </summary>
        [TestMethod]
        public void CreateRotationXY()
        {
            var expected = new Matrix4(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateXY, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for 90° rotations about the x & z axes.
        /// </summary>
        [TestMethod]
        public void CreateRotationXZ()
        {
            var expected = new Matrix4(0, 0, 1, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateXZ, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for 90° rotations about the y & z axes.
        /// </summary>
        [TestMethod]
        public void CreateRotationYZ()
        {
            var expected = new Matrix4(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateYZ, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for 90° rotations about the x, y & z axes.
        /// </summary>
        [TestMethod]
        public void CreateRotationXYZ()
        {
            var expected = new Matrix4(0, 0, 1, 0, 0, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: RotateXYZ, scale: Unity);
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a scale factor of 1:4:9.
        /// </summary>
        [TestMethod]
        public void CreateScaling()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(), orientation: new Euler3f(), scale: new Vector3f(1, 4, 9));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a general transformation.
        /// </summary>
        [TestMethod]
        public void CreateTransformationGeneral()
        {
            var expected = new Matrix4(0, 0, 9, 0, 0, -9, 0, 0, 9, 0, 0, 0, 7, 11, 13, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(7, 11, 13), orientation: RotateXYZ, scale: new Vector3f(9, 9, 9));
            Matrix4Compare(expected, actual);
        }

        /// <summary>
        /// Get the transformation matrix for a simple translation.
        /// </summary>
        [TestMethod]
        public void CreateTranslation()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 5, 1);
            var actual = Maths.CreateTransformation(location: new Vector3f(2, 3, 5), orientation: new Euler3f(), scale: Unity);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get the view matrix for the default camera location.
        /// </summary>
        [TestMethod]
        public void CreateCameraView()
        {
            var expected = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, -2, 1);
            var actual = Maths.CreateCameraView(new Camera());
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get the view matrix for a general camera location.
        /// </summary>
        [TestMethod]
        public void CreateCameraViewGeneral()
        {
            var expected = new Matrix4(
                0.8479983f, -0.342783f, 0.404226f, 0,
                0, 0.7626922f, 0.6467617f, 0,
                -0.529999f, -0.5484528f, 0.6467617f, 0,
                0.9539982f, 1.139754f, -18.35186f, 1);
            var actual = Maths.CreateCameraView(new Camera
            {
                Position = new Vector3f(7, 11, 13),
                Focus = new Vector3f(2, 3, 5)
            });
            Matrix4Compare(expected, actual, 1e-5f);
        }

        /// <summary>
        /// Get the view matrix for an offset camera position.
        /// </summary>
        [TestMethod]
        public void CreateCameraViewPosition()
        {
            var expected = new Matrix4(
                -0.9284767f, -0.1807426f, -0.3244428f, 0,
                0, 0.8735891f, -0.4866643f, 0,
                0.3713907f, -0.4518564f, -0.8111071f, 0,
                -2.980232E-08f, 0, -6.164414f, 1);
            var actual = Maths.CreateCameraView(new Camera { Position = new Vector3f(-2, -3, -5) });
            Matrix4Compare(expected, actual);
        }

        private static readonly Vector3f Unity = new Vector3f(1, 1, 1);
        private static readonly Euler3f
            RotateX = new Euler3f(90, 0, 0),
            RotateY = new Euler3f(0, 90, 0),
            RotateZ = new Euler3f(0, 0, 90),
            RotateXY = new Euler3f(90, 90, 0),
            RotateXZ = new Euler3f(90, 0, 90),
            RotateYZ = new Euler3f(0, 90, 90),
            RotateXYZ = new Euler3f(90, 90, 90);

        private static void Matrix4Compare(Matrix4 expected, Matrix4 actual, float delta = 1e-6f)
        {
            for (var row = 0; row < 4; row++)
                for (var col = 0; col < 4; col++)
                    Assert.AreEqual(expected[row, col], actual[row, col], delta);
        }
    }
}
