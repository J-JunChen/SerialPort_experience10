using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace 串口调试助手
{

    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        // private string sendTextBox = "01 03 00 00 00 01 84 0A"; //发送接收温度值指令

        // private string textBox2 = "00 06 00 04 00 00 c9 da"; //广播自动发送不使能
        // private string textBox2 = "00 06 00 04 00 01 08 1a"; //广播自动发送使能  

        public static FileStream file;//格式：每天一个文件
        public static StreamWriter fileWriter;  //用于写文件
        public static StreamReader fileReader;  //用于读取文件的行数

        public static FileStream logStream;
        public static StreamWriter logWriter;
        public static string logFile = "log.log";

        private static int line = 0;

        public static string fileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + ".txt";

        //public static string roadName = @"C:\Users\陈俊杰\Desktop\串口调试助手1";  //路径名

        public static string roadName = @"..\..\..\";  //路径名
        public static string imageFile = @"..\..\..\温度折线图";  //路径名
        public static string temperatureFile = @"..\..\..\温度记录文件";  //路径名

        public static string settingFile = @"C:\Users\Public\Documents\setting.xml";  //管理员的设置保存

        private PointF[] pointf = new PointF[21];
        private double[] temperatureText = new double[21];
        private static int num = 0;
        private static int count = 1;
        private Graphics graphics;
        private Bitmap bitmap;
        private DrawLine drawline;
        private Point mousePosition;

        private float move = 35f; //坐标偏移量，也是原点的x轴
        private static float move1 = 35f; //坐标偏移量，也是原点的x轴

        private static Pen lineColor = new Pen(Brushes.Black, 2);  //折线的颜色
        private static double alarmTemperature = 0;  //报警温度

        private Access access;
        private string accessFileRoad = @"..\..\..\Jun.mdb";
        private string[] config = new string[6]; //串口配置参数

        public MainForm()
        {
            LoginForm loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }

            else if (result == DialogResult.Yes)
            {
                InitializeComponent();
            }

        }

        /// <summary>
        /// 初始化串口设置
        /// </summary>
        /// 
        private void MainForm_Load(object sender, EventArgs e)
        {
            access = new Access(accessFileRoad);
            access.createTemperatureTable("温度表"); //在数据库中创建
            access.createPictureTable("温度折线图");
            access.createConfigTable("串口配置表");

            bitmap = new Bitmap(TemperaturePanel.Width, TemperaturePanel.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            drawline = new DrawLine();

            serialPort = new SerialPort();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; //禁用了所有的控件合法性检查


            groupBox8.Enabled = false;

            string[] ArrayComPortsName = SerialPort.GetPortNames(); //获取当前串口个数名称
            if (ArrayComPortsName.Length != 0)
            {
                Array.Sort(ArrayComPortsName);

                for (int i = 0; i < ArrayComPortsName.Length; i++)
                {
                    portComboBox.Items.Add(ArrayComPortsName[i]);
                }
                portComboBox.Text = ArrayComPortsName[0];

                if (portComboBox.Items.Count == 1)
                    serialPortStated.Text = portComboBox.Items[0].ToString() + " is Connected !";
                else
                    serialPortStated.Text = portComboBox.Items[portComboBox.SelectedIndex].ToString() + " is Connected !";

            }


            if (LoginForm.userType != "管理员")  //“一般用户”使用的时候，就将上一次“管理员”注销前的 设置串口配置 复用
            {
                addToolStripButton.Enabled = false; //“添加用户”按钮
                deleteToolStripButton.Enabled = false;  //“删除用户”按钮
                readToolStripButton.Enabled = false;
            }


            userToolStripStatusLabel.Text = "     欢迎：" + LoginForm.userName;


            if (!Directory.Exists(imageFile))  //判断文件夹是否存在
            {
                Directory.CreateDirectory(imageFile);
            }
            if (!Directory.Exists(temperatureFile))
            {
                Directory.CreateDirectory(temperatureFile);
            }

            if (File.Exists(temperatureFile + '\\' + fileName) == false)  //判断记录温度的txt是否存在，如果不存在则需要创建
            {
                file = File.Create(temperatureFile + '\\' + fileName);
                file.Close();
            }
           
            System.Diagnostics.Debug.Write("文件已经存在");

            fileReader = new StreamReader(temperatureFile + '\\' + fileName);
            while (fileReader.ReadLine() != null)
                line++;
            System.Diagnostics.Debug.WriteLine("行数：" + line);
            fileReader.Close();

            file = new FileStream(temperatureFile + '\\' + fileName, FileMode.Append);

            fileWriter = new StreamWriter(file, System.Text.Encoding.Default);



            if (File.Exists(logFile) == false)  //判断记录温度的txt是否存在，如果不存在则需要创建
            {

                logStream = File.Create(logFile);
                logStream.Close();
            }
            System.Diagnostics.Debug.Write("log文件已经存在");

            logStream = new FileStream(logFile, FileMode.Append);

            logWriter = new StreamWriter(logStream, System.Text.Encoding.Default);

            logWriter.WriteLine(DateTime.Now.ToString() + ": \t" + LoginForm.userType + '\t' + LoginForm.userName + "\t登陆成功！");

        }


        /// <summary>
        /// 显示COM状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (portComboBox.Items.Count == 0)
                serialPortStated.Text = "Not Connected！";
            //if (portComboBox.Items.Count == 1)
            //    serialPortStated.Text = portComboBox.Items[0].ToString() + " is Connected !";
            else
                serialPortStated.Text = portComboBox.Items[portComboBox.SelectedIndex].ToString() + " is Connected !";
        }

        /// <summary>
        /// “串口”数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //* Byte数组的个数是不确定的，根据实时返回的指令个数为准,而且返回的都是10进制数
                do
                {
                    //serialPort.ReadBufferSize();
                    int count = serialPort.BytesToRead;
                    if (count <= 0)
                        break;
                    Byte[] dataBuff = new Byte[count];
                    serialPort.Read(dataBuff, 0, count);
                    string str = null;
                    string strAscii = null;
                    string tempStr = null;


                    for (int i = 0; i < count; i++)
                    {
                        strAscii += ((char)dataBuff[i]).ToString() + ' '; //转换为字符
                        string s = dataBuff[i].ToString("X");
                        if (s.Length == 1)   //当16进制数只有一位是，在前面补上0；
                            s = "0" + s;
                        if (i == 3 || i == 4)
                        {
                            tempStr += s;
                        }
                        str += s + ' ';

                    }

                    double temp = (double)(Convert.ToInt32(tempStr, 16)) / 10.0; //计算温度值

                    //画温度图
                    Draw(temp);

                    tempTextBox.Text = Convert.ToString(temp); //tempTextBox显示温度值

                    // System.Diagnostics.Debug.WriteLine("序号：" + line++ + "\t日期：" + DateTime.Now.ToString() + "\t用户名：" + LoginForm.userName + "\t温度：" + tempTextBox.Text);

                    fileWriter.WriteLine("序号：" + ++line + "    日期：" + DateTime.Now.ToString() + "    用户类型：" + LoginForm.userType + "    用户名：" + LoginForm.userName + "    温度：" + tempTextBox.Text + "℃" + "    采样地点：" + placeTextBox.Text);

                    access.insertTemperature("温度表", LoginForm.userType, LoginForm.userName, DateTime.Now.ToString(), tempTextBox.Text + "℃", placeTextBox.Text);



                    // receiveTextBox.AppendText("接收16进制指令：" + str + "\r\n\r\n");
                    receiveTextBox.AppendText(DateTime.Now.ToString("hh:mm:ss") + " 的温度：" + tempTextBox.Text + "℃" + "\r\n\r\n");


                } while (serialPort.BytesToRead > 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show("error:接收返回信息异常：" + ex.Message);
            }

        }


        /// <summary>
        /// "关于" 按钮的操作，启动关于窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutform = new AboutForm();
            aboutform.StartPosition = FormStartPosition.CenterScreen; //开始的窗体位置在屏幕中间
            aboutform.Show();
        }




        /// <summary>
        /// timer控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)  //时钟事件
        {
            // sendButton_Click(sender, e);
            getTemperatureButton_Click(sender, e);
        }

        /// <summary>
        /// “自动发送”复选框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoCheckBox_CheckedChanged(object sender, EventArgs e)  //自动发送事件
        {
            if (autoCheckBox.Checked)  //判断自动发送是否被选择，如果选择了，则启用timer时钟
            {
                setTimeTextBox.Enabled = false;  //设置的时间间距不能修改
                timer.Enabled = true;
                //timer.Interval = 1000;
                timer.Interval = int.Parse(setTimeTextBox.Text);

              //  logWriter.WriteLine(DateTime.Now.ToString() + ": " + LoginForm.userType + '\t' + LoginForm.userName + "\t 选择数据自动接收，间距" + setTimeTextBox.Text + "s");

            }
            else
            {
                timer.Enabled = false; //timer不能启用
                setTimeTextBox.Enabled = true;  // //设置的时间间距可以修改
            }
        }



        /// <summary>
        /// “退出”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitClick_Click(object sender, EventArgs e)
        {
            this.Dispose();  //清空正在使用的所有资源
            this.Close();
        }

        /// <summary>
        /// “清除”按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            receiveTextBox.Text = "";
        }


        /// <summary>
        /// “新建”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        /// <summary>
        /// 当前时间获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "         Time: " + DateTime.Now.ToString();
        }


        /// <summary>
        /// 添加双击托盘图标事件（双击显示窗口）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Normal;//还原窗体显示
                this.Visible = true;
                //this.Activate();  //激活窗体并给予它焦点
                this.ShowInTaskbar = true; //任务栏显示图标       
            }

        }

        /// <summary>
        /// 判断是否最小化，然后显示托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        /// <summary>
        /// 确认是否退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginForm.userType == "管理员")
            {
                config[0] = portComboBox.Text;
                config[1] = "9600";
                config[2] = "8";
                config[3] = "1";
                config[4] = "HEX";
                config[5] = "HEX";
                access.updateConfig("串口配置表", config);
            }

            if (fileWriter != null)
                fileWriter.Close();
            if (file != null)
                file.Close();

            if (logWriter != null)
                logWriter.Close();
            if (logStream != null)
                logStream.Close();  //日志文件关闭
        }



        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 托盘右键推出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crcToolStripButton_Click(object sender, EventArgs e)
        {
            CRCForm crcForm = new CRCForm();
            crcForm.Show();
        }


        /// <summary>
        /// “注销”按钮 ， 当“管理员” 注销时，其设置的串口配置将会被保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void logoutButton_Click(object sender, EventArgs e)
        {
            logWriter.WriteLine(DateTime.Now.ToString() + ": \t" + LoginForm.userType + '\t' + LoginForm.userName + "\t注销成功！");

            serialPort.Close();
            fileWriter.Close();
            file.Close();

            Application.Restart();

        }

        /// <summary>
        /// ”添加用户“，加了权限，只有管理员才能再MainForm里面添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            RegisterForm addUserForm = new RegisterForm();
            addUserForm.Show();
        }

        /// <summary>
        /// “删除用户”，只有管理员才能删除用户。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteUserForm deleteUserForm = new DeleteUserForm();
            deleteUserForm.Show();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePWDForm cpf = new ChangePWDForm();
            cpf.Show();
        }

        /// <summary>
        /// 读取储存温度的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readToolStripButton_Click(object sender, EventArgs e)
        {
            ReadForm readForm = new ReadForm();
            readForm.Show();
        }


        /// <summary>
        /// 温度折线图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemperaturePanel_Paint(object sender, PaintEventArgs e)
        {
            drawline.DrawXY(graphics, TemperaturePanel, move);
            drawline.DrawXLine(graphics, TemperaturePanel, 20f, 20, move);
            drawline.DrawYLine(graphics, TemperaturePanel, 20f, 30f, 20, move);
            TemperaturePanel.BackgroundImage = bitmap;
        }

        /// <summary>
        /// 画点和图
        /// </summary>
        /// <param name="temperature"></param>
        private void Draw(double temperature)
        {
            temperatureText[num] = temperature;

            float y = (float)(temperature - 20) * 50;
            pointf[num] = new PointF(move1 += 25f, y);


            System.Diagnostics.Debug.WriteLine("PointF.Owid:" + pointf[num].X + ", Pointf.Ohei:" + pointf[num].Y);

            pointf[num].Y = TemperaturePanel.Height - move - pointf[num].Y;

            System.Diagnostics.Debug.WriteLine("PointF.wid:" + pointf[num].X + ", Pointf.hei:" + pointf[num].Y);

            drawline.DrawFillEllipse(graphics, pointf[num]);
            //drawline.DrawTextBox(graphics, Convert.ToString(temperature), pointf[num]);
            drawline.DrawTextBox(graphics, Convert.ToString(count++), pointf[num]);
            switch (num)
            {
                case 0:
                    num++;
                    break;

                case 20:

                    bitmap = new Bitmap(TemperaturePanel.Width, TemperaturePanel.Height);
                    graphics = Graphics.FromImage(bitmap);
                    graphics.Clear(Color.White);

                    for (int i = 0; i < num; i++)
                    {
                        pointf[i] = pointf[i + 1];
                        temperatureText[i] = temperatureText[i + 1];
                    }
                    DrawOldLine(pointf, temperatureText);

                    // num=num-1;
                    break;

                default:
                    if (alarmTemperature == 0)
                        drawline.Drawline(graphics, pointf[num - 1], pointf[num], lineColor);

                    // pointf[num].Y = TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50;
                    else
                        drawline.Drawline(graphics, pointf[num - 1], pointf[num], lineColor, (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50);

                    num++;
                    break;
            }
            TemperaturePanel.Refresh();
        }


        /// <summary>
        /// 折线实时更新，折线先后拖曳
        /// </summary>
        /// <param name="temperature"></param>
        private void DrawOldLine(PointF[] oldPointf, double[] oldWenDu)
        {
            if (alarmTextBox.Text.Trim().Length > 0)
            {
                alarmTemperature = Convert.ToDouble(alarmTextBox.Text);

                float newX = TemperaturePanel.Width - move;
                float newY = (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50;
                //画温度警报线
                PointF px1 = new PointF(move, newY);
                PointF px2 = new PointF(newX, newY);
                graphics.DrawLine(new Pen(Brushes.Red, 2), px1, px2);
                //drawline.Drawline(graphics, pointf[num - 1], pointf[num], lineColor, (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50);
            }


            float move2 = TemperaturePanel.Width - move;
            float x = move1;
            int count2 = count;
            PointF[] p = new PointF[20];
            for (int i = num - 1; i >= 0; i--)
            {
                float y = (float)(oldWenDu[i] - 20) * 50;

                oldPointf[i] = new PointF(move2, y);
                oldPointf[i].Y = TemperaturePanel.Height - move - oldPointf[i].Y;
                drawline.DrawFillEllipse(graphics, oldPointf[i]);
                drawline.DrawTextBox(graphics, Convert.ToString(count2--), oldPointf[i]);
                move2 -= 25f;
                p[i] = oldPointf[i];

            }

            for (int i = 1; i < 20; i++)
            {
                if (alarmTemperature == 0)
                    drawline.Drawline(graphics, p[i - 1], pointf[i], lineColor);

                // pointf[num].Y = TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50;
                else
                    drawline.Drawline(graphics, pointf[i - 1], pointf[i], lineColor, (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50);

            }

            // graphics.DrawLines(lineColor, p);
            TemperaturePanel.Refresh();
        }

        /// <summary>
        /// 求两点距离
        /// </summary>
        /// <param name="p1">第一点</param>
        /// <param name="p2">第二点</param>
        /// <returns></returns>
        public double PointToPoint(Point p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }



        /// <summary>
        /// “保存图片”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePictureButton_Click(object sender, EventArgs e)
        {
            string imageRoad = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".jpg";
            bitmap.Save(imageFile + '\\' + imageRoad);

            access.insertPicutre("温度折线图", LoginForm.userType, LoginForm.userName, DateTime.Now.ToString(), imageFile + '\\' + imageRoad);
            //access.insertPicutre("温度折线图", DateTime.Now.ToString(), bitmap);
          //  logWriter.WriteLine(DateTime.Now.ToString() + ": " + LoginForm.userType + '\t' + LoginForm.userName + "\t 点击保存图片");

            MessageBox.Show("保存图片成功！");
        }


        /// <summary>
        /// 清空温度折线图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTeampaturebutton_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(TemperaturePanel.Width, TemperaturePanel.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            num = 0;
            move1 = move;
            count = 1;  //一次性点的个数
            TemperaturePanel.Refresh();

         //   logWriter.WriteLine(DateTime.Now.ToString() + ": " + LoginForm.userType + '\t' + LoginForm.userName + "\t 点击清除图片");

        }


        /// <summary>
        /// 在控件鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemperaturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            // TemperaturePanel.Capture = true;
            mousePosition = e.Location;

            // System.Diagnostics.Debug.WriteLine("mouse.X:" + mousePosition.X + ", mouse.Y: " + mousePosition.Y);
            for (int i = 0; i < num; i++)
            {
                // TemperaturePanel.Controls.Add(temperatureText[num]);
                System.Diagnostics.Debug.WriteLine("i:" + i + "PTOP: " + PointToPoint(mousePosition, pointf[i]) + "mouse.X:" + mousePosition.X + ", mouse.Y: " + mousePosition.Y + "pointf.X: " + pointf[i].X + "pointf.y:" + pointf[i].Y);

                if (PointToPoint(mousePosition, pointf[i]) < 10)
                {
                    toolTip1.SetToolTip(TemperaturePanel, "温度：" + temperatureText[i] + "℃");
                }

                // else
                //  label[i].Visible = false;
            }
        }

        /// <summary>
        ///" 获取温度"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getTemperatureButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    serialPort.PortName = portComboBox.Text;
                    serialPort.BaudRate = Convert.ToInt32("9600");  //转换为10进制
                    serialPort.DataBits = Convert.ToInt16("8");
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    serialPort.Open();
                    serialPort.ReceivedBytesThreshold = 7; //获取或设置 System.IO.Ports.SerialPort.DataReceived 事件发生前内部输入缓冲区中的字节数。
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                    serialPortStated.Text = portComboBox.Text + " is Ok !";
                }
                catch
                {
                    MessageBox.Show("串口设置错误");
                }
            }
            else
            {
                groupBox8.Enabled = true;
            }

            if (serialPort.IsOpen)  //判断串口是否打开
            {
                string sendText = ("01 03 00 00 00 01 84 0a").Replace(" ", "");

                if ((sendText.Length % 2) != 0)
                {
                    sendText += " ";
                }
                byte[] byteData = new byte[sendText.Length / 2];

                for (int i = 0; i < byteData.Length; i++)
                {
                    byteData[i] = Convert.ToByte(sendText.Substring(i * 2, 2), 16);
                }
                serialPort.Write(byteData, 0, byteData.Length);

               // logWriter.WriteLine(DateTime.Now.ToString() + ": " + LoginForm.userType + '\t' + LoginForm.userName + "\t点击获取温度");

            }
            else
            {
                MessageBox.Show("串口还没打开，先按打开按钮！！");
            }

        }


        /// <summary>
        /// 更新报警温度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (alarmTextBox.Text.Trim().Length > 0)
            {
                alarmTemperature = Convert.ToDouble(alarmTextBox.Text);

                clearTeampaturebutton_Click(sender, e);
                float newX = TemperaturePanel.Width - move;
                float newY = (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50;
                //画温度警报线
                PointF px1 = new PointF(move, newY);
                PointF px2 = new PointF(newX, newY);
                graphics.DrawLine(new Pen(Brushes.Red, 2), px1, px2);
                //drawline.Drawline(graphics, pointf[num - 1], pointf[num], lineColor, (float)TemperaturePanel.Height - move - (float)(alarmTemperature - 20) * 50);
                //logWriter.WriteLine(DateTime.Now.ToString() + ": " + LoginForm.userType + '\t' + LoginForm.userName + "\t 更新报警温度:" + alarmTextBox.Text.Trim() + "℃");

            }
        }

        /// <summary>
        /// 折线变"黑色"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Black_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.FullOpen = false; //是否显示ColorDialog有半部分，运行一下就很了然了
            //colorDialog1.CustomColors = colorDialog1.Color;//设置自定义颜色
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                Color color_from = colorDialog1.Color;
                lineColor = new Pen(color_from, 2);
                int a = color_from.R;
                int b = color_from.G;
                int c = color_from.B;

                Black.BackColor = color_from;
               // string str;
               // str = a.ToString() + "  " + b.ToString() + "  " + c.ToString() + "  ";
               // MessageBox.Show(str);
            }
        }


        /// <summary>
        /// "查看数据库的温度"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchStripButton3_Click(object sender, EventArgs e)
        {
            searchDataBaseForm form = new searchDataBaseForm();
            form.Show();
        }

        private void PicturetoolStripButton_Click(object sender, EventArgs e)
        {
            PictureForm form = new PictureForm();
            form.Show();
        }


        //richTextBox的滚轮一直置于最下方
        private void receiveTextBox_TextChanged(object sender, EventArgs e)
        {
            receiveTextBox.ScrollToCaret();
        }


        /// <summary>
        /// 报警温度不能是负数和其他非数字字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alarmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }
    }
    
}
