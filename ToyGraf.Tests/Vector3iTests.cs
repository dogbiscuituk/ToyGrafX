namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class Vector3iTests
    {
        #region Test Methods

        [TestMethod]
        public void Vector3iAdd()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 4, 6),
                actual = p + q,
                expected = new Vector3i(3, 6, 9);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check that the Vector3i copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void Vector3iCopy()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void Vector3iCrossProduct()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 3, 4),
                actual = p.Cross(q),
                expected = new Vector3i(-1, 2, -1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iDotProduct()
        {
            Vector3i
                p = new Vector3i(1, 4, 3),
                q = new Vector3i(2, 4, 16);
            int
                actual = p.Dot(q),
                expected = 66;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iEquality()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void Vector3iInequality()
        {
            Vector3iInequality(1, 2, 3, 99, 2, 3);
            Vector3iInequality(1, 2, 3, 1, 99, 3);
            Vector3iInequality(1, 2, 3, 1, 2, 99);
        }

        [TestMethod]
        public void Vector3iMultiplyLeft()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                actual = 2 * p,
                expected = new Vector3i(2, 4, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iMultiplyRight()
        {
            Vector3i
                p = new Vector3i(2, 3, 4),
                actual = p * 3,
                expected = new Vector3i(6, 9, 12);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iNegate()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                actual = -p,
                expected = new Vector3i(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iNorm()
        {
            var p = new Vector3i(5, 12, 84);
            float
                actual = p.Norm,
                expected = 85;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3iSubtract()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 4, 6),
                actual = p - q,
                expected = new Vector3i(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Private Static Helper Methods

        private static void Vector3iInequality(params int[] a)
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