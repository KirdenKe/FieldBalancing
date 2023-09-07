using Windows.Devices.Enumeration;
using Windows.Devices.WiFiDirect;

namespace FeildBalancing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        Server server;
        string Account;
        string Password;
        List<Log> UserList = new List<Log>();
        List<Login> LoginCheck = new List<Login>();

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPage_FactoryStatus = new TabPage();
            label_details = new Label();
            textBox_LogTexts = new TextBox();
            label_FeildBalancingNo3 = new Label();
            pictureBox_FeildBalancingNo3 = new PictureBox();
            label_FeildBalancingNo2 = new Label();
            pictureBox_FeildBalancingNo2 = new PictureBox();
            label_FeildBalancingNo1 = new Label();
            pictureBox_FeildBalancingNo1 = new PictureBox();
            tabPage_StaffManagement = new TabPage();
            listBox_StaffList = new ListBox();
            label1 = new Label();
            button_ChangeWorkContent = new Button();
            button_RemoveStaff = new Button();
            button_NewStaff = new Button();
            tabPage_QueryLogFile = new TabPage();
            textBox_LogFile = new TextBox();
            button_SelectFile = new Button();
            tabControl.SuspendLayout();
            tabPage_FactoryStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo1).BeginInit();
            tabPage_StaffManagement.SuspendLayout();
            tabPage_QueryLogFile.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage_FactoryStatus);
            tabControl.Controls.Add(tabPage_StaffManagement);
            tabControl.Controls.Add(tabPage_QueryLogFile);
            tabControl.Enabled = false;
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 426);
            tabControl.TabIndex = 0;
            tabControl.Visible = false;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPage_FactoryStatus
            // 
            tabPage_FactoryStatus.BackColor = SystemColors.Control;
            tabPage_FactoryStatus.Controls.Add(label_details);
            tabPage_FactoryStatus.Controls.Add(textBox_LogTexts);
            tabPage_FactoryStatus.Controls.Add(label_FeildBalancingNo3);
            tabPage_FactoryStatus.Controls.Add(pictureBox_FeildBalancingNo3);
            tabPage_FactoryStatus.Controls.Add(label_FeildBalancingNo2);
            tabPage_FactoryStatus.Controls.Add(pictureBox_FeildBalancingNo2);
            tabPage_FactoryStatus.Controls.Add(label_FeildBalancingNo1);
            tabPage_FactoryStatus.Controls.Add(pictureBox_FeildBalancingNo1);
            tabPage_FactoryStatus.Location = new Point(4, 28);
            tabPage_FactoryStatus.Name = "tabPage_FactoryStatus";
            tabPage_FactoryStatus.Padding = new Padding(3);
            tabPage_FactoryStatus.Size = new Size(768, 394);
            tabPage_FactoryStatus.TabIndex = 0;
            tabPage_FactoryStatus.Text = "工廠現況";
            // 
            // label_details
            // 
            label_details.AutoSize = true;
            label_details.Location = new Point(6, 163);
            label_details.Name = "label_details";
            label_details.Size = new Size(69, 19);
            label_details.TabIndex = 7;
            label_details.Text = "詳細資訊";
            // 
            // textBox_LogTexts
            // 
            textBox_LogTexts.Location = new Point(6, 185);
            textBox_LogTexts.Multiline = true;
            textBox_LogTexts.Name = "textBox_LogTexts";
            textBox_LogTexts.ScrollBars = ScrollBars.Both;
            textBox_LogTexts.Size = new Size(756, 203);
            textBox_LogTexts.TabIndex = 6;
            // 
            // label_FeildBalancingNo3
            // 
            label_FeildBalancingNo3.AutoSize = true;
            label_FeildBalancingNo3.Location = new Point(321, 107);
            label_FeildBalancingNo3.Name = "label_FeildBalancingNo3";
            label_FeildBalancingNo3.Size = new Size(153, 19);
            label_FeildBalancingNo3.TabIndex = 5;
            label_FeildBalancingNo3.Text = "平衡校正機3：已離線";
            // 
            // pictureBox_FeildBalancingNo3
            // 
            pictureBox_FeildBalancingNo3.Image = Properties.Resources.control_system;
            pictureBox_FeildBalancingNo3.Location = new Point(321, 6);
            pictureBox_FeildBalancingNo3.Name = "pictureBox_FeildBalancingNo3";
            pictureBox_FeildBalancingNo3.Size = new Size(153, 98);
            pictureBox_FeildBalancingNo3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_FeildBalancingNo3.TabIndex = 4;
            pictureBox_FeildBalancingNo3.TabStop = false;
            // 
            // label_FeildBalancingNo2
            // 
            label_FeildBalancingNo2.AutoSize = true;
            label_FeildBalancingNo2.Location = new Point(162, 107);
            label_FeildBalancingNo2.Name = "label_FeildBalancingNo2";
            label_FeildBalancingNo2.Size = new Size(153, 19);
            label_FeildBalancingNo2.TabIndex = 3;
            label_FeildBalancingNo2.Text = "平衡校正機2：已離線";
            // 
            // pictureBox_FeildBalancingNo2
            // 
            pictureBox_FeildBalancingNo2.Image = Properties.Resources.control_system;
            pictureBox_FeildBalancingNo2.Location = new Point(162, 6);
            pictureBox_FeildBalancingNo2.Name = "pictureBox_FeildBalancingNo2";
            pictureBox_FeildBalancingNo2.Size = new Size(153, 98);
            pictureBox_FeildBalancingNo2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_FeildBalancingNo2.TabIndex = 2;
            pictureBox_FeildBalancingNo2.TabStop = false;
            // 
            // label_FeildBalancingNo1
            // 
            label_FeildBalancingNo1.AutoSize = true;
            label_FeildBalancingNo1.Location = new Point(3, 107);
            label_FeildBalancingNo1.Name = "label_FeildBalancingNo1";
            label_FeildBalancingNo1.Size = new Size(153, 19);
            label_FeildBalancingNo1.TabIndex = 1;
            label_FeildBalancingNo1.Text = "平衡校正機1：已離線";
            // 
            // pictureBox_FeildBalancingNo1
            // 
            pictureBox_FeildBalancingNo1.Image = Properties.Resources.control_system;
            pictureBox_FeildBalancingNo1.Location = new Point(3, 6);
            pictureBox_FeildBalancingNo1.Name = "pictureBox_FeildBalancingNo1";
            pictureBox_FeildBalancingNo1.Size = new Size(153, 98);
            pictureBox_FeildBalancingNo1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_FeildBalancingNo1.TabIndex = 0;
            pictureBox_FeildBalancingNo1.TabStop = false;
            // 
            // tabPage_StaffManagement
            // 
            tabPage_StaffManagement.BackColor = SystemColors.Control;
            tabPage_StaffManagement.Controls.Add(listBox_StaffList);
            tabPage_StaffManagement.Controls.Add(label1);
            tabPage_StaffManagement.Controls.Add(button_ChangeWorkContent);
            tabPage_StaffManagement.Controls.Add(button_RemoveStaff);
            tabPage_StaffManagement.Controls.Add(button_NewStaff);
            tabPage_StaffManagement.Location = new Point(4, 28);
            tabPage_StaffManagement.Name = "tabPage_StaffManagement";
            tabPage_StaffManagement.Padding = new Padding(3);
            tabPage_StaffManagement.Size = new Size(768, 394);
            tabPage_StaffManagement.TabIndex = 1;
            tabPage_StaffManagement.Text = "工作人員管理";
            // 
            // listBox_StaffList
            // 
            listBox_StaffList.FormattingEnabled = true;
            listBox_StaffList.HorizontalScrollbar = true;
            listBox_StaffList.ItemHeight = 19;
            listBox_StaffList.Location = new Point(106, 28);
            listBox_StaffList.Name = "listBox_StaffList";
            listBox_StaffList.SelectionMode = SelectionMode.MultiSimple;
            listBox_StaffList.Size = new Size(656, 346);
            listBox_StaffList.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 6);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 3;
            label1.Text = "總覽";
            // 
            // button_ChangeWorkContent
            // 
            button_ChangeWorkContent.Location = new Point(6, 134);
            button_ChangeWorkContent.Name = "button_ChangeWorkContent";
            button_ChangeWorkContent.Size = new Size(94, 58);
            button_ChangeWorkContent.TabIndex = 2;
            button_ChangeWorkContent.Text = "變更";
            button_ChangeWorkContent.UseVisualStyleBackColor = true;
            button_ChangeWorkContent.Click += button_ChangeWorkContent_Click;
            // 
            // button_RemoveStaff
            // 
            button_RemoveStaff.Location = new Point(6, 70);
            button_RemoveStaff.Name = "button_RemoveStaff";
            button_RemoveStaff.Size = new Size(94, 58);
            button_RemoveStaff.TabIndex = 1;
            button_RemoveStaff.Text = "刪除";
            button_RemoveStaff.UseVisualStyleBackColor = true;
            button_RemoveStaff.Click += button_RemoveStaff_Click;
            // 
            // button_NewStaff
            // 
            button_NewStaff.Location = new Point(6, 6);
            button_NewStaff.Name = "button_NewStaff";
            button_NewStaff.Size = new Size(94, 58);
            button_NewStaff.TabIndex = 0;
            button_NewStaff.Text = "新增";
            button_NewStaff.UseVisualStyleBackColor = true;
            button_NewStaff.Click += button_NewStaff_Click;
            // 
            // tabPage_QueryLogFile
            // 
            tabPage_QueryLogFile.BackColor = SystemColors.Control;
            tabPage_QueryLogFile.Controls.Add(textBox_LogFile);
            tabPage_QueryLogFile.Controls.Add(button_SelectFile);
            tabPage_QueryLogFile.Location = new Point(4, 28);
            tabPage_QueryLogFile.Name = "tabPage_QueryLogFile";
            tabPage_QueryLogFile.Size = new Size(768, 394);
            tabPage_QueryLogFile.TabIndex = 2;
            tabPage_QueryLogFile.Text = "記錄檔查詢";
            // 
            // textBox_LogFile
            // 
            textBox_LogFile.Location = new Point(103, 3);
            textBox_LogFile.Multiline = true;
            textBox_LogFile.Name = "textBox_LogFile";
            textBox_LogFile.ScrollBars = ScrollBars.Both;
            textBox_LogFile.Size = new Size(665, 388);
            textBox_LogFile.TabIndex = 1;
            // 
            // button_SelectFile
            // 
            button_SelectFile.Location = new Point(3, 3);
            button_SelectFile.Name = "button_SelectFile";
            button_SelectFile.Size = new Size(94, 58);
            button_SelectFile.TabIndex = 0;
            button_SelectFile.Text = "選擇檔案";
            button_SelectFile.UseVisualStyleBackColor = true;
            button_SelectFile.Click += button_SelectFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "Form1";
            Text = "系統管理員";
            FormClosed += Form1_FormClosed;
            tabControl.ResumeLayout(false);
            tabPage_FactoryStatus.ResumeLayout(false);
            tabPage_FactoryStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FeildBalancingNo1).EndInit();
            tabPage_StaffManagement.ResumeLayout(false);
            tabPage_StaffManagement.PerformLayout();
            tabPage_QueryLogFile.ResumeLayout(false);
            tabPage_QueryLogFile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage_FactoryStatus;
        private TabPage tabPage_StaffManagement;
        private Button button_RemoveStaff;
        private Button button_NewStaff;
        private ListBox listBox_StaffList;
        private Label label1;
        private Button button_ChangeWorkContent;
        private PictureBox pictureBox_FeildBalancingNo1;
        private Label label_details;
        private TextBox textBox_LogTexts;
        private Label label_FeildBalancingNo3;
        private PictureBox pictureBox_FeildBalancingNo3;
        private Label label_FeildBalancingNo2;
        private PictureBox pictureBox_FeildBalancingNo2;
        private Label label_FeildBalancingNo1;
        private TabPage tabPage_QueryLogFile;
        private TextBox textBox_LogFile;
        private Button button_SelectFile;
    }
}