using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;  //这个命名空间包含了注册表相关的类，registry类、registryKey


namespace 串口调试助手
{
    public partial class LoginForm : Form
    {
        private RSA ras;
        private Regedit registry;
        private Regedit adminRegistry;
        private Regedit userRegistry;

        private Access access;   //数据库
        private string accessFileRoad = @"..\..\..\Jun.mdb";
        private Md5 md5 = new Md5();  //MD5加密

        private  string recaptcha = null;  //验证码

        public static string userName;   //userName:全局变量，用于用户名的判断
        public static string userType;  //userType:全局变量，用于用户类型的判断

        public LoginForm()
        {
            InitializeComponent();
            //primaryKey = Registry.CurrentUser;   //注册在当前用户里，如果使用管理员运行该软件才能注册在LocalMachine里。
            //softWare = primaryKey.CreateSubKey(@"SOFTWARE\JUN-SerialPort");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            userCombobox.Items.Add("管理员");
            userCombobox.Items.Add("一般用户");
            userCombobox.Text = userCombobox.Items[0].ToString();
            registry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort");  //定义一个注册表
            adminRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\admin");  //定义管理员注册表
            userRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\user");   //定义用户注册表
            ras = new RSA(); //定义一个RAS用于加解密
            recaptcha = reCaptcha();
            recaptchaTextBox.Text = recaptcha;

            access = new Access(accessFileRoad); //数据库加载

        }

        /// <summary>
        /// ”登录“按钮事件，基于注册表和数据库的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextbox.Text.Trim();
            userType = userCombobox.Text;
            string captchaText = recaptchaTextBox.Text.Trim().ToUpper();  //输入的字母全部大写化
            string accessPassword = null;  //数据库的 MD5 加密后的密码
            string password = null;    //注册表 RSA 加密后的密码

            if (userName.Length >0)
            {
                if (userType == "管理员")
                {
                    accessPassword = access.searchUser("管理员", userName);  //返回一个password
                    if (adminRegistry.isRegistryValueNameExist(userName, ref password) && accessPassword != null)  //先判断该管理员是否在数据库和注册表内
                    {
                        if (string.Equals(passwordTextBox.Text.Trim(), password) && string.Equals(md5.MD5Encryption(passwordTextBox.Text.Trim()), accessPassword))  //密码匹配正确,先将输入框密码MD5加密，再和数据库的加密后的密码比较
                        {
                            if (captchaText == recaptcha)  //验证码匹配正确
                            {
                                //Thread t = new Thread(new ThreadStart(adminMainFormStart));
                                //t.Start();
                                //this.Close();
                                this.DialogResult = DialogResult.Yes;  //返回ok ，进入主窗体
                            }
                            else
                                MessageBox.Show("验证码输入错误！");

                        }
                        else
                            MessageBox.Show("密码错误！");
                    }
                    else
                        MessageBox.Show("该管理员不存在！");
                }
                else  //一般用户
                {
                    accessPassword = access.searchUser("一般用户", userName);  //返回一个password
                    if (userRegistry.isRegistryValueNameExist(userName, ref password) && accessPassword != null)  //再判断判断用户是否在注册表和数据库内
                    {

                        if (string.Equals(passwordTextBox.Text, password) && string.Equals(md5.MD5Encryption(passwordTextBox.Text.Trim()), accessPassword))   //密码匹配正确
                        {
                            if (captchaText == recaptcha) //验证码匹配正确
                            {
                                //Thread t = new Thread(new ThreadStart(adminMainFormStart));
                                //t.Start();
                                //this.Close();
                                this.DialogResult = DialogResult.Yes;  //返回ok ，进入主窗体
                            }
                            else
                                MessageBox.Show("验证码输入错误！");
                        }

                        else
                            MessageBox.Show("密码错误！");
                    }

                    else
                        MessageBox.Show("该用户不存在！");
                }
            }

            else
            {
                MessageBox.Show("用户名不能为空！");
            }
        }

        //public void adminMainFormStart()
        //{
        //    MainForm mainForm = new MainForm();
        //    Application.Run(mainForm);
        //}

        private void userNameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }


        /// <summary>
        /// "注册"按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            DialogResult result = registerForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                userCombobox.Items.Clear();   //先将Combobox清空
                LoginForm_Load(sender, e);  //重新加载一次，就像是重新加载了数据库
            }

        }


        /// <summary>
        /// 点击"更换验证码"事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recaptchaPictureBox_Click(object sender, EventArgs e)
        {
           recaptcha = reCaptcha();

        }


        /// <summary>
        /// 验证码生成函数
        /// </summary>
        private string reCaptcha()
        {
            Random rd = new Random();
            string str = null;

            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F',
                'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            

            for (int i = 0; i < 5; i++)
            {
                int num = rd.Next(0, Pattern.Length);
                str += Pattern[num];
            }
            Bitmap bmp = new Bitmap(150, 40);
            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < 5; i++)
            {
                Point p = new Point(i * 25, 0);
                string font = "微软雅黑";
                Color[] colors = { Color.Red, Color.Black, Color.Blue, Color.Gray, Color.Green };
                g.DrawString(str[i].ToString(), new Font(font, 20, FontStyle.Bold), new SolidBrush(colors[rd.Next(0, 5)]), p);
            }

            for (int i = 0; i < 20; i++)
            {
                Point p1 = new Point(rd.Next(0, bmp.Width), rd.Next(0, bmp.Height));
                Point p2 = new Point(rd.Next(0, bmp.Width), rd.Next(0, bmp.Height));
                g.DrawLine(new Pen(Brushes.Green), p1, p2);
            }

            for (int i = 0; i < 500; i++)
            {
                Point p = new Point(rd.Next(0, bmp.Width), rd.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }

            recaptchaPictureBox.Image = bmp;
       
            return str; //输出验证码
        }

       
    }

}
