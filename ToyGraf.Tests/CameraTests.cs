namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class CameraTests
    {
        /// <summary>
        /// Check that the Camera copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CameraCopy()
        {
            var p = new Camera(1, 2, 3, 4, 5, 6);
            var q = new Camera(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void CameraEquality()
        {
            var p = new Camera(1, 2, 3, 4, 5, 6);
            var q = new Camera(1, 2, 3, 4, 5, 6);
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

        private static void CameraInequality(params float[] a)
        {
            var p = new Camera(a[0], a[1], a[2], a[3], a[4], a[5]);
            var q = new Camera(a[6], a[7], a[8], a[9], a[10], a[11]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}