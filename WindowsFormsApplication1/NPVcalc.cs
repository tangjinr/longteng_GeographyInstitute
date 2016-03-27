<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NPVcalc
    {
        private double C = 0.0d;//初始投资额

        private string digit = "0.00";//小数位
        private int n = 0;//项目年限
        private double r = 0.0d;//银行贴现率
        private List<double> NPVj= new List<double>();//每年NPV
        private List<double> NPVsj = new List<double>();//每年NPV/按亩算
        private Dictionary<int,String> selectRows1;//总表选择行
        private Dictionary<int,String> selectRows2;//输入表选择行
        private DataTable dt1 = null;//总表
        private DataTable dt2 = null;//输入表
        private DataTable resultData = new DataTable(); //结果集
        
        public NPVcalc(DataTable dt1,DataTable dt2, Dictionary<int, String> selectRows1, Dictionary<int, String> selectRows2)
        {
            this.dt1 = dt1;
            this.dt2 = dt2;
            this.selectRows1 = selectRows1;
            this.selectRows2 = selectRows2;
            this.Calc();
        }

        private void Calc()
        {
             double V = 0.0d;//总产值
             double F = 0.0d;//总现金成本
             double NCF = 0.0d;//净现金流量
            double Vs = 0.0d;//总产值
            double Fs = 0.0d;//总现金成本
            double NCFs = 0.0d;//净现金流量
            double NPV = 0.0d;//净现值
            double NPVs = 0.0d;//净现值/每亩
            int indexCul = 0;
            n = Convert.ToInt32(dt2.Rows[1][3]);

            resultData.Columns.Add("标识码");
            resultData.Columns.Add("总产值V");
            resultData.Columns.Add("总现金成本F");
            resultData.Columns.Add("净现金流量NCF");
            resultData.Columns.Add("NPV");
            for (int i = 0; i < n; i++)
            {
                resultData.Columns.Add("NPV" + i + 1);
            }
            resultData.Columns.Add("每亩总产值V'");
            resultData.Columns.Add("每亩总现金成本F'");
            resultData.Columns.Add("每亩净现金流量NCF'");
            resultData.Columns.Add("NPV'");
            for (int i = 0; i < n; i++)
            {
                resultData.Columns.Add("NPV'" + i + 1);
            }


            foreach (var item in selectRows1)
            {
                indexCul = 0;
                int row = item.Key;
                DataRow dataRow = resultData.NewRow();
                getIn(item.Value);
                dataRow[indexCul++] = item.Value;
                V = getV(row);
                dataRow[indexCul++] = V.ToString(digit);
                F = getF(row);
                dataRow[indexCul++] = F.ToString(digit);
                NCF = getNCF(V, F);
                dataRow[indexCul++] = NCF.ToString(digit);
                NPV = getNPV(NCF);
                dataRow[indexCul++] = NPV.ToString(digit);
                for (int j = 0; j < n; j++)
                {
                    dataRow[indexCul++] = NPVj[j].ToString(digit);
                }
                Vs = getVs(V, row);
                dataRow[indexCul++] = Vs.ToString(digit);
                Fs = getFs(F, row);
                dataRow[indexCul++] = Fs.ToString(digit);
                NCFs = getNCFs(NCF,row);
                dataRow[indexCul++] = NCFs.ToString(digit);
                NPVs = getNPVs(NPV, row);
                dataRow[indexCul++] = NPVs.ToString(digit);
                this.getNPVsj(row);
                for (int i = 0; i < n; i++)
                {
                    dataRow[indexCul++] = NPVsj[i].ToString(digit);
                }
                resultData.Rows.Add(dataRow);
                NPVj.Clear();
                NPVsj.Clear();
            }
        }
        
        private DataRow setColumns()
        {
            DataRow dataRow=resultData.NewRow();
            int index = 0;
            dataRow[index++]="标识码";
            dataRow[index++] = "总产值V";
            dataRow[index++] = "总现金成本F";
            dataRow[index++] = "净现金流量NCF";
            dataRow[index++] = "NPV";
            for (int i = 0; i < n; i++)
            {
                dataRow[index++] = "NPV" + i + 1;
            }
            dataRow[index++]="每亩总产值V'";
            dataRow[index++]="每亩总现金成本F'";
            dataRow[index++]="每亩净现金流量NCF'";
            dataRow[index++]="NPV'";
            for (int i = 0; i < n; i++)
            {
                dataRow[index++]="NPV'" + i + 1;
            }
            return dataRow;
        }
        //读取输入表
        private void getIn(String value)
        {
            for(int indexRow = 1; indexRow< dt2.Rows.Count;indexRow++)
            {
                String temp = Convert.ToString(dt2.Rows[indexRow][0]);
                if (String.Equals(temp,value))
                {
                    C = Convert.ToDouble(dt2.Rows[indexRow][1])+ Convert.ToDouble(dt2.Rows[indexRow][2]);
                    n = Convert.ToInt32(dt2.Rows[indexRow][3]);
                    r = Convert.ToDouble(dt2.Rows[indexRow][4]);
                }
            }
        }

        //x1——x2行，y1——y2列 区域的和
        private double sumXRowYColumn(int x1, int x2, int y1, int y2)
        {
            double sum = 0.0d;
            double temp = 0.0d;
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    if (dt1.Rows[i][j] != null)
                        temp=Convert.ToDouble(dt1.Rows[i][j]);
                    if (temp == -999.0d)
                    {
                        temp = 0;
                    }
                    sum += temp;
                }
            }
            return sum;
        }
        //计算总产值V
        public double getV(int row)
        {
            double a = 0.0d, sum = 0.0d;
            a = sumXRowYColumn(row, row, 67, 68);
            sum += a;
            a = sumXRowYColumn(row, row, 77, 78);
            sum += a;

            return sum;
        }

        //总现金成本F
        public double getF(int row)
        {
            double a = 0.0d, sum = 0.0d;
            a = sumXRowYColumn(row, row, 48, 61);
            sum += a;
            a = sumXRowYColumn(row, row, 66, 66);
            sum += a;
            a = sumXRowYColumn(row, row, 90, 90);
            sum += a;

            return sum;
        }
        //计算 净现金流NCF
        private double getNCF(double V,double F)
        {
            return V - F;
        }

        
        private double getNPV(double NCF)
        {
            double sum = 0.0d,temp=0.0d;
            for(int i=1;i< n+1; i++)
            {
                temp = NCF / Math.Pow((1 + r), i) - C/n;
                NPVj.Add(temp);
                sum +=temp;
            }
            return sum;

        }
        private double getNPVs(double NPV,int row)
        {
            return NPV/getS(row);
        }
        private double getVs(double V,int row)
        {
            return V / getS(row);
        }
        private double getFs(double F, int row)
        {
            return F / getS(row);
        }
        private double getNCFs(double NCF, int row)
        {
            return NCF / getS(row);
        }
        private void getNPVsj(int row)
        {
            double s = getS(row);
            for(int i=0; i < NPVj.Count; i++)
            {
                NPVsj.Add(NPVj[i] / s);
            }
        }

        private double getS(int row)
        {
            return Convert.ToDouble( dt1.Rows[row][4]);
        }

        public DataTable getResult()
        {
            return resultData;
        }

    }

    }
=======
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NPVcalc
    {
        private double C = 0.0d;//初始投资额

        private string digit = "0.00";//小数位
        private int n = 0;//项目年限
        private double r = 0.0d;//银行贴现率
        private List<double> NPVj= new List<double>();//每年NPV
        private List<double> NPVsj = new List<double>();//每年NPV/按亩算
        private Dictionary<int,String> selectRows1;//总表选择行
        private Dictionary<int,String> selectRows2;//输入表选择行
        private DataTable dt1 = null;//总表
        private DataTable dt2 = null;//输入表
        private DataTable resultData = new DataTable(); //结果集
        
        public NPVcalc(DataTable dt1,DataTable dt2, Dictionary<int, String> selectRows1, Dictionary<int, String> selectRows2)
        {
            this.dt1 = dt1;
            this.dt2 = dt2;
            this.selectRows1 = selectRows1;
            this.selectRows2 = selectRows2;
            this.Calc();
        }

        private void Calc()
        {
             double V = 0.0d;//总产值
             double F = 0.0d;//总现金成本
             double NCF = 0.0d;//净现金流量
            double Vs = 0.0d;//总产值
            double Fs = 0.0d;//总现金成本
            double NCFs = 0.0d;//净现金流量
            double NPV = 0.0d;//净现值
            double NPVs = 0.0d;//净现值/每亩
            int indexCul = 0;
            n = Convert.ToInt32(dt2.Rows[1][3]);

            resultData.Columns.Add("标识码");
            resultData.Columns.Add("总产值V");
            resultData.Columns.Add("总现金成本F");
            resultData.Columns.Add("净现金流量NCF");
            resultData.Columns.Add("NPV");
            for (int i = 0; i < n; i++)
            {
                resultData.Columns.Add("NPV" + i + 1);
            }
            resultData.Columns.Add("每亩总产值V'");
            resultData.Columns.Add("每亩总现金成本F'");
            resultData.Columns.Add("每亩净现金流量NCF'");
            resultData.Columns.Add("NPV'");
            for (int i = 0; i < n; i++)
            {
                resultData.Columns.Add("NPV'" + i + 1);
            }


            foreach (var item in selectRows1)
            {
                indexCul = 0;
                int row = item.Key;
                DataRow dataRow = resultData.NewRow();
                getIn(item.Value);
                dataRow[indexCul++] = item.Value;
                V = getV(row);
                dataRow[indexCul++] = V.ToString(digit);
                F = getF(row);
                dataRow[indexCul++] = F.ToString(digit);
                NCF = getNCF(V, F);
                dataRow[indexCul++] = NCF.ToString(digit);
                NPV = getNPV(NCF);
                dataRow[indexCul++] = NPV.ToString(digit);
                for (int j = 0; j < n; j++)
                {
                    dataRow[indexCul++] = NPVj[j].ToString(digit);
                }
                Vs = getVs(V, row);
                dataRow[indexCul++] = Vs.ToString(digit);
                Fs = getFs(F, row);
                dataRow[indexCul++] = Fs.ToString(digit);
                NCFs = getNCFs(NCF,row);
                dataRow[indexCul++] = NCFs.ToString(digit);
                NPVs = getNPVs(NPV, row);
                dataRow[indexCul++] = NPVs.ToString(digit);
                this.getNPVsj(row);
                for (int i = 0; i < n; i++)
                {
                    dataRow[indexCul++] = NPVsj[i].ToString(digit);
                }
                resultData.Rows.Add(dataRow);
                NPVj.Clear();
                NPVsj.Clear();
            }
        }
        
        private DataRow setColumns()
        {
            DataRow dataRow=resultData.NewRow();
            int index = 0;
            dataRow[index++]="标识码";
            dataRow[index++] = "总产值V";
            dataRow[index++] = "总现金成本F";
            dataRow[index++] = "净现金流量NCF";
            dataRow[index++] = "NPV";
            for (int i = 0; i < n; i++)
            {
                dataRow[index++] = "NPV" + i + 1;
            }
            dataRow[index++]="每亩总产值V'";
            dataRow[index++]="每亩总现金成本F'";
            dataRow[index++]="每亩净现金流量NCF'";
            dataRow[index++]="NPV'";
            for (int i = 0; i < n; i++)
            {
                dataRow[index++]="NPV'" + i + 1;
            }
            return dataRow;
        }
        //读取输入表
        private void getIn(String value)
        {
            for(int indexRow = 1; indexRow< dt2.Rows.Count;indexRow++)
            {
                String temp = Convert.ToString(dt2.Rows[indexRow][0]);
                if (String.Equals(temp,value))
                {
                    C = Convert.ToDouble(dt2.Rows[indexRow][1])+ Convert.ToDouble(dt2.Rows[indexRow][2]);
                    n = Convert.ToInt32(dt2.Rows[indexRow][3]);
                    r = Convert.ToDouble(dt2.Rows[indexRow][4]);
                }
            }
        }

        //x1——x2行，y1——y2列 区域的和
        private double sumXRowYColumn(int x1, int x2, int y1, int y2)
        {
            double sum = 0.0d;
            double temp = 0.0d;
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    if (dt1.Rows[i][j] != null)
                        temp=Convert.ToDouble(dt1.Rows[i][j]);
                    if (temp == -999.0d)
                    {
                        temp = 0;
                    }
                    sum += temp;
                }
            }
            return sum;
        }
        //计算总产值V
        public double getV(int row)
        {
            double a = 0.0d, sum = 0.0d;
            a = sumXRowYColumn(row, row, 67, 68);
            sum += a;
            a = sumXRowYColumn(row, row, 77, 78);
            sum += a;

            return sum;
        }

        //总现金成本F
        public double getF(int row)
        {
            double a = 0.0d, sum = 0.0d;
            a = sumXRowYColumn(row, row, 48, 61);
            sum += a;
            a = sumXRowYColumn(row, row, 66, 66);
            sum += a;
            a = sumXRowYColumn(row, row, 90, 90);
            sum += a;

            return sum;
        }
        //计算 净现金流NCF
        private double getNCF(double V,double F)
        {
            return V - F;
        }

        
        private double getNPV(double NCF)
        {
            double sum = 0.0d,temp=0.0d;
            for(int i=1;i< n+1; i++)
            {
                temp = NCF / Math.Pow((1 + r), i) - C/n;
                NPVj.Add(temp);
                sum +=temp;
            }
            return sum;

        }
        private double getNPVs(double NPV,int row)
        {
            return NPV/getS(row);
        }
        private double getVs(double V,int row)
        {
            return V / getS(row);
        }
        private double getFs(double F, int row)
        {
            return F / getS(row);
        }
        private double getNCFs(double NCF, int row)
        {
            return NCF / getS(row);
        }
        private void getNPVsj(int row)
        {
            double s = getS(row);
            for(int i=0; i < NPVj.Count; i++)
            {
                NPVsj.Add(NPVj[i] / s);
            }
        }

        private double getS(int row)
        {
            return Convert.ToDouble( dt1.Rows[row][4]);
        }

        public DataTable getResult()
        {
            return resultData;
        }

    }

    }
>>>>>>> 167f7a405e7de9995d073c43dd99a9fa99a63730
