using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public delegate void diseaseDelegate(string d);

namespace Slow_Dent_Desktop
{
    public partial class wywiad : Form
    {
        private Patient pacjent;
        public diseaseDelegate addDiseaseCallback;
        public diseaseDelegate removeDiseaseCallback;

        public wywiad(Patient pacjent, List<Disease> choroby)
        {
            InitializeComponent();

            this.pacjent = pacjent;

            int n = choroby.Count();
            int m = pacjent.itsDiseases.Count();

            for(int i = 0; i < n; i++)
            {
                CheckBox cb_choroba = new CheckBox();
                cb_choroba.Text = choroby[i].itsName;
                cb_choroba.Appearance = Appearance.Button;
                cb_choroba.FlatStyle = FlatStyle.Flat;
                cb_choroba.AutoSize = true;

                for (int j = 0; j < m; j++)
                {
                    if(pacjent.itsDiseases[j] == choroby[i])
                    {
                        cb_choroba.Checked = true;
                    }
                }

                flp_choroby.Controls.Add(cb_choroba);

                cb_choroba.CheckedChanged += new System.EventHandler(cb_choroba_CheckedChanged);
            }


            
        }

        private void cb_choroba_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = new CheckBox();
            cbx = (CheckBox)sender;

            if (cbx.Checked)
                addDiseaseCallback(cbx.Text);
            else
                removeDiseaseCallback(cbx.Text);
            
        }

        private void cb_ciaza_CheckedChanged(object sender, EventArgs e)
        {
            pacjent.isPregnant = cb_ciaza.Checked;
        }

        private void wywiad_FormClosing(object sender, FormClosingEventArgs e)
        {
            pacjent.addInfo = tb_uwagi.Text;
            pacjent.Drugs = tb_leki.Text;
        }

        private void wywiad_Load(object sender, EventArgs e)
        {
            label1.Text = pacjent.itsName + " " + pacjent.itsSurname + "\n" + "ogólny stan zdrowia";
            cb_ciaza.Checked = pacjent.isPregnant;
            tb_uwagi.Text = pacjent.addInfo;
            tb_leki.Text = pacjent.Drugs;
        }
    }
}
