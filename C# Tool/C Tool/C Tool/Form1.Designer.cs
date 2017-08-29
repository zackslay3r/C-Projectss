﻿namespace C_Tool
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
            this.lblStartPText = new System.Windows.Forms.Label();
            this.lblEndPText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.tlstrpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(180, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 514);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lblStartP
            // 
            this.lblStartP.AutoSize = true;
            this.lblStartP.Location = new System.Drawing.Point(867, 542);
            this.lblStartP.Name = "lblStartP";
            this.lblStartP.Size = new System.Drawing.Size(56, 13);
            this.lblStartP.TabIndex = 2;
            this.lblStartP.Text = "Start Point";
            // 
            // lblEndP
            // 
            this.lblEndP.AutoSize = true;
            this.lblEndP.Location = new System.Drawing.Point(867, 584);
            this.lblEndP.Name = "lblEndP";
            this.lblEndP.Size = new System.Drawing.Size(53, 13);
            this.lblEndP.TabIndex = 3;
            this.lblEndP.Text = "End Point";
            // 
            // lblStartUV
            // 
            this.lblStartUV.AutoSize = true;
            this.lblStartUV.Location = new System.Drawing.Point(867, 625);
            this.lblStartUV.Name = "lblStartUV";
            this.lblStartUV.Size = new System.Drawing.Size(47, 13);
            this.lblStartUV.TabIndex = 4;
            this.lblStartUV.Text = "Start UV";
            // 
            // lblEndUV
            // 
            this.lblEndUV.AutoSize = true;
            this.lblEndUV.Location = new System.Drawing.Point(867, 666);
            this.lblEndUV.Name = "lblEndUV";
            this.lblEndUV.Size = new System.Drawing.Size(44, 13);
            this.lblEndUV.TabIndex = 5;
            this.lblEndUV.Text = "End UV";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2.Location = new System.Drawing.Point(855, 91);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 139);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblStartPText
            // 
            this.lblStartPText.AutoSize = true;
            this.lblStartPText.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStartPText.Location = new System.Drawing.Point(943, 542);
            this.lblStartPText.Name = "lblStartPText";
            this.lblStartPText.Size = new System.Drawing.Size(10, 13);
            this.lblStartPText.TabIndex = 7;
            this.lblStartPText.Text = " ";
            // 
            // lblEndPText
            // 
            this.lblEndPText.AutoSize = true;
            this.lblEndPText.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblEndPText.Location = new System.Drawing.Point(943, 584);
            this.lblEndPText.Name = "lblEndPText";
            this.lblEndPText.Size = new System.Drawing.Size(10, 13);
            this.lblEndPText.TabIndex = 8;
            this.lblEndPText.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(943, 625);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(943, 666);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " ";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(429, 28);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "&Export UV\'s";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(429, 666);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save UV";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(32, 468);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 13;
            this.btnDeleteItem.Text = "&Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
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
            this.lblRecName.Location = new System.Drawing.Point(360, 625);
            this.lblRecName.Name = "lblRecName";
            this.lblRecName.Size = new System.Drawing.Size(35, 13);
            this.lblRecName.TabIndex = 16;
            this.lblRecName.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(908, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Preview";
            // 
            // btnClearArea
            // 
            this.btnClearArea.Location = new System.Drawing.Point(870, 498);
            this.btnClearArea.Name = "btnClearArea";
            this.btnClearArea.Size = new System.Drawing.Size(93, 23);
            this.btnClearArea.TabIndex = 18;
            this.btnClearArea.Text = "&Clear Area";
            this.btnClearArea.UseVisualStyleBackColor = true;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 772);
            this.Controls.Add(this.btnClearArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecName);
            this.Controls.Add(this.txtRecName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEndPText);
            this.Controls.Add(this.lblStartPText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblEndUV);
            this.Controls.Add(this.lblStartUV);
            this.Controls.Add(this.lblEndP);
            this.Controls.Add(this.lblStartP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tlstrpMenu);
            this.Name = "Form1";
            this.Text = "Zack\'s Spritesheet Editior";
            this.tlstrpMenu.ResumeLayout(false);
            this.tlstrpMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblStartPText;
        private System.Windows.Forms.Label lblEndPText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.TextBox txtRecName;
        private System.Windows.Forms.Label lblRecName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearArea;
        private System.Windows.Forms.Timer tmrClock;
    }
}

