using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(150, Color.White);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isValid();
        }

        private void isValid()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名！", "提示");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入登录密码！", "提示");
            }
            else if (textBox1.Text != "admin")
            {
                MessageBox.Show("用户名不存在！", "提示");
            }
            else if (textBox2.Text != "admin")
            {
                MessageBox.Show("密码错误！", "警告");
            }
            else
            {
                if (MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Visible = false;
                    Form总 form总 = new Form总();
                    form总.ShowDialog();
                }
            }
            textBox2.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                isValid();//触发button事件  
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                isValid(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            textBox1.Focus();
        }
    }
}
