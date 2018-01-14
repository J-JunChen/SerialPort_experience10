namespace 串口调试助手
{
    partial class searchDataBaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchDataBaseForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.placeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.standardTextBox = new System.Windows.Forms.TextBox();
            this.maxValueTextbox = new System.Windows.Forms.TextBox();
            this.minValuetextBox = new System.Windows.Forms.TextBox();
            this.averageTextBox = new System.Windows.Forms.TextBox();
            this.wholeLines = new System.Windows.Forms.TextBox();
            this.standardLabel = new System.Windows.Forms.Label();
            this.averageLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.wholeLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.saveExcelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(2, 16);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.Size = new System.Drawing.Size(931, 250);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(935, 268);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 268);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(935, 206);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Resize += new System.EventHandler(this.groupBox1_Resize);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.dateTimePickerFrom);
            this.groupBox5.Controls.Add(this.placeTextBox);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.dateTimePickerTo);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(64, 57);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(508, 91);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            this.groupBox5.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox5_Paint);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(110, 19);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(151, 21);
            this.dateTimePickerFrom.TabIndex = 12;
            // 
            // placeTextBox
            // 
            this.placeTextBox.Location = new System.Drawing.Point(240, 52);
            this.placeTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.placeTextBox.Name = "placeTextBox";
            this.placeTextBox.Size = new System.Drawing.Size(76, 21);
            this.placeTextBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "采样地点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "时间段：";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(279, 19);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(151, 21);
            this.dateTimePickerTo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(263, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "~";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.standardTextBox);
            this.groupBox4.Controls.Add(this.maxValueTextbox);
            this.groupBox4.Controls.Add(this.minValuetextBox);
            this.groupBox4.Controls.Add(this.averageTextBox);
            this.groupBox4.Controls.Add(this.wholeLines);
            this.groupBox4.Controls.Add(this.standardLabel);
            this.groupBox4.Controls.Add(this.averageLabel);
            this.groupBox4.Controls.Add(this.maxLabel);
            this.groupBox4.Controls.Add(this.minLabel);
            this.groupBox4.Controls.Add(this.wholeLabel);
            this.groupBox4.Location = new System.Drawing.Point(4, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(613, 60);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            this.groupBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox4_Paint);
            // 
            // standardTextBox
            // 
            this.standardTextBox.Location = new System.Drawing.Point(528, 21);
            this.standardTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.standardTextBox.Name = "standardTextBox";
            this.standardTextBox.ReadOnly = true;
            this.standardTextBox.Size = new System.Drawing.Size(66, 21);
            this.standardTextBox.TabIndex = 30;
            this.standardTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maxValueTextbox
            // 
            this.maxValueTextbox.Location = new System.Drawing.Point(191, 21);
            this.maxValueTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maxValueTextbox.Name = "maxValueTextbox";
            this.maxValueTextbox.ReadOnly = true;
            this.maxValueTextbox.Size = new System.Drawing.Size(55, 21);
            this.maxValueTextbox.TabIndex = 29;
            this.maxValueTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minValuetextBox
            // 
            this.minValuetextBox.Location = new System.Drawing.Point(299, 21);
            this.minValuetextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minValuetextBox.Name = "minValuetextBox";
            this.minValuetextBox.ReadOnly = true;
            this.minValuetextBox.Size = new System.Drawing.Size(57, 21);
            this.minValuetextBox.TabIndex = 28;
            this.minValuetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // averageTextBox
            // 
            this.averageTextBox.Location = new System.Drawing.Point(407, 21);
            this.averageTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.averageTextBox.Name = "averageTextBox";
            this.averageTextBox.ReadOnly = true;
            this.averageTextBox.Size = new System.Drawing.Size(70, 21);
            this.averageTextBox.TabIndex = 27;
            this.averageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wholeLines
            // 
            this.wholeLines.Location = new System.Drawing.Point(90, 21);
            this.wholeLines.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wholeLines.Name = "wholeLines";
            this.wholeLines.ReadOnly = true;
            this.wholeLines.Size = new System.Drawing.Size(52, 21);
            this.wholeLines.TabIndex = 26;
            this.wholeLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // standardLabel
            // 
            this.standardLabel.AutoSize = true;
            this.standardLabel.Location = new System.Drawing.Point(482, 25);
            this.standardLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.standardLabel.Name = "standardLabel";
            this.standardLabel.Size = new System.Drawing.Size(53, 12);
            this.standardLabel.TabIndex = 25;
            this.standardLabel.Text = "标准差：";
            // 
            // averageLabel
            // 
            this.averageLabel.AutoSize = true;
            this.averageLabel.Location = new System.Drawing.Point(362, 25);
            this.averageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.Size = new System.Drawing.Size(53, 12);
            this.averageLabel.TabIndex = 24;
            this.averageLabel.Text = "平均值：";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(147, 25);
            this.maxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(53, 12);
            this.maxLabel.TabIndex = 23;
            this.maxLabel.Text = "最大值：";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(254, 25);
            this.minLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(53, 12);
            this.minLabel.TabIndex = 22;
            this.minLabel.Text = "最小值：";
            // 
            // wholeLabel
            // 
            this.wholeLabel.AutoSize = true;
            this.wholeLabel.Location = new System.Drawing.Point(44, 25);
            this.wholeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wholeLabel.Name = "wholeLabel";
            this.wholeLabel.Size = new System.Drawing.Size(53, 12);
            this.wholeLabel.TabIndex = 21;
            this.wholeLabel.Text = "总行数：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.updateButton);
            this.groupBox3.Controls.Add(this.saveExcelButton);
            this.groupBox3.Location = new System.Drawing.Point(194, 142);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(268, 49);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateButton.Location = new System.Drawing.Point(24, 17);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(56, 30);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // saveExcelButton
            // 
            this.saveExcelButton.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveExcelButton.Location = new System.Drawing.Point(169, 18);
            this.saveExcelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveExcelButton.Name = "saveExcelButton";
            this.saveExcelButton.Size = new System.Drawing.Size(56, 30);
            this.saveExcelButton.TabIndex = 10;
            this.saveExcelButton.Text = "保存";
            this.saveExcelButton.UseVisualStyleBackColor = true;
            this.saveExcelButton.Click += new System.EventHandler(this.saveExcelButton_Click);
            // 
            // searchDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 474);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(662, 462);
            this.Name = "searchDataBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 查询温度界面";
            this.Load += new System.EventHandler(this.searchDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button saveExcelButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.TextBox placeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox standardTextBox;
        private System.Windows.Forms.TextBox maxValueTextbox;
        private System.Windows.Forms.TextBox minValuetextBox;
        private System.Windows.Forms.TextBox averageTextBox;
        private System.Windows.Forms.TextBox wholeLines;
        private System.Windows.Forms.Label standardLabel;
        private System.Windows.Forms.Label averageLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label wholeLabel;
    }
}