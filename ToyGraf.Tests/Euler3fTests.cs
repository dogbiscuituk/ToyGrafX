namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class Euler3fTests
    {
        #region Test Methods

        [TestMethod]
        public void Euler3fAdd()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(2, 4, 6),
                actual = p + q,
                expected = new Euler3f(3, 6, 9);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void Euler3fCtorCopy()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Copy & Modify constructor.
        /// </summary>
        [TestMethod]
        public void Euler3fCtorCopyModify()
        {
            Euler3fCtorCopyModify(Euler3f.DisplayNames.Pitch, 99, 3, 5);
            Euler3fCtorCopyModify(Euler3f.DisplayNames.Yaw, 2, 99, 5);
            Euler3fCtorCopyModify(Euler3f.DisplayNames.Roll, 2, 3, 99);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        [TestMethod]
        public void Euler3fCtorDefault()
        {
            var p = new Euler3f();
            Assert.AreEqual(0, p.Pitch);
            Assert.AreEqual(0, p.Yaw);
            Assert.AreEqual(0, p.Roll);
        }

        /// <summary>
        /// General constructor.
        /// </summary>
        [TestMethod]
        public void Euler3fCtorGeneral()
        {
            var p = new Euler3f(2, 3, 5);
            Assert.AreEqual(2, p.Pitch);
            Assert.AreEqual(3, p.Yaw);
            Assert.AreEqual(5, p.Roll);
        }

        [TestMethod]
        public void Euler3fDivide()
        {
            Euler3f
                p = new Euler3f(10, 20, 30),
                actual = p / 2.5f,
                expected = new Euler3f(4, 8, 12);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Euler3fEquality()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void Euler3fInequality()
        {
            Euler3fInequality(99, 2, 3);
            Euler3fInequality(1, 99, 3);
            Euler3fInequality(1, 2, 99);
        }

        [TestMethod]
        public void Euler3fMultiplyLeft()
        {
            Euler3f
                p = new Euler3f(2, 4, 6),
                actual = 2.5f * p,
                expected = new Euler3f(5, 10, 15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euler3fMultiplyRight()
        {
            Euler3f
                p = new Euler3f(4, 0, 8),
                actual = p * 1.25f,
                expected = new Euler3f(5, 0, 10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euler3fNegate()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                actual = -p,
                expected = new Euler3f(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euler3fParse()
        {
            var p = Euler3f.Parse("+2.5,-3.75, 0.5875e1 ");
            Assert.AreEqual(2.5f, p.Pitch);
            Assert.AreEqual(-3.75f, p.Yaw);
            Assert.AreEqual(5.875f, p.Roll);
        }

        [TestMethod]
        public void Euler3fSubtract()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(2, 4, 6),
                actual = p - q,
                expected = new Euler3f(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Private Static Helper Methods

        private static void Euler3fCtorCopyModify(string field, params float[] expected)
        {
            var p = new Euler3f(2, 3, 5);
            p = new Euler3f(p, field, 99);
            Assert.AreEqual(expected[0], p.Pitch);
            Assert.AreEqual(expected[1], p.Yaw);
            Assert.AreEqual(expected[2], p.Roll);
        }

        private static void Euler3fInequality(params float[] a)
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(a[0], a[1], a[2]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}