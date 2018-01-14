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
    public partial class CRCForm : Form
    {
        public CRCForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expression = this.textBox1.Text.Trim();
            this.textBox2.Text = this.CRCCalc(expression).ToString();
        }

        public string CRCCalc(string data)  //CRC检验算法
        {
            string[] datas = data.Split(' ');
            List<byte> bytedata = new List<byte>();

            foreach (string str in datas)
            {
                bytedata.Add(byte.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            byte[] crcbuf = bytedata.ToArray();
            //计算并填写CRC校验码
            int crc = 0xffff;
            int len = crcbuf.Length;
            for (int n = 0; n < len; n++)
            {
                byte i;
                crc = crc ^ crcbuf[n];
                for (i = 0; i < 8; i++)
                {
                    int TT;
                    TT = crc & 1;
                    crc = crc >> 1;
                    crc = crc & 0x7fff;
                    if (TT == 1)
                    {
                        crc = crc ^ 0xa001;
                    }
                    crc = crc & 0xffff;
                }
            }
            string[] redata = new string[2];
            redata[1] = Convert.ToString((byte)((crc >> 8) & 0xff), 16);
            redata[0] = Convert.ToString((byte)((crc & 0xff)), 16);
            if (redata[1].Length < 2)
                redata[1] = "0" + redata[1];
            if (redata[0].Length < 2)
                redata[0] = "0" + redata[0];

            return redata[0] + " " + redata[1];
        }

      
    }
}
