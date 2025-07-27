namespace OraclePasswordManager
{
    partial class Form1
    {
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnApplyChanges;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.GroupBox groupConnection;
        private System.Windows.Forms.GroupBox groupPasswordSettings;
        private System.Windows.Forms.RadioButton rbUnlimited;
        private System.Windows.Forms.RadioButton rbLimited;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblCopyright;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.rbUnlimited = new System.Windows.Forms.RadioButton();
            this.rbLimited = new System.Windows.Forms.RadioButton();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnUnlockAccount = new System.Windows.Forms.Button();
            this.btnResetExpiredPassword = new System.Windows.Forms.Button();
            this.btnLockAccount = new System.Windows.Forms.Button();
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.groupAccountStatus = new System.Windows.Forms.GroupBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.groupPasswordSettings = new System.Windows.Forms.GroupBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.btnApplyChanges = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.groupConnection.SuspendLayout();
            this.groupPasswordSettings.SuspendLayout();
            this.groupAccountStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(200, 105);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(250, 35);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Spoji se na Oracle bazu";
            this.toolTip1.SetToolTip(this.btnConnect, "Klikni za spajanje sa Oracle bazom");
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIpAddress.Location = new System.Drawing.Point(200, 28);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(460, 25);
            this.txtIpAddress.TabIndex = 1;
            this.txtIpAddress.Text = "127.0.0.1:1521/XEPDB1";
            this.toolTip1.SetToolTip(this.txtIpAddress, "Unesi IP adresu i servis baze, npr: 127.0.0.1:1521/XEPDB1");
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(200, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(230, 25);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "sys as sysdba";
            this.toolTip1.SetToolTip(this.txtUsername, "Unesi korisničko ime, npr: sys as sysdba ili HR");
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(510, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 25);
            this.txtPassword.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtPassword, "Unesi šifru za korisnika");
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // numDays
            // 
            this.numDays.Enabled = false;
            this.numDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDays.Location = new System.Drawing.Point(340, 66);
            this.numDays.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(60, 23);
            this.numDays.TabIndex = 11;
            this.toolTip1.SetToolTip(this.numDays, "Broj dana nakon kojih šifra istječe");
            this.numDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // rbUnlimited
            // 
            this.rbUnlimited.Checked = true;
            this.rbUnlimited.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbUnlimited.Location = new System.Drawing.Point(20, 68);
            this.rbUnlimited.Name = "rbUnlimited";
            this.rbUnlimited.Size = new System.Drawing.Size(120, 20);
            this.rbUnlimited.TabIndex = 9;
            this.rbUnlimited.TabStop = true;
            this.rbUnlimited.Text = "Neograničeno";
            this.toolTip1.SetToolTip(this.rbUnlimited, "Šifra nikad ne istječe");
            this.rbUnlimited.CheckedChanged += new System.EventHandler(this.rbUnlimited_CheckedChanged);
            // 
            // rbLimited
            // 
            this.rbLimited.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbLimited.Location = new System.Drawing.Point(190, 68);
            this.rbLimited.Name = "rbLimited";
            this.rbLimited.Size = new System.Drawing.Size(110, 20);
            this.rbLimited.TabIndex = 10;
            this.rbLimited.Text = "Ograničeno na:";
            this.toolTip1.SetToolTip(this.rbLimited, "Šifra istječe nakon određenog broja dana");
            this.rbLimited.CheckedChanged += new System.EventHandler(this.rbLimited_CheckedChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(630, 605);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(90, 25);
            this.btnAbout.TabIndex = 12;
            this.btnAbout.Text = "Više o aplikaciji";
            this.toolTip1.SetToolTip(this.btnAbout, "Prikaži informacije o aplikaciji");
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnUnlockAccount
            // 
            this.btnUnlockAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUnlockAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnlockAccount.FlatAppearance.BorderSize = 0;
            this.btnUnlockAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlockAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnlockAccount.ForeColor = System.Drawing.Color.White;
            this.btnUnlockAccount.Location = new System.Drawing.Point(20, 30);
            this.btnUnlockAccount.Name = "btnUnlockAccount";
            this.btnUnlockAccount.Size = new System.Drawing.Size(150, 35);
            this.btnUnlockAccount.TabIndex = 13;
            this.btnUnlockAccount.Text = "Otključaj nalog";
            this.toolTip1.SetToolTip(this.btnUnlockAccount, "Otključava zaključan nalog korisnika");
            this.btnUnlockAccount.UseVisualStyleBackColor = false;
            this.btnUnlockAccount.Click += new System.EventHandler(this.btnUnlockAccount_Click);
            // 
            // btnResetExpiredPassword
            // 
            this.btnResetExpiredPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnResetExpiredPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetExpiredPassword.FlatAppearance.BorderSize = 0;
            this.btnResetExpiredPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetExpiredPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetExpiredPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetExpiredPassword.Location = new System.Drawing.Point(190, 30);
            this.btnResetExpiredPassword.Name = "btnResetExpiredPassword";
            this.btnResetExpiredPassword.Size = new System.Drawing.Size(150, 35);
            this.btnResetExpiredPassword.TabIndex = 14;
            this.btnResetExpiredPassword.Text = "Resetuj šifru";
            this.toolTip1.SetToolTip(this.btnResetExpiredPassword, "Resetuje isteklu šifru na privremenu vrijednost");
            this.btnResetExpiredPassword.UseVisualStyleBackColor = false;
            this.btnResetExpiredPassword.Click += new System.EventHandler(this.btnResetExpiredPassword_Click);
            // 
            // btnLockAccount
            // 
            this.btnLockAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLockAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockAccount.FlatAppearance.BorderSize = 0;
            this.btnLockAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLockAccount.ForeColor = System.Drawing.Color.White;
            this.btnLockAccount.Location = new System.Drawing.Point(360, 30);
            this.btnLockAccount.Name = "btnLockAccount";
            this.btnLockAccount.Size = new System.Drawing.Size(150, 35);
            this.btnLockAccount.TabIndex = 15;
            this.btnLockAccount.Text = "Zaključaj nalog";
            this.toolTip1.SetToolTip(this.btnLockAccount, "Zaključava nalog korisnika");
            this.btnLockAccount.UseVisualStyleBackColor = false;
            this.btnLockAccount.Click += new System.EventHandler(this.btnLockAccount_Click);
            // 
            // groupConnection
            // 
            this.groupConnection.BackColor = System.Drawing.Color.White;
            this.groupConnection.Controls.Add(this.lblIpAddress);
            this.groupConnection.Controls.Add(this.txtIpAddress);
            this.groupConnection.Controls.Add(this.lblUsername);
            this.groupConnection.Controls.Add(this.txtUsername);
            this.groupConnection.Controls.Add(this.lblPassword);
            this.groupConnection.Controls.Add(this.txtPassword);
            this.groupConnection.Controls.Add(this.btnConnect);
            this.groupConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupConnection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupConnection.Location = new System.Drawing.Point(25, 20);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Size = new System.Drawing.Size(700, 140);
            this.groupConnection.TabIndex = 0;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "Spajanje na Oracle bazu";
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIpAddress.Location = new System.Drawing.Point(20, 30);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(141, 19);
            this.lblIpAddress.TabIndex = 0;
            this.lblIpAddress.Text = "IP/Hostname (ili TNS):";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.Location = new System.Drawing.Point(20, 68);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 19);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Korisničko ime:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(450, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(38, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Šifra:";
            // 
            // groupPasswordSettings
            // 
            this.groupPasswordSettings.BackColor = System.Drawing.Color.White;
            this.groupPasswordSettings.Controls.Add(this.lblUsers);
            this.groupPasswordSettings.Controls.Add(this.cmbUsers);
            this.groupPasswordSettings.Controls.Add(this.rbUnlimited);
            this.groupPasswordSettings.Controls.Add(this.rbLimited);
            this.groupPasswordSettings.Controls.Add(this.numDays);
            this.groupPasswordSettings.Controls.Add(this.lblDays);
            this.groupPasswordSettings.Controls.Add(this.btnApplyChanges);
            this.groupPasswordSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupPasswordSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupPasswordSettings.Location = new System.Drawing.Point(25, 175);
            this.groupPasswordSettings.Name = "groupPasswordSettings";
            this.groupPasswordSettings.Size = new System.Drawing.Size(700, 120);
            this.groupPasswordSettings.TabIndex = 1;
            this.groupPasswordSettings.TabStop = false;
            this.groupPasswordSettings.Text = "Postavke trajanja šifara";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsers.Location = new System.Drawing.Point(20, 30);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(119, 19);
            this.lblUsers.TabIndex = 7;
            this.lblUsers.Text = "Odaberi korisnika:";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUsers.Location = new System.Drawing.Point(200, 28);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(250, 25);
            this.cmbUsers.TabIndex = 8;
            // 
            // lblDays
            // 
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDays.Location = new System.Drawing.Point(410, 70);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(40, 17);
            this.lblDays.TabIndex = 12;
            this.lblDays.Text = "dana";
            // 
            // btnApplyChanges
            // 
            this.btnApplyChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnApplyChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyChanges.FlatAppearance.BorderSize = 0;
            this.btnApplyChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChanges.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplyChanges.ForeColor = System.Drawing.Color.White;
            this.btnApplyChanges.Location = new System.Drawing.Point(480, 25);
            this.btnApplyChanges.Name = "btnApplyChanges";
            this.btnApplyChanges.Size = new System.Drawing.Size(190, 35);
            this.btnApplyChanges.TabIndex = 9;
            this.btnApplyChanges.Text = "Primijeni promjene";
            this.btnApplyChanges.UseVisualStyleBackColor = false;
            this.btnApplyChanges.Click += new System.EventHandler(this.btnApplyChanges_Click);
            // 
            // groupAccountStatus
            // 
            this.groupAccountStatus.BackColor = System.Drawing.Color.White;
            this.groupAccountStatus.Controls.Add(this.btnUnlockAccount);
            this.groupAccountStatus.Controls.Add(this.btnResetExpiredPassword);
            this.groupAccountStatus.Controls.Add(this.btnLockAccount);
            this.groupAccountStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupAccountStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupAccountStatus.Location = new System.Drawing.Point(25, 305);
            this.groupAccountStatus.Name = "groupAccountStatus";
            this.groupAccountStatus.Size = new System.Drawing.Size(700, 80);
            this.groupAccountStatus.TabIndex = 2;
            this.groupAccountStatus.TabStop = false;
            this.groupAccountStatus.Text = "Upravljanje statusom naloga";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsers.Location = new System.Drawing.Point(25, 395);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(700, 180);
            this.dgvUsers.TabIndex = 10;
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 645);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(750, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Spremno za spajanje...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblCopyright.Location = new System.Drawing.Point(25, 610);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 15);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "© 2025 Hamza Delić - Sektor Informatike. Sva prava zadržana.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(750, 670);
            this.Controls.Add(this.groupConnection);
            this.Controls.Add(this.groupPasswordSettings);
            this.Controls.Add(this.groupAccountStatus);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oracle Password manager";
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.groupConnection.ResumeLayout(false);
            this.groupConnection.PerformLayout();
            this.groupPasswordSettings.ResumeLayout(false);
            this.groupPasswordSettings.PerformLayout();
            this.groupAccountStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code
        private System.Windows.Forms.Button btnUnlockAccount;
        private System.Windows.Forms.Button btnResetExpiredPassword;
        private System.Windows.Forms.Button btnLockAccount;
        private System.Windows.Forms.GroupBox groupAccountStatus;
        #endregion
    }
}
