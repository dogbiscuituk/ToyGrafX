namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class ColourFormatTests
    {
        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCreateCopy()
        {
            ColourFormat
                p = new ColourFormat(1, 2, 3, 4),
                q = new ColourFormat(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void ColourFormatEquality()
        {
            ColourFormat
                p = new ColourFormat(1, 2, 3, 4),
                q = new ColourFormat(1, 2, 3, 4);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void ColourFormatInequality()
        {
            ColourFormatInequality(8, 2, 3, 4);
            ColourFormatInequality(1, 8, 3, 4);
            ColourFormatInequality(1, 2, 8, 4);
            ColourFormatInequality(1, 2, 3, 8);
        }

        private static void ColourFormatInequality(params int[] a)
        {
            ColourFormat
                p = new ColourFormat(1, 2, 3, 4),
                q = new ColourFormat(a[0], a[1], a[2], a[3]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}