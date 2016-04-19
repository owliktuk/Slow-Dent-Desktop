using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slow_Dent_Desktop
{
    public enum local_state { None, normal, cavity,  fulfillment, fulfillmentCavity}
    public enum tooth_state { normal, extracted,  endo, cutting, crown, stopped, endocrown}

    public delegate void ToothDelegate(string ToothId, tooth_state tState);
    public delegate void ToothPartDelegate(string ToothId, string tRegion, local_state lState);

    public class ToothController : Panel
    {
        public ToothDelegate ToothChanged;
        public ToothPartDelegate ToothPartChanged;

        public string ToothId { get; }
        private tooth_state itsState;

        public ToothPartController farther { get; set; }
        public ToothPartController closer { get; set; }
        public ToothPartController top { get; set; }
        public ToothPartController buccal { get; set; }
        public ToothPartController palatal { get; set; }
        private int fartherPositionX;
        private int closerPositionX;
        private int buccalPositionY;
        private int palatalPositionY;


        public ToothController(string ToothId, int locX, int locY)
        {
            this.ToothId = ToothId;

            setToothOrientation(ToothId);

            this.Size = new System.Drawing.Size(30, 30);
            this.Location = new System.Drawing.Point(locX, locY);
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = Properties.Resources.normal;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            farther = new ToothPartController("farther", fartherPositionX, 10);
            closer = new ToothPartController("closer", closerPositionX, 10);
            top = new ToothPartController("top", 10, 10);
            buccal = new ToothPartController("buccal", 10, buccalPositionY);
            palatal = new ToothPartController("palatal", 10, palatalPositionY);

            farther.MouseDown += new MouseEventHandler(this.changeState);
            closer.MouseDown += new MouseEventHandler(this.changeState);
            top.MouseDown += new MouseEventHandler(this.changeState);
            buccal.MouseDown += new MouseEventHandler(this.changeState);
            palatal.MouseDown += new MouseEventHandler(this.changeState);
            this.MouseDown += new MouseEventHandler(changeState);

            this.Controls.Add(farther);
            this.Controls.Add(closer);
            this.Controls.Add(top);
            this.Controls.Add(buccal);
            this.Controls.Add(palatal);

        }

        public void changeState(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (itsState)
                {
                    case tooth_state.normal:
                        setState(tooth_state.extracted);
                        break;
                    case tooth_state.extracted:
                        setState(tooth_state.endo);
                        break;
                    case tooth_state.endo:
                        setState(tooth_state.crown);
                        break;
                    case tooth_state.crown:
                        setState(tooth_state.endocrown);
                        break;
                    case tooth_state.endocrown:
                        setState(tooth_state.cutting);
                        break;
                    case tooth_state.cutting:
                        setState(tooth_state.stopped);
                        break;
                    case tooth_state.stopped:
                        setState(tooth_state.normal);
                        break;

                }

                ToothChanged(ToothId, itsState);

            }
            else if(sender is ToothPartController)
            {
                ToothPartController tempButton;
                tempButton = (ToothPartController)sender;
                local_state newLocalState = tempButton.changeState();
                string toothPartRegion = tempButton.itsRegion;
                ToothPartChanged(ToothId, toothPartRegion, newLocalState);
            }
        }

        public void setState(tooth_state tState)
        {
            itsState = tState;

            switch (tState)
            {
                case tooth_state.normal:
                    showToothPartStates();
                    this.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("normal");
                     
                    this.BackColor = System.Drawing.Color.Transparent;
                    break;

                case tooth_state.extracted:
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.extracted;
                    break;

                case tooth_state.endo:
                    showToothPartStates();
                    this.BackgroundImage = Properties.Resources.endo;
                    break;

                case tooth_state.crown:
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.crown;
                    break;

                case tooth_state.endocrown:
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.endocrown;
                    break;

                case tooth_state.cutting:
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.cutting;
                    break;

                case tooth_state.stopped:
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.stopped;             
                    break;

            }
        }


        private void setToothOrientation(string tooth)
        {
            char quart = tooth.First();

            if (quart == '1' || quart == '5')
            {
                fartherPositionX = 0;
                closerPositionX = 20;
                buccalPositionY = 0;
                palatalPositionY = 20;
            }
            else if(quart == '2' || quart == '6')
            {
                fartherPositionX = 20;
                closerPositionX = 0;
                buccalPositionY = 0;
                palatalPositionY = 20;
            }
            else if (quart == '3' || quart == '7')
            {
                fartherPositionX = 0;
                closerPositionX = 20;
                buccalPositionY = 20;
                palatalPositionY = 0;
            }
            else if (quart == '4' || quart == '8')
            {
                fartherPositionX = 20;
                closerPositionX = 0;
                buccalPositionY = 20;
                palatalPositionY = 0;
            }
        }    
        
        private void hideToothPartStates()
        {
            farther.Visible = false;
            closer.Visible = false;
            top.Visible = false;
            buccal.Visible = false;
            palatal.Visible = false;
        }

        private void showToothPartStates()
        {
            farther.Visible = true;
            closer.Visible = true;
            top.Visible = true;
            buccal.Visible = true;
            palatal.Visible = true;
        }

    }

    public class ToothPartController : Button
    {
        

        private local_state itsState;
        public string itsRegion { get; }

        public ToothPartController(string region, int locX, int locY)
        {
            itsRegion = region;
            itsState = local_state.normal;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.Color.Transparent;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;

            this.Height = 10;
            this.Width = 10;

            this.Location = new System.Drawing.Point(locX, locY);

        }

        public local_state changeState()
        {
            switch (itsState)
            {
                case local_state.normal:
                    setState(local_state.cavity);
                    break;
                case local_state.cavity:
                    setState(local_state.fulfillment);
                    break;
                case local_state.fulfillment:
                    setState(local_state.fulfillmentCavity);
                    break;
                case local_state.fulfillmentCavity:
                    setState(local_state.normal);
                    break;                                       
            }
            return itsState;
                             
        }

        public local_state getState()
        {
            return itsState;
        }

        public void setState(local_state state)
        {
            itsState = state;
            switch (state)
            {
                case local_state.normal:
                    this.BackColor = System.Drawing.Color.Transparent;
                    break;
                case local_state.cavity:
                    this.BackColor = System.Drawing.Color.Red;
                    break;
                case local_state.fulfillment:
                    this.BackColor = System.Drawing.Color.Gray;
                    break;
                case local_state.fulfillmentCavity:
                    this.BackColor = System.Drawing.Color.Violet;
                    break;
            }
    }


    }
}
