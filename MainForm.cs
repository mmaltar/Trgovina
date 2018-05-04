using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;

namespace Trgovina
{
    public partial class MainForm : Form
    {
        SQLiteConnection mConn;
        public SQLiteDataAdapter mAdapter;
        public DataTable mTable, artikli, nacini_placanja;
        DataTableCollection tables;
        User userLoggedIn;
        AutoCompleteStringCollection autocomplete_data;
        string mDbPath;
        PodaciTrgovina podaciTrgovina;
        List<Artikal> art;

        public MainForm(User userLoggedIn)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;

            this.userLoggedIn = userLoggedIn;
            string mDbPath = Application.StartupPath + "/database.db"; //getstarted.db
            mDbPath = Application.StartupPath + "/database.db"; //getstarted.db

            // If DB Not Exists, it will be created.
            mConn = new SQLiteConnection("Data Source=" + mDbPath);
            mConn.Open();

         


            mAdapter = new SQLiteDataAdapter("SELECT * FROM artikal", mConn);
            artikli = new DataTable(); // Don't forget initialize!
            mAdapter.Fill(artikli);

            mAdapter = new SQLiteDataAdapter("SELECT * from nacin_placanja where aktivan = 1", mConn);
            nacini_placanja = new DataTable();
            mAdapter.Fill(nacini_placanja);

            autocomplete_data = new AutoCompleteStringCollection();

           

            //napunimo listview sa artiklima
            loadItems();
            initDateTimePickersPopusti();
            podaciTrgovina = new PodaciTrgovina();
            this.Text = podaciTrgovina.Ime;
            initPodaciOTrgovini();
            dohvatiIstkleArtikle();
        }

        public void loadItems()
        {


            listView1.Columns.Add(artikli.Columns[0].ToString(), 0);
            listView1.Columns.Add("Kod", 80);
            listView1.Columns.Add("Ime", 90);
            listView1.Columns.Add("Cijena", 50);
            listView1.Columns.Add("Porez (%)", 60);
            listView1.Columns.Add("Ukupna cijena", 90);
            listView1.Columns.Add("Rok uporabe", 80);
            listView1.Columns.Add(artikli.Columns[7].ToString(), 0);
            listView1.Columns.Add("Količina", 60);


            listView3.Columns.Add("Ime", 90);
            listView3.Columns.Add("Kod", 80);

            ListViewItem listitem;

            foreach (DataRow row in artikli.Rows)
            {
                if( Int32.Parse(row[9].ToString()) == 1 && Int32.Parse(row[8].ToString()) > 0)
                {
                    listitem = new ListViewItem(row[0].ToString());

                    for (int i = 1; i < 9; i++)
                        listitem.SubItems.Add(row[i].ToString());

                    listitem.Name = listitem.SubItems[2].Text;
                    autocomplete_data.Add(listitem.Name);

                    listView1.Items.Add(listitem);

                }

               
            }

            //drugi listview predstavlja izabrane
            listView2.Columns.Add(artikli.Columns[0].ToString(), 0);
            listView2.Columns.Add("Kod", 80);
            listView2.Columns.Add("Ime", 90);
            listView2.Columns.Add("Cijena", 0);
            listView2.Columns.Add("Porez (%)", 0);
            listView2.Columns.Add("Ukupna cijena", 90);
            listView2.Columns.Add("Rok uporabe", 0);
            listView2.Columns.Add(artikli.Columns[7].ToString(), 0);
            listView2.Columns.Add("Količina", 60);


            //autocomplete za search
            textBox2.AutoCompleteCustomSource = autocomplete_data;

            InitComboBoxes();
            //napunimo naćin plaćanja
            foreach (DataRow row in nacini_placanja.Rows)
            {
                comboBox1.Items.Add(row[1].ToString());

            }
            comboBox1.SelectedIndex = 0;



        }

        //dodaj artikal
        private void Add_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (listView2.Items.ContainsKey(item.Name))
                {
                    ListViewItem temp = listView2.FindItemWithText(item.SubItems[2].Text);
                    double jedinicna_cijena = Double.Parse(temp.SubItems[5].Text) / Double.Parse(temp.SubItems[8].Text);
                    temp.SubItems[8].Text = (Int32.Parse(temp.SubItems[8].Text) + 1).ToString();
                    temp.SubItems[5].Text = (Double.Parse(temp.SubItems[5].Text) + jedinicna_cijena).ToString();
                }
                else
                {
                    ListViewItem temp = (ListViewItem)item.Clone();
                    temp.Name = item.SubItems[2].Text;
                    temp.SubItems[8].Text = 1.ToString();
                    listView2.Items.Add(temp);
                }

                item.SubItems[8].Text = (Int32.Parse(item.SubItems[8].Text) - 1).ToString();
                if (Int32.Parse(item.SubItems[8].Text) == 0) listView1.Items.Remove(item);
            }
        }

        //makni artikal
        private void Remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                if (Int32.Parse(item.SubItems[8].Text) > 1)
                {
                    double jedinicna_cijena = Double.Parse(item.SubItems[5].Text) / Int32.Parse(item.SubItems[8].Text);
                    item.SubItems[8].Text = (Int32.Parse(item.SubItems[8].Text) - 1).ToString();
                    item.SubItems[5].Text = (Double.Parse(item.SubItems[5].Text) - jedinicna_cijena).ToString();
                }
                else
                    listView2.Items.Remove(item);

                if (listView1.Items.ContainsKey(item.Name))
                {
                    ListViewItem sel = listView1.FindItemWithText(item.Name);
                    sel.SubItems[8].Text = (Int32.Parse(sel.SubItems[8].Text) + 1).ToString();
                }
                else
                {
                    ListViewItem temp = (ListViewItem)item.Clone();
                    temp.Name = temp.SubItems[2].Text;
                    temp.SubItems[8].Text = 1.ToString();
                    temp.SubItems[5].Text = (Double.Parse(item.SubItems[5].Text) / (Int32.Parse(item.SubItems[8].Text))).ToString();
                    listView1.Items.Add(temp);
                }

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

      
        }

        private void Dodaj2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0) return;

            DataRow[] artikal = artikli.Select("kod =" + Int32.Parse(textBox1.Text));

            if (artikal.Length == 0)
            {
                MessageBox.Show("Ne postoji artikal sa tim kodom.");
                textBox1.Text = "";
            }
            else
            {
                ListViewItem item = new ListViewItem(artikal[0][0].ToString());
                item.Name = artikal[0][2].ToString();

                if (listView1.Items.ContainsKey(item.Name))
                {
                    for (int i = 1; i < 9; i++)
                        item.SubItems.Add(artikal[0][i].ToString());

                    if (listView2.Items.ContainsKey(item.Name))
                    {
                        ListViewItem temp = listView2.FindItemWithText(item.Name);
                        double jedinicna_cijena = Double.Parse(temp.SubItems[5].Text) / Int32.Parse(temp.SubItems[8].Text);
                        temp.SubItems[8].Text = (Int32.Parse(temp.SubItems[8].Text) + 1).ToString();
                        temp.SubItems[5].Text = (Double.Parse(temp.SubItems[5].Text) + jedinicna_cijena).ToString();
                    }
                    else
                    {
                        item.SubItems[8].Text = 1.ToString();
                        listView2.Items.Add(item);
                    }

                    ListViewItem sel = listView1.FindItemWithText(item.Name);
                    sel.SubItems[8].Text = (Int32.Parse(sel.SubItems[8].Text) - 1).ToString();
                    if (Int32.Parse(sel.SubItems[8].Text) == 0) listView1.Items.Remove(sel);
                }
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetUserList();   
            }
            catch (Exception ex)
            {
                //Logger.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + ": " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        //pretraga po kodu
        private void Trazi_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();

            DataRow[] artikal = artikli.Select("aktivan = 1 AND ime LIKE '" + textBox2.Text + "%' OR aktivan = 1 AND ime LIKE '% " + textBox2.Text + "%'");

            foreach (DataRow dr in artikal)
            {
                ListViewItem item = new ListViewItem(dr[2].ToString());
                item.SubItems.Add(dr[1].ToString());
                listView3.Items.Add(item);
            }
        }


        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices.Count <= 0)
            {
                return;
            }

            textBox1.Text = listView3.SelectedItems[0].SubItems[1].Text;


        }

        //kreirat račun i ubacit u bazu sve potrebno
        private void kreiraj_Click(object sender, EventArgs e)
        {

            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("Košarica je prazna.");
                return;
            }

            DataRow[] rows = nacini_placanja.Select("name = '" + comboBox1.Text + "'");

            Nacin_placanja np = new Nacin_placanja(Convert.ToInt32(rows[0][0]), rows[0][1].ToString(), rows[0][2].ToString(),
                                     Convert.ToInt32(rows[0][3]), Convert.ToInt32(rows[0][4]));



            Racun r = new Racun(userLoggedIn.ID, np);

            foreach (ListViewItem item in listView2.Items)
            {

                Artikal temp = new Artikal(Int32.Parse(item.SubItems[0].Text), Int32.Parse(item.SubItems[1].Text), item.SubItems[2].Text,
                 Double.Parse(item.SubItems[3].Text.Replace(",", "."), CultureInfo.InvariantCulture), Double.Parse(item.SubItems[4].Text.Replace(",", "."), CultureInfo.InvariantCulture),
                 Double.Parse(item.SubItems[5].Text.Replace(",", "."), CultureInfo.InvariantCulture), item.SubItems[6].Text,
                 item.SubItems[7].Text, Int32.Parse(item.SubItems[8].Text));

                List<Popust> popusti = Service.getAllPopust(temp);

                foreach (Popust p in popusti)
                    temp.dodajPopust(p);

                r.Add(temp);
            }
            Service.insertRacunAndAll(r);


            tabPanel.SelectedTab = tabPageRacuniPregled;
            listView2.Items.Clear();

            //odma prikazujemo taj račun
            prikaziRacun(r);

        }


        private void PrikaziIzabranRacun_Click(object sender, EventArgs e)
        {

            if (listView5.SelectedItems.Count == 0)
                MessageBox.Show("Niste izabrali račun.");
            else
            {
                List<Racun> racun = Service.getRacunByID(Int32.Parse(listView5.SelectedItems[0].SubItems[1].Text));

                racun[0].reset();

                foreach (Artikal art in Service.getRacunArtikli(racun[0].id))
                {
                    foreach (Popust p in Service.getAllPopust(art))
                        art.dodajPopust(p);

                    racun[0].Add(art);
                }

                prikaziRacun(racun[0]);
            }
        }
    

            private void Odaberi_Click(object sender, EventArgs e)
            {
                listView5.Items.Clear();
                List<Racun> racuni = new List<Racun>();

            racuni = Service.getRacunByDate(dateTimePicker1.Value.Date.ToString());

                foreach (Racun r in racuni)
                {

                    ListViewItem item = new ListViewItem(r.datetime.Substring(r.datetime.Length - 8));

                    item.SubItems.Add(r.id.ToString());
                    item.SubItems.Add(r.id_user.ToString()); 
                    listView5.Items.Add(item);
                }

            }


        private void prikaziRacun(Racun r)
        {
            listView4.Items.Clear();

            foreach (Artikal art in r.artikli)
            {
                ListViewItem item = new ListViewItem(art.ime);
                item.SubItems.Add(art.porez_posto.ToString() + "%");
                item.SubItems.Add(art.getPopustSum().ToString() + "%");
                item.SubItems.Add(Math.Round((art.cijena_ukupno / art.kolicina), 2).ToString());
                item.SubItems.Add(art.kolicina.ToString());
                item.SubItems.Add(Math.Round((art.cijena_ukupno - 0.01 * art.getPopustSum() * art.cijena_ukupno), 2).ToString());

                listView4.Items.Add(item);
            }

            label6.Text = "Ukupno: " + Math.Round(r.total_artikli, 2);
            label7.Text = "Naćin plaćanja: " + r.getNacinPlacanja().name;
            label8.Text = "Popust: " + Math.Round(r.popust_nacin_placanja, 2);
            label9.Text = "Za platiti: " + Math.Round(r.total, 2);
        }


        private void tabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;

            if (tc.SelectedTab == tabPageArtikli)
            {
                artikliList.DataSource = artikli;
                displayArtikli();

            }

        }

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            if(DialogResult.OK == userForm.ShowDialog())
            {
                GetUserList();
            }
        }

   

        private void comboBoxUserStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetUserList();

            }
            catch (Exception ex)
            {
                //Logger.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + ": " + ex.Message);
            }
        }

        private void GetUserList()
        {
            try
            {

                List<Tuple<string, string, string>> filteri = new List<Tuple<string, string, string>>();
                DataRowView selectedRoleO = (DataRowView)comboBoxUserRole.SelectedItem;
                
                int selectedRole = (int)selectedRoleO["CKey"];
                Console.WriteLine("Rola {0}", selectedRole);
                if (selectedRole > -1)
                {
                    filteri.Add(new Tuple<string, string, string>("role_id", "=", (selectedRole).ToString()));
                }
                DataRowView selectedStatusO = (DataRowView)comboBoxUserStatus.SelectedItem;
                int selectedStatus = (int)selectedStatusO["CKey"];
                Console.WriteLine("Status {0}", selectedStatus);
                if (selectedStatus > -1)
                {
                   
                    filteri.Add(new Tuple<string, string, string>("active", "=", (selectedStatus).ToString()));
                }


                List<User> rt = User.All(filteri);
                userList.DataSource = rt;
                userList.Columns["Active"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + "(): " + ex.Message);
            }
        }

        private void userList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            User selectedUser = (User) userList.CurrentRow.DataBoundItem;
            UserForm userForm = new UserForm(selectedUser);
            if (DialogResult.OK == userForm.ShowDialog())
            {
                GetUserList();
            }

        }

        private void InitComboBoxes()
        {
            DataTable comboBoxUserStatusDataSource = new DataTable();
            comboBoxUserStatusDataSource.Columns.Add("CKey",typeof(int));
            comboBoxUserStatusDataSource.Columns.Add("CValue", typeof(string));
            comboBoxUserStatusDataSource.Rows.Add(-1, "Svi");
            comboBoxUserStatusDataSource.Rows.Add(1, "Aktivni");
            comboBoxUserStatusDataSource.Rows.Add(0, "Neaktivni");
            comboBoxUserStatus.DataSource = comboBoxUserStatusDataSource;
            comboBoxUserStatus.ValueMember = "CKey";
            comboBoxUserStatus.DisplayMember = "CValue";
            comboBoxUserStatus.SelectedIndex = 1;

            DataTable comboBoxUserRoleDataSource = new DataTable();
            comboBoxUserRoleDataSource.Columns.Add("CKey", typeof(int));
            comboBoxUserRoleDataSource.Columns.Add("CValue", typeof(string));
            comboBoxUserRoleDataSource.Rows.Add(-1, "Svi");
            comboBoxUserRole.DataSource = comboBoxUserRoleDataSource;
          
            string[] vals =(string[]) Enum.GetNames(typeof(Role));
            for (int k = 0; k < vals.Length; k++)
            {
                comboBoxUserRoleDataSource.Rows.Add((int)Enum.Parse(typeof(Role),vals[k]), vals[k]);
            }
            comboBoxUserRole.ValueMember = "CKey";
            comboBoxUserRole.DisplayMember = "CValue";
            comboBoxUserRole.SelectedIndex = 0;

        }

        private void buttonMyProfileEdit_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(userLoggedIn, true);
            if (DialogResult.OK == userForm.ShowDialog())
            {
                setMyFrofileData();
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            PasswordChange userForm = new PasswordChange(userLoggedIn);
            userForm.ShowDialog();
        }

        private void noviArtikal_Click(object sender, EventArgs e)
        {
            ArtikalForm artikalForm = new ArtikalForm(artikli);
            artikalForm.ShowDialog();
          
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ArtikliList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = artikliList.Rows[e.RowIndex];

            Console.WriteLine(row.Cells[3].Value.ToString().Replace(",", "."));

            Artikal art = new Artikal(
                Int32.Parse(row.Cells[0].Value.ToString()),
                Int32.Parse(row.Cells[1].Value.ToString()),
                row.Cells[2].Value.ToString(),
                Double.Parse(row.Cells[3].Value.ToString().Replace(",", "."), CultureInfo.InvariantCulture),
                Double.Parse(row.Cells[4].Value.ToString(), CultureInfo.InvariantCulture),
                Double.Parse(row.Cells[5].Value.ToString(), CultureInfo.InvariantCulture),
                row.Cells[6].Value.ToString(),
                row.Cells[7].Value.ToString(),
                Int32.Parse(row.Cells[8].Value.ToString()),
                Int32.Parse(row.Cells[9].Value.ToString())
                );


            ArtikalForm artikalForm = new ArtikalForm(artikli, art, Int32.Parse(row.Cells[9].Value.ToString()));

            if (DialogResult.OK == artikalForm.ShowDialog())
            {

            }

        }

        private void tabPanel_Selected(object sender, TabControlEventArgs e)
        {
            Console.WriteLine("tabPanel_Selected");
            if (e.TabPage == tabPageMyProfile)
            {
                setMyFrofileData();
            }
            else if (e.TabPage == tabPagePopusti)
            {
                Console.WriteLine("tabPanel_Selected popusti");

                dohvatiPopuste();
            }
            else if (e.TabPage == tabPageStatistika)
            {
                prodajaPoKorinicimaArtikli();
                prodajaPoKorinicimaRacuni();
                prodajaPoVrstiArtikla();
            }
        }

        private void setMyFrofileData()
        {
            labelMyFrofileName.Text = userLoggedIn.Ime;
            labelMyFrofileLastName.Text = userLoggedIn.Prezime;
            labelMyFrofileUsername.Text = userLoggedIn.Username;
            labelMyFrofileRole.Text = userLoggedIn.Rola.ToString();
        }

        private void displayArtikli()
        {
            artikliList.Columns[0].HeaderText = "ID";
            artikliList.Columns[0].Width = 25;
            artikliList.Columns[1].HeaderText = "Kod";
            artikliList.Columns[1].Width = 80;
            artikliList.Columns[2].HeaderText = "Ime";
            artikliList.Columns[2].Width = 90;
            artikliList.Columns[3].HeaderText = "Cijena";
            artikliList.Columns[3].Width = 50;
            artikliList.Columns[4].HeaderText = "Porez (%)";
            artikliList.Columns[4].Width = 40;
            artikliList.Columns[5].HeaderText = "Ukupna cijena";
            artikliList.Columns[5].Width = 50;
            artikliList.Columns[6].HeaderText = "Rok Uporabe";
            artikliList.Columns[6].Width = 70;
            artikliList.Columns[7].HeaderText = "Datum nabave";
            artikliList.Columns[7].Width = 70;
            artikliList.Columns[8].HeaderText = "Količina";
            artikliList.Columns[8].Width = 60;
            artikliList.Columns[9].HeaderText = "Aktivan";
            artikliList.Columns[9].Width = 50;

        }

        private void dateTimePickerPopustiOd_ValueChanged(object sender, EventArgs e)
        {
            dohvatiPopuste();
        }

        private void dateTimePickerPopustiDo_ValueChanged(object sender, EventArgs e)
        {
            dohvatiPopuste();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PopustiForm popustiForm = new PopustiForm();
            if (DialogResult.OK == popustiForm.ShowDialog())
            {
                dohvatiPopuste();
            }
        }

        private void buttonTrgovinaSave_Click(object sender, EventArgs e)
        {
            podaciTrgovina.Save();
            buttonTrgovinaSave.Visible = false;
        }

        private void initDateTimePickersPopusti()
        {
            DateTime from = DateTime.Now;
            from = from.AddDays(-30);
            dateTimePickerPopustiOd.Value = from;
            dateTimePickerPopustiDo.Value = DateTime.Now;
            
        }

        private void textBoxTrgovinaIme_TextChanged(object sender, EventArgs e)
        {
            buttonTrgovinaSave.Visible = true;
        }

        private void dohvatiPopuste()
        {
            string from = "'"+dateTimePickerPopustiOd.Value.ToString("yyyy.MM.dd")+"'";
            string to = "'" + dateTimePickerPopustiDo.Value.ToString("yyyy.MM.dd") + "'";
            string where = @" ("+Service.FormatSQLDate("vrijedi_od")+" <= "+from + " AND " + Service.FormatSQLDate("vrijedi_do") + " >= " + from
                + ") OR (" + Service.FormatSQLDate("vrijedi_od") + " >= " + from + " AND " + Service.FormatSQLDate("vrijedi_od") + " <= " + to+")"; 
            dataGridViewPopusti.DataSource = Trgovina.Popust.All("*", where);
        }

        private void initPodaciOTrgovini()
        {
            textBoxTrgovinaIme.Text = podaciTrgovina.Ime;
            textBoxTrgovinaEmail.Text = podaciTrgovina.Email;
            textBoxTrgovinaGrad.Text = podaciTrgovina.Grad;
            textBoxTrgovinaKbr.Text = podaciTrgovina.KucniBroj;
            textBoxTrgovinaOib.Text = podaciTrgovina.OIB;
            textBoxTrgovinaTel.Text = podaciTrgovina.TEL;
            textBoxTrgovinaUlica.Text = podaciTrgovina.Ulica;
            textBoxTrgovinaVlasnik.Text = podaciTrgovina.Vlasnik;
            buttonTrgovinaSave.Visible = false;
        }

        private void prodajaPoKorinicimaArtikli()
        {
            try
            {
                string seria = "korisniciArtikli";
                DataTable kori =  Service.ProdajaArtikalaPoKorisniku();
            
                chartArtikliPoKorisnicima.Series.Add(seria);
                chartArtikliPoKorisnicima.Series[seria].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chartArtikliPoKorisnicima.DataSource = kori;
                chartArtikliPoKorisnicima.Series[seria].XValueMember = "korisnik";
                chartArtikliPoKorisnicima.Series[seria].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartArtikliPoKorisnicima.Series[seria].YValueMembers = "smm";
                chartArtikliPoKorisnicima.Series[seria].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartArtikliPoKorisnicima.Series[seria].IsValueShownAsLabel = true;
            }
            catch(Exception e)
            {
                Console.WriteLine("EEEEEEE");
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            if (userLoggedIn.Rola == Role.Blagajnik)
            {
                Console.WriteLine("MainForm_Load if");
                tabPanel.TabPages.Remove(tabPageArtikli);
                tabPanel.TabPages.Remove(tabPagePopusti);
                tabPanel.TabPages.Remove(tabPageOptions);
                tabPanel.TabPages.Remove(tabPageStatistika);
            }
            else if(userLoggedIn.Rola == Role.Poslovođa)
            {
                Console.WriteLine("MainForm_Load ele");
                tabPanel.TabPages.Remove(tabPageOptions);
            }
        }

        private void prodajaPoKorinicimaRacuni()
        {
            try
            {
                string seria = "korisniciRacuni";
                DataTable kori = Service.ProdajaRacunaPoKorisniku();

                chartRacuniPoKorisnicima.Series.Add(seria);
                chartRacuniPoKorisnicima.Series[seria].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chartRacuniPoKorisnicima.DataSource = kori;
                chartRacuniPoKorisnicima.Series[seria].XValueMember = "korisnik";
                chartRacuniPoKorisnicima.Series[seria].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartRacuniPoKorisnicima.Series[seria].YValueMembers = "smm";
                chartRacuniPoKorisnicima.Series[seria].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartRacuniPoKorisnicima.Series[seria].IsValueShownAsLabel = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("EEEEEEE");
            }

        }

        private void buttonNoticePotvrdi_Click(object sender, EventArgs e)
        {
            panelNotice.Visible = false;
            panelNotice.SendToBack();
            Service.IstekliArtikliPotvrdeno((DataTable)dataGridViewNotice.DataSource);
            dataGridViewNotice.DataSource = null;
        }

        private void prodajaPoVrstiArtikla()
        {
            try
            {
                string seria = "artikli";
                DataTable art = Service.ProdajaPoVrstiArtikla();

                chartArtikli.Series.Add(seria);
                chartArtikli.Series[seria].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chartArtikli.DataSource = art;
                chartArtikli.Series[seria].XValueMember = "ime";
                chartArtikli.Series[seria].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartArtikli.Series[seria].YValueMembers = "smm";
                chartArtikli.Series[seria].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartArtikli.Series[seria].IsValueShownAsLabel = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("EEEEEEE");
            }

        }

        private void dohvatiIstkleArtikle()
        {
            DataTable istekli = Service.IstekliArtikli();

            dataGridViewNotice.DataSource = istekli;
            
            if (istekli.Rows.Count > 0)
            {
                panelNotice.Visible = true;
                panelNotice.BringToFront();

            }
        }
    }
}
