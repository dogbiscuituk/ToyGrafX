namespace ToyGraf.Views
{
    partial class FctbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FctbForm));
            this.SecondaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.PrimaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOK = new System.Windows.Forms.ToolStripDropDownButton();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.SecondarySplitter = new System.Windows.Forms.SplitContainer();
            this.SecondaryRuler = new FastColoredTextBoxNS.Ruler();
            this.SecondaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.PrimarySplitter = new System.Windows.Forms.SplitContainer();
            this.PrimaryRuler = new FastColoredTextBoxNS.Ruler();
            this.PrimaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.EditReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.EditComment = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUncomment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditIncreaseIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDecreaseIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewDocumentMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSplitHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSplitVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.ToolStripDropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).BeginInit();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitter)).BeginInit();
            this.SecondarySplitter.Panel1.SuspendLayout();
            this.SecondarySplitter.Panel2.SuspendLayout();
            this.SecondarySplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrimarySplitter)).BeginInit();
            this.PrimarySplitter.Panel1.SuspendLayout();
            this.PrimarySplitter.Panel2.SuspendLayout();
            this.PrimarySplitter.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SecondaryTextBox
            // 
            this.SecondaryTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.SecondaryTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.SecondaryTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.SecondaryTextBox.BackBrush = null;
            this.SecondaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.SecondaryTextBox.CharHeight = 14;
            this.SecondaryTextBox.CharWidth = 8;
            this.SecondaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecondaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SecondaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.SecondaryTextBox.IsReplaceMode = false;
            this.SecondaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.SecondaryTextBox.LeftBracket = '(';
            this.SecondaryTextBox.LeftBracket2 = '{';
            this.SecondaryTextBox.Location = new System.Drawing.Point(0, 24);
            this.SecondaryTextBox.Name = "SecondaryTextBox";
            this.SecondaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.SecondaryTextBox.RightBracket = ')';
            this.SecondaryTextBox.RightBracket2 = '}';
            this.SecondaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.SecondaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("SecondaryTextBox.ServiceColors")));
            this.SecondaryTextBox.ShowFoldingLines = true;
            this.SecondaryTextBox.ShowLineNumbers = false;
            this.SecondaryTextBox.Size = new System.Drawing.Size(500, 99);
            this.SecondaryTextBox.SourceTextBox = this.PrimaryTextBox;
            this.SecondaryTextBox.TabIndex = 1;
            this.SecondaryTextBox.Zoom = 100;
            // 
            // PrimaryTextBox
            // 
            this.PrimaryTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.PrimaryTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.PrimaryTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.PrimaryTextBox.BackBrush = null;
            this.PrimaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.PrimaryTextBox.CharHeight = 14;
            this.PrimaryTextBox.CharWidth = 8;
            this.PrimaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PrimaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.PrimaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.PrimaryTextBox.IsReplaceMode = false;
            this.PrimaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.PrimaryTextBox.LeftBracket = '(';
            this.PrimaryTextBox.LeftBracket2 = '{';
            this.PrimaryTextBox.Location = new System.Drawing.Point(0, 24);
            this.PrimaryTextBox.Name = "PrimaryTextBox";
            this.PrimaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.PrimaryTextBox.RightBracket = ')';
            this.PrimaryTextBox.RightBracket2 = '}';
            this.PrimaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.PrimaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("PrimaryTextBox.ServiceColors")));
            this.PrimaryTextBox.ShowFoldingLines = true;
            this.PrimaryTextBox.ShowLineNumbers = false;
            this.PrimaryTextBox.Size = new System.Drawing.Size(500, 244);
            this.PrimaryTextBox.TabIndex = 2;
            this.PrimaryTextBox.Zoom = 100;
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
            this.ToolStripContainer.ContentPanel.Controls.Add(this.Splitter);
            this.ToolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(624, 395);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(624, 441);
            this.ToolStripContainer.TabIndex = 8;
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
            this.btnApply,
            this.btnCancel,
            this.btnOK});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBar.Size = new System.Drawing.Size(624, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowDropDownArrow = false;
            this.btnCancel.Size = new System.Drawing.Size(47, 20);
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.ShowDropDownArrow = false;
            this.btnOK.Size = new System.Drawing.Size(27, 20);
            this.btnOK.Text = "OK";
            // 
            // Splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(4, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.SecondarySplitter);
            this.Splitter.Panel1MinSize = 0;
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.PrimarySplitter);
            this.Splitter.Panel2MinSize = 0;
            this.Splitter.Size = new System.Drawing.Size(616, 395);
            this.Splitter.SplitterDistance = 123;
            this.Splitter.TabIndex = 2;
            // 
            // SecondarySplitter
            // 
            this.SecondarySplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondarySplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SecondarySplitter.Location = new System.Drawing.Point(0, 0);
            this.SecondarySplitter.Name = "SecondarySplitter";
            // 
            // SecondarySplitter.Panel1
            // 
            this.SecondarySplitter.Panel1.Controls.Add(this.SecondaryTextBox);
            this.SecondarySplitter.Panel1.Controls.Add(this.SecondaryRuler);
            // 
            // SecondarySplitter.Panel2
            // 
            this.SecondarySplitter.Panel2.Controls.Add(this.SecondaryMap);
            this.SecondarySplitter.Size = new System.Drawing.Size(616, 123);
            this.SecondarySplitter.SplitterDistance = 500;
            this.SecondarySplitter.TabIndex = 5;
            // 
            // SecondaryRuler
            // 
            this.SecondaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondaryRuler.Location = new System.Drawing.Point(0, 0);
            this.SecondaryRuler.MaximumSize = new System.Drawing.Size(1252698752, 28);
            this.SecondaryRuler.MinimumSize = new System.Drawing.Size(0, 24);
            this.SecondaryRuler.Name = "SecondaryRuler";
            this.SecondaryRuler.Size = new System.Drawing.Size(500, 24);
            this.SecondaryRuler.TabIndex = 4;
            this.SecondaryRuler.Target = this.SecondaryTextBox;
            this.SecondaryRuler.Visible = false;
            // 
            // SecondaryMap
            // 
            this.SecondaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.SecondaryMap.Location = new System.Drawing.Point(0, 0);
            this.SecondaryMap.Name = "SecondaryMap";
            this.SecondaryMap.Size = new System.Drawing.Size(112, 123);
            this.SecondaryMap.TabIndex = 0;
            this.SecondaryMap.Target = this.SecondaryTextBox;
            this.SecondaryMap.Text = "documentMap1";
            // 
            // PrimarySplitter
            // 
            this.PrimarySplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimarySplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.PrimarySplitter.Location = new System.Drawing.Point(0, 0);
            this.PrimarySplitter.Name = "PrimarySplitter";
            // 
            // PrimarySplitter.Panel1
            // 
            this.PrimarySplitter.Panel1.Controls.Add(this.PrimaryTextBox);
            this.PrimarySplitter.Panel1.Controls.Add(this.PrimaryRuler);
            // 
            // PrimarySplitter.Panel2
            // 
            this.PrimarySplitter.Panel2.Controls.Add(this.PrimaryMap);
            this.PrimarySplitter.Size = new System.Drawing.Size(616, 268);
            this.PrimarySplitter.SplitterDistance = 500;
            this.PrimarySplitter.TabIndex = 4;
            // 
            // PrimaryRuler
            // 
            this.PrimaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrimaryRuler.Location = new System.Drawing.Point(0, 0);
            this.PrimaryRuler.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.PrimaryRuler.MinimumSize = new System.Drawing.Size(0, 24);
            this.PrimaryRuler.Name = "PrimaryRuler";
            this.PrimaryRuler.Size = new System.Drawing.Size(500, 24);
            this.PrimaryRuler.TabIndex = 3;
            this.PrimaryRuler.Target = this.PrimaryTextBox;
            this.PrimaryRuler.Visible = false;
            // 
            // PrimaryMap
            // 
            this.PrimaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.PrimaryMap.Location = new System.Drawing.Point(0, 0);
            this.PrimaryMap.Name = "PrimaryMap";
            this.PrimaryMap.Size = new System.Drawing.Size(112, 268);
            this.PrimaryMap.TabIndex = 0;
            this.PrimaryMap.Target = this.PrimaryTextBox;
            this.PrimaryMap.Text = "documentMap2";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExport,
            this.FilePrint});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileExport
            // 
            this.FileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExportHTML,
            this.FileExportRTF});
            this.FileExport.Name = "FileExport";
            this.FileExport.ShortcutKeyDisplayString = "";
            this.FileExport.Size = new System.Drawing.Size(130, 22);
            this.FileExport.Text = "&Export";
            // 
            // FileExportHTML
            // 
            this.FileExportHTML.Name = "FileExportHTML";
            this.FileExportHTML.Size = new System.Drawing.Size(115, 22);
            this.FileExportHTML.Text = "&HTML...";
            // 
            // FileExportRTF
            // 
            this.FileExportRTF.Name = "FileExportRTF";
            this.FileExportRTF.Size = new System.Drawing.Size(115, 22);
            this.FileExportRTF.Text = "&RTF...";
            // 
            // FilePrint
            // 
            this.FilePrint.Name = "FilePrint";
            this.FilePrint.ShortcutKeyDisplayString = "^P";
            this.FilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.FilePrint.Size = new System.Drawing.Size(130, 22);
            this.FilePrint.Text = "&Print...";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditFind,
            this.EditReplace,
            this.toolStripMenuItem4,
            this.EditComment,
            this.EditUncomment,
            this.toolStripMenuItem1,
            this.EditIncreaseIndent,
            this.EditDecreaseIndent});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // EditFind
            // 
            this.EditFind.Name = "EditFind";
            this.EditFind.ShortcutKeyDisplayString = "^F";
            this.EditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.EditFind.Size = new System.Drawing.Size(158, 22);
            this.EditFind.Text = "&Find...";
            // 
            // EditReplace
            // 
            this.EditReplace.Name = "EditReplace";
            this.EditReplace.ShortcutKeyDisplayString = "^H";
            this.EditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.EditReplace.Size = new System.Drawing.Size(158, 22);
            this.EditReplace.Text = "&Replace...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 6);
            // 
            // EditComment
            // 
            this.EditComment.Name = "EditComment";
            this.EditComment.Size = new System.Drawing.Size(158, 22);
            this.EditComment.Text = "&Comment";
            // 
            // EditUncomment
            // 
            this.EditUncomment.Name = "EditUncomment";
            this.EditUncomment.Size = new System.Drawing.Size(158, 22);
            this.EditUncomment.Text = "&Uncomment";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // EditIncreaseIndent
            // 
            this.EditIncreaseIndent.Name = "EditIncreaseIndent";
            this.EditIncreaseIndent.ShortcutKeyDisplayString = "";
            this.EditIncreaseIndent.Size = new System.Drawing.Size(158, 22);
            this.EditIncreaseIndent.Text = "&Increase Indent";
            // 
            // EditDecreaseIndent
            // 
            this.EditDecreaseIndent.Name = "EditDecreaseIndent";
            this.EditDecreaseIndent.ShortcutKeyDisplayString = "";
            this.EditDecreaseIndent.Size = new System.Drawing.Size(158, 22);
            this.EditDecreaseIndent.Text = "&Decrease Indent";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewRuler,
            this.ViewLineNumbers,
            this.ViewDocumentMap,
            this.toolStripMenuItem2,
            this.ViewSplit});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ViewRuler
            // 
            this.ViewRuler.Name = "ViewRuler";
            this.ViewRuler.Size = new System.Drawing.Size(157, 22);
            this.ViewRuler.Text = "&Ruler";
            // 
            // ViewLineNumbers
            // 
            this.ViewLineNumbers.Name = "ViewLineNumbers";
            this.ViewLineNumbers.Size = new System.Drawing.Size(157, 22);
            this.ViewLineNumbers.Text = "&Line Numbers";
            // 
            // ViewDocumentMap
            // 
            this.ViewDocumentMap.Name = "ViewDocumentMap";
            this.ViewDocumentMap.Size = new System.Drawing.Size(157, 22);
            this.ViewDocumentMap.Text = "&Document Map";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // ViewSplit
            // 
            this.ViewSplit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewSplitHorizontal,
            this.ViewSplitVertical});
            this.ViewSplit.Name = "ViewSplit";
            this.ViewSplit.Size = new System.Drawing.Size(157, 22);
            this.ViewSplit.Text = "&Split";
            // 
            // ViewSplitHorizontal
            // 
            this.ViewSplitHorizontal.Name = "ViewSplitHorizontal";
            this.ViewSplitHorizontal.Size = new System.Drawing.Size(129, 22);
            this.ViewSplitHorizontal.Text = "&Horizontal";
            // 
            // ViewSplitVertical
            // 
            this.ViewSplitVertical.Name = "ViewSplitVertical";
            this.ViewSplitVertical.Size = new System.Drawing.Size(129, 22);
            this.ViewSplitVertical.Text = "&Vertical";
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            // 
            // btnApply
            // 
            this.btnApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApply.Name = "btnApply";
            this.btnApply.ShowDropDownArrow = false;
            this.btnApply.Size = new System.Drawing.Size(42, 20);
            this.btnApply.Text = "Apply";
            // 
            // FctbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.MinimizeBox = false;
            this.Name = "FctbForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).EndInit();
            this.ToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.SecondarySplitter.Panel1.ResumeLayout(false);
            this.SecondarySplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitter)).EndInit();
            this.SecondarySplitter.ResumeLayout(false);
            this.PrimarySplitter.Panel1.ResumeLayout(false);
            this.PrimarySplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrimarySplitter)).EndInit();
            this.PrimarySplitter.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal FastColoredTextBoxNS.FastColoredTextBox SecondaryTextBox;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal System.Windows.Forms.MenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal System.Windows.Forms.StatusStrip StatusBar;
        internal System.Windows.Forms.ToolStripDropDownButton btnCancel;
        internal System.Windows.Forms.ToolStripDropDownButton btnOK;
        internal System.Windows.Forms.ToolStripMenuItem FileExport;
        internal System.Windows.Forms.ToolStripMenuItem FileExportHTML;
        internal System.Windows.Forms.ToolStripMenuItem FileExportRTF;
        internal System.Windows.Forms.ToolStripMenuItem FilePrint;
        internal System.Windows.Forms.ToolStripMenuItem EditFind;
        internal System.Windows.Forms.ToolStripMenuItem EditReplace;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem EditComment;
        internal System.Windows.Forms.ToolStripMenuItem EditUncomment;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem EditIncreaseIndent;
        internal System.Windows.Forms.ToolStripMenuItem EditDecreaseIndent;
        internal System.Windows.Forms.SplitContainer Splitter;
        internal FastColoredTextBoxNS.FastColoredTextBox PrimaryTextBox;
        internal FastColoredTextBoxNS.Ruler PrimaryRuler;
        internal FastColoredTextBoxNS.Ruler SecondaryRuler;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem ViewRuler;
        internal System.Windows.Forms.ToolStripMenuItem ViewLineNumbers;
        internal System.Windows.Forms.ToolStripMenuItem ViewSplit;
        internal System.Windows.Forms.ToolStripMenuItem ViewSplitHorizontal;
        internal System.Windows.Forms.ToolStripMenuItem ViewSplitVertical;
        internal System.Windows.Forms.SplitContainer SecondarySplitter;
        internal FastColoredTextBoxNS.DocumentMap SecondaryMap;
        internal System.Windows.Forms.SplitContainer PrimarySplitter;
        internal FastColoredTextBoxNS.DocumentMap PrimaryMap;
        internal System.Windows.Forms.ToolStripMenuItem ViewDocumentMap;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripDropDownButton btnApply;
    }
}