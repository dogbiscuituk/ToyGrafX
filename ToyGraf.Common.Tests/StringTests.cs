namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Common.Utility;

    [TestClass]
    public class StringTests
    {
        #region Test Methods

        [TestMethod]
        public void StringGetLineCount()
        {
            StringGetLineCount(null, 0);
            StringGetLineCount(string.Empty, 0);
            StringGetLineCount(" ", 1);
            StringGetLineCount("\n", 2);
            StringGetLineCount("\n\n", 3);
            StringGetLineCount("1\n\n3", 3);
            StringGetLineCount("1\n2\n3", 3);
            StringGetLineCount("One\nTwo\nThree", 3);
            StringGetLineCount("1\n2\n3\n4\n5\n6\n7\n8\n9\n10", 10);
            StringGetLineCount("One\nTwo\nThree\nFour\nFive\nSix\nSeven\nEight\nNine\nTen", 10);
            StringGetLineCount("\nOne\nTwo\nThree\nFour\nFive\nSix\nSeven\nEight\nNine\nTen\n", 12);
            StringGetLineCount("\n\n\nOne\nTwo\nThree\nFour\nFive\nSix\nSeven\nEight\nNine\nTen\n\n\n", 16);
        }

        #endregion

        #region Private Static Helper Methods

        private void StringGetLineCount(string s, int expected) =>
            Assert.AreEqual(expected, s.GetLineCount());

        #endregion
    }
}
