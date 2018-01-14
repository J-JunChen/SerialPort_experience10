using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;  //MD5需要的引用

namespace 串口调试助手
{
    class Md5
    {
        private MD5 md5;

        public Md5()
        { 
            md5 = new MD5CryptoServiceProvider();

        }

        /// <summary>
        /// MD5不可逆的加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string MD5Encryption(string input)
        {
            string output = null;
            byte[] inputByte = Encoding.Default.GetBytes(input);
            byte[] outputByte = md5.ComputeHash(inputByte);

            for(int i=0;i<outputByte.Length;i++)
            {
                output += outputByte[i].ToString("X");   //转换为16进制数
            }

         //   output = Encoding.Default.GetString(outputByte);

            return output;

        }

    }
}
