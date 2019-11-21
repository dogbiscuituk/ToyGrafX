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
            this.SlaveTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.MasterTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOK = new System.Windows.Forms.ToolStripDropDownButton();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.SlaveRuler = new FastColoredTextBoxNS.Ruler();
            this.MasterRuler = new FastColoredTextBoxNS.Ruler();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsRTF = new System.Windows.Forms.ToolStripMenuItem();
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
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterTextBox)).BeginInit();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SlaveTextBox
            // 
            this.SlaveTextBox.AutoCompleteBracketsList = new char[] {
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
            this.SlaveTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.SlaveTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.SlaveTextBox.BackBrush = null;
            this.SlaveTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.SlaveTextBox.CharHeight = 14;
            this.SlaveTextBox.CharWidth = 8;
            this.SlaveTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SlaveTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SlaveTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlaveTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.SlaveTextBox.IsReplaceMode = false;
            this.SlaveTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.SlaveTextBox.LeftBracket = '(';
            this.SlaveTextBox.LeftBracket2 = '{';
            this.SlaveTextBox.Location = new System.Drawing.Point(0, 28);
            this.SlaveTextBox.Name = "SlaveTextBox";
            this.SlaveTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.SlaveTextBox.RightBracket = ')';
            this.SlaveTextBox.RightBracket2 = '}';
            this.SlaveTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.SlaveTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("SlaveTextBox.ServiceColors")));
            this.SlaveTextBox.ShowFoldingLines = true;
            this.SlaveTextBox.ShowLineNumbers = false;
            this.SlaveTextBox.Size = new System.Drawing.Size(616, 95);
            this.SlaveTextBox.SourceTextBox = this.MasterTextBox;
            this.SlaveTextBox.TabIndex = 1;
            this.SlaveTextBox.Zoom = 100;
            // 
            // MasterTextBox
            // 
            this.MasterTextBox.AutoCompleteBracketsList = new char[] {
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
            this.MasterTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.MasterTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.MasterTextBox.BackBrush = null;
            this.MasterTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.MasterTextBox.CharHeight = 14;
            this.MasterTextBox.CharWidth = 8;
            this.MasterTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MasterTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.MasterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MasterTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.MasterTextBox.IsReplaceMode = false;
            this.MasterTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.MasterTextBox.LeftBracket = '(';
            this.MasterTextBox.LeftBracket2 = '{';
            this.MasterTextBox.Location = new System.Drawing.Point(0, 28);
            this.MasterTextBox.Name = "MasterTextBox";
            this.MasterTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.MasterTextBox.RightBracket = ')';
            this.MasterTextBox.RightBracket2 = '}';
            this.MasterTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MasterTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("MasterTextBox.ServiceColors")));
            this.MasterTextBox.ShowFoldingLines = true;
            this.MasterTextBox.ShowLineNumbers = false;
            this.MasterTextBox.Size = new System.Drawing.Size(616, 240);
            this.MasterTextBox.TabIndex = 2;
            this.MasterTextBox.Zoom = 100;
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
            this.ToolStripContainer.ContentPanel.Controls.Add(this.SplitContainer);
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
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(4, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.SlaveTextBox);
            this.SplitContainer.Panel1.Controls.Add(this.SlaveRuler);
            this.SplitContainer.Panel1MinSize = 0;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.MasterTextBox);
            this.SplitContainer.Panel2.Controls.Add(this.MasterRuler);
            this.SplitContainer.Panel2MinSize = 0;
            this.SplitContainer.Size = new System.Drawing.Size(616, 395);
            this.SplitContainer.SplitterDistance = 123;
            this.SplitContainer.TabIndex = 2;
            // 
            // SlaveRuler
            // 
            this.SlaveRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.SlaveRuler.Location = new System.Drawing.Point(0, 0);
            this.SlaveRuler.MaximumSize = new System.Drawing.Size(1461481856, 32);
            this.SlaveRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.SlaveRuler.Name = "SlaveRuler";
            this.SlaveRuler.Size = new System.Drawing.Size(616, 28);
            this.SlaveRuler.TabIndex = 4;
            this.SlaveRuler.Target = this.SlaveTextBox;
            this.SlaveRuler.Visible = false;
            // 
            // MasterRuler
            // 
            this.MasterRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterRuler.Location = new System.Drawing.Point(0, 0);
            this.MasterRuler.MaximumSize = new System.Drawing.Size(1252698752, 28);
            this.MasterRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.MasterRuler.Name = "MasterRuler";
            this.MasterRuler.Size = new System.Drawing.Size(616, 28);
            this.MasterRuler.TabIndex = 3;
            this.MasterRuler.Target = this.MasterTextBox;
            this.MasterRuler.Visible = false;
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
            this.FileSaveAs,
            this.FilePrint});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveAsHTML,
            this.FileSaveAsRTF});
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.ShortcutKeyDisplayString = "";
            this.FileSaveAs.Size = new System.Drawing.Size(130, 22);
            this.FileSaveAs.Text = "&Save as";
            // 
            // FileSaveAsHTML
            // 
            this.FileSaveAsHTML.Name = "FileSaveAsHTML";
            this.FileSaveAsHTML.Size = new System.Drawing.Size(116, 22);
            this.FileSaveAsHTML.Text = "&HTML...";
            // 
            // FileSaveAsRTF
            // 
            this.FileSaveAsRTF.Name = "FileSaveAsRTF";
            this.FileSaveAsRTF.Size = new System.Drawing.Size(116, 22);
            this.FileSaveAsRTF.Text = "&RTF...";
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
            this.EditFind.Size = new System.Drawing.Size(224, 22);
            this.EditFind.Text = "&Find...";
            // 
            // EditReplace
            // 
            this.EditReplace.Name = "EditReplace";
            this.EditReplace.ShortcutKeyDisplayString = "^H";
            this.EditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.EditReplace.Size = new System.Drawing.Size(224, 22);
            this.EditReplace.Text = "&Replace...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(221, 6);
            // 
            // EditComment
            // 
            this.EditComment.Name = "EditComment";
            this.EditComment.Size = new System.Drawing.Size(224, 22);
            this.EditComment.Text = "&Comment";
            // 
            // EditUncomment
            // 
            this.EditUncomment.Name = "EditUncomment";
            this.EditUncomment.Size = new System.Drawing.Size(224, 22);
            this.EditUncomment.Text = "&Uncomment";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // EditIncreaseIndent
            // 
            this.EditIncreaseIndent.Name = "EditIncreaseIndent";
            this.EditIncreaseIndent.ShortcutKeyDisplayString = "";
            this.EditIncreaseIndent.Size = new System.Drawing.Size(180, 22);
            this.EditIncreaseIndent.Text = "&Increase Indent";
            // 
            // EditDecreaseIndent
            // 
            this.EditDecreaseIndent.Name = "EditDecreaseIndent";
            this.EditDecreaseIndent.ShortcutKeyDisplayString = "";
            this.EditDecreaseIndent.Size = new System.Drawing.Size(180, 22);
            this.EditDecreaseIndent.Text = "&Decrease Indent";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewRuler,
            this.ViewLineNumbers});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ViewRuler
            // 
            this.ViewRuler.Name = "ViewRuler";
            this.ViewRuler.Size = new System.Drawing.Size(148, 22);
            this.ViewRuler.Text = "&Ruler";
            // 
            // ViewLineNumbers
            // 
            this.ViewLineNumbers.Name = "ViewLineNumbers";
            this.ViewLineNumbers.Size = new System.Drawing.Size(148, 22);
            this.ViewLineNumbers.Text = "&Line Numbers";
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
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
            ((System.ComponentModel.ISupportInitialize)(this.SlaveTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterTextBox)).EndInit();
            this.ToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal FastColoredTextBoxNS.FastColoredTextBox SlaveTextBox;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal System.Windows.Forms.MenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal System.Windows.Forms.StatusStrip StatusBar;
        internal System.Windows.Forms.ToolStripDropDownButton btnCancel;
        internal System.Windows.Forms.ToolStripDropDownButton btnOK;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAsHTML;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAsRTF;
        internal System.Windows.Forms.ToolStripMenuItem FilePrint;
        internal System.Windows.Forms.ToolStripMenuItem EditFind;
        internal System.Windows.Forms.ToolStripMenuItem EditReplace;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem EditComment;
        internal System.Windows.Forms.ToolStripMenuItem EditUncomment;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem EditIncreaseIndent;
        internal System.Windows.Forms.ToolStripMenuItem EditDecreaseIndent;
        internal System.Windows.Forms.SplitContainer SplitContainer;
        internal FastColoredTextBoxNS.FastColoredTextBox MasterTextBox;
        internal FastColoredTextBoxNS.Ruler MasterRuler;
        internal FastColoredTextBoxNS.Ruler SlaveRuler;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem ViewRuler;
        internal System.Windows.Forms.ToolStripMenuItem ViewLineNumbers;
    }
}