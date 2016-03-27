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
    public partial class Form5 : Form
    {
        private DataTable dt = new DataTable();

        private ArrayList y1Result = new ArrayList();
        private ArrayList x1Result = new ArrayList();
        private ArrayList y2Result = new ArrayList();
        private ArrayList x2Result = new ArrayList();

        private int paraNum = 4;

        private string fileName = null;

        public Form5()
        {
            InitializeComponent();
        }

        public string ReadTxt(string path)
        {
            try
            {
                FileStream fs = File.OpenRead(path);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                return sr.ReadToEnd();
            }
            catch (Exception ex) { return null; }
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

        private string getSURPara(ArrayList al)
        {
            string[] x = (string[])al.ToArray(typeof(string));
            string result = x[0];
            int count = x.Length;
            for (int i = 1; i < count; i++)
            {
                result += "+" + x[i];
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
                    SaveFileDialog savetxtSFD = new SaveFileDialog();
                    //设置对话框标题
                    savetxtSFD.Title = "保存SUR结果";
                    //设置默认文件类型显示顺序
                    savetxtSFD.FilterIndex = 2;
                    //保存对话框是否记忆上次打开的目录
                    savetxtSFD.RestoreDirectory = true;
                    //设置文件类型
                    savetxtSFD.Filter = "Txt格式|*.txt";
                    //设置默认文件名称
                    savetxtSFD.FileName = DateTime.Now.ToString("yyyyMMdd") + "sur结果";

                    string fileNameX = null;//文件名，不带路径，不带格式后缀
                    string filePathX = null;//文件路径，不带文件名

                    if (savetxtSFD.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(savetxtSFD.FileName);//保存的文件信息
                        filePathX = fileInfo.DirectoryName;
                        filePathX = filePathX.Replace("\\", "/");

                        fileNameX = fileInfo.Name;//文件名，不带路径，带格式后缀
                    }

                    conR.EvaluateNoReturn("library(systemfit)");
                    conR.EvaluateNoReturn("hsb2<-read.csv('" + fileName + "')");
                    conR.EvaluateNoReturn("r1<-" + getSURPara(y1Result) + "~" + getSURPara(x1Result));//用户选取的参数
                    conR.EvaluateNoReturn("r2<-" + getSURPara(y2Result) + "~" + getSURPara(x2Result));//用户选取的参数
                    //conR.EvaluateNoReturn("r1<-v37~v16+v17+v18+v19+v20+v21+v22+v23+v24+v26+v32+v40+v41+v42+v47+v50+v53");//用户选取的参数
                    //conR.EvaluateNoReturn("r2<-v13~v6+v10+v14+v33+v40+v41+v42+v48+v51+v54+v60+v70");//用户选取的参数
                    conR.EvaluateNoReturn("fitsur<-systemfit(list(v1reg = r1, v2reg = r2),'SUR',data=hsb2)");
                    conR.EvaluateNoReturn("write(capture.output(summary(fitsur)),file = '" + filePathX + "/" + fileNameX + ".txt')");
                    txtSUResult.Text = ReadTxt(filePathX.Replace("/", "\\\\") + "\\\\" + fileNameX + ".txt");

                    MessageBox.Show("计算并保存成功!");
                }
                catch (Exception ex) { MessageBox.Show("参数选择无法参与计算，保存失败!"); }
            }
            catch (Exception ex) { MessageBox.Show("程序链接失败!"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|csv文件(*.csv*)|*.csv*|全部文件(*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                fileName = fileName.Replace("\\", "/");
                getDataTable(fileName);
                if (dt != null)
                {
                    dataGridView7.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    dataGridView7.DataSource = dt;
                    setDataGridView(dataGridView7);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 4;
                getCellSelected(y1Result, paraNum, dataGridView7);
                showResult(y1Result, label6, "Y1:");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 5;
                getCellSelected(x1Result, paraNum, dataGridView7);
                showResult(x1Result, label7, "X1:");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getCellSelected(x1Result, paraNum, dataGridView7);
            showResult(x1Result, label7, "X1:");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 6;
                getCellSelected(y2Result, paraNum, dataGridView7);
                showResult(y2Result, label8, "Y2:");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 7;
                getCellSelected(x2Result, paraNum, dataGridView7);
                showResult(x2Result, label9, "X2:");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            getCellSelected(x2Result, paraNum, dataGridView7);
            showResult(x2Result, label9, "X2:");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (y1Result.Count <= 0)
            {
                MessageBox.Show("请选择Y1参数!");
            }
            else if (x1Result.Count <= 0)
            {
                MessageBox.Show("请先读取X1参数!");
            }
            else if (y2Result.Count <= 0)
            {
                MessageBox.Show("请选择Y2参数!");
            }
            else if (x2Result.Count <= 0)
            {
                MessageBox.Show("请先读取X2参数!");
            }
            else
            {
                useR_Calc(fileName);
            }
        }

        private void dataGridView7_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (paraNum == 4) //y1的参数
            {
                MessageBox.Show("ad");
                getCellSelected(y1Result, paraNum, dataGridView7);
                showResult(y1Result, label6, "Y1:");
            }
            else if (paraNum == 5) //x1的参数
            {
                /*getCellSelected(x1Result, paraNum, dataGridView7);
                showResult(x1Result, label7, "X1:");*/
            }
            else if (paraNum == 6) //y2的参数
            {
                getCellSelected(y2Result, paraNum, dataGridView7);
                showResult(y2Result, label8, "Y2:");
            }
            else if (paraNum == 7) //x2的参数
            {
                /*getCellSelected(x2Result, paraNum, dataGridView7);
                showResult(x2Result, label9, "X2:");*/
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
    public partial class Form5 : Form
    {
        private DataTable dt = new DataTable();

        private ArrayList y1Result = new ArrayList();
        private ArrayList x1Result = new ArrayList();
        private ArrayList y2Result = new ArrayList();
        private ArrayList x2Result = new ArrayList();

        private int paraNum = 4;

        private string fileName = null;

        public Form5()
        {
            InitializeComponent();
        }

        public string ReadTxt(string path)
        {
            try
            {
                FileStream fs = File.OpenRead(path);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                return sr.ReadToEnd();
            }
            catch (Exception ex) { return null; }
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

        private string getSURPara(ArrayList al)
        {
            string[] x = (string[])al.ToArray(typeof(string));
            string result = x[0];
            int count = x.Length;
            for (int i = 1; i < count; i++)
            {
                result += "+" + x[i];
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
                    SaveFileDialog savetxtSFD = new SaveFileDialog();
                    //设置对话框标题
                    savetxtSFD.Title = "保存SUR结果";
                    //设置默认文件类型显示顺序
                    savetxtSFD.FilterIndex = 2;
                    //保存对话框是否记忆上次打开的目录
                    savetxtSFD.RestoreDirectory = true;
                    //设置文件类型
                    savetxtSFD.Filter = "Txt格式|*.txt";
                    //设置默认文件名称
                    savetxtSFD.FileName = DateTime.Now.ToString("yyyyMMdd") + "sur结果";

                    string fileNameX = null;//文件名，不带路径，不带格式后缀
                    string filePathX = null;//文件路径，不带文件名

                    if (savetxtSFD.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(savetxtSFD.FileName);//保存的文件信息
                        filePathX = fileInfo.DirectoryName;
                        filePathX = filePathX.Replace("\\", "/");

                        fileNameX = fileInfo.Name;//文件名，不带路径，带格式后缀
                    }

                    conR.EvaluateNoReturn("library(systemfit)");
                    conR.EvaluateNoReturn("hsb2<-read.csv('" + fileName + "')");
                    conR.EvaluateNoReturn("r1<-" + getSURPara(y1Result) + "~" + getSURPara(x1Result));//用户选取的参数
                    conR.EvaluateNoReturn("r2<-" + getSURPara(y2Result) + "~" + getSURPara(x2Result));//用户选取的参数
                    //conR.EvaluateNoReturn("r1<-v37~v16+v17+v18+v19+v20+v21+v22+v23+v24+v26+v32+v40+v41+v42+v47+v50+v53");//用户选取的参数
                    //conR.EvaluateNoReturn("r2<-v13~v6+v10+v14+v33+v40+v41+v42+v48+v51+v54+v60+v70");//用户选取的参数
                    conR.EvaluateNoReturn("fitsur<-systemfit(list(v1reg = r1, v2reg = r2),'SUR',data=hsb2)");
                    conR.EvaluateNoReturn("write(capture.output(summary(fitsur)),file = '" + filePathX + "/" + fileNameX + ".txt')");
                    txtSUResult.Text = ReadTxt(filePathX.Replace("/", "\\\\") + "\\\\" + fileNameX + ".txt");

                    MessageBox.Show("计算并保存成功!");
                }
                catch (Exception ex) { MessageBox.Show("参数选择无法参与计算，保存失败!"); }
            }
            catch (Exception ex) { MessageBox.Show("程序链接失败!"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|csv文件(*.csv*)|*.csv*|全部文件(*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                fileName = fileName.Replace("\\", "/");
                getDataTable(fileName);
                if (dt != null)
                {
                    dataGridView7.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    dataGridView7.DataSource = dt;
                    setDataGridView(dataGridView7);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 4;
                getCellSelected(y1Result, paraNum, dataGridView7);
                showResult(y1Result, label6, "Y1:");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 5;
                getCellSelected(x1Result, paraNum, dataGridView7);
                showResult(x1Result, label7, "X1:");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getCellSelected(x1Result, paraNum, dataGridView7);
            showResult(x1Result, label7, "X1:");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 6;
                getCellSelected(y2Result, paraNum, dataGridView7);
                showResult(y2Result, label8, "Y2:");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                dataGridView7.ClearSelection();
                paraNum = 7;
                getCellSelected(x2Result, paraNum, dataGridView7);
                showResult(x2Result, label9, "X2:");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            getCellSelected(x2Result, paraNum, dataGridView7);
            showResult(x2Result, label9, "X2:");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (y1Result.Count <= 0)
            {
                MessageBox.Show("请选择Y1参数!");
            }
            else if (x1Result.Count <= 0)
            {
                MessageBox.Show("请先读取X1参数!");
            }
            else if (y2Result.Count <= 0)
            {
                MessageBox.Show("请选择Y2参数!");
            }
            else if (x2Result.Count <= 0)
            {
                MessageBox.Show("请先读取X2参数!");
            }
            else
            {
                useR_Calc(fileName);
            }
        }

        private void dataGridView7_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (paraNum == 4) //y1的参数
            {
                MessageBox.Show("ad");
                getCellSelected(y1Result, paraNum, dataGridView7);
                showResult(y1Result, label6, "Y1:");
            }
            else if (paraNum == 5) //x1的参数
            {
                /*getCellSelected(x1Result, paraNum, dataGridView7);
                showResult(x1Result, label7, "X1:");*/
            }
            else if (paraNum == 6) //y2的参数
            {
                getCellSelected(y2Result, paraNum, dataGridView7);
                showResult(y2Result, label8, "Y2:");
            }
            else if (paraNum == 7) //x2的参数
            {
                /*getCellSelected(x2Result, paraNum, dataGridView7);
                showResult(x2Result, label9, "X2:");*/
            }
            else { }
        }
    }
}
>>>>>>> 167f7a405e7de9995d073c43dd99a9fa99a63730
