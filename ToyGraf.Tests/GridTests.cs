﻿namespace ToyGraf.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Utility;

    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestGetVertexCoords1D()
        {
            var actual = Grids.GetVertexCoords(8);
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
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetVertexCoords2D()
        {
            var actual = Grids.GetVertexCoords(8, 8);
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
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetVertexCoords3D()
        {
            var actual = Grids.GetVertexCoords(4, 4, 4);
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
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
