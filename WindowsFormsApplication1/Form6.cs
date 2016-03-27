<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using STATCONNECTORCLNTLib;
using StatConnectorCommonLib;
using STATCONNECTORSRVLib;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Threading.Tasks;
namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private ArrayList ynResult = new ArrayList();
        private ArrayList xnResult = new ArrayList();
        private ArrayList znResult = new ArrayList();

        private DataTable dt = new DataTable();
        private string fileName = null;
        private int paraNum = 1;

        private bool preHandle(string fileName)
        {
            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
            }
            catch (Exception ex)
            {
                MessageBox.Show("链接错误！");
                return false;
            }

            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
                conR.EvaluateNoReturn("wheat <- read.csv(file ='" + fileName + "')");
                conR.EvaluateNoReturn("wheat$logoutput = log(wheat$output)");
                conR.EvaluateNoReturn("wheat$logqlabor = log(wheat$qlabor)");
                conR.EvaluateNoReturn("wheat$logvcapital = log(wheat$vcapital)");
                conR.EvaluateNoReturn("wheat$logplantarea = log(wheat$plantarea)");
                conR.EvaluateNoReturn("write.csv(wheat,file = '" + fileName + "')");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("表格选择错误，数据不符合效率计算条件！");
                return false;
            }

        }

        private void getDataTable(string fileName)
        {
            if (fileName.IndexOf(".csv") > 0)
            {
                CSVHelper csvHelper = new CSVHelper(fileName);
                dt = csvHelper[1, -1, 1, -1];
            }
            else
            {
                ExcelHelper excelHelper = new ExcelHelper(fileName);
                dt = excelHelper.ExcelToDataTable("");//这里可以添加参数，读取第几个sheet
            }
        }

        private void setDataGridView(DataGridView dg1)
        {
            int count = dg1.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dg1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dg1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|csv文件(*.csv*)|*.csv*|全部文件(*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                fileName = fileName.Replace("\\", "/");
                if (preHandle(fileName))
                {
                    getDataTable(fileName);
                    if (dt != null)
                    {
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        dataGridView1.DataSource = dt;
                        setDataGridView(dataGridView1);
                    }
                }
            }
        }

        private string getParaString(ArrayList al)
        {
            string[] x = (string[])al.ToArray(typeof(string));
            string result = "'" + x[0] + "'";
            int count = x.Length;
            for (int i = 1; i < count; i++)
            {
                result += ",'" + x[i] + "'";
            }
            return result;
        }

        private void useR_Calc(string fileName)
        {
            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
                try
                {
                    conR.EvaluateNoReturn("wheat <- read.csv(file ='" + fileName + "')");
                    conR.EvaluateNoReturn("library(frontier)");
                    conR.EvaluateNoReturn("yn <- c(" + getParaString(ynResult) + ")");//用户选取的参数
                    conR.EvaluateNoReturn("xn <- c(" + getParaString(xnResult) + ")");
                    conR.EvaluateNoReturn("zn <- c(" + getParaString(znResult) + ")");
                    conR.EvaluateNoReturn("translogwheat1 <- frontierQuad(yName = yn, xNames = xn, zNames = zn, data = wheat) ");
                    //conR.EvaluateNoReturn("summary(translogwheat1)");
                    conR.EvaluateNoReturn("wheat$effwheat1 = efficiencies(translogwheat1)");
                    //conR.EvaluateNoReturn("coefwheat1 = coefficients(translogwheat1)");
                    conR.EvaluateNoReturn("write.csv(wheat,file = '" + fileName + "')");
                    getDataTable(fileName);
                    if (dt != null)
                    {
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        dataGridView1.DataSource = dt;
                        setDataGridView(dataGridView1);
                    }
                    MessageBox.Show("计算并写入成功!");
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show("程序链接失败!"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ynResult.Count <= 0)
            {
                MessageBox.Show("请选择yn参数!");
            }
            else if (xnResult.Count <= 0)
            {
                MessageBox.Show("请选择xn参数!");
            }
            else if (znResult.Count <= 0)
            {
                MessageBox.Show("请选择zn参数!");
            }
            else useR_Calc(fileName);
        }

        private void showResult(ArrayList al, Label lb, string st)
        {
            lb.Text = st.ToString();
            if (al.Count > 0)
            {
                string[] result = (string[])al.ToArray(typeof(string));
                int count = result.Length;
                for (int i = 0; i < count - 1; i++)
                {
                    lb.Text += (result[i] + "、").ToString();
                }
                lb.Text += result[count - 1];
            }
        }

        private void getCellSelected(ArrayList list, int num, DataGridView dg1)
        {
            list.Clear();
            int xNum = dg1.ColumnCount;//获取列数
            for (int i = 0; i < xNum; i++)
            {
                if (dg1.Rows[0].Cells[i].Selected)
                {
                    list.Add(dg1.Rows[0].Cells[i].Value);
                    if (num == 4 || num == 6) break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 1;
                getCellSelected(ynResult, paraNum, dataGridView1);
                showResult(ynResult, label1, "yn:");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 2;
                getCellSelected(xnResult, paraNum, dataGridView1);
                showResult(xnResult, label2, "xn:");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 3;
                getCellSelected(znResult, paraNum, dataGridView1);
                showResult(znResult, label3, "zn:");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (paraNum == 1)//yn的参数
            {
                getCellSelected(ynResult, paraNum, dataGridView1);
                showResult(ynResult, label1, "yn:");
            }
            else if (paraNum == 2)//xn的参数
            {
                getCellSelected(xnResult, paraNum, dataGridView1);
                showResult(xnResult, label2, "xn:");
            }
            else if (paraNum == 3)//zn的参数
            {
                getCellSelected(znResult, paraNum, dataGridView1);
                showResult(znResult, label3, "zn:");
            }
            else { }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using STATCONNECTORCLNTLib;
using StatConnectorCommonLib;
using STATCONNECTORSRVLib;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Threading.Tasks;
namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private ArrayList ynResult = new ArrayList();
        private ArrayList xnResult = new ArrayList();
        private ArrayList znResult = new ArrayList();

        private DataTable dt = new DataTable();
        private string fileName = null;
        private int paraNum = 1;

        private bool preHandle(string fileName)
        {
            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
            }
            catch (Exception ex)
            {
                MessageBox.Show("链接错误！");
                return false;
            }

            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
                conR.EvaluateNoReturn("wheat <- read.csv(file ='" + fileName + "')");
                conR.EvaluateNoReturn("wheat$logoutput = log(wheat$output)");
                conR.EvaluateNoReturn("wheat$logqlabor = log(wheat$qlabor)");
                conR.EvaluateNoReturn("wheat$logvcapital = log(wheat$vcapital)");
                conR.EvaluateNoReturn("wheat$logplantarea = log(wheat$plantarea)");
                conR.EvaluateNoReturn("write.csv(wheat,file = '" + fileName + "')");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("表格选择错误，数据不符合效率计算条件！");
                return false;
            }

        }

        private void getDataTable(string fileName)
        {
            if (fileName.IndexOf(".csv") > 0)
            {
                CSVHelper csvHelper = new CSVHelper(fileName);
                dt = csvHelper[1, -1, 1, -1];
            }
            else
            {
                ExcelHelper excelHelper = new ExcelHelper(fileName);
                dt = excelHelper.ExcelToDataTable("");//这里可以添加参数，读取第几个sheet
            }
        }

        private void setDataGridView(DataGridView dg1)
        {
            int count = dg1.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dg1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dg1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|csv文件(*.csv*)|*.csv*|全部文件(*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                fileName = fileName.Replace("\\", "/");
                if (preHandle(fileName))
                {
                    getDataTable(fileName);
                    if (dt != null)
                    {
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        dataGridView1.DataSource = dt;
                        setDataGridView(dataGridView1);
                    }
                }
            }
        }

        private string getParaString(ArrayList al)
        {
            string[] x = (string[])al.ToArray(typeof(string));
            string result = "'" + x[0] + "'";
            int count = x.Length;
            for (int i = 1; i < count; i++)
            {
                result += ",'" + x[i] + "'";
            }
            return result;
        }

        private void useR_Calc(string fileName)
        {
            try
            {
                StatConnector conR = new STATCONNECTORSRVLib.StatConnectorClass();
                conR.Init("R");
                try
                {
                    conR.EvaluateNoReturn("wheat <- read.csv(file ='" + fileName + "')");
                    conR.EvaluateNoReturn("library(frontier)");
                    conR.EvaluateNoReturn("yn <- c(" + getParaString(ynResult) + ")");//用户选取的参数
                    conR.EvaluateNoReturn("xn <- c(" + getParaString(xnResult) + ")");
                    conR.EvaluateNoReturn("zn <- c(" + getParaString(znResult) + ")");
                    conR.EvaluateNoReturn("translogwheat1 <- frontierQuad(yName = yn, xNames = xn, zNames = zn, data = wheat) ");
                    //conR.EvaluateNoReturn("summary(translogwheat1)");
                    conR.EvaluateNoReturn("wheat$effwheat1 = efficiencies(translogwheat1)");
                    //conR.EvaluateNoReturn("coefwheat1 = coefficients(translogwheat1)");
                    conR.EvaluateNoReturn("write.csv(wheat,file = '" + fileName + "')");
                    getDataTable(fileName);
                    if (dt != null)
                    {
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        dataGridView1.DataSource = dt;
                        setDataGridView(dataGridView1);
                    }
                    MessageBox.Show("计算并写入成功!");
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show("程序链接失败!"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ynResult.Count <= 0)
            {
                MessageBox.Show("请选择yn参数!");
            }
            else if (xnResult.Count <= 0)
            {
                MessageBox.Show("请选择xn参数!");
            }
            else if (znResult.Count <= 0)
            {
                MessageBox.Show("请选择zn参数!");
            }
            else useR_Calc(fileName);
        }

        private void showResult(ArrayList al, Label lb, string st)
        {
            lb.Text = st.ToString();
            if (al.Count > 0)
            {
                string[] result = (string[])al.ToArray(typeof(string));
                int count = result.Length;
                for (int i = 0; i < count - 1; i++)
                {
                    lb.Text += (result[i] + "、").ToString();
                }
                lb.Text += result[count - 1];
            }
        }

        private void getCellSelected(ArrayList list, int num, DataGridView dg1)
        {
            list.Clear();
            int xNum = dg1.ColumnCount;//获取列数
            for (int i = 0; i < xNum; i++)
            {
                if (dg1.Rows[0].Cells[i].Selected)
                {
                    list.Add(dg1.Rows[0].Cells[i].Value);
                    if (num == 4 || num == 6) break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 1;
                getCellSelected(ynResult, paraNum, dataGridView1);
                showResult(ynResult, label1, "yn:");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 2;
                getCellSelected(xnResult, paraNum, dataGridView1);
                showResult(xnResult, label2, "xn:");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView1.ClearSelection();
                paraNum = 3;
                getCellSelected(znResult, paraNum, dataGridView1);
                showResult(znResult, label3, "zn:");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (paraNum == 1)//yn的参数
            {
                getCellSelected(ynResult, paraNum, dataGridView1);
                showResult(ynResult, label1, "yn:");
            }
            else if (paraNum == 2)//xn的参数
            {
                getCellSelected(xnResult, paraNum, dataGridView1);
                showResult(xnResult, label2, "xn:");
            }
            else if (paraNum == 3)//zn的参数
            {
                getCellSelected(znResult, paraNum, dataGridView1);
                showResult(znResult, label3, "zn:");
            }
            else { }
        }
    }
}
>>>>>>> 167f7a405e7de9995d073c43dd99a9fa99a63730
