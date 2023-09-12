namespace FeildBalancing
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private static Administrator administrator;
        public event EventHandler<LoginArgs> LoginHandler = delegate { };
        public event EventHandler<LockArgs> LockHandler = delegate { };
        bool isLoginOnce = false;

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
            textBox_account = new TextBox();
            textBox_password = new TextBox();
            label2 = new Label();
            button_login = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 0;
            label1.Text = "帳號";
            // 
            // textBox_account
            // 
            textBox_account.Location = new Point(57, 12);
            textBox_account.Name = "textBox_account";
            textBox_account.Size = new Size(125, 27);
            textBox_account.TabIndex = 1;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(57, 45);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(125, 27);
            textBox_password.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(39, 19);
            label2.TabIndex = 3;
            label2.Text = "密碼";
            // 
            // button_login
            // 
            button_login.Location = new Point(12, 78);
            button_login.Name = "button_login";
            button_login.Size = new Size(94, 58);
            button_login.TabIndex = 4;
            button_login.Text = "登入";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_login);
            Controls.Add(label2);
            Controls.Add(textBox_password);
            Controls.Add(textBox_account);
            Controls.Add(label1);
            Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "Form2";
            Text = "請先登入";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_account;
        private TextBox textBox_password;
        private Label label2;
        private Button button_login;
    }
}