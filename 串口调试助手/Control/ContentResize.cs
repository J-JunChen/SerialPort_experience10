using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口调试助手
{
    class ContentResize
    {

        /// <summary>
        /// 两个groupBox的居中
        /// </summary>
        /// <param name="kidBox">子groupBox</param>
        /// <param name="FatherBox">父groupBox</param>
        public void GroupBoxReSize(GroupBox kidBox, GroupBox FatherBox)
        {
            kidBox.Left = (FatherBox.Left - kidBox.Left) / 2;
            int x = (int)(FatherBox.Width - kidBox.Width) / 2;
            int y = kidBox.Location.Y;
            kidBox.Location = new Point(x, y);

        }
    }
}
