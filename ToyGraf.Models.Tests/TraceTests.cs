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
            Assert.AreEqual(source.Description, target.Description);
            Assert.AreEqual(source.Location, target.Location);
            Assert.AreEqual(source.Maximum, target.Maximum);
            Assert.AreEqual(source.Minimum, target.Minimum);
            Assert.AreEqual(source.Orientation, target.Orientation);
            Assert.AreEqual(source.Pattern, target.Pattern);
            Assert.AreEqual(source.Scale, target.Scale);
            Assert.AreEqual(source.Shader1Vertex, target.Shader1Vertex);
            Assert.AreEqual(source.Shader2TessControl, target.Shader2TessControl);
            Assert.AreEqual(source.Shader3TessEvaluation, target.Shader3TessEvaluation);
            Assert.AreEqual(source.Shader4Geometry, target.Shader4Geometry);
            Assert.AreEqual(source.Shader5Fragment, target.Shader5Fragment);
            Assert.AreEqual(source.Shader6Compute, target.Shader6Compute);
            Assert.AreEqual(source.StripCount, target.StripCount);
            Assert.AreEqual(source.Visible, target.Visible);
            Assert.IsFalse(ReferenceEquals(source, target));
        }

        [TestMethod]
        public void TraceCreateDefault()
        {
            var trace = new Trace();
            Assert.AreEqual(Trace.Defaults.Description, trace.Description);
            Assert.AreEqual(Trace.Defaults.Location, trace.Location);
            Assert.AreEqual(Trace.Defaults.Maximum, trace.Maximum);
            Assert.AreEqual(Trace.Defaults.Minimum, trace.Minimum);
            Assert.AreEqual(Trace.Defaults.Orientation, trace.Orientation);
            Assert.AreEqual(Trace.Defaults.Pattern, trace.Pattern);
            Assert.AreEqual(Trace.Defaults.Scale, trace.Scale);
            Assert.AreEqual(Trace.Defaults.Shader1Vertex, trace.Shader1Vertex);
            Assert.AreEqual(Trace.Defaults.Shader2TessControl, trace.Shader2TessControl);
            Assert.AreEqual(Trace.Defaults.Shader3TessEvaluation, trace.Shader3TessEvaluation);
            Assert.AreEqual(Trace.Defaults.Shader4Geometry, trace.Shader4Geometry);
            Assert.AreEqual(Trace.Defaults.Shader5Fragment, trace.Shader5Fragment);
            Assert.AreEqual(Trace.Defaults.Shader6Compute, trace.Shader6Compute);
            Assert.AreEqual(Trace.Defaults.StripCount, trace.StripCount);
            Assert.AreEqual(Trace.Defaults.Visible, trace.Visible);
        }
    }
}
