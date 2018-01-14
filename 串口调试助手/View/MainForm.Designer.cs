namespace 串口调试助手
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Files = new System.Windows.Forms.ToolStripMenuItem();
            this.New = new System.Windows.Forms.ToolStripMenuItem();
            this.quitClick = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPortStated = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.userToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.crcToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.readToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.PicturetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.TemperaturePanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.savePictureButton = new System.Windows.Forms.Button();
            this.clearTeampaturebutton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.alarmTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.Black = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.receiveTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Temp = new System.Windows.Forms.Label();
            this.tempTextBox = new System.Windows.Forms.TextBox();
            this.getTemperatureButton = new System.Windows.Forms.Button();
            this.placeTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.autoCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.setTimeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.TemperaturePanel.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Files,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(825, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Files
            // 
            this.Files.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.quitClick});
            this.Files.Name = "Files";
            this.Files.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.Files.Size = new System.Drawing.Size(58, 21);
            this.Files.Text = "文件(&F)";
            // 
            // New
            // 
            this.New.Name = "New";
            this.New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New.Size = new System.Drawing.Size(152, 22);
            this.New.Text = "新建";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // quitClick
            // 
            this.quitClick.Name = "quitClick";
            this.quitClick.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitClick.Size = new System.Drawing.Size(152, 22);
            this.quitClick.Text = "退出";
            this.quitClick.Click += new System.EventHandler(this.quitClick_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.aboutToolStripMenuItem.Text = "关于(&H)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.serialPortStated,
            this.toolStripStatusLabel2,
            this.userToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 667);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // serialPortStated
            // 
            this.serialPortStated.Name = "serialPortStated";
            this.serialPortStated.Size = new System.Drawing.Size(96, 17);
            this.serialPortStated.Text = "Not Connected";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel2.Text = "             Time";
            // 
            // userToolStripStatusLabel
            // 
            this.userToolStripStatusLabel.Name = "userToolStripStatusLabel";
            this.userToolStripStatusLabel.Size = new System.Drawing.Size(88, 17);
            this.userToolStripStatusLabel.Text = "           欢迎：";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.showToolStripMenuItem.Text = "打开窗体";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.quitToolStripMenuItem.Text = "退出程序";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crcToolStripButton,
            this.addToolStripButton,
            this.deleteToolStripButton,
            this.readToolStripButton,
            this.searchStripButton3,
            this.PicturetoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 27);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // crcToolStripButton
            // 
            this.crcToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.crcToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("crcToolStripButton.Image")));
            this.crcToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.crcToolStripButton.Name = "crcToolStripButton";
            this.crcToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.crcToolStripButton.Text = "crcToolStripButton";
            this.crcToolStripButton.Click += new System.EventHandler(this.crcToolStripButton_Click);
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addToolStripButton.Text = "toolStripButton3";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteToolStripButton.Text = "toolStripButton4";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // readToolStripButton
            // 
            this.readToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.readToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("readToolStripButton.Image")));
            this.readToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.readToolStripButton.Name = "readToolStripButton";
            this.readToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.readToolStripButton.Text = "toolStripButton3";
            this.readToolStripButton.Click += new System.EventHandler(this.readToolStripButton_Click);
            // 
            // searchStripButton3
            // 
            this.searchStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("searchStripButton3.Image")));
            this.searchStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchStripButton3.Name = "searchStripButton3";
            this.searchStripButton3.Size = new System.Drawing.Size(24, 24);
            this.searchStripButton3.Text = "toolStripButton3";
            this.searchStripButton3.Click += new System.EventHandler(this.searchStripButton3_Click);
            // 
            // PicturetoolStripButton
            // 
            this.PicturetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PicturetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PicturetoolStripButton.Image")));
            this.PicturetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PicturetoolStripButton.Name = "PicturetoolStripButton";
            this.PicturetoolStripButton.Size = new System.Drawing.Size(24, 24);
            this.PicturetoolStripButton.Text = "toolStripButton3";
            this.PicturetoolStripButton.Click += new System.EventHandler(this.PicturetoolStripButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(427, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 19;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Gold;
            this.logoutButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logoutButton.ForeColor = System.Drawing.Color.Black;
            this.logoutButton.Location = new System.Drawing.Point(681, 0);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(56, 27);
            this.logoutButton.TabIndex = 20;
            this.logoutButton.Text = "注销";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.Gold;
            this.changePasswordButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changePasswordButton.ForeColor = System.Drawing.Color.Black;
            this.changePasswordButton.Location = new System.Drawing.Point(593, 0);
            this.changePasswordButton.Margin = new System.Windows.Forms.Padding(2);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(75, 27);
            this.changePasswordButton.TabIndex = 23;
            this.changePasswordButton.Text = "修改密码";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // TemperaturePanel
            // 
            this.TemperaturePanel.AutoScroll = true;
            this.TemperaturePanel.Controls.Add(this.label8);
            this.TemperaturePanel.Location = new System.Drawing.Point(223, 27);
            this.TemperaturePanel.Margin = new System.Windows.Forms.Padding(2);
            this.TemperaturePanel.Name = "TemperaturePanel";
            this.TemperaturePanel.Size = new System.Drawing.Size(573, 570);
            this.TemperaturePanel.TabIndex = 24;
            this.TemperaturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TemperaturePanel_Paint);
            this.TemperaturePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TemperaturePanel_MouseMove);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(255, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "温度折线图";
            // 
            // savePictureButton
            // 
            this.savePictureButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.savePictureButton.Location = new System.Drawing.Point(561, 615);
            this.savePictureButton.Margin = new System.Windows.Forms.Padding(2);
            this.savePictureButton.Name = "savePictureButton";
            this.savePictureButton.Size = new System.Drawing.Size(107, 37);
            this.savePictureButton.TabIndex = 25;
            this.savePictureButton.Text = "保存图片";
            this.savePictureButton.UseVisualStyleBackColor = true;
            this.savePictureButton.Click += new System.EventHandler(this.savePictureButton_Click);
            // 
            // clearTeampaturebutton
            // 
            this.clearTeampaturebutton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearTeampaturebutton.Location = new System.Drawing.Point(695, 615);
            this.clearTeampaturebutton.Margin = new System.Windows.Forms.Padding(2);
            this.clearTeampaturebutton.Name = "clearTeampaturebutton";
            this.clearTeampaturebutton.Size = new System.Drawing.Size(76, 37);
            this.clearTeampaturebutton.TabIndex = 26;
            this.clearTeampaturebutton.Text = "清除";
            this.clearTeampaturebutton.UseVisualStyleBackColor = true;
            this.clearTeampaturebutton.Click += new System.EventHandler(this.clearTeampaturebutton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1000;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 5000;
            this.toolTip1.ReshowDelay = 5000;
            // 
            // alarmTextBox
            // 
            this.alarmTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmTextBox.Location = new System.Drawing.Point(70, 18);
            this.alarmTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.alarmTextBox.MaxLength = 6;
            this.alarmTextBox.Name = "alarmTextBox";
            this.alarmTextBox.Size = new System.Drawing.Size(49, 23);
            this.alarmTextBox.TabIndex = 28;
            this.alarmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alarmTextBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(4, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 29;
            this.label10.Text = "报警温度";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.alarmTextBox);
            this.groupBox10.Location = new System.Drawing.Point(293, 602);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(151, 53);
            this.groupBox10.TabIndex = 30;
            this.groupBox10.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(123, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "℃";
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateButton.Location = new System.Drawing.Point(455, 615);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(78, 37);
            this.updateButton.TabIndex = 31;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.Location = new System.Drawing.Point(12, 27);
            this.Black.Margin = new System.Windows.Forms.Padding(2);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(36, 23);
            this.Black.TabIndex = 31;
            this.Black.UseVisualStyleBackColor = false;
            this.Black.Click += new System.EventHandler(this.Black_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.Black);
            this.groupBox9.Location = new System.Drawing.Point(213, 601);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(59, 53);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(4, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "折线样式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口";
            // 
            // portComboBox
            // 
            this.portComboBox.BackColor = System.Drawing.SystemColors.Menu;
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portComboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(49, 19);
            this.portComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(111, 22);
            this.portComboBox.TabIndex = 1;
            this.portComboBox.Tag = "";
            this.portComboBox.SelectedIndexChanged += new System.EventHandler(this.portComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(181, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // receiveTextBox
            // 
            this.receiveTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiveTextBox.Location = new System.Drawing.Point(2, 16);
            this.receiveTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.receiveTextBox.Name = "receiveTextBox";
            this.receiveTextBox.Size = new System.Drawing.Size(181, 180);
            this.receiveTextBox.TabIndex = 7;
            this.receiveTextBox.Text = "";
            this.receiveTextBox.TextChanged += new System.EventHandler(this.receiveTextBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.receiveTextBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 143);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(185, 198);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收框";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(126, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "℃";
            // 
            // Temp
            // 
            this.Temp.AutoSize = true;
            this.Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Temp.Location = new System.Drawing.Point(25, 33);
            this.Temp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(63, 14);
            this.Temp.TabIndex = 13;
            this.Temp.Text = "温度值：";
            // 
            // tempTextBox
            // 
            this.tempTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tempTextBox.Location = new System.Drawing.Point(78, 30);
            this.tempTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.Size = new System.Drawing.Size(48, 23);
            this.tempTextBox.TabIndex = 14;
            this.tempTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // getTemperatureButton
            // 
            this.getTemperatureButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.getTemperatureButton.Location = new System.Drawing.Point(41, 200);
            this.getTemperatureButton.Margin = new System.Windows.Forms.Padding(2);
            this.getTemperatureButton.Name = "getTemperatureButton";
            this.getTemperatureButton.Size = new System.Drawing.Size(98, 43);
            this.getTemperatureButton.TabIndex = 27;
            this.getTemperatureButton.Text = "获取温度";
            this.getTemperatureButton.UseVisualStyleBackColor = true;
            this.getTemperatureButton.Click += new System.EventHandler(this.getTemperatureButton_Click);
            // 
            // placeTextBox
            // 
            this.placeTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.placeTextBox.Location = new System.Drawing.Point(69, 162);
            this.placeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.placeTextBox.MaxLength = 20;
            this.placeTextBox.Name = "placeTextBox";
            this.placeTextBox.Size = new System.Drawing.Size(90, 23);
            this.placeTextBox.TabIndex = 33;
            this.placeTextBox.Text = "实验室";
            this.placeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(19, 164);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 32;
            this.label12.Text = "地点：";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.setTimeTextBox);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.autoCheckBox);
            this.groupBox8.Location = new System.Drawing.Point(33, 71);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(115, 69);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            // 
            // autoCheckBox
            // 
            this.autoCheckBox.AutoSize = true;
            this.autoCheckBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoCheckBox.Location = new System.Drawing.Point(18, 15);
            this.autoCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.autoCheckBox.Name = "autoCheckBox";
            this.autoCheckBox.Size = new System.Drawing.Size(82, 18);
            this.autoCheckBox.TabIndex = 7;
            this.autoCheckBox.Text = "自动发送";
            this.autoCheckBox.UseVisualStyleBackColor = true;
            this.autoCheckBox.CheckedChanged += new System.EventHandler(this.autoCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(72, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "ms";
            // 
            // setTimeTextBox
            // 
            this.setTimeTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setTimeTextBox.Location = new System.Drawing.Point(17, 35);
            this.setTimeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.setTimeTextBox.Name = "setTimeTextBox";
            this.setTimeTextBox.Size = new System.Drawing.Size(52, 23);
            this.setTimeTextBox.TabIndex = 8;
            this.setTimeTextBox.Text = "1000";
            this.setTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.placeTextBox);
            this.groupBox2.Controls.Add(this.getTemperatureButton);
            this.groupBox2.Controls.Add(this.tempTextBox);
            this.groupBox2.Controls.Add(this.Temp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 249);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 689);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.clearTeampaturebutton);
            this.Controls.Add(this.savePictureButton);
            this.Controls.Add(this.TemperaturePanel);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(841, 727);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(841, 727);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  陈俊杰温度监控软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TemperaturePanel.ResumeLayout(false);
            this.TemperaturePanel.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Files;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel serialPortStated;
        private System.Windows.Forms.ToolStripMenuItem quitClick;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem New;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton crcToolStripButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.ToolStripStatusLabel userToolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton readToolStripButton;
        private System.Windows.Forms.Panel TemperaturePanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button savePictureButton;
        private System.Windows.Forms.Button clearTeampaturebutton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox alarmTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ToolStripButton searchStripButton3;
        private System.Windows.Forms.ToolStripButton PicturetoolStripButton;
        private System.Windows.Forms.Button Black;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox receiveTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Temp;
        private System.Windows.Forms.TextBox tempTextBox;
        private System.Windows.Forms.Button getTemperatureButton;
        private System.Windows.Forms.TextBox placeTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox setTimeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox autoCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

