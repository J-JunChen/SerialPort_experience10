using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 串口调试助手
{
    class XmlFile
    {
        public XmlFile()
        {

        }

        public void Create()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0","UTF-8",null);
            doc.AppendChild(dec);

            XmlElement root = doc.CreateElement("窗口设置");
            doc.AppendChild(root);

            XmlElement portNameSetting = doc.CreateElement("端口");
            XmlText portText = doc.CreateTextNode("COM3");
            portNameSetting.AppendChild(portText);
            root.AppendChild(portNameSetting);

            XmlElement baudRateSetting = doc.CreateElement("波特率");
            XmlText baudRateText = doc.CreateTextNode("9600");
            baudRateSetting.AppendChild(baudRateText);
            root.AppendChild(baudRateSetting);

            XmlElement dataBitSetting = doc.CreateElement("数据位");
            XmlText dataBitText = doc.CreateTextNode("8");
            dataBitSetting.AppendChild(dataBitText);
            root.AppendChild(dataBitSetting);

            XmlElement stopBitSetting = doc.CreateElement("停止位");
            XmlText stopBitText = doc.CreateTextNode("1");
            stopBitSetting.AppendChild(stopBitText);
            root.AppendChild(stopBitSetting);

            XmlElement receiverSetting = doc.CreateElement("接收设置");
            XmlText receiverText = doc.CreateTextNode("hex");
            receiverSetting.AppendChild(receiverText);
            root.AppendChild(receiverSetting);

            XmlElement sendSetting = doc.CreateElement("发送设置");
            XmlText sendText = doc.CreateTextNode("hex");
            sendSetting.AppendChild(sendText);
            root.AppendChild(sendSetting);


            XmlElement autoSendSetting = doc.CreateElement("自动发送");
            XmlText autoSendText = doc.CreateTextNode("Y");
            autoSendSetting.AppendChild(autoSendText);
            root.AppendChild(autoSendSetting);

            XmlElement timeSetting = doc.CreateElement("自动发送间距");
            XmlText timeText = doc.CreateTextNode("1000");
            timeSetting.AppendChild(timeText);
            root.AppendChild(timeSetting);

            doc.Save(@"C:\Users\陈俊杰\Desktop\串口调试助手1\setting.xml");
        }
    }
}
