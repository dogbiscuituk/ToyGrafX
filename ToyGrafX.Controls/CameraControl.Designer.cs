namespace ToyGrafX.Controls
{
    partial class CameraControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sePhi = new System.Windows.Forms.NumericUpDown();
            this.seTheta = new System.Windows.Forms.NumericUpDown();
            this.seR = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.seZ = new System.Windows.Forms.NumericUpDown();
            this.seY = new System.Windows.Forms.NumericUpDown();
            this.seX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.seRoll = new System.Windows.Forms.NumericUpDown();
            this.seYaw = new System.Windows.Forms.NumericUpDown();
            this.sePitch = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sePhi);
            this.groupBox1.Controls.Add(this.seTheta);
            this.groupBox1.Controls.Add(this.seR);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.seZ);
            this.groupBox1.Controls.Add(this.seY);
            this.groupBox1.Controls.Add(this.seX);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // sePhi
            // 
            this.sePhi.DecimalPlaces = 2;
            this.sePhi.Location = new System.Drawing.Point(136, 80);
            this.sePhi.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.sePhi.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.sePhi.Name = "sePhi";
            this.sePhi.Size = new System.Drawing.Size(80, 23);
            this.sePhi.TabIndex = 12;
            this.sePhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seTheta
            // 
            this.seTheta.DecimalPlaces = 2;
            this.seTheta.Location = new System.Drawing.Point(136, 51);
            this.seTheta.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seTheta.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seTheta.Name = "seTheta";
            this.seTheta.Size = new System.Drawing.Size(80, 23);
            this.seTheta.TabIndex = 11;
            this.seTheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seR
            // 
            this.seR.DecimalPlaces = 4;
            this.seR.Location = new System.Drawing.Point(136, 22);
            this.seR.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seR.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seR.Name = "seR";
            this.seR.Size = new System.Drawing.Size(80, 23);
            this.seR.TabIndex = 10;
            this.seR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(110, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "ϕ°";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "θ°";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "r";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // seZ
            // 
            this.seZ.DecimalPlaces = 4;
            this.seZ.Location = new System.Drawing.Point(24, 80);
            this.seZ.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seZ.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seZ.Name = "seZ";
            this.seZ.Size = new System.Drawing.Size(80, 23);
            this.seZ.TabIndex = 4;
            this.seZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seY
            // 
            this.seY.DecimalPlaces = 4;
            this.seY.Location = new System.Drawing.Point(24, 51);
            this.seY.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seY.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seY.Name = "seY";
            this.seY.Size = new System.Drawing.Size(80, 23);
            this.seY.TabIndex = 3;
            this.seY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seX
            // 
            this.seX.DecimalPlaces = 4;
            this.seX.Location = new System.Drawing.Point(24, 22);
            this.seX.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seX.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seX.Name = "seX";
            this.seX.Size = new System.Drawing.Size(80, 23);
            this.seX.TabIndex = 2;
            this.seX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.seRoll);
            this.groupBox2.Controls.Add(this.seYaw);
            this.groupBox2.Controls.Add(this.sePitch);
            this.groupBox2.Location = new System.Drawing.Point(236, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "roll°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "yaw°";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "pitch°";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // seRoll
            // 
            this.seRoll.DecimalPlaces = 2;
            this.seRoll.Location = new System.Drawing.Point(51, 80);
            this.seRoll.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seRoll.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seRoll.Name = "seRoll";
            this.seRoll.Size = new System.Drawing.Size(80, 23);
            this.seRoll.TabIndex = 7;
            this.seRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seYaw
            // 
            this.seYaw.DecimalPlaces = 2;
            this.seYaw.Location = new System.Drawing.Point(51, 51);
            this.seYaw.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.seYaw.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.seYaw.Name = "seYaw";
            this.seYaw.Size = new System.Drawing.Size(80, 23);
            this.seYaw.TabIndex = 6;
            this.seYaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sePitch
            // 
            this.sePitch.DecimalPlaces = 2;
            this.sePitch.Location = new System.Drawing.Point(51, 22);
            this.sePitch.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.sePitch.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.sePitch.Name = "sePitch";
            this.sePitch.Size = new System.Drawing.Size(80, 23);
            this.sePitch.TabIndex = 5;
            this.sePitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CameraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CameraControl";
            this.Size = new System.Drawing.Size(383, 121);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown sePhi;
        public System.Windows.Forms.NumericUpDown seTheta;
        public System.Windows.Forms.NumericUpDown seR;
        public System.Windows.Forms.NumericUpDown seZ;
        public System.Windows.Forms.NumericUpDown seY;
        public System.Windows.Forms.NumericUpDown seX;
        public System.Windows.Forms.NumericUpDown seRoll;
        public System.Windows.Forms.NumericUpDown seYaw;
        public System.Windows.Forms.NumericUpDown sePitch;
    }
}
