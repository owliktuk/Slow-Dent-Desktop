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
    public partial class Dane : Form
    {
        public databaseConnectionDelegate connectToDatabase;
        public EmptyDelegate readFromFile;

        public Dane()
        {

            InitializeComponent();
            //cb_noDatabase.Checked = Properties.Settings.Default.FileMode;
            //tb_pass.Enabled = !Properties.Settings.Default.FileMode;
            //tb_user.Enabled = !Properties.Settings.Default.FileMode;
            //tb_server.Enabled = !Properties.Settings.Default.FileMode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!cb_noDatabase.Checked)
            {
                readFromFile();
                this.Close();
            }
            else
            {
                bool connectionEstablished = connectToDatabase(tb_server.Text, tb_user.Text, tb_pass.Text);
                if (connectionEstablished)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie udało się nawiązać połączenia z bazą danych. Sprawdź poprawność danych.");
                }
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cb_noDatabase_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_noDatabase.Checked == true)
            {
                tb_user.Enabled = true;
                tb_server.Enabled = true;
                tb_pass.Enabled = true;
            }
            else
            {
                tb_user.Enabled = false;
                tb_server.Enabled = false;
                tb_pass.Enabled = false;
            }
        }

        private void Dane_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FileMode = cb_noDatabase.Checked;
            Properties.Settings.Default.Save();
        }

        private void Dane_Load(object sender, EventArgs e)
        {
            
        }
    }
}
