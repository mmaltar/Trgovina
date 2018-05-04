namespace Trgovina
{
    partial class PopustiForm
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
            this.labelPopustFormOpis = new System.Windows.Forms.Label();
            this.textBoxPopustFormOpis = new System.Windows.Forms.TextBox();
            this.labelPopustFormOd = new System.Windows.Forms.Label();
            this.labelPopustFormDo = new System.Windows.Forms.Label();
            this.dateTimePickerPopustFormOd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPopustFormDo = new System.Windows.Forms.DateTimePicker();
            this.buttonPopustFormCancle = new System.Windows.Forms.Button();
            this.buttonPopustFormCreate = new System.Windows.Forms.Button();
            this.errorProviderPopustiForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelPopustiFormPopust = new System.Windows.Forms.Label();
            this.numericUpDownPopustiFormPopust = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPopustiForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopustiFormPopust)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPopustFormOpis
            // 
            this.labelPopustFormOpis.AutoSize = true;
            this.labelPopustFormOpis.Location = new System.Drawing.Point(22, 52);
            this.labelPopustFormOpis.Name = "labelPopustFormOpis";
            this.labelPopustFormOpis.Size = new System.Drawing.Size(43, 19);
            this.labelPopustFormOpis.TabIndex = 0;
            this.labelPopustFormOpis.Text = "Opis:";
            // 
            // textBoxPopustFormOpis
            // 
            this.textBoxPopustFormOpis.Location = new System.Drawing.Point(114, 40);
            this.textBoxPopustFormOpis.Multiline = true;
            this.textBoxPopustFormOpis.Name = "textBoxPopustFormOpis";
            this.textBoxPopustFormOpis.Size = new System.Drawing.Size(250, 40);
            this.textBoxPopustFormOpis.TabIndex = 1;
            this.textBoxPopustFormOpis.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPopustFormOpis_Validating);
            // 
            // labelPopustFormOd
            // 
            this.labelPopustFormOd.AutoSize = true;
            this.labelPopustFormOd.Location = new System.Drawing.Point(22, 107);
            this.labelPopustFormOd.Name = "labelPopustFormOd";
            this.labelPopustFormOd.Size = new System.Drawing.Size(75, 19);
            this.labelPopustFormOd.TabIndex = 2;
            this.labelPopustFormOd.Text = "Vrijedi od:";
            // 
            // labelPopustFormDo
            // 
            this.labelPopustFormDo.AutoSize = true;
            this.labelPopustFormDo.Location = new System.Drawing.Point(22, 155);
            this.labelPopustFormDo.Name = "labelPopustFormDo";
            this.labelPopustFormDo.Size = new System.Drawing.Size(75, 19);
            this.labelPopustFormDo.TabIndex = 3;
            this.labelPopustFormDo.Text = "Vrijedi do:";
            // 
            // dateTimePickerPopustFormOd
            // 
            this.dateTimePickerPopustFormOd.Location = new System.Drawing.Point(114, 103);
            this.dateTimePickerPopustFormOd.Name = "dateTimePickerPopustFormOd";
            this.dateTimePickerPopustFormOd.Size = new System.Drawing.Size(175, 27);
            this.dateTimePickerPopustFormOd.TabIndex = 4;
            this.dateTimePickerPopustFormOd.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePickerPopustFormOd_Validating);
            // 
            // dateTimePickerPopustFormDo
            // 
            this.dateTimePickerPopustFormDo.Location = new System.Drawing.Point(114, 153);
            this.dateTimePickerPopustFormDo.Name = "dateTimePickerPopustFormDo";
            this.dateTimePickerPopustFormDo.Size = new System.Drawing.Size(175, 27);
            this.dateTimePickerPopustFormDo.TabIndex = 5;
            this.dateTimePickerPopustFormDo.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePickerPopustFormDo_Validating);
            // 
            // buttonPopustFormCancle
            // 
            this.buttonPopustFormCancle.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonPopustFormCancle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonPopustFormCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPopustFormCancle.ForeColor = System.Drawing.Color.White;
            this.buttonPopustFormCancle.Location = new System.Drawing.Point(166, 290);
            this.buttonPopustFormCancle.Name = "buttonPopustFormCancle";
            this.buttonPopustFormCancle.Size = new System.Drawing.Size(85, 29);
            this.buttonPopustFormCancle.TabIndex = 6;
            this.buttonPopustFormCancle.Text = "Odustani";
            this.buttonPopustFormCancle.UseVisualStyleBackColor = false;
            this.buttonPopustFormCancle.Click += new System.EventHandler(this.buttonPopustFormCancle_Click);
            // 
            // buttonPopustFormCreate
            // 
            this.buttonPopustFormCreate.BackColor = System.Drawing.Color.DarkRed;
            this.buttonPopustFormCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonPopustFormCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPopustFormCreate.ForeColor = System.Drawing.Color.White;
            this.buttonPopustFormCreate.Location = new System.Drawing.Point(275, 290);
            this.buttonPopustFormCreate.Name = "buttonPopustFormCreate";
            this.buttonPopustFormCreate.Size = new System.Drawing.Size(75, 29);
            this.buttonPopustFormCreate.TabIndex = 7;
            this.buttonPopustFormCreate.Text = "Kreiraj";
            this.buttonPopustFormCreate.UseVisualStyleBackColor = false;
            this.buttonPopustFormCreate.Click += new System.EventHandler(this.buttonPopustFormCreate_Click);
            // 
            // errorProviderPopustiForm
            // 
            this.errorProviderPopustiForm.ContainerControl = this;
            // 
            // labelPopustiFormPopust
            // 
            this.labelPopustiFormPopust.AutoSize = true;
            this.labelPopustiFormPopust.Location = new System.Drawing.Point(22, 205);
            this.labelPopustiFormPopust.Name = "labelPopustiFormPopust";
            this.labelPopustiFormPopust.Size = new System.Drawing.Size(82, 19);
            this.labelPopustiFormPopust.TabIndex = 8;
            this.labelPopustiFormPopust.Text = "Popust (%):";
            // 
            // numericUpDownPopustiFormPopust
            // 
            this.numericUpDownPopustiFormPopust.DecimalPlaces = 2;
            this.numericUpDownPopustiFormPopust.Location = new System.Drawing.Point(114, 203);
            this.numericUpDownPopustiFormPopust.Name = "numericUpDownPopustiFormPopust";
            this.numericUpDownPopustiFormPopust.Size = new System.Drawing.Size(73, 27);
            this.numericUpDownPopustiFormPopust.TabIndex = 9;
            // 
            // PopustiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 377);
            this.Controls.Add(this.numericUpDownPopustiFormPopust);
            this.Controls.Add(this.labelPopustiFormPopust);
            this.Controls.Add(this.buttonPopustFormCreate);
            this.Controls.Add(this.buttonPopustFormCancle);
            this.Controls.Add(this.dateTimePickerPopustFormDo);
            this.Controls.Add(this.dateTimePickerPopustFormOd);
            this.Controls.Add(this.labelPopustFormDo);
            this.Controls.Add(this.labelPopustFormOd);
            this.Controls.Add(this.textBoxPopustFormOpis);
            this.Controls.Add(this.labelPopustFormOpis);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PopustiForm";
            this.Text = "Popust";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPopustiForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopustiFormPopust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPopustFormOpis;
        private System.Windows.Forms.TextBox textBoxPopustFormOpis;
        private System.Windows.Forms.Label labelPopustFormOd;
        private System.Windows.Forms.Label labelPopustFormDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerPopustFormOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerPopustFormDo;
        private System.Windows.Forms.Button buttonPopustFormCancle;
        private System.Windows.Forms.Button buttonPopustFormCreate;
        private System.Windows.Forms.ErrorProvider errorProviderPopustiForm;
        private System.Windows.Forms.NumericUpDown numericUpDownPopustiFormPopust;
        private System.Windows.Forms.Label labelPopustiFormPopust;
    }
}