namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Linq;
    using ToyGraf.Commands;
    using ToyGraf.Controllers;
    using ToyGraf.Controls;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Views;

    [DefaultProperty("Traces")]
    public class Scene
    {
        #region Public Interface

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController) : this() => SceneController = sceneController;

        internal Matrix4 GetCameraView() => Maths.CreateCameraView(CameraPosition, CameraRotation);
        internal Matrix4 GetProjection() => Maths.CreatePerspectiveProjection(FieldOfView, AspectRatio, NearPlane, FarPlane);

        public string GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return _Shader1Vertex;
                case ShaderType.TessControlShader:
                    return _Shader2TessControl;
                case ShaderType.TessEvaluationShader:
                    return _Shader3TessEvaluation;
                case ShaderType.GeometryShader:
                    return _Shader4Geometry;
                case ShaderType.FragmentShader:
                    return _Shader5Fragment;
                case ShaderType.ComputeShader:
                    return _Shader6Compute;
            }
            return string.Empty;
        }

        public void SetScript(ShaderType shaderType, string script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    _Shader1Vertex = script;
                    break;
                case ShaderType.TessControlShader:
                    _Shader2TessControl = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    _Shader3TessEvaluation = script;
                    break;
                case ShaderType.GeometryShader:
                    _Shader4Geometry = script;
                    break;
                case ShaderType.FragmentShader:
                    _Shader5Fragment = script;
                    break;
                case ShaderType.ComputeShader:
                    _Shader6Compute = script;
                    break;
            }
        }

        internal void SetCameraView(Matrix4 cameraView) { }
        internal void SetProjection(Matrix4 projection) { }

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Title)
            ? _Title
            : "New scene";

        internal event PropertyChangedEventHandler PropertyChanged;

        internal void Clear()
        {
            RestoreDefaults();
            OnPropertyChanged(string.Empty);
        }

        #endregion

        #region Browsable Properties

        #region Graphics Mode

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description("The number of bits per pixel in each accumulator colour channel.")]
        [DisplayName("Accumulator Colour Format")]
        [JsonIgnore]
        public ColourFormat AccumColourFormat { get => _AccumColourFormat; set => Run(new AccumColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description("The colour of the background.")]
        [DisplayName("Background Colour")]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description("The number of bits per pixel in each colour channel.")]
        [DisplayName("Colour Format")]
        [JsonIgnore]
        public ColourFormat ColourFormat { get => _ColourFormat; set => Run(new ColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Depth)]
        [Description("The number of bits in the depth buffer.")]
        [DisplayName("Depth Bits")]
        [JsonIgnore]
        public int Depth { get => _Depth; set => Run(new DepthCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stencil)]
        [Description("The number of bits in the stencil buffer.")]
        [DisplayName("Stencil Bits")]
        [JsonIgnore]
        public int Stencil { get => _Stencil; set => Run(new StencilCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.SampleCount)]
        [Description("The number of Full Screen Anti-Aliasing (FSAA) samples used.")]
        [DisplayName("Sample Count")]
        [JsonIgnore]
        public int SampleCount { get => _SampleCount; set => Run(new SampleCountCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Buffers)]
        [Description("The number of buffers associated with this display mode.")]
        [DisplayName("Buffers")]
        [JsonIgnore]
        public int Buffers { get => _Buffers; set => Run(new BuffersCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stereo)]
        [Description("Indicates whether this display mode is stereoscopic 3D.")]
        [DisplayName("Stereo")]
        [JsonIgnore]
        public bool Stereo { get => _Stereo; set => Run(new StereoCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.VSync)]
        [Description("Indicates whether GLControl updates are synced to the monitor's refresh rate.")]
        [DisplayName("VSync")]
        [JsonIgnore]
        public bool VSync { get => _VSync; set => Run(new VSyncCommand(value)); }

        #endregion

        #region Projection

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FieldOfView)]
        [Description("The frustrum field of view (Y component, degrees).")]
        [DisplayName("Field of View° Y")]
        [JsonIgnore]
        public float FieldOfView { get => _FieldOfView; set => Run(new FieldOfViewCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.NearPlane)]
        [Description("The distance from the camera position to the near plane of the frustrum.")]
        [DisplayName("Near Plane")]
        [JsonIgnore]
        public float NearPlane { get => _NearPlane; set => Run(new NearPlaneCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FarPlane)]
        [Description("The distance from the camera position to the far plane of the frustrum.")]
        [DisplayName("Far Plane")]
        [JsonIgnore]
        public float FarPlane { get => _FarPlane; set => Run(new FarPlaneCommand(value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description("The camera view matrix for the scene.")]
        [DisplayName("View")]
        [JsonIgnore]
        public Matrix4 CameraView
        {
            get => GetCameraView();
            set => Run(new CameraViewCommand(value));
        }

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPUStatus)]
        [Description("The status of the most recent GPU compilation action. An empty value indicates successful compilation.")]
        [DisplayName("GPU Status")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPUStatus
        {
            get => _GPUStatus;
        }

        [Category(Categories.SystemRO)]
        [Description("The projection matrix for the scene.")]
        [DisplayName("Projection")]
        [JsonIgnore]
        public Matrix4 Projection
        {
            get => GetProjection();
            set => Run(new SceneProjectionCommand(value));
        }

        #endregion

        #region Scene

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Point3F), Defaults.CameraPositionString)]
        [Description("The camera position for the scene.")]
        [DisplayName("Camera Position")]
        [JsonIgnore]
        public Point3F CameraPosition { get => _CameraPosition; set => Run(new CameraPositionCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Euler3F), Defaults.CameraRotationString)]
        [Description("The camera rotation for the scene (in degrees).")]
        [DisplayName("Camera Rotation°")]
        [JsonIgnore]
        public Euler3F CameraRotation { get => _CameraRotation; set => Run(new CameraRotationCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.FPS)]
        [Description("Frames per second: a cap on this scene's rendering frequency.")]
        [DisplayName("FPS")]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new SceneFpsCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.Title)]
        [Description("A title for this scene.")]
        [DisplayName("Title")]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        [Category(Categories.Scene)]
        [Description("A list of the traces in this scene.")]
        [DisplayName("Traces")]
        [Editor(typeof(TgCollectionEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public List<Trace> Traces
        {
            get => _Traces.Select(t => t.Clone()).ToList();
            set => _Traces = value;
        }

        #endregion

        #region Shaders

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader1Vertex)]
        [Description(@"The vertex processor is a programmable unit that operates on incoming vertices and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called vertex shaders.
When a set of vertex shaders are successfully compiled and linked, they result in a vertex shader executable that runs on the vertex processor.
The vertex processor operates on one vertex at a time. It does not replace graphics operations that require knowledge of several vertices at a time.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 1: Vertex (mandatory)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader1Vertex
        {
            get => _Shader1Vertex;
            set => Run(new SceneVertexShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader2TessControl)]
        [Description(@"The tessellation control processor is a programmable unit that operates on a patch of incoming vertices and their associated data, emitting a new output patch. Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation control shaders.
When a set of tessellation control shaders are successfully compiled and linked, they result in a tessellation control shader executable that runs on the tessellation control processor.
The tessellation control shader is invoked for each vertex of the output patch. Each invocation can read the attributes of any vertex in the input or output patches, but can only write per-vertex attributes for the corresponding output patch vertex.
The shader invocations collectively produce a set of per-patch attributes for the output patch. After all tessellation control shader invocations have completed, the output vertices and per-patch attributes are assembled to form a patch to be used by subsequent pipeline stages.
Tessellation control shader invocations run mostly independently, with undefined relative execution order. However, the built-in function barrier() can be used to control execution order by synchronizing invocations, effectively dividing tessellation control shader execution into a set of phases.
Tessellation control shaders will get undefined results if one invocation reads a per-vertex or per-patch attribute written by another invocation at any point during the same phase, or if two invocations attempt to write different values to the same per-patch output in a single phase.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 2: Tessellation Control")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader2TessControl
        {
            get => _Shader2TessControl;
            set => Run(new SceneTessControlShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader3TessEvaluation)]
        [Description(@"The tessellation evaluation processor is a programmable unit that evaluates the position and other attributes of a vertex generated by the tessellation primitive generator, using a patch of incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation evaluation shaders.
When a set of tessellation evaluation shaders are successfully compiled and linked, they result in a tessellation evaluation shader executable that runs on the tessellation evaluation processor.
Each invocation of the tessellation evaluation executable computes the position and attributes of a single vertex generated by the tessellation primitive generator.
The executable can read the attributes of any vertex in the input patch, plus the tessellation coordinate, which is the relative location of the vertex in the primitive being tessellated. The executable writes the position and other attributes of the vertex.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 3: Tessellation Evaluation")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set => Run(new SceneTessEvaluationShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader4Geometry)]
        [Description(@"The geometry processor is a programmable unit that operates on data for incoming vertices for a primitive assembled after vertex processing and outputs a sequence of vertices forming output primitives.
Compilation units written in the OpenGL Shading Language to run on this processor are called geometry shaders.
When a set of geometry shaders are successfully compiled and linked, they result in a geometry shader executable that runs on the geometry processor.
A single invocation of the geometry shader executable on the geometry processor will operate on a declared input primitive with a fixed number of vertices.
This single invocation can emit a variable number of vertices that are assembled into primitives of a declared output primitive type and passed to subsequent pipeline stages.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 4: Geometry")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new SceneGeometryShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader5Fragment)]
        [Description(@"The fragment processor is a programmable unit that operates on fragment values and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called fragment shaders.
When a set of fragment shaders are successfully compiled and linked, they result in a fragment shader executable that runs on the fragment processor.
A fragment shader cannot change a fragment's (x, y) position. Access to neighboring fragments is not allowed.
The values computed by the fragment shader are ultimately used to update framebuffer memory or texture memory, depending on the current OpenGL state and the OpenGL command that caused the fragments to be generated.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 5: Fragment (mandatory)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader5Fragment
        {
            get => _Shader5Fragment;
            set => Run(new SceneFragmentShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader6Compute)]
        [Description(@"The compute processor is a programmable unit that operates independently from the other shader processors. Compilation units written in the OpenGL Shading Language to run on this processor are called compute shaders.
When a set of compute shaders are successfully compiled and linked, they result in a compute shader executable that runs on the compute processor.
A compute shader has access to many of the same resources as fragment and other shader processors, including textures, buffers, image variables, and atomic counters. It does not have any predefined inputs nor any fixed-function outputs.
It is not part of the graphics pipeline and its visible side effects are through changes to images, storage buffers, and atomic counters.
A compute shader operates on a group of work items called a work group. A work group is a collection of shader invocations that execute the same code, potentially in parallel.
An invocation within a work group may share data with other members of the same work group through shared variables and issue memory and control barriers to synchronize with other members of the same work group.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader 6: Compute")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader6Compute
        {
            get => _Shader6Compute;
            set => Run(new SceneComputeShaderCommand(value));
        }

        #endregion

        #endregion

        #region Persistent Fields

        [JsonProperty] internal ColourFormat _AccumColourFormat;
        [JsonProperty] internal Color _BackgroundColour;
        [JsonProperty] internal int _Buffers;
        [JsonProperty] internal Point3F _CameraPosition;
        [JsonProperty] internal Euler3F _CameraRotation;
        [JsonProperty] internal ColourFormat _ColourFormat;
        [JsonProperty] internal int _Depth;
        [JsonProperty] internal float _FarPlane;
        [JsonProperty] internal float _FieldOfView;
        [JsonProperty] internal double _FPS;
        [JsonProperty] internal string _GPUStatus;
        [JsonProperty] internal float _NearPlane;
        [JsonProperty] internal int _SampleCount;
        [JsonProperty] internal string _Shader1Vertex;
        [JsonProperty] internal string _Shader2TessControl;
        [JsonProperty] internal string _Shader3TessEvaluation;
        [JsonProperty] internal string _Shader4Geometry;
        [JsonProperty] internal string _Shader5Fragment;
        [JsonProperty] internal string _Shader6Compute;
        [JsonProperty] internal int _Stencil;
        [JsonProperty] internal bool _Stereo;
        [JsonProperty] internal string _Title;
        [JsonProperty] internal List<Trace> _Traces = new List<Trace>();
        [JsonProperty] internal bool _VSync;

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal bool IsModified => CommandProcessor?.IsModified ?? false;
        internal SceneController SceneController;

        #endregion

        #region Internal Methods

        internal void AddTrace(Trace trace)
        {
            _Traces.Add(trace);
            OnPropertyChanged("Traces");
        }

        internal void AttachTraces()
        {
            foreach (var trace in _Traces)
                trace.Init(this);
        }

        internal void InsertTrace(int index, Trace trace)
        {
            _Traces.Insert(index, trace);
            OnPropertyChanged("Traces");
        }

        internal Trace NewTrace()
        {
            var trace = new Trace(this);
            //_Traces.Add(trace);
            return trace;
        }

        internal void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < _Traces.Count)
            {
                _Traces.RemoveAt(index);
                OnPropertyChanged("Traces");
            }
        }

        #endregion

        #region Private Properties

        private float AspectRatio
        {
            get
            {
                var glControl = GLControl;
                if (glControl != null)
                {
                    float w = glControl.Width, h = glControl.Height;
                    if (w > 0 && h > 0)
                        return w / h;
                }
                return 1920f / 1080f;
            }
        }

        private GLControl GLControl => SceneForm?.GLControl;
        private SceneForm SceneForm => SceneController?.SceneForm;

        #endregion

        #region Private Methods

        private void RestoreDefaults()
        {
            _AccumColourFormat = Defaults.AccumColourFormat;
            _BackgroundColour = Defaults.BackgroundColour;
            _Buffers = Defaults.Buffers;
            _CameraPosition = Defaults.CameraPosition;
            _CameraRotation = Defaults.CameraRotation;
            _ColourFormat = Defaults.ColourFormat;
            _Depth = Defaults.Depth;
            _FarPlane = Defaults.FarPlane;
            _FieldOfView = Defaults.FieldOfView;
            _FPS = Defaults.FPS;
            _GPUStatus = Defaults.GPUStatus;
            _NearPlane = Defaults.NearPlane;
            _SampleCount = Defaults.SampleCount;
            _Shader1Vertex = Defaults.Shader1Vertex;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Defaults.Shader5Fragment;
            _Shader6Compute = Defaults.Shader6Compute;
            _Stencil = Defaults.Stencil;
            _Stereo = Defaults.Stereo;
            _Title = Defaults.Title;
            _Traces = Defaults.Traces;
            _VSync = Defaults.VSync;
        }

        private void Run(IScenePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        #endregion

        #region Private Classes

        private class Categories
        {
            internal const string
                Camera = "Camera",
                GraphicsMode = "Graphics Mode",
                Projection = "Projection",
                Scene = "Scene",
                Shaders = "Shaders",
                SystemRO = "Read Only / System";
        }

        private class Defaults
        {
            internal const string
                BackgroundColourString = "White",
                CameraPositionString = "0, 0, 0",
                CameraRotationString = "0, 0, 0",
                ColourFormatString = "0, 0, 0, 0",
                GPUStatus = "",
                Shader1Vertex = "",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader5Fragment = "",
                Shader6Compute = "",
                Title = "";

            internal const bool
                Stereo = false,
                VSync = false;

            internal const int
                Buffers = 2,
                Depth = 24,
                SampleCount = 0,
                Stencil = 8;

            internal const float
                FieldOfView = 75,
                NearPlane = 0.1f,
                FarPlane = 1000;

            internal const double
                FPS = 60;

            internal static Color
                BackgroundColour = Color.White;

            internal static ColourFormat
                ColourFormat = new ColourFormat(8),
                AccumColourFormat = new ColourFormat();

            internal static Euler3F
                CameraRotation = new Euler3F();

            internal static Point3F
                CameraPosition = new Point3F();

            internal static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion
    }
}
