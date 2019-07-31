namespace ToyGraf.Shaders
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Linq;
    using System.Text;
    using ToyGraf.Controllers;
    using ToyGraf.Engine.Shaders;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;

    public class TraceShader : Shader
    {
        #region Public Interface

        public TraceShader(Trace trace) : base() => Trace = trace;

        public override string CreateProgram()
        {
            MakeCurrent(true);
            var log = base.CreateProgram();
            MakeCurrent(false);
            Trace._ShaderStatus = log.ToStringArray(StringSplitOptions.RemoveEmptyEntries);
            return log;
        }

        #endregion

        #region Non-Public Properties

        private GLControlRenderer Renderer => SceneController.Renderer;
        private Scene Scene => Trace.Scene;
        private SceneController SceneController => Scene.SceneController;
        private readonly Trace Trace;

        #endregion

        #region Non-Public Methods

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        protected override string GetScript(ShaderType shaderType)
        {
            var script = Trace.GetScript(shaderType);
            return script == null || script.Length < 1
                ? string.Empty
                : script.Aggregate((s, t) => $@"{s}\n{t}");
        }

        private void MakeCurrent(bool current) => Renderer.MakeCurrent(current);

        #endregion

        protected override void Dispose(bool disposing)
        {
            MakeCurrent(true);
            base.Dispose(disposing);
            MakeCurrent(false);
        }
    }
}
