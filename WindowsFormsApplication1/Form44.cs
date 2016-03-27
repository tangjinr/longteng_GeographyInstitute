using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form44 : Form
    {
        public Form44()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            listView1.Items.Clear();
            listView1.Items.Add("读取主表>>");
            listView1.Items.Add("读取附表>>");
        }

        private void Calc()
        {
            listView1.Items.Clear();
            listView1.Items.Add("计算效益>>");
        }

        private void ShowResult()
        {
            listView1.Items.Clear();
            listView1.Items.Add("结果显示>>");
        }

        private void Quit()
        {
            listView1.Items.Clear();
            listView1.Items.Add("退出>>");
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
                case "读取":
                    Read();
                    break;

                case "计算":
                    Calc();
                    break;

                case "结果":
                    ShowResult();
                    break;

                case "退出":
                    Quit();
                    break;

                default:
                    break;
            }
            listView1.BringToFront();  // Without this, the buttons will hide the items.
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            switch (this.listView1.SelectedItems[0].Text)
            {
                case "读取主表>>":
                    textBox1.Text = "点击“读取主表”菜单，通过路径选择需要读取的主表数据（类型为.xls,.xlsx,.csv），快捷键为Ctrl+M";
                    break;

                case "读取附表>>":
                    textBox1.Text = "点击“读取附表”菜单，通过路径选择需要读取的附表数据（类型为.xls,.xlsx,.csv），快捷键为Ctrl+L";
                    break;

                case "计算效益>>":
                    textBox1.Text = "点击“计算效益”菜单，根据“主表”中选择的数据计算成本收益，并可显示在界面上，快捷键为Ctrl+R";
                    break;

                case "结果显示>>":
                    textBox1.Text = "点击“结果显示”菜单，将计算结果显示在界面上，快捷键为Ctrl+D";
                    break;

                case "退出>>":
                    textBox1.Text = "点击“退出”菜单，关闭此模块功能，快捷键为Ctrl+Q";
                    break;

                default:
                    break;
            }
        }
    }
}