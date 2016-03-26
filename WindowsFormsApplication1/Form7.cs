using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        private bool isX = true;

        private string fileName = null;
        private DataTable dt = new DataTable();

        private DigramHelper myDH = new DigramHelper();

        private List<ArrayList> resultDT = new List<ArrayList>();

        public Form7()
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
            }
        }

        //判断是否为数字
        private bool isNum(string str)
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (r.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        //或许横坐标x数据
        private ArrayList getXData(int num)
        {
            ArrayList alX = new ArrayList();
            int startNum = 0;
            if (checkBox4.Checked) startNum = 1;
            if (radioButton1.Checked)
            {
                int Col = dataGridView6.ColumnCount;
                for (int i = startNum; i < Col; i++)
                {
                    string x = dataGridView6.Rows[num].Cells[i].Value.ToString();
                    if (!isNum(x)) return null;
                    alX.Add(x);
                }
            }
            else
            {
                int Row = dataGridView6.RowCount - 1;
                for (int i = startNum; i < Row; i++)
                {
                    string x = dataGridView6.Rows[i].Cells[num].Value.ToString();
                    if (!isNum(x)) return null;
                    alX.Add(x);
                }
            }
            return alX;
        }

        //或许横坐标y数据
        private ArrayList getYData(ArrayList x, int num)
        {
            ArrayList alY = new ArrayList();
            int len = x.Count;
            int startNum = 0;
            if (checkBox4.Checked)
            {
                startNum = 1;
                len++;
            }

            if (radioButton1.Checked)
            {
                int Col = dataGridView6.ColumnCount;
                for (int i = startNum; i < len; i++)
                {
                    string y = dataGridView6.Rows[num].Cells[i].Value.ToString();
                    if (!isNum(y)) return null;
                    alY.Add(y);
                }
            }
            else
            {
                int Row = dataGridView6.RowCount;
                for (int i = startNum; i < len; i++)
                {
                    string y = dataGridView6.Rows[i].Cells[num].Value.ToString();
                    if (!isNum(y)) return null;
                    alY.Add(y);
                }
            }
            return alY;
        }

        //使DataGridView整列可以选择
        private void setDataGridView(DataGridView dg1)
        {
            int count = dg1.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dg1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dg1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dataGridView6_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (isX) label18.Text = (e.ColumnIndex + 1).ToString();
                else label21.Text = (e.ColumnIndex + 1).ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
                    if (radioButton2.Checked)
                    {
                        dataGridView6.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        setDataGridView(dataGridView6);
                    }
                    dataGridView6.DataSource = dt;
                }
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(chart1, e.Location);
            }
        }

        private void savePIC_Click(object sender, EventArgs e)
        {
            SaveFileDialog savePicSFD = new SaveFileDialog();
            //设置对话框标题
            savePicSFD.Title = "保存图片";
            //设置默认文件类型显示顺序
            savePicSFD.FilterIndex = 2;
            //保存对话框是否记忆上次打开的目录
            savePicSFD.RestoreDirectory = true;
            //设置文件类型
            savePicSFD.Filter = "Bmp格式|*.bmp|Jpg格式|*.jpg|Png格式|*.png|Tif格式|*.tif";
            //设置默认文件名称
            savePicSFD.FileName = DateTime.Now.ToString("yyyyMMdd") + "pic";

            if (savePicSFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(savePicSFD.FileName);//保存的文件信息
                    string filePath = fileInfo.DirectoryName;//文件路径，不带文件名
                    string fileName = fileInfo.Name;//文件名，不带路径，带格式后缀
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                    string fileFormat = fileInfo.Extension;//文件格式后缀

                    chart1.TempDirectory = filePath;//设置图片路径
                    chart1.FileManager.FileName = fileName;//设置图片文件名
                    //设置图片格式
                    switch (fileFormat)
                    {
                        case ".bmp":
                            chart1.FileManager.ImageFormat = dotnetCHARTING.WinForms.ImageFormat.Bmp;
                            break;
                        case ".jpg":
                            chart1.FileManager.ImageFormat = dotnetCHARTING.WinForms.ImageFormat.Jpg;
                            break;
                        case ".png":
                            chart1.FileManager.ImageFormat = dotnetCHARTING.WinForms.ImageFormat.Png;
                            break;
                        case ".tif":
                            chart1.FileManager.ImageFormat = dotnetCHARTING.WinForms.ImageFormat.Tif;
                            break;
                        default:
                            chart1.FileManager.ImageFormat = dotnetCHARTING.WinForms.ImageFormat.Png;
                            break;
                    }
                    chart1.FileManager.SaveImage();//保存

                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label16.Text = "第一列作为横纵坐标名称";
                label19.Text = "行数据";
                label22.Text = "行数据";
                label18.Text = "..";
                label21.Text = "..";
                dataGridView6.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label16.Text = "第一行作为横纵坐标名称";
                label19.Text = "列数据";
                label22.Text = "列数据";
                label18.Text = "..";
                label21.Text = "..";
                dataGridView6.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                setDataGridView(dataGridView6);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox2.ReadOnly = true;
                toolTip1.SetToolTip(textBox2, "此处不需要填写横坐标名称");
                textBox4.ReadOnly = true;
                toolTip1.SetToolTip(textBox4, "此处不需要填写纵坐标名称");
            }
            else
            {
                textBox2.ReadOnly = false;
                toolTip1.SetToolTip(textBox2, null);
                textBox4.ReadOnly = false;
                toolTip1.SetToolTip(textBox4, null);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView6.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                isX = true;
                dataGridView6.ClearSelection();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (dataGridView6.DataSource == null)
            {
                MessageBox.Show("请先读取数据！");
            }
            else
            {
                isX = false;
                dataGridView6.ClearSelection();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView6.ReadOnly = !dataGridView6.ReadOnly;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Use3D = !chart1.Use3D;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "饼状图(合并)" || comboBox1.Text == "饼状图(分散)")
            {
                textBox2.ReadOnly = true;
                toolTip1.SetToolTip(textBox2, "此处不需要填写横坐标名称");
                textBox3.ReadOnly = true;
                toolTip1.SetToolTip(textBox3, "此处不需要填写图例名称");
                textBox4.ReadOnly = true;
                toolTip1.SetToolTip(textBox4, "此处不需要填写纵坐标名称");
            }
            else
            {
                textBox2.ReadOnly = false;
                toolTip1.SetToolTip(textBox2, null);
                textBox3.ReadOnly = false;
                toolTip1.SetToolTip(textBox3, null);
                textBox4.ReadOnly = false;
                toolTip1.SetToolTip(textBox4, null);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isNum(label18.Text) && isNum(label21.Text))
            {
                chart1.Refresh();
                chart1.SeriesCollection.Clear();
                try
                {
                    resultDT.Clear();

                    int xNum = Int32.Parse(label18.Text) - 1, yNum = Int32.Parse(label21.Text) - 1;

                    ArrayList x = getXData(xNum);
                    if (x == null) throw new Exception();
                    else resultDT.Add(x);

                    ArrayList y = getYData(x, yNum);
                    if (y == null) throw new Exception();
                    else resultDT.Add(y);

                    myDH.Title = textBox1.Text;
                    myDH.SeriesName = textBox3.Text;
                    if (checkBox4.Checked)
                    {
                        if (radioButton1.Checked)
                        {
                            myDH.XTitle = dataGridView6.Rows[xNum].Cells[0].Value.ToString();
                            myDH.YTitle = dataGridView6.Rows[yNum].Cells[0].Value.ToString();
                        }
                        if (radioButton2.Checked)
                        {
                            myDH.XTitle = dataGridView6.Rows[0].Cells[xNum].Value.ToString();
                            myDH.YTitle = dataGridView6.Rows[0].Cells[yNum].Value.ToString();
                        }
                    }
                    else
                    {
                        myDH.XTitle = textBox2.Text;
                        myDH.YTitle = textBox4.Text;
                    }
                    myDH.PicHight = 278;
                    myDH.PicWidth = 519;
                    myDH.DataSource = resultDT;
                    string text = comboBox1.Text;
                    if (text == "柱状图")
                    {
                        myDH.CreateColumn(chart1);
                    }
                    else if (text == "折线图")
                    {
                        myDH.CreateLine(chart1);
                    }
                    else if (text == "饼状图(合并)")
                    {
                        myDH.CreatePie1(chart1);
                    }
                    else if (text == "饼状图(分散)")
                    {
                        myDH.CreatePie2(chart1);
                    }
                    else if (text == "雷达图")
                    {
                        myDH.CreateRadar(chart1);
                    }
                    else
                    {
                        //show.CreateColumn(chart1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("所选数据内容存在非数字，无法成图！");
                }
            }
            else
            {
                MessageBox.Show("请先选择数据");
            }
        }

        //行标题点击事件
        private void dataGridView6_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (isX) label18.Text = (e.RowIndex + 1).ToString();
                else label21.Text = (e.RowIndex + 1).ToString();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "饼状图(合并)" || comboBox1.Text == "饼状图(分散)")
            {
                toolTip1.SetToolTip(textBox3, "此处不需要填写图例名称");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "饼状图(合并)" || comboBox1.Text == "饼状图(分散)")
            {
                toolTip1.SetToolTip(textBox2, "此处不需要填写横坐标名称");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "饼状图(合并)" || comboBox1.Text == "饼状图(分散)")
            {
                toolTip1.SetToolTip(textBox4, "此处不需要填写横坐标名称");
            }
        }
    }
}
