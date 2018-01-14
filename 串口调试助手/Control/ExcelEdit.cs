using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;

namespace 串口调试助手
{
    class ExcelEdit
    {
        public string fileName;
        private Excel.Application app;
        private Excel.Workbooks wbooks;
        private Excel.Workbook wbook;
        private Excel._Worksheet wsheet;

        private Excel.Range range;

        private int rowCount;
        private int colCount;

        public ExcelEdit( string fileRoad)
        {
            app = new Excel.Application();
          
            app.Visible = false;
          
            wbook = app.Workbooks.Add(1);
            wsheet = (Excel.Worksheet)wbook.Sheets[1];
            wsheet.Cells.Select();
            wsheet.Cells.Columns.AutoFit();
            

            wbook.SaveAs(fileRoad, Excel.XlSaveAsAccessMode.xlNoChange);

            // wbook = app.Workbooks.Open(fileRoad);

            // wbook = app.Workbooks.Open(fileRoad, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);

            range = wsheet.UsedRange;
            rowCount = range.Rows.Count;
            colCount = range.Columns.Count;


        }


        /// <summary>
        /// 查询excel表格数据
        /// </summary>
        //public void SearchExcel()
       // {
            //for (int i = 1; i <= rowCount; i++)
            //{
            //    for (int j = 1; j <= colCount; j++)
            //    {
            //        if (j == 1)
            //            Console.Write("\r\n");
            //        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
            //        {
            //            Console.Write(range.Cells[i, j].Value2.ToString() + '\t');
            //        }
            //    }
            //}

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

       // }


        /// <summary>
        /// 添加excel表格数据
        /// </summary>
        public void AddData(string[] data)
        {
            int count = data.Length;
            // rowCount += 1;

            for (int i = 1; i <= count; i++)
            {
                wsheet.Cells[rowCount, i] = data[i - 1];
            }          
            wbook.Save();
            rowCount += 1;
            colCount = count;
        }


        /// <summary>
        /// 在某一列加上按照列来加上数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="colNum"></param>
        public void AddData2(string[] data)
        {
            colCount++;

            int count = data.Length;

            for (int i = 1; i <= count; i++)
            {
                wsheet.Cells[ i,colCount] = data[i - 1];
            }
            wbook.Save();
        }

        /// <summary>
        /// 单元表格的格式
        /// </summary>
        public void Format()
        {

            int count = colCount;
            //range.ColumnWidth = 100;

            Excel.Range range1 = (Range)wsheet.get_Range("A1","E1");    
            range1.ColumnWidth = 20;

            //Excel.Range range2 = (Range)wsheet.get_Range("A1","E16");
            Excel.Range range2 = (Range)app.Range[wsheet.Cells[1, 1], wsheet.Cells[rowCount, colCount]];
            range2.ColumnWidth = 20;
            range2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;  //垂直居中
            range2.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;   //水平居中
        }


        public void Creat()
        {
            app = new Excel.Application();
            wbooks = app.Workbooks;
            wbook = wbooks.Add(true);
        }

        /// <summary>
        /// 打开一个Excel文件
        /// </summary>
        /// <param name="FileName">excel文件名，包括文件路径</param>
        public void Open(string FileName)
        {
            object missing = System.Reflection.Missing.Value;
            app = new Application();
            wbooks = app.Workbooks;
            wbook = wbooks.Add(FileName);
            wbook = wbooks.Open(FileName, missing, true, missing, missing, missing, missing, missing, missing, true, missing, missing, missing, missing, missing);
            fileName = FileName;
        }

        /// <summary>
        /// 获取一个工作表
        /// </summary>
        /// <param name="SheetName">工作表名称</param>
        /// <returns></returns>
        public Worksheet GetSheet(string SheetName)
        {
            Worksheet s = (Worksheet)wbook.Worksheets[SheetName];
            return s;
        }

        /// <summary>
        /// 添加一个工作表
        /// </summary>
        /// <param name="SheetName">工作表名称</param>
        /// <returns></returns>
        public Worksheet AddSheet(string SheetName)
        {
            Worksheet s = (Worksheet)wbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            s.Name = SheetName;
            return s;
        }

        /// <summary>
        /// 设置单元格的值
        /// </summary>
        /// <param name="ws">工作表</param>
        /// <param name="x">行标</param>
        /// <param name="y">列标</param>
        /// <param name="value">数据</param>
        public void SetCellValue(Worksheet ws, int x, int y, object value)
        {
            ws.Cells[x, y] = value;
        }

        /// <summary>
        /// 设置单元格的值
        /// </summary>
        /// <param name="ws">工作表名称</param>
        /// <param name="x">行标</param>
        /// <param name="y">列标</param>
        /// <param name="value">数据</param>
        public void SetCellValue(string ws, int x, int y, object value)
        {
            GetSheet(ws).Cells[x, y] = value;
        }


        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="ws">工作表名称</param>
        /// <param name="startX">起始行标</param>
        /// <param name="startY">起始列标</param>
        public void InsertTable(System.Data.DataTable dt, Worksheet ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    ws.Cells[startX + i, j + startY] = dt.Rows[i][j];
                }
            }
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns></returns>
        //public bool Save()
        //{
        //    if (fileName == "")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            wbook.Save();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("error from Save: "+ex);
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// 文档另存为
        /// </summary>
        /// <param name="FileName">文件名（包含路径）</param>
        /// <returns></returns>
        public bool SaveAs(object FileName)
        {
            try
            {
                wbook.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from SaveAs: " + ex);
                return false;
            }
        }

        /// <summary>
        /// 关闭一个Excel对象，销毁对象
        /// </summary>
        public void Close()
        {
            //wbook.Close(Type.Missing, Type.Missing, Type.Missing);
            wbook.Close(true);
            app.Quit();
            wbook = null;
       
            app = null;
            GC.Collect();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ExcelEdit()
        {
            GC.Collect();
            Console.WriteLine("ExcelEdit 析构函数被调用！");
        }
    }

}
