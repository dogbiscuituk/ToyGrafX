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
            this.ShadersTabControl = new System.Windows.Forms.TabControl();
            this.tpVertex = new System.Windows.Forms.TabPage();
            this.tpTessellationControl = new System.Windows.Forms.TabPage();
            this.tpTessellationEvaluation = new System.Windows.Forms.TabPage();
            this.tpGeometry = new System.Windows.Forms.TabPage();
            this.tpFragment = new System.Windows.Forms.TabPage();
            this.tpCompute = new System.Windows.Forms.TabPage();
            this.ShadersTabControl.SuspendLayout();
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
            this.tpVertex.Location = new System.Drawing.Point(4, 24);
            this.tpVertex.Name = "tpVertex";
            this.tpVertex.Padding = new System.Windows.Forms.Padding(3);
            this.tpVertex.Size = new System.Drawing.Size(472, 332);
            this.tpVertex.TabIndex = 0;
            this.tpVertex.Text = "Vertex";
            this.tpVertex.UseVisualStyleBackColor = true;
            // 
            // tpTessellationControl
            // 
            this.tpTessellationControl.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationControl.Name = "tpTessellationControl";
            this.tpTessellationControl.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationControl.TabIndex = 1;
            this.tpTessellationControl.Text = "Tess Control";
            this.tpTessellationControl.UseVisualStyleBackColor = true;
            // 
            // tpTessellationEvaluation
            // 
            this.tpTessellationEvaluation.Location = new System.Drawing.Point(4, 24);
            this.tpTessellationEvaluation.Name = "tpTessellationEvaluation";
            this.tpTessellationEvaluation.Size = new System.Drawing.Size(472, 332);
            this.tpTessellationEvaluation.TabIndex = 2;
            this.tpTessellationEvaluation.Text = "Tess Evaluation";
            this.tpTessellationEvaluation.UseVisualStyleBackColor = true;
            // 
            // tpGeometry
            // 
            this.tpGeometry.Location = new System.Drawing.Point(4, 24);
            this.tpGeometry.Name = "tpGeometry";
            this.tpGeometry.Size = new System.Drawing.Size(472, 332);
            this.tpGeometry.TabIndex = 3;
            this.tpGeometry.Text = "Geometry";
            this.tpGeometry.UseVisualStyleBackColor = true;
            // 
            // tpFragment
            // 
            this.tpFragment.Location = new System.Drawing.Point(4, 24);
            this.tpFragment.Name = "tpFragment";
            this.tpFragment.Size = new System.Drawing.Size(472, 332);
            this.tpFragment.TabIndex = 4;
            this.tpFragment.Text = "Fragment";
            this.tpFragment.UseVisualStyleBackColor = true;
            // 
            // tpCompute
            // 
            this.tpCompute.Location = new System.Drawing.Point(4, 24);
            this.tpCompute.Name = "tpCompute";
            this.tpCompute.Size = new System.Drawing.Size(472, 332);
            this.tpCompute.TabIndex = 5;
            this.tpCompute.Text = "Compute";
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
    }
}
