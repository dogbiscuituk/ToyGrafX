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
            this.TextBox2 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOK = new System.Windows.Forms.ToolStripDropDownButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox2
            // 
            this.TextBox2.AutoCompleteBracketsList = new char[] {
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
            this.TextBox2.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.TextBox2.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox2.BackBrush = null;
            this.TextBox2.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.TextBox2.CharHeight = 14;
            this.TextBox2.CharWidth = 8;
            this.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox2.IsReplaceMode = false;
            this.TextBox2.Language = FastColoredTextBoxNS.Language.CSharp;
            this.TextBox2.LeftBracket = '(';
            this.TextBox2.LeftBracket2 = '{';
            this.TextBox2.Location = new System.Drawing.Point(0, 0);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox2.RightBracket = ')';
            this.TextBox2.RightBracket2 = '}';
            this.TextBox2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox2.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox2.ServiceColors")));
            this.TextBox2.ShowFoldingLines = true;
            this.TextBox2.Size = new System.Drawing.Size(624, 0);
            this.TextBox2.SourceTextBox = this.TextBox1;
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Zoom = 100;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusBar);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(624, 395);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(624, 441);
            this.toolStripContainer1.TabIndex = 8;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainMenu);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TextBox2);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TextBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(624, 395);
            this.splitContainer1.SplitterDistance = 0;
            this.splitContainer1.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
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
            this.EditFind.Size = new System.Drawing.Size(216, 22);
            this.EditFind.Text = "&Find...";
            // 
            // EditReplace
            // 
            this.EditReplace.Name = "EditReplace";
            this.EditReplace.ShortcutKeyDisplayString = "^H";
            this.EditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.EditReplace.Size = new System.Drawing.Size(216, 22);
            this.EditReplace.Text = "&Replace...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(213, 6);
            // 
            // EditComment
            // 
            this.EditComment.Name = "EditComment";
            this.EditComment.Size = new System.Drawing.Size(216, 22);
            this.EditComment.Text = "&Comment";
            // 
            // EditUncomment
            // 
            this.EditUncomment.Name = "EditUncomment";
            this.EditUncomment.Size = new System.Drawing.Size(216, 22);
            this.EditUncomment.Text = "&Uncomment";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // EditIncreaseIndent
            // 
            this.EditIncreaseIndent.Name = "EditIncreaseIndent";
            this.EditIncreaseIndent.ShortcutKeyDisplayString = "Tab";
            this.EditIncreaseIndent.Size = new System.Drawing.Size(216, 22);
            this.EditIncreaseIndent.Text = "&Increase Indent";
            // 
            // EditDecreaseIndent
            // 
            this.EditDecreaseIndent.Name = "EditDecreaseIndent";
            this.EditDecreaseIndent.ShortcutKeyDisplayString = "Shift+Tab";
            this.EditDecreaseIndent.Size = new System.Drawing.Size(216, 22);
            this.EditDecreaseIndent.Text = "&Decrease Indent";
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            // 
            // TextBox1
            // 
            this.TextBox1.AutoCompleteBracketsList = new char[] {
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
            this.TextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.TextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox1.BackBrush = null;
            this.TextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.TextBox1.CharHeight = 14;
            this.TextBox1.CharWidth = 8;
            this.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.IsReplaceMode = false;
            this.TextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            this.TextBox1.LeftBracket = '(';
            this.TextBox1.LeftBracket2 = '{';
            this.TextBox1.Location = new System.Drawing.Point(0, 0);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox1.RightBracket = ')';
            this.TextBox1.RightBracket2 = '}';
            this.TextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox1.ServiceColors")));
            this.TextBox1.ShowFoldingLines = true;
            this.TextBox1.Size = new System.Drawing.Size(624, 391);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Zoom = 100;
            // 
            // FctbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.ContextMenuStrip = this.PopupMenu;
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FctbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal FastColoredTextBoxNS.FastColoredTextBox TextBox2;
        internal System.Windows.Forms.ContextMenuStrip PopupMenu;
        internal System.Windows.Forms.ToolStripContainer toolStripContainer1;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem EditIncreaseIndent;
        internal System.Windows.Forms.ToolStripMenuItem EditDecreaseIndent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal FastColoredTextBoxNS.FastColoredTextBox TextBox1;
    }
}