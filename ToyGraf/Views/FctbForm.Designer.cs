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
            this.TextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupFind = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSaveAsHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSaveAsRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.AutoCompleteBracketsList = new char[] {
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
            this.TextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.TextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox.BackBrush = null;
            this.TextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.TextBox.CharHeight = 14;
            this.TextBox.CharWidth = 8;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox.IsReplaceMode = false;
            this.TextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.TextBox.LeftBracket = '(';
            this.TextBox.LeftBracket2 = '{';
            this.TextBox.Location = new System.Drawing.Point(12, 12);
            this.TextBox.Name = "TextBox";
            this.TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox.RightBracket = ')';
            this.TextBox.RightBracket2 = '}';
            this.TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox.ServiceColors")));
            this.TextBox.ShowFoldingLines = true;
            this.TextBox.Size = new System.Drawing.Size(600, 388);
            this.TextBox.TabIndex = 1;
            this.TextBox.Zoom = 100;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(537, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(456, 406);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupSaveAs,
            this.PopupPrint,
            this.toolStripMenuItem1,
            this.PopupFind,
            this.PopupReplace});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(181, 120);
            // 
            // PopupFind
            // 
            this.PopupFind.Name = "PopupFind";
            this.PopupFind.ShortcutKeyDisplayString = "^F";
            this.PopupFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.PopupFind.Size = new System.Drawing.Size(180, 22);
            this.PopupFind.Text = "&Find...";
            this.PopupFind.Click += new System.EventHandler(this.PopupFind_Click);
            // 
            // PopupReplace
            // 
            this.PopupReplace.Name = "PopupReplace";
            this.PopupReplace.ShortcutKeyDisplayString = "^H";
            this.PopupReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.PopupReplace.Size = new System.Drawing.Size(180, 22);
            this.PopupReplace.Text = "&Replace...";
            this.PopupReplace.Click += new System.EventHandler(this.PopupReplace_Click);
            // 
            // PopupPrint
            // 
            this.PopupPrint.Name = "PopupPrint";
            this.PopupPrint.ShortcutKeyDisplayString = "^P";
            this.PopupPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PopupPrint.Size = new System.Drawing.Size(180, 22);
            this.PopupPrint.Text = "&Print...";
            this.PopupPrint.Click += new System.EventHandler(this.PopupPrint_Click);
            // 
            // PopupSaveAs
            // 
            this.PopupSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupSaveAsHTML,
            this.PopupSaveAsRTF});
            this.PopupSaveAs.Name = "PopupSaveAs";
            this.PopupSaveAs.ShortcutKeyDisplayString = "";
            this.PopupSaveAs.Size = new System.Drawing.Size(180, 22);
            this.PopupSaveAs.Text = "&Save as";
            // 
            // PopupSaveAsHTML
            // 
            this.PopupSaveAsHTML.Name = "PopupSaveAsHTML";
            this.PopupSaveAsHTML.Size = new System.Drawing.Size(180, 22);
            this.PopupSaveAsHTML.Text = "&HTML...";
            this.PopupSaveAsHTML.Click += new System.EventHandler(this.PopupSaveAsHTML_Click);
            // 
            // PopupSaveAsRTF
            // 
            this.PopupSaveAsRTF.Name = "PopupSaveAsRTF";
            this.PopupSaveAsRTF.Size = new System.Drawing.Size(180, 22);
            this.PopupSaveAsRTF.Text = "&RTF...";
            this.PopupSaveAsRTF.Click += new System.EventHandler(this.PopupSaveAsRTF_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // FctbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.ContextMenuStrip = this.PopupMenu;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.TextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FctbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FctbForm";
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal FastColoredTextBoxNS.FastColoredTextBox TextBox;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.ContextMenuStrip PopupMenu;
        internal System.Windows.Forms.ToolStripMenuItem PopupFind;
        internal System.Windows.Forms.ToolStripMenuItem PopupReplace;
        internal System.Windows.Forms.ToolStripMenuItem PopupPrint;
        internal System.Windows.Forms.ToolStripMenuItem PopupSaveAs;
        internal System.Windows.Forms.ToolStripMenuItem PopupSaveAsHTML;
        internal System.Windows.Forms.ToolStripMenuItem PopupSaveAsRTF;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}