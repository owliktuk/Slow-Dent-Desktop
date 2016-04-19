using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slow_Dent_Desktop
{
    public enum local_state { normal, cavity,  fulfillment, fulfillmentCavity}
    public enum tooth_state { normal, extracted,  endo, cutting, crown, stopped, endocrown}

    public class ToothController : Panel
    {
        private string ToothId;
        private tooth_state itsState;

        private ToothPart farther;
        private ToothPart closer;
        private ToothPart top;
        private ToothPart buccal;
        private ToothPart palatal;
        private int fartherPositionX;
        private int closerPositionX;
        private int buccalPositionY;
        private int palatalPositionY;

        private PictureBox picture;

        


        public ToothController(string ToothId, int locX, int locY)
        {
            this.ToothId = ToothId;
            itsState = tooth_state.normal;

            setToothPartsPositions(ToothId);

            farther = new ToothPart(fartherPositionX, 10);
            closer = new ToothPart(closerPositionX, 10);
            top = new ToothPart(10, 10);
            buccal = new ToothPart(10, buccalPositionY);
            palatal = new ToothPart(10, palatalPositionY);

            picture.Region = new System.Drawing.Region();

              System.Drawing.Rectangle fff = new System.Drawing.Rectangle();
            System.Drawing.Graphics.

            picture = new PictureBox();
            picture.Image = Properties.Resources.zab;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            farther.Parent = picture;
         

            this.Size = new System.Drawing.Size(30, 30);
            this.Location = new System.Drawing.Point(locX, locY);
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            farther.Click += new EventHandler(changeLocalState);
            closer.Click += new EventHandler(changeLocalState);
            top.Click += new EventHandler(changeLocalState);
            buccal.Click += new EventHandler(changeLocalState);
            palatal.Click += new EventHandler(changeLocalState);
            this.Click += new EventHandler(changeToothState);

            this.Controls.Add(farther);
            this.Controls.Add(closer);
            this.Controls.Add(top);
            this.Controls.Add(buccal);
            this.Controls.Add(palatal);
            this.Controls.Add(picture);

        }

        public void changeLocalState(object sender, EventArgs e)
        {
            ToothPart tempButton;
            tempButton = (ToothPart)sender;
            tempButton.changeState();
        }

        public void changeToothState(object sender, EventArgs e)
        {
            switch (itsState)
            {
                case tooth_state.normal:
                    itsState = tooth_state.extracted;
                    hideToothPartStates();
                    this.BackgroundImage = Properties.Resources.extracted;
                    break;
                case tooth_state.extracted:
                    itsState = tooth_state.endo;
                    showToothPartStates();
                    this.BackgroundImage = null;
                    break;
                case tooth_state.endo:
                    itsState = tooth_state.crown;
                    hideToothPartStates();
                    break;
                case tooth_state.crown:
                    itsState = tooth_state.endocrown;
                    hideToothPartStates();
                    break;
                case tooth_state.endocrown:
                    itsState = tooth_state.cutting;
                    hideToothPartStates();
                    break;
                case tooth_state.cutting:
                    itsState = tooth_state.stopped;
                    hideToothPartStates();
                    break;
                case tooth_state.stopped:
                    itsState = tooth_state.normal;
                    showToothPartStates();
                    break;

            }
        }
        
        private void setToothPartsPositions(string tooth)
        {
            fartherPositionX = 0;
            closerPositionX = 20;
            buccalPositionY = 0;
            palatalPositionY = 20;
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

    public class ToothPart : Control
    {
        private local_state itsState;

        public ToothPart(int locX, int locY)
        {

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

        public void changeState()
        {
            switch (itsState)
            {
                case local_state.normal:
                    itsState = local_state.cavity;
                    this.BackColor = System.Drawing.Color.Red;
                    break;
                case local_state.cavity:
                    itsState = local_state.fulfillment;
                    this.BackColor = System.Drawing.Color.Gray;
                    break;
                case local_state.fulfillment:
                    itsState = local_state.fulfillmentCavity;
                    this.BackColor = System.Drawing.Color.Violet;
                    break;
                case local_state.fulfillmentCavity:
                    itsState = local_state.normal;
                    this.BackColor = System.Drawing.Color.Transparent;
                    break;                                       
            }
                             
        }

        public local_state getState()
        {
            return itsState;
        }

        public void setState(local_state state)
        {
            itsState = state; 
        }


    }
}
