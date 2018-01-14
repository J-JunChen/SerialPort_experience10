using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;

namespace 串口调试助手
{
    public class Regedit
    {
        private RegistryKey softWare;//注册表类型变量    
        private string[] sValueNameColl;  //键值表项
        private string[] sKeyNameColl;  //注册表项

        private RSA ras = new RSA();  // 这是我整合的 RSA 常用的方法的一个类 

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="registry">判断哪里添加注册表</param>
        /// <param name="subKey">注册表的软件名称</param>
        public Regedit(RegistryKey registry, string subKey)
        {
            this.softWare = registry.CreateSubKey(subKey); //创建一个新子项或打开一个现有子项以进行写访问。
            // this.softWare = registry.OpenSubKey(subKey,true);  //需要加上true才能对键值进行写操作，否则默认是读操作

            sKeyNameColl = softWare.GetValueNames();
            sValueNameColl = softWare.GetValueNames();  //获取JUN-SerialPort所有子项
        }

        /// <summary>
        /// 判断注册表是否存在
        /// </summary>
        /// <param name="sKeyName"></param>
        /// <returns></returns>
        public bool isRegistryKeyExit(string sKeyName)
        {            
            foreach (string sName in sKeyNameColl)
            {
                if (sName == sKeyName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  判断键值是否存在
        /// </summary>
        /// <param name="sValueName">注册表名 </param>
        /// <param name="value">返回键值的值</param>
        /// <returns></returns>
        public bool isRegistryValueNameExist(string sValueName, ref string value)
        {        
            foreach (string sName in sValueNameColl)
            {
                if (sName == sValueName)  //如果键匹配了
                {
                    value = ras.Decrypt(Convert.ToString(softWare.GetValue(sName)));//那就将该键的值，即密码，进行RSA解密  
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  判断键值是否存在
        /// </summary>
        /// <param name="sValueName">注册表名 </param>
        /// <returns></returns>
        public bool isRegistryValueNameExist(string sValueName)
        {
            foreach (string sName in sValueNameColl)
            {
                if (sName == sValueName)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 在注册表里添加键值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="valueKind"></param>
        public void SetValue(string name,string value, Microsoft.Win32.RegistryValueKind valueKind)
        {
            try
            {
                softWare.SetValue(name, value, valueKind);
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现异常："+ex);
            }
        }

        /// <summary>
        /// 返回所有键值
        /// </summary>
        /// <returns></returns>
        public string[] GetKeyNames()
        {
            return sValueNameColl;          
        }


        /// <summary>
        /// 删除注册表键值
        /// </summary>
        /// <param name="keyName">键值</param>
        /// <returns></returns>
        public bool DeleteKey(string keyName)
        {
            if (sValueNameColl.Length > 0)
            {
                softWare.DeleteValue(keyName); //只需要删除其中的键，那么键和值都会被删除 
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 注册表关闭
        /// </summary>
         ~Regedit()
        {
            softWare.Close();
        }
    }
}
