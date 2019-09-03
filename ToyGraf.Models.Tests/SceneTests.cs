namespace ToyGraf.Tests
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
            Assert.AreEqual(scene.BackgroundColour, Scene.Defaults.BackgroundColour);
            Assert.AreEqual(scene.Camera, Scene.Defaults.Camera);
            Assert.AreEqual(scene.FPS, Scene.Defaults.FPS);
            Assert.AreEqual(scene.Projection, Scene.Defaults.Projection);
            Assert.AreEqual(scene.Shader1Vertex, Scene.Defaults.Shader1Vertex);
            Assert.AreEqual(scene.Shader2TessControl, Scene.Defaults.Shader2TessControl);
            Assert.AreEqual(scene.Shader3TessEvaluation, Scene.Defaults.Shader3TessEvaluation);
            Assert.AreEqual(scene.Shader4Geometry, Scene.Defaults.Shader4Geometry);
            Assert.AreEqual(scene.Shader5Fragment, Scene.Defaults.Shader5Fragment);
            Assert.AreEqual(scene.Shader6Compute, Scene.Defaults.Shader6Compute);
            Assert.AreEqual(scene.Title, Scene.Defaults.Title);
            Assert.AreEqual(scene.VSync, Scene.Defaults.VSync);
        }
    }
}
