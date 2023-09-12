using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeildBalancing
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(bool LoginOnceCheck)
        {
            InitializeComponent();
            administrator = new Administrator();
            isLoginOnce = LoginOnceCheck;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            administrator = new Administrator(textBox_account.Text, textBox_password.Text);
            if (!isLoginOnce)
            {
                if (administrator.AllowLogin)
                {
                    //成功登入後該做的事
                    if (LoginHandler != null)
                    {
                        var localLoginHandler = new EventHandler<LoginArgs>(LoginHandler);
                        var ar = new LoginArgs(textBox_account.Text, textBox_password.Text);
                        localLoginHandler?.Invoke(this, ar);
                    }
                }
                else
                    MessageBox.Show("登入失敗！");
            }
            else
            {
                if (LoginHandler != null)
                {
                    var localLoginHandler = new EventHandler<LoginArgs>(LoginHandler);
                    var ar = new LoginArgs(textBox_account.Text, textBox_password.Text);
                    localLoginHandler?.Invoke(this, ar);
                }
                if (!administrator.AllowLogin)
                    MessageBox.Show("登入失敗！");
            }
            if (!isLoginOnce)
                Close();
            if (isLoginOnce && administrator.AllowLogin)
                Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLoginOnce && !administrator.AllowLogin)
            {
                if (LockHandler != null)
                {
                    var localLockHandler = new EventHandler<LockArgs>(LockHandler);
                    var ar = new LockArgs();
                    localLockHandler?.Invoke(this, ar);
                }
            }
        }
        public void TruelyClosed()
        {
            isLoginOnce = false;
            Close();
        }
    }
}
