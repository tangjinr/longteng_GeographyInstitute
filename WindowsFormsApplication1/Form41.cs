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
    public partial class Form41 : Form
    {
        private string fileName = null;
        private DataTable dt1 = new DataTable();
        private Dictionary<int, String> selectRows1 = new Dictionary<int, String>();//总表选择行

        public Form41(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
            openFile();
        }

        public DataTable getDt1()
        {
            return dt1;
        }

        public Dictionary<int, String> getSelectRows1()
        {
            return selectRows1;
        }

        private void getDataTable(string fileName)
        {
            if (fileName.IndexOf(".csv") > 0)
            {
                CSVHelper csvHelper = new CSVHelper(fileName);
                dt1 = csvHelper[1, -1, 1, -1];
            }
            else
            {
                ExcelHelper excelHelper = new ExcelHelper(fileName);
                dt1 = excelHelper.ExcelToDataTable("");//这里可以添加参数，读取第几个sheet
            }
        }

        private void openFile()
        {
            fileName = fileName.Replace("\\", "/");
            getDataTable(fileName);
            if (dt1 != null)
            {
                dataGridView1.DataSource = dt1;
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    if (checkBox1.Checked == true)
                    {
                        for (int i = 1; i < dt1.Rows.Count; i++)
                        {
                            ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = true;
                            if (!selectRows1.ContainsKey(i))
                            {
                                selectRows1.Add(i, dataGridView1.Rows[i].Cells[1].Value.ToString());
                            }
                        }
                        if (selectRows1[selectRows1.Keys.Count] == "")
                        {
                            selectRows1.Remove(selectRows1.Keys.Count);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = false;
                            selectRows1.Remove(i);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == false)
                {
                    checkCell.Value = true;
                    selectRows1.Add(e.RowIndex, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                else
                {
                    checkCell.Value = false;
                    selectRows1.Remove(e.RowIndex);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
