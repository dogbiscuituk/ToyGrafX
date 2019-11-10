namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenTK;
    using ToyGraf.Common.Types;

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

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void Vector3fCtorCopy()
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
        /// Copy & Modify constructor.
        /// </summary>
        [TestMethod]
        public void Vector3fCtorCopyModify()
        {
            Vector3fCtorCopyModify(Vector3f.DisplayNames.X, 99, 3, 5);
            Vector3fCtorCopyModify(Vector3f.DisplayNames.Y, 2, 99, 5);
            Vector3fCtorCopyModify(Vector3f.DisplayNames.Z, 2, 3, 99);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        [TestMethod]
        public void Vector3fCtorDefault()
        {
            var p = new Vector3f();
            Assert.AreEqual(0, p.X);
            Assert.AreEqual(0, p.Y);
            Assert.AreEqual(0, p.Z);
        }

        /// <summary>
        /// General constructor.
        /// </summary>
        [TestMethod]
        public void Vector3fCtorGeneral()
        {
            var p = new Vector3f(2, 3, 5);
            Assert.AreEqual(2, p.X);
            Assert.AreEqual(3, p.Y);
            Assert.AreEqual(5, p.Z);
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
        public void Vector3fImplicitFromVector3()
        {
            var p = new Vector3(2, 3, 5);
            Vector3f q = p;
            Assert.AreEqual(2, q.X);
            Assert.AreEqual(3, q.Y);
            Assert.AreEqual(5, q.Z);
        }

        [TestMethod]
        public void Vector3fImplicitToVector3()
        {
            var p = new Vector3f(2, 3, 5);
            Vector3 q = p;
            Assert.AreEqual(2, q.X);
            Assert.AreEqual(3, q.Y);
            Assert.AreEqual(5, q.Z);
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
        public void Vector3fNormalize()
        {
            Vector3f
                actual = new Vector3f(2, 3, 5).Normalize(),
                expected = new Vector3f(0.3244428f, 0.4866643f, 0.8111071f);
            Vector3fCompare(expected, actual);
        }

        [TestMethod]
        public void Vector3fParse()
        {
            var p = Vector3f.Parse("+2.5,-3.75, 0.5875e1 ");
            Assert.AreEqual(2.5f, p.X);
            Assert.AreEqual(-3.75f, p.Y);
            Assert.AreEqual(5.875f, p.Z);
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

        private static void Vector3fCompare(Vector3f expected, Vector3f actual, float delta = 1e-7f)
        {
            Assert.AreEqual(expected.X, actual.X, delta);
            Assert.AreEqual(expected.Y, actual.Y, delta);
            Assert.AreEqual(expected.Z, actual.Z, delta);
        }

        private static void Vector3fCtorCopyModify(string field, params float[] expected)
        {
            var p = new Vector3f(2, 3, 5);
            p = new Vector3f(p, field, 99);
            Assert.AreEqual(expected[0], p.X);
            Assert.AreEqual(expected[1], p.Y);
            Assert.AreEqual(expected[2], p.Z);
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