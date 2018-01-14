namespace 串口调试助手
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.userCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recaptchaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.recaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(86, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(86, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameTextbox.Location = new System.Drawing.Point(152, 73);
            this.userNameTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userNameTextbox.Multiline = true;
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(108, 28);
            this.userNameTextbox.TabIndex = 2;
            this.userNameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userNameTextbox_KeyDown);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordTextBox.Location = new System.Drawing.Point(152, 132);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(108, 28);
            this.passwordTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Location = new System.Drawing.Point(196, 362);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(63, 35);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registerButton.Location = new System.Drawing.Point(88, 362);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(64, 35);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "注册";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(70, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户类型：";
            // 
            // userCombobox
            // 
            this.userCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userCombobox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userCombobox.FormattingEnabled = true;
            this.userCombobox.Location = new System.Drawing.Point(152, 186);
            this.userCombobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userCombobox.Name = "userCombobox";
            this.userCombobox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userCombobox.Size = new System.Drawing.Size(108, 24);
            this.userCombobox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(37, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "欢迎使用陈俊杰温度监控系统";
            // 
            // recaptchaTextBox
            // 
            this.recaptchaTextBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recaptchaTextBox.Location = new System.Drawing.Point(152, 234);
            this.recaptchaTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recaptchaTextBox.Multiline = true;
            this.recaptchaTextBox.Name = "recaptchaTextBox";
            this.recaptchaTextBox.Size = new System.Drawing.Size(108, 28);
            this.recaptchaTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(86, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "验证码：";
            // 
            // recaptchaPictureBox
            // 
            this.recaptchaPictureBox.Location = new System.Drawing.Point(130, 282);
            this.recaptchaPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recaptchaPictureBox.Name = "recaptchaPictureBox";
            this.recaptchaPictureBox.Size = new System.Drawing.Size(134, 47);
            this.recaptchaPictureBox.TabIndex = 11;
            this.recaptchaPictureBox.TabStop = false;
            this.recaptchaPictureBox.Click += new System.EventHandler(this.recaptchaPictureBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(42, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "点击图片，\r\n更换下一张";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 438);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.recaptchaPictureBox);
            this.Controls.Add(this.recaptchaTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  陈俊杰温度监控登录窗体";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox userCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox recaptchaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox recaptchaPictureBox;
        private System.Windows.Forms.Label label6;
    }
}