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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private Dictionary<int, String> selectRows1 = new Dictionary<int, String>();//总表选择行
        private Dictionary<int, String> selectRows2 = new Dictionary<int, String>();//输入表选择行
        private DataTable resultData = new DataTable();//输出结果
        private DataTable dt1 = null;
        private DataTable dt2 = null;
        Form41 primaryTable = null;
        Form42 secondaryTable = null;
        private string resultFileName = null;

        private bool getData()
        {
            if (primaryTable == null || secondaryTable == null)
            {
                MessageBox.Show("未读取数据！");
                return false;
            }
            dt1 = primaryTable.getDt1();
            selectRows1 = primaryTable.getSelectRows1();
            dt2 = secondaryTable.getDt2();
            return true;
        }

        private void openFile(int num)
        {
            OpenFileDialog open = new OpenFileDialog();

            //设置文件类型  
            open.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*";

            //保存对话框是否记忆上次打开的目录  
            open.RestoreDirectory = true;

            if (open.ShowDialog() != DialogResult.OK) return;

            //点了确定按钮进入  
            if (num == 1)
            {
                primaryTable = new Form41(open.FileName);
                primaryTable.Show();
            }
            else if (num == 2)
            {
                secondaryTable = new Form42(open.FileName);
                secondaryTable.Show();
            }
            else { }
        }

        private static void GridToExcelByNPOI(DataTable dt, string strExcelFileName)
        {
            try
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
                ISheet sheet = workbook.CreateSheet("计算结果");

                ICellStyle HeadercellStyle = workbook.CreateCellStyle();
                HeadercellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //字体
                NPOI.SS.UserModel.IFont headerfont = workbook.CreateFont();
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                HeadercellStyle.SetFont(headerfont);


                //用column name 作为列名
                int icolIndex = 0;
                IRow headerRow = sheet.CreateRow(0);
                foreach (DataColumn item in dt.Columns)
                {
                    ICell cell = headerRow.CreateCell(icolIndex);
                    cell.SetCellValue(item.ColumnName);
                    cell.CellStyle = HeadercellStyle;
                    icolIndex++;
                }

                ICellStyle cellStyle = workbook.CreateCellStyle();

                //为避免日期格式被Excel自动替换，所以设定 format 为 『@』 表示一率当成text來看
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;


                NPOI.SS.UserModel.IFont cellfont = workbook.CreateFont();
                cellfont.Boldweight = (short)FontBoldWeight.Normal;
                cellStyle.SetFont(cellfont);

                //建立内容行
                int iRowIndex = 1;
                int iCellIndex = 0;
                foreach (DataRow Rowitem in dt.Rows)
                {
                    IRow DataRow = sheet.CreateRow(iRowIndex);
                    foreach (DataColumn Colitem in dt.Columns)
                    {

                        ICell cell = DataRow.CreateCell(iCellIndex);
                        cell.SetCellValue(Rowitem[Colitem].ToString());
                        cell.CellStyle = cellStyle;
                        iCellIndex++;
                    }
                    iCellIndex = 0;
                    iRowIndex++;
                }

                //自适应列宽度
                for (int i = 0; i < icolIndex; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                //写Excel
                FileStream file = new FileStream(strExcelFileName, FileMode.OpenOrCreate);
                workbook.Write(file);
                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
            }

            //finally {
            //    workbook = null;
            //}


        }

        private void 读取主表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile(1);
        }

        private void 读取附表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile(2);
        }

        private void 计算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!getData()) return;
                NPVcalc npvcalc = new NPVcalc(dt1, dt2, selectRows1, selectRows2);
                resultData = npvcalc.getResult();
                string localFilePath = String.Empty;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //设置文件类型
                saveFileDialog1.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";

                //设置文件名称：
                saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "NPV输出.xlsx";

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                //点了保存按钮进入  
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    GridToExcelByNPOI(resultData, saveFileDialog1.FileName);
                    if (MessageBox.Show("计算并保存成功，是否查看?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        resultFileName = saveFileDialog1.FileName;
                        resultFileName = resultFileName.Replace("\\", "/");
                        ExcelHelper excelHelper = new ExcelHelper(resultFileName);
                        dataGridView1.DataSource = excelHelper.ExcelToDataTable("计算结果");
                        //若结果不需要弹窗显示，注释掉下面两行
                        //Form43 resultForm = new Form43(fileName);
                        //resultForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算错误！");
            }
        }

        private void 结果显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resultFileName == null)
            {
                MessageBox.Show("未读取数据！");
                return;
            }
            ExcelHelper excelHelper = new ExcelHelper(resultFileName);
            dataGridView1.DataSource = excelHelper.ExcelToDataTable("计算结果");
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form44 helpForm = new Form44();
            helpForm.Show();
        }
    }
}
