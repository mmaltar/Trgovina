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
    public partial class UserForm : Form
    {
        private User user;
        bool isEditMode = false;
        bool isSelfUpdate;


        public UserForm(User user = null, bool isSelfUpdate = false)
        {
            InitializeComponent();

            comboBoxUserFormRole.DataSource = System.Enum.GetValues(typeof(Role));
            comboBoxUserFormRole.SelectedItem = (Role) 2;
            this.user = user;
            this.isSelfUpdate = isSelfUpdate;
            if (this.user != null && !isSelfUpdate)
            {
                SetEditMode();
            }

            if (this.isSelfUpdate)
            {
                SetSelfUpdateMode();
            }
        }


        private bool tbNameValidate()
        {
            bool bStatus = true;
            if (this.textBoxUserFormName.Text == "")
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormName, "Unesite ime");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxUserFormName, "");
            }
            return bStatus;
        }

        private bool tbLastNameValidate()
        {
            bool bStatus = true;
            if (this.textBoxUserFormLastName.Text == "")
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormLastName, "Unesite prezime");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxUserFormLastName, "");
            }
            return bStatus;
        }

        private bool tbUsernameValidate()
        {
            bool bStatus = true;
            if (this.textBoxUserFormUsername.Text == "")
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormUsername, "Unesite username");
                bStatus = false;
            }
            else if (this.textBoxUserFormUsername.Text.Length < 3)
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormUsername, "Za username je potrebno minimalno 3 znaka");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxUserFormUsername, "");
            }
            return bStatus;
        }
        private bool tbPassValidate()
        {
            bool bStatus = true;
            if (this.textBoxUserFormPassword.Text== "")
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormPassword, "Unesite lozinku");
                bStatus = false;
            }
            else if (this.textBoxUserFormPassword.Text.Length < 3)
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormPassword, "Za lozinku je potrebno minimalno 3 znaka");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxUserFormPassword, "");
            }
            return bStatus;
        }
        private bool tbPassConfValidate()
        {
            bool bStatus = true;
            if (this.textBoxUserFormPassword.Text != this.textBoxUserFormPassConf.Text)
            {
                Console.WriteLine("if");
                errorProvider1.SetError(this.textBoxUserFormPassConf, "Lozinke se ne podudaraju");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProvider1.SetError(this.textBoxUserFormPassConf, "");
            }
            return bStatus;
        }

        private void textBoxUserFormName_Validating(object sender, CancelEventArgs e)
        {
            tbNameValidate();
        }

        private void textBoxUserFormLastName_Validating(object sender, CancelEventArgs e)
        {
            tbLastNameValidate();
        }

        private void textBoxUserFormUsername_Validating(object sender, CancelEventArgs e)
        {
            tbUsernameValidate();
        }

        private void textBoxUserFormPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!isEditMode)
            {
                tbPassValidate();
            }
            
        }

        private void textBoxUserFormPassConf_Validating(object sender, CancelEventArgs e)
        {
            if (!isEditMode)
            {
                tbPassConfValidate();
            }
        }

        private void buttonUserFormCreate_Click(object sender, EventArgs e)
        {
            bool tbValName = tbNameValidate();
            bool tbValLastName = tbLastNameValidate();
            bool tbValUsername = tbUsernameValidate();
            bool tbValPass = tbPassValidate();
            bool tbValPassConf = tbPassConfValidate();
            Console.WriteLine("{0}", (int)comboBoxUserFormRole.SelectedItem);
            if (tbValName && tbValLastName && tbValUsername && tbValPass && tbValPassConf)
            {
                User.Create(textBoxUserFormName.Text, radioButtonUserFormActive.Checked ? 1 : 0, textBoxUserFormLastName.Text, textBoxUserFormUsername.Text, textBoxUserFormPassword.Text, (int)comboBoxUserFormRole.SelectedItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Unesite ispravne podatke");
            }
        }
        private void SetEditMode()
        {
            textBoxUserFormName.Text = this.user.Ime;
            textBoxUserFormLastName.Text = this.user.Prezime;
            textBoxUserFormUsername.Text = this.user.Username;
            textBoxUserFormUsername.Enabled = false;
            textBoxUserFormPassword.Visible = false;
            textBoxUserFormPassConf.Visible = false;
            labelUserFormPassword.Visible = false;
            labelUserFormConfirmPass.Visible = false;
            labelUserFormStatus.Location = new Point(30,238);
            radioButtonUserFormActive.Location = new Point(155,238);
            radioButtonUserFormInactive.Location = new Point(302, 238);
            radioButtonUserFormActive.Checked = this.user.Active == 1 ? true : false;
            radioButtonUserFormInactive.Checked = this.user.Active == 0 ? true : false;
            buttonUserFormSave.Location = new Point(318, 288);
            buttonUserFormSave.Visible = true;
            buttonUserFormCreate.Visible = false;
            buttonUserFormCancle.Location = new Point(211, 288);
            comboBoxUserFormRole.SelectedItem = user.Rola;
            this.Size = new Size(462, 408);
            this.isEditMode = true;
            this.Text = "Korisnik: " + this.user.Ime + " " + this.user.Prezime;
        }

        private void SetSelfUpdateMode()
        {
            textBoxUserFormName.Text = this.user.Ime;
            textBoxUserFormLastName.Text = this.user.Prezime;

            textBoxUserFormUsername.Visible = false;
            labelUserFormUsername.Visible = false;

            textBoxUserFormPassword.Visible = false;
            labelUserFormPassword.Visible = false;

            textBoxUserFormPassConf.Visible = false;
            labelUserFormConfirmPass.Visible = false;

            labelUserFormStatus.Visible = false;
            radioButtonUserFormActive.Visible = false;
            radioButtonUserFormInactive.Visible = false;

            labelUserFormRole.Visible = false;
            comboBoxUserFormRole.Visible = false;

            buttonUserFormCreate.Visible = false;

            buttonUserFormSave.Visible = true;
            buttonUserFormSave.Location = new Point(318, 154);
            buttonUserFormCancle.Location = new Point(211, 154);
            this.Size = new Size(462, 270);

            this.isEditMode = true;
            this.Text = "Korisnik: "+this.user.Ime+" "+this.user.Prezime;
        }

        private void buttonUserFormCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonUserFormSave_Click(object sender, EventArgs e)
        {
            bool tbValName = tbNameValidate();
            bool tbValLastName = tbLastNameValidate();
          
            if (tbValName && tbValLastName)
            {

                user.Ime = textBoxUserFormName.Text;
                user.Prezime = textBoxUserFormLastName.Text;
                if (isEditMode && !isSelfUpdate)
                {
                    user.Active = radioButtonUserFormActive.Checked ? 1 : 0;
                    user.Rola = (Role)comboBoxUserFormRole.SelectedItem;
                }
                
                user.Save();
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
