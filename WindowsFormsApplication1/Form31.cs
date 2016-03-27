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
            listView1.Items.Add("��>>");
            listView1.Items.Add("����>>");
            listView1.Items.Add("���Ϊ>>");
            listView1.Items.Add("�˳�>>");
        }
        private void Edit()
        {
            listView1.Items.Clear();
            listView1.Items.Add("�޸�>>");
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
                case "�ļ�":
                    Open();
                    break;

                case "�༭":
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
                case "��>>":
                    textBox1.Text = "������򿪡��˵���ͨ��·��ѡ����Ҫ��ȡ�ı�����ݣ�����Ϊ.xls,.xlsx,.csv������ݼ�ΪCtrl+O";
                    break;

                case "����>>":
                    textBox1.Text = "��������桱�˵���������ݱ��浽ԭ·������ݼ�ΪCtrl+S";
                    break;

                case "���Ϊ>>":
                    textBox1.Text = "��������Ϊ���˵���������ݱ��浽ָ��·�����ҿ��������ļ���";
                    break;

                case "�˳�>>":
                    textBox1.Text = "������˳����˵����رմ�ģ�鹦�ܿ�";
                    break;

                case "�޸�>>":
                    textBox1.Text = "������޸ġ��˵�����ѡ�е����ݴ��ڿ��޸�״̬";
                    break;

                default:
                    break;
            }*/
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            switch (this.listView1.SelectedItems[0].Text)
            {
                case "��>>":
                    textBox1.Text = "������򿪡��˵���ͨ��·��ѡ����Ҫ��ȡ�ı�����ݣ�����Ϊ.xls,.xlsx,.csv������ݼ�ΪCtrl+O��Ҳ���Ե�������ϵ�����ͼƬ�򿪶�ȡ���ݱ��";
                    break;

                case "����>>":
                    textBox1.Text = "��������桱�˵���������ݱ��浽ԭ·������ݼ�ΪCtrl+S";
                    break;

                case "���Ϊ>>":
                    textBox1.Text = "��������Ϊ���˵���������ݱ��浽ָ��·�����ҿ��������ļ���";
                    break;

                case "�˳�>>":
                    textBox1.Text = "������˳����˵����رմ�ģ�鹦��";
                    break;

                case "�޸�>>":
                    textBox1.Text = "������޸ġ��˵�����ѡ�е����ݴ��ڿ��޸�״̬";
                    break;

                default:
                    break;
            }
        }
    }
}