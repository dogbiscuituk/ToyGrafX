namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Common.Types;

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

        [TestMethod]
        public void Vector3iCross()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(2, 3, 4),
                actual = p.Cross(q),
                expected = new Vector3i(-1, 2, -1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void Vector3iCtorCopy()
        {
            Vector3i
                p = new Vector3i(1, 2, 3),
                q = new Vector3i(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Copy & Modify constructor.
        /// </summary>
        [TestMethod]
        public void Vector3iCtorCopyModify()
        {
            Vector3iCtorCopyModify(Vector3i.DisplayNames.X, 99, 3, 5);
            Vector3iCtorCopyModify(Vector3i.DisplayNames.Y, 2, 99, 5);
            Vector3iCtorCopyModify(Vector3i.DisplayNames.Z, 2, 3, 99);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        [TestMethod]
        public void Vector3iCtorDefault()
        {
            var p = new Vector3i();
            Assert.AreEqual(0, p.X);
            Assert.AreEqual(0, p.Y);
            Assert.AreEqual(0, p.Z);
        }

        /// <summary>
        /// General constructor.
        /// </summary>
        [TestMethod]
        public void Vector3iCtorGeneral()
        {
            var p = new Vector3i(2, 3, 5);
            Assert.AreEqual(2, p.X);
            Assert.AreEqual(3, p.Y);
            Assert.AreEqual(5, p.Z);
        }

        [TestMethod]
        public void Vector3iDot()
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
        public void Vector3iImplicitToVector3f()
        {
            var p = new Vector3i(2, 3, 5);
            Vector3f q = p;
            Assert.AreEqual(2, q.X);
            Assert.AreEqual(3, q.Y);
            Assert.AreEqual(5, q.Z);
        }

        [TestMethod]
        public void Vector3iInequality()
        {
            Vector3iInequality(99, 3, 5);
            Vector3iInequality(2, 99, 5);
            Vector3iInequality(2, 3, 99);
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
        public void Vector3iParse()
        {
            var p = Vector3i.Parse("+2,-3, 5 ");
            Assert.AreEqual(+2, p.X);
            Assert.AreEqual(-3, p.Y);
            Assert.AreEqual(+5, p.Z);
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

        private static void Vector3iCtorCopyModify(string field, params int[] expected)
        {
            var p = new Vector3i(2, 3, 5);
            p = new Vector3i(p, field, 99);
            Assert.AreEqual(expected[0], p.X);
            Assert.AreEqual(expected[1], p.Y);
            Assert.AreEqual(expected[2], p.Z);
        }

        private static void Vector3iInequality(params int[] a)
        {
            var p = new Vector3i(2, 3, 5);
            var q = new Vector3i(a[0], a[1], a[2]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}