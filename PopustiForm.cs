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
    public partial class PopustiForm : Form
    {
        public PopustiForm()
        {
            InitializeComponent();
        }

        private void buttonPopustFormCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool tbOpisValidate()
        {
            bool bStatus = true;
            if (this.textBoxPopustFormOpis.Text == "")
            {
                Console.WriteLine("if");
                errorProviderPopustiForm.SetError(this.textBoxPopustFormOpis, "Unesite opis");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProviderPopustiForm.SetError(this.textBoxPopustFormOpis, "");
            }
            return bStatus;
        }

        private bool tbFromValidate()
        {
            bool bStatus = true;
            DateTime nowD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime selected = this.dateTimePickerPopustFormOd.Value;
            DateTime selectedCompare = new DateTime(selected.Year, selected.Month, selected.Day, 0, 0, 0);
            
            if (DateTime.Compare(nowD, selectedCompare) == 1)
            {
                errorProviderPopustiForm.SetError(this.dateTimePickerPopustFormOd, "Popust se može definirati najranije od danas");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProviderPopustiForm.SetError(this.dateTimePickerPopustFormOd, "");
            }
            return bStatus;
        }

        private bool tbToValidate()
        {
            bool bStatus = true;
            DateTime selected = this.dateTimePickerPopustFormOd.Value;
            DateTime selectedCompare = new DateTime(selected.Year, selected.Month, selected.Day, 0, 0, 0);

            DateTime selected2 = this.dateTimePickerPopustFormDo.Value;
            DateTime selectedCompare2 = new DateTime(selected2.Year, selected2.Month, selected2.Day, 0, 0, 0);


            if (DateTime.Compare(selectedCompare, selectedCompare2) == 1)
            {
                errorProviderPopustiForm.SetError(this.dateTimePickerPopustFormDo, "Datum do kojeg vrijedi popust ne može biti manji od datuma od kojeg vrijedi popust");
                bStatus = false;
            }
            else
            {
                Console.WriteLine("else");
                errorProviderPopustiForm.SetError(this.dateTimePickerPopustFormDo, "");
            }
            return bStatus;
        }

        private void buttonPopustFormCreate_Click(object sender, EventArgs e)
        {
            bool tbValOpis = tbOpisValidate();
            bool tbValFrom = tbFromValidate();
            bool tbValTo = tbToValidate();
            if (tbValOpis && tbValFrom && tbValTo)
            {
                Popust.Create((double)numericUpDownPopustiFormPopust.Value,textBoxPopustFormOpis.Text, dateTimePickerPopustFormOd.Value.ToString("dd.MM.yyy"), dateTimePickerPopustFormDo.Value.ToString("dd.MM.yyy"));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite ispravne podatke");
            }
        }

        private void dateTimePickerPopustFormOd_Validating(object sender, CancelEventArgs e)
        {
            tbFromValidate();
        }

        private void dateTimePickerPopustFormDo_Validating(object sender, CancelEventArgs e)
        {
            tbToValidate();
        }

        private void textBoxPopustFormOpis_Validating(object sender, CancelEventArgs e)
        {
            tbOpisValidate();
        }
    }
}
