namespace Planner.Forms
{
    partial class FormAdmin
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
            this.DescriptionTask = new MetroFramework.Controls.MetroLabel();
            this.TextDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.FieldName = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.FIOWorker = new MetroFramework.Controls.MetroComboBox();
            this.AddTask = new MetroFramework.Controls.MetroButton();
            this.seeTasks = new MetroFramework.Controls.MetroButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // DescriptionTask
            // 
            this.DescriptionTask.AutoSize = true;
            this.DescriptionTask.Location = new System.Drawing.Point(31, 74);
            this.DescriptionTask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionTask.Name = "DescriptionTask";
            this.DescriptionTask.Size = new System.Drawing.Size(118, 19);
            this.DescriptionTask.TabIndex = 0;
            this.DescriptionTask.Text = "Описание задачи";
            // 
            // TextDescription
            // 
            // 
            // 
            // 
            this.TextDescription.CustomButton.Image = null;
            this.TextDescription.CustomButton.Location = new System.Drawing.Point(152, 2);
            this.TextDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.TextDescription.CustomButton.Name = "";
            this.TextDescription.CustomButton.Size = new System.Drawing.Size(101, 101);
            this.TextDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextDescription.CustomButton.TabIndex = 1;
            this.TextDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextDescription.CustomButton.UseSelectable = true;
            this.TextDescription.CustomButton.Visible = false;
            this.TextDescription.Lines = new string[0];
            this.TextDescription.Location = new System.Drawing.Point(157, 78);
            this.TextDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TextDescription.MaxLength = 32767;
            this.TextDescription.Multiline = true;
            this.TextDescription.Name = "TextDescription";
            this.TextDescription.PasswordChar = '\0';
            this.TextDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextDescription.SelectedText = "";
            this.TextDescription.SelectionLength = 0;
            this.TextDescription.SelectionStart = 0;
            this.TextDescription.ShortcutsEnabled = true;
            this.TextDescription.Size = new System.Drawing.Size(256, 106);
            this.TextDescription.TabIndex = 1;
            this.TextDescription.UseSelectable = true;
            this.TextDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(101, 193);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Сроки";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(157, 192);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 30);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 223);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Название стадиона";
            // 
            // FieldName
            // 
            this.FieldName.FormattingEnabled = true;
            this.FieldName.ItemHeight = 23;
            this.FieldName.Location = new System.Drawing.Point(157, 218);
            this.FieldName.Name = "FieldName";
            this.FieldName.Size = new System.Drawing.Size(256, 29);
            this.FieldName.TabIndex = 5;
            this.FieldName.UseSelectable = true;
            this.FieldName.SelectedIndexChanged += new System.EventHandler(this.FieldName_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(40, 256);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(109, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "ФИО работника";
            // 
            // FIOWorker
            // 
            this.FIOWorker.FormattingEnabled = true;
            this.FIOWorker.ItemHeight = 23;
            this.FIOWorker.Location = new System.Drawing.Point(157, 253);
            this.FIOWorker.Name = "FIOWorker";
            this.FIOWorker.Size = new System.Drawing.Size(256, 29);
            this.FIOWorker.TabIndex = 7;
            this.FIOWorker.UseSelectable = true;
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(288, 288);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(125, 26);
            this.AddTask.TabIndex = 8;
            this.AddTask.Text = "Добавить задачу";
            this.AddTask.UseSelectable = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // seeTasks
            // 
            this.seeTasks.Location = new System.Drawing.Point(293, 48);
            this.seeTasks.Name = "seeTasks";
            this.seeTasks.Size = new System.Drawing.Size(120, 23);
            this.seeTasks.TabIndex = 9;
            this.seeTasks.Text = "Посмотреть задачи";
            this.seeTasks.UseSelectable = true;
            this.seeTasks.Click += new System.EventHandler(this.seeTasks_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(293, 192);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 30);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(157, 288);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(125, 26);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Text = "Склад";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.seeTasks);
            this.Controls.Add(this.AddTask);
            this.Controls.Add(this.FIOWorker);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.FieldName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.TextDescription);
            this.Controls.Add(this.DescriptionTask);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(430, 330);
            this.MinimumSize = new System.Drawing.Size(430, 330);
            this.Name = "FormAdmin";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "FormAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel DescriptionTask;
        public MetroFramework.Controls.MetroTextBox TextDescription;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox FieldName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox FIOWorker;
        private MetroFramework.Controls.MetroButton AddTask;
        private MetroFramework.Controls.MetroButton seeTasks;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}