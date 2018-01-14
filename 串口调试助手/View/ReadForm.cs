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

namespace 串口调试助手
{
    public partial class ReadForm : Form
    {

        private ContentResize groupBoxResize = new ContentResize();

        public ReadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readForm_Load(object sender, EventArgs e)
        {
            groupBoxResize.GroupBoxReSize(groupBox2, groupBox3);
        }

        /// <summary>
        /// 打开文件选择导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "文本文件(*.txt) | *.txt";  //文本文件(*.txt) | *.txt | 所有文件(*.*) | *.*
            //file.ShowDialog();
            //string name = file.FileName;   //返回路径名和文件名
            //System.Diagnostics.Debug.Write(name);

            DialogResult result = file.ShowDialog();
            if (result == DialogResult.OK)
                ReadTextFile(@file.FileName);

        }

        /// <summary>
        /// 读取txt文件的数据
        /// </summary>
        /// <param name="fileName"></param>
        private void ReadTextFile(string fileName)
        {
            MainForm.fileWriter.Close();
            MainForm.file.Close();

            readTextBox.Text = null;
            string[] lines = File.ReadAllLines(fileName,System.Text.Encoding.Default);
            foreach(string line in lines)
            {
                readTextBox.AppendText(line+Environment.NewLine);
            }

            MainForm.file = new FileStream(MainForm.temperatureFile + '\\' + MainForm.fileName, FileMode.Append);

            MainForm.fileWriter = new StreamWriter(MainForm.file, System.Text.Encoding.Default);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox3_Resize(object sender, EventArgs e)
        {
            groupBoxResize.GroupBoxReSize(groupBox2, groupBox3);
        }
    }
}
