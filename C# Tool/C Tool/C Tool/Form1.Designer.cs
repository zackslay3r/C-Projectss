namespace C_Tool
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
            this.tlstrpMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStartP = new System.Windows.Forms.Label();
            this.lblEndP = new System.Windows.Forms.Label();
            this.lblStartUV = new System.Windows.Forms.Label();
            this.lblEndUV = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.txtRecName = new System.Windows.Forms.TextBox();
            this.lblRecName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearArea = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlMainImage = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTestAni = new System.Windows.Forms.CheckBox();
            this.tmrAniTimer = new System.Windows.Forms.Timer(this.components);
            this.txtStartText = new System.Windows.Forms.TextBox();
            this.txtEndText = new System.Windows.Forms.TextBox();
            this.txtStartUV = new System.Windows.Forms.TextBox();
            this.txtEndUV = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.tlstrpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlMainImage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlstrpMenu
            // 
            this.tlstrpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.tlstrpMenu.Location = new System.Drawing.Point(0, 0);
            this.tlstrpMenu.Name = "tlstrpMenu";
            this.tlstrpMenu.Size = new System.Drawing.Size(1058, 25);
            this.tlstrpMenu.TabIndex = 0;
            this.tlstrpMenu.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton1.Text = "&Load Image";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton2.Text = "&Load UV";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(0, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(687, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // lblStartP
            // 
            this.lblStartP.AutoSize = true;
            this.lblStartP.Location = new System.Drawing.Point(885, 405);
            this.lblStartP.Name = "lblStartP";
            this.lblStartP.Size = new System.Drawing.Size(56, 13);
            this.lblStartP.TabIndex = 2;
            this.lblStartP.Text = "Start Point";
            // 
            // lblEndP
            // 
            this.lblEndP.AutoSize = true;
            this.lblEndP.Location = new System.Drawing.Point(885, 447);
            this.lblEndP.Name = "lblEndP";
            this.lblEndP.Size = new System.Drawing.Size(53, 13);
            this.lblEndP.TabIndex = 3;
            this.lblEndP.Text = "End Point";
            // 
            // lblStartUV
            // 
            this.lblStartUV.AutoSize = true;
            this.lblStartUV.Location = new System.Drawing.Point(885, 488);
            this.lblStartUV.Name = "lblStartUV";
            this.lblStartUV.Size = new System.Drawing.Size(47, 13);
            this.lblStartUV.TabIndex = 4;
            this.lblStartUV.Text = "Start UV";
            // 
            // lblEndUV
            // 
            this.lblEndUV.AutoSize = true;
            this.lblEndUV.Location = new System.Drawing.Point(885, 529);
            this.lblEndUV.Name = "lblEndUV";
            this.lblEndUV.Size = new System.Drawing.Size(44, 13);
            this.lblEndUV.TabIndex = 5;
            this.lblEndUV.Text = "End UV";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 139);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(429, 28);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "&Export UV\'s";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(429, 666);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save UV";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(32, 468);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 13;
            this.btnDeleteItem.Text = "&Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Visible = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstItems);
            this.panel1.Location = new System.Drawing.Point(13, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 333);
            this.panel1.TabIndex = 14;
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(3, 2);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(112, 329);
            this.lstItems.TabIndex = 0;
            this.lstItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDown);
            // 
            // txtRecName
            // 
            this.txtRecName.Location = new System.Drawing.Point(519, 618);
            this.txtRecName.Name = "txtRecName";
            this.txtRecName.Size = new System.Drawing.Size(100, 20);
            this.txtRecName.TabIndex = 15;
            // 
            // lblRecName
            // 
            this.lblRecName.AutoSize = true;
            this.lblRecName.Location = new System.Drawing.Point(354, 621);
            this.lblRecName.Name = "lblRecName";
            this.lblRecName.Size = new System.Drawing.Size(58, 13);
            this.lblRecName.TabIndex = 16;
            this.lblRecName.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(926, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Preview";
            // 
            // btnClearArea
            // 
            this.btnClearArea.Location = new System.Drawing.Point(911, 315);
            this.btnClearArea.Name = "btnClearArea";
            this.btnClearArea.Size = new System.Drawing.Size(93, 23);
            this.btnClearArea.TabIndex = 18;
            this.btnClearArea.Text = "&Clear Area";
            this.btnClearArea.UseVisualStyleBackColor = true;
            this.btnClearArea.Click += new System.EventHandler(this.btnClearArea_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // pnlMainImage
            // 
            this.pnlMainImage.AutoScroll = true;
            this.pnlMainImage.Controls.Add(this.pictureBox1);
            this.pnlMainImage.Location = new System.Drawing.Point(162, 57);
            this.pnlMainImage.Name = "pnlMainImage";
            this.pnlMainImage.Size = new System.Drawing.Size(687, 540);
            this.pnlMainImage.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(870, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 139);
            this.panel2.TabIndex = 20;
            // 
            // chkTestAni
            // 
            this.chkTestAni.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTestAni.Location = new System.Drawing.Point(870, 28);
            this.chkTestAni.Name = "chkTestAni";
            this.chkTestAni.Size = new System.Drawing.Size(164, 23);
            this.chkTestAni.TabIndex = 22;
            this.chkTestAni.Text = "Test Animation";
            this.chkTestAni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTestAni.UseVisualStyleBackColor = true;
            this.chkTestAni.CheckedChanged += new System.EventHandler(this.chkTestAni_CheckedChanged);
            // 
            // tmrAniTimer
            // 
            this.tmrAniTimer.Enabled = true;
            this.tmrAniTimer.Interval = 200;
            this.tmrAniTimer.Tick += new System.EventHandler(this.tmrAniTimer_Tick);
            // 
            // txtStartText
            // 
            this.txtStartText.Location = new System.Drawing.Point(946, 405);
            this.txtStartText.Name = "txtStartText";
            this.txtStartText.Size = new System.Drawing.Size(100, 20);
            this.txtStartText.TabIndex = 23;
            this.txtStartText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartText_KeyDown);
            this.txtStartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartText_KeyPress);
            // 
            // txtEndText
            // 
            this.txtEndText.Location = new System.Drawing.Point(946, 442);
            this.txtEndText.Name = "txtEndText";
            this.txtEndText.Size = new System.Drawing.Size(100, 20);
            this.txtEndText.TabIndex = 24;
            this.txtEndText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndText_KeyDown);
            // 
            // txtStartUV
            // 
            this.txtStartUV.Location = new System.Drawing.Point(946, 479);
            this.txtStartUV.Name = "txtStartUV";
            this.txtStartUV.Size = new System.Drawing.Size(100, 20);
            this.txtStartUV.TabIndex = 25;
            this.txtStartUV.TextChanged += new System.EventHandler(this.txtStartUV_TextChanged);
            this.txtStartUV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartUV_KeyDown);
            // 
            // txtEndUV
            // 
            this.txtEndUV.Location = new System.Drawing.Point(946, 521);
            this.txtEndUV.Name = "txtEndUV";
            this.txtEndUV.Size = new System.Drawing.Size(100, 20);
            this.txtEndUV.TabIndex = 26;
            this.txtEndUV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndUV_KeyDown);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(946, 564);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 27;
            this.txtWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWidth_KeyDown);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(946, 610);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 28;
            this.txtHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHeight_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(888, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(888, 616);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 30;
            this.lblHeight.Text = "Height";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 772);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtEndUV);
            this.Controls.Add(this.txtStartUV);
            this.Controls.Add(this.txtEndText);
            this.Controls.Add(this.txtStartText);
            this.Controls.Add(this.chkTestAni);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMainImage);
            this.Controls.Add(this.btnClearArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecName);
            this.Controls.Add(this.txtRecName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblEndUV);
            this.Controls.Add(this.lblStartUV);
            this.Controls.Add(this.lblEndP);
            this.Controls.Add(this.lblStartP);
            this.Controls.Add(this.tlstrpMenu);
            this.Name = "Form1";
            this.Text = "Zack\'s Spritesheet Editior";
            this.tlstrpMenu.ResumeLayout(false);
            this.tlstrpMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlMainImage.ResumeLayout(false);
            this.pnlMainImage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlstrpMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStartP;
        private System.Windows.Forms.Label lblEndP;
        private System.Windows.Forms.Label lblStartUV;
        private System.Windows.Forms.Label lblEndUV;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRecName;
        private System.Windows.Forms.Label lblRecName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearArea;
        private System.Windows.Forms.Timer tmrClock;
        public System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Panel pnlMainImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkTestAni;
        private System.Windows.Forms.Timer tmrAniTimer;
        private System.Windows.Forms.TextBox txtStartText;
        private System.Windows.Forms.TextBox txtEndText;
        private System.Windows.Forms.TextBox txtStartUV;
        private System.Windows.Forms.TextBox txtEndUV;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHeight;
    }
}

