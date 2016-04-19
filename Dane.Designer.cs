namespace Slow_Dent_Desktop
{
    partial class Dane
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_noDatabase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button2.Location = new System.Drawing.Point(247, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Wyjdź";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_server
            // 
            this.tb_server.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Slow_Dent_Desktop.Properties.Settings.Default, "FileMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_server.Enabled = global::Slow_Dent_Desktop.Properties.Settings.Default.FileMode;
            this.tb_server.Location = new System.Drawing.Point(131, 47);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(191, 20);
            this.tb_server.TabIndex = 3;
            this.tb_server.Text = "OWLIKTUK-HP\\SQLEXPRESS";
            // 
            // tb_user
            // 
            this.tb_user.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Slow_Dent_Desktop.Properties.Settings.Default, "FileMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_user.Enabled = global::Slow_Dent_Desktop.Properties.Settings.Default.FileMode;
            this.tb_user.Location = new System.Drawing.Point(131, 73);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(191, 20);
            this.tb_user.TabIndex = 4;
            this.tb_user.Text = "sa";
            // 
            // tb_pass
            // 
            this.tb_pass.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Slow_Dent_Desktop.Properties.Settings.Default, "FileMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_pass.Enabled = global::Slow_Dent_Desktop.Properties.Settings.Default.FileMode;
            this.tb_pass.Location = new System.Drawing.Point(131, 99);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.PasswordChar = '*';
            this.tb_pass.Size = new System.Drawing.Size(191, 20);
            this.tb_pass.TabIndex = 5;
            this.tb_pass.Text = "ssd_AG1202";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nazwa serwera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwa użytkownika";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hasło";
            // 
            // cb_noDatabase
            // 
            this.cb_noDatabase.AutoSize = true;
            this.cb_noDatabase.Checked = global::Slow_Dent_Desktop.Properties.Settings.Default.FileMode;
            this.cb_noDatabase.Location = new System.Drawing.Point(131, 24);
            this.cb_noDatabase.Name = "cb_noDatabase";
            this.cb_noDatabase.Size = new System.Drawing.Size(132, 17);
            this.cb_noDatabase.TabIndex = 2;
            this.cb_noDatabase.Text = "Połącz z bazą danych";
            this.cb_noDatabase.UseVisualStyleBackColor = true;
            this.cb_noDatabase.CheckedChanged += new System.EventHandler(this.cb_noDatabase_CheckedChanged);
            // 
            // Dane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 167);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_server);
            this.Controls.Add(this.cb_noDatabase);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Dane";
            this.Text = "Slow Dent Desktop - wybierz źródło danych";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dane_FormClosing);
            this.Load += new System.EventHandler(this.Dane_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cb_noDatabase;
        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}