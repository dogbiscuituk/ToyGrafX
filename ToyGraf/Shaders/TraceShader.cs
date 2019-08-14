namespace ToyGraf.Shaders
{
    using OpenTK.Graphics.OpenGL;
    using ToyGraf.Controllers;
    using ToyGraf.Engine;
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
            Trace._GPUStatus = log;
            return log;
        }

        #endregion

        #region Non-Public Properties

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

        protected override string GetScript(ShaderType shaderType) => Trace.GetScript(shaderType);

        private void MakeCurrent(bool current) => MakeCurrent(current);

        #endregion
    }
}
