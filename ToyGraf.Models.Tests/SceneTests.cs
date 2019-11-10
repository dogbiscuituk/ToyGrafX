namespace ToyGraf.Models.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToyGraf.Models;

    [TestClass]
    public class SceneTests
    {
        [TestMethod]
        public void SceneCreateDefault()
        {
            var scene = new Scene();
            Assert.AreEqual(Scene.Defaults.BackgroundColour, scene.BackgroundColour);
            Assert.AreEqual(Scene.Defaults.Camera, scene.Camera);
            Assert.AreEqual(Scene.Defaults.FPS, scene.FPS);
            Assert.AreEqual(Scene.Defaults.Projection, scene.Projection);
            Assert.AreEqual(Scene.Defaults.Shader1Vertex, scene.Shader1Vertex);
            Assert.AreEqual(Scene.Defaults.Shader2TessControl, scene.Shader2TessControl);
            Assert.AreEqual(Scene.Defaults.Shader3TessEvaluation, scene.Shader3TessEvaluation);
            Assert.AreEqual(Scene.Defaults.Shader4Geometry, scene.Shader4Geometry);
            Assert.AreEqual(Scene.Defaults.Shader5Fragment, scene.Shader5Fragment);
            Assert.AreEqual(Scene.Defaults.Shader6Compute, scene.Shader6Compute);
            Assert.AreEqual(Scene.Defaults.Title, scene.Title);
            Assert.AreEqual(0, scene.Traces.Count);
            Assert.AreEqual(Scene.Defaults.VSync, scene.VSync);
        }
    }
}
