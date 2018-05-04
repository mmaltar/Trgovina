using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trgovina
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void login_button_Click(object sender, EventArgs e)
        {
            User userList = User.UserLogin(login_username.Text, Crypto.GetHashString(login_pass.Text));
            bool develop = true;
            Console.WriteLine(Crypto.GetHashString(login_pass.Text));
            if (userList != null)
            {
              
                Program.Username = login_username.Text;
                this.Hide();
                MainForm mainForm = new MainForm(userList);
                DialogResult dr = (DialogResult) mainForm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    login_pass.Text = "";
                    login_username.Text = "";
                    this.Show();
                }
              
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
                login_username.Clear();
                login_pass.Clear();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_button_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_button_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
