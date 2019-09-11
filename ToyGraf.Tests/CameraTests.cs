namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class CameraTests
    {
        [TestMethod]
        public void CameraCreate1()
        {
            var p = new Camera();
            Assert.AreEqual(Camera.Defaults.Position.X, p.Position.X);
            Assert.AreEqual(Camera.Defaults.Position.Y, p.Position.Y);
            Assert.AreEqual(Camera.Defaults.Position.Z, p.Position.Z);
            Assert.AreEqual(Camera.Defaults.Focus.X, p.Focus.X);
            Assert.AreEqual(Camera.Defaults.Focus.Y, p.Focus.Y);
            Assert.AreEqual(Camera.Defaults.Focus.Z, p.Focus.Z);
        }

        [TestMethod]
        public void CameraCreate2()
        {
            var p = new Camera(new Vector3f(1, 2, 3), new Vector3f(4, 5, 6));
            Assert.AreEqual(1, p.Position.X);
            Assert.AreEqual(2, p.Position.Y);
            Assert.AreEqual(3, p.Position.Z);
            Assert.AreEqual(4, p.Focus.X);
            Assert.AreEqual(5, p.Focus.Y);
            Assert.AreEqual(6, p.Focus.Z);
        }

        [TestMethod]
        public void CameraCreate3()
        {
            var p = new Camera(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(1, p.Position.X);
            Assert.AreEqual(2, p.Position.Y);
            Assert.AreEqual(3, p.Position.Z);
            Assert.AreEqual(4, p.Focus.X);
            Assert.AreEqual(5, p.Focus.Y);
            Assert.AreEqual(6, p.Focus.Z);
        }

        /// <summary>
        /// Check that the Camera copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CameraCreate4()
        {
            Camera
                p = new Camera(1, 2, 3, 4, 5, 6),
                q = new Camera(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void CameraCreate5()
        {
            CameraCopy("Position.X", 99, 2, 3, 4, 5, 6);
            CameraCopy("Position.Y", 1, 99, 3, 4, 5, 6);
            CameraCopy("Position.Z", 1, 2, 99, 4, 5, 6);
            CameraCopy("Focus.X", 1, 2, 3, 99, 5, 6);
            CameraCopy("Focus.Y", 1, 2, 3, 4, 99, 6);
            CameraCopy("Focus.Z", 1, 2, 3, 4, 5, 99);
        }

        [TestMethod]
        public void CameraEquality()
        {
            Camera
                p = new Camera(1, 2, 3, 4, 5, 6),
                q = new Camera(1, 2, 3, 4, 5, 6);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void CameraInequality()
        {
            CameraInequality(1, 2, 3, 4, 5, 6, 99, 2, 3, 4, 5, 6);
            CameraInequality(1, 2, 3, 4, 5, 6, 1, 99, 3, 4, 5, 6);
            CameraInequality(1, 2, 3, 4, 5, 6, 1, 2, 99, 4, 5, 6);
            CameraInequality(1, 2, 3, 4, 5, 6, 1, 2, 3, 99, 5, 6);
            CameraInequality(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 99, 6);
            CameraInequality(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 99);
        }

        private static void CameraCopy(string field, params float[] a)
        {
            var p = new Camera(new Camera(1, 2, 3, 4, 5, 6), field, 99f);
            Assert.AreEqual(a[0], p.Position.X);
            Assert.AreEqual(a[1], p.Position.Y);
            Assert.AreEqual(a[2], p.Position.Z);
            Assert.AreEqual(a[3], p.Focus.X);
            Assert.AreEqual(a[4], p.Focus.Y);
            Assert.AreEqual(a[5], p.Focus.Z);

        }

        private static void CameraInequality(params float[] a)
        {
            Camera
                p = new Camera(a[0], a[1], a[2], a[3], a[4], a[5]),
                q = new Camera(a[6], a[7], a[8], a[9], a[10], a[11]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}