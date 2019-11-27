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
            Assert.AreEqual(Scene.Defaults.Title, scene.Title);
            Assert.AreEqual(0, scene.Traces.Count);
            Assert.AreEqual(Scene.Defaults.VSync, scene.VSync);
        }
    }
}
