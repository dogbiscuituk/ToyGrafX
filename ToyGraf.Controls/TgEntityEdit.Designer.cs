namespace ToyGraf.Controls
{
    partial class TgEntityEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TgEntityEdit));
            this.ShadersTabControl = new System.Windows.Forms.TabControl();
            this.tpVertex = new System.Windows.Forms.TabPage();
            this.fctbVertex = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpTessellationControl = new System.Windows.Forms.TabPage();
            this.fctbTessellationControl = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpTessellationEvaluation = new System.Windows.Forms.TabPage();
            this.fctbTessellationEvaluation = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpGeometry = new System.Windows.Forms.TabPage();
            this.fctbGeometry = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpFragment = new System.Windows.Forms.TabPage();
            this.fctbFragment = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpCompute = new System.Windows.Forms.TabPage();
            this.fctbCompute = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ShadersTabControl.SuspendLayout();
            this.tpVertex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbVertex)).BeginInit();
            this.tpTessellationControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbTessellationControl)).BeginInit();
            this.tpTessellationEvaluation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbTessellationEvaluation)).BeginInit();
            this.tpGeometry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbGeometry)).BeginInit();
            this.tpFragment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbFragment)).BeginInit();
            this.tpCompute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbCompute)).BeginInit();
            this.SuspendLayout();
            // 
            // ShadersTabControl
            // 
            this.ShadersTabControl.Controls.Add(this.tpVertex);
            this.ShadersTabControl.Controls.Add(this.tpTessellationControl);
            this.ShadersTabControl.Controls.Add(this.tpTessellationEvaluation);
            this.ShadersTabControl.Controls.Add(this.tpGeometry);
            this.ShadersTabControl.Controls.Add(this.tpFragment);
            this.ShadersTabControl.Controls.Add(this.tpCompute);
            this.ShadersTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadersTabControl.Location = new System.Drawing.Point(0, 0);
            this.ShadersTabControl.Name = "ShadersTabControl";
            this.ShadersTabControl.SelectedIndex = 0;
            this.ShadersTabControl.Size = new System.Drawing.Size(480, 360);
            this.ShadersTabControl.TabIndex = 0;
            // 
            // tpVertex
            // 
            this.tpVertex.Controls.Add(this.fctbVertex);
            this.tpVertex.Location = new System.Drawing.Point(4, 24);
            this.tpVertex.Name = "tpVertex";
            this.tpVertex.Size = new System.Drawing.Size(472, 332);
            this.tpVertex.TabIndex = 0;
            this.tpVertex.Text = "Vertex";
            this.tpVertex.ToolTipText = "Shader 1: Vertex (mandatory)";
            this.tpVertex.UseVisualStyleBackColor = true;
            // 
            // fctbVertex
            // 
            this.fctbVertex.AutoCompleteBracketsList = new char[] {
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
            this.fctbVertex.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbVertex.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctbVertex.BackBrush = null;
            this.fctbVertex.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbVertex.CharHeight = 14;
            this.fctbVertex.CharWidth = 8;
            this.fctbVertex.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbVertex.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbVertex.IsReplaceMode = false;
            this.fctbVertex.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbVertex.LeftBracket = '(';
            this.fctbVertex.LeftBracket2 = '{';
            this.fctbVertex.Location = new System.Drawing.Point(0, 0);
            this.fctbVertex.Name = "fctbVertex";
            this.fctbVertex.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbVertex.RightBracket = ')';
            this.fctbVertex.RightBracket2 = '}';
            this.fctbVertex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbVertex.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbVertex.ServiceColors")));
            this.fctbVertex.ShowFoldingLines = true;
            this.fctbVertex.Size = new System.Drawing.Size(472, 332);
            this.fctbVertex.TabIndex = 0;
            this.fctbVertex.Zoom = 100;
            // 
            // tpTessellationControl
            // 
            this.tpTessellationControl.Controls.Add(this.fctbTessellationControl);
            this.tpTessellationControl.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationControl.Name = "tpTessellationControl";
            this.tpTessellationControl.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationControl.TabIndex = 1;
            this.tpTessellationControl.Text = "Tess Ctrl";
            this.tpTessellationControl.ToolTipText = "Shader 2: Tessellation Control";
            this.tpTessellationControl.UseVisualStyleBackColor = true;
            // 
            // fctbTessellationControl
            // 
            this.fctbTessellationControl.AutoCompleteBracketsList = new char[] {
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
            this.fctbTessellationControl.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbTessellationControl.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctbTessellationControl.BackBrush = null;
            this.fctbTessellationControl.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbTessellationControl.CharHeight = 14;
            this.fctbTessellationControl.CharWidth = 8;
            this.fctbTessellationControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbTessellationControl.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbTessellationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbTessellationControl.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbTessellationControl.IsReplaceMode = false;
            this.fctbTessellationControl.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbTessellationControl.LeftBracket = '(';
            this.fctbTessellationControl.LeftBracket2 = '{';
            this.fctbTessellationControl.Location = new System.Drawing.Point(0, 0);
            this.fctbTessellationControl.Name = "fctbTessellationControl";
            this.fctbTessellationControl.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbTessellationControl.RightBracket = ')';
            this.fctbTessellationControl.RightBracket2 = '}';
            this.fctbTessellationControl.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbTessellationControl.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbTessellationControl.ServiceColors")));
            this.fctbTessellationControl.ShowFoldingLines = true;
            this.fctbTessellationControl.Size = new System.Drawing.Size(472, 332);
            this.fctbTessellationControl.TabIndex = 1;
            this.fctbTessellationControl.Zoom = 100;
            // 
            // tpTessellationEvaluation
            // 
            this.tpTessellationEvaluation.Controls.Add(this.fctbTessellationEvaluation);
            this.tpTessellationEvaluation.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationEvaluation.Name = "tpTessellationEvaluation";
            this.tpTessellationEvaluation.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationEvaluation.TabIndex = 2;
            this.tpTessellationEvaluation.Text = "Tess Eval";
            this.tpTessellationEvaluation.ToolTipText = "Shader 3: Tessellation Evaluation";
            this.tpTessellationEvaluation.UseVisualStyleBackColor = true;
            // 
            // fctbTessellationEvaluation
            // 
            this.fctbTessellationEvaluation.AutoCompleteBracketsList = new char[] {
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
            this.fctbTessellationEvaluation.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbTessellationEvaluation.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctbTessellationEvaluation.BackBrush = null;
            this.fctbTessellationEvaluation.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbTessellationEvaluation.CharHeight = 14;
            this.fctbTessellationEvaluation.CharWidth = 8;
            this.fctbTessellationEvaluation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbTessellationEvaluation.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbTessellationEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbTessellationEvaluation.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbTessellationEvaluation.IsReplaceMode = false;
            this.fctbTessellationEvaluation.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbTessellationEvaluation.LeftBracket = '(';
            this.fctbTessellationEvaluation.LeftBracket2 = '{';
            this.fctbTessellationEvaluation.Location = new System.Drawing.Point(0, 0);
            this.fctbTessellationEvaluation.Name = "fctbTessellationEvaluation";
            this.fctbTessellationEvaluation.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbTessellationEvaluation.RightBracket = ')';
            this.fctbTessellationEvaluation.RightBracket2 = '}';
            this.fctbTessellationEvaluation.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbTessellationEvaluation.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbTessellationEvaluation.ServiceColors")));
            this.fctbTessellationEvaluation.ShowFoldingLines = true;
            this.fctbTessellationEvaluation.Size = new System.Drawing.Size(472, 332);
            this.fctbTessellationEvaluation.TabIndex = 1;
            this.fctbTessellationEvaluation.Zoom = 100;
            // 
            // tpGeometry
            // 
            this.tpGeometry.Controls.Add(this.fctbGeometry);
            this.tpGeometry.Location = new System.Drawing.Point(4, 24);
            this.tpGeometry.Name = "tpGeometry";
            this.tpGeometry.Size = new System.Drawing.Size(472, 332);
            this.tpGeometry.TabIndex = 3;
            this.tpGeometry.Text = "Geometry";
            this.tpGeometry.ToolTipText = "Shader 4: Geometry";
            this.tpGeometry.UseVisualStyleBackColor = true;
            // 
            // fctbGeometry
            // 
            this.fctbGeometry.AutoCompleteBracketsList = new char[] {
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
            this.fctbGeometry.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbGeometry.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctbGeometry.BackBrush = null;
            this.fctbGeometry.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbGeometry.CharHeight = 14;
            this.fctbGeometry.CharWidth = 8;
            this.fctbGeometry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbGeometry.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbGeometry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbGeometry.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbGeometry.IsReplaceMode = false;
            this.fctbGeometry.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbGeometry.LeftBracket = '(';
            this.fctbGeometry.LeftBracket2 = '{';
            this.fctbGeometry.Location = new System.Drawing.Point(0, 0);
            this.fctbGeometry.Name = "fctbGeometry";
            this.fctbGeometry.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbGeometry.RightBracket = ')';
            this.fctbGeometry.RightBracket2 = '}';
            this.fctbGeometry.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbGeometry.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbGeometry.ServiceColors")));
            this.fctbGeometry.ShowFoldingLines = true;
            this.fctbGeometry.Size = new System.Drawing.Size(472, 332);
            this.fctbGeometry.TabIndex = 1;
            this.fctbGeometry.Zoom = 100;
            // 
            // tpFragment
            // 
            this.tpFragment.Controls.Add(this.fctbFragment);
            this.tpFragment.Location = new System.Drawing.Point(4, 24);
            this.tpFragment.Name = "tpFragment";
            this.tpFragment.Size = new System.Drawing.Size(472, 332);
            this.tpFragment.TabIndex = 4;
            this.tpFragment.Text = "Fragment";
            this.tpFragment.ToolTipText = "Shader 5: Fragment (mandatory)";
            this.tpFragment.UseVisualStyleBackColor = true;
            // 
            // fctbFragment
            // 
            this.fctbFragment.AutoCompleteBracketsList = new char[] {
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
            this.fctbFragment.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbFragment.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctbFragment.BackBrush = null;
            this.fctbFragment.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbFragment.CharHeight = 14;
            this.fctbFragment.CharWidth = 8;
            this.fctbFragment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbFragment.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbFragment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbFragment.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbFragment.IsReplaceMode = false;
            this.fctbFragment.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbFragment.LeftBracket = '(';
            this.fctbFragment.LeftBracket2 = '{';
            this.fctbFragment.Location = new System.Drawing.Point(0, 0);
            this.fctbFragment.Name = "fctbFragment";
            this.fctbFragment.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbFragment.RightBracket = ')';
            this.fctbFragment.RightBracket2 = '}';
            this.fctbFragment.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbFragment.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbFragment.ServiceColors")));
            this.fctbFragment.ShowFoldingLines = true;
            this.fctbFragment.Size = new System.Drawing.Size(472, 332);
            this.fctbFragment.TabIndex = 1;
            this.fctbFragment.Zoom = 100;
            // 
            // tpCompute
            // 
            this.tpCompute.Controls.Add(this.fctbCompute);
            this.tpCompute.Location = new System.Drawing.Point(4, 24);
            this.tpCompute.Name = "tpCompute";
            this.tpCompute.Size = new System.Drawing.Size(472, 332);
            this.tpCompute.TabIndex = 5;
            this.tpCompute.Text = "Compute";
            this.tpCompute.ToolTipText = "Shader 6: Compute";
            this.tpCompute.UseVisualStyleBackColor = true;
            // 
            // fctbCompute
            // 
            this.fctbCompute.AutoCompleteBracketsList = new char[] {
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
            this.fctbCompute.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbCompute.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctbCompute.BackBrush = null;
            this.fctbCompute.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbCompute.CharHeight = 14;
            this.fctbCompute.CharWidth = 8;
            this.fctbCompute.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbCompute.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbCompute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbCompute.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbCompute.IsReplaceMode = false;
            this.fctbCompute.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbCompute.LeftBracket = '(';
            this.fctbCompute.LeftBracket2 = '{';
            this.fctbCompute.Location = new System.Drawing.Point(0, 0);
            this.fctbCompute.Name = "fctbCompute";
            this.fctbCompute.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbCompute.RightBracket = ')';
            this.fctbCompute.RightBracket2 = '}';
            this.fctbCompute.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbCompute.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbCompute.ServiceColors")));
            this.fctbCompute.ShowFoldingLines = true;
            this.fctbCompute.Size = new System.Drawing.Size(472, 332);
            this.fctbCompute.TabIndex = 1;
            this.fctbCompute.Zoom = 100;
            // 
            // TgEntityEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShadersTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TgEntityEdit";
            this.Size = new System.Drawing.Size(480, 360);
            this.ShadersTabControl.ResumeLayout(false);
            this.tpVertex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbVertex)).EndInit();
            this.tpTessellationControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbTessellationControl)).EndInit();
            this.tpTessellationEvaluation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbTessellationEvaluation)).EndInit();
            this.tpGeometry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbGeometry)).EndInit();
            this.tpFragment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbFragment)).EndInit();
            this.tpCompute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbCompute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl ShadersTabControl;
        public System.Windows.Forms.TabPage tpVertex;
        public System.Windows.Forms.TabPage tpTessellationControl;
        public System.Windows.Forms.TabPage tpTessellationEvaluation;
        public System.Windows.Forms.TabPage tpGeometry;
        public System.Windows.Forms.TabPage tpFragment;
        public System.Windows.Forms.TabPage tpCompute;
        public FastColoredTextBoxNS.FastColoredTextBox fctbVertex;
        public FastColoredTextBoxNS.FastColoredTextBox fctbTessellationControl;
        public FastColoredTextBoxNS.FastColoredTextBox fctbTessellationEvaluation;
        public FastColoredTextBoxNS.FastColoredTextBox fctbGeometry;
        public FastColoredTextBoxNS.FastColoredTextBox fctbFragment;
        public FastColoredTextBoxNS.FastColoredTextBox fctbCompute;
    }
}
