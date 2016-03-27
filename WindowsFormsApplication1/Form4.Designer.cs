namespace WindowsFormsApplication1
{
    partial class Form4
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
            this.读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取主表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取附表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结果显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取ToolStripMenuItem,
            this.计算ToolStripMenuItem,
            this.结果ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 读取ToolStripMenuItem
            // 
            this.读取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取主表ToolStripMenuItem,
            this.读取附表ToolStripMenuItem});
            this.读取ToolStripMenuItem.Name = "读取ToolStripMenuItem";
            this.读取ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.读取ToolStripMenuItem.Text = "读取(&F)";
            // 
            // 读取主表ToolStripMenuItem
            // 
            this.读取主表ToolStripMenuItem.Name = "读取主表ToolStripMenuItem";
            this.读取主表ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.读取主表ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.读取主表ToolStripMenuItem.Text = "读取主表...";
            this.读取主表ToolStripMenuItem.Click += new System.EventHandler(this.读取主表ToolStripMenuItem_Click);
            // 
            // 读取附表ToolStripMenuItem
            // 
            this.读取附表ToolStripMenuItem.Name = "读取附表ToolStripMenuItem";
            this.读取附表ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.读取附表ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.读取附表ToolStripMenuItem.Text = "读取附表...";
            this.读取附表ToolStripMenuItem.Click += new System.EventHandler(this.读取附表ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算ToolStripMenuItem1});
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.计算ToolStripMenuItem.Text = "计算(&R)";
            // 
            // 计算ToolStripMenuItem1
            // 
            this.计算ToolStripMenuItem1.Name = "计算ToolStripMenuItem1";
            this.计算ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.计算ToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.计算ToolStripMenuItem1.Text = "计算效益";
            this.计算ToolStripMenuItem1.Click += new System.EventHandler(this.计算ToolStripMenuItem1_Click);
            // 
            // 结果ToolStripMenuItem
            // 
            this.结果ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结果显示ToolStripMenuItem});
            this.结果ToolStripMenuItem.Name = "结果ToolStripMenuItem";
            this.结果ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.结果ToolStripMenuItem.Text = "结果(&D)";
            // 
            // 结果显示ToolStripMenuItem
            // 
            this.结果显示ToolStripMenuItem.Name = "结果显示ToolStripMenuItem";
            this.结果显示ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.结果显示ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.结果显示ToolStripMenuItem.Text = "结果显示";
            this.结果显示ToolStripMenuItem.Click += new System.EventHandler(this.结果显示ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem1});
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.退出ToolStripMenuItem.Text = "退出(&Q)";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(923, 302);
            this.dataGridView1.TabIndex = 14;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 327);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成本效益";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取主表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取附表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 结果显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}