namespace Trgovina
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.labelUserFormName = new System.Windows.Forms.Label();
            this.labelUserFormLastName = new System.Windows.Forms.Label();
            this.labelUserFormUsername = new System.Windows.Forms.Label();
            this.labelUserFormPassword = new System.Windows.Forms.Label();
            this.labelUserFormRole = new System.Windows.Forms.Label();
            this.textBoxUserFormName = new System.Windows.Forms.TextBox();
            this.textBoxUserFormLastName = new System.Windows.Forms.TextBox();
            this.textBoxUserFormUsername = new System.Windows.Forms.TextBox();
            this.comboBoxUserFormRole = new System.Windows.Forms.ComboBox();
            this.textBoxUserFormPassword = new System.Windows.Forms.TextBox();
            this.buttonUserFormCreate = new System.Windows.Forms.Button();
            this.labelUserFormConfirmPass = new System.Windows.Forms.Label();
            this.textBoxUserFormPassConf = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radioButtonUserFormActive = new System.Windows.Forms.RadioButton();
            this.labelUserFormStatus = new System.Windows.Forms.Label();
            this.radioButtonUserFormInactive = new System.Windows.Forms.RadioButton();
            this.buttonUserFormSave = new System.Windows.Forms.Button();
            this.buttonUserFormCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserFormName
            // 
            this.labelUserFormName.AutoSize = true;
            this.labelUserFormName.Location = new System.Drawing.Point(30, 54);
            this.labelUserFormName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserFormName.Name = "labelUserFormName";
            this.labelUserFormName.Size = new System.Drawing.Size(37, 19);
            this.labelUserFormName.TabIndex = 0;
            this.labelUserFormName.Text = "Ime:";
            // 
            // labelUserFormLastName
            // 
            this.labelUserFormLastName.AutoSize = true;
            this.labelUserFormLastName.Location = new System.Drawing.Point(30, 100);
            this.labelUserFormLastName.Name = "labelUserFormLastName";
            this.labelUserFormLastName.Size = new System.Drawing.Size(64, 19);
            this.labelUserFormLastName.TabIndex = 1;
            this.labelUserFormLastName.Text = "Prezime:";
            // 
            // labelUserFormUsername
            // 
            this.labelUserFormUsername.AutoSize = true;
            this.labelUserFormUsername.Location = new System.Drawing.Point(30, 146);
            this.labelUserFormUsername.Name = "labelUserFormUsername";
            this.labelUserFormUsername.Size = new System.Drawing.Size(106, 19);
            this.labelUserFormUsername.TabIndex = 2;
            this.labelUserFormUsername.Text = "Korisničko ime:";
            // 
            // labelUserFormPassword
            // 
            this.labelUserFormPassword.AutoSize = true;
            this.labelUserFormPassword.Location = new System.Drawing.Point(30, 238);
            this.labelUserFormPassword.Name = "labelUserFormPassword";
            this.labelUserFormPassword.Size = new System.Drawing.Size(61, 19);
            this.labelUserFormPassword.TabIndex = 3;
            this.labelUserFormPassword.Text = "Lozinka:";
            // 
            // labelUserFormRole
            // 
            this.labelUserFormRole.AutoSize = true;
            this.labelUserFormRole.Location = new System.Drawing.Point(30, 192);
            this.labelUserFormRole.Name = "labelUserFormRole";
            this.labelUserFormRole.Size = new System.Drawing.Size(42, 19);
            this.labelUserFormRole.TabIndex = 4;
            this.labelUserFormRole.Text = "Rola:";
            // 
            // textBoxUserFormName
            // 
            this.textBoxUserFormName.Location = new System.Drawing.Point(154, 51);
            this.textBoxUserFormName.Name = "textBoxUserFormName";
            this.textBoxUserFormName.Size = new System.Drawing.Size(239, 27);
            this.textBoxUserFormName.TabIndex = 1;
            this.textBoxUserFormName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFormName_Validating);
            // 
            // textBoxUserFormLastName
            // 
            this.textBoxUserFormLastName.Location = new System.Drawing.Point(154, 97);
            this.textBoxUserFormLastName.Name = "textBoxUserFormLastName";
            this.textBoxUserFormLastName.Size = new System.Drawing.Size(239, 27);
            this.textBoxUserFormLastName.TabIndex = 2;
            this.textBoxUserFormLastName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFormLastName_Validating);
            // 
            // textBoxUserFormUsername
            // 
            this.textBoxUserFormUsername.Location = new System.Drawing.Point(154, 143);
            this.textBoxUserFormUsername.Name = "textBoxUserFormUsername";
            this.textBoxUserFormUsername.Size = new System.Drawing.Size(239, 27);
            this.textBoxUserFormUsername.TabIndex = 3;
            this.textBoxUserFormUsername.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFormUsername_Validating);
            // 
            // comboBoxUserFormRole
            // 
            this.comboBoxUserFormRole.FormattingEnabled = true;
            this.comboBoxUserFormRole.Location = new System.Drawing.Point(154, 189);
            this.comboBoxUserFormRole.Name = "comboBoxUserFormRole";
            this.comboBoxUserFormRole.Size = new System.Drawing.Size(239, 27);
            this.comboBoxUserFormRole.TabIndex = 6;
            // 
            // textBoxUserFormPassword
            // 
            this.textBoxUserFormPassword.Location = new System.Drawing.Point(154, 235);
            this.textBoxUserFormPassword.Name = "textBoxUserFormPassword";
            this.textBoxUserFormPassword.Size = new System.Drawing.Size(239, 27);
            this.textBoxUserFormPassword.TabIndex = 4;
            this.textBoxUserFormPassword.UseSystemPasswordChar = true;
            this.textBoxUserFormPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFormPassword_Validating);
            // 
            // buttonUserFormCreate
            // 
            this.buttonUserFormCreate.BackColor = System.Drawing.Color.DarkRed;
            this.buttonUserFormCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonUserFormCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormCreate.ForeColor = System.Drawing.Color.White;
            this.buttonUserFormCreate.Location = new System.Drawing.Point(318, 379);
            this.buttonUserFormCreate.Name = "buttonUserFormCreate";
            this.buttonUserFormCreate.Size = new System.Drawing.Size(75, 29);
            this.buttonUserFormCreate.TabIndex = 7;
            this.buttonUserFormCreate.Text = "Kreiraj";
            this.buttonUserFormCreate.UseVisualStyleBackColor = false;
            this.buttonUserFormCreate.Click += new System.EventHandler(this.buttonUserFormCreate_Click);
            // 
            // labelUserFormConfirmPass
            // 
            this.labelUserFormConfirmPass.AutoSize = true;
            this.labelUserFormConfirmPass.Location = new System.Drawing.Point(30, 284);
            this.labelUserFormConfirmPass.Name = "labelUserFormConfirmPass";
            this.labelUserFormConfirmPass.Size = new System.Drawing.Size(107, 19);
            this.labelUserFormConfirmPass.TabIndex = 11;
            this.labelUserFormConfirmPass.Text = "Potvrdi lozinku:";
            // 
            // textBoxUserFormPassConf
            // 
            this.textBoxUserFormPassConf.Location = new System.Drawing.Point(154, 281);
            this.textBoxUserFormPassConf.Name = "textBoxUserFormPassConf";
            this.textBoxUserFormPassConf.Size = new System.Drawing.Size(239, 27);
            this.textBoxUserFormPassConf.TabIndex = 5;
            this.textBoxUserFormPassConf.UseSystemPasswordChar = true;
            this.textBoxUserFormPassConf.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUserFormPassConf_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // radioButtonUserFormActive
            // 
            this.radioButtonUserFormActive.AutoSize = true;
            this.radioButtonUserFormActive.Checked = true;
            this.radioButtonUserFormActive.Location = new System.Drawing.Point(155, 327);
            this.radioButtonUserFormActive.Name = "radioButtonUserFormActive";
            this.radioButtonUserFormActive.Size = new System.Drawing.Size(75, 23);
            this.radioButtonUserFormActive.TabIndex = 12;
            this.radioButtonUserFormActive.TabStop = true;
            this.radioButtonUserFormActive.Text = "Aktivan";
            this.radioButtonUserFormActive.UseVisualStyleBackColor = true;
            // 
            // labelUserFormStatus
            // 
            this.labelUserFormStatus.AutoSize = true;
            this.labelUserFormStatus.Location = new System.Drawing.Point(30, 329);
            this.labelUserFormStatus.Name = "labelUserFormStatus";
            this.labelUserFormStatus.Size = new System.Drawing.Size(53, 19);
            this.labelUserFormStatus.TabIndex = 13;
            this.labelUserFormStatus.Text = "Status:";
            // 
            // radioButtonUserFormInactive
            // 
            this.radioButtonUserFormInactive.AutoSize = true;
            this.radioButtonUserFormInactive.Location = new System.Drawing.Point(302, 327);
            this.radioButtonUserFormInactive.Name = "radioButtonUserFormInactive";
            this.radioButtonUserFormInactive.Size = new System.Drawing.Size(92, 23);
            this.radioButtonUserFormInactive.TabIndex = 14;
            this.radioButtonUserFormInactive.TabStop = true;
            this.radioButtonUserFormInactive.Text = "Neaktivan";
            this.radioButtonUserFormInactive.UseVisualStyleBackColor = true;
            // 
            // buttonUserFormSave
            // 
            this.buttonUserFormSave.BackColor = System.Drawing.Color.DarkRed;
            this.buttonUserFormSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonUserFormSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormSave.ForeColor = System.Drawing.Color.White;
            this.buttonUserFormSave.Location = new System.Drawing.Point(79, 379);
            this.buttonUserFormSave.Name = "buttonUserFormSave";
            this.buttonUserFormSave.Size = new System.Drawing.Size(77, 29);
            this.buttonUserFormSave.TabIndex = 15;
            this.buttonUserFormSave.Text = "Spremi";
            this.buttonUserFormSave.UseVisualStyleBackColor = false;
            this.buttonUserFormSave.Visible = false;
            this.buttonUserFormSave.Click += new System.EventHandler(this.buttonUserFormSave_Click);
            // 
            // buttonUserFormCancle
            // 
            this.buttonUserFormCancle.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonUserFormCancle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonUserFormCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormCancle.ForeColor = System.Drawing.Color.White;
            this.buttonUserFormCancle.Location = new System.Drawing.Point(211, 379);
            this.buttonUserFormCancle.Name = "buttonUserFormCancle";
            this.buttonUserFormCancle.Size = new System.Drawing.Size(85, 29);
            this.buttonUserFormCancle.TabIndex = 16;
            this.buttonUserFormCancle.Text = "Odustani";
            this.buttonUserFormCancle.UseVisualStyleBackColor = false;
            this.buttonUserFormCancle.Click += new System.EventHandler(this.buttonUserFormCancle_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(446, 460);
            this.Controls.Add(this.buttonUserFormCancle);
            this.Controls.Add(this.buttonUserFormSave);
            this.Controls.Add(this.radioButtonUserFormInactive);
            this.Controls.Add(this.labelUserFormStatus);
            this.Controls.Add(this.radioButtonUserFormActive);
            this.Controls.Add(this.textBoxUserFormPassConf);
            this.Controls.Add(this.labelUserFormConfirmPass);
            this.Controls.Add(this.buttonUserFormCreate);
            this.Controls.Add(this.textBoxUserFormPassword);
            this.Controls.Add(this.comboBoxUserFormRole);
            this.Controls.Add(this.textBoxUserFormUsername);
            this.Controls.Add(this.textBoxUserFormLastName);
            this.Controls.Add(this.textBoxUserFormName);
            this.Controls.Add(this.labelUserFormRole);
            this.Controls.Add(this.labelUserFormPassword);
            this.Controls.Add(this.labelUserFormUsername);
            this.Controls.Add(this.labelUserFormLastName);
            this.Controls.Add(this.labelUserFormName);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserForm";
            this.Text = "Novi korsinik";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserFormName;
        private System.Windows.Forms.Label labelUserFormLastName;
        private System.Windows.Forms.Label labelUserFormUsername;
        private System.Windows.Forms.Label labelUserFormPassword;
        private System.Windows.Forms.Label labelUserFormRole;
        private System.Windows.Forms.TextBox textBoxUserFormName;
        private System.Windows.Forms.TextBox textBoxUserFormLastName;
        private System.Windows.Forms.TextBox textBoxUserFormUsername;
        private System.Windows.Forms.ComboBox comboBoxUserFormRole;
        private System.Windows.Forms.TextBox textBoxUserFormPassword;
        private System.Windows.Forms.Button buttonUserFormCreate;
        private System.Windows.Forms.Label labelUserFormConfirmPass;
        private System.Windows.Forms.TextBox textBoxUserFormPassConf;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton radioButtonUserFormInactive;
        private System.Windows.Forms.Label labelUserFormStatus;
        private System.Windows.Forms.RadioButton radioButtonUserFormActive;
        private System.Windows.Forms.Button buttonUserFormSave;
        private System.Windows.Forms.Button buttonUserFormCancle;
    }
}