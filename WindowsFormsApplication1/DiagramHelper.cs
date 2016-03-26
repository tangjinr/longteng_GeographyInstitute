using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using dotnetCHARTING;
using System.Drawing;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class DigramHelper
    {
        #region 属性
        //private string _phaysicalimagepath;//图片存放路径  
        private string _title; //图片标题  
        private string _xtitle;//图片x座标名称
        private string _ytitle;//图片y座标名称  
        private string _seriesname;//图例名称
        private int _picwidth;//图片宽度
        private int _pichight;//图片高度
        private List<ArrayList> _dt;//图片数据源

        /*/// <summary>
        /// 图片存放路径
        /// </summary>
        public string PhaysicalImagePath
        {
            set { _phaysicalimagepath = value; }
            get { return _phaysicalimagepath; }
        }*/
        /// <summary>  
        /// 图片标题  
        /// </summary>  
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>  
        /// 图片标题  
        /// </summary>  
        public string XTitle
        {
            set { _xtitle = value; }
            get { return _xtitle; }
        }
        /// <summary>  
        /// 图片标题  
        /// </summary>  
        public string YTitle
        {
            set { _ytitle = value; }
            get { return _ytitle; }
        }

        /// <summary>  
        /// 图例名称  
        /// </summary>  
        public string SeriesName
        {
            set { _seriesname = value; }
            get { return _seriesname; }
        }
        /// <summary>  
        /// 图片宽度  
        /// </summary>  
        public int PicWidth
        {
            set { _picwidth = value; }
            get { return _picwidth; }
        }
        /// <summary>  
        /// 图片高度  
        /// </summary>  
        public int PicHight
        {
            set { _pichight = value; }
            get { return _pichight; }
        }
        /// <summary>  
        /// 图片数据源  
        /// </summary>  
        public List<ArrayList> DataSource
        {
            set { _dt = value; }
            get { return _dt; }
        }
        #endregion

        #region 构造函数
        public DigramHelper()
        {
            //  
            // TODO: 在此处添加构造函数逻辑  
            //  
        }
        public DigramHelper(string PhaysicalImagePath, string Title, string XTitle, string YTitle, string SeriesName)
        {
            //_phaysicalimagepath = PhaysicalImagePath;  
            _title = Title;
            _xtitle = XTitle;
            _ytitle = YTitle;
            _seriesname = SeriesName;
        }
        #endregion

        #region 输出柱形图
        /// <summary>
        /// 柱形图
        /// </summary>
        public void CreateColumn(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.XAxis.Label.Text = this._xtitle;
            chart.YAxis.Label.Text = this._ytitle;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            //chart.TempDirectory = this._phaysicalimagepath;//图片存放路径
            chart.Type = dotnetCHARTING.WinForms.ChartType.Combo;
            //chart.Series.Type = dotnetCHARTING.WinForms.SeriesType.Cylinder;
            //chart.Series.Name = this._seriesname;
            //chart.Series.Data = this._dt;
            chart.SeriesCollection.Add(getSimpleData(1));
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.Series.DefaultElement.ShowValue = true;
            chart.ShadingEffect = true;
            //chart.Use3D = false;
        }
        #endregion

        #region 输出折线图
        /// <summary>  
        /// 曲线图  
        /// </summary>  
        /// <returns></returns>  
        public void CreateLine(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.XAxis.Label.Text = this._xtitle;
            chart.YAxis.Label.Text = this._ytitle;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            //chart.TempDirectory = this._phaysicalimagepath;//图片存放路径
            chart.Type = dotnetCHARTING.WinForms.ChartType.Combo;
            //chart.Series.Type = dotnetCHARTING.WinForms.SeriesType.Spline;
            //chart.Series.Name = this._seriesname;
            //chart.Series.Data = this._dt;
            chart.SeriesCollection.Add(getSimpleData(2));
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.Series.DefaultElement.ShowValue = true;
            chart.ShadingEffect = true;
            //chart.Use3D = false;  
        }
        #endregion

        #region 输出饼图
        /// <summary>  
        /// 饼图(合并)
        /// </summary>
        public void CreatePie1(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            //chart.TempDirectory = this._phaysicalimagepath;//图片存放路径            
            chart.Type = dotnetCHARTING.WinForms.ChartType.Pie;
            //chart.Series.Type = dotnetCHARTING.WinForms.SeriesType.Cylinder;
            //chart.Series.Name = this._seriesname;
            chart.SeriesCollection.Add(getComplexData());
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.Series.DefaultElement.ShowValue = true;
            chart.ShadingEffect = true;

            chart.DefaultSeries.DefaultElement.Transparency = 20;
            chart.DefaultSeries.DefaultElement.ExplodeSlice = false;
            chart.PieLabelMode = dotnetCHARTING.WinForms.PieLabelMode.Inside;
            //chart.Use3D = false;
        }
        #endregion

        #region 输出饼图
        /// <summary>  
        /// 饼图(分散)
        /// </summary>
        public void CreatePie2(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            //chart.TempDirectory = this._phaysicalimagepath;//图片存放路径            
            chart.Type = dotnetCHARTING.WinForms.ChartType.Pie;
            //chart.Series.Type = dotnetCHARTING.WinForms.SeriesType.Cylinder;
            //chart.Series.Name = this._seriesname;
            chart.SeriesCollection.Add(getComplexData());
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.Series.DefaultElement.ShowValue = true;
            chart.ShadingEffect = true;

            chart.DefaultSeries.DefaultElement.Transparency = 20;
            chart.DefaultSeries.DefaultElement.ExplodeSlice = true;
            chart.PieLabelMode = dotnetCHARTING.WinForms.PieLabelMode.Outside;
            //chart.Use3D = false;
        }
        #endregion

        #region 输出雷达图
        /// <summary>  
        /// 雷达图  
        /// </summary>  
        /// <returns></returns>  
        public void CreateRadar(dotnetCHARTING.WinForms.Chart chart)
        {

        }
        #endregion


        //柱状图折线图
        dotnetCHARTING.WinForms.SeriesCollection getSimpleData(int num)
        {
            ArrayList x = this._dt[0];//x值
            ArrayList y = this._dt[1];//y值
            int len = x.Count;
            dotnetCHARTING.WinForms.SeriesCollection SC = new dotnetCHARTING.WinForms.SeriesCollection();
            dotnetCHARTING.WinForms.Series s = new dotnetCHARTING.WinForms.Series();
            s.Name = this._seriesname;
            switch (num)
            {
                case 1: s.Type = dotnetCHARTING.WinForms.SeriesType.Cylinder; break;
                case 2: s.Type = dotnetCHARTING.WinForms.SeriesType.Line; break;
            }
            for (int i = 0; i < len; i++)
            {
                dotnetCHARTING.WinForms.Element e = new dotnetCHARTING.WinForms.Element();
                e.Name = x[i].ToString();
                e.YValue = Convert.ToDouble(y[i]);
                s.Elements.Add(e);
            }
            SC.Add(s);
            return SC;
        }

        //饼状图雷达图
        dotnetCHARTING.WinForms.SeriesCollection getComplexData()
        {
            ArrayList x = this._dt[0];//x值
            ArrayList y = this._dt[1];//y值
            int len = x.Count;
            dotnetCHARTING.WinForms.SeriesCollection SC = new dotnetCHARTING.WinForms.SeriesCollection();
            for (int i = 0; i < len; i++)
            {
                dotnetCHARTING.WinForms.Series s = new dotnetCHARTING.WinForms.Series();
                s.Name = x[i].ToString();
                dotnetCHARTING.WinForms.Element e = new dotnetCHARTING.WinForms.Element();
                e.Name = "Element" + i;
                e.YValue = Convert.ToDouble(y[i]);
                s.Elements.Add(e);
                SC.Add(s);
            }
            return SC;
        }
    }
}