namespace ToyGraf.Engine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;

    [TestClass]
    public class ProjectionTests
    {
        /// <summary>
        /// Check that the Projection copy constructor yields a result equal to the original,
        /// but having a different reference.
        /// </summary>
        [TestMethod]
        public void ProjectionCopy()
        {
            var p = Projection.Parse("0, 1, 2, 3, 4, 5, 6, 7, 8");
            var q = new Projection(p);
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void ProjectionEquality()
        {
            var p = new Projection(ProjectionType.Perspective, 1, new Vector3f(2, 3, 4), new Vector3f(5, 6, 7));
            var q = new Projection(ProjectionType.Perspective, 1, new Vector3f(2, 3, 4), new Vector3f(5, 6, 7));
            Assert.IsTrue(p.Equals(q));
            Assert.IsTrue(p == q);
            Assert.IsFalse(p != q);
        }

        [TestMethod]
        public void ProjectionInequality()
        {
            var t = ProjectionType.Perspective;
            var t2 = ProjectionType.Orthographic;
            ProjectionInequality(t, t2, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 99, 2, 3, 4, 5, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 99, 3, 4, 5, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 99, 4, 5, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 99, 5, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 99, 6, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 99, 7);
            ProjectionInequality(t, t, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 99);
        }

        private static void ProjectionInequality(ProjectionType typeA, ProjectionType typeB, params float[] a)
        {
            var p = new Projection(typeA, a[0], new Vector3f(a[1], a[2], a[3]), new Vector3f(a[4], a[5], a[6]));
            var q = new Projection(typeB, a[7], new Vector3f(a[8], a[9], a[10]), new Vector3f(a[11], a[12], a[13]));
            Assert.IsFalse(p.Equals(q));
            Assert.IsFalse(p == q);
            Assert.IsTrue(p != q);
        }
    }
}