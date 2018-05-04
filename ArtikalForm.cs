using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trgovina
{
    public partial class ArtikalForm : Form
    {

        DataTable artikli;

        public ArtikalForm()
        {
            InitializeComponent();
        }

        public ArtikalForm(DataTable svi_artikli)
        {
            artikli = svi_artikli;
            InitializeComponent();
        }

        public ArtikalForm(DataTable svi_artikli, Artikal art, int aktivan)
        {
            InitializeComponent();
            artikli = svi_artikli;

            buttonDodaj.Hide();
            Azuriraj.Show();

            textBox1.Text = art.kod.ToString();
            textBox2.Text = art.ime;
            textBox3.Text = art.cijena.ToString();
            textBox4.Text = art.porez_posto.ToString();
            maskedTextBox1.Text = art.datum_nabave;
            maskedTextBox2.Text = art.rok_uporabe;
            numericUpDown1.Value = art.kolicina;
            label8.Text = art.id.ToString();
            if (aktivan == 1)
            {
                radioButtonActive.Checked = true;
                radioButtonInactive.Checked = false;
            }
            else
            {
                radioButtonActive.Checked = false;
                radioButtonInactive.Checked = true;

            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

        }



        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            string dn, ru;
            int aktivan = 0;

            if (maskedTextBox1.Text[0] == '0')
            {
                if (maskedTextBox1.Text[3] == '0')
                {
                    dn = maskedTextBox1.Text.Substring(1, 2) + maskedTextBox1.Text.Substring(4);
                }
                else dn = maskedTextBox1.Text.Substring(1);
            }
            else if (maskedTextBox1.Text[3] == '0')
            {
                dn = maskedTextBox1.Text.Substring(0, 3) + maskedTextBox1.Text.Substring(4);
            }
            else
                dn = maskedTextBox1.Text;

            if (maskedTextBox2.Text[0] == '0')
            {
                if (maskedTextBox2.Text[3] == '0')
                {
                    ru = maskedTextBox2.Text.Substring(1, 2) + maskedTextBox2.Text.Substring(4);
                }
                else ru = maskedTextBox2.Text.Substring(1);
            }
            else if (maskedTextBox2.Text[3] == '0')
            {
               ru = maskedTextBox2.Text.Substring(0, 3) + maskedTextBox2.Text.Substring(4);
            }
            else
                ru = maskedTextBox2.Text;


            //ne radi za neaktivan?
            if (radioButtonActive.Checked == true)
                aktivan = 1;
            else
                aktivan = 0;

            int id = Service.AddArtikal(new Artikal(Int32.Parse(textBox1.Text), textBox2.Text, Double.Parse(textBox3.Text, CultureInfo.InvariantCulture),
                Double.Parse(textBox4.Text, CultureInfo.InvariantCulture), Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) + 0.01 * Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) * 
                Double.Parse(textBox4.Text, CultureInfo.InvariantCulture),
                ru, dn, (int)numericUpDown1.Value), aktivan);

            DataRow dr = artikli.NewRow();
            dr[0] = id;
            dr[1] = Int32.Parse(textBox1.Text);
            dr[2] = textBox2.Text;
            dr[3] = Math.Round(Double.Parse(textBox3.Text, CultureInfo.InvariantCulture), 2);
            dr[4] = Double.Parse(textBox4.Text, CultureInfo.InvariantCulture);
            dr[5] = Math.Round(Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) + 0.01 * Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) * Double.Parse(textBox4.Text, CultureInfo.InvariantCulture), 2);
            dr[6] = maskedTextBox2.Text;
            dr[7] = maskedTextBox1.Text;
            dr[8] = (int)numericUpDown1.Value;
            dr[9] = aktivan;

            artikli.Rows.Add(dr);
            artikli.AcceptChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonUserFormCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        //validirat kaj sve treba
        private bool tbKodValidate()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Unesite kod");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.textBox1, "");
            }
            return bStatus;
        }

        private bool tbImeValidate()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Unesite ime");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.textBox2, "");
            }
            return bStatus;
        }


        private bool tbCijenaValidate()
        {
            bool bStatus = true;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Unesite cijenu");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.textBox3, "");
            }
            return bStatus;
        }


        private bool tbPorezValidate()
        {
            bool bStatus = true;
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Unesite cijenu");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.textBox4, "");
            }
            return bStatus;
        }


        private bool tbDatumNabaveValidate()
        {
            bool bStatus = true;

            if (!maskedTextBox1.MaskFull)
            {
                errorProvider1.SetError(maskedTextBox1, "Unesite datum nabave");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.maskedTextBox1, "");
            }
            return bStatus;
        }

        private bool tbRokUporabeValidate()
        {
            bool bStatus = true;
            if (!maskedTextBox2.MaskFull)
            {
                errorProvider1.SetError(maskedTextBox2, "Unesite rok uporabe");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(this.maskedTextBox2, "");
            }
            return bStatus;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            tbKodValidate();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            tbImeValidate();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            tbCijenaValidate();
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            tbPorezValidate();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            tbDatumNabaveValidate();
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            tbRokUporabeValidate();
        }

        private void Azuriraj_Click(object sender, EventArgs e)
        {
            int aktivan;

            if (radioButtonActive.Checked == true)
                aktivan = 1;
            else aktivan = 0;
            
            Service.updateArtikal(new Artikal(Int32.Parse(label8.Text), Int32.Parse(textBox1.Text), textBox2.Text,
                Double.Parse(textBox3.Text, CultureInfo.InvariantCulture), Double.Parse(textBox4.Text, CultureInfo.InvariantCulture),
                Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) + 0.01 * Double.Parse(textBox4.Text, CultureInfo.InvariantCulture) *
                Double.Parse(textBox3.Text, CultureInfo.InvariantCulture), maskedTextBox2.Text, maskedTextBox1.Text, (int)numericUpDown1.Value, aktivan) );
                
            DataRow[] row = artikli.Select("id =" + label8.Text);

            row[0][0] = Int32.Parse(label8.Text);
            row[0][1] = Int32.Parse(textBox1.Text);
            row[0][2] = textBox2.Text;
            row[0][3] = Math.Round(Double.Parse(textBox3.Text, CultureInfo.InvariantCulture), 2);
            row[0][4] = Double.Parse(textBox4.Text, CultureInfo.InvariantCulture);
            row[0][5] = Math.Round(Double.Parse(textBox3.Text, CultureInfo.InvariantCulture) + 0.01 * Double.Parse(textBox4.Text, CultureInfo.InvariantCulture) * Double.Parse(textBox3.Text, CultureInfo.InvariantCulture), 2);
            row[0][6] = maskedTextBox2.Text;
            row[0][7] = maskedTextBox1.Text;
            row[0][8] = numericUpDown1.Value;
            row[0][9] = aktivan;

            artikli.AcceptChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}