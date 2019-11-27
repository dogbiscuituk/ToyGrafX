namespace ToyGraf.Models.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Common.Types;
    using ToyGraf.Models;

    [TestClass]
    public class TraceTests
    {
        [TestMethod]
        public void TraceCreateCopy()
        {
            Trace
                p = new Trace
                {
                    Description = "Test trace",
                    Location = new Vector3f(1, 2, 3),
                    Maximum = new Vector3f(4, 5, 6),
                    Minimum = new Vector3f(-7, -8, -9),
                    Orientation = new Euler3f(10, 11, 12),
                    Pattern = Pattern.Saltires,
                    Scale = new Vector3f(13, 14, 15),
                    Shader1Vertex = "/* Vertex Shader */",
                    Shader2TessControl = "/* Tessellation Control Shader */",
                    Shader3TessEvaluation = "/* Tessellation Evaluation Shader */",
                    Shader4Geometry = "/* Geometry Shader */",
                    Shader5Fragment = "/* Fragment Shader */",
                    Shader6Compute = "/* Compute Shader */",
                    StripCount = new Vector3i(16, 17, 18),
                    Visible = false
                },
                q = new Trace(p);
            Assert.AreEqual(p.Description, q.Description);
            Assert.AreEqual(p.Location, q.Location);
            Assert.AreEqual(p.Maximum, q.Maximum);
            Assert.AreEqual(p.Minimum, q.Minimum);
            Assert.AreEqual(p.Orientation, q.Orientation);
            Assert.AreEqual(p.Pattern, q.Pattern);
            Assert.AreEqual(p.Scale, q.Scale);
            Assert.AreEqual(p.Shader1Vertex, q.Shader1Vertex);
            Assert.AreEqual(p.Shader2TessControl, q.Shader2TessControl);
            Assert.AreEqual(p.Shader3TessEvaluation, q.Shader3TessEvaluation);
            Assert.AreEqual(p.Shader4Geometry, q.Shader4Geometry);
            Assert.AreEqual(p.Shader5Fragment, q.Shader5Fragment);
            Assert.AreEqual(p.Shader6Compute, q.Shader6Compute);
            Assert.AreEqual(p.StripCount, q.StripCount);
            Assert.AreEqual(p.Visible, q.Visible);
            Assert.IsFalse(ReferenceEquals(p, q));
        }

        [TestMethod]
        public void TraceCreateDefault()
        {
            var p = new Trace();
            Assert.AreEqual(Trace.Defaults.Description, p.Description);
            Assert.AreEqual(Trace.Defaults.Location, p.Location);
            Assert.AreEqual(Trace.Defaults.Maximum, p.Maximum);
            Assert.AreEqual(Trace.Defaults.Minimum, p.Minimum);
            Assert.AreEqual(Trace.Defaults.Orientation, p.Orientation);
            Assert.AreEqual(Trace.Defaults.Pattern, p.Pattern);
            Assert.AreEqual(Trace.Defaults.Scale, p.Scale);
            Assert.AreEqual(Trace.Defaults.StripCount, p.StripCount);
            Assert.AreEqual(Trace.Defaults.Visible, p.Visible);
        }
    }
}
