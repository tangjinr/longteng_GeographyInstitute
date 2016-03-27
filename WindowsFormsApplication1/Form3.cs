using System;
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
    public partial class Form3 : Form
    {
        private DataTable dt = new DataTable();
        private string fileName = null;
        private static string sheetName = null;

        public Form3()
        {
            InitializeComponent();
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
                sheetName = excelHelper.getSheetName();
            }
        }

        private void openFile()
        {
            dataGridView2.Visible = true;
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
                    dataGridView2.DataSource = dt;
                }
                label1.Visible = false;
                pictureBox1.Visible = false;
            }            
        }

        private static void GridToExcelByNPOI1(DataTable dt, string strExcelFileName)
        {
            IWorkbook workbook = null;
            if (strExcelFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook();
            }
            else if (strExcelFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook();
            }
            ISheet sheet = workbook.CreateSheet(sheetName);//这里需要读取到sheet1的内容

            //用column name 作为列名
            int icolIndex = 0;
            IRow headerRow = sheet.CreateRow(0);
            foreach (DataColumn item in dt.Columns)
            {
                ICell cell = headerRow.CreateCell(icolIndex);
                cell.SetCellValue(item.ColumnName);
                icolIndex++;
            }

            //建立内容行
            int iRowIndex = 1;
            int iCellIndex = 0;
            foreach (DataRow Rowitem in dt.Rows)
            {
                IRow DataRow = sheet.CreateRow(iRowIndex);
                foreach (DataColumn Colitem in dt.Columns)
                {
                    ICell cell = DataRow.CreateCell(iCellIndex);
                    string x = Rowitem[Colitem].ToString();
                    cell.SetCellValue(x);
                    iCellIndex++;
                }
                iCellIndex = 0;
                iRowIndex++;
            }

            //写Excel
            try
            {
                FileStream file = new FileStream(strExcelFileName, FileMode.Create);
                workbook.Write(file);
                file.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("文件以隐藏文件方式存在!");
            }
        }

        public static bool IsNumberic(string str)
        {
            //判断是否为整数字符串
            //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false
            int result = -1;   //result 定义为out 用来输出值
            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                result = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void GridToExcelByNPOI2(DataTable dt, string strExcelFileName)
        {
            IWorkbook workbook = null;
            if (strExcelFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook();
            }
            else if (strExcelFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook();
            }
            ISheet sheet = workbook.CreateSheet(sheetName);//这里需要读取到sheet1的内容

            //用column name 作为列名
            int icolIndex = 0;
            IRow headerRow = sheet.CreateRow(0);
            foreach (DataColumn item in dt.Columns)
            {
                ICell cell = headerRow.CreateCell(icolIndex);
                cell.SetCellValue(item.ColumnName);
                icolIndex++;
            }

            //建立内容行
            int iRowIndex = 1;
            int iCellIndex = 0;
            foreach (DataRow Rowitem in dt.Rows)
            {
                IRow DataRow = sheet.CreateRow(iRowIndex);
                foreach (DataColumn Colitem in dt.Columns)
                {
                    ICell cell = DataRow.CreateCell(iCellIndex);
                    string x = Rowitem[Colitem].ToString();
                    cell.SetCellValue(x);
                    iCellIndex++;
                }
                iCellIndex = 0;
                iRowIndex++;
            }

            //写Excel
            try
            {
                FileStream file = new FileStream(strExcelFileName, FileMode.CreateNew);
                workbook.Write(file);
                file.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("文件已存在！");
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.open2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.open1;
        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("请先读取数据!");
                return;
            }
            try
            {
                DataTable data = new DataTable();
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    data.Columns.Add(dataGridView2.Rows[0].Cells[i].Value.ToString());
                }
                for (int i = 1; i < dataGridView2.Rows.Count - 1; i++)
                {
                    DataRow dataRow = data.NewRow();
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        dataRow[j] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                    }
                    data.Rows.Add(dataRow);
                }
                GridToExcelByNPOI1(data, fileName);
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex) { MessageBox.Show("保存失败!"); }
        }

        private void 另存为ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("请先读取数据!");
                return;
            }
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                //设置文件类型
                saveFileDialog.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";

                //设置文件名称：
                saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "存储.xlsx";

                //保存对话框是否记忆上次打开的目录
                saveFileDialog.RestoreDirectory = true;

                saveFileDialog.FilterIndex = 0;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "另存为";
                //点了保存按钮进入
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable data = new DataTable();
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        data.Columns.Add(dataGridView2.Rows[0].Cells[i].Value.ToString());
                    }
                    for (int i = 1; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        DataRow dataRow = data.NewRow();
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            dataRow[j] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                    GridToExcelByNPOI2(data, saveFileDialog.FileName);
                    MessageBox.Show("另存为成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("另存为失败！");
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView2.DataSource != null)dataGridView2.BeginEdit(true);
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 helpForm = new Form31();
            helpForm.Show();
        }
    }
}
