namespace Sabır
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.videoAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoBiçimlendirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameText = new System.Windows.Forms.TextBox();
            this.prev = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.ekran = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoAçToolStripMenuItem,
            this.videoBiçimlendirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1239, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // videoAçToolStripMenuItem
            // 
            this.videoAçToolStripMenuItem.Name = "videoAçToolStripMenuItem";
            this.videoAçToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.videoAçToolStripMenuItem.Text = "Video Aç";
            this.videoAçToolStripMenuItem.Click += new System.EventHandler(this.videoAçToolStripMenuItem_Click);
            // 
            // videoBiçimlendirToolStripMenuItem
            // 
            this.videoBiçimlendirToolStripMenuItem.Name = "videoBiçimlendirToolStripMenuItem";
            this.videoBiçimlendirToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.videoBiçimlendirToolStripMenuItem.Text = "Video Biçimlendir";
            this.videoBiçimlendirToolStripMenuItem.Click += new System.EventHandler(this.videoBiçimlendirToolStripMenuItem_Click);
            // 
            // frameText
            // 
            this.frameText.Location = new System.Drawing.Point(45, 32);
            this.frameText.Name = "frameText";
            this.frameText.Size = new System.Drawing.Size(41, 20);
            this.frameText.TabIndex = 1;
            this.frameText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frameText_KeyUp);
            // 
            // prev
            // 
            this.prev.Location = new System.Drawing.Point(10, 32);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(29, 21);
            this.prev.TabIndex = 2;
            this.prev.Text = "<";
            this.prev.UseVisualStyleBackColor = true;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(92, 32);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(28, 20);
            this.next.TabIndex = 3;
            this.next.Text = ">";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // ekran
            // 
            this.ekran.Location = new System.Drawing.Point(13, 73);
            this.ekran.Name = "ekran";
            this.ekran.Size = new System.Drawing.Size(107, 94);
            this.ekran.TabIndex = 4;
            this.ekran.TabStop = false;
            this.ekran.Paint += new System.Windows.Forms.PaintEventHandler(this.ekran_Paint);
            this.ekran.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ekran_MouseDown);
            this.ekran.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ekran_MouseMove);
            this.ekran.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ekran_MouseUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(935, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(304, 668);
            this.dataGridView1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 667);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(917, 18);
            this.progressBar1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 692);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ekran);
            this.Controls.Add(this.next);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.frameText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sabırlı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem videoAçToolStripMenuItem;
        private System.Windows.Forms.TextBox frameText;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.PictureBox ekran;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem videoBiçimlendirToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

