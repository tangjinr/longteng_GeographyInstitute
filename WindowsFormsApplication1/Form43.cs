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
    public partial class Form43 : Form
    {
        private string fileName = null;
        public Form43(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
            showResult();
        }

        private void showResult()
        {
            ExcelHelper excelHelper = new ExcelHelper(fileName);
            dataGridView1.DataSource = excelHelper.ExcelToDataTable("计算结果");
        }
    }
}
