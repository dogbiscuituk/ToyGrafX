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
            this.tpTessellationEvaluation = new System.Windows.Forms.TabPage();
            this.tpGeometry = new System.Windows.Forms.TabPage();
            this.tpFragment = new System.Windows.Forms.TabPage();
            this.tpCompute = new System.Windows.Forms.TabPage();
            this.ShadersTabControl.SuspendLayout();
            this.tpVertex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbVertex)).BeginInit();
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
            this.tpVertex.Padding = new System.Windows.Forms.Padding(3);
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
            this.fctbVertex.AutoScrollMinSize = new System.Drawing.Size(594, 98);
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
            this.fctbVertex.Location = new System.Drawing.Point(3, 3);
            this.fctbVertex.Name = "fctbVertex";
            this.fctbVertex.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbVertex.RightBracket = ')';
            this.fctbVertex.RightBracket2 = '}';
            this.fctbVertex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbVertex.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbVertex.ServiceColors")));
            this.fctbVertex.ShowLineNumbers = false;
            this.fctbVertex.Size = new System.Drawing.Size(466, 326);
            this.fctbVertex.TabIndex = 0;
            this.fctbVertex.Text = resources.GetString("fctbVertex.Text");
            this.fctbVertex.Zoom = 100;
            // 
            // tpTessellationControl
            // 
            this.tpTessellationControl.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationControl.Name = "tpTessellationControl";
            this.tpTessellationControl.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationControl.TabIndex = 1;
            this.tpTessellationControl.Text = "Tess Ctrl";
            this.tpTessellationControl.ToolTipText = "Shader 2: Tessellation Control";
            this.tpTessellationControl.UseVisualStyleBackColor = true;
            // 
            // tpTessellationEvaluation
            // 
            this.tpTessellationEvaluation.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationEvaluation.Name = "tpTessellationEvaluation";
            this.tpTessellationEvaluation.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationEvaluation.TabIndex = 2;
            this.tpTessellationEvaluation.Text = "Tess Eval";
            this.tpTessellationEvaluation.ToolTipText = "Shader 3: Tessellation Evaluation";
            this.tpTessellationEvaluation.UseVisualStyleBackColor = true;
            // 
            // tpGeometry
            // 
            this.tpGeometry.Location = new System.Drawing.Point(4, 24);
            this.tpGeometry.Name = "tpGeometry";
            this.tpGeometry.Size = new System.Drawing.Size(472, 332);
            this.tpGeometry.TabIndex = 3;
            this.tpGeometry.Text = "Geometry";
            this.tpGeometry.ToolTipText = "Shader 4: Geometry";
            this.tpGeometry.UseVisualStyleBackColor = true;
            // 
            // tpFragment
            // 
            this.tpFragment.Location = new System.Drawing.Point(4, 24);
            this.tpFragment.Name = "tpFragment";
            this.tpFragment.Size = new System.Drawing.Size(472, 332);
            this.tpFragment.TabIndex = 4;
            this.tpFragment.Text = "Fragment";
            this.tpFragment.ToolTipText = "Shader 5: Fragment (mandatory)";
            this.tpFragment.UseVisualStyleBackColor = true;
            // 
            // tpCompute
            // 
            this.tpCompute.Location = new System.Drawing.Point(4, 24);
            this.tpCompute.Name = "tpCompute";
            this.tpCompute.Size = new System.Drawing.Size(472, 332);
            this.tpCompute.TabIndex = 5;
            this.tpCompute.Text = "Compute";
            this.tpCompute.ToolTipText = "Shader 6: Compute";
            this.tpCompute.UseVisualStyleBackColor = true;
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
    }
}
