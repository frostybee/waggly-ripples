namespace FrostyBee.FriskyRipples
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
            this.btnLayeredFrom = new System.Windows.Forms.Button();
            this.cmbProfilesList = new System.Windows.Forms.ComboBox();
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
            this.chkbColorTransition = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnStopAnimation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRipplePreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAnimSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLayeredFrom
            // 
            this.btnLayeredFrom.Location = new System.Drawing.Point(510, 372);
            this.btnLayeredFrom.Name = "btnLayeredFrom";
            this.btnLayeredFrom.Size = new System.Drawing.Size(169, 44);
            this.btnLayeredFrom.TabIndex = 1;
            this.btnLayeredFrom.Text = "Show Layered Window";
            this.btnLayeredFrom.UseVisualStyleBackColor = true;
            this.btnLayeredFrom.Click += new System.EventHandler(this.BtnLayeredWindow_Click);
            // 
            // cmbProfilesList
            // 
            this.cmbProfilesList.FormattingEnabled = true;
            this.cmbProfilesList.Location = new System.Drawing.Point(12, 61);
            this.cmbProfilesList.Name = "cmbProfilesList";
            this.cmbProfilesList.Size = new System.Drawing.Size(158, 24);
            this.cmbProfilesList.TabIndex = 3;
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
            this.groupBox1.Location = new System.Drawing.Point(28, 177);
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
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Speed:";
            // 
            // sliderAnimSpeed
            // 
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
            this.cmbInterpolationMode.SelectedIndexChanged += new System.EventHandler(this.CmbInterpolationMode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interpolation Mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 24);
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
            this.cmbAnimDirection.SelectedIndexChanged += new System.EventHandler(this.CmbAnimDirection_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkbColorTransition);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbProfilesList);
            this.groupBox2.Location = new System.Drawing.Point(28, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile Options";
            // 
            // chkbColorTransition
            // 
            this.chkbColorTransition.AutoSize = true;
            this.chkbColorTransition.Location = new System.Drawing.Point(196, 61);
            this.chkbColorTransition.Name = "chkbColorTransition";
            this.chkbColorTransition.Size = new System.Drawing.Size(123, 20);
            this.chkbColorTransition.TabIndex = 6;
            this.chkbColorTransition.Text = "Color Transition";
            this.chkbColorTransition.UseVisualStyleBackColor = true;
            this.chkbColorTransition.CheckedChanged += new System.EventHandler(this.ChkbColorTransition_CheckedChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.Blue;
            this.btnPreview.Location = new System.Drawing.Point(510, 313);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 35);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnStopAnimation
            // 
            this.btnStopAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopAnimation.ForeColor = System.Drawing.Color.Red;
            this.btnStopAnimation.Location = new System.Drawing.Point(623, 313);
            this.btnStopAnimation.Name = "btnStopAnimation";
            this.btnStopAnimation.Size = new System.Drawing.Size(93, 35);
            this.btnStopAnimation.TabIndex = 11;
            this.btnStopAnimation.Text = "Stop";
            this.btnStopAnimation.UseVisualStyleBackColor = true;
            this.btnStopAnimation.Click += new System.EventHandler(this.BtnStopAnimation_Click);
            // 
            // RippleViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 475);
            this.Controls.Add(this.btnStopAnimation);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcbRipplePreview);
            this.Controls.Add(this.btnLayeredFrom);
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

        private System.Windows.Forms.Button btnLayeredFrom;
        private System.Windows.Forms.ComboBox cmbProfilesList;
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
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnStopAnimation;
        private System.Windows.Forms.CheckBox chkbColorTransition;
    }
}

