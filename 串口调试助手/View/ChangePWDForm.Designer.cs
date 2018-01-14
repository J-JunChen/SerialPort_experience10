namespace 串口调试助手
{
    partial class ChangePWDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePWDForm));
            this.oldPWDTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newPWDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newPWDTextBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // oldPWDTextbox
            // 
            this.oldPWDTextbox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.oldPWDTextbox.Location = new System.Drawing.Point(202, 89);
            this.oldPWDTextbox.Multiline = true;
            this.oldPWDTextbox.Name = "oldPWDTextbox";
            this.oldPWDTextbox.PasswordChar = '*';
            this.oldPWDTextbox.Size = new System.Drawing.Size(143, 34);
            this.oldPWDTextbox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(114, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "原密码：";
            // 
            // newPWDTextBox
            // 
            this.newPWDTextBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newPWDTextBox.Location = new System.Drawing.Point(202, 161);
            this.newPWDTextBox.Multiline = true;
            this.newPWDTextBox.Name = "newPWDTextBox";
            this.newPWDTextBox.PasswordChar = '*';
            this.newPWDTextBox.Size = new System.Drawing.Size(143, 34);
            this.newPWDTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(114, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "新密码：";
            // 
            // newPWDTextBox2
            // 
            this.newPWDTextBox2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newPWDTextBox2.Location = new System.Drawing.Point(202, 235);
            this.newPWDTextBox2.Multiline = true;
            this.newPWDTextBox2.Name = "newPWDTextBox2";
            this.newPWDTextBox2.PasswordChar = '*';
            this.newPWDTextBox2.Size = new System.Drawing.Size(143, 34);
            this.newPWDTextBox2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(94, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "确认密码：";
            // 
            // changeButton
            // 
            this.changeButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changeButton.Location = new System.Drawing.Point(110, 327);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(85, 44);
            this.changeButton.TabIndex = 10;
            this.changeButton.Text = "修改";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelButton.Location = new System.Drawing.Point(260, 327);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 44);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "密码修改";
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userNameTextbox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameTextbox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.userNameTextbox.Location = new System.Drawing.Point(29, 41);
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.ReadOnly = true;
            this.userNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.userNameTextbox.TabIndex = 13;
            this.userNameTextbox.Text = "userName";
            // 
            // ChangePWDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 413);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.newPWDTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newPWDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldPWDTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePWDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  修改密码窗体";
            this.Load += new System.EventHandler(this.ChangePWDForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox oldPWDTextbox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox newPWDTextBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox newPWDTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userNameTextbox;
    }
}