namespace Slow_Dent_Desktop
{
    partial class wywiad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_ciaza = new System.Windows.Forms.CheckBox();
            this.flp_choroby = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_leki = new System.Windows.Forms.TextBox();
            this.tb_uwagi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_ciaza
            // 
            this.cb_ciaza.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_ciaza.AutoSize = true;
            this.cb_ciaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_ciaza.Location = new System.Drawing.Point(15, 235);
            this.cb_ciaza.Name = "cb_ciaza";
            this.cb_ciaza.Size = new System.Drawing.Size(43, 23);
            this.cb_ciaza.TabIndex = 18;
            this.cb_ciaza.Text = "Ciąża";
            this.cb_ciaza.UseVisualStyleBackColor = true;
            this.cb_ciaza.CheckedChanged += new System.EventHandler(this.cb_ciaza_CheckedChanged);
            // 
            // flp_choroby
            // 
            this.flp_choroby.Location = new System.Drawing.Point(12, 53);
            this.flp_choroby.Name = "flp_choroby";
            this.flp_choroby.Size = new System.Drawing.Size(289, 176);
            this.flp_choroby.TabIndex = 19;
            // 
            // tb_leki
            // 
            this.tb_leki.Location = new System.Drawing.Point(12, 290);
            this.tb_leki.Multiline = true;
            this.tb_leki.Name = "tb_leki";
            this.tb_leki.Size = new System.Drawing.Size(289, 63);
            this.tb_leki.TabIndex = 20;
            // 
            // tb_uwagi
            // 
            this.tb_uwagi.Location = new System.Drawing.Point(12, 381);
            this.tb_uwagi.Multiline = true;
            this.tb_uwagi.Name = "tb_uwagi";
            this.tb_uwagi.Size = new System.Drawing.Size(289, 63);
            this.tb_uwagi.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 38);
            this.label1.TabIndex = 22;
            this.label1.Text = "Piotr Graczyk \r\nogólny stan zdrowia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Leki";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(11, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Uwagi";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(206, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 30);
            this.button1.TabIndex = 25;
            this.button1.Text = "Gotowe";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // wywiad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_uwagi);
            this.Controls.Add(this.tb_leki);
            this.Controls.Add(this.flp_choroby);
            this.Controls.Add(this.cb_ciaza);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wywiad";
            this.ShowIcon = false;
            this.Text = "Wywiad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wywiad_FormClosing);
            this.Load += new System.EventHandler(this.wywiad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_ciaza;
        private System.Windows.Forms.FlowLayoutPanel flp_choroby;
        private System.Windows.Forms.TextBox tb_leki;
        private System.Windows.Forms.TextBox tb_uwagi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}