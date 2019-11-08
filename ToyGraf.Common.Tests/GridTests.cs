namespace ToyGraf.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Common.Types;

    [TestClass]
    public class GridTests
    {
        /// <summary>
        /// Check that the "empty" grid actually contains one point, namely the origin.
        /// </summary>
        [TestMethod]
        public void CheckGrid()
        {
            var expected = new float[] { 0, 0, 0 };
            var actual = Entity.GetCoordinates(0, 0, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 9 points dividing the x axis into 8 equal line segments.
        /// </summary>
        [TestMethod]
        public void CheckGridX()
        {
            var expected = new[]
            {
                -1.00f, 0, 0,
                -0.75f, 0, 0,
                -0.50f, 0, 0,
                -0.25f, 0, 0,
                +0.00f, 0, 0,
                +0.25f, 0, 0,
                +0.50f, 0, 0,
                +0.75f, 0, 0,
                +1.00f, 0, 0
            };
            var actual = Entity.GetCoordinates(cx: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 9 points dividing the y axis into 8 equal line segments.
        /// </summary>
        [TestMethod]
        public void CheckGridY()
        {
            var expected = new[]
            {
                0, -1.00f, 0,
                0, -0.75f, 0,
                0, -0.50f, 0,
                0, -0.25f, 0,
                0, +0.00f, 0,
                0, +0.25f, 0,
                0, +0.50f, 0,
                0, +0.75f, 0,
                0, +1.00f, 0
            };
            var actual = Entity.GetCoordinates(cy: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 9 points dividing the z axis into 8 equal line segments.
        /// </summary>
        [TestMethod]
        public void CheckGridZ()
        {
            var expected = new[]
            {
                0, 0, -1.00f,
                0, 0, -0.75f,
                0, 0, -0.50f,
                0, 0, -0.25f,
                0, 0, +0.00f,
                0, 0, +0.25f,
                0, 0, +0.50f,
                0, 0, +0.75f,
                0, 0, +1.00f
            };
            var actual = Entity.GetCoordinates(cz: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 81 (9*9) points dividing the xy plane into an 8x8 grid.
        /// </summary>
        [TestMethod]
        public void CheckGridXY()
        {
            var expected = new[]
            {
                -1.00f, -1.00f, 0, -1.00f, -0.75f, 0, -1.00f, -0.50f, 0, -1.00f, -0.25f, 0, -1.00f, 0, 0,
                -1.00f, +0.25f, 0, -1.00f, +0.50f, 0, -1.00f, +0.75f, 0, -1.00f, +1.00f, 0,
                -0.75f, -1.00f, 0, -0.75f, -0.75f, 0, -0.75f, -0.50f, 0, -0.75f, -0.25f, 0, -0.75f, 0, 0,
                -0.75f, +0.25f, 0, -0.75f, +0.50f, 0, -0.75f, +0.75f, 0, -0.75f, +1.00f, 0,
                -0.50f, -1.00f, 0, -0.50f, -0.75f, 0, -0.50f, -0.50f, 0, -0.50f, -0.25f, 0, -0.50f, 0, 0,
                -0.50f, +0.25f, 0, -0.50f, +0.50f, 0, -0.50f, +0.75f, 0, -0.50f, +1.00f, 0,
                -0.25f, -1.00f, 0, -0.25f, -0.75f, 0, -0.25f, -0.50f, 0, -0.25f, -0.25f, 0, -0.25f, 0, 0,
                -0.25f, +0.25f, 0, -0.25f, +0.50f, 0, -0.25f, +0.75f, 0, -0.25f, +1.00f, 0,
                +0.00f, -1.00f, 0, +0.00f, -0.75f, 0, +0.00f, -0.50f, 0, +0.00f, -0.25f, 0, +0.00f, 0, 0,
                +0.00f, +0.25f, 0, +0.00f, +0.50f, 0, +0.00f, +0.75f, 0, +0.00f, +1.00f, 0,
                +0.25f, -1.00f, 0, +0.25f, -0.75f, 0, +0.25f, -0.50f, 0, +0.25f, -0.25f, 0, +0.25f, 0, 0,
                +0.25f, +0.25f, 0, +0.25f, +0.50f, 0, +0.25f, +0.75f, 0, +0.25f, +1.00f, 0,
                +0.50f, -1.00f, 0, +0.50f, -0.75f, 0, +0.50f, -0.50f, 0, +0.50f, -0.25f, 0, +0.50f, 0, 0,
                +0.50f, +0.25f, 0, +0.50f, +0.50f, 0, +0.50f, +0.75f, 0, +0.50f, +1.00f, 0,
                +0.75f, -1.00f, 0, +0.75f, -0.75f, 0, +0.75f, -0.50f, 0, +0.75f, -0.25f, 0, +0.75f, 0, 0,
                +0.75f, +0.25f, 0, +0.75f, +0.50f, 0, +0.75f, +0.75f, 0, +0.75f, +1.00f, 0,
                +1.00f, -1.00f, 0, +1.00f, -0.75f, 0, +1.00f, -0.50f, 0, +1.00f, -0.25f, 0, +1.00f, 0, 0,
                +1.00f, +0.25f, 0, +1.00f, +0.50f, 0, +1.00f, +0.75f, 0, +1.00f, +1.00f, 0
            };
            var actual = Entity.GetCoordinates(cx: 8, cy: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 81 (9*9) points dividing the xz plane into an 8x8 grid.
        /// </summary>
        [TestMethod]
        public void CheckGridXZ()
        {
            var expected = new[]
            {
                -1.00f, 0, -1.00f, -1.00f, 0, -0.75f, -1.00f, 0, -0.50f, -1.00f, 0, -0.25f, -1.00f, 0, 0,
                -1.00f, 0, +0.25f, -1.00f, 0, +0.50f, -1.00f, 0, +0.75f, -1.00f, 0, +1.00f,
                -0.75f, 0, -1.00f, -0.75f, 0, -0.75f, -0.75f, 0, -0.50f, -0.75f, 0, -0.25f, -0.75f, 0, 0,
                -0.75f, 0, +0.25f, -0.75f, 0, +0.50f, -0.75f, 0, +0.75f, -0.75f, 0, +1.00f,
                -0.50f, 0, -1.00f, -0.50f, 0, -0.75f, -0.50f, 0, -0.50f, -0.50f, 0, -0.25f, -0.50f, 0, 0,
                -0.50f, 0, +0.25f, -0.50f, 0, +0.50f, -0.50f, 0, +0.75f, -0.50f, 0, +1.00f,
                -0.25f, 0, -1.00f, -0.25f, 0, -0.75f, -0.25f, 0, -0.50f, -0.25f, 0, -0.25f, -0.25f, 0, 0,
                -0.25f, 0, +0.25f, -0.25f, 0, +0.50f, -0.25f, 0, +0.75f, -0.25f, 0, +1.00f,
                +0.00f, 0, -1.00f, +0.00f, 0, -0.75f, +0.00f, 0, -0.50f, +0.00f, 0, -0.25f, +0.00f, 0, 0,
                +0.00f, 0, +0.25f, +0.00f, 0, +0.50f, +0.00f, 0, +0.75f, +0.00f, 0, +1.00f,
                +0.25f, 0, -1.00f, +0.25f, 0, -0.75f, +0.25f, 0, -0.50f, +0.25f, 0, -0.25f, +0.25f, 0, 0,
                +0.25f, 0, +0.25f, +0.25f, 0, +0.50f, +0.25f, 0, +0.75f, +0.25f, 0, +1.00f,
                +0.50f, 0, -1.00f, +0.50f, 0, -0.75f, +0.50f, 0, -0.50f, +0.50f, 0, -0.25f, +0.50f, 0, 0,
                +0.50f, 0, +0.25f, +0.50f, 0, +0.50f, +0.50f, 0, +0.75f, +0.50f, 0, +1.00f,
                +0.75f, 0, -1.00f, +0.75f, 0, -0.75f, +0.75f, 0, -0.50f, +0.75f, 0, -0.25f, +0.75f, 0, 0,
                +0.75f, 0, +0.25f, +0.75f, 0, +0.50f, +0.75f, 0, +0.75f, +0.75f, 0, +1.00f,
                +1.00f, 0, -1.00f, +1.00f, 0, -0.75f, +1.00f, 0, -0.50f, +1.00f, 0, -0.25f, +1.00f, 0, 0,
                +1.00f, 0, +0.25f, +1.00f, 0, +0.50f, +1.00f, 0, +0.75f, +1.00f, 0, +1.00f
            };
            var actual = Entity.GetCoordinates(cx: 8, cz: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 81 (9*9) points dividing the yz plane into an 8x8 grid.
        /// </summary>
        [TestMethod]
        public void CheckGridYZ()
        {
            var expected = new[]
            {
                0, -1.00f, -1.00f, 0, -1.00f, -0.75f, 0, -1.00f, -0.50f, 0, -1.00f, -0.25f, 0, -1.00f, 0,
                0, -1.00f, +0.25f, 0, -1.00f, +0.50f, 0, -1.00f, +0.75f, 0, -1.00f, +1.00f,
                0, -0.75f, -1.00f, 0, -0.75f, -0.75f, 0, -0.75f, -0.50f, 0, -0.75f, -0.25f, 0, -0.75f, 0,
                0, -0.75f, +0.25f, 0, -0.75f, +0.50f, 0, -0.75f, +0.75f, 0, -0.75f, +1.00f,
                0, -0.50f, -1.00f, 0, -0.50f, -0.75f, 0, -0.50f, -0.50f, 0, -0.50f, -0.25f, 0, -0.50f, 0,
                0, -0.50f, +0.25f, 0, -0.50f, +0.50f, 0, -0.50f, +0.75f, 0, -0.50f, +1.00f,
                0, -0.25f, -1.00f, 0, -0.25f, -0.75f, 0, -0.25f, -0.50f, 0, -0.25f, -0.25f, 0, -0.25f, 0,
                0, -0.25f, +0.25f, 0, -0.25f, +0.50f, 0, -0.25f, +0.75f, 0, -0.25f, +1.00f,
                0, +0.00f, -1.00f, 0, +0.00f, -0.75f, 0, +0.00f, -0.50f, 0, +0.00f, -0.25f, 0, +0.00f, 0,
                0, +0.00f, +0.25f, 0, +0.00f, +0.50f, 0, +0.00f, +0.75f, 0, +0.00f, +1.00f,
                0, +0.25f, -1.00f, 0, +0.25f, -0.75f, 0, +0.25f, -0.50f, 0, +0.25f, -0.25f, 0, +0.25f, 0,
                0, +0.25f, +0.25f, 0, +0.25f, +0.50f, 0, +0.25f, +0.75f, 0, +0.25f, +1.00f,
                0, +0.50f, -1.00f, 0, +0.50f, -0.75f, 0, +0.50f, -0.50f, 0, +0.50f, -0.25f, 0, +0.50f, 0,
                0, +0.50f, +0.25f, 0, +0.50f, +0.50f, 0, +0.50f, +0.75f, 0, +0.50f, +1.00f,
                0, +0.75f, -1.00f, 0, +0.75f, -0.75f, 0, +0.75f, -0.50f, 0, +0.75f, -0.25f, 0, +0.75f, 0,
                0, +0.75f, +0.25f, 0, +0.75f, +0.50f, 0, +0.75f, +0.75f, 0, +0.75f, +1.00f,
                0, +1.00f, -1.00f, 0, +1.00f, -0.75f, 0, +1.00f, -0.50f, 0, +1.00f, -0.25f, 0, +1.00f, 0,
                0, +1.00f, +0.25f, 0, +1.00f, +0.50f, 0, +1.00f, +0.75f, 0, +1.00f, +1.00f
            };
            var actual = Entity.GetCoordinates(cy: 8, cz: 8);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 125 (5*5*5) points dividing the xyz space into a 4x4x4 lattice.
        /// </summary>
        [TestMethod]
        public void CheckGridXYZ()
        {
            var expected = new[]
            {
                -1, -1.0f, -1, -1, -1.0f, -.5f, -1, -1.0f, 0, -1, -1.0f, .5f, -1, -1.0f, 1,
                -1, -0.5f, -1, -1, -0.5f, -.5f, -1, -0.5f, 0, -1, -0.5f, .5f, -1, -0.5f, 1,
                -1, +0.0f, -1, -1, +0.0f, -.5f, -1, +0.0f, 0, -1, +0.0f, .5f, -1, +0.0f, 1,
                -1, +0.5f, -1, -1, +0.5f, -.5f, -1, +0.5f, 0, -1, +0.5f, .5f, -1, +0.5f, 1,
                -1, +1.0f, -1, -1, +1.0f, -.5f, -1, +1.0f, 0, -1, +1.0f, .5f, -1, +1.0f, 1,
                -.5f, -1.0f, -1, -.5f, -1.0f, -.5f, -.5f, -1.0f, 0, -.5f, -1.0f, .5f, -.5f, -1.0f, 1,
                -.5f, -0.5f, -1, -.5f, -0.5f, -.5f, -.5f, -0.5f, 0, -.5f, -0.5f, .5f, -.5f, -0.5f, 1,
                -.5f, +0.0f, -1, -.5f, +0.0f, -.5f, -.5f, +0.0f, 0, -.5f, +0.0f, .5f, -.5f, +0.0f, 1,
                -.5f, +0.5f, -1, -.5f, +0.5f, -.5f, -.5f, +0.5f, 0, -.5f, +0.5f, .5f, -.5f, +0.5f, 1,
                -.5f, +1.0f, -1, -.5f, +1.0f, -.5f, -.5f, +1.0f, 0, -.5f, +1.0f, .5f, -.5f, +1.0f, 1,
                0, -1.0f, -1, 0, -1.0f, -.5f, 0, -1.0f, 0, 0, -1.0f, .5f, 0, -1.0f, 1,
                0, -0.5f, -1, 0, -0.5f, -.5f, 0, -0.5f, 0, 0, -0.5f, .5f, 0, -0.5f, 1,
                0, +0.0f, -1, 0, +0.0f, -.5f, 0, +0.0f, 0, 0, +0.0f, .5f, 0, +0.0f, 1,
                0, +0.5f, -1, 0, +0.5f, -.5f, 0, +0.5f, 0, 0, +0.5f, .5f, 0, +0.5f, 1,
                0, +1.0f, -1, 0, +1.0f, -.5f, 0, +1.0f, 0, 0, +1.0f, .5f, 0, +1.0f, 1,
                .5f, -1.0f, -1, .5f, -1.0f, -.5f, .5f, -1.0f, 0, .5f, -1.0f, .5f, .5f, -1.0f, 1,
                .5f, -0.5f, -1, .5f, -0.5f, -.5f, .5f, -0.5f, 0, .5f, -0.5f, .5f, .5f, -0.5f, 1,
                .5f, +0.0f, -1, .5f, +0.0f, -.5f, .5f, +0.0f, 0, .5f, +0.0f, .5f, .5f, +0.0f, 1,
                .5f, +0.5f, -1, .5f, +0.5f, -.5f, .5f, +0.5f, 0, .5f, +0.5f, .5f, .5f, +0.5f, 1,
                .5f, +1.0f, -1, .5f, +1.0f, -.5f, .5f, +1.0f, 0, .5f, +1.0f, .5f, .5f, +1.0f, 1,
                1, -1.0f, -1, 1, -1.0f, -.5f, 1, -1.0f, 0, 1, -1.0f, .5f, 1, -1.0f, 1,
                1, -0.5f, -1, 1, -0.5f, -.5f, 1, -0.5f, 0, 1, -0.5f, .5f, 1, -0.5f, 1,
                1, +0.0f, -1, 1, +0.0f, -.5f, 1, +0.0f, 0, 1, +0.0f, .5f, 1, +0.0f, 1,
                1, +0.5f, -1, 1, +0.5f, -.5f, 1, +0.5f, 0, 1, +0.5f, .5f, 1, +0.5f, 1,
                1, +1.0f, -1, 1, +1.0f, -.5f, 1, +1.0f, 0, 1, +1.0f, .5f, 1, +1.0f, 1
            };
            var actual = Entity.GetCoordinates(4, 4, 4);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 3D coordinates of the 30 (2*5*3) points dividing the xyz space into a 1x4x2 lattice.
        /// </summary>
        [TestMethod]
        public void CheckGridXYZ2()
        {
            var expected = new[]
            {
                -1, -1.0f, -1, -1, -1.0f, 0, -1, -1.0f, 1, -1, -0.5f, -1, -1, -0.5f, 0, -1, -0.5f, 1,
                -1, +0.0f, -1, -1, +0.0f, 0, -1, +0.0f, 1, -1, +0.5f, -1, -1, +0.5f, 0, -1, +0.5f, 1,
                -1, +1.0f, -1, -1, +1.0f, 0, -1, +1.0f, 1, +1, -1.0f, -1, +1, -1.0f, 0, +1, -1.0f, 1,
                +1, -0.5f, -1, +1, -0.5f, 0, +1, -0.5f, 1, +1, +0.0f, -1, +1, +0.0f, 0, +1, +0.0f, 1,
                +1, +0.5f, -1, +1, +0.5f, 0, +1, +0.5f, 1, +1, +1.0f, -1, +1, +1.0f, 0, +1, +1.0f, 1
            };
            var actual = Entity.GetCoordinates(1, 4, 2);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check the 137 (1+8*(1+8*2)) vertex indices needed to cover with a single triangle strip,
        /// a plane partitioned by an 8x8 grid.
        /// </summary>
        [TestMethod]
        public void CheckTriangleStripIndices()
        {
            var expected = new int[]
            {
                00,
                09, 01, 10, 02, 11, 03, 12, 04, 13, 05, 14, 06, 15, 07, 16, 08, 17,
                26, 16, 25, 15, 24, 14, 23, 13, 22, 12, 21, 11, 20, 10, 19, 09, 18,
                27, 19, 28, 20, 29, 21, 30, 22, 31, 23, 32, 24, 33, 25, 34, 26, 35,
                44, 34, 43, 33, 42, 32, 41, 31, 40, 30, 39, 29, 38, 28, 37, 27, 36,
                45, 37, 46, 38, 47, 39, 48, 40, 49, 41, 50, 42, 51, 43, 52, 44, 53,
                62, 52, 61, 51, 60, 50, 59, 49, 58, 48, 57, 47, 56, 46, 55, 45, 54,
                63, 55, 64, 56, 65, 57, 66, 58, 67, 59, 68, 60, 69, 61, 70, 62, 71,
                80, 70, 79, 69, 78, 68, 77, 67, 76, 66, 75, 65, 74, 64, 73, 63, 72
            };
            var actual = Entity.GetIndices(Pattern.Fill, 8, 8);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
