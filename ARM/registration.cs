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
    public partial class registration : Form
    {
         
        public void Check()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*) FROM users WHERE login = @currentLogin"
                })
                {
                    sCommand.Parameters.AddWithValue("@currentLogin", tbLogin.Text.Trim());
                    // ReSharper disable once PossibleNullReferenceException
                    if ((long)sCommand.ExecuteScalar() > 0 || tbLogin.Text == "")
                    {
                        epMain.SetError(tbLogin, "Login is uncorrect");
                        _isLoginValid = false;
                    }
                    else
                    {
                        epMain.SetError(tbLogin, "");
                        _isLoginValid = true;
                    }
                }

                SyncBtRegisterState();
            }
        }
        public registration()
        {
            InitializeComponent();
            WarmupDbConnection();

            Check();
        }
        public string Login
        {
            get
            {
                return tbLogin.Text.Trim();
            }
            set
            {
                tbLogin.Text = value;
            }
        }

        public string Pass
        {
            get
            {
                return password.Text.Trim();
            }
            set
            {
                password.Text = value;
            }
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

        private bool _isLoginValid;



        private void SyncBtRegisterState()
        {
            regist.Enabled = _isLoginValid && _isPasswordValid;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*) FROM users WHERE login = @currentLogin"
                })
                {
                    sCommand.Parameters.AddWithValue("@currentLogin", tbLogin.Text.Trim());
                    // ReSharper disable once PossibleNullReferenceException
                    if ((long)sCommand.ExecuteScalar() > 0 || tbLogin.Text == "")
                    {
                        epMain.SetError(tbLogin, "Логин занят");
                        _isLoginValid = false;
                    }
                    else
                    {
                        epMain.SetError(tbLogin, "");
                        _isLoginValid = true;
                    }
                }

                SyncBtRegisterState();
            }


        }



        private string CalcHash(string text)
        {

            {
                SHA1CryptoServiceProvider password = new SHA1CryptoServiceProvider();
                return Convert.ToBase64String(password.ComputeHash(Encoding.Unicode.GetBytes(text)));
            }
        }




        private void regist_Click(object sender, EventArgs e)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"INSERT INTO users(login, password, salt, date, isAdmin) VALUES (@login, @password, @salt, @date, @admin)"
                })
                {
                    if (tbLogin.Text == "")
                        MessageBox.Show(@"Пустой логин!");
                    else
                    {
                        string salt = "1234ad";
                        bool adm = false;
                        sCommand.Parameters.AddWithValue("login", tbLogin.Text.Trim());
                        sCommand.Parameters.AddWithValue("password", CalcHash(password.Text+salt) );
                        sCommand.Parameters.AddWithValue("salt", salt);
                        sCommand.Parameters.AddWithValue("date", DateTime.Today);
                        sCommand.Parameters.AddWithValue("admin", adm);

                        if (sCommand.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show(@"Регистрация успешна");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                            MessageBox.Show(@"Что - то пошло не так");
                        _isLoginValid = false;
                        password.Text = "";
                        tbLogin.Text = "";
                    }

                }

                SyncBtRegisterState();
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if ((password.Text.Length < 8) || (password.Text.Replace(" ", "").Replace("\t", "").Length < 8))
            {
                epMain.SetError(password, "Пароль простой");
                _isPasswordValid = false;
            }
            else
            {
                epMain.SetError(password, "");
                _isPasswordValid = true;
            }
            SyncBtRegisterState();
        }

        private void tbLogin_TextChanged_1(object sender, EventArgs e)
        {
            if (tbLogin.Text.Length > 100)
            {
                
                epMain.SetError(tbLogin, "Login is too big");
                _isLoginValid = false;
            }
            else
            {
                epMain.SetError(tbLogin, "");
                _isLoginValid = true;
            }
            SyncBtRegisterState();
            }
        }
    }

