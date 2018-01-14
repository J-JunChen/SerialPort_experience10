using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace 串口调试助手
{
    public partial class searchDataBaseForm : Form
    {
        private Access access;
        private string accessFileRoad = @"..\..\..\Jun.mdb";

        public static string fileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + ".txt";

        //public static string roadName = @"C:\Users\陈俊杰\Desktop\串口调试助手1";  //路径名

        public static string temperatureFile = @"..\..\..\温度记录文件";  //路径名

        private ContentResize groupBoxResize = new ContentResize();

        private ExcelEdit excelEdit;

        public searchDataBaseForm()
        {
            InitializeComponent();
        }

        private void searchDataBase_Load(object sender, EventArgs e)
        {
            groupBoxResize.GroupBoxReSize(groupBox3, groupBox1);
            groupBoxResize.GroupBoxReSize(groupBox4, groupBox1);
            groupBoxResize.GroupBoxReSize(groupBox5, groupBox1);

            dataGridView.Columns.Add("id", "id");
            dataGridView.Columns.Add("type", "用户类型");
            dataGridView.Columns.Add("user", "用户名");
            dataGridView.Columns.Add("time", "时间");
            dataGridView.Columns.Add("temperature", "温度");
            dataGridView.Columns.Add("place", "采样地点");
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  //单元列内容居中显示
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            access = new Access(accessFileRoad);
            //    dateTimePickerFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            //    dateTimePickerFrom.Value = DateTime.ParseExact("00:01","HH;mm",null);

            List<string> ListTable = access.searchTable("温度表");
            string[][] temperature = new string[ListTable.Count][];
            for (int i = 0; i < ListTable.Count; i++)
            {
                temperature[i] = ListTable[i].Split('~');
                Console.WriteLine(ListTable[i]);
            }

            int num = 0;
            double[] temperatureValue = new double[ListTable.Count];

            foreach (string[] rowTemperature in temperature) //遍历二维数组
            {
                DataGridViewRow row = new DataGridViewRow();
                int index = dataGridView.Rows.Add(row);


                dataGridView.Rows[index].Cells[0].Value = rowTemperature[0];
                dataGridView.Rows[index].Cells[1].Value = rowTemperature[1];
                dataGridView.Rows[index].Cells[2].Value = rowTemperature[2];
                dataGridView.Rows[index].Cells[3].Value = rowTemperature[3];
                dataGridView.Rows[index].Cells[4].Value = rowTemperature[4];
                dataGridView.Rows[index].Cells[5].Value = rowTemperature[5];

                temperatureValue[num] = Convert.ToDouble(rowTemperature[4].Replace("℃", ""));
                num++;

            }

            wholeLines.Text = ListTable.Count.ToString();

            if (ListTable.Count > 0)
            {
                maxValueTextbox.Text = temperatureValue.Max() + "℃";
                minValuetextBox.Text = temperatureValue.Min() + "℃";

                double average = temperatureValue.Average();   //求平均值          
                double standard = 0;

                for (int i = 0; i < ListTable.Count; i++)
                {
                    standard += Math.Pow(temperatureValue[i] - average, 2);
                }

                averageTextBox.Text = average.ToString("f5") + "℃";
                standardTextBox.Text = Math.Sqrt(standard / ListTable.Count).ToString("f5");  //格式化，只有五个小数
            }

        }


        /// <summary>
        /// "更新"按钮操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            maxValueTextbox.Text = null;
            minValuetextBox.Text = null;
            averageTextBox.Text = null;
            standardTextBox.Text = null;
            wholeLines.Text = null;


            DateTime timeFrom = new DateTime();
            DateTime timeTo = new DateTime();
            string placeName = placeTextBox.Text.Trim();  //获取地址名

            timeFrom = dateTimePickerFrom.Value;
            timeTo = dateTimePickerTo.Value;

            Console.WriteLine("From time : " + timeFrom.ToString());
            Console.WriteLine("To time : " + timeTo.ToString());



            if (DateTime.Compare(timeFrom, timeTo) > 0)
                MessageBox.Show("时间段格式不符合实际！");
            else
            {
                // DateTime d = Convert.ToDateTime("2017/12/4 13:52:47");
                List<string> ListTemperature = access.searchTemperature("温度表", placeName, timeFrom, timeTo);

                string[][] temperature = new string[ListTemperature.Count][];
                for (int i = 0; i < ListTemperature.Count; i++)
                {
                    temperature[i] = ListTemperature[i].Split('~');
                    Console.WriteLine(ListTemperature[i]);
                }

                int num = 0;
                double[] temperatureValue = new double[ListTemperature.Count];

                foreach (string[] rowTemperature in temperature) //遍历二维数组
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int index = dataGridView.Rows.Add(row);


                    dataGridView.Rows[index].Cells[0].Value = rowTemperature[0];
                    dataGridView.Rows[index].Cells[1].Value = rowTemperature[1];
                    dataGridView.Rows[index].Cells[2].Value = rowTemperature[2];
                    dataGridView.Rows[index].Cells[3].Value = rowTemperature[3];
                    dataGridView.Rows[index].Cells[4].Value = rowTemperature[4];
                    dataGridView.Rows[index].Cells[5].Value = rowTemperature[5];

                    temperatureValue[num] = Convert.ToDouble(rowTemperature[4].Replace("℃", ""));
                    num++;

                }

                wholeLines.Text = ListTemperature.Count.ToString();

                if (ListTemperature.Count > 0)
                {
                    maxValueTextbox.Text = temperatureValue.Max() + "℃";
                    minValuetextBox.Text = temperatureValue.Min() + "℃";

                    double average = temperatureValue.Average();   //求平均值          
                    double standard = 0;

                    for (int i = 0; i < ListTemperature.Count; i++)
                    {
                        standard += Math.Pow(temperatureValue[i] - average, 2);
                    }

                    averageTextBox.Text = average.ToString("f5") + "℃";
                    standardTextBox.Text = Math.Sqrt(standard / ListTemperature.Count).ToString("f5");  //格式化，只有五个小数
                }

            }

        }

        /// <summary>
        /// "保存excel文件"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            string excelRoad = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xls";
            // bitmap.Save(temperatureFile + '\\' + excelRoad);

            SaveFileDialog excelFile = new SaveFileDialog();
            excelFile.Filter = "Excel files (*.xls)|* .xls";
            excelFile.FilterIndex = 0;
            excelFile.RestoreDirectory = true;
            excelFile.CreatePrompt = true;
            excelFile.Title = "保存为Excel文件";

            if (excelFile.ShowDialog() == DialogResult.OK)
            {

                #region excel的文件流操作
                //Stream excelStream;
                //excelStream = excelFile.OpenFile();  //输出文件

                //StreamWriter writer = new StreamWriter(excelStream, Encoding.GetEncoding(0));
                //string columnTitle = "";


                //    try
                //    {
                //        //写入列标题
                //        for(int i=0;i< dataGridView.ColumnCount;i++ )
                //        {
                //            if (i > 0)
                //                columnTitle += '\t';
                //            columnTitle += dataGridView.Columns[i].HeaderText;
                //        }

                //        writer.WriteLine(columnTitle);


                //        //写入行内容
                //        for (int i = 0; i < dataGridView.Rows.Count; i++)
                //        {
                //            string content = null;
                //            for (int j = 0; j < dataGridView.Columns.Count; j++)
                //            {
                //                if (j > 0)
                //                {
                //                    content += '\t';
                //                }

                //                content += dataGridView.Rows[i].Cells[j].Value.ToString();
                //            }
                //            writer.WriteLine(content);
                //        }

                //        writer.Close();
                //        excelStream.Close();
                //    }
                //    catch(Exception ex)
                //    {
                //        Console.WriteLine("error from 保存excel："+ex);
                //    }
                //    finally
                //    {
                //        writer.Close();
                //        excelStream.Close();
                //    }
                #endregion


                #region excel的workBook和Worksheet操作

                try
                {
                    string fileRoad = excelFile.FileName.ToString();  //获取文件路径
                    excelEdit = new ExcelEdit(fileRoad);

                    string[] header = new string[dataGridView.ColumnCount];
                    //写入列标题
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {

                        header[i] = dataGridView.Columns[i].HeaderText;
                    }

                    excelEdit.AddData(header);


                    int row = dataGridView.Rows.Count - 1;  // 一般会计算多一条空白行
                    int col = dataGridView.Columns.Count;

                    //写入行内容
                    for (int i = 0; i < row; i++)
                    {
                        string[] content = new string[dataGridView.ColumnCount];
                        for (int j = 0; j < col; j++)
                        {
                            content[j] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        excelEdit.AddData(content);

                    }

                    string[][] str = new string[5][];
                    str[0] = new string[] { wholeLabel.Text, wholeLines.Text };
                    str[1] = new string[] { maxLabel.Text, maxValueTextbox.Text };
                    str[2] = new string[] { minLabel.Text, minValuetextBox.Text };
                    str[3] = new string[] { averageLabel.Text, averageTextBox.Text };
                    str[4] = new string[] { standardLabel.Text, standardTextBox.Text };

                    int q = 1;
                    foreach (string[] s in str)
                    {
                        excelEdit.AddData2(s);
                    }


                    excelEdit.Format();
                    excelEdit.Close();
                    MessageBox.Show("保存文件成功！");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error from Excel的Workbook 和 workSheet 操作 " + ex);
                }
                //finally
                //{
                //    GC.Collect();
                //    this.Close();
                //}

                #endregion


            }

        }




        /// <summary>
        /// 主要是父GroupBox，调整边框大小，主要是三个子groupBox居中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_Resize(object sender, EventArgs e)
        {
            groupBoxResize.GroupBoxReSize(groupBox3, groupBox1);
            groupBoxResize.GroupBoxReSize(groupBox4, groupBox1);
            groupBoxResize.GroupBoxReSize(groupBox5, groupBox1);
        }


        /// <summary>
        /// 下面三个都是groupbox的重绘，目的是将去掉groupBox的边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
    }
}
