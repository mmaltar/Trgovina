namespace Trgovina
{
    partial class PasswordChange
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
            this.labelNewPass = new System.Windows.Forms.Label();
            this.labelPassConfirm = new System.Windows.Forms.Label();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.textBoxNewPassConf = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNewPass
            // 
            this.labelNewPass.AutoSize = true;
            this.labelNewPass.Font = new System.Drawing.Font("Calibri", 12F);
            this.labelNewPass.Location = new System.Drawing.Point(25, 40);
            this.labelNewPass.Name = "labelNewPass";
            this.labelNewPass.Size = new System.Drawing.Size(87, 19);
            this.labelNewPass.TabIndex = 0;
            this.labelNewPass.Text = "Nova lozink:";
            // 
            // labelPassConfirm
            // 
            this.labelPassConfirm.AutoSize = true;
            this.labelPassConfirm.Font = new System.Drawing.Font("Calibri", 12F);
            this.labelPassConfirm.Location = new System.Drawing.Point(25, 98);
            this.labelPassConfirm.Name = "labelPassConfirm";
            this.labelPassConfirm.Size = new System.Drawing.Size(107, 19);
            this.labelPassConfirm.TabIndex = 1;
            this.labelPassConfirm.Text = "Potvrdi lozinku:";
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(184, 37);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.Size = new System.Drawing.Size(227, 26);
            this.textBoxNewPass.TabIndex = 2;
            this.textBoxNewPass.UseSystemPasswordChar = true;
            this.textBoxNewPass.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNewPass_Validating);
            // 
            // textBoxNewPassConf
            // 
            this.textBoxNewPassConf.Location = new System.Drawing.Point(184, 95);
            this.textBoxNewPassConf.Name = "textBoxNewPassConf";
            this.textBoxNewPassConf.Size = new System.Drawing.Size(227, 26);
            this.textBoxNewPassConf.TabIndex = 3;
            this.textBoxNewPassConf.UseSystemPasswordChar = true;
            this.textBoxNewPassConf.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNewPassConf_Validating);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkRed;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(313, 157);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonCancle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancle.Font = new System.Drawing.Font("Calibri", 12F);
            this.buttonCancle.ForeColor = System.Drawing.Color.White;
            this.buttonCancle.Location = new System.Drawing.Point(184, 157);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(98, 29);
            this.buttonCancle.TabIndex = 5;
            this.buttonCancle.Text = "Odustani";
            this.buttonCancle.UseVisualStyleBackColor = false;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(446, 231);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNewPassConf);
            this.Controls.Add(this.textBoxNewPass);
            this.Controls.Add(this.labelPassConfirm);
            this.Controls.Add(this.labelNewPass);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PasswordChange";
            this.Text = "Promjena lozinke";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewPass;
        private System.Windows.Forms.Label labelPassConfirm;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.TextBox textBoxNewPassConf;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}