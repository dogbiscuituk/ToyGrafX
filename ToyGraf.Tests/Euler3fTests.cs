namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class Euler3fTests
    {
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
        /// Check that the Euler3f copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void Euler3fCopy()
        {
            var p = new Euler3f(1, 2, 3);
            var q = new Euler3f(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void Euler3fEquality()
        {
            var p = new Euler3f(1, 2, 3);
            var q = new Euler3f(1, 2, 3);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void Euler3fInequality()
        {
            Euler3fInequality(1, 2, 3, 99, 2, 3);
            Euler3fInequality(1, 2, 3, 1, 99, 3);
            Euler3fInequality(1, 2, 3, 1, 2, 99);
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
        public void Euler3fSubtract()
        {
            Euler3f
                p = new Euler3f(1, 2, 3),
                q = new Euler3f(2, 4, 6),
                actual = p - q,
                expected = new Euler3f(-1, -2, -3);
            Assert.AreEqual(expected, actual);
        }

        private static void Euler3fInequality(params float[] a)
        {
            var p = new Euler3f(a[0], a[1], a[2]);
            var q = new Euler3f(a[3], a[4], a[5]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}