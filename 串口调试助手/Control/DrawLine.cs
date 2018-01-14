using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 串口调试助手
{
    class DrawLine
    {

        public  void DrawXY(Graphics panelGraphics,Panel pan, float move )
        {
            // float move = 30f;
            float newX = pan.Width - move;
            float newY = pan.Height - move;

            //画x轴
            PointF px1 = new PointF(move, newY);
            PointF px2 = new PointF(newX, newY);
            panelGraphics.DrawLine(new Pen(Brushes.Black, 2), px1, px2);

            //画y轴
            PointF py1 = new PointF(move, move);
            PointF py2 = new PointF(move, newY);
            panelGraphics.DrawLine(new Pen(Brushes.Black, 2), py1, py2);

        }
        /// <summary>  
        /// 画出X轴上的分值线，从零开始  
        /// </summary>  
        /// <param name="pan"></param>  
        /// <param name="maxX">最大的x值</param>  
        /// <param name="len">要分成多少段</param>  
        /// <param name="Scale">刻度名</param>
        #region   画出X轴上的分值线，从零开始  
        public void DrawXLine(Graphics panelGraphics, Panel pan, float maxX, int len, float move)
        {
            //float move = 30f;

            float LenX = pan.Width - 2 * move;


            for (int i = 1; i <= len; i++)
            {
                PointF py1 = new PointF(LenX * i / len + move, pan.Height - move - 4);
                PointF py2 = new PointF(LenX * i / len + move, pan.Height - move);
                string sy = (maxX * i / len).ToString();
                panelGraphics.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
                panelGraphics.DrawString(sy, new Font("宋体", 8f), Brushes.Black, new PointF(LenX * i / len + move, pan.Height - move / 1.1f));
            }

            panelGraphics.DrawString("时间/次", new Font("宋体 ", 8f), Brushes.Red, new PointF(pan.Width - move*1.5f, pan.Height - move / 1.5f));
        }
        #endregion

        /// <summary>  
        /// 画出Y轴上的分值线，从零开始  
        /// </summary>  
        /// <param name="pan"></param>  
        /// <param name="maxY"></param>  
        /// <param name="len"></param>  
        #region   画出Y轴上的分值线，从零开始  
        public  void DrawYLine(Graphics panelGraphics, Panel pan, float maxY, int len, float move)
        {
           // float move = 30f;
            float LenY = pan.Height - 2 * move;
            for (int i = 0; i <= len; i++)    //len等份Y轴  
            {
                PointF px1 = new PointF(move, LenY * i / len + move);
                PointF px2 = new PointF(move + 4, LenY * i / len + move);
                string sx = (maxY - maxY * i / len).ToString();
                panelGraphics.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                panelGraphics.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / len + move * 1.1f), drawFormat);
            }
            panelGraphics.DrawString("温度", new Font("宋体 ", 8f), Brushes.Red, new PointF(move / 3, move / 3f));
        }
        #endregion


        /// <summary>  
        /// 画出Y轴上的分值线，从任意值开始  
        /// </summary>  
        /// <param name="pan"></param>  
        /// <param name="minY"></param>  
        /// <param name="maxY"></param>  
        /// <param name="len"></param>  
        #region   画出Y轴上的分值线，从任意值开始  
        public  void DrawYLine(Graphics panelGraphics, Panel pan, float minY, float maxY, int len , float move)
        {
            //float move = 30f;
            float LenY = pan.Height - 2 * move;
            for (int i = 0; i <= len; i++)    //len等份Y轴  
            {
                PointF px1 = new PointF(move, LenY * i / len + move);
                PointF px2 = new PointF(move + 4, LenY * i / len + move);
                string sx = (maxY - (maxY - minY) * i / len).ToString();
                panelGraphics.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                panelGraphics.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / len + move * 1.1f), drawFormat);
            }
            Pen pen = new Pen(Color.Black, 1);
            panelGraphics.DrawString("温度/℃", new Font("宋体 ", 8f), Brushes.Red, new PointF(move / 3, move / 3f));
        }
        #endregion


        /// <summary>
        /// 两点画线，有警报温度
        /// </summary>
        /// <param name="panelGraphics"></param>
        /// <param name="pointF1"></param>
        /// <param name="pointF2"></param>
        /// <param name="pen"></param>
        /// <param name="alarmY"></param>
        public void Drawline(Graphics panelGraphics, PointF pointF1, PointF pointF2 , Pen pen, float alarmY)
        {

            Pen pen2 = new Pen(Brushes.Red, 2);
       
            if (pointF2.Y < alarmY)
                panelGraphics.DrawLine(pen2, pointF1, pointF2);
            else
                panelGraphics.DrawLine(pen, pointF1, pointF2);

        }

        /// <summary>
        /// 两点画线，无警报温度
        /// </summary>
        /// <param name="panelGraphics"></param>
        /// <param name="pointF1"></param>
        /// <param name="pointF2"></param>
        /// <param name="pen"></param>
        public void Drawline(Graphics panelGraphics, PointF pointF1, PointF pointF2, Pen pen)
        {
            panelGraphics.DrawLine(pen, pointF1, pointF2);
        }

        public  void DrawFillEllipse(Graphics panelGraphics, PointF pointF)
        {
            Pen pen = new Pen(Brushes.Red);
            panelGraphics.FillEllipse(Brushes.Red, new RectangleF(pointF.X - 4, pointF.Y - 1, 6, 6));

        }

        public  void DrawTextBox(Graphics panelGraphics, string text, PointF pointF)
        {
            TextBox textBox = new TextBox();
            textBox.Text = text;
            textBox.Visible = true;
            panelGraphics.DrawString(text, new Font("微软雅黑", 8), Brushes.Black, pointF);
        }


        public void DrawPath(Graphics panelGraphics, PointF pointF1, PointF pointF2)
        {
            Pen pen = new Pen(Brushes.Red);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(pointF1,pointF2);
            panelGraphics.DrawPath(pen, path);
        }

    }
}
