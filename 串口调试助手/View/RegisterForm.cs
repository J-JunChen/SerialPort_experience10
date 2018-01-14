using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;  //这个命名空间包含了注册表相关的类，registry类、registryKey
using System.Security;
using System.Security.Cryptography;

namespace 串口调试助手
{
    public partial class RegisterForm : Form
    {
        private RSA ras;
        private Regedit registry;
        private Regedit adminRegistry;
        private Regedit userRegistry;

        private Md5 md5 = new Md5();

        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实现“注册表”的注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterForm_Load(object sender, EventArgs e) 
        {
            // primaryKey = Registry.CurrentUser;   //注册在当前用户里，如果使用管理员运行该软件才能注册在LocalMachine里。
            //softWare= primaryKey.CreateSubKey(@"SOFTWARE\JUN-SerialPort");

            userCombobox.Items.Add("管理员");
            userCombobox.Items.Add("一般用户");
            userCombobox.Text = userCombobox.Items[0].ToString();

            registry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort");  //定义一个注册表  
            adminRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\admin");  //定义管理员注册表
            userRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\user");   //定义用户注册表         
            ras = new RSA();  //定义一个RAS对象，用于加密和解密

            LoginForm.access.creatDataDB();  //创建数据库
            LoginForm.access.createUserTable("管理员");   //在数据库创建管理员和一般用户
            LoginForm.access.createUserTable("一般用户");
        }

        /// <summary>
        /// "确定"按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text.Trim();  //去除字符串前后面的空格
            string password = passwordTextBox.Text.Trim();

            //if (String.IsNullOrEmpty(userNameTextBox.Text))
            if (userName != String.Empty )
            {
                if (password != String.Empty)
                {
                 
                    if (String.Equals(password, passwordTextBox2.Text.Trim())) //两次密码相同
                    {
                        if (userCombobox.Text == "管理员")
                        {
                            //数据库和注册表同时操作
                            if (adminRegistry.isRegistryValueNameExist(userName) && LoginForm.access.searchUser("管理员",userName)!= null)
                            {
                                MessageBox.Show("该管理员已存在！");
                            }
                            else
                            {
                                //下面要对密码进行加密再储存在注册表里面，还有数据库
                                adminRegistry.SetValue(userName, ras.Encryption(password), RegistryValueKind.String);
                                LoginForm.access.insertUser("管理员",userName,md5.MD5Encryption(password));

                                MessageBox.Show("恭喜管理员 “" + userName + "” 注册成功");
                                this.DialogResult = DialogResult.Yes;
                                //this.Close();
                            }
                        }
                        else
                        {
                            if (userRegistry.isRegistryValueNameExist(userName) && LoginForm.access.searchUser("一般用户", userName) != null)
                            {
                                MessageBox.Show("该用户已存在！");
                            }
                            else
                            {
                                //下面要对密码进行加密再储存在注册表里面
                                userRegistry.SetValue(userName, ras.Encryption(password), RegistryValueKind.String);
                                LoginForm.access.insertUser("一般用户", userName, md5.MD5Encryption(password));

                                MessageBox.Show("恭喜用户 “" + userName + "” 注册成功");
                                this.DialogResult = DialogResult.Yes;
                                //this.Close();
                            }
                        }
                    }
                    else
                        MessageBox.Show("两次输入密码不一致");
                }
                else
                    MessageBox.Show("输入密码不能为空");
            }
            else
                MessageBox.Show("用户名不能为空");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
