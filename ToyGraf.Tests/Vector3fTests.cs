namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class Vector3fTests
    {
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
        /// Check that the Vector3f copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void Vector3fCopy()
        {
            var p = new Vector3f(1, 2, 3);
            var q = new Vector3f(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void Vector3fCrossProduct()
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
        public void Vector3fDotProduct()
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
            var p = new Vector3f(1, 2, 3);
            var q = new Vector3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void Vector3fInequality()
        {
            Vector3fInequality(1, 2, 3, 99, 2, 3);
            Vector3fInequality(1, 2, 3, 1, 99, 3);
            Vector3fInequality(1, 2, 3, 1, 2, 99);
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

        private static void Vector3fInequality(params float[] a)
        {
            var p = new Vector3f(a[0], a[1], a[2]);
            var q = new Vector3f(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}