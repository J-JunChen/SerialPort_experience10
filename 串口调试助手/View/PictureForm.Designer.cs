namespace 串口调试助手
{
    partial class PictureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.picturComboBox = new System.Windows.Forms.ComboBox();
            this.pictureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(14, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(570, 570);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // picturComboBox
            // 
            this.picturComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.picturComboBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.picturComboBox.FormattingEnabled = true;
            this.picturComboBox.Location = new System.Drawing.Point(177, 601);
            this.picturComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picturComboBox.Name = "picturComboBox";
            this.picturComboBox.Size = new System.Drawing.Size(350, 29);
            this.picturComboBox.TabIndex = 5;
            // 
            // pictureButton
            // 
            this.pictureButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pictureButton.Location = new System.Drawing.Point(54, 596);
            this.pictureButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureButton.Name = "pictureButton";
            this.pictureButton.Size = new System.Drawing.Size(78, 41);
            this.pictureButton.TabIndex = 4;
            this.pictureButton.Text = "选择图片";
            this.pictureButton.UseVisualStyleBackColor = true;
            this.pictureButton.Click += new System.EventHandler(this.pictureButton_Click);
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 657);
            this.Controls.Add(this.picturComboBox);
            this.Controls.Add(this.pictureButton);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 572);
            this.Name = "PictureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  温度图查看窗体";
            this.Load += new System.EventHandler(this.PictureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox picturComboBox;
        private System.Windows.Forms.Button pictureButton;
    }
}