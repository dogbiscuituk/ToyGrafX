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
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.SecondarySplitter = new System.Windows.Forms.SplitContainer();
            this.SecondaryRuler = new FastColoredTextBoxNS.Ruler();
            this.SecondaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.PrimarySplitter = new System.Windows.Forms.SplitContainer();
            this.PrimaryRuler = new FastColoredTextBoxNS.Ruler();
            this.PrimaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.ToolStrip = new ToyGraf.Controls.TgToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripDropDownButton();
            this.FileExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.ViewRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewDocumentMap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).BeginInit();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
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
            this.ToolStrip.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
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
            this.SecondaryTextBox.Size = new System.Drawing.Size(500, 93);
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
            this.PrimaryTextBox.Size = new System.Drawing.Size(500, 231);
            this.PrimaryTextBox.TabIndex = 2;
            this.PrimaryTextBox.Zoom = 100;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.Splitter);
            this.ToolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(624, 376);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(624, 401);
            this.ToolStripContainer.TabIndex = 8;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.ToolStrip);
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
            this.Splitter.Size = new System.Drawing.Size(616, 376);
            this.Splitter.SplitterDistance = 117;
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
            this.SecondarySplitter.Size = new System.Drawing.Size(616, 117);
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
            this.SecondaryMap.Size = new System.Drawing.Size(112, 117);
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
            this.PrimarySplitter.Size = new System.Drawing.Size(616, 255);
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
            this.PrimaryMap.Size = new System.Drawing.Size(112, 255);
            this.PrimaryMap.TabIndex = 0;
            this.PrimaryMap.Target = this.PrimaryTextBox;
            this.PrimaryMap.Text = "documentMap2";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.btnPrint,
            this.btnOptions,
            this.btnSplit,
            this.btnHelp});
            this.ToolStrip.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(139, 25);
            this.ToolStrip.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExportHTML,
            this.FileExportRTF});
            this.btnExport.Image = global::ToyGraf.Properties.Resources.saveHS;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(29, 22);
            this.btnExport.ToolTipText = "Export";
            // 
            // FileExportHTML
            // 
            this.FileExportHTML.Name = "FileExportHTML";
            this.FileExportHTML.Size = new System.Drawing.Size(180, 22);
            this.FileExportHTML.Text = "Export as &HTML...";
            // 
            // FileExportRTF
            // 
            this.FileExportRTF.Name = "FileExportRTF";
            this.FileExportRTF.Size = new System.Drawing.Size(180, 22);
            this.FileExportRTF.Text = "Export as &RTF...";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::ToyGraf.Properties.Resources.PrintHS;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            // 
            // btnOptions
            // 
            this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewRuler,
            this.ViewLineNumbers,
            this.ViewDocumentMap});
            this.btnOptions.Image = global::ToyGraf.Properties.Resources.OptionsHS;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(29, 22);
            this.btnOptions.ToolTipText = "Options";
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
            // btnSplit
            // 
            this.btnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSplit.Image = global::ToyGraf.Properties.Resources.TileWindowsHorizontallyHS;
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(23, 22);
            this.btnSplit.ToolTipText = "Split";
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::ToyGraf.Properties.Resources.info;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.ToolTipText = "Help";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.btnApply);
            this.ButtonPanel.Controls.Add(this.btnCancel);
            this.ButtonPanel.Controls.Add(this.btnOK);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 401);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(624, 40);
            this.ButtonPanel.TabIndex = 9;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(537, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(456, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(375, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FctbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ToolStripContainer);
            this.Controls.Add(this.ButtonPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "FctbForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).EndInit();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
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
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal FastColoredTextBoxNS.FastColoredTextBox SecondaryTextBox;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal System.Windows.Forms.SplitContainer Splitter;
        internal FastColoredTextBoxNS.FastColoredTextBox PrimaryTextBox;
        internal FastColoredTextBoxNS.Ruler PrimaryRuler;
        internal FastColoredTextBoxNS.Ruler SecondaryRuler;
        internal System.Windows.Forms.SplitContainer SecondarySplitter;
        internal FastColoredTextBoxNS.DocumentMap SecondaryMap;
        internal System.Windows.Forms.SplitContainer PrimarySplitter;
        internal FastColoredTextBoxNS.DocumentMap PrimaryMap;
        internal Controls.TgToolStrip ToolStrip;
        internal System.Windows.Forms.ToolStripDropDownButton btnExport;
        internal System.Windows.Forms.ToolStripMenuItem FileExportHTML;
        internal System.Windows.Forms.ToolStripMenuItem FileExportRTF;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripDropDownButton btnOptions;
        internal System.Windows.Forms.ToolStripMenuItem ViewRuler;
        internal System.Windows.Forms.ToolStripMenuItem ViewLineNumbers;
        internal System.Windows.Forms.ToolStripMenuItem ViewDocumentMap;
        internal System.Windows.Forms.ToolStripButton btnSplit;
        internal System.Windows.Forms.Panel ButtonPanel;
        internal System.Windows.Forms.Button btnApply;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.ToolStripButton btnHelp;
    }
}