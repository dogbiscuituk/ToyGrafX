namespace ToyGraf.Controls
{
    partial class GLSLShaderEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLSLShaderEditor));
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tbFooter = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbCase = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbCaseHeader = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbMain = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbMainHeader = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbInit = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tbInitHeader = new FastColoredTextBoxNS.FastColoredTextBox();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMainHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInitHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.Controls.Add(this.tbFooter, 0, 6);
            this.TableLayoutPanel.Controls.Add(this.tbCase, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.tbCaseHeader, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.tbMain, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.tbMainHeader, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.tbInit, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.tbInitHeader, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 7;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(631, 475);
            this.TableLayoutPanel.TabIndex = 2;
            // 
            // tbFooter
            // 
            this.tbFooter.AutoCompleteBracketsList = new char[] {
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
            this.tbFooter.AutoScrollMinSize = new System.Drawing.Size(98, 70);
            this.tbFooter.BackBrush = null;
            this.tbFooter.BackColor = System.Drawing.SystemColors.Control;
            this.tbFooter.CharHeight = 14;
            this.tbFooter.CharWidth = 8;
            this.tbFooter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFooter.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFooter.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbFooter.IsReplaceMode = false;
            this.tbFooter.Location = new System.Drawing.Point(0, 378);
            this.tbFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tbFooter.Name = "tbFooter";
            this.tbFooter.Paddings = new System.Windows.Forms.Padding(0);
            this.tbFooter.ReadOnly = true;
            this.tbFooter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbFooter.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbFooter.ServiceColors")));
            this.tbFooter.ShowLineNumbers = false;
            this.tbFooter.Size = new System.Drawing.Size(633, 97);
            this.tbFooter.TabIndex = 6;
            this.tbFooter.Text = "      break;\r\n    default:\r\n      break;\r\n  }\r\n}";
            this.tbFooter.Zoom = 100;
            this.tbFooter.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbCase
            // 
            this.tbCase.AutoCompleteBracketsList = new char[] {
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
            this.tbCase.AutoScrollMinSize = new System.Drawing.Size(554, 140);
            this.tbCase.BackBrush = null;
            this.tbCase.CharHeight = 14;
            this.tbCase.CharWidth = 8;
            this.tbCase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCase.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCase.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbCase.IsReplaceMode = false;
            this.tbCase.Location = new System.Drawing.Point(48, 238);
            this.tbCase.Margin = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.tbCase.Name = "tbCase";
            this.tbCase.Paddings = new System.Windows.Forms.Padding(0);
            this.tbCase.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbCase.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbCase.ServiceColors")));
            this.tbCase.ShowLineNumbers = false;
            this.tbCase.Size = new System.Drawing.Size(585, 140);
            this.tbCase.TabIndex = 5;
            this.tbCase.Text = resources.GetString("tbCase.Text");
            this.tbCase.Zoom = 100;
            this.tbCase.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbCaseHeader
            // 
            this.tbCaseHeader.AutoCompleteBracketsList = new char[] {
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
            this.tbCaseHeader.AutoScrollMinSize = new System.Drawing.Size(154, 42);
            this.tbCaseHeader.BackBrush = null;
            this.tbCaseHeader.BackColor = System.Drawing.SystemColors.Control;
            this.tbCaseHeader.CharHeight = 14;
            this.tbCaseHeader.CharWidth = 8;
            this.tbCaseHeader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCaseHeader.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbCaseHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCaseHeader.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbCaseHeader.IsReplaceMode = false;
            this.tbCaseHeader.Location = new System.Drawing.Point(16, 196);
            this.tbCaseHeader.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.tbCaseHeader.Name = "tbCaseHeader";
            this.tbCaseHeader.Paddings = new System.Windows.Forms.Padding(0);
            this.tbCaseHeader.ReadOnly = true;
            this.tbCaseHeader.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbCaseHeader.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbCaseHeader.ServiceColors")));
            this.tbCaseHeader.ShowLineNumbers = false;
            this.tbCaseHeader.Size = new System.Drawing.Size(617, 42);
            this.tbCaseHeader.TabIndex = 4;
            this.tbCaseHeader.Text = "switch (traceIndex)\r\n{\r\n  case 0:";
            this.tbCaseHeader.Zoom = 100;
            this.tbCaseHeader.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbMain
            // 
            this.tbMain.AutoCompleteBracketsList = new char[] {
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
            this.tbMain.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.tbMain.BackBrush = null;
            this.tbMain.CharHeight = 14;
            this.tbMain.CharWidth = 8;
            this.tbMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMain.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbMain.IsReplaceMode = false;
            this.tbMain.Location = new System.Drawing.Point(16, 182);
            this.tbMain.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Paddings = new System.Windows.Forms.Padding(0);
            this.tbMain.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbMain.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbMain.ServiceColors")));
            this.tbMain.ShowLineNumbers = false;
            this.tbMain.Size = new System.Drawing.Size(617, 14);
            this.tbMain.TabIndex = 3;
            this.tbMain.Zoom = 100;
            this.tbMain.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbMainHeader
            // 
            this.tbMainHeader.AutoCompleteBracketsList = new char[] {
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
            this.tbMainHeader.AutoScrollMinSize = new System.Drawing.Size(90, 28);
            this.tbMainHeader.BackBrush = null;
            this.tbMainHeader.BackColor = System.Drawing.SystemColors.Control;
            this.tbMainHeader.CharHeight = 14;
            this.tbMainHeader.CharWidth = 8;
            this.tbMainHeader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMainHeader.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbMainHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMainHeader.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbMainHeader.IsReplaceMode = false;
            this.tbMainHeader.Location = new System.Drawing.Point(0, 154);
            this.tbMainHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tbMainHeader.Name = "tbMainHeader";
            this.tbMainHeader.Paddings = new System.Windows.Forms.Padding(0);
            this.tbMainHeader.ReadOnly = true;
            this.tbMainHeader.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbMainHeader.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbMainHeader.ServiceColors")));
            this.tbMainHeader.ShowLineNumbers = false;
            this.tbMainHeader.Size = new System.Drawing.Size(633, 28);
            this.tbMainHeader.TabIndex = 2;
            this.tbMainHeader.Text = "void main()\r\n{";
            this.tbMainHeader.Zoom = 100;
            this.tbMainHeader.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbInit
            // 
            this.tbInit.AutoCompleteBracketsList = new char[] {
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
            this.tbInit.AutoScrollMinSize = new System.Drawing.Size(314, 126);
            this.tbInit.BackBrush = null;
            this.tbInit.CharHeight = 14;
            this.tbInit.CharWidth = 8;
            this.tbInit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbInit.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInit.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbInit.IsReplaceMode = false;
            this.tbInit.Location = new System.Drawing.Point(0, 28);
            this.tbInit.Margin = new System.Windows.Forms.Padding(0);
            this.tbInit.Name = "tbInit";
            this.tbInit.Paddings = new System.Windows.Forms.Padding(0);
            this.tbInit.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbInit.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbInit.ServiceColors")));
            this.tbInit.ShowLineNumbers = false;
            this.tbInit.Size = new System.Drawing.Size(633, 126);
            this.tbInit.TabIndex = 1;
            this.tbInit.Text = "layout (location = 0) in vec3 position;\r\nout vec3 colour;\r\nuniform float timeValu" +
    "e;\r\nuniform int traceIndex;\r\nuniform mat4\r\n  transform,\r\n  cameraView,\r\n  projec" +
    "tion;\r\nfloat t, x, y, z, r, g, b;";
            this.tbInit.Zoom = 100;
            this.tbInit.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // tbInitHeader
            // 
            this.tbInitHeader.AutoCompleteBracketsList = new char[] {
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
            this.tbInitHeader.AutoScrollMinSize = new System.Drawing.Size(130, 28);
            this.tbInitHeader.BackBrush = null;
            this.tbInitHeader.BackColor = System.Drawing.SystemColors.Control;
            this.tbInitHeader.CharHeight = 14;
            this.tbInitHeader.CharWidth = 8;
            this.tbInitHeader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbInitHeader.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbInitHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInitHeader.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tbInitHeader.IsReplaceMode = false;
            this.tbInitHeader.Location = new System.Drawing.Point(0, 0);
            this.tbInitHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tbInitHeader.Name = "tbInitHeader";
            this.tbInitHeader.Paddings = new System.Windows.Forms.Padding(0);
            this.tbInitHeader.ReadOnly = true;
            this.tbInitHeader.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbInitHeader.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbInitHeader.ServiceColors")));
            this.tbInitHeader.ShowLineNumbers = false;
            this.tbInitHeader.Size = new System.Drawing.Size(633, 28);
            this.tbInitHeader.TabIndex = 0;
            this.tbInitHeader.Text = "// Vertex Shader\r\n#version 330";
            this.tbInitHeader.Zoom = 100;
            this.tbInitHeader.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox_TextChanged);
            // 
            // GLSLShaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "GLSLShaderEditor";
            this.Size = new System.Drawing.Size(631, 475);
            this.TableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMainHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInitHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private FastColoredTextBoxNS.FastColoredTextBox tbFooter;
        private FastColoredTextBoxNS.FastColoredTextBox tbCase;
        private FastColoredTextBoxNS.FastColoredTextBox tbCaseHeader;
        private FastColoredTextBoxNS.FastColoredTextBox tbMain;
        private FastColoredTextBoxNS.FastColoredTextBox tbMainHeader;
        private FastColoredTextBoxNS.FastColoredTextBox tbInit;
        private FastColoredTextBoxNS.FastColoredTextBox tbInitHeader;
    }
}
