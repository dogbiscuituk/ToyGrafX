namespace ToyGraf.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    /// <summary>
    /// Test the equality operators on the simple support types.
    /// </summary>
    [TestClass]
    public class OperatorTests
    {
        #region Public Test Methods

        /// <summary>
        /// Check that the Camera copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyCamera()
        {
            var p = new Camera(1, 2, 3, 4, 5, 6);
            var q = new Camera(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the ColourFormat copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyColourFormat()
        {
            var p = new ColourFormat(1, 2, 3, 4);
            var q = new ColourFormat(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the Euler3F copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyEuler3F()
        {
            var p = new Euler3F(1, 2, 3);
            var q = new Euler3F(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the Point3 copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyPoint3()
        {
            var p = new Point3(1, 2, 3);
            var q = new Point3(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the Point3F copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyPoint3F()
        {
            var p = new Point3F(1, 2, 3);
            var q = new Point3F(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the Projection copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyProjection()
        {
            var p = Projection.Parse("0, 1, 2, 3, 4, 5, 6, 7, 8");
            var q = new Projection(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void EqualCamera()
        {
            var p = new Camera(1, 2, 3, 4, 5, 6);
            var q = new Camera(1, 2, 3, 4, 5, 6);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualColourFormat()
        {
            var p = new ColourFormat(1, 2, 3, 4);
            var q = new ColourFormat(1, 2, 3, 4);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualEuler3F()
        {
            var p = new Euler3F(1, 2, 3);
            var q = new Euler3F(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualPoint3()
        {
            var p = new Point3(1, 2, 3);
            var q = new Point3(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualPoint3F()
        {
            var p = new Point3F(1, 2, 3);
            var q = new Point3F(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualProjection()
        {
            var p = new Projection(ProjectionType.Perspective, 1, new Point3F(2, 3, 4), new Point3F(5, 6, 7));
            var q = new Projection(ProjectionType.Perspective, 1, new Point3F(2, 3, 4), new Point3F(5, 6, 7));
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void UnequalCamera()
        {
            UnequalCamera(1, 2, 3, 4, 5, 6, 99, 2, 3, 4, 5, 6);
            UnequalCamera(1, 2, 3, 4, 5, 6, 1, 99, 3, 4, 5, 6);
            UnequalCamera(1, 2, 3, 4, 5, 6, 1, 2, 99, 4, 5, 6);
            UnequalCamera(1, 2, 3, 4, 5, 6, 1, 2, 3, 99, 5, 6);
            UnequalCamera(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 99, 6);
            UnequalCamera(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 99);
        }

        [TestMethod]
        public void UnequalColourFormat()
        {
            UnequalColourFormat(1, 2, 3, 4, 8, 2, 3, 4);
            UnequalColourFormat(1, 2, 3, 4, 1, 8, 3, 4);
            UnequalColourFormat(1, 2, 3, 4, 1, 2, 8, 4);
            UnequalColourFormat(1, 2, 3, 4, 1, 2, 3, 8);
        }

        [TestMethod]
        public void UnequalEuler3F()
        {
            UnequalEuler3F(1, 2, 3, 99, 2, 3);
            UnequalEuler3F(1, 2, 3, 1, 99, 3);
            UnequalEuler3F(1, 2, 3, 1, 2, 99);
        }

        [TestMethod]
        public void UnequalPoint3()
        {
            UnequalPoint3(1, 2, 3, 99, 2, 3);
            UnequalPoint3(1, 2, 3, 1, 99, 3);
            UnequalPoint3(1, 2, 3, 1, 2, 99);
        }

        [TestMethod]
        public void UnequalPoint3F()
        {
            UnequalPoint3F(1, 2, 3, 99, 2, 3);
            UnequalPoint3F(1, 2, 3, 1, 99, 3);
            UnequalPoint3F(1, 2, 3, 1, 2, 99);
        }

        [TestMethod]
        public void UnequalProjection()
        {
            var t = ProjectionType.Perspective;
            var t2 = ProjectionType.Orthographic;
            UnequalProjection(t, t2, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 99, 2, 3, 4, 5, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 99, 3, 4, 5, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 99, 4, 5, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 99, 5, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 99, 6, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 99, 7);
            UnequalProjection(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 99);
        }

        #endregion

        #region Private Helper Methods

        private void UnequalCamera(params float[] a)
        {
            var p = new Camera(a[0], a[1], a[2], a[3], a[4], a[5]);
            var q = new Camera(a[6], a[7], a[8], a[9], a[10], a[11]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalColourFormat(params int[] a)
        {
            var p = new ColourFormat(a[0], a[1], a[2], a[3]);
            var q = new ColourFormat(a[4], a[5], a[6], a[7]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalEuler3F(params float[] a)
        {
            var p = new Euler3F(a[0], a[1], a[2]);
            var q = new Euler3F(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalPoint3(params int[] a)
        {
            var p = new Point3F(a[0], a[1], a[2]);
            var q = new Point3F(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalPoint3F(params float[] a)
        {
            var p = new Point3F(a[0], a[1], a[2]);
            var q = new Point3F(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalProjection(ProjectionType typeA, ProjectionType typeB, params float[] a)
        {
            var p = new Projection(typeA, a[0], new Point3F(a[1], a[2], a[3]), new Point3F(a[4], a[5], a[6]));
            var q = new Projection(typeB, a[7], new Point3F(a[8], a[9], a[10]), new Point3F(a[11], a[12], a[13]));
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}