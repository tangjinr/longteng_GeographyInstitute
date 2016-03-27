<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;

namespace WindowsFormsApplication1
{
    public class ExcelHelper : IDisposable
    {
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <returns>返回的DataTable</returns>
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }
        
        public DataTable ExcelToDataTable(string sheetName)
        {
            DataTable data = new DataTable();
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                ISheet sheet = null;
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    //获取总的列数
                    int maxNum = -1;
                    for (int i = 0; i <= 65535; i++)
                    {
                        
                        IRow row = sheet.GetRow(i);
                        if (row != null)
                        {
                            int x = row.LastCellNum;
                            if(x > maxNum)
                            {
                                maxNum = x;
                            }
                        }
                    }

                    //添加列号
                    for (int i = 0; i < maxNum; i++)
                    {
                        int num = i + 1;
                        string x = "";
                        while (num != 0)
                        {
                            string y = "";
                            if (num % 26 == 0)
                            {
                                y += (char)((int)'A' + 25);
                                num--;
                            }
                            else y += (char)((int)'A' + num % 26 - 1);
                            x = x.Insert(0, y);
                            num = num / 26;
                        }
                        data.Columns.Add(x);
                    }

                    //获取单元格数据
                    int rowCount = sheet.LastRowNum;
                    for (int i = 0; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow dataRow = data.NewRow();
                        //判断每一行，没有数据的行默认是null
                        if (row != null)
                        {
                            //每一个单元格的内容
                            for (int j = row.FirstCellNum; j < maxNum; ++j)
                            {
                                ICell cell = row.GetCell(j);
                                if (cell != null) //同理，没有数据的单元格都默认是null
                                {
                                    object cellValue = null;
                                    switch (cell.CellType)
                                    {
                                        case CellType.Error: //错误类型     
                                            cellValue = cell.ErrorCellValue;
                                            break;
                                        case CellType.Blank: //空数据类型处理
                                            cellValue = "";
                                            break;
                                        case CellType.Boolean: //Boolean数据类型处理
                                            cellValue = cell.BooleanCellValue;
                                            break;
                                        case CellType.String: //字符串类型
                                            cellValue = cell.StringCellValue;
                                            break;
                                        case CellType.Numeric: //数字类型
                                            if (DateUtil.IsCellDateFormatted(cell))
                                            {
                                                cellValue = cell.DateCellValue.ToShortDateString();
                                            }
                                            else
                                            {
                                                cellValue = cell.NumericCellValue;
                                            }
                                            break;
                                        case CellType.Formula: //公式类型
                                            try
                                            {
                                                cellValue = cell.NumericCellValue;//格式错误，比如=1/0
                                            }
                                            catch(System.InvalidOperationException)
                                            { 
                                                cellValue = cell.ToString();//直接转换为字符串
                                            }
                                            catch (System.FormatException)
                                            { 
                                                cellValue = cell.ToString();//直接转换为字符串
                                            }
                                            break;
                                        default:
                                            cellValue = "";
                                            break;
                                    }
                                    dataRow[j] = cellValue.ToString();
                                }
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }
                fs = null;
                disposed = true;
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;

namespace WindowsFormsApplication1
{
    public class ExcelHelper : IDisposable
    {
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <returns>返回的DataTable</returns>
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }
        
        public DataTable ExcelToDataTable(string sheetName)
        {
            DataTable data = new DataTable();
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                ISheet sheet = null;
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    //获取总的列数
                    int maxNum = -1;
                    for (int i = 0; i <= 65535; i++)
                    {
                        
                        IRow row = sheet.GetRow(i);
                        if (row != null)
                        {
                            int x = row.LastCellNum;
                            if(x > maxNum)
                            {
                                maxNum = x;
                            }
                        }
                    }

                    //添加列号
                    for (int i = 0; i < maxNum; i++)
                    {
                        int num = i + 1;
                        string x = "";
                        while (num != 0)
                        {
                            string y = "";
                            if (num % 26 == 0)
                            {
                                y += (char)((int)'A' + 25);
                                num--;
                            }
                            else y += (char)((int)'A' + num % 26 - 1);
                            x = x.Insert(0, y);
                            num = num / 26;
                        }
                        data.Columns.Add(x);
                    }

                    //获取单元格数据
                    int rowCount = sheet.LastRowNum;
                    for (int i = 0; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow dataRow = data.NewRow();
                        //判断每一行，没有数据的行默认是null
                        if (row != null)
                        {
                            //每一个单元格的内容
                            for (int j = row.FirstCellNum; j < maxNum; ++j)
                            {
                                ICell cell = row.GetCell(j);
                                if (cell != null) //同理，没有数据的单元格都默认是null
                                {
                                    object cellValue = null;
                                    switch (cell.CellType)
                                    {
                                        case CellType.Error: //错误类型     
                                            cellValue = cell.ErrorCellValue;
                                            break;
                                        case CellType.Blank: //空数据类型处理
                                            cellValue = "";
                                            break;
                                        case CellType.Boolean: //Boolean数据类型处理
                                            cellValue = cell.BooleanCellValue;
                                            break;
                                        case CellType.String: //字符串类型
                                            cellValue = cell.StringCellValue;
                                            break;
                                        case CellType.Numeric: //数字类型
                                            if (DateUtil.IsCellDateFormatted(cell))
                                            {
                                                cellValue = cell.DateCellValue.ToShortDateString();
                                            }
                                            else
                                            {
                                                cellValue = cell.NumericCellValue;
                                            }
                                            break;
                                        case CellType.Formula: //公式类型
                                            try
                                            {
                                                cellValue = cell.NumericCellValue;//格式错误，比如=1/0
                                            }
                                            catch(System.InvalidOperationException)
                                            { 
                                                cellValue = cell.ToString();//直接转换为字符串
                                            }
                                            catch (System.FormatException)
                                            { 
                                                cellValue = cell.ToString();//直接转换为字符串
                                            }
                                            break;
                                        default:
                                            cellValue = "";
                                            break;
                                    }
                                    dataRow[j] = cellValue.ToString();
                                }
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }
                fs = null;
                disposed = true;
            }
        }
    }
}
>>>>>>> 167f7a405e7de9995d073c43dd99a9fa99a63730
