﻿namespace ToyGraf.Controllers
{
    using OpenTK;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Controls;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Models.Enums;
    using ToyGraf.Properties;
    using ToyGraf.Views;

    internal class SceneController
    {
        #region Constructors

        internal SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            ClockController = new ClockController(this);
            CommandProcessor = new CommandProcessor(this);
            new FullScreenController(this);
            JsonController = new JsonController(this);
            PropertyGridController = new PropertyGridController(this);
            RenderController = new RenderController(this);
            TraceTableController = new TraceTableController(this);
            ConnectAll(true);
        }

        #endregion

        #region Internal Properties

        internal ClockController ClockController;
        internal CommandProcessor CommandProcessor { get; private set; }
        internal readonly PropertyGridController PropertyGridController;
        internal readonly RenderController RenderController;
        internal Scene Scene;
        internal SceneForm SceneForm;
        internal readonly TraceTableController TraceTableController;

        #endregion

        #region Internal Methods

        internal void ApplyOptions() => PropertyGridController.ApplyOptions();

        internal void BeginUpdate() => ++UpdateCount;

        private void ConnectControllers(bool connect)
        {
            if (connect)
            {
                PropertyGridController.SelectedObject = Scene;
            }
            else
            {
                PropertyGridController.SelectedObject = null;
                RenderController.Unload();
            }
        }

        internal void EndUpdate()
        {
            if (--UpdateCount == 0)
            {
                foreach (var propertyName in ChangedPropertyNames)
                    OnPropertyChanged(propertyName);
                ChangedPropertyNames.Clear();
            }
        }

        internal static void InitTextureDialog(OpenFileDialog dialog)
        {
            dialog.Filter = Settings.Default.ImageFilter;
            dialog.Title = "Select Texture";
        }

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => SceneForm.Text = JsonController.WindowCaption;

        internal void OnPropertyChanged(Scene scene, params string[] propertyNames)
        {
            ChangedSubject = scene;
            OnPropertyChanged(propertyNames);
        }

        internal void OnPropertyChanged(Trace trace, params string[] propertyNames)
        {
            ChangedSubject = trace;
            OnPropertyChanged(propertyNames);
        }

        internal void OnSelectionChanged() => PropertyGridController.Refresh();

        /// <summary>
        /// When the PropertyGrid signals editing of a subproperty, it has already modified the
        /// parent property directly, bypassing the Command pattern. Therefore we need to spoof the
        /// appropriate command, to ensure the undo/redo mechanism is kept in sync with the state of
        /// the model.
        /// </summary>
        /// <param name="e">The EventArgs from the original event.</param>
        internal bool PropertyChanged(PropertyValueChangedEventArgs e)
        {
            string property = null, field = null;
            for (var item = e.ChangedItem; item.Parent != null; item = item.Parent)
            {
                if (item.Label.EndsWith(" "))
                    break;
                field = field == null ? property : $"{property}.{field}";
                property = item.Label;
            }
            if (field == null) // Not a nested property.
                return false;
            var value = e.OldValue;
            var scene = PropertyGridAdapter.SelectedObject;
            if (scene != null)
                Spoof(Spoof(property, field, value));
            else
                foreach (Trace trace in PropertyGridAdapter.SelectedObjects)
                    Spoof(Spoof(trace, property, field, value));
            return true;
        }

        internal void Show() => SceneForm.Show();

        internal void ShowOpenGLSLBook(PropertyGrid propertyGrid) =>
            $"{GLSLUrl}{GetBookmark(propertyGrid)}".Launch();

        #endregion

        #region Private Event Handlers

        private void CameraMoveBack_Click(object sender, System.EventArgs e) => Scene.CameraMoveBack();
        private void CameraMoveDown_Click(object sender, EventArgs e) => Scene.CameraMoveDown();
        private void CameraMoveForward_Click(object sender, System.EventArgs e) => Scene.CameraMoveForward();
        private void CameraMoveLeft_Click(object sender, EventArgs e) => Scene.CameraMoveLeft();
        private void CameraMoveRight_Click(object sender, EventArgs e) => Scene.CameraMoveRight();
        private void CameraMoveUp_Click(object sender, EventArgs e) => Scene.CameraMoveUp();
        private void CameraRotateDown_Click(object sender, EventArgs e) => Scene.CameraRotateDown();
        private void CameraRotateLeft_Click(object sender, EventArgs e) => Scene.CameraRotateLeft();
        private void CameraRotateRight_Click(object sender, EventArgs e) => Scene.CameraRotateRight();
        private void CameraRotateUp_Click(object sender, EventArgs e) => Scene.CameraRotateUp();
        private void Clock_Tick(object sender, EventArgs e) { RenderController.Render(); }
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();
        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void GLControl_ClientSizeChanged(object sender, EventArgs e) => Resize();
        private void GLControl_Load(object sender, EventArgs e) { }
        private void GLControl_Paint(object sender, PaintEventArgs e) => RenderController.Render();
        private void GLControl_Resize(object sender, EventArgs e) { }
        private void HelpAbout_Click(object sender, System.EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook(SceneForm.PropertyGrid);
        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;
        private void Scene_PropertyChanged(object sender, PropertyChangedEventArgs e) => OnPropertyChanged(e.PropertyName);
        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void SceneForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);
        private void TbOpen_DropDownOpening(object sender, EventArgs e) => SceneForm.FileReopen.CloneTo(SceneForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        #endregion

        #region Private Properties

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private object ChangedSubject;
        private Clock Clock => ClockController.Clock;
        private GLControl GLControl => SceneForm?.GLControl;
        private const string GLSLUrl = "https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html";
        private readonly JsonController JsonController;
        private TgPropertyGridAdapter PropertyGridAdapter => PropertyGridController.PropertyGridAdapter;
        private int UpdateCount;
        private bool Updating => UpdateCount > 0;

        #endregion

        #region Private Methods

        private void ClockInit() => Clock.Interval_ms = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockController.UpdateTimeControls();
        }

        private void ConnectAll(bool connect)
        {
            if (connect)
            {
                ConnectEventHandlers(true);
                ConnectControllers(true);
                CommandProcessor.Clear();
                Clock.Tick += Clock_Tick;
                ClockStartup();
            }
            else
            {
                ClockShutdown();
                Clock.Tick -= Clock_Tick;
                RenderController.InvalidateProgram();
                CommandProcessor.Clear();
                ConnectControllers(false);
                ConnectEventHandlers(false);
                AppController.Remove(this);
            }
        }

        private void ConnectEventHandlers(bool connect)
        {
            if (connect)
            {
                SceneForm.FormClosed += SceneForm_FormClosed;
                SceneForm.FormClosing += SceneForm_FormClosing;
                SceneForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click += FileOpen_Click;
                SceneForm.FileSave.Click += FileSave_Click;
                SceneForm.FileSaveAs.Click += FileSaveAs_Click;
                SceneForm.FileClose.Click += FileClose_Click;
                SceneForm.FileExit.Click += FileExit_Click;
                SceneForm.EditOptions.Click += EditOptions_Click;
                SceneForm.EditRefresh.Click += (sender, e) => RenderController.Refresh();
                SceneForm.MoveLeft.Click += CameraMoveLeft_Click;
                SceneForm.MoveRight.Click += CameraMoveRight_Click;
                SceneForm.ZoomIn.Click += CameraMoveForward_Click;
                SceneForm.ZoomOut.Click += CameraMoveBack_Click;
                SceneForm.MoveUp.Click += CameraMoveUp_Click;
                SceneForm.MoveDown.Click += CameraMoveDown_Click;
                SceneForm.CircleLeft.Click += CameraRotateLeft_Click;
                SceneForm.CircleRight.Click += CameraRotateRight_Click;
                SceneForm.CircleUp.Click += CameraRotateUp_Click;
                SceneForm.CircleDown.Click += CameraRotateDown_Click;
                SceneForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click += HelpAbout_Click;
                SceneForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick += FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                SceneForm.tbSave.Click += TbSave_Click;
                GLControl.ClientSizeChanged += GLControl_ClientSizeChanged;
                GLControl.Load += GLControl_Load;
                GLControl.Paint += GLControl_Paint;
                GLControl.Resize += GLControl_Resize;
                JsonController.FileLoaded += JsonController_FileLoaded;
                JsonController.FilePathChanged += JsonController_FilePathChanged;
                JsonController.FilePathRequest += JsonController_FilePathRequest;
                JsonController.FileReopen += JsonController_FileReopen;
                JsonController.FileSaving += JsonController_FileSaving;
                JsonController.FileSaved += JsonController_FileSaved;
            }
            else
            {
                SceneForm.FormClosed -= SceneForm_FormClosed;
                SceneForm.FormClosing -= SceneForm_FormClosing;
                SceneForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click -= FileOpen_Click;
                SceneForm.FileSave.Click -= FileSave_Click;
                SceneForm.FileSaveAs.Click -= FileSaveAs_Click;
                SceneForm.FileClose.Click -= FileClose_Click;
                SceneForm.FileExit.Click -= FileExit_Click;
                SceneForm.EditOptions.Click -= EditOptions_Click;
                SceneForm.EditRefresh.Click -= (sender, e) => RenderController.Refresh();
                SceneForm.MoveLeft.Click -= CameraMoveLeft_Click;
                SceneForm.MoveRight.Click -= CameraMoveRight_Click;
                SceneForm.ZoomIn.Click -= CameraMoveForward_Click;
                SceneForm.ZoomOut.Click -= CameraMoveBack_Click;
                SceneForm.MoveUp.Click -= CameraMoveUp_Click;
                SceneForm.MoveDown.Click -= CameraMoveDown_Click;
                SceneForm.CircleLeft.Click -= CameraRotateLeft_Click;
                SceneForm.CircleRight.Click -= CameraRotateRight_Click;
                SceneForm.CircleUp.Click -= CameraRotateUp_Click;
                SceneForm.CircleDown.Click -= CameraRotateDown_Click;
                SceneForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click -= HelpAbout_Click;
                SceneForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick -= FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                SceneForm.tbSave.Click -= TbSave_Click;
                GLControl.ClientSizeChanged -= GLControl_ClientSizeChanged;
                GLControl.Load -= GLControl_Load;
                GLControl.Paint -= GLControl_Paint;
                GLControl.Resize -= GLControl_Resize;
                JsonController.FileLoaded -= JsonController_FileLoaded;
                JsonController.FilePathChanged -= JsonController_FilePathChanged;
                JsonController.FilePathRequest -= JsonController_FilePathRequest;
                JsonController.FileReopen -= JsonController_FileReopen;
                JsonController.FileSaving -= JsonController_FileSaving;
                JsonController.FileSaved -= JsonController_FileSaved;
            }
        }

        private void EditOptions()
        {
            using (var optionsController = new OptionsController(this))
                optionsController.ShowModal(SceneForm);
        }

        private void FileLoaded()
        {
            ConnectControllers(false);
            Scene.SceneController = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
            ConnectControllers(true);
        }

        private void FilePathRequest(SdiController.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved()
        {
            BeginUpdate();
            CommandProcessor.Save();
            EndUpdate();
        }

        private bool FormClosing(CloseReason _) => JsonController.SaveIfModified();

        private void FormClosed() => ConnectAll(false);

        private static string GetBookmark(PropertyGrid propertyGrid)
        {
            switch (propertyGrid.SelectedGridItem?.PropertyDescriptor.Name)
            {
                case "Shader1Vertex":
                    return "#vertex-processor";
                case "Shader2TessControl":
                    return "#tessellation-control-processor";
                case "Shader3TessEvaluation":
                    return "#tessellation-evaluation-processor";
                case "Shader4Geometry":
                    return "#geometry-processor";
                case "Shader5Fragment":
                    return "#fragment-processor";
                case "Shader6Compute":
                    return "#compute-processor";
                default:
                    return string.Empty;
            }
        }

        private int GetFrameMilliseconds() => (int)Math.Round(1000 / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private SceneController GetNewSceneController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewSceneController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void HelpAbout() => new AboutController().ShowDialog(SceneForm);

        private void NewEmptyScene()
        {
            GetNewSceneController();
            CommandProcessor.Clear();
        }

        private void NewFromTemplate()
        {
            var sceneController = OpenFile(FilterIndex.Template);
            if (sceneController != null)
                sceneController.JsonController.FilePath = string.Empty;
        }

        private void OnPropertyChanged(params string[] propertyNames)
        {
            if (Updating)
            {
                ChangedPropertyNames.AddRange(propertyNames.Where(p => !ChangedPropertyNames.Contains(p)));
                return;
            }
            $"Property Changed: {propertyNames.Aggregate((s, t) => $"{s}, {t}")}.".Spit();
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case DisplayNames.FPS:
                        ClockInit();
                        break;
                    case DisplayNames.Camera:
                        RenderController.InvalidateCameraView();
                        break;
                    case DisplayNames.Shader1Vertex:
                    case DisplayNames.Shader2TessControl:
                    case DisplayNames.Shader3TessEvaluation:
                    case DisplayNames.Shader4Geometry:
                    case DisplayNames.Shader5Fragment:
                    case DisplayNames.Shader6Compute:
                    case DisplayNames.TraceList:
                        RenderController.InvalidateProgram();
                        break;
                    case DisplayNames.Projection:
                        RenderController.InvalidateProjection();
                        break;
                    case DisplayNames.Pattern:
                    case DisplayNames.StripCount:
                        RenderController.InvalidateTrace((Trace)ChangedSubject);
                        break;
                }
            PropertyGridController.Refresh();
            TraceTableController.Refresh();
            GLControl.Invalidate();
        }

        private SceneController OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonController.SelectFilePath(filterIndex));

        private SceneController OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var sceneController = GetNewSceneController();
            sceneController?.LoadFromFile(filePath);
            return sceneController;
        }

        private void Resize() => RenderController.InvalidateProjection();
        private bool SaveFile() => JsonController.Save();
        private bool SaveFileAs() => JsonController.SaveAs();
        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void Spoof(ICommand command) => CommandProcessor.Run(command, true);

        private ICommand Spoof(string property, string field, object value)
        {
            switch (property)
            {
                case DisplayNames.AccumColourFormat:
                    return new AccumColourFormatCommand(new ColourFormat(Scene.AccumColourFormat, field, (int)value));
                case DisplayNames.Camera:
                    return new CameraCommand(new Camera(Scene.Camera, field, value));
                case DisplayNames.ColourFormat:
                    return new ColourFormatCommand(new ColourFormat(Scene.ColourFormat, field, (int)value));
                case DisplayNames.Projection:
                    return new ProjectionCommand(new Projection(Scene.Projection, field, value));
            }
            return null;
        }

        private ICommand Spoof(Trace trace, string property, string field, object value)
        {
            var index = trace.Index;
            switch (property)
            {
                case DisplayNames.Location:
                    return new LocationCommand(index, new Vector3f(trace.Location, field, (float)value));
                case DisplayNames.Maximum:
                    return new MaximumCommand(index, new Vector3f(trace.Maximum, field, (float)value));
                case DisplayNames.Minimum:
                    return new MinimumCommand(index, new Vector3f(trace.Minimum, field, (float)value));
                case DisplayNames.Orientation:
                    return new OrientationCommand(index, new Euler3f(trace.Orientation, field, (float)value));
                case DisplayNames.Scale:
                    return new ScaleCommand(index, new Vector3f(trace.Scale, field, (float)value));
                case DisplayNames.StripCount:
                    return new StripCountCommand(index, new Vector3i(trace.StripCount, field, (int)value));
            }
            return null;
        }

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        #endregion
    }
}
