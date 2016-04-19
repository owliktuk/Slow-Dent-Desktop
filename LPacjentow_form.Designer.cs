namespace Slow_Dent_Desktop
{
    partial class PL_form
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
            this.lv_listapacjentow = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PL_usuń_button = new System.Windows.Forms.Button();
            this.PL_edytuj_button = new System.Windows.Forms.Button();
            this.PL_anuluj_button = new System.Windows.Forms.Button();
            this.PL_wybierz_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv_listapacjentow
            // 
            this.lv_listapacjentow.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_listapacjentow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lv_listapacjentow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_listapacjentow.FullRowSelect = true;
            this.lv_listapacjentow.Location = new System.Drawing.Point(7, 45);
            this.lv_listapacjentow.MultiSelect = false;
            this.lv_listapacjentow.Name = "lv_listapacjentow";
            this.lv_listapacjentow.Size = new System.Drawing.Size(538, 216);
            this.lv_listapacjentow.TabIndex = 0;
            this.lv_listapacjentow.UseCompatibleStateImageBehavior = false;
            this.lv_listapacjentow.View = System.Windows.Forms.View.Details;
            this.lv_listapacjentow.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_listapacjentow_ColumnClick);
            this.lv_listapacjentow.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_listapacjentow_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Imię i nazwisko";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data urodzenia";
            this.columnHeader2.Width = 155;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ulica";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id pacjenta";
            this.columnHeader4.Width = 75;
            // 
            // PL_usuń_button
            // 
            this.PL_usuń_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PL_usuń_button.Enabled = false;
            this.PL_usuń_button.Location = new System.Drawing.Point(341, 267);
            this.PL_usuń_button.Name = "PL_usuń_button";
            this.PL_usuń_button.Size = new System.Drawing.Size(99, 31);
            this.PL_usuń_button.TabIndex = 1;
            this.PL_usuń_button.Text = "Usuń";
            this.PL_usuń_button.UseVisualStyleBackColor = true;
            this.PL_usuń_button.Click += new System.EventHandler(this.PL_usuń_button_Click);
            // 
            // PL_edytuj_button
            // 
            this.PL_edytuj_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PL_edytuj_button.Enabled = false;
            this.PL_edytuj_button.Location = new System.Drawing.Point(236, 267);
            this.PL_edytuj_button.Name = "PL_edytuj_button";
            this.PL_edytuj_button.Size = new System.Drawing.Size(99, 29);
            this.PL_edytuj_button.TabIndex = 2;
            this.PL_edytuj_button.Text = "Edytuj";
            this.PL_edytuj_button.UseVisualStyleBackColor = true;
            this.PL_edytuj_button.Click += new System.EventHandler(this.PL_edytuj_button_Click);
            // 
            // PL_anuluj_button
            // 
            this.PL_anuluj_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PL_anuluj_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PL_anuluj_button.Location = new System.Drawing.Point(446, 268);
            this.PL_anuluj_button.Name = "PL_anuluj_button";
            this.PL_anuluj_button.Size = new System.Drawing.Size(99, 30);
            this.PL_anuluj_button.TabIndex = 3;
            this.PL_anuluj_button.Text = "Anuluj";
            this.PL_anuluj_button.UseVisualStyleBackColor = true;
            this.PL_anuluj_button.Click += new System.EventHandler(this.PL_anuluj_button_Click);
            // 
            // PL_wybierz_button
            // 
            this.PL_wybierz_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PL_wybierz_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PL_wybierz_button.Enabled = false;
            this.PL_wybierz_button.Location = new System.Drawing.Point(131, 267);
            this.PL_wybierz_button.Name = "PL_wybierz_button";
            this.PL_wybierz_button.Size = new System.Drawing.Size(99, 29);
            this.PL_wybierz_button.TabIndex = 4;
            this.PL_wybierz_button.Text = "Wybierz";
            this.PL_wybierz_button.UseVisualStyleBackColor = true;
            this.PL_wybierz_button.Click += new System.EventHandler(this.PL_wybierz_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista pacjentów";
            // 
            // PL_form
            // 
            this.AcceptButton = this.PL_wybierz_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.PL_anuluj_button;
            this.ClientSize = new System.Drawing.Size(548, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PL_wybierz_button);
            this.Controls.Add(this.PL_anuluj_button);
            this.Controls.Add(this.PL_edytuj_button);
            this.Controls.Add(this.PL_usuń_button);
            this.Controls.Add(this.lv_listapacjentow);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(556, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(556, 200);
            this.Name = "PL_form";
            this.Text = "Lista pacjentów - Slow Dent Desktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_listapacjentow;
        private System.Windows.Forms.Button PL_usuń_button;
        private System.Windows.Forms.Button PL_edytuj_button;
        private System.Windows.Forms.Button PL_anuluj_button;
        private System.Windows.Forms.Button PL_wybierz_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}