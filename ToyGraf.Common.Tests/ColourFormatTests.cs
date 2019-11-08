namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Common.Types;

    [TestClass]
    public class ColourFormatTests
    {
        #region Test Methods

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCtorCopy()
        {
            ColourFormat
                p = new ColourFormat(1, 2, 4, 8),
                q = new ColourFormat(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        /// <summary>
        /// Copy & Modify constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCtorCopyModify()
        {
            ColourFormatCtorCopyModify(ColourFormat.DisplayNames.Red, 0, 2, 4, 8);
            ColourFormatCtorCopyModify(ColourFormat.DisplayNames.Green, 1, 0, 4, 8);
            ColourFormatCtorCopyModify(ColourFormat.DisplayNames.Blue, 1, 2, 0, 8);
            ColourFormatCtorCopyModify(ColourFormat.DisplayNames.Alpha, 1, 2, 4, 0);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCtorDefault()
        {
            var p = new ColourFormat();
            Assert.AreEqual(0, p.Red);
            Assert.AreEqual(0, p.Green);
            Assert.AreEqual(0, p.Blue);
            Assert.AreEqual(0, p.Alpha);
        }

        /// <summary>
        /// General constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCtorGeneral()
        {
            var p = new ColourFormat(1, 2, 4, 8);
            Assert.AreEqual(1, p.Red);
            Assert.AreEqual(2, p.Green);
            Assert.AreEqual(4, p.Blue);
            Assert.AreEqual(8, p.Alpha);
        }

        /// <summary>
        /// Uniform constructor.
        /// </summary>
        [TestMethod]
        public void ColourFormatCtorUniform()
        {
            ColourFormatCtorUniform(1);
            ColourFormatCtorUniform(2);
            ColourFormatCtorUniform(4);
            ColourFormatCtorUniform(8);
        }

        [TestMethod]
        public void ColourFormatEquality()
        {
            ColourFormat
                p = new ColourFormat(1, 2, 4, 8),
                q = new ColourFormat(1, 2, 4, 8);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void ColourFormatInequality()
        {
            ColourFormatInequality(0, 2, 4, 8);
            ColourFormatInequality(1, 0, 4, 8);
            ColourFormatInequality(1, 2, 0, 8);
            ColourFormatInequality(1, 2, 4, 0);
        }

        #endregion

        #region Private Static Helper Methods

        private static void ColourFormatCtorCopyModify(string field, params int[] expected)
        {
            var p = new ColourFormat(1, 2, 4, 8);
            p = new ColourFormat(p, field, 0);
            Assert.AreEqual(expected[0], p.Red);
            Assert.AreEqual(expected[1], p.Green);
            Assert.AreEqual(expected[2], p.Blue);
            Assert.AreEqual(expected[3], p.Alpha);
        }

        private static void ColourFormatCtorUniform(int expected)
        {
            var p = new ColourFormat(expected);
            Assert.AreEqual(expected, p.Red);
            Assert.AreEqual(expected, p.Green);
            Assert.AreEqual(expected, p.Blue);
            Assert.AreEqual(expected, p.Alpha);
        }

        private static void ColourFormatInequality(params int[] a)
        {
            ColourFormat
                p = new ColourFormat(1, 2, 4, 8),
                q = new ColourFormat(a[0], a[1], a[2], a[3]);
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }

        #endregion
    }
}