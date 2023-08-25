namespace FeildBalancing
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        bool isFeildBalancingCilck = false;
        bool isetcCilck = false;
        public static Staff _Staff;

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
            label1 = new Label();
            textBox_name = new TextBox();
            label2 = new Label();
            textBox_ID = new TextBox();
            label3 = new Label();
            textBox_account = new TextBox();
            label4 = new Label();
            textBox_password = new TextBox();
            label5 = new Label();
            button_FieldBalancing = new Button();
            button_etc = new Button();
            button_confirm = new Button();
            button_cancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 0;
            label1.Text = "名字";
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(12, 31);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(125, 27);
            textBox_name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(143, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 2;
            label2.Text = "身分證字號";
            // 
            // textBox_ID
            // 
            textBox_ID.Location = new Point(143, 31);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Size = new Size(125, 27);
            textBox_ID.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(39, 19);
            label3.TabIndex = 4;
            label3.Text = "帳號";
            // 
            // textBox_account
            // 
            textBox_account.Location = new Point(12, 83);
            textBox_account.Name = "textBox_account";
            textBox_account.Size = new Size(125, 27);
            textBox_account.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 61);
            label4.Name = "label4";
            label4.Size = new Size(39, 19);
            label4.TabIndex = 6;
            label4.Text = "密碼";
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(143, 83);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(125, 27);
            textBox_password.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 113);
            label5.Name = "label5";
            label5.Size = new Size(99, 19);
            label5.TabIndex = 8;
            label5.Text = "允許使用機台";
            // 
            // button_FieldBalancing
            // 
            button_FieldBalancing.BackColor = SystemColors.Control;
            button_FieldBalancing.BackgroundImage = Properties.Resources.control_system;
            button_FieldBalancing.BackgroundImageLayout = ImageLayout.Zoom;
            button_FieldBalancing.Location = new Point(12, 135);
            button_FieldBalancing.Name = "button_FieldBalancing";
            button_FieldBalancing.Size = new Size(125, 119);
            button_FieldBalancing.TabIndex = 9;
            button_FieldBalancing.Text = " ";
            button_FieldBalancing.UseVisualStyleBackColor = false;
            button_FieldBalancing.Click += button_FieldBalancing_Click;
            // 
            // button_etc
            // 
            button_etc.BackColor = SystemColors.Control;
            button_etc.BackgroundImageLayout = ImageLayout.Zoom;
            button_etc.Location = new Point(143, 135);
            button_etc.Name = "button_etc";
            button_etc.Size = new Size(125, 119);
            button_etc.TabIndex = 10;
            button_etc.Text = "etc";
            button_etc.UseVisualStyleBackColor = false;
            button_etc.Click += button_etc_Click;
            // 
            // button_confirm
            // 
            button_confirm.Location = new Point(12, 313);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(125, 77);
            button_confirm.TabIndex = 11;
            button_confirm.Text = "確定";
            button_confirm.UseVisualStyleBackColor = true;
            button_confirm.Click += button_confirm_Click;
            // 
            // button_cancel
            // 
            button_cancel.Location = new Point(143, 313);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(125, 77);
            button_cancel.TabIndex = 12;
            button_cancel.Text = "取消";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_cancel);
            Controls.Add(button_confirm);
            Controls.Add(button_etc);
            Controls.Add(button_FieldBalancing);
            Controls.Add(label5);
            Controls.Add(textBox_password);
            Controls.Add(label4);
            Controls.Add(textBox_account);
            Controls.Add(label3);
            Controls.Add(textBox_ID);
            Controls.Add(label2);
            Controls.Add(textBox_name);
            Controls.Add(label1);
            Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_name;
        private Label label2;
        private TextBox textBox_ID;
        private Label label3;
        private TextBox textBox_account;
        private Label label4;
        private TextBox textBox_password;
        private Label label5;
        private Button button_FieldBalancing;
        private Button button_etc;
        private Button button_confirm;
        private Button button_cancel;
    }
}