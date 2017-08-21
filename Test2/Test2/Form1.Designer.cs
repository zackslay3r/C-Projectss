namespace Test2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblStartUVTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEndUVText = new System.Windows.Forms.Label();
            this.lblStartUVText = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoadImage = new System.Windows.Forms.ToolStripButton();
            this.btnUVLoad = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(257, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(597, 441);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(27, 76);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(192, 499);
            this.textOutput.TabIndex = 1;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(528, 596);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(528, 536);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblStartUVTitle
            // 
            this.lblStartUVTitle.AutoSize = true;
            this.lblStartUVTitle.Location = new System.Drawing.Point(915, 291);
            this.lblStartUVTitle.Name = "lblStartUVTitle";
            this.lblStartUVTitle.Size = new System.Drawing.Size(50, 13);
            this.lblStartUVTitle.TabIndex = 4;
            this.lblStartUVTitle.Text = "Start UV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "End UV:";
            // 
            // lblEndUVText
            // 
            this.lblEndUVText.AutoSize = true;
            this.lblEndUVText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEndUVText.Location = new System.Drawing.Point(1002, 355);
            this.lblEndUVText.Name = "lblEndUVText";
            this.lblEndUVText.Size = new System.Drawing.Size(10, 13);
            this.lblEndUVText.TabIndex = 7;
            this.lblEndUVText.Text = " ";
            // 
            // lblStartUVText
            // 
            this.lblStartUVText.AutoSize = true;
            this.lblStartUVText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblStartUVText.Location = new System.Drawing.Point(1002, 291);
            this.lblStartUVText.Name = "lblStartUVText";
            this.lblStartUVText.Size = new System.Drawing.Size(10, 13);
            this.lblStartUVText.TabIndex = 8;
            this.lblStartUVText.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadImage,
            this.btnUVLoad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadImage.Image")));
            this.btnLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(73, 22);
            this.btnLoadImage.Text = "&Load Image";
            this.btnLoadImage.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnUVLoad
            // 
            this.btnUVLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUVLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnUVLoad.Image")));
            this.btnUVLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUVLoad.Name = "btnUVLoad";
            this.btnUVLoad.Size = new System.Drawing.Size(55, 22);
            this.btnUVLoad.Text = "&Load UV";
            this.btnUVLoad.Click += new System.EventHandler(this.btnUVLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblStartUVText);
            this.Controls.Add(this.lblEndUVText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStartUVTitle);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStartUVTitle;
        private System.Windows.Forms.Label label1;
      
        private System.Windows.Forms.Label lblEndUVText;
        private System.Windows.Forms.Label lblStartUVText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoadImage;
        private System.Windows.Forms.ToolStripButton btnUVLoad;
    }
}

