namespace ToyGraf.Views
{
    partial class SceneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GLControl = new OpenTK.GLControl();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new ToyGraf.Controls.TgStatusStrip();
            this.tbDecelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbReverse = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbStop = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbPause = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbForward = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbAccelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.PopupPropertyGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupPropertyGridFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPropertyGridHide = new System.Windows.Forms.ToolStripMenuItem();
            this.EntityTable = new System.Windows.Forms.DataGridView();
            this.PopupEntityTableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupEntityTableFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupEntityTableHide = new System.Windows.Forms.ToolStripMenuItem();
            this.Toolbar = new ToyGraf.Controls.TgToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new ToyGraf.Controls.TgMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.EditOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneAddNewTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewPropertyGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewEntityTable = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMove = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraMoveIn = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveOut = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRotateLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRotateRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraRotateUp = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRotateDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraRotateAnticlockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRotateClockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraHome = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDecelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeStop = new System.Windows.Forms.ToolStripMenuItem();
            this.TimePause = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeForward = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeAccelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.PopupPropertyGridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntityTable)).BeginInit();
            this.PopupEntityTableMenu.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLControl.Location = new System.Drawing.Point(0, 0);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(415, 321);
            this.GLControl.TabIndex = 1;
            this.GLControl.VSync = false;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.BottomToolStripPanel
            // 
            this.ToolStripContainer.BottomToolStripPanel.Controls.Add(this.StatusBar);
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.SplitContainer1);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(591, 395);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(624, 441);
            this.ToolStripContainer.TabIndex = 2;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDecelerate,
            this.tbReverse,
            this.tbStop,
            this.tbPause,
            this.tbForward,
            this.tbAccelerate,
            this.SpeedLabel,
            this.TimeLabel,
            this.FpsLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(624, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // tbDecelerate
            // 
            this.tbDecelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDecelerate.Image = global::ToyGraf.Properties.Resources.RewindHS;
            this.tbDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDecelerate.Name = "tbDecelerate";
            this.tbDecelerate.ShowDropDownArrow = false;
            this.tbDecelerate.Size = new System.Drawing.Size(20, 20);
            this.tbDecelerate.Text = "toolStripDropDownButton1";
            this.tbDecelerate.ToolTipText = "Decelerate";
            // 
            // tbReverse
            // 
            this.tbReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReverse.Image = global::ToyGraf.Properties.Resources.BackHS;
            this.tbReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.tbReverse.Name = "tbReverse";
            this.tbReverse.ShowDropDownArrow = false;
            this.tbReverse.Size = new System.Drawing.Size(20, 20);
            this.tbReverse.Text = "toolStripDropDownButton2";
            this.tbReverse.ToolTipText = "Reverse";
            // 
            // tbStop
            // 
            this.tbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStop.Image = global::ToyGraf.Properties.Resources.StopHS;
            this.tbStop.ImageTransparentColor = System.Drawing.Color.White;
            this.tbStop.Name = "tbStop";
            this.tbStop.ShowDropDownArrow = false;
            this.tbStop.Size = new System.Drawing.Size(20, 20);
            this.tbStop.Text = "toolStripDropDownButton3";
            this.tbStop.ToolTipText = "Stop";
            // 
            // tbPause
            // 
            this.tbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPause.Image = global::ToyGraf.Properties.Resources.PauseHS;
            this.tbPause.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPause.Name = "tbPause";
            this.tbPause.ShowDropDownArrow = false;
            this.tbPause.Size = new System.Drawing.Size(20, 20);
            this.tbPause.Text = "toolStripDropDownButton4";
            this.tbPause.ToolTipText = "Pause";
            // 
            // tbForward
            // 
            this.tbForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbForward.Image = global::ToyGraf.Properties.Resources.PlayHS;
            this.tbForward.ImageTransparentColor = System.Drawing.Color.White;
            this.tbForward.Name = "tbForward";
            this.tbForward.ShowDropDownArrow = false;
            this.tbForward.Size = new System.Drawing.Size(20, 20);
            this.tbForward.Text = "toolStripDropDownButton5";
            this.tbForward.ToolTipText = "Forward";
            // 
            // tbAccelerate
            // 
            this.tbAccelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAccelerate.Image = global::ToyGraf.Properties.Resources.FFwdHS;
            this.tbAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAccelerate.Name = "tbAccelerate";
            this.tbAccelerate.ShowDropDownArrow = false;
            this.tbAccelerate.Size = new System.Drawing.Size(20, 20);
            this.tbAccelerate.Text = "toolStripDropDownButton6";
            this.tbAccelerate.ToolTipText = "Accelerate";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = false;
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(64, 17);
            this.SpeedLabel.Text = "time × 1";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = false;
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(64, 17);
            this.TimeLabel.Text = "t=0.0";
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = false;
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(64, 17);
            this.FpsLabel.Text = "fps=0.0";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.EntityTable);
            this.SplitContainer1.Size = new System.Drawing.Size(591, 395);
            this.SplitContainer1.SplitterDistance = 321;
            this.SplitContainer1.SplitterWidth = 5;
            this.SplitContainer1.TabIndex = 2;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.GLControl);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.PropertyGrid);
            this.SplitContainer2.Size = new System.Drawing.Size(591, 321);
            this.SplitContainer2.SplitterDistance = 415;
            this.SplitContainer2.SplitterWidth = 5;
            this.SplitContainer2.TabIndex = 0;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.ContextMenuStrip = this.PopupPropertyGridMenu;
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(171, 321);
            this.PropertyGrid.TabIndex = 0;
            // 
            // PopupPropertyGridMenu
            // 
            this.PopupPropertyGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupPropertyGridFloat,
            this.PopupPropertyGridHide});
            this.PopupPropertyGridMenu.Name = "PopupPropertyGridMenu";
            this.PopupPropertyGridMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // PopupPropertyGridFloat
            // 
            this.PopupPropertyGridFloat.Name = "PopupPropertyGridFloat";
            this.PopupPropertyGridFloat.Size = new System.Drawing.Size(100, 22);
            this.PopupPropertyGridFloat.Text = "&Float";
            // 
            // PopupPropertyGridHide
            // 
            this.PopupPropertyGridHide.Name = "PopupPropertyGridHide";
            this.PopupPropertyGridHide.Size = new System.Drawing.Size(100, 22);
            this.PopupPropertyGridHide.Text = "&Hide";
            // 
            // EntityTable
            // 
            this.EntityTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntityTable.ContextMenuStrip = this.PopupEntityTableMenu;
            this.EntityTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityTable.Location = new System.Drawing.Point(0, 0);
            this.EntityTable.Name = "EntityTable";
            this.EntityTable.Size = new System.Drawing.Size(591, 69);
            this.EntityTable.TabIndex = 0;
            // 
            // PopupEntityTableMenu
            // 
            this.PopupEntityTableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupEntityTableFloat,
            this.PopupEntityTableHide});
            this.PopupEntityTableMenu.Name = "PopupDataGridMenu";
            this.PopupEntityTableMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // PopupEntityTableFloat
            // 
            this.PopupEntityTableFloat.Name = "PopupEntityTableFloat";
            this.PopupEntityTableFloat.Size = new System.Drawing.Size(100, 22);
            this.PopupEntityTableFloat.Text = "&Float";
            // 
            // PopupEntityTableHide
            // 
            this.PopupEntityTableHide.Name = "PopupEntityTableHide";
            this.PopupEntityTableHide.Size = new System.Drawing.Size(100, 22);
            this.PopupEntityTableHide.Text = "&Hide";
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator1,
            this.tbUndo,
            this.tbRedo,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbAdd});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 253);
            this.Toolbar.TabIndex = 2;
            this.Toolbar.Text = "toolStrip1";
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewEmptyScene,
            this.tbNewFromTemplate});
            this.tbNew.Image = global::ToyGraf.Properties.Resources.NewDocumentHS;
            this.tbNew.ImageTransparentColor = System.Drawing.Color.White;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(31, 20);
            this.tbNew.ToolTipText = "Create a new file (^N)";
            // 
            // tbNewEmptyScene
            // 
            this.tbNewEmptyScene.Name = "tbNewEmptyScene";
            this.tbNewEmptyScene.ShortcutKeyDisplayString = "^N";
            this.tbNewEmptyScene.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tbNewEmptyScene.Size = new System.Drawing.Size(193, 22);
            this.tbNewEmptyScene.Text = "&New Empty Scene";
            // 
            // tbNewFromTemplate
            // 
            this.tbNewFromTemplate.Name = "tbNewFromTemplate";
            this.tbNewFromTemplate.Size = new System.Drawing.Size(193, 22);
            this.tbNewFromTemplate.Text = "New from &Template...";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = global::ToyGraf.Properties.Resources.OpenFileHS;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(31, 20);
            this.tbOpen.ToolTipText = "Open an existing file (^O)";
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = global::ToyGraf.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.White;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(31, 20);
            this.tbSave.ToolTipText = "Save to file (^S)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(31, 6);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Image = global::ToyGraf.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(31, 20);
            this.tbUndo.ToolTipText = "Undo (^Z)";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::ToyGraf.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(31, 20);
            this.tbRedo.ToolTipText = "Redo (^Y)";
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::ToyGraf.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(31, 20);
            this.tbCut.Text = "toolStripButton1";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::ToyGraf.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.Text = "toolStripButton2";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::ToyGraf.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.Text = "toolStripButton3";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::ToyGraf.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.Text = "toolStripButton4";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(31, 6);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.Image = global::ToyGraf.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(31, 20);
            this.tbAdd.ToolTipText = "Add a new Trace (F2)";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.SceneMenu,
            this.ViewMenu,
            this.CameraMenu,
            this.TimeMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileReopen,
            this.toolStripMenuItem2,
            this.FileSave,
            this.FileSaveAs,
            this.toolStripMenuItem1,
            this.FileClose,
            this.FileExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewEmptyScene,
            this.FileNewFromTemplate});
            this.FileNew.Image = global::ToyGraf.Properties.Resources.NewDocumentHS;
            this.FileNew.ImageTransparentColor = System.Drawing.Color.White;
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeyDisplayString = "";
            this.FileNew.Size = new System.Drawing.Size(196, 22);
            this.FileNew.Text = "&New";
            // 
            // FileNewEmptyScene
            // 
            this.FileNewEmptyScene.Name = "FileNewEmptyScene";
            this.FileNewEmptyScene.ShortcutKeyDisplayString = "^N";
            this.FileNewEmptyScene.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNewEmptyScene.Size = new System.Drawing.Size(166, 22);
            this.FileNewEmptyScene.Text = "&Empty Scene";
            // 
            // FileNewFromTemplate
            // 
            this.FileNewFromTemplate.Name = "FileNewFromTemplate";
            this.FileNewFromTemplate.Size = new System.Drawing.Size(166, 22);
            this.FileNewFromTemplate.Text = "From Template";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::ToyGraf.Properties.Resources.OpenFileHS;
            this.FileOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(196, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(196, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::ToyGraf.Properties.Resources.saveHS;
            this.FileSave.ImageTransparentColor = System.Drawing.Color.White;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(196, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(196, 22);
            this.FileSaveAs.Text = "&Save As...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(196, 22);
            this.FileClose.Text = "&Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(196, 22);
            this.FileExit.Text = "Close All && E&xit";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo,
            this.toolStripMenuItem8,
            this.EditCut,
            this.EditCopy,
            this.EditPaste,
            this.EditDelete,
            this.toolStripMenuItem9,
            this.EditSelectAll,
            this.EditInvertSelection,
            this.toolStripMenuItem10,
            this.EditOptions});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // EditUndo
            // 
            this.EditUndo.Image = global::ToyGraf.Properties.Resources.Edit_UndoHS;
            this.EditUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeyDisplayString = "^Z";
            this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.EditUndo.Size = new System.Drawing.Size(155, 22);
            this.EditUndo.Text = "&Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Image = global::ToyGraf.Properties.Resources.Edit_RedoHS;
            this.EditRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeyDisplayString = "^Y";
            this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.EditRedo.Size = new System.Drawing.Size(155, 22);
            this.EditRedo.Text = "&Redo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 6);
            // 
            // EditCut
            // 
            this.EditCut.Image = global::ToyGraf.Properties.Resources.CutHS;
            this.EditCut.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCut.Name = "EditCut";
            this.EditCut.ShortcutKeyDisplayString = "^X";
            this.EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.EditCut.Size = new System.Drawing.Size(155, 22);
            this.EditCut.Text = "Cu&t";
            // 
            // EditCopy
            // 
            this.EditCopy.Image = global::ToyGraf.Properties.Resources.CopyHS;
            this.EditCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.ShortcutKeyDisplayString = "^C";
            this.EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.EditCopy.Size = new System.Drawing.Size(155, 22);
            this.EditCopy.Text = "&Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Image = global::ToyGraf.Properties.Resources.PasteHS;
            this.EditPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.ShortcutKeyDisplayString = "^V";
            this.EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.EditPaste.Size = new System.Drawing.Size(155, 22);
            this.EditPaste.Text = "&Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Image = global::ToyGraf.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.Size = new System.Drawing.Size(155, 22);
            this.EditDelete.Text = "&Delete";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.Size = new System.Drawing.Size(155, 22);
            this.EditSelectAll.Text = "Select &All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(155, 22);
            this.EditInvertSelection.Text = "&Invert Selection";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 6);
            // 
            // EditOptions
            // 
            this.EditOptions.Name = "EditOptions";
            this.EditOptions.Size = new System.Drawing.Size(155, 22);
            this.EditOptions.Text = "&Options...";
            // 
            // SceneMenu
            // 
            this.SceneMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SceneAddNewTrace});
            this.SceneMenu.Name = "SceneMenu";
            this.SceneMenu.Size = new System.Drawing.Size(50, 20);
            this.SceneMenu.Text = "&Scene";
            // 
            // SceneAddNewTrace
            // 
            this.SceneAddNewTrace.Image = global::ToyGraf.Properties.Resources.action_add_16xLG;
            this.SceneAddNewTrace.ImageTransparentColor = System.Drawing.Color.White;
            this.SceneAddNewTrace.Name = "SceneAddNewTrace";
            this.SceneAddNewTrace.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.SceneAddNewTrace.Size = new System.Drawing.Size(182, 22);
            this.SceneAddNewTrace.Text = "&Add a New Trace";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFullScreen,
            this.toolStripMenuItem3,
            this.ViewPropertyGrid,
            this.ViewEntityTable});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ViewFullScreen
            // 
            this.ViewFullScreen.Image = global::ToyGraf.Properties.Resources.FullScreenHS;
            this.ViewFullScreen.ImageTransparentColor = System.Drawing.Color.White;
            this.ViewFullScreen.Name = "ViewFullScreen";
            this.ViewFullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.ViewFullScreen.Size = new System.Drawing.Size(156, 22);
            this.ViewFullScreen.Text = "&Full Screen";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(153, 6);
            // 
            // ViewPropertyGrid
            // 
            this.ViewPropertyGrid.Name = "ViewPropertyGrid";
            this.ViewPropertyGrid.Size = new System.Drawing.Size(156, 22);
            this.ViewPropertyGrid.Text = "Property Grid";
            // 
            // ViewEntityTable
            // 
            this.ViewEntityTable.Name = "ViewEntityTable";
            this.ViewEntityTable.Size = new System.Drawing.Size(156, 22);
            this.ViewEntityTable.Text = "Entity Table";
            // 
            // CameraMenu
            // 
            this.CameraMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraMove,
            this.CameraRotate,
            this.toolStripMenuItem11,
            this.CameraHome});
            this.CameraMenu.Name = "CameraMenu";
            this.CameraMenu.Size = new System.Drawing.Size(60, 20);
            this.CameraMenu.Text = "&Camera";
            // 
            // CameraMove
            // 
            this.CameraMove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraMoveLeft,
            this.CameraMoveRight,
            this.toolStripMenuItem4,
            this.CameraMoveUp,
            this.CameraMoveDown,
            this.toolStripMenuItem5,
            this.CameraMoveIn,
            this.CameraMoveOut});
            this.CameraMove.Name = "CameraMove";
            this.CameraMove.Size = new System.Drawing.Size(155, 22);
            this.CameraMove.Text = "&Move";
            // 
            // CameraMoveLeft
            // 
            this.CameraMoveLeft.Name = "CameraMoveLeft";
            this.CameraMoveLeft.ShortcutKeyDisplayString = "^Left";
            this.CameraMoveLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.CameraMoveLeft.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveLeft.Text = "&Left";
            // 
            // CameraMoveRight
            // 
            this.CameraMoveRight.Name = "CameraMoveRight";
            this.CameraMoveRight.ShortcutKeyDisplayString = "^Right";
            this.CameraMoveRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.CameraMoveRight.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveRight.Text = "&Right";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(170, 6);
            // 
            // CameraMoveUp
            // 
            this.CameraMoveUp.Name = "CameraMoveUp";
            this.CameraMoveUp.ShortcutKeyDisplayString = "^Up";
            this.CameraMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.CameraMoveUp.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveUp.Text = "&Up";
            // 
            // CameraMoveDown
            // 
            this.CameraMoveDown.Name = "CameraMoveDown";
            this.CameraMoveDown.ShortcutKeyDisplayString = "^Down";
            this.CameraMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.CameraMoveDown.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveDown.Text = "&Down";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(170, 6);
            // 
            // CameraMoveIn
            // 
            this.CameraMoveIn.Name = "CameraMoveIn";
            this.CameraMoveIn.ShortcutKeyDisplayString = "^PgUp";
            this.CameraMoveIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.PageUp)));
            this.CameraMoveIn.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveIn.Text = "Zoom &In";
            // 
            // CameraMoveOut
            // 
            this.CameraMoveOut.Name = "CameraMoveOut";
            this.CameraMoveOut.ShortcutKeyDisplayString = "^PgDn";
            this.CameraMoveOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Next)));
            this.CameraMoveOut.Size = new System.Drawing.Size(173, 22);
            this.CameraMoveOut.Text = "Zoom &Out";
            // 
            // CameraRotate
            // 
            this.CameraRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraRotateLeft,
            this.CameraRotateRight,
            this.toolStripMenuItem6,
            this.CameraRotateUp,
            this.CameraRotateDown,
            this.toolStripMenuItem7,
            this.CameraRotateAnticlockwise,
            this.CameraRotateClockwise});
            this.CameraRotate.Name = "CameraRotate";
            this.CameraRotate.Size = new System.Drawing.Size(155, 22);
            this.CameraRotate.Text = "&Rotate";
            // 
            // CameraRotateLeft
            // 
            this.CameraRotateLeft.Name = "CameraRotateLeft";
            this.CameraRotateLeft.ShortcutKeyDisplayString = "Shift+^Left";
            this.CameraRotateLeft.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Left)));
            this.CameraRotateLeft.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateLeft.Text = "&Left";
            // 
            // CameraRotateRight
            // 
            this.CameraRotateRight.Name = "CameraRotateRight";
            this.CameraRotateRight.ShortcutKeyDisplayString = "Shift+^Right";
            this.CameraRotateRight.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.CameraRotateRight.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateRight.Text = "&Right";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(220, 6);
            // 
            // CameraRotateUp
            // 
            this.CameraRotateUp.Name = "CameraRotateUp";
            this.CameraRotateUp.ShortcutKeyDisplayString = "Shift+^Up";
            this.CameraRotateUp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.CameraRotateUp.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateUp.Text = "&Up";
            // 
            // CameraRotateDown
            // 
            this.CameraRotateDown.Name = "CameraRotateDown";
            this.CameraRotateDown.ShortcutKeyDisplayString = "Shift+^Down";
            this.CameraRotateDown.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.CameraRotateDown.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateDown.Text = "&Down";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(220, 6);
            // 
            // CameraRotateAnticlockwise
            // 
            this.CameraRotateAnticlockwise.Name = "CameraRotateAnticlockwise";
            this.CameraRotateAnticlockwise.ShortcutKeyDisplayString = "Shift+^PgUp";
            this.CameraRotateAnticlockwise.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.PageUp)));
            this.CameraRotateAnticlockwise.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateAnticlockwise.Text = "&Anticlockwise";
            // 
            // CameraRotateClockwise
            // 
            this.CameraRotateClockwise.Name = "CameraRotateClockwise";
            this.CameraRotateClockwise.ShortcutKeyDisplayString = "Shift+^PgDn";
            this.CameraRotateClockwise.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Next)));
            this.CameraRotateClockwise.Size = new System.Drawing.Size(223, 22);
            this.CameraRotateClockwise.Text = "&Clockwise";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(152, 6);
            // 
            // CameraHome
            // 
            this.CameraHome.Name = "CameraHome";
            this.CameraHome.ShortcutKeyDisplayString = "^Home";
            this.CameraHome.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Home)));
            this.CameraHome.Size = new System.Drawing.Size(155, 22);
            this.CameraHome.Text = "&Home";
            // 
            // TimeMenu
            // 
            this.TimeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeDecelerate,
            this.TimeReverse,
            this.TimeStop,
            this.TimePause,
            this.TimeForward,
            this.TimeAccelerate});
            this.TimeMenu.Name = "TimeMenu";
            this.TimeMenu.Size = new System.Drawing.Size(46, 20);
            this.TimeMenu.Text = "&Time";
            // 
            // TimeDecelerate
            // 
            this.TimeDecelerate.Image = global::ToyGraf.Properties.Resources.RewindHS;
            this.TimeDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeDecelerate.Name = "TimeDecelerate";
            this.TimeDecelerate.Size = new System.Drawing.Size(129, 22);
            this.TimeDecelerate.Text = "&Decelerate";
            // 
            // TimeReverse
            // 
            this.TimeReverse.Image = global::ToyGraf.Properties.Resources.BackHS;
            this.TimeReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeReverse.Name = "TimeReverse";
            this.TimeReverse.Size = new System.Drawing.Size(129, 22);
            this.TimeReverse.Text = "&Reverse";
            // 
            // TimeStop
            // 
            this.TimeStop.Image = global::ToyGraf.Properties.Resources.StopHS;
            this.TimeStop.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeStop.Name = "TimeStop";
            this.TimeStop.Size = new System.Drawing.Size(129, 22);
            this.TimeStop.Text = "&Stop";
            this.TimeStop.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // TimePause
            // 
            this.TimePause.Image = global::ToyGraf.Properties.Resources.PauseHS;
            this.TimePause.ImageTransparentColor = System.Drawing.Color.White;
            this.TimePause.Name = "TimePause";
            this.TimePause.Size = new System.Drawing.Size(129, 22);
            this.TimePause.Text = "&Pause";
            // 
            // TimeForward
            // 
            this.TimeForward.Image = global::ToyGraf.Properties.Resources.PlayHS;
            this.TimeForward.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeForward.Name = "TimeForward";
            this.TimeForward.Size = new System.Drawing.Size(129, 22);
            this.TimeForward.Text = "&Forward";
            // 
            // TimeAccelerate
            // 
            this.TimeAccelerate.Image = global::ToyGraf.Properties.Resources.FFwdHS;
            this.TimeAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeAccelerate.Name = "TimeAccelerate";
            this.TimeAccelerate.Size = new System.Drawing.Size(129, 22);
            this.TimeAccelerate.Text = "&Accelerate";
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            // 
            // HelpAbout
            // 
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.Size = new System.Drawing.Size(107, 22);
            this.HelpAbout.Text = "&About";
            // 
            // SceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SceneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Telemetry";
            this.ToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.PerformLayout();
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.PopupPropertyGridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntityTable)).EndInit();
            this.PopupEntityTableMenu.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal OpenTK.GLControl GLControl;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal ToyGraf.Controls.TgMenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal ToyGraf.Controls.TgToolStrip Toolbar;
        internal System.Windows.Forms.ToolStripSplitButton tbNew;
        internal System.Windows.Forms.ToolStripSplitButton tbOpen;
        internal ToyGraf.Controls.TgStatusStrip StatusBar;
        internal System.Windows.Forms.ToolStripMenuItem FileNew;
        internal System.Windows.Forms.ToolStripMenuItem FileOpen;
        internal System.Windows.Forms.ToolStripMenuItem FileSave;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem FileExit;
        internal System.Windows.Forms.ToolStripMenuItem ViewFullScreen;
        internal System.Windows.Forms.ToolStripMenuItem HelpAbout;
        internal System.Windows.Forms.ToolStripMenuItem FileReopen;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem FileClose;
        internal System.Windows.Forms.ToolStripMenuItem FileNewEmptyScene;
        internal System.Windows.Forms.ToolStripMenuItem FileNewFromTemplate;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.ContextMenuStrip PopupPropertyGridMenu;
        internal System.Windows.Forms.ToolStripMenuItem PopupPropertyGridFloat;
        internal System.Windows.Forms.ToolStripMenuItem PopupPropertyGridHide;
        internal System.Windows.Forms.ContextMenuStrip PopupEntityTableMenu;
        internal System.Windows.Forms.ToolStripMenuItem PopupEntityTableFloat;
        internal System.Windows.Forms.ToolStripMenuItem PopupEntityTableHide;
        internal System.Windows.Forms.PropertyGrid PropertyGrid;
        internal System.Windows.Forms.DataGridView EntityTable;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem ViewPropertyGrid;
        internal System.Windows.Forms.ToolStripMenuItem ViewEntityTable;
        internal System.Windows.Forms.ToolStripMenuItem CameraMenu;
        internal System.Windows.Forms.ToolStripMenuItem CameraMove;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveLeft;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveRight;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveUp;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveDown;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveIn;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveOut;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotate;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateLeft;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateRight;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateUp;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateDown;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateClockwise;
        internal System.Windows.Forms.ToolStripMenuItem CameraRotateAnticlockwise;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        internal System.Windows.Forms.ToolStripMenuItem EditUndo;
        internal System.Windows.Forms.ToolStripMenuItem EditRedo;
        internal System.Windows.Forms.ToolStripMenuItem tbNewEmptyScene;
        internal System.Windows.Forms.ToolStripMenuItem tbNewFromTemplate;
        internal System.Windows.Forms.ToolStripButton tbSave;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripSplitButton tbUndo;
        internal System.Windows.Forms.ToolStripSplitButton tbRedo;
        internal System.Windows.Forms.ToolStripButton tbCut;
        internal System.Windows.Forms.ToolStripButton tbCopy;
        internal System.Windows.Forms.ToolStripButton tbPaste;
        internal System.Windows.Forms.ToolStripButton tbDelete;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        internal System.Windows.Forms.ToolStripMenuItem EditCut;
        internal System.Windows.Forms.ToolStripMenuItem EditCopy;
        internal System.Windows.Forms.ToolStripMenuItem EditPaste;
        internal System.Windows.Forms.ToolStripMenuItem EditDelete;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        internal System.Windows.Forms.ToolStripMenuItem EditSelectAll;
        internal System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        internal System.Windows.Forms.ToolStripMenuItem EditOptions;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton tbAdd;
        internal System.Windows.Forms.ToolStripMenuItem SceneMenu;
        internal System.Windows.Forms.ToolStripMenuItem TimeMenu;
        internal System.Windows.Forms.ToolStripMenuItem SceneAddNewTrace;
        internal System.Windows.Forms.ToolStripMenuItem TimeDecelerate;
        internal System.Windows.Forms.ToolStripMenuItem TimeReverse;
        internal System.Windows.Forms.ToolStripMenuItem TimeStop;
        internal System.Windows.Forms.ToolStripMenuItem TimePause;
        internal System.Windows.Forms.ToolStripMenuItem TimeForward;
        internal System.Windows.Forms.ToolStripMenuItem TimeAccelerate;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        internal System.Windows.Forms.ToolStripMenuItem CameraHome;
        internal System.Windows.Forms.ToolStripDropDownButton tbDecelerate;
        internal System.Windows.Forms.ToolStripDropDownButton tbReverse;
        internal System.Windows.Forms.ToolStripDropDownButton tbStop;
        internal System.Windows.Forms.ToolStripDropDownButton tbPause;
        internal System.Windows.Forms.ToolStripDropDownButton tbForward;
        internal System.Windows.Forms.ToolStripDropDownButton tbAccelerate;
        internal System.Windows.Forms.ToolStripStatusLabel SpeedLabel;
        internal System.Windows.Forms.ToolStripStatusLabel TimeLabel;
        internal System.Windows.Forms.ToolStripStatusLabel FpsLabel;
    }
}
