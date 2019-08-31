namespace ToyGraf.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    /// <summary>
    /// Test the provided operators on the simple support types.
    /// </summary>
    [TestClass]
    public class OperatorTests
    {
        #region Copy Constructors

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
        /// Check that the Euler3f copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyEuler3f()
        {
            var p = new Euler3f(1, 2, 3);
            var q = new Euler3f(p);
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

        /// <summary>
        /// Check that the Vector3f copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyVector3f()
        {
            var p = new Vector3f(1, 2, 3);
            var q = new Vector3f(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Check that the Vector3i copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void CopyVector3i()
        {
            var p = new Vector3i(1, 2, 3);
            var q = new Vector3i(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        #endregion

        #region Equality

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
        public void EqualEuler3f()
        {
            var p = new Euler3f(1, 2, 3);
            var q = new Euler3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualProjection()
        {
            var p = new Projection(ProjectionType.Perspective, 1, new Vector3f(2, 3, 4), new Vector3f(5, 6, 7));
            var q = new Projection(ProjectionType.Perspective, 1, new Vector3f(2, 3, 4), new Vector3f(5, 6, 7));
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualVector3f()
        {
            var p = new Vector3f(1, 2, 3);
            var q = new Vector3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void EqualVector3i()
        {
            var p = new Vector3i(1, 2, 3);
            var q = new Vector3i(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        #endregion

        #region Inequality

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
        public void UnequalEuler3f()
        {
            UnequalEuler3f(1, 2, 3, 99, 2, 3);
            UnequalEuler3f(1, 2, 3, 1, 99, 3);
            UnequalEuler3f(1, 2, 3, 1, 2, 99);
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

        [TestMethod]
        public void UnequalVector3f()
        {
            UnequalVector3f(1, 2, 3, 99, 2, 3);
            UnequalVector3f(1, 2, 3, 1, 99, 3);
            UnequalVector3f(1, 2, 3, 1, 2, 99);
        }

        [TestMethod]
        public void UnequalVector3i()
        {
            UnequalVector3i(1, 2, 3, 99, 2, 3);
            UnequalVector3i(1, 2, 3, 1, 99, 3);
            UnequalVector3i(1, 2, 3, 1, 2, 99);
        }

        #endregion

        #region Other Operators

        #region Euler3f

        [TestMethod]
        public void Euler3fAdd()
        {
            Euler3f
                expected = new Euler3f(3, 6, 9),
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(2, 4, 6),
                actual = p + q;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euler3fNegate()
        {
            Euler3f
                expected = new Euler3f(-1, -2, -3),
                p = new Euler3f(1, 2, 3),
                actual = -p;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euler3fSubtract()
        {
            Euler3f
                expected = new Euler3f(-1, -2, -3),
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(2, 4, 6),
                actual = p - q;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Vector3f

        [TestMethod]
        public void Vector3fAdd()
        {
            Vector3f
                expected = new Vector3f(3, 6, 9),
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(2, 4, 6),
                actual = p + q;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fNegate()
        {
            Vector3f
                expected = new Vector3f(-1, -2, -3),
                p = new Vector3f(1, 2, 3),
                actual = -p;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fSubtract()
        {
            Vector3f
                expected = new Vector3f(-1, -2, -3),
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(2, 4, 6),
                actual = p - q;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Vector3i

        [TestMethod]
        public void Vector3iAdd()
        {
            Vector3i
                expected = new Vector3i(3, 6, 9),
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 4, 6),
                actual = p + q;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iNegate()
        {
            Vector3i
                expected = new Vector3i(-1, -2, -3),
                p = new Vector3i(1, 2, 3),
                actual = -p;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iSubtract()
        {
            Vector3i
                expected = new Vector3i(-1, -2, -3),
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 4, 6),
                actual = p - q;
            Assert.AreEqual(expected, actual);
        }

        #endregion

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

        private void UnequalEuler3f(params float[] a)
        {
            var p = new Euler3f(a[0], a[1], a[2]);
            var q = new Euler3f(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalProjection(ProjectionType typeA, ProjectionType typeB, params float[] a)
        {
            var p = new Projection(typeA, a[0], new Vector3f(a[1], a[2], a[3]), new Vector3f(a[4], a[5], a[6]));
            var q = new Projection(typeB, a[7], new Vector3f(a[8], a[9], a[10]), new Vector3f(a[11], a[12], a[13]));
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalVector3f(params float[] a)
        {
            var p = new Vector3f(a[0], a[1], a[2]);
            var q = new Vector3f(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        private void UnequalVector3i(params int[] a)
        {
            var p = new Vector3i(a[0], a[1], a[2]);
            var q = new Vector3i(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}