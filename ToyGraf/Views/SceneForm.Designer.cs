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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneForm));
            this.GLControl = new OpenTK.GLControl();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new ToyGraf.Controls.TgStatusStrip();
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
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
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
            this.GLControl.Size = new System.Drawing.Size(803, 428);
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
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(971, 494);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(1004, 540);
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
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1004, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
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
            this.SplitContainer1.Size = new System.Drawing.Size(971, 494);
            this.SplitContainer1.SplitterDistance = 428;
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
            this.SplitContainer2.Size = new System.Drawing.Size(971, 428);
            this.SplitContainer2.SplitterDistance = 803;
            this.SplitContainer2.SplitterWidth = 5;
            this.SplitContainer2.TabIndex = 0;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.ContextMenuStrip = this.PopupPropertyGridMenu;
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(163, 428);
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
            this.EntityTable.Size = new System.Drawing.Size(971, 61);
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
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 57);
            this.Toolbar.TabIndex = 2;
            this.Toolbar.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(31, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(31, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.CameraMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1004, 24);
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
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeyDisplayString = "";
            this.FileNew.Size = new System.Drawing.Size(136, 22);
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
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(136, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(136, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(136, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(136, 22);
            this.FileSaveAs.Text = "&Save As...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(136, 22);
            this.FileClose.Text = "&Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(136, 22);
            this.FileExit.Text = "E&xit";
            // 
            // EditMenu
            // 
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
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
            this.CameraRotate});
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
            this.CameraMove.Size = new System.Drawing.Size(108, 22);
            this.CameraMove.Text = "Move";
            // 
            // CameraMoveLeft
            // 
            this.CameraMoveLeft.Name = "CameraMoveLeft";
            this.CameraMoveLeft.ShortcutKeyDisplayString = "^Left";
            this.CameraMoveLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.CameraMoveLeft.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveLeft.Text = "&Left";
            // 
            // CameraMoveRight
            // 
            this.CameraMoveRight.Name = "CameraMoveRight";
            this.CameraMoveRight.ShortcutKeyDisplayString = "^Right";
            this.CameraMoveRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.CameraMoveRight.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveRight.Text = "&Right";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 6);
            // 
            // CameraMoveUp
            // 
            this.CameraMoveUp.Name = "CameraMoveUp";
            this.CameraMoveUp.ShortcutKeyDisplayString = "^Up";
            this.CameraMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.CameraMoveUp.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveUp.Text = "&Up";
            // 
            // CameraMoveDown
            // 
            this.CameraMoveDown.Name = "CameraMoveDown";
            this.CameraMoveDown.ShortcutKeyDisplayString = "^Down";
            this.CameraMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.CameraMoveDown.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveDown.Text = "&Down";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(148, 6);
            // 
            // CameraMoveIn
            // 
            this.CameraMoveIn.Name = "CameraMoveIn";
            this.CameraMoveIn.ShortcutKeyDisplayString = "^PgUp";
            this.CameraMoveIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.PageUp)));
            this.CameraMoveIn.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveIn.Text = "&In";
            // 
            // CameraMoveOut
            // 
            this.CameraMoveOut.Name = "CameraMoveOut";
            this.CameraMoveOut.ShortcutKeyDisplayString = "^PgDn";
            this.CameraMoveOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Next)));
            this.CameraMoveOut.Size = new System.Drawing.Size(151, 22);
            this.CameraMoveOut.Text = "&Out";
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
            this.CameraRotate.Size = new System.Drawing.Size(108, 22);
            this.CameraRotate.Text = "Rotate";
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
            this.ClientSize = new System.Drawing.Size(1004, 540);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SceneForm";
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
        internal System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        internal System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    }
}

