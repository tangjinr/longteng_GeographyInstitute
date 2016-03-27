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
    public partial class Form42 : Form
    {
        private string fileName = null;
        private DataTable dt2 = new DataTable();

        public Form42(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
            openFile();
        }

        private void getDataTable(string fileName)
        {
            if (fileName.IndexOf(".csv") > 0)
            {
                CSVHelper csvHelper = new CSVHelper(fileName);
                dt2 = csvHelper[1, -1, 1, -1];
            }
            else
            {
                ExcelHelper excelHelper = new ExcelHelper(fileName);
                dt2 = excelHelper.ExcelToDataTable("");//这里可以添加参数，读取第几个sheet
            }
        }

        private void openFile()
        {
            fileName = fileName.Replace("\\", "/");
            getDataTable(fileName);
            if (dt2 != null)
            {
                dataGridView1.DataSource = dt2;
            }
        }

        public DataTable getDt2()
        {
            return dt2;
        }

        private void 重新选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            //设置文件类型  
            open.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*";

            //保存对话框是否记忆上次打开的目录  
            open.RestoreDirectory = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                this.fileName = open.FileName;
                openFile();
            }
        }
    }
}
