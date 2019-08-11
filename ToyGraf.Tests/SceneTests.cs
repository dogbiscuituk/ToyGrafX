namespace ToyGraf.Tests
{
    using System.Reflection;
    using ToyGraf.Models;

    public class SceneTests
    {
        public void foo()
        {
            var scene1 = new Scene();
            var scene2 = scene1.Clone();
            var properties = typeof(Scene).GetProperties(BindingFlags.Public);
            foreach (var property in properties)
            {
            }
        }
    }
}
