namespace WindowsFormsApplication1
{
    partial class Form44
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonZip = new System.Windows.Forms.Button();
            this.buttonCars = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txt = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(0, 89);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(130, 318);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.buttonZip);
            this.panel1.Controls.Add(this.buttonCars);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 411);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "结果";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonZip
            // 
            this.buttonZip.BackColor = System.Drawing.SystemColors.Control;
            this.buttonZip.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonZip.Location = new System.Drawing.Point(0, 23);
            this.buttonZip.Name = "buttonZip";
            this.buttonZip.Size = new System.Drawing.Size(130, 23);
            this.buttonZip.TabIndex = 2;
            this.buttonZip.Text = "计算";
            this.buttonZip.UseVisualStyleBackColor = false;
            this.buttonZip.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonCars
            // 
            this.buttonCars.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCars.Location = new System.Drawing.Point(0, 0);
            this.buttonCars.Name = "buttonCars";
            this.buttonCars.Size = new System.Drawing.Size(130, 23);
            this.buttonCars.TabIndex = 1;
            this.buttonCars.Text = "读取";
            this.buttonCars.UseVisualStyleBackColor = false;
            this.buttonCars.Click += new System.EventHandler(this.ButtonClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(134, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 411);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // txt
            // 
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt.Location = new System.Drawing.Point(138, 0);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt.Size = new System.Drawing.Size(350, 411);
            this.txt.TabIndex = 16;
            this.txt.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(350, 411);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "点击“打开”菜单，通过路径选择需要读取的表格数据（类型为.xls,.xlsx,.csv），快捷键为Ctrl+O";
            // 
            // Form44
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(488, 411);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "Form44";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成本效益帮助文档";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonZip;
        private System.Windows.Forms.Button buttonCars;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;



    }
}