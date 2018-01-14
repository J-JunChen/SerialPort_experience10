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


namespace 串口调试助手
{
    public partial class DeleteUserForm : Form
    {
        private Regedit regedit; //实例化一个注册表实例
        private string[] keyNames; //返回所有键值
        private Access access;
        private string accessFileRoad = @"..\..\..\Jun.mdb";

        public DeleteUserForm()
        {
            InitializeComponent();
            access = new Access(accessFileRoad);
        }


        /// <summary>
        /// 加载“注册表”的用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteUser_Load(object sender, EventArgs e)
        {
            regedit = new Regedit(Registry.CurrentUser, @"SOFTWARE\JUN-SerialPort\user");
            keyNames = regedit.GetKeyNames();

            foreach (string name in keyNames)
                userComboBox.Items.Add(name);
            if (keyNames.Length > 0)
            {
                userComboBox.Text = userComboBox.Items[0].ToString();
            }
           
        } 
   

        private void sureButton_Click(object sender, EventArgs e)
        {
            if (keyNames.Length == 0)  
                MessageBox.Show("对不起，用户为空，没有用户可以删除！");

            else  //键值不为空
            {
                if (userComboBox.Items.Count == 1)
                    userComboBox.Text = userComboBox.Items[0].ToString();
                else
                    userComboBox.Text = userComboBox.Items[userComboBox.SelectedIndex].ToString();
                if (MessageBox.Show("你将要删除用户 “" + userComboBox.Text + "” 吗？", "删除用户", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                 {
                    if (regedit.DeleteKey(userComboBox.Text) && access.deleteUser("一般用户", userComboBox.Text)) //在数据库和注册表内一起删除
                    {                        
                        MessageBox.Show("删除成功！");
                        userComboBox.Items.Clear();   //先将Combobox清空
                        DeleteUser_Load(sender, e);  //再重新加载
                    }
                    else
                        MessageBox.Show("删除失败！");
                }
            }
        }


        /// <summary>
        /// "取消" 按钮，返回主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
