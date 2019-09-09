namespace ToyGraf.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Engine.Types;
    using ToyGraf.Models;

    [TestClass]
    public class TraceTests
    {
        [TestMethod]
        public void TraceCreateCopy()
        {
            Trace
                source = new Trace
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
                target = new Trace(source);
            Assert.AreEqual(target.Description, source.Description);
            Assert.AreEqual(target.Location, source.Location);
            Assert.AreEqual(target.Maximum, source.Maximum);
            Assert.AreEqual(target.Minimum, source.Minimum);
            Assert.AreEqual(target.Orientation, source.Orientation);
            Assert.AreEqual(target.Pattern, source.Pattern);
            Assert.AreEqual(target.Scale, source.Scale);
            Assert.AreEqual(target.Shader1Vertex, source.Shader1Vertex);
            Assert.AreEqual(target.Shader2TessControl, source.Shader2TessControl);
            Assert.AreEqual(target.Shader3TessEvaluation, source.Shader3TessEvaluation);
            Assert.AreEqual(target.Shader4Geometry, source.Shader4Geometry);
            Assert.AreEqual(target.Shader5Fragment, source.Shader5Fragment);
            Assert.AreEqual(target.Shader6Compute, source.Shader6Compute);
            Assert.AreEqual(target.StripCount, source.StripCount);
            Assert.AreEqual(target.Visible, source.Visible);
            Assert.IsFalse(ReferenceEquals(target, source));
        }

        [TestMethod]
        public void TraceCreateDefault()
        {
            var trace = new Trace();
            Assert.AreEqual(trace.Description, Trace.Defaults.Description);
            Assert.AreEqual(trace.Location, Trace.Defaults.Location);
            Assert.AreEqual(trace.Maximum, Trace.Defaults.Maximum);
            Assert.AreEqual(trace.Minimum, Trace.Defaults.Minimum);
            Assert.AreEqual(trace.Orientation, Trace.Defaults.Orientation);
            Assert.AreEqual(trace.Pattern, Trace.Defaults.Pattern);
            Assert.AreEqual(trace.Scale, Trace.Defaults.Scale);
            Assert.AreEqual(trace.Shader1Vertex, Trace.Defaults.Shader1Vertex);
            Assert.AreEqual(trace.Shader2TessControl, Trace.Defaults.Shader2TessControl);
            Assert.AreEqual(trace.Shader3TessEvaluation, Trace.Defaults.Shader3TessEvaluation);
            Assert.AreEqual(trace.Shader4Geometry, Trace.Defaults.Shader4Geometry);
            Assert.AreEqual(trace.Shader5Fragment, Trace.Defaults.Shader5Fragment);
            Assert.AreEqual(trace.Shader6Compute, Trace.Defaults.Shader6Compute);
            Assert.AreEqual(trace.StripCount, Trace.Defaults.StripCount);
            Assert.AreEqual(trace.Visible, Trace.Defaults.Visible);
        }
    }
}
