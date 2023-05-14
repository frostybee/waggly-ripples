namespace WinFormLayered
{
    partial class RippleViewerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cboxRipplesList = new System.Windows.Forms.ComboBox();
            this.pcbRipplePreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAnimSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sliderAnimSpeed = new System.Windows.Forms.TrackBar();
            this.cmbInterpolationMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAnimDirection = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRipplePreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAnimSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "OpenLayered";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hide Form";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(686, 357);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "Shadow Tester";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cboxRipplesList
            // 
            this.cboxRipplesList.FormattingEnabled = true;
            this.cboxRipplesList.Location = new System.Drawing.Point(12, 61);
            this.cboxRipplesList.Name = "cboxRipplesList";
            this.cboxRipplesList.Size = new System.Drawing.Size(158, 24);
            this.cboxRipplesList.TabIndex = 3;
            // 
            // pcbRipplePreview
            // 
            this.pcbRipplePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbRipplePreview.Location = new System.Drawing.Point(510, 51);
            this.pcbRipplePreview.Name = "pcbRipplePreview";
            this.pcbRipplePreview.Size = new System.Drawing.Size(250, 250);
            this.pcbRipplePreview.TabIndex = 4;
            this.pcbRipplePreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ripple Profiles:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(507, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ripple Preview:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAnimSpeed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sliderAnimSpeed);
            this.groupBox1.Controls.Add(this.cmbInterpolationMode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbAnimDirection);
            this.groupBox1.Location = new System.Drawing.Point(28, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation Options";
            // 
            // lblAnimSpeed
            // 
            this.lblAnimSpeed.AutoSize = true;
            this.lblAnimSpeed.Location = new System.Drawing.Point(320, 119);
            this.lblAnimSpeed.Name = "lblAnimSpeed";
            this.lblAnimSpeed.Size = new System.Drawing.Size(21, 16);
            this.lblAnimSpeed.TabIndex = 12;
            this.lblAnimSpeed.Text = "50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Speed:";
            // 
            // sliderAnimSpeed
            // 
            this.sliderAnimSpeed.AllowDrop = true;
            this.sliderAnimSpeed.Location = new System.Drawing.Point(39, 117);
            this.sliderAnimSpeed.Maximum = 50;
            this.sliderAnimSpeed.Minimum = 10;
            this.sliderAnimSpeed.Name = "sliderAnimSpeed";
            this.sliderAnimSpeed.Size = new System.Drawing.Size(275, 56);
            this.sliderAnimSpeed.SmallChange = 5;
            this.sliderAnimSpeed.TabIndex = 9;
            this.sliderAnimSpeed.TickFrequency = 3;
            this.sliderAnimSpeed.Value = 10;
            this.sliderAnimSpeed.Scroll += new System.EventHandler(this.SliderAnimSpeed_Scroll);
            // 
            // cmbInterpolationMode
            // 
            this.cmbInterpolationMode.FormattingEnabled = true;
            this.cmbInterpolationMode.Location = new System.Drawing.Point(196, 47);
            this.cmbInterpolationMode.Name = "cmbInterpolationMode";
            this.cmbInterpolationMode.Size = new System.Drawing.Size(184, 24);
            this.cmbInterpolationMode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interpolation Mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Direction:";
            // 
            // cmbAnimDirection
            // 
            this.cmbAnimDirection.FormattingEnabled = true;
            this.cmbAnimDirection.Location = new System.Drawing.Point(11, 47);
            this.cmbAnimDirection.Name = "cmbAnimDirection";
            this.cmbAnimDirection.Size = new System.Drawing.Size(158, 24);
            this.cmbAnimDirection.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboxRipplesList);
            this.groupBox2.Location = new System.Drawing.Point(28, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile Options";
            // 
            // RippleViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcbRipplePreview);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "RippleViewerForm";
            this.Text = "Animated Ripples Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pcbRipplePreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAnimSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cboxRipplesList;
        private System.Windows.Forms.PictureBox pcbRipplePreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAnimDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbInterpolationMode;
        private System.Windows.Forms.TrackBar sliderAnimSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAnimSpeed;
        private System.Windows.Forms.Label label6;
    }
}

