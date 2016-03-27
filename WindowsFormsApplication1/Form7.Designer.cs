namespace WindowsFormsApplication1
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            dotnetCHARTING.WinForms.Label label1 = new dotnetCHARTING.WinForms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button20 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.chart1 = new dotnetCHARTING.WinForms.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.savePIC = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 3000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(98, 9);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBox2, "修改数据仅是在界面上，没有修改文档本身\r\n可以直接点击左边数据修改，修改后成图看变化\r\n");
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "视图数据可修改";
            this.toolTip1.SetToolTip(this.label10, "修改数据仅是在界面上，没有修改文档本身\r\n可以直接点击左边数据修改，修改后成图看变化");
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(53, 10);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBox3, "显示简单3D效果");
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "3D效果";
            this.toolTip1.SetToolTip(this.label11, "显示简单3D效果");
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Controls.Add(this.dataGridView6);
            this.groupBox7.Location = new System.Drawing.Point(2, 28);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(536, 645);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "数据读取";
            // 
            // button9
            // 
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(455, 616);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "读取";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(6, 20);
            this.dataGridView6.MultiSelect = false;
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.RowTemplate.Height = 23;
            this.dataGridView6.Size = new System.Drawing.Size(524, 590);
            this.dataGridView6.TabIndex = 0;
            this.dataGridView6.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView6_ColumnHeaderMouseClick);
            this.dataGridView6.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView6_RowHeaderMouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox12);
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Location = new System.Drawing.Point(544, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 645);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "表格成图";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label20);
            this.groupBox12.Controls.Add(this.label21);
            this.groupBox12.Controls.Add(this.label22);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Controls.Add(this.label18);
            this.groupBox12.Controls.Add(this.button20);
            this.groupBox12.Controls.Add(this.label17);
            this.groupBox12.Controls.Add(this.button19);
            this.groupBox12.Controls.Add(this.panel1);
            this.groupBox12.Controls.Add(this.label5);
            this.groupBox12.Controls.Add(this.panel4);
            this.groupBox12.Controls.Add(this.comboBox1);
            this.groupBox12.Controls.Add(this.panel3);
            this.groupBox12.Controls.Add(this.panel2);
            this.groupBox12.Controls.Add(this.textBox4);
            this.groupBox12.Controls.Add(this.label15);
            this.groupBox12.Controls.Add(this.textBox3);
            this.groupBox12.Controls.Add(this.label14);
            this.groupBox12.Controls.Add(this.textBox2);
            this.groupBox12.Controls.Add(this.label13);
            this.groupBox12.Controls.Add(this.textBox1);
            this.groupBox12.Controls.Add(this.label12);
            this.groupBox12.Controls.Add(this.button10);
            this.groupBox12.Location = new System.Drawing.Point(0, 309);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(531, 336);
            this.groupBox12.TabIndex = 10;
            this.groupBox12.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(412, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 27;
            this.label20.Text = "已选第";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(450, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 18);
            this.label21.TabIndex = 26;
            this.label21.Text = "..";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(481, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 25;
            this.label22.Text = "行数据";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(156, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 24;
            this.label19.Text = "行数据";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(127, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 18);
            this.label18.TabIndex = 23;
            this.label18.Text = "..";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button20
            // 
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button20.Location = new System.Drawing.Point(333, 70);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 22;
            this.button20.Text = "选取y数据";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(89, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 21;
            this.label17.Text = "已选第";
            // 
            // button19
            // 
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button19.Location = new System.Drawing.Point(9, 70);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 3;
            this.button19.Text = "选取x数据";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(4, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 30);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(315, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "选择成图类型:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox4);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(355, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(166, 36);
            this.panel4.TabIndex = 19;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(146, 13);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "第一列作为横纵坐标名称";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "柱状图",
            "饼状图(合并)",
            "饼状图(分散)",
            "折线图"});
            this.comboBox1.Location = new System.Drawing.Point(400, 263);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Location = new System.Drawing.Point(4, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 36);
            this.panel3.TabIndex = 18;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(155, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "表格行内容作为坐标数据";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(184, 11);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(155, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "表格列内容作为坐标数据";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(190, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(79, 30);
            this.panel2.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(364, 214);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(157, 21);
            this.textBox4.TabIndex = 17;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(283, 218);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "纵坐标y名称:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(68, 169);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(453, 21);
            this.textBox3.TabIndex = 13;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "图例名称:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 213);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 21);
            this.textBox2.TabIndex = 15;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "横坐标x名称:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "标    题:";
            // 
            // button10
            // 
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(448, 307);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 5;
            this.button10.Text = "成图";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // chart1
            // 
            this.chart1.Background.Color = System.Drawing.Color.White;
            this.chart1.ChartArea.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.chart1.ChartArea.CornerTopLeft = dotnetCHARTING.WinForms.BoxCorner.Square;
            this.chart1.ChartArea.DefaultElement.DefaultSubValue.Line.Color = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.chart1.ChartArea.DefaultElement.LegendEntry.DividerLine.Color = System.Drawing.Color.Empty;
            this.chart1.ChartArea.InteriorLine.Color = System.Drawing.Color.LightGray;
            this.chart1.ChartArea.Label.Font = new System.Drawing.Font("Tahoma", 8F);
            this.chart1.ChartArea.LegendBox.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            this.chart1.ChartArea.LegendBox.CornerBottomRight = dotnetCHARTING.WinForms.BoxCorner.Cut;
            this.chart1.ChartArea.LegendBox.DefaultEntry.DividerLine.Color = System.Drawing.Color.Empty;
            this.chart1.ChartArea.LegendBox.HeaderEntry.DividerLine.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.LegendBox.HeaderEntry.Name = "Name";
            this.chart1.ChartArea.LegendBox.HeaderEntry.SortOrder = -1;
            this.chart1.ChartArea.LegendBox.HeaderEntry.Value = "Value";
            this.chart1.ChartArea.LegendBox.HeaderEntry.Visible = false;
            this.chart1.ChartArea.LegendBox.InteriorLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chart1.ChartArea.LegendBox.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.LegendBox.Padding = 4;
            this.chart1.ChartArea.LegendBox.Position = dotnetCHARTING.WinForms.LegendBoxPosition.Top;
            this.chart1.ChartArea.LegendBox.Visible = true;
            this.chart1.ChartArea.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.StartDateOfYear = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.TitleBox.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            this.chart1.ChartArea.TitleBox.InteriorLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chart1.ChartArea.TitleBox.Label.Color = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.chart1.ChartArea.TitleBox.Label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chart1.ChartArea.TitleBox.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.TitleBox.Visible = true;
            this.chart1.ChartArea.XAxis.DefaultTick.GridLine.Color = System.Drawing.Color.LightGray;
            this.chart1.ChartArea.XAxis.DefaultTick.Line.Length = 3;
            this.chart1.ChartArea.XAxis.MinorTimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.XAxis.TimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.XAxis.ZeroTick.GridLine.Color = System.Drawing.Color.Red;
            this.chart1.ChartArea.XAxis.ZeroTick.Line.Length = 3;
            this.chart1.ChartArea.YAxis.DefaultTick.GridLine.Color = System.Drawing.Color.LightGray;
            this.chart1.ChartArea.YAxis.DefaultTick.Line.Length = 3;
            this.chart1.ChartArea.YAxis.TimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.YAxis.ZeroTick.GridLine.Color = System.Drawing.Color.Red;
            this.chart1.ChartArea.YAxis.ZeroTick.Line.Length = 3;
            this.chart1.DataGrid = null;
            this.chart1.DefaultElement.LegendEntry.DividerLine.Color = System.Drawing.Color.Empty;
            this.chart1.LabelChart = label1;
            this.chart1.Location = new System.Drawing.Point(6, 20);
            this.chart1.Name = "chart1";
            this.chart1.NoDataLabel.Text = "No Data";
            this.chart1.Size = new System.Drawing.Size(519, 278);
            this.chart1.StartDateOfYear = new System.DateTime(((long)(0)));
            this.chart1.TabIndex = 7;
            this.chart1.TempDirectory = "C:\\Users\\hello\\AppData\\Local\\Temp\\";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePIC});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // savePIC
            // 
            this.savePIC.Name = "savePIC";
            this.savePIC.Size = new System.Drawing.Size(100, 22);
            this.savePIC.Text = "存储";
            this.savePIC.Click += new System.EventHandler(this.savePIC_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 701);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "综合决策";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button10;
        private dotnetCHARTING.WinForms.Chart chart1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem savePIC;

    }
}