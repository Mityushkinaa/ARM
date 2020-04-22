using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ARM
{
    public partial class autentification : Form
    {
        public autentification()
        {
            InitializeComponent();
            WarmupDbConnection();
        }
        private string sConnStr = new NpgsqlConnectionStringBuilder()
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = "arm",
            Username = "postgres",
            Password = "1234",
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2

        }.ConnectionString;

        public string Login
        {
            get
            {
                return txLogin.Text.Trim();
            }
        }

        public string Pass
        {
            get
            {
                return password.Text.Trim();
            }
        }

        private void WarmupDbConnection()
        {
            Task.Run(() =>
            {
                using (var sConn = new NpgsqlConnection(sConnStr))
                {
                    sConn.Open();
                }
            }
            );
        }

        private bool _isPasswordValid;

        private bool _isLoginValid = true;



        private void SyncBtRegisterState()
        {
            btEnter.Enabled = _isLoginValid && _isPasswordValid;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if ((password.Text.Length < 8) || (password.Text.Contains(" ")))
            {
                epMain.SetError(password, "Password is simple");
                _isPasswordValid = false;
            }
            else
            {
                epMain.SetError(password, "");
                _isPasswordValid = true;
            }
            SyncBtRegisterState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string CalcHash(string text)
        {
          
            {
                SHA1CryptoServiceProvider password = new SHA1CryptoServiceProvider();
                return Convert.ToBase64String(password.ComputeHash(Encoding.Unicode.GetBytes(text)));
            }
        }

        private void enter_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                NpgsqlCommand sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT password,salt, isAdmin FROM users WHERE login = @Login"
                };
                sCommand.Parameters.AddWithValue("@Login", txLogin.Text.Trim(' ', '\t'));

                NpgsqlDataReader reader = sCommand.ExecuteReader();
                if (reader.Read())
                {
                    string passwordHash = (string)reader["password"];
                    string salt = (string)reader["salt"];
                    bool adm = (bool)reader["isAdmin"];
                    string t = CalcHash(Pass+salt);
                    Console.WriteLine(t);
                    Console.WriteLine(passwordHash);
                   
                    if (passwordHash == t)
                    {

                        if (adm)
                        {
                            MessageBox.Show("Вход выполнен, вы администратор");
                            ARM.user = 1;
                        }
                        else
                        {
                            MessageBox.Show("Вы вошли ");
                            ARM.user = 2;
                        }

                        password.Text = "";
                        txLogin.Text = "";
                        btEnter.DialogResult = DialogResult.OK;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else MessageBox.Show("Неверный пароль");
                }
                else MessageBox.Show("Неверный логин");
            }


        }

        

        private void btReg_Click(object sender, EventArgs e)
        {
            registration registration = new registration();
            registration.Login = txLogin.Text.Trim();
            registration.Pass = password.Text.Trim();
            if(registration.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btGuest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вход выполнен, вы гость");
            ARM.user = 3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
