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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }
        public StaffForm(string name, string iD, string account, string password, string allowedMachine)
        {
            InitializeComponent();
            textBox_name.Text = name;
            textBox_ID.Text = iD;
            textBox_account.Text = account;
            textBox_password.Text = password;
            if (allowedMachine.Contains(Machine.FieldBalancing.ToString()))
            {
                isFeildBalancingCilck = true;
                button_FieldBalancing.BackColor = Color.Green;
            }
            if (allowedMachine.Contains(Machine.etc.ToString()))
            {
                isetcCilck = true;
                button_etc.BackColor = Color.Green;
            }
        }

        private void button_FieldBalancing_Click(object sender, EventArgs e)
        {
            if (isFeildBalancingCilck == false)
            {
                isFeildBalancingCilck = true;
                button_FieldBalancing.BackColor = Color.Green;
            }
            else
            {
                isFeildBalancingCilck = false;
                button_FieldBalancing.BackColor = Control.DefaultBackColor;
            }
        }

        private void button_etc_Click(object sender, EventArgs e)
        {
            if (isetcCilck == false)
            {
                isetcCilck = true;
                button_etc.BackColor = Color.Green;
            }
            else
            {
                isetcCilck = false;
                button_etc.BackColor = Control.DefaultBackColor;
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            _Staff = new Staff();
            List<Object> allowedMachine = new List<Object>();
            if (isFeildBalancingCilck)
                allowedMachine.Add(Machine.FieldBalancing);
            if (isetcCilck)
                allowedMachine.Add(Machine.etc);
            if (String.IsNullOrEmpty(textBox_name.Text) || String.IsNullOrEmpty(textBox_ID.Text) || String.IsNullOrEmpty(textBox_account.Text) || String.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("請填寫所有欄位");
                return;
            }
            var staff = new Staff(textBox_name.Text, textBox_ID.Text, textBox_account.Text, textBox_password.Text, allowedMachine);
            _Staff = staff;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
