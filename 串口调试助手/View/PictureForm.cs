using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口调试助手
{
    public partial class PictureForm : Form
    { 
        private static string[][] pictureConfig = null;


        public PictureForm()
        {
            InitializeComponent();
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {
          
            List<string> listName = null;

            if (LoginForm.userType == "管理员")  //如果是管理员，即可以查询所有的表
                listName = LoginForm.access.searchPictureName("温度折线图");
            else
                listName = LoginForm.access.searchPictureName("温度折线图",LoginForm.userType, LoginForm.userName);

            pictureConfig = new string[listName.Count][];
            for (int i = 0; i < listName.Count; i++)
            {
                pictureConfig[i] = listName[i].Split('~');
            }
            
            foreach (string[] name in pictureConfig)
            {
                picturComboBox.Items.Add("   " +name[0] + "—" + name[1] + "—" + name[2]);
            }

            if (pictureConfig.Length > 0)
            {
                picturComboBox.Text = picturComboBox.Items[0].ToString();
            }
        }

        /// <summary>
        /// 选择数据库图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureButton_Click(object sender, EventArgs e)
        {
            if (pictureConfig != null)
            {
                this.Refresh();

                string s = picturComboBox.Text;
                s = s.Trim();

                string[] config = s.Split('—');
                
                byte[] pictureByte = LoginForm.access.getPicture("温度折线图", config[0],config[1],config[2]);

                MemoryStream memstream = new MemoryStream(pictureByte);

                Image image = Image.FromStream(memstream);

                pictureBox.Image = image;

                //image.Save(@"C:\Users\Public\Documents\wendu.jpg");

                // Console.WriteLine("输出图片信息：" + pictureByte);
            }

            else
                MessageBox.Show("没有该图片");

        }

       
    }
}
