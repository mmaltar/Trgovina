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
    public partial class PasswordChange : Form
    {
        private User user;
        public PasswordChange(User user)
        {
            InitializeComponent();
            this.user = user;
        }


        private bool tbPassValidate()
        {
            bool bStatus = true;
            if (this.textBoxNewPass.Text == "")
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxNewPass, "Unesite lozinku");
                bStatus = false;
            }
            else if (this.textBoxNewPass.Text.Length < 3)
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxNewPass, "Za lozinku je potrebno minimalno 3 znaka");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxNewPass, "");
            }
            return bStatus;
        }
        private bool tbPassConfValidate()
        {
            bool bStatus = true;
            if (this.textBoxNewPassConf.Text != this.textBoxNewPassConf.Text)
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxNewPassConf, "Lozinke se ne podudaraju");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxNewPassConf, "");
            }
            return bStatus;
        }



        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void textBoxNewPassConf_Validating(object sender, CancelEventArgs e)
        {
            tbPassConfValidate();
        }

        private void textBoxNewPass_Validating(object sender, CancelEventArgs e)
        {
            tbPassValidate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool tbValPass = tbPassValidate();
            bool tbValPassConf = tbPassConfValidate();

            if (tbValPass && tbValPassConf)
            {

                user.ChangePassword(textBoxNewPass.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite ispravne podatke");
            }
        }
    }
}
