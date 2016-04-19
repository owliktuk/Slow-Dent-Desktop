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

namespace Slow_Dent_Desktop
{
    public partial class PL_form : Form
    {

        public List<Patient> Pacjenci;
        public Patient wybranyPacjent;
        private ListViewColumnSorter lvwColumnSorter;

        public PatientDelegate updatePatientonMainWindow;
        public EmptyDelegate refreshPatientonMainWindow;
        public PatientDelegate patientRemovedCallback;

        public PL_form(List<Patient> listaPacjentow)
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lv_listapacjentow.ListViewItemSorter = lvwColumnSorter;

            Pacjenci = listaPacjentow;

            enableButtons();

            //fill ListView
            int liczbaPacjentow = Pacjenci.Count();
            string[] row = new string[4];

            foreach(Patient Pacjent in listaPacjentow)
            {
                row[0] = Pacjent.itsName + " " + Pacjent.itsSurname;
                row[1] = Pacjent.itsBirthDate;
                row[2] = Pacjent.itsAddress.itsStreet + " " + Pacjent.itsAddress.itsStreetNumber;
                row[3] = Pacjent.PatientId.ToString();
                var listViewItem = new ListViewItem(row);
                lv_listapacjentow.Items.Add(listViewItem);
            }

        }

        private void enableButtons()
        {

            if (lv_listapacjentow.SelectedItems.Count > 0)
            {
                PL_edytuj_button.Enabled = true;
                PL_usuń_button.Enabled = true;
                PL_wybierz_button.Enabled = true;
            }
            else
            {
                PL_edytuj_button.Enabled = false;
                PL_usuń_button.Enabled = false;
                PL_wybierz_button.Enabled = false;
            }
        }

        private void updatePatientOnListView(Patient epac)
        {
            lv_listapacjentow.SelectedItems[0].SubItems[0].Text = epac.itsName + " " + epac.itsSurname;
            lv_listapacjentow.SelectedItems[0].SubItems[1].Text = epac.itsBirthDate;
            lv_listapacjentow.SelectedItems[0].SubItems[2].Text = epac.itsAddress.itsStreet + " " + epac.itsAddress.itsStreetNumber;
            enableButtons();
        }

        private void PL_edytuj_button_Click(object sender, EventArgs e)
        {
            int IdPacjenta = int.Parse(lv_listapacjentow.SelectedItems[0].SubItems[3].Text);
            wybranyPacjent = Pacjenci.Single(p => p.PatientId == IdPacjenta);

            Patient_form edytujPacjentaForm = new Patient_form(wybranyPacjent);
            edytujPacjentaForm.EditPatientCallback = new PatientDelegate(updatePatientOnListView);
            edytujPacjentaForm.ShowDialog();   

        }

        private void lv_listapacjentow_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lv_listapacjentow.Sort();
        }

        private void PL_usuń_button_Click(object sender, EventArgs e)
        {
            int IdPacjenta = int.Parse(lv_listapacjentow.SelectedItems[0].SubItems[3].Text);
            wybranyPacjent = Pacjenci.Single(p => p.PatientId == IdPacjenta);
            patientRemovedCallback(wybranyPacjent);
            Pacjenci.Remove(wybranyPacjent);
            lv_listapacjentow.SelectedItems[0].Remove();            

            enableButtons();
        }

        private void lv_listapacjentow_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            enableButtons();
        }

        private void PL_wybierz_button_Click(object sender, EventArgs e)
        {
            int IdPacjenta = int.Parse(lv_listapacjentow.SelectedItems[0].SubItems[3].Text);
            wybranyPacjent = Pacjenci.Single(p => p.PatientId == IdPacjenta);
            updatePatientonMainWindow(wybranyPacjent);
        }

        private void PL_anuluj_button_Click(object sender, EventArgs e)
        {
            refreshPatientonMainWindow();
        }
    }
}
