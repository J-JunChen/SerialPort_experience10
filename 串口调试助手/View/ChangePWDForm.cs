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
    public partial class ChangePWDForm : Form
    {
        private RSA ras;
        private Regedit registry;
        private Regedit adminRegistry;
        private Regedit userRegistry;
        private Access access;
        private string accessFileRoad = @"..\..\..\Jun.mdb";
        private Md5 md5 = new Md5();

      
        public ChangePWDForm()
        {
            InitializeComponent();
            access = new Access(accessFileRoad);
        }

        /// <summary>
        /// “修改密码”窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePWDForm_Load(object sender, EventArgs e)
        {
            registry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort");  //定义一个注册表
            adminRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\admin");  //定义管理员注册表
            userRegistry = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\user");   //定义用户注册表

            ras = new RSA(); //定义一个RAS用于加解密

            userNameTextbox.Text = "欢迎："+LoginForm.userName;
        }

        /// <summary>
        /// "确认修改"按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            string oldPwd = null;
            string accessOldPwd = null;  //数据库中的旧密码

            if (LoginForm.userType == "管理员")
            {
                adminRegistry.isRegistryValueNameExist(LoginForm.userName, ref oldPwd);
                accessOldPwd = access.searchUser("管理员", LoginForm.userName);
            }

            else //用户类型是 “一般用户”
            {
                userRegistry.isRegistryValueNameExist(LoginForm.userName, ref oldPwd);
                accessOldPwd = access.searchUser("一般用户", LoginForm.userName);
            }

            if (oldPWDTextbox.Text == oldPwd && md5.MD5Encryption(oldPWDTextbox.Text) == accessOldPwd)  //如果旧密码输入正确才能修改密码
            {
                if (newPWDTextBox.Text.Trim() != String.Empty)
                {

                    if (newPWDTextBox.Text.Trim() == newPWDTextBox2.Text.Trim())
                    {
                        if (LoginForm.userType == "管理员")  //“管理员修改密码”
                        {
                            //下面要对密码进行加密再储存在注册表里面
                            adminRegistry.SetValue(LoginForm.userName, ras.Encryption(newPWDTextBox.Text.Trim()), RegistryValueKind.String);
                            access.updatePassword("管理员", LoginForm.userName, md5.MD5Encryption(oldPWDTextbox.Text), md5.MD5Encryption(newPWDTextBox.Text.Trim()));
                        }
                        else  //“一般用户修改密码”
                        {
                            userRegistry.SetValue(LoginForm.userName, ras.Encryption(newPWDTextBox.Text.Trim()), RegistryValueKind.String);
                            access.updatePassword("一般用户", LoginForm.userName, md5.MD5Encryption(oldPWDTextbox.Text), md5.MD5Encryption(newPWDTextBox.Text.Trim()));
                        }
                        MessageBox.Show("修改成功！");
                        MainForm.logWriter.WriteLine(DateTime.Now.ToString() + ": \t" + LoginForm.userType + '\t' + LoginForm.userName + "\t 成功修改密码");
                    }
                    else
                        MessageBox.Show("两次密码输入不一致");
                }
                else
                    MessageBox.Show("输入密码不能为空");
            }
            else
            {
                MessageBox.Show("原密码输入错误");
            }
                      

        }

        /// <summary>
        /// “取消”按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
