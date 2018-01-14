using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口调试助手
{
    public partial class AboutForm : Form
    { 
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// “关于”窗体，加载背景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutForm_Paint(object sender, PaintEventArgs e)
        {
            //Image img = Image.FromFile(@"C:\Users\陈俊杰\Desktop\串口调试助手1\school.jpg");
            //Bitmap bitmap = new Bitmap(img);
            //int height = bitmap.Height;
            //int width = bitmap.Width;

            //Bitmap tempb = new Bitmap(bitmap, width / 1.5, height / 1.5); //目标图
            //tempb.Save(@"C:\Users\陈俊杰\Desktop\串口调试助手1\temp.jpg");

            Image shcoolImg = Image.FromFile("school.jpg");

            Graphics g = e.Graphics;
            g.DrawImage(shcoolImg, new Point(0, 0));//point: System.Drawing.Point 结构，它表示所绘制图像的左上角的位置。
            g.Dispose();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
