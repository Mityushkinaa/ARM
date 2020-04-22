using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class secondForm : Form
    {
        public secondForm()
        {
            InitializeComponent();
        }
        public enum State
        {
            Insert,
            Update
        }

        string sConnStr = "";

        public string Login
        {
            get { return login.Text; }
            set { login.Text = value; }
        }
        public string Password
        {
            get { return password.Text; }
            set { password.Text = value; }

        }

        public DateTime RegistrationDate
        {
            get { return registrationDate.Value; }
            set { registrationDate.Value = value; }

        }
        public bool Admin
        {
            get { return cbAdmin.Checked; }
            set { cbAdmin.Checked = value; }

        }

        public bool BtOk
        {
            get { return btOk.Enabled; }
            set { btOk.Enabled = value; }
        }

        private bool _isPasswordValid = true;

        private bool _isLoginValid = true;

        bool checkVal = true;



        public void SyncBtRegisterState()
        {
            btOk.Enabled = _isLoginValid && _isPasswordValid && checkVal;
        }

        State state;
        public secondForm(State frmState, string _sConnStr)
        {
            state = frmState;
            InitializeComponent();
            sConnStr = _sConnStr;
            switch (frmState)
            {
                case State.Insert:

                    Text = "Добавение нового пользователя";
                    btOk.Text = @"Добавить";
                    btOk.Enabled = false;
                    break;

                case State.Update:

                    Tag = 1;
                    
                    Text = "Изменение данных";
                    btOk.Text = @"Принять изменение";


                    break;
            }
        }

        private void login_TextChanged(object sender, EventArgs e)
        {

            if (state == State.Update)
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
                        sCommand.Parameters.AddWithValue("@currentLogin", login.Text.Trim(' ', '\t'));

                        if (login.Text.Trim(' ', '\t') == Users.OLD)
                        {
                            epMain.SetError(login, "");
                            _isLoginValid = true;
                        }
                        else
                        {
                            if ((long)sCommand.ExecuteScalar() > 0 || Login == "")
                            {

                                epMain.SetError(login, "Login is uncorrect");
                                _isLoginValid = false;

                            }
                            else
                            {
                                epMain.SetError(login, "");
                                _isLoginValid = true;
                            }

                        }

                    }

                    SyncBtRegisterState();
                }
            }
            else
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
                        sCommand.Parameters.AddWithValue("@currentLogin", login.Text.Trim(' ', '\t'));

                        if ((long)sCommand.ExecuteScalar() > 0 || login.Text == "")
                        {
                            epMain.SetError(login, "Login is uncorrect");
                            _isLoginValid = false;
                        }
                        else
                        {
                            epMain.SetError(login, "");
                            _isLoginValid = true;
                        }
                    }

                    SyncBtRegisterState();
                }

            }
        }



        private void password_TextChanged(object sender, EventArgs e)
        {
            if (state == State.Update)
            {
                if (password.Text.Trim() == "")
                {
                    epMain.SetError(password, "");
                    _isPasswordValid = true;
                    SyncBtRegisterState();
                }
                else
                {
                    if ((password.Text.Length < 8) || (password.Text.Replace(" ", "").Replace("\t", "").Length < 8))
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
            }
            else
            {
                if ((password.Text.Length < 8) || (password.Text.Replace(" ", "").Replace("\t", "").Length < 8))
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
        }
        private void secondForm_Load(object sender, EventArgs e)
        {


        }

        private void btOk_Click(object sender, EventArgs e)
        {

        }

        private void btOk_Click_1(object sender, EventArgs e)
        {

        }

        private void cbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(state == State.Update)
            {
                int count;
                using (var sConn = new NpgsqlConnection(sConnStr))
                {
                    sConn.Open();
                    using (var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"SELECT COUNT(*) FROM users WHERE isAdmin = TRUE"
                    })
                    {
                        //sCommand.Parameters.AddWithValue("@currentLogin", login.Text.Trim(' ', '\t'));

                        if ((long)sCommand.ExecuteScalar() == 1 && cbAdmin.Checked == false)
                        {
                           
                            checkVal = false;
                        }
                        else
                        {
                            //epMain.SetError(login, "");
                            checkVal = true;
                        }
                    }
                }

                SyncBtRegisterState();
            }
        }
    }
}
