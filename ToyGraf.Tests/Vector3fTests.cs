namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class Vector3fTests
    {
        #region Test Methods

        [TestMethod]
        public void Vector3fAdd()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(2, 4, 6),
                actual = p + q,
                expected = new Vector3f(3, 6, 9);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void Vector3fCreateCopy()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Copy+Modify constructor.
        /// </summary>
        public void Vector3fCreateCopyModify()
        {
            Vector3fCreateCopyModify("X", 99, 3, 5);
            Vector3fCreateCopyModify("Y", 2, 99, 5);
            Vector3fCreateCopyModify("Z", 2, 3, 99);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public void Vector3fCreateDefault()
        {
            var p = new Vector3f();
            Assert.AreEqual(0, p.X);
            Assert.AreEqual(0, p.Y);
            Assert.AreEqual(0, p.Z);
        }

        /// <summary>
        /// General constructor.
        /// </summary>
        public void Vector3fCreateGeneral()
        {
            var p = new Vector3f(2, 3, 5);
            Assert.AreEqual(2, p.X);
            Assert.AreEqual(3, p.Y);
            Assert.AreEqual(5, p.Z);
        }

        [TestMethod]
        public void Vector3fCross()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(2, 3, 4),
                actual = p.Cross(q),
                expected = new Vector3f(-1, 2, -1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fDivide()
        {
            Vector3f
                p = new Vector3f(10, 20, 30),
                actual = p / 2.5f,
                expected = new Vector3f(4, 8, 12);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fDot()
        {
            Vector3f
                p = new Vector3f(1.5f, 4, 3.125f),
                q = new Vector3f(2, 4.25f, 16);
            float
                actual = p.Dot(q),
                expected = 70;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fEquality()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void Vector3fInequality()
        {
            Vector3fInequality(99, 3, 5);
            Vector3fInequality(2, 99, 5);
            Vector3fInequality(2, 3, 99);
        }

        [TestMethod]
        public void Vector3fMultiplyLeft()
        {
            Vector3f
                p = new Vector3f(2, 4, 6),
                actual = 2.5f * p,
                expected = new Vector3f(5, 10, 15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fMultiplyRight()
        {
            Vector3f
                p = new Vector3f(4, 0, 8),
                actual = p * 1.25f,
                expected = new Vector3f(5, 0, 10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fNegate()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                actual = -p,
                expected = new Vector3f(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fNorm()
        {
            Vector3f p = new Vector3f(3, 4, 12);
            float
                actual = p.Norm,
                expected = 13;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3fSubtract()
        {
            Vector3f
                p = new Vector3f(1, 2, 3),
                q = new Vector3f(2, 4, 6),
                actual = p - q,
                expected = new Vector3f(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Private Static Helper Methods

        private static void Vector3fCreateCopyModify(string field, params float[] a)
        {
            var p = new Vector3f(2, 3, 5);
            p = new Vector3f(p, field, 99);
            Assert.AreEqual(p.X, a[0]);
            Assert.AreEqual(p.Y, a[1]);
            Assert.AreEqual(p.Z, a[2]);
        }

        private static void Vector3fInequality(params float[] a)
        {
            var p = new Vector3f(2, 3, 5);
            var q = new Vector3f(a[0], a[1], a[1]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}