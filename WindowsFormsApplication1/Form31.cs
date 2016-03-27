using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Open();
        }
        private void Open()
        {
            listView1.Items.Clear();
            listView1.Items.Add("打开>>");
            listView1.Items.Add("保存>>");
            listView1.Items.Add("另存为>>");
            listView1.Items.Add("退出>>");
        }
        private void Edit()
        {
            listView1.Items.Clear();
            listView1.Items.Add("修改>>");
        }
        void ButtonClick(object sender, System.EventArgs e)
        {
            // Get the clicked button...
            Button clickedButton = (Button)sender;
            // ... and it's tabindex
            int clickedButtonTabIndex = clickedButton.TabIndex;

            // Send each button to top or bottom as appropriate
            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is Button)
                {
                    Button btn = (Button)ctl;
                    if (btn.TabIndex > clickedButtonTabIndex)
                    {
                        if (btn.Dock != DockStyle.Bottom)
                        {
                            btn.Dock = DockStyle.Bottom;
                            // This is vital to preserve the correct order
                            btn.BringToFront();
                        }
                    }
                    else
                    {
                        if (btn.Dock != DockStyle.Top)
                        {
                            btn.Dock = DockStyle.Top;
                            // This is vital to preserve the correct order
                            btn.BringToFront();
                        }
                    }
                }
            }

            // Determine which button was clicked.
            switch (clickedButton.Text)
            {
                case "文件":
                    Open();
                    break;

                case "编辑":
                    Edit();
                    break;

                default:
                    break;
            }
            listView1.BringToFront();  // Without this, the buttons will hide the items.
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*switch (this.listView1.SelectedItems[0].Text)
            {
                case "打开>>":
                    textBox1.Text = "点击“打开”菜单，通过路径选择需要读取的表格数据（类型为.xls,.xlsx,.csv），快捷键为Ctrl+O";
                    break;

                case "保存>>":
                    textBox1.Text = "点击“保存”菜单，表格数据保存到原路径，快捷键为Ctrl+S";
                    break;

                case "另存为>>":
                    textBox1.Text = "点击“另存为”菜单，表格数据保存到指定路径，且可以输入文件名";
                    break;

                case "退出>>":
                    textBox1.Text = "点击“退出”菜单，关闭此模块功能框";
                    break;

                case "修改>>":
                    textBox1.Text = "点击“修改”菜单，被选中的数据处于课修改状态";
                    break;

                default:
                    break;
            }*/
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            switch (this.listView1.SelectedItems[0].Text)
            {
                case "打开>>":
                    textBox1.Text = "点击“打开”菜单，通过路径选择需要读取的表格数据（类型为.xls,.xlsx,.csv），快捷键为Ctrl+O。也可以点击界面上的搜索图片打开读取数据表格";
                    break;

                case "保存>>":
                    textBox1.Text = "点击“保存”菜单，表格数据保存到原路径，快捷键为Ctrl+S";
                    break;

                case "另存为>>":
                    textBox1.Text = "点击“另存为”菜单，表格数据保存到指定路径，且可以输入文件名";
                    break;

                case "退出>>":
                    textBox1.Text = "点击“退出”菜单，关闭此模块功能";
                    break;

                case "修改>>":
                    textBox1.Text = "点击“修改”菜单，被选中的数据处于可修改状态";
                    break;

                default:
                    break;
            }
        }
    }
}