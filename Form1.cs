using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace OraclePasswordManager
{
    public partial class Form1 : Form
    {
        private OracleConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Unos podataka za konekciju
            string ipAddress = txtIpAddress.Text;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // SYSDBA/SYSOPER detekcija
            string dbaPrivilege = string.Empty;
            if (username.ToLower().EndsWith(" as sysdba"))
            {
                username = username.Substring(0, username.Length - " as sysdba".Length).Trim();
                dbaPrivilege = ";DBA Privilege=SYSDBA";
            }
            else if (username.ToLower().EndsWith(" as sysoper"))
            {
                username = username.Substring(0, username.Length - " as sysoper".Length).Trim();
                dbaPrivilege = ";DBA Privilege=SYSOPER";
            }

            // Pravi konekcioni string za Oracle bazu (podržava TNS, SID ili SERVICE_NAME)
            // Primer: 127.0.0.1:1521/XEPDB1 ili TNS ime
            string connectionString = $"User Id={username};Password={password};Data Source={ipAddress}{dbaPrivilege}";
            // Ako korisnik unese samo IP, koristi default port i servis
            if (!ipAddress.Contains("/"))
            {
                connectionString = $"User Id={username};Password={password};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={ipAddress})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))){dbaPrivilege}";
            }
            try
            {
                // Povezivanje sa Oracle bazom
                connection = new OracleConnection(connectionString);
                connection.Open();
                lblStatus.Text = "Uspješno spojen na Oracle bazu!";
                LoadUsers();  // Učitaj korisnike nakon uspešnog povezivanja
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Greška: {ex.Message}";
            }
        }

        private void LoadUsers()
        {
            // Čisti ComboBox pre novog učitavanja
            cmbUsers.Items.Clear();

            // Upit za učitavanje korisnika, profila i PASSWORD_LIFE_TIME
            string query = @"
                SELECT u.username, u.profile, p.limit, u.created, u.account_status
                FROM dba_users u
                JOIN dba_profiles p ON u.profile = p.profile
                WHERE p.resource_name = 'PASSWORD_LIFE_TIME'
                ORDER BY u.username";

            OracleCommand cmd = new OracleCommand(query, connection);
            OracleDataReader reader = cmd.ExecuteReader();

            // Kreiranje DataTable za prikazivanje u DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Profile");
            dt.Columns.Add("Password Life Time");
            dt.Columns.Add("Created");
            dt.Columns.Add("Account Status");

            while (reader.Read())
            {
                string username = reader.GetString(0);
                string profile = reader.GetString(1);
                string limit = reader.GetString(2);
                DateTime created = reader.GetDateTime(3);
                string accountStatus = reader.GetString(4);

                dt.Rows.Add(username, profile, limit, created.ToString("dd.MM.yyyy"), accountStatus);

                // Dodaj korisnike u ComboBox
                cmbUsers.Items.Add(username);
            }

            if (cmbUsers.Items.Count > 0)
            {
                cmbUsers.SelectedIndex = 0;  // Postavi prvi korisnik kao selektovan
            }
            dgvUsers.DataSource = dt;    // Poveži DataGridView sa DataTable-om
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                lblStatus.Text = "Nijedan korisnik nije odabran.";
                return;
            }
            string selectedUser = cmbUsers.SelectedItem.ToString();

            // Odredi tip profila na osnovu odabira
            string profileName;
            string passwordLifetime;
            
            if (rbUnlimited.Checked)
            {
                profileName = "UNLIMITED_PASSWORD_PROFILE";
                passwordLifetime = "UNLIMITED";
            }
            else
            {
                int days = (int)numDays.Value;
                profileName = $"PASSWORD_{days}_DAYS_PROFILE";
                passwordLifetime = days.ToString();
            }
            
            // SQL komande za kreiranje profila i primjenu na korisnika
            string createProfileQuery = $"CREATE PROFILE {profileName} LIMIT PASSWORD_LIFE_TIME {passwordLifetime}";
            string alterUserQuery = $"ALTER USER {selectedUser} PROFILE {profileName}";
            
            // Provjeri da li profil već postoji
            string checkProfileQuery = $"SELECT COUNT(*) FROM dba_profiles WHERE profile = '{profileName}' AND ROWNUM = 1";

            try
            {
                // Provjeri da li profil već postoji
                bool profileExists = false;
                using (OracleCommand checkCmd = new OracleCommand(checkProfileQuery, connection))
                {
                    object result = checkCmd.ExecuteScalar();
                    profileExists = Convert.ToInt32(result) > 0;
                }

                // Kreiraj profil samo ako ne postoji
                if (!profileExists)
                {
                    using (OracleCommand createCmd = new OracleCommand(createProfileQuery, connection))
                    {
                        createCmd.ExecuteNonQuery();
                        lblStatus.Text = $"Kreiran novi profil: {profileName}";
                    }
                }

                // Primijeni profil na odabranog korisnika
                using (OracleCommand alterCmd = new OracleCommand(alterUserQuery, connection))
                {
                    alterCmd.ExecuteNonQuery();
                }

                string message = rbUnlimited.Checked 
                    ? $"Šifra postavljena na neograničeno trajanje za korisnika: {selectedUser}"
                    : $"Šifra postavljena na {numDays.Value} dana za korisnika: {selectedUser}";
                    
                lblStatus.Text = message;
                
                // Osveži prikaz korisnika
                LoadUsers();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Greška: {ex.Message}";
            }
        }

        private void rbUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            numDays.Enabled = !rbUnlimited.Checked;
        }

        private void rbLimited_CheckedChanged(object sender, EventArgs e)
        {
            numDays.Enabled = rbLimited.Checked;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void btnUnlockAccount_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                lblStatus.Text = "Nijedan korisnik nije odabran.";
                return;
            }

            string selectedUser = cmbUsers.SelectedItem.ToString();
            
            try
            {
                // Otključaj nalog i resetuj šifru na isteknutu
                string unlockQuery = $"ALTER USER {selectedUser} ACCOUNT UNLOCK";
                OracleCommand unlockCmd = new OracleCommand(unlockQuery, connection);
                unlockCmd.ExecuteNonQuery();
                
                lblStatus.Text = $"Nalog korisnika {selectedUser} je uspešno otključan!";
                
                // Osveži prikaz korisnika
                LoadUsers();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Greška pri otključavanju naloga: {ex.Message}";
            }
        }

        private void btnResetExpiredPassword_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                lblStatus.Text = "Nijedan korisnik nije odabran.";
                return;
            }

            string selectedUser = cmbUsers.SelectedItem.ToString();
            
            try
            {
                // Generiši novu privremenu šifru
                string tempPassword = "TempPass123";
                
                // Resetuj šifru i zahtevaj promenu pri sledećem logovanju
                string resetQuery = $"ALTER USER {selectedUser} IDENTIFIED BY {tempPassword}";
                OracleCommand resetCmd = new OracleCommand(resetQuery, connection);
                resetCmd.ExecuteNonQuery();
                
                // Zahtevaj promenu šifre pri sledećem logovanju
                string expireQuery = $"ALTER USER {selectedUser} PASSWORD EXPIRE";
                OracleCommand expireCmd = new OracleCommand(expireQuery, connection);
                expireCmd.ExecuteNonQuery();
                
                lblStatus.Text = $"Šifra korisnika {selectedUser} je resetovana na '{tempPassword}' i mora biti promenjena pri sledećem logovanju.";
                
                // Osveži prikaz korisnika
                LoadUsers();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Greška pri resetovanju šifre: {ex.Message}";
            }
        }

        private void btnLockAccount_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                lblStatus.Text = "Nijedan korisnik nije odabran.";
                return;
            }

            string selectedUser = cmbUsers.SelectedItem.ToString();
            
            // Potvrdi akciju
            DialogResult result = MessageBox.Show(
                $"Da li ste sigurni da želite da zaključate nalog korisnika {selectedUser}?", 
                "Potvrda zaključavanja", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    string lockQuery = $"ALTER USER {selectedUser} ACCOUNT LOCK";
                    OracleCommand lockCmd = new OracleCommand(lockQuery, connection);
                    lockCmd.ExecuteNonQuery();
                    
                    lblStatus.Text = $"Nalog korisnika {selectedUser} je uspešno zaključan!";
                    
                    // Osveži prikaz korisnika
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Greška pri zaključavanju naloga: {ex.Message}";
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Uzmi ime korisnika iz selektovanog reda
                string selectedUsername = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
                
                // Pronađi i selektuj tog korisnika u ComboBox-u
                for (int i = 0; i < cmbUsers.Items.Count; i++)
                {
                    if (cmbUsers.Items[i].ToString() == selectedUsername)
                    {
                        cmbUsers.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void ShowAboutDialog()
        {
            Form aboutForm = new Form();
            aboutForm.Text = "O aplikaciji";
            aboutForm.Size = new System.Drawing.Size(650, 520);
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            aboutForm.MaximizeBox = false;
            aboutForm.MinimizeBox = false;
            aboutForm.BackColor = System.Drawing.Color.White;
            aboutForm.ShowIcon = false;

            // Naslov aplikacije
            Label lblTitle = new Label();
            lblTitle.Text = "Oracle Password Manager";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblTitle.Location = new System.Drawing.Point(30, 20);
            lblTitle.Size = new System.Drawing.Size(590, 35);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Opis aplikacije
            Label lblDescription = new Label();
            lblDescription.Text = "Aplikacija služi za prikaz korisnika u Oracle kontejneru\n" +
                                 "i modifikaciju istih, odnosno upravljanje šiframa.\n\n" +
                                 "UPOZORENJE:\n" +
                                 "Potrebno je prethodno poznavati koji korisnik\n" +
                                 "pripada čemu i za šta služi da se ne bi\n" +
                                 "diralo pogrešno i narušilo funkcionisanje sistema.";
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            lblDescription.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblDescription.Location = new System.Drawing.Point(30, 70);
            lblDescription.Size = new System.Drawing.Size(590, 140);
            lblDescription.TextAlign = System.Drawing.ContentAlignment.TopLeft;

            // Funkcionalnosti
            Label lblFeatures = new Label();
            lblFeatures.Text = "Funkcionalnosti:\n" +
                              "• Spajanje na Oracle bazu podataka\n" +
                              "• Prikaz korisnika i njihovih profila\n" +
                              "• Postavljanje neograničenog trajanja šifara\n" +
                              "• Postavljanje ograničenog trajanja šifara (1-999 dana)\n" +
                              "• Podrška za SYSDBA/SYSOPER konekcije\n" +
                              "• Otključavanje zaključanih naloga\n" +
                              "• Resetovanje isteklih šifara\n" +
                              "• Zaključavanje korisničkih naloga";
            lblFeatures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblFeatures.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblFeatures.Location = new System.Drawing.Point(30, 220);
            lblFeatures.Size = new System.Drawing.Size(590, 120);
            lblFeatures.TextAlign = System.Drawing.ContentAlignment.TopLeft;

            // Copyright
            Label lblCopyrightModal = new Label();
            lblCopyrightModal.Text = "© 2025 Hamza Delić - Sektor Informatike\nSva prava zadržana.";
            lblCopyrightModal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblCopyrightModal.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            lblCopyrightModal.Location = new System.Drawing.Point(30, 360);
            lblCopyrightModal.Size = new System.Drawing.Size(400, 40);
            lblCopyrightModal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // OK dugme
            Button btnOK = new Button();
            btnOK.Text = "U redu";
            btnOK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnOK.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnOK.ForeColor = System.Drawing.Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Location = new System.Drawing.Point(540, 365);
            btnOK.Size = new System.Drawing.Size(80, 30);
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, ev) => aboutForm.Close();

            // Dodaj kontrole na formu
            aboutForm.Controls.Add(lblTitle);
            aboutForm.Controls.Add(lblDescription);
            aboutForm.Controls.Add(lblFeatures);
            aboutForm.Controls.Add(lblCopyrightModal);
            aboutForm.Controls.Add(btnOK);

            // Prikaži modal
            aboutForm.ShowDialog(this);
        }
    }
}
