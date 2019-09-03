namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class ColourFormatTests
    {
        /// <summary>
        /// Check that the ColourFormat copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void ColourFormatCopy()
        {
            var p = new ColourFormat(1, 2, 3, 4);
            var q = new ColourFormat(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void ColourFormatEquality()
        {
            var p = new ColourFormat(1, 2, 3, 4);
            var q = new ColourFormat(1, 2, 3, 4);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void ColourFormatInequality()
        {
            ColourFormatInequality(1, 2, 3, 4, 8, 2, 3, 4);
            ColourFormatInequality(1, 2, 3, 4, 1, 8, 3, 4);
            ColourFormatInequality(1, 2, 3, 4, 1, 2, 8, 4);
            ColourFormatInequality(1, 2, 3, 4, 1, 2, 3, 8);
        }

        private static void ColourFormatInequality(params int[] a)
        {
            var p = new ColourFormat(a[0], a[1], a[2], a[3]);
            var q = new ColourFormat(a[4], a[5], a[6], a[7]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}