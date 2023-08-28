using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button_login_Click(object sender, EventArgs e)
        {
            var administrator = new Administrator(textBox_account.Text, textBox_password.Text);
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
            Close();
        }
    }
}
