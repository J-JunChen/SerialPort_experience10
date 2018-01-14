using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;  //这个命名空间包含了注册表相关的类，registry类、registryKey
using System.Security; //RAS加密需要引用的包  
using System.Security.Cryptography;

namespace 串口调试助手
{
    public class RSA
    {
   
        /// <summary>
        /// 使用”RSA“加密
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public string Encryption(string express)
        {
            CspParameters param = new CspParameters(); //CspParameters: 包含传递给执行加密计算的加密服务提供程序(CSP) 的参数
            param.KeyContainerName = "JunKey";  //密钥容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plainData = Encoding.Default.GetBytes(express);  //将要加密的字符串转换为字节数组
                byte[] encryptData = rsa.Encrypt(plainData, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptData); //将加密后的字节数组转换为字符串
            }
        }

        /// <summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public string Decrypt(string ciphertext)
        {
        ///  使用”RSA“解密
        /// </summary>
            CspParameters param = new CspParameters();
            param.KeyContainerName = "JunKey";    //密钥容器的名称，保持加密解密一致才能解密成功  
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encrytData = Convert.FromBase64String(ciphertext);
                byte[] decryptData = rsa.Decrypt(encrytData, false);
                return Encoding.Default.GetString(decryptData);
            }
        }


    }


}
