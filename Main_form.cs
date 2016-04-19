using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace Slow_Dent_Desktop
{

    public delegate void PatientDelegate(Patient pacjent);
    public delegate void EmptyDelegate();
    public delegate bool databaseConnectionDelegate(string s, string u, string p);

    public partial class Main_form : Form
    {

        public List<Patient> listaPacjentow { get; set; }
        public List<Disease> listaChorob { get; set; }
        Patient wybranyPacjent;
        DentitionController DentCont;
        BindingSource bs;

        bool isDatabaseAvailable;
        PatientsDatabaseContext Database;


        public Main_form()
        {           

            InitializeComponent();

            Dane dane_form = new Dane();
            dane_form.connectToDatabase = new databaseConnectionDelegate(connectToDatabase);
            dane_form.readFromFile = new EmptyDelegate(readDataFromFile);
            dane_form.ShowDialog();

            bs = new BindingSource();
            dataGridView1.DataSource = bs;
            dataGridView1.RowTemplate.MinimumHeight = 50;
        }

        private bool connectToDatabase(string server, string user, string pass)
        {

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.InitialCatalog = "SlowDentDesktop";
            sqlBuilder.DataSource = server;
            sqlBuilder.UserID = user;
            sqlBuilder.Password = pass;
            sqlBuilder.PersistSecurityInfo = true;

            string providerString = sqlBuilder.ConnectionString;



            try
            {
                Database = new PatientsDatabaseContext(providerString);
                Database.Database.Connection.Open();
                Database.Database.Connection.Close();
            }
            catch (SqlException)
            {
                return false;
            }

            isDatabaseAvailable = true;
            listaPacjentow = Database.Pacjenci.Include(pac => pac.itsTeeth).ToList();
            listaChorob = Database.Diseases.ToList();

            return true;
        }

        private void readDataFromFile()
        {
            isDatabaseAvailable = false;

            listaPacjentow = BinarySerialization.ReadFromBinaryFile<List<Patient>>("slow_dent_data.bin");
            listaChorob = BinarySerialization.ReadFromBinaryFile<List<Disease>>("slow_dent_diseases.bin");
            if (listaPacjentow == null)
            {
                listaPacjentow = new List<Patient>();
            }
            if (listaChorob == null)
            {
                createDiseasesList();
            }
        }

        public void createDiseasesList()
        {
            listaChorob = new List<Disease>();
            listaChorob.Add(new Disease("Niewydolność krążenia"));
            listaChorob.Add(new Disease("Wada serca"));
            listaChorob.Add(new Disease("Nerwica"));
            listaChorob.Add(new Disease("Nadciśnienie"));
            listaChorob.Add(new Disease("Cukrzyca"));
            listaChorob.Add(new Disease("Choroby tarczycy"));
            listaChorob.Add(new Disease("Jaskra"));
            listaChorob.Add(new Disease("Zawał"));
            listaChorob.Add(new Disease("Zastawki/rozrusznik"));
            listaChorob.Add(new Disease("Zapalenie wsierdzia"));
            listaChorob.Add(new Disease("Choroba wrzodowa"));
            listaChorob.Add(new Disease("Alergia"));
            listaChorob.Add(new Disease("Reumatyzm"));
            listaChorob.Add(new Disease("Żółtaczka"));
            listaChorob.Add(new Disease("Astma"));
            listaChorob.Add(new Disease("Hemofilia"));
            listaChorob.Add(new Disease("Padaczka"));
            listaChorob.Add(new Disease("AIDS"));
            BinarySerialization.WriteToBinaryFile("slow_dent_diseases.bin", listaChorob);
        }

        public void dodajPacjenta(Patient nowyPacjent)
        {            
            if (isDatabaseAvailable)
            {
                Database.Pacjenci.Add(nowyPacjent);
                Database.SaveChanges();
            }
            else
            {
                if (listaPacjentow.Count() != 0)
                {
                    nowyPacjent.PatientId = listaPacjentow.Max(p => p.PatientId) + 1;
                }
                else
                {
                    nowyPacjent.PatientId = 1;
                }
                
            }
            listaPacjentow.Add(nowyPacjent);
            wczytajPacjenta(nowyPacjent);

        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }


        private void listaPacjentówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL_form Lista_pacjentow = new PL_form(listaPacjentow);
            Lista_pacjentow.updatePatientonMainWindow = new PatientDelegate(wczytajPacjenta);
            Lista_pacjentow.refreshPatientonMainWindow = new EmptyDelegate(odswiezPacjenta);
            Lista_pacjentow.patientRemovedCallback = new PatientDelegate(usunPacjenta);
            Lista_pacjentow.ShowDialog();
        }

        private void dodajPacjentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patient_form nowyPacjentForm = new Patient_form();
            nowyPacjentForm.AddPatientCallback = new PatientDelegate(this.dodajPacjenta);
            nowyPacjentForm.ShowDialog();
            if (nowyPacjentForm.DialogResult == DialogResult.Yes)
                zrobWywiad();
        }

        private void wczytajPacjenta(Patient wpac)
        {
            this.Controls.Remove(DentCont);
            DentCont = null;

            bs.DataSource = null;
            dataGridView1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            wybranyPacjent = wpac;
            l_imie.Text = wybranyPacjent.itsName + " " + wybranyPacjent.itsSurname;
            int rok = int.Parse(wybranyPacjent.itsBirthDate.Substring(0, 4));
            int teraz = DateTime.Now.Year;
            int wiek = teraz - rok;
            l_wiek.Text = wiek.ToString() + " " + "lat";
            l_PESEL.Text = wybranyPacjent.itsPESEL;

            radioButton1.Visible = true;
            radioButton2.Visible = true;
            b_wywiad.Visible = true;
            button2.Visible = true;
            wybranyPacjent.synchronizeTreatments();            

            pictureBox1.Visible = false;

            DentCont = new DentitionController(this.Width, this.Height);
            setTeethControllerStates();
            this.Controls.Add(DentCont);
            

            //DentCont delegate
            DentCont.setToothDelegates(translateToothControllerCommands, translateToothControllerCommands);
        }

        private void odswiezPacjenta()
        {
            if(wybranyPacjent != null)
            {
                l_imie.Text = wybranyPacjent.itsName + " " + wybranyPacjent.itsSurname;
                int rok = int.Parse(wybranyPacjent.itsBirthDate.Substring(0, 4));
                int teraz = DateTime.Now.Year;
                int wiek = teraz - rok;
                l_wiek.Text = wiek.ToString() + " " + "lat";
                l_PESEL.Text = wybranyPacjent.itsPESEL;
            }

        }

        private void usunPacjenta(Patient pac)
        {
            if (isDatabaseAvailable)
            {
                Database.Pacjenci.Remove(pac);
                Database.SaveChanges();
            }

            if(pac == wybranyPacjent)
            {
                wybranyPacjent = null;
                l_imie.Text = "Wybierz pacjenta z listy lub dodaj nowego";
                l_wiek.Text = null;
                l_PESEL.Text = null;

                this.Controls.Remove(DentCont);
                DentCont = null;

                bs.DataSource = null;

                dataGridView1.Visible = false;
                pictureBox1.Visible = true;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                b_wywiad.Visible = false;
                button2.Visible = false;
            }
        }

        private void translateToothControllerCommands(string TId, tooth_state tState)
        {
            Tooth eTooth = wybranyPacjent.getTooth(TId);
            switch (tState)
            {
                case tooth_state.normal:
                    eTooth.setNormal();
                    break;
                case tooth_state.endo:
                    eTooth.isEndo = true;
                    eTooth.hasCrown = false;
                    break;
                case tooth_state.crown:
                    eTooth.isEndo = false;
                    eTooth.hasCrown = true;
                    break;
                case tooth_state.endocrown:
                    eTooth.isEndo = true;
                    eTooth.hasCrown = true;
                    break;
                case tooth_state.extracted:
                    eTooth.isExtracted = true;
                    break;
                case tooth_state.cutting:
                    eTooth.isCutting = true;
                    break;
            }
        }

        private void translateToothControllerCommands(string TId, string tRegion, local_state lState)
        {
            Tooth eTooth = wybranyPacjent.getTooth(TId);
            ToothRegion eToothRegion = eTooth.getRegion(tRegion);

            switch (lState)
            {
                case local_state.normal:
                    eToothRegion.hasCavity = false;
                    eToothRegion.hasFulfillment = false;
                    break;
                case local_state.fulfillment:
                    eToothRegion.hasCavity = false;
                    eToothRegion.hasFulfillment = true;
                    break;
                case local_state.cavity:
                    eToothRegion.hasCavity = true;
                    eToothRegion.hasFulfillment = false;
                    break;
                case local_state.fulfillmentCavity:
                    eToothRegion.hasCavity = true;
                    eToothRegion.hasFulfillment = true;
                    break;
            }
        }

        private void setTeethControllerStates()
        {
            for (int i = 0; i < 52; i++)
            {

                ToothController cTooth = DentCont.TeethControls[i];
                Tooth lTooth = wybranyPacjent.getTooth(cTooth.ToothId);

                if (lTooth.isNormal())
                {
                    cTooth.setState(tooth_state.normal);
                }
                else if (lTooth.isEndo && lTooth.hasCrown)
                {
                    cTooth.setState(tooth_state.endocrown);
                }
                else if (lTooth.isEndo)
                {
                    cTooth.setState(tooth_state.endo);
                }
                else if (lTooth.hasCrown)
                {
                    cTooth.setState(tooth_state.crown);
                }
                else if (lTooth.isExtracted)
                {
                    cTooth.setState(tooth_state.extracted);
                }
                else if (lTooth.isCutting)
                {
                    cTooth.setState(tooth_state.cutting);
                }
                else if (lTooth.isStopped)
                {
                    cTooth.setState(tooth_state.stopped);
                }

                //****************************************

                if(lTooth.farther.hasCavity && lTooth.farther.hasFulfillment)
                {
                    cTooth.farther.setState(local_state.fulfillmentCavity);
                }
                else if (lTooth.farther.hasCavity)
                {
                    cTooth.farther.setState(local_state.cavity);
                }
                else if (lTooth.farther.hasFulfillment)
                {
                    cTooth.farther.setState(local_state.fulfillment);
                }
                else
                {
                    cTooth.farther.setState(local_state.normal);
                }

                if (lTooth.closer.hasCavity && lTooth.closer.hasFulfillment)
                {
                    cTooth.closer.setState(local_state.fulfillmentCavity);
                }
                else if (lTooth.closer.hasCavity)
                {
                    cTooth.closer.setState(local_state.cavity);
                }
                else if (lTooth.closer.hasFulfillment)
                {
                    cTooth.closer.setState(local_state.fulfillment);
                }
                else
                {
                    cTooth.closer.setState(local_state.normal);
                }

                if (lTooth.top.hasCavity && lTooth.top.hasFulfillment)
                {
                    cTooth.top.setState(local_state.fulfillmentCavity);
                }
                else if (lTooth.top.hasCavity)
                {
                    cTooth.top.setState(local_state.cavity);
                }
                else if (lTooth.top.hasFulfillment)
                {
                    cTooth.top.setState(local_state.fulfillment);
                }
                else
                {
                    cTooth.top.setState(local_state.normal);
                }

                if (lTooth.buccal.hasCavity && lTooth.buccal.hasFulfillment)
                {
                    cTooth.buccal.setState(local_state.fulfillmentCavity);
                }
                else if (lTooth.buccal.hasCavity)
                {
                    cTooth.buccal.setState(local_state.cavity);
                }
                else if (lTooth.buccal.hasFulfillment)
                {
                    cTooth.buccal.setState(local_state.fulfillment);
                }
                else
                {
                    cTooth.buccal.setState(local_state.normal);
                }

                if (lTooth.palatal.hasCavity && lTooth.palatal.hasFulfillment)
                {
                    cTooth.palatal.setState(local_state.fulfillmentCavity);
                }
                else if (lTooth.palatal.hasCavity)
                {
                    cTooth.palatal.setState(local_state.cavity);
                }
                else if (lTooth.palatal.hasFulfillment)
                {
                    cTooth.palatal.setState(local_state.fulfillment);
                }
                else
                {
                    cTooth.palatal.setState(local_state.normal);
                }



            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            
            bs.DataSource = wybranyPacjent.itsTreatments;        
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns["itsDate"].DisplayIndex = 1;
            dataGridView1.Columns["itsHour"].DisplayIndex = 2;
            dataGridView1.Columns["RefTooth"].DisplayIndex = 3;
            dataGridView1.Columns["Recognition"].DisplayIndex = 4;
            dataGridView1.Columns["itsDescription"].DisplayIndex = 5;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns["Patient"].Visible = false;
            dataGridView1.Columns["itsDate"].HeaderText = "Data";
            dataGridView1.Columns["itsDate"].FillWeight = 14;
            dataGridView1.Columns["itsDate"].CellTemplate.ToolTipText = "dd-MM-YYYY";
            ((DataGridViewTextBoxColumn)dataGridView1.Columns["itsDate"]).MaxInputLength = 10;
            dataGridView1.Columns["itsHour"].HeaderText = "Godz.";
            dataGridView1.Columns["itsHour"].FillWeight = 11;
            dataGridView1.Columns["itsHour"].CellTemplate.ToolTipText = "hh:mm";
            ((DataGridViewTextBoxColumn)dataGridView1.Columns["itsHour"]).MaxInputLength = 5;
            dataGridView1.Columns["RefTooth"].HeaderText = "Ząb";
            dataGridView1.Columns["RefTooth"].FillWeight = 10;
            dataGridView1.Columns["Recognition"].HeaderText = "Rozpoznanie";
            dataGridView1.Columns["Recognition"].FillWeight = 25;
            dataGridView1.Columns["Recognition"].Visible = true;
            dataGridView1.Columns["itsDescription"].HeaderText = "Leczenie i zalecenia";
            dataGridView1.Columns["itsDescription"].FillWeight = 40;
            dataGridView1.Visible = true;
            
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            bs.DataSource = wybranyPacjent.itsTreatmentPlans;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns["itsDate"].DisplayIndex = 1;
            dataGridView1.Columns["itsHour"].DisplayIndex = 2;
            dataGridView1.Columns["RefTooth"].DisplayIndex = 3;
            //dataGridView1.Columns["Recognition"].DisplayIndex = 4;
            dataGridView1.Columns["itsDescription"].DisplayIndex = 4;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns["Patient"].Visible = false;
            dataGridView1.Columns["itsDate"].HeaderText = "Data";
            dataGridView1.Columns["itsDate"].FillWeight = 14;
            dataGridView1.Columns["itsDate"].CellTemplate.ToolTipText = "dd-MM-YYYY";
            dataGridView1.Columns["itsHour"].HeaderText = "Godz.";
            dataGridView1.Columns["itsHour"].FillWeight = 11;
            dataGridView1.Columns["itsHour"].CellTemplate.ToolTipText = "hh:mm";
            ((DataGridViewTextBoxColumn)dataGridView1.Columns["itsHour"]).MaxInputLength = 5;
            dataGridView1.Columns["RefTooth"].HeaderText = "Ząb";
            dataGridView1.Columns["RefTooth"].FillWeight = 10;
            //dataGridView1.Columns["Recognition"].Visible = false;
            dataGridView1.Columns["itsDescription"].HeaderText = "Plan leczenia";
            dataGridView1.Columns["itsDescription"].FillWeight = 65;
            dataGridView1.Visible = true;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
            if (dgv.SelectedCells[0].OwningColumn.DisplayIndex == 1)
            {
                if(!validDate(e.FormattedValue.ToString()))
                {
                    errorProvider1.SetError(dataGridView1, "Niepoprawny format daty!");
                    e.Cancel = true;
                }
            }
            if(dgv.SelectedCells[0].OwningColumn.DisplayIndex == 2)
            {
                if (!validTime(e.FormattedValue.ToString()))
                {
                    errorProvider1.SetError(dataGridView1, "Niepoprawny format godziny!");
                    e.Cancel = true;
                }
            }
        }

        bool validDate(string Date)
        {
            DateTime dateValue;
            System.Globalization.CultureInfo  enUS = new System.Globalization.CultureInfo("en-US");

            return (DateTime.TryParseExact(Date, "dd-MM-yyyy", enUS, System.Globalization.DateTimeStyles.None, out dateValue)) ;

                
        }

        bool validTime(string Time)
        {
            DateTime dateValue;
            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");

            return (DateTime.TryParseExact(Time, "HH:mm", enUS, System.Globalization.DateTimeStyles.None, out dateValue));


        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.SetError(dataGridView1, "");
        }

        private void b_wywiad_Click(object sender, EventArgs e)
        {
            zrobWywiad();
        }

        private void zrobWywiad()
        {
            wywiad wywiad_form = new wywiad(wybranyPacjent, listaChorob);
            wywiad_form.addDiseaseCallback = new diseaseDelegate(dodajChorobe);
            wywiad_form.removeDiseaseCallback = new diseaseDelegate(usunChorobe);
            wywiad_form.ShowDialog();
        }

        private void dodajChorobe(string choroba)
        {
            if (isDatabaseAvailable)
            {
            }
            wybranyPacjent.itsDiseases.Add(listaChorob.Where(lch => String.Equals(lch.itsName, choroba)).Single());
        }

        private void usunChorobe(string choroba)
        {
            if (isDatabaseAvailable)
            {
            }
            wybranyPacjent.itsDiseases.Remove(listaChorob.Where(lch => String.Equals(lch.itsName, choroba)).Single());
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDatabaseAvailable)
            {
                Database.SaveChanges();
            }
            else
            {
                BinarySerialization.WriteToBinaryFile("slow_dent_data.bin", listaPacjentow);
            }
        }

        private void Main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDatabaseAvailable)
            {
                Database.SaveChanges();
            }
            else
            {
                BinarySerialization.WriteToBinaryFile("slow_dent_data.bin", listaPacjentow);
            }
        }
    }
}
