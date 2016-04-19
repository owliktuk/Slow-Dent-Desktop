using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Slow_Dent_Desktop
{
    public partial class Patient_form : Form
    {
        public PatientDelegate AddPatientCallback;
        public PatientDelegate EditPatientCallback;

        Patient pacjent;
        string trybOkna;

        public Patient_form()
        {
            InitializeComponent();
            trybOkna = "Add";
            this.Text = "Dodawanie nowego pacjenta";

        }

        public Patient_form(Patient edytowanyPacjent)
        {
            InitializeComponent();
            pacjent = edytowanyPacjent;
            trybOkna = "Edit";
            this.Text = "Edytowanie pacjenta";

            tb_imie.Text = edytowanyPacjent.itsName;
            tb_nazwisko.Text = edytowanyPacjent.itsSurname;
            tb_pesel.Text = edytowanyPacjent.itsPESEL;
            tb_tel.Text = edytowanyPacjent.itsTelephone;
            tb_ulica.Text = edytowanyPacjent.itsAddress.itsStreet;
            tb_numer.Text = edytowanyPacjent.itsAddress.itsStreetNumber;
            tb_kod.Text = edytowanyPacjent.itsAddress.itsPostCode;
            tb_miasto.Text = edytowanyPacjent.itsAddress.itsCity;
            tb_panstwo.Text = edytowanyPacjent.itsAddress.itsCountry;
            dtp_birth.Value = DateTime.Parse(edytowanyPacjent.itsBirthDate);
            PF_SaveAndQuest.Enabled = false;
        }

        private void PF_Save_Click(object sender, EventArgs e)
        {
            if (acceptPatientData())
            {

                if (trybOkna == "Add")
                {
                    Address adres = new Address(tb_ulica.Text, tb_numer.Text, tb_kod.Text, tb_miasto.Text, tb_panstwo.Text);
                    pacjent = new Patient(tb_imie.Text, tb_nazwisko.Text, tb_pesel.Text, adres, tb_tel.Text, dtp_birth.Value.ToString("yyyy-MM-dd"));
                    AddPatientCallback(pacjent);
                }

                if (trybOkna == "Edit")
                {

                    pacjent.itsName = tb_imie.Text;
                    pacjent.itsSurname = tb_nazwisko.Text;
                    pacjent.itsPESEL = tb_pesel.Text;
                    pacjent.itsTelephone = tb_tel.Text;
                    pacjent.itsAddress.itsStreet = tb_ulica.Text;
                    pacjent.itsAddress.itsStreetNumber = tb_numer.Text;
                    pacjent.itsAddress.itsPostCode = tb_kod.Text;
                    pacjent.itsAddress.itsCity = tb_miasto.Text;
                    pacjent.itsAddress.itsCountry = tb_panstwo.Text;
                    pacjent.itsBirthDate = dtp_birth.Value.ToString("yyyy-MM-dd");
                    EditPatientCallback(pacjent);

                }

            }
            else
            {
                MessageBox.Show("Podanie imienia i nazwiska pacjenta jest obowiązkowe.");
                this.DialogResult = DialogResult.None;
            }

        }

        private bool acceptPatientData()
        {
            if (tb_imie.TextLength != 0 && tb_nazwisko.TextLength != 0)
                return true;
            else
                return false;
        }

        private void PF_SaveAndQuest_Click(object sender, EventArgs e)
        {
            PF_Save_Click(sender, e);
        }
    }
}
