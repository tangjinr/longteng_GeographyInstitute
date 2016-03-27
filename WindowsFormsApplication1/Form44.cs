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
            listView1.Items.Add("��ȡ����>>");
            listView1.Items.Add("��ȡ����>>");
        }

        private void Calc()
        {
            listView1.Items.Clear();
            listView1.Items.Add("����Ч��>>");
        }

        private void ShowResult()
        {
            listView1.Items.Clear();
            listView1.Items.Add("�����ʾ>>");
        }

        private void Quit()
        {
            listView1.Items.Clear();
            listView1.Items.Add("�˳�>>");
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
                case "��ȡ":
                    Read();
                    break;

                case "����":
                    Calc();
                    break;

                case "���":
                    ShowResult();
                    break;

                case "�˳�":
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
                case "��ȡ����>>":
                    textBox1.Text = "�������ȡ�����˵���ͨ��·��ѡ����Ҫ��ȡ���������ݣ�����Ϊ.xls,.xlsx,.csv������ݼ�ΪCtrl+M";
                    break;

                case "��ȡ����>>":
                    textBox1.Text = "�������ȡ�����˵���ͨ��·��ѡ����Ҫ��ȡ�ĸ������ݣ�����Ϊ.xls,.xlsx,.csv������ݼ�ΪCtrl+L";
                    break;

                case "����Ч��>>":
                    textBox1.Text = "���������Ч�桱�˵������ݡ�������ѡ������ݼ���ɱ����棬������ʾ�ڽ����ϣ���ݼ�ΪCtrl+R";
                    break;

                case "�����ʾ>>":
                    textBox1.Text = "����������ʾ���˵�������������ʾ�ڽ����ϣ���ݼ�ΪCtrl+D";
                    break;

                case "�˳�>>":
                    textBox1.Text = "������˳����˵����رմ�ģ�鹦�ܣ���ݼ�ΪCtrl+Q";
                    break;

                default:
                    break;
            }
        }
    }
}