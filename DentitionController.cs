using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Slow_Dent_Desktop
{
    class DentitionController : GroupBox
    {
        public ToothController[] TeethControls { get; set; }
        private Label[] teethNumeration;

        public DentitionController(int LocX, int LocY)
        {
            
            this.Size = new System.Drawing.Size(588, 183);
            this.MinimumSize = new System.Drawing.Size(565, 183);
            this.Anchor = AnchorStyles.Bottom;
            this.Location = new System.Drawing.Point(12+(LocX -620)/2, 298+LocY-520);
            this.Text = "Uzębienie";
            this.Font = new System.Drawing.Font(Font.FontFamily, 10);


            TeethControls = new ToothController[52] {  new ToothController("18",10,20), new ToothController("17", 45,20), new ToothController("16", 80,20), new ToothController("15", 115,20), new ToothController("14", 150,20), new ToothController("13", 185,20), new ToothController("12", 220,20), new ToothController("11", 255,20),
                                                        new ToothController("21", 300,20), new ToothController("22", 335,20), new ToothController("23", 370,20), new ToothController("24", 405,20), new ToothController("25", 440,20), new ToothController("26", 475,20), new ToothController("27", 510,20), new ToothController("28", 545,20),
                                                        new ToothController("48",10, 55), new ToothController("47", 45, 55), new ToothController("46", 80, 55), new ToothController("45", 115, 55), new ToothController("44", 150, 55), new ToothController("43", 185, 55), new ToothController("42", 220, 55), new ToothController("41", 255, 55),
                                                        new ToothController("31", 300, 55), new ToothController("32", 335, 55), new ToothController("33", 370, 55), new ToothController("34", 405, 55), new ToothController("35", 440, 55), new ToothController("36", 475, 55), new ToothController("37", 510, 55), new ToothController("38", 545, 55),

                                                        new ToothController("55", 115, 100), new ToothController("54", 150, 100), new ToothController("53", 185, 100), new ToothController("52", 220, 100), new ToothController("51", 255, 100),
                                                        new ToothController("61", 300, 100), new ToothController("62", 335, 100), new ToothController("63", 370, 100), new ToothController("64", 405, 100), new ToothController("65", 440, 100), 
                                                        new ToothController("85", 115, 135), new ToothController("84", 150, 135), new ToothController("83", 185, 135), new ToothController("82", 220, 135), new ToothController("81", 255, 135),
                                                        new ToothController("71", 300, 135), new ToothController("72", 335, 135), new ToothController("73", 370, 135), new ToothController("74", 405, 135), new ToothController("75", 440, 135) };

            for (int i = 0; i < 52; i++)
            {
                this.Controls.Add(TeethControls[i]);
            }

            teethNumeration = new Label[16];

            for (int i = 0; i < 8; i++)
            {
                teethNumeration[i] = new Label();                
                teethNumeration[i].Location = new System.Drawing.Point(20 + i * 35, 85);
                teethNumeration[i].Font = new System.Drawing.Font(Font.FontFamily, 9);
                teethNumeration[i].Text = (8- i).ToString();
                teethNumeration[i].AutoSize = true;
                this.Controls.Add(teethNumeration[i]);
            }

            for (int i = 8; i < 16; i++)
            {
                teethNumeration[i] = new Label();
                teethNumeration[i].Location = new System.Drawing.Point(30 + i * 35, 85);
                teethNumeration[i].Font = new System.Drawing.Font(Font.FontFamily, 9);
                teethNumeration[i].Text = (i-7).ToString();
                teethNumeration[i].AutoSize = true;
                this.Controls.Add(teethNumeration[i]);
            }


        }

        public void setToothDelegates(ToothDelegate toothMethod, ToothPartDelegate partMethod)
        {
            for (int i = 0; i < 52; i++)
            {
                TeethControls[i].ToothChanged = toothMethod;
                TeethControls[i].ToothPartChanged = partMethod;
            }

        }
    }
}
