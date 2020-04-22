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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            InitializeLvUsers();
        }
        public static string OLD;
        readonly string sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = "arm",
            Username = "postgres",
            Password = "1234",
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;

       

        private void InitializeLvUsers()
        {
            lvUsers.Columns.Add("Логин");
            lvUsers.Columns.Add("Пароль");
            lvUsers.Columns.Add("Дата регистрации");
            lvUsers.Columns.Add("Права администратора");
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT login, password, date, isAdmin FROM users"
                };

                var reader = sCommand.ExecuteReader();
              //  string adm;
               

                    while (reader.Read())
                {
                    var lvi = new ListViewItem(new[]
                    {
                        (string) reader["login"],
                        (string) reader["password"],
                        ((DateTime) reader["date"]).ToLongDateString(),
                        (bool)reader["isAdmin"] ? "Да" : "Нет"
                        
                    })
                    { Tag = (DateTime)reader["date"] };

                    lvUsers.Items.Add(lvi);
                }
                lvUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secondForm secondForm = new secondForm(secondForm.State.Insert, sConnStr);
            if (secondForm.ShowDialog() == DialogResult.OK)
            {
                using (var sConn = new NpgsqlConnection(sConnStr))
                {
                    sConn.Open();
                    var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"INSERT INTO Users (login, password, salt, date, isAdmin)
                                        VALUES (@Login, @Password, @Salt, @Date, @admin)"
                    };

                    var salt = "1234ad";
                    var password = CalcHash(secondForm.Password + salt);
                    var login = secondForm.Login.Trim();

                    sCommand.Parameters.AddWithValue("@Login", login);
                    sCommand.Parameters.AddWithValue("@Password", password);
                    sCommand.Parameters.AddWithValue("@Salt", salt);
                    sCommand.Parameters.AddWithValue("@Date", secondForm.RegistrationDate);
                    sCommand.Parameters.AddWithValue("@admin", secondForm.Admin);

                    string curLogin = (string)sCommand.ExecuteScalar();

                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        secondForm.Login,
                        password,
                        secondForm.RegistrationDate.ToLongDateString(),
                        (bool)secondForm.Admin ? "Да" : "Нет"
                    })
                    { Tag = secondForm.RegistrationDate };
                    lvUsers.Items.Add(lvi);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in lvUsers.SelectedItems)
            {

                using (var sConn = new NpgsqlConnection(sConnStr))
                {
                    sConn.Open();
                    var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"DELETE FROM users WHERE login = @Login"
                    };


                    sCommand.Parameters.AddWithValue("@Login", selectedItem.SubItems[0].Text);
                    sCommand.ExecuteNonQuery();
                    lvUsers.Items.Remove(selectedItem);

                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secondForm secondForm = new secondForm(secondForm.State.Update, sConnStr);
            foreach (ListViewItem selectedItem in lvUsers.SelectedItems)
            {
                var oldLogin = selectedItem.SubItems[0].Text;
                OLD = oldLogin;
                secondForm.Login = oldLogin;
                secondForm.Password = "";
                secondForm.RegistrationDate = (DateTime)selectedItem.Tag;
                if (selectedItem.SubItems[3].Text.Trim() == "Да")
                    secondForm.Admin = true;
                else
                    secondForm.Admin = false;
                    
                

                secondForm.BtOk = Enabled;
                string password = "";

                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new NpgsqlConnection(sConnStr))
                    {
                        sConn.Open();
                        NpgsqlCommand sCommand;

                        if (secondForm.Password.Trim() == "")
                        {
                            sCommand = new NpgsqlCommand
                            {
                                Connection = sConn,
                                CommandText = @"UPDATE Users SET login = @Login, Date = @RegistrationDate, isAdmin = @admin
                                               WHERE  login = @oldLogin"
                            };
                        }
                        else
                        {

                            sCommand = new NpgsqlCommand
                            {
                                Connection = sConn,
                                CommandText = @"UPDATE Users SET login = @Login, password = @Password, salt = @Salt,  date = @RegistrationDate, isAdmin=@admin WHERE  login = @oldLogin"
                            };
                            var salt = "1234ad";
                            CalcHash(secondForm.Password + salt);

                            sCommand.Parameters.AddWithValue("@Password", password);
                            sCommand.Parameters.AddWithValue("@Salt", salt);
                        }
                        sCommand.Parameters.AddWithValue("@oldLogin", oldLogin);
                        sCommand.Parameters.AddWithValue("@Login", secondForm.Login.Trim());
                        sCommand.Parameters.AddWithValue("@RegistrationDate", secondForm.RegistrationDate);
                        sCommand.Parameters.AddWithValue("@admin", secondForm.Admin);

                        sCommand.ExecuteNonQuery();

                        selectedItem.SubItems[0].Text = secondForm.Login.Trim();
                        if (password != "") selectedItem.SubItems[1].Text = password;
                        selectedItem.SubItems[2].Text = secondForm.RegistrationDate.ToLongDateString();
                        selectedItem.SubItems[3].Text = (bool)secondForm.Admin ? "Да" : "Нет";


                        lvUsers.Tag = secondForm.RegistrationDate;
                    }
                }
            }
        }

      

        private string CalcHash(string text)
        {
            using (SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(SHA1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
