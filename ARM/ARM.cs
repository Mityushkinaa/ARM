using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ARM
{

    public partial class ARM : Form
    {
        public static int user = 0;

        private readonly string _sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database="arm",
            Username = "postgres",
            Password = "1234",
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;

        public ARM()
        {
            InitializeComponent();
            autentification autentification = new autentification();
            if (autentification.ShowDialog() == DialogResult.OK)
            {
                switch (user){
                    case 2:
                        управлениеПользователямиToolStripMenuItem.Visible = false;
                        break;
                    case 3:
                        управлениеПользователямиToolStripMenuItem.Visible = false;
                        dgvMyOwn.ReadOnly = true;
                        dgvMyOwn.AllowUserToDeleteRows = false;
                        dgvMyDach.ReadOnly = true;
                        dgvMyDach.AllowUserToDeleteRows = false;
                        dgvMyDachas.ReadOnly = true;
                        dgvMyDachas.AllowUserToDeleteRows = false;
                        dgvMyDist.ReadOnly = true;
                        dgvMyDist.AllowUserToDeleteRows = false;
                        addDis.Visible = false;
                        addDach.Visible = false;
                        addOwn.Visible = false;
                        addCountry.Visible = false;
                        break;

                }
            }
            
            InitializeDgvMyOwn();
            InitializeDgvMyDist();
            InitializeDgvMyDacash();
            InitializeDgvMyDach();
        }

        #region Районы
        DataGridViewComboBoxColumn districtCountry = new DataGridViewComboBoxColumn
        {
            Name = "countryName",
            HeaderText = @"Страна",
            DisplayMember = "name",
            ValueMember = "id"
        };

        DataGridViewButtonColumn addCountry = new DataGridViewButtonColumn

        {
            Name = "add",
            HeaderText = @"Кнопка добавления новой страны",
            UseColumnTextForButtonValue = true,
            Text = " + "


        };

        private void InitializeDgvMyDist()
        {
            dgvMyDist.Rows.Clear();
            dgvMyDist.Columns.Clear();
            dgvMyDist.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false
            });

            dgvMyDist.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Название района",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvMyDist.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "area",
                HeaderText = "Площадь района",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            //dgvMyDist.Columns.Add("name", "Название района");
            //dgvMyDist.Columns.Add("area", "Площадь района");


            //addCountry.Text = "  +  ";
            dgvMyDist.Columns.AddRange(districtCountry);
            dgvMyDist.Columns.Add(addCountry);
            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();

                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.CommandText = "SELECT * FROM country";
                    sCommand.Connection = sConn;
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());

                    districtCountry.DataSource = table;

                }
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.CommandText = "SELECT *, country.id as countryId, country.name as countryName  FROM district JOIN country ON district.country_id = country.id";
                    sCommand.Connection = sConn;
                    var reader = sCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var dataDict = new Dictionary<string, object>();
                        foreach (var columnsName in new[] { "name", "area", "countryName" })
                        {
                            dataDict[columnsName] = reader[columnsName];
                        }
                        var rowIdx = dgvMyDist.Rows.Add(reader["id"], reader["name"], reader["area"],
                            reader["countryId"]);
                        dgvMyDist.Rows[rowIdx].Tag = dataDict;
                    }
                }
            }
        }

        private void dgvMyDist_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvMyDist.Rows[e.RowIndex];
            if (dgvMyDist.IsCurrentRowDirty)
            {
                foreach (DataGridViewRow rw in dgvMyDist.Rows)
                {
                    var dataDict = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "name", "area" })
                    {
                        dataDict[columnsName] = row.Cells[columnsName].Value;
                    }
                    dataDict["countryName"] = row.Cells["countryName"].FormattedValue;

                    if (row == rw || rw.IsNewRow)
                    {
                        continue;
                    }

                    var dataDict2 = ((Dictionary<string, object>)rw.Tag);
                    if ((Convert.ToString(dataDict2["name"]).Trim() == Convert.ToString(dataDict["name"]).Trim()) && (Convert.ToInt32(dataDict2["area"]) == Convert.ToInt32(dataDict["area"])) && (Convert.ToString(dataDict2["countryName"]) == Convert.ToString(dataDict["countryName"])))
                    {
                        row.ErrorText = $"Значение в строке уже существует";
                        e.Cancel = true;

                    }
                }

                var cellsWithPotentialErrors = new[] { row.Cells["name"], row.Cells["area"], row.Cells["countryName"] };
                foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(cell.Value)))
                    {
                        row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                    }
                }
                if (Convert.ToString(row.Cells["name"].Value).Length > 100)
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["name"].OwningColumn.HeaderText}' не может быть такой длинны";
                    e.Cancel = true;
                }

                int z;
                if (!Int32.TryParse(Convert.ToString(row.Cells["area"].Value), out z))
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["area"].OwningColumn.HeaderText}' не может быть текстовым";
                    e.Cancel = true;
                }
                else
                {
                    if ((Convert.ToInt32(row.Cells["area"].Value) <= 0))
                    {
                        row.ErrorText = $"Значение в столбце '{row.Cells["area"].OwningColumn.HeaderText}' не может быть отрицательным";
                        e.Cancel = true;
                    }
                }


                if (!e.Cancel)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn
                        };
                        sCommand.Parameters.AddWithValue("@Name", row.Cells["name"].Value);
                        sCommand.Parameters.AddWithValue("@area", Convert.ToInt32(row.Cells["area"].Value));
                        sCommand.Parameters.AddWithValue("@Country", row.Cells["countryName"].Value);
                        var ownId = (int?)row.Cells["ID"].Value;
                        if (ownId.HasValue)
                        {
                            sCommand.CommandText = @"UPDATE district SET name = @Name, area = @Area, 
                                                            country_id = @Country
                                                    WHERE id = @ownID";
                            sCommand.Parameters.AddWithValue("@ownID", ownId.Value);
                            sCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sCommand.CommandText = @"INSERT INTO district(name, area, country_id)
                                                     VALUES (@Name, @Area, @Country)
                                                     RETURNING id";
                            row.Cells["id"].Value = sCommand.ExecuteScalar();
                        }

                        var dataDict = new Dictionary<string, object>();
                        foreach (var columnsName in new[] { "name", "area" })
                        {
                            dataDict[columnsName] = row.Cells[columnsName].Value;
                        }
                        dataDict["countryName"] = row.Cells["countryName"].FormattedValue;

                        row.Tag = dataDict;
                    }

                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                    InitializeDgvMyDacash();
                    using (var ctx = new MyModel())
                    {
                        ctx.dachas.Load();
                        var districts = ctx.districts.ToList();
                        var dachas = ctx.dachas.ToList();
                        foreach (var dacha in dachas)
                        {
                            dacha.district = districts.First(district => district.id == dacha.district_id);
                        }
                        dachaName.DataSource = dachas;
                    }
                    // row.Cells["modified_date"].ErrorText = "";
                }
            }
        }

        private void dgvMyDist_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var ownId = (int?)e.Row.Cells["id"].Value; // проверка на существование Id
            if (ownId.HasValue)
            {
                using (var sConn = new NpgsqlConnection(_sConnStr))
                {
                    sConn.Open();
                    var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = "DELETE FROM district WHERE id = @ownID"
                    };
                    sCommand.Parameters.AddWithValue("@ownID", ownId.Value);
                    try
                    {
                        sCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Нарушение внешнего ключа, в этом районе есть дома");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvMyDist_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvMyDist.IsCurrentRowDirty)
            {
                dgvMyDist.CancelEdit();
                if (dgvMyDist.CurrentRow.Cells["id"].Value != null)
                {
                    foreach (var kvp in (Dictionary<string, object>)dgvMyDist.CurrentRow.Tag)
                    {
                        dgvMyDist.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgvMyDist.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                }
                else
                {
                    dgvMyDist.Rows.Remove(dgvMyDist.CurrentRow);
                }
            }
        }

        private void dgvMyDist_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMyDist.Rows[e.RowIndex].IsNewRow)
            {
                dgvMyDist[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                if (dgvMyDist.Rows[e.RowIndex].Tag != null)
                    dgvMyDist[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                                                                  ((Dictionary<string, object>)dgvMyDist.Rows[e.RowIndex]
                                                                      .Tag)[dgvMyDist.Columns[e.ColumnIndex].Name];
            }

        }

        private void dgvMyDist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                addCountry secondForm = new addCountry();
                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn,
                            CommandText = @"INSERT INTO country (name, lang_id)
                                        VALUES (@name, @id)"
                        };



                        sCommand.Parameters.AddWithValue("@name", secondForm.countryName);
                        sCommand.Parameters.AddWithValue("@id", Convert.ToInt32(secondForm.Lang));
                        try
                        {
                            sCommand.ExecuteScalar();
                            using (var ctx = new MyModel())
                            {

                                ctx.countries.Load();
                                districtCountry.DataSource = ctx.countries.ToList();
                                


                            }
                        }
                        catch
                        {
                            MessageBox.Show("такая страна уже есть");
                        }
                        
                    }
                }
            }
        }
        #endregion

        #region Владельцы


        private void InitializeDgvMyOwn()
        {
            dgvMyOwn.Rows.Clear();
            dgvMyOwn.Columns.Clear();
            dgvMyOwn.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false,
                
                
            });
            dgvMyOwn.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fio",
                HeaderText = "ФИО",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvMyOwn.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                HeaderText = "Возраст",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvMyOwn.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "number",
                HeaderText = "Номер телефона",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            //dgvMyOwn.Columns.Add("fio", "ФИО");
            //dgvMyOwn.Columns.Add("age", "Возраст");
            //dgvMyOwn.Columns.Add("number", "Номер телефона");

            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT id, fio, age, number
                                    FROM owners
                                    ORDER BY id"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var dataDict = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "fio", "age", "number" })
                    {

                        dataDict[columnsName] = reader[columnsName];
                    }

                    var rowIdx = dgvMyOwn.Rows.Add(reader["id"], reader["fio"], reader["age"],
                        reader["number"]);
                    dgvMyOwn.Rows[rowIdx].Tag = dataDict;
                }
            }
        }

        private void dgvMu_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {


            var row = dgvMyOwn.Rows[e.RowIndex];
            bool newRow = row.IsNewRow;
            int rep = 0;
            if (dgvMyOwn.IsCurrentRowDirty)
            {

                foreach (DataGridViewRow rw in dgvMyOwn.Rows)
                {
                    var dataDict = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "fio", "age", "number" })
                    {
                        dataDict[columnsName] = row.Cells[columnsName].Value;
                    }

                    if (row == rw || rw.IsNewRow)
                    {
                        continue;
                    }

                    var dataDict2 = ((Dictionary<string, object>)rw.Tag);
                    if ((Convert.ToString(dataDict2["fio"]).Trim() == Convert.ToString(dataDict["fio"]).Trim()) && (Convert.ToInt32(dataDict2["age"]) == Convert.ToInt32(dataDict["age"])) && (Convert.ToInt64(dataDict2["number"]) == Convert.ToInt64(dataDict["number"])))
                    {
                        row.ErrorText = $"Значение в строке уже существует";
                        e.Cancel = true;
                        rep = 0;

                    }
                }

                if (rep > 1)
                {

                }

                if (Convert.ToString(row.Cells["fio"].Value).Length > 100)
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["fio"].OwningColumn.HeaderText}' не может быть такой длинны";
                    e.Cancel = true;
                }

                int z;
                if (!Int32.TryParse(Convert.ToString(row.Cells["age"].Value), out z))
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["age"].OwningColumn.HeaderText}' не может быть текстовым";
                    e.Cancel = true;
                }
                else
                {
                    if (!((Convert.ToInt32(row.Cells["age"].Value) >= 16) && (Convert.ToInt32(row.Cells["age"].Value) <= 200)))
                    {
                        row.ErrorText = $"Значение в столбце '{row.Cells["age"].OwningColumn.HeaderText}' должно быть в диапазоне от 16 до 200 ";
                        e.Cancel = true;
                    }
                }
                long x;
                if (!Int64.TryParse(Convert.ToString(row.Cells["number"].Value), out x))
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["number"].OwningColumn.HeaderText}' не может быть текстовым";
                    e.Cancel = true;
                }
                else
                {
                    if ((Convert.ToInt64(row.Cells["number"].Value) <= 0))
                    {
                        row.ErrorText = $"Значение в столбце '{row.Cells["number"].OwningColumn.HeaderText}' не может быть отрицательным";
                        e.Cancel = true;
                    }
                }

                var cellsWithPotentialErrors = new[] { row.Cells["fio"], row.Cells["age"], row.Cells["number"] };
                foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(cell.Value)))
                    {
                        row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                    }
                }


                if (!e.Cancel)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn
                        };
                        sCommand.Parameters.AddWithValue("@FIO", row.Cells["fio"].Value);
                        sCommand.Parameters.AddWithValue("@Age", Convert.ToInt32(row.Cells["age"].Value));
                        sCommand.Parameters.AddWithValue("@Number", Convert.ToInt64(row.Cells["number"].Value));
                        var ownId = (int?)row.Cells["ID"].Value;
                        if (ownId.HasValue)
                        {
                            sCommand.CommandText = @"UPDATE owners SET fio = @FIO, age = @Age, 
                                                            number = @Number
                                                    WHERE id = @ownID";
                            sCommand.Parameters.AddWithValue("@ownID", ownId.Value);
                            sCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sCommand.CommandText = @"INSERT INTO owners(fio, age, number)
                                                     VALUES (@FIO, @Age, @Number)
                                                     RETURNING id";
                            row.Cells["id"].Value = sCommand.ExecuteScalar();
                        }

                        var dataDict = new Dictionary<string, object>();
                        foreach (var columnsName in new[] { "fio", "age", "number" })
                        {
                            dataDict[columnsName] = row.Cells[columnsName].Value;
                        }

                        row.Tag = dataDict;
                    }

                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                    //InitializeDgvMyOwn();
                  //  InitializeDgvMyDist();
                  //  InitializeDgvMyDacash();
                    InitializeDgvMyDach();
                }
            }
        }

        private void dgvMu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMyOwn.Rows[e.RowIndex].IsNewRow)
            {
                dgvMyOwn[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                if (dgvMyOwn.Rows[e.RowIndex].Tag != null)
                    dgvMyOwn[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                                                                  ((Dictionary<string, object>)dgvMyOwn.Rows[e.RowIndex]
                                                                      .Tag)[dgvMyOwn.Columns[e.ColumnIndex].Name];
            }
        }

        private void dgvMu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var ownId = (int?)e.Row.Cells["id"].Value; // проверка на существование Id
            if (ownId.HasValue)
            {
                using (var sConn = new NpgsqlConnection(_sConnStr))
                {
                    sConn.Open();
                    var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = "DELETE FROM owners WHERE id = @ownID"
                    };
                    sCommand.Parameters.AddWithValue("@ownID", ownId.Value);
                    try
                    {
                        sCommand.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                       // MessageBox.Show(ex.Message);
                        MessageBox.Show("Нарушение внешнего ключа, у этого владельца есть загородные дома");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvMu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvMyOwn.IsCurrentRowDirty)
            {
                dgvMyOwn.CancelEdit();
                if (dgvMyOwn.CurrentRow.Cells["id"].Value != null)
                {
                    foreach (var kvp in (Dictionary<string, object>)dgvMyOwn.CurrentRow.Tag)
                    {
                        dgvMyOwn.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgvMyOwn.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                }
                else
                {
                    dgvMyOwn.Rows.Remove(dgvMyOwn.CurrentRow);
                }
            }
        }



        #endregion

        #region Собственность 
        DataGridViewComboBoxColumn dachaName = new DataGridViewComboBoxColumn
        {
            Name = "dachaName",
            HeaderText = @"Дача",
            DisplayMember = "fullName",
            ValueMember = "id"
        };
        DataGridViewButtonColumn addOwn = new DataGridViewButtonColumn

        {
            Name = "addOwn",
            HeaderText = @"Добавить владельца",
            UseColumnTextForButtonValue = true,
            Text = " Добавить владельца"

        };
        DataGridViewButtonColumn addDach = new DataGridViewButtonColumn

        {
            Name = "addDach",
            HeaderText = @"Добавить дачу",
            UseColumnTextForButtonValue = true,
            Text = "Добавить дачу "


        };
        DataGridViewComboBoxColumn ownerFIO = new DataGridViewComboBoxColumn
        {
            Name = "ownerName",
            HeaderText = @"ФИО владельца",
            DisplayMember = "info",
            ValueMember = "id"
        };
        public void InitializeDgvMyDach()
        {
            
            dgvMyDach.Rows.Clear();
            dgvMyDach.Columns.Clear();
            dgvMyDach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false
            });
            




            dgvMyDach.Columns.AddRange(ownerFIO);
            dgvMyDach.Columns.AddRange(dachaName);
            dgvMyDach.Columns.AddRange(addOwn);
            dgvMyDach.Columns.AddRange(addDach);
            //dgvMyDach.Columns.Add("area", "Площадь участка");
            //dgvMyDach.Columns.Add("away", "Удаленность от города");
            //dgvMyDach.Columns.Add("name", "Название населенного пунка");

            using (var ctx = new MyModel())
            {

                ctx.owners.Load();
                ownerFIO.DataSource = ctx.owners.ToList();
                ctx.dachas.Load();
                var districts = ctx.districts.ToList();
                var dachas = ctx.dachas.ToList();
                foreach (var dacha in dachas)
                {
                    dacha.district = districts.First(district => district.id == dacha.district_id);
                }
                dachaName.DataSource = dachas;

                using (var ctxx = new MyModel())
                {
                    foreach (var ow in ctxx.dacha_owners)
                    {
                        var id_dc = ow.id_dacha;
                        foreach (var dh in ctx.dachas)
                        {
                            if (dh.id == id_dc)

                            {
                                var rowIdx = dgvMyDach.Rows.Add(ow.id, ow.id_owners, dh.id);
                                //var dataDict = new Dictionary<string, object>();


                                //dataDict["fio"] = ow.id_owners;
                                //dataDict["name"] = dh.id;

                                //(Dictionary<string, object>, dacha_owners) tp = (dataDict, ow);

                                dgvMyDach.Rows[rowIdx].Tag = ow;


                            }
                        }

                    }
                }
            }

        }

        private void dgvMyDach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            string nameDacha = " ";
            string Fio = "";

            using (var ctx = new MyModel())
            {

                if (!dgvMyDach.Rows[e.RowIndex].IsNewRow)
                {

                    dgvMyDach[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                    if (dgvMyDach.Rows[e.RowIndex].Tag != null)
                    {
                        var dc = (dacha_owners)dgvMyDach.Rows[e.RowIndex].Tag;

                        foreach (var tmp in ctx.dachas)
                        {
                            if (dc.id_dacha == tmp.id)
                                nameDacha = tmp.name + "  " + tmp.district_id + "  " + tmp.area + "  " + tmp.awayfromtown;

                        }

                        foreach (var tmp in ctx.owners)
                        {
                            if (dc.id_owners == tmp.id)
                                Fio = tmp.fio;

                        }
                        if (e.ColumnIndex == 2)
                            dgvMyDach[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                                                                          (nameDacha);
                        else
                            dgvMyDach[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +

                                (Fio);


                    }
                }
            }
        }

        private void dgvMyDach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var ctx = new MyModel())
            {

                // (Dictionary<string, object>, dacha_owners) dc = (Tuple) e.Row.Tag;
                var dc = (dacha_owners)e.Row.Tag;
                ctx.dacha_owners.Attach(dc);
                ctx.dacha_owners.Remove(dc);
                ctx.SaveChanges();
            }
        }

        private void dgvMyDach_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvMyDach.Rows[e.RowIndex];
            bool newRow = row.IsNewRow;
            int rep = 0;
            if (dgvMyDach.IsCurrentRowDirty)
            {
                var cellsWithPotentialErrors = new[] { row.Cells["ownerName"], row.Cells["dachaName"] };
                foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(cell.Value)))
                    {
                        row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                    }
                }
                foreach (DataGridViewRow rw in dgvMyDach.Rows)
                {
                    var dict1 = new dacha_owners
                    {
                        id_dacha = Convert.ToInt32(row.Cells["dachaName"].Value),
                        id_owners = Convert.ToInt32(row.Cells["ownerName"].Value),
                    };
                    var dict2 = (dacha_owners)rw.Tag;

                    if (row == rw || rw.IsNewRow)
                    {
                        continue;
                    }
                    if (dict1.id_dacha == dict2.id_dacha && dict1.id_owners == dict2.id_owners)
                    {
                        row.ErrorText = $"Значение в строке уже существует";
                        e.Cancel = true;
                        rep = 0;

                    }


                }

                if (!e.Cancel)
                {
                    using (var ctxx = new MyModel())
                    {
                        var ownId = (int?)row.Cells["id"].Value;
                        if (ownId.HasValue)
                        {
                            var ow = (dacha_owners)row.Tag;
                            ctxx.dacha_owners.Attach(ow);
                            ow.id_dacha = Convert.ToInt32(row.Cells["dachaName"].Value);
                            ow.id_owners = Convert.ToInt32(row.Cells["ownerName"].Value);
                            ctxx.SaveChanges();


                        }
                        else
                        {
                            var ow = new dacha_owners
                            {
                                id_dacha = Convert.ToInt32(row.Cells["dachaName"].Value),
                                id_owners = Convert.ToInt32(row.Cells["ownerName"].Value),
                            };
                            ctxx.dacha_owners.Add(ow);
                            ctxx.SaveChanges();
                            row.Tag = ow;
                        }



                    }

                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                    
                }
            }

        }

        private void dgvMyDach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvMyDach.IsCurrentRowDirty)
            {
                dgvMyDach.CancelEdit();
                if (dgvMyDach.CurrentRow.Cells["id"].Value != null)
                {
                    var kvp = (dacha_owners)dgvMyDach.CurrentRow.Tag;
                    {
                        dgvMyDach.CurrentRow.Cells["ownerName"].Value = kvp.id_owners;
                        dgvMyDach.CurrentRow.Cells["dachaName"].Value = kvp.id_dacha;
                        dgvMyDach.CurrentRow.Cells["ownerName"].ErrorText = "";
                        dgvMyDach.CurrentRow.Cells["dachaName"].ErrorText = "";
                    }
                }
                else
                {
                    dgvMyDach.Rows.Remove(dgvMyDach.CurrentRow);
                }
            }
        }

        private void dgvMyDach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                addOwner secondForm = new addOwner();
                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn,
                            CommandText = @"INSERT INTO owners (fio, age, number)
                                        VALUES (@fio, @age, @number)"
                        };



                        sCommand.Parameters.AddWithValue("@fio", secondForm.Fio);
                        sCommand.Parameters.AddWithValue("@age", Convert.ToInt32(secondForm.Age));
                        sCommand.Parameters.AddWithValue("@number", Convert.ToInt64(secondForm.Number));
                        try
                        {
                            sCommand.ExecuteScalar();
                            //InitializeDgvMyDach();
                            using (var ctx = new MyModel())
                            {
                                ctx.owners.Load();
                                ownerFIO.DataSource = ctx.owners.ToList();
                                ctx.dachas.Load();
                                var districts = ctx.districts.ToList();
                                var dachas = ctx.dachas.ToList();
                                foreach (var dacha in dachas)
                                {
                                    dacha.district = districts.First(district => district.id == dacha.district_id);
                                }
                                dachaName.DataSource = dachas;


                            }
                            InitializeDgvMyOwn();
                        }
                        catch {
                            MessageBox.Show("такой владелец уже есть");
                        }
                        
                    }
                }
            }
            if (e.ColumnIndex == 4)
            {
                addDach secondForm = new addDach();
                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn,
                            CommandText = @"INSERT INTO dacha (area, awayfromtown, name, district_id)
                                        VALUES (@area, @away, @name, @district)"
                        };



                        sCommand.Parameters.AddWithValue("@name", secondForm.NameDch);
                        sCommand.Parameters.AddWithValue("@away", Convert.ToInt32(secondForm.Away));
                        sCommand.Parameters.AddWithValue("@area", Convert.ToInt32(secondForm.Area));
                        sCommand.Parameters.AddWithValue("@district", Convert.ToInt32(secondForm.Dist));
                        try
                        {
                            sCommand.ExecuteScalar();
                            
                            //InitializeDgvMyDach();
                            using (var ctx = new MyModel())
                            {
                                ctx.owners.Load();
                                ownerFIO.DataSource = ctx.owners.ToList();
                                ctx.dachas.Load();
                                var districts = ctx.districts.ToList();
                                var dachas = ctx.dachas.ToList();
                                foreach (var dacha in dachas)
                                {
                                    dacha.district = districts.First(district => district.id == dacha.district_id);
                                }
                                dachaName.DataSource = dachas;
                                


                            }
                            InitializeDgvMyOwn();
                            InitializeDgvMyDist();
                            InitializeDgvMyDacash();
                        }
                        catch
                        {
                            MessageBox.Show("Такая дача уже есть");
                        }

                        

                    }
                }
                else
                {
                    using (var ctx = new MyModel())
                    {
                        ctx.owners.Load();
                        ownerFIO.DataSource = ctx.owners.ToList();
                        ctx.dachas.Load();
                        var districts = ctx.districts.ToList();
                        var dachas = ctx.dachas.ToList();
                        foreach (var dacha in dachas)
                        {
                            dacha.district = districts.First(district => district.id == dacha.district_id);
                        }
                        dachaName.DataSource = dachas;



                    }
                    InitializeDgvMyOwn();
                    InitializeDgvMyDist();
                    InitializeDgvMyDacash();
                }
            }
        }

        #endregion


        #region Дачи
        DataGridViewButtonColumn addDis = new DataGridViewButtonColumn

        {
            Name = "add",
            HeaderText = @"Кнопка добавления нового района",
            UseColumnTextForButtonValue = true,
            Text = " +район "


        };
        DataGridViewComboBoxColumn distName = new DataGridViewComboBoxColumn
        {
            Name = "distName", 
            HeaderText = @"Район",
            DisplayMember = "info", //тута поле которое должно отображаться
            ValueMember = "id" // тут айди
        };
        public void InitializeDgvMyDacash()
        {
            dgvMyDachas.Rows.Clear();
            dgvMyDachas.Columns.Clear();
            dgvMyDachas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false
            });
            dgvMyDachas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "area",
                HeaderText = "Площадь участа",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvMyDachas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "away",
                HeaderText = "Удаленность от города",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvMyDachas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Населённый пункт",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvMyDachas.Columns.Add("area", "Площадь участка");
            dgvMyDachas.Columns.Add("away", "Удалённость от города");
            dgvMyDachas.Columns.Add("name", "Населённый пункт");
            
          

            

            dgvMyDachas.Columns.AddRange(distName);
            dgvMyDachas.Columns.AddRange(addDis);
           // dgvMyDach.Columns.Add("area", "Площадь участка");
            //dgvMyDach.Columns.Add("away", "Удаленность от города");
            //dgvMyDach.Columns.Add("name", "Название населенного пунка");

            using (var ctx = new MyModel())
            {

                //ctx.districts.Load();//подгружаешь таблицу
                //var districts = ctx.districts.ToList();// переделываешь в лист
  
                //var cout = ctx.countries.ToList();
                //foreach (var dist in districts)
                //{
                //    dist.country = cout.First(country => country.id == dist.country_id);
                //}
                //distName.DataSource = districts;//подключаешь к комбобоксу


                foreach (var ow in ctx.dachas)
                {

                    var id_dc = ow.district_id;
                    //using (var ctxx = new OpenModel())
                    //{

                    var rowIdx = dgvMyDachas.Rows.Add(ow.id, ow.area, ow.awayfromtown, ow.name, ow.district_id);
                    //var dataDict = new Dictionary<string, object>();


                    //dataDict["fio"] = ow.id_owners;
                    //dataDict["name"] = dh.id;

                    //(Dictionary<string, object>, dacha_owners) tp = (dataDict, ow);

                    dgvMyDachas.Rows[rowIdx].Tag = ow;





                    //}

                }
            }

        }

        private void dgvMyDachas_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvMyDachas.Rows[e.RowIndex];
            bool newRow = row.IsNewRow;
            int rep = 0;
            bool txt = true;
            if (dgvMyDachas.IsCurrentRowDirty)
            {
                var cellsWithPotentialErrors = new[] { row.Cells["area"], row.Cells["away"], row.Cells["name"], row.Cells["distName"] };
                foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(cell.Value)))
                    {
                        row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                    }
                }

                foreach (var cell in cellsWithPotentialErrors)
                {

                    if (Convert.ToString(cell.Value).Trim().Length > 100)
                    {
                        row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть длинее 100 символов";
                        e.Cancel = true;
                    }
                }
                int x;
                if (!Int32.TryParse(Convert.ToString(row.Cells["area"].Value).Trim(), out x))
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["area"].OwningColumn.HeaderText}' должно быть целым типа int  и не отрицательным";
                    e.Cancel = true;
                    txt = false;
                }
                else
                {
                    if ((Convert.ToInt64(row.Cells["area"].Value) <= 0))
                    {
                        row.ErrorText = $"Значение в столбце '{row.Cells["area"].OwningColumn.HeaderText}' не может быть отрицательным";
                        e.Cancel = true;
                    }
                }

                if (!Int32.TryParse(Convert.ToString(row.Cells["away"].Value).Trim(), out x))
                {
                    row.ErrorText = $"Значение в столбце '{row.Cells["away"].OwningColumn.HeaderText}' должно быть целым типа int  и не отрицательным";
                    e.Cancel = true;
                    txt = false;
                }
                else
                {
                    if ((Convert.ToInt64(row.Cells["away"].Value) <= 0))
                    {
                        row.ErrorText = $"Значение в столбце '{row.Cells["away"].OwningColumn.HeaderText}' не может быть отрицательным";
                        e.Cancel = true;
                    }
                }
                if (txt)
                {
                    foreach (DataGridViewRow rw in dgvMyDachas.Rows)
                    {
                        var dict1 = new dacha
                        {
                            area = Convert.ToInt32(row.Cells["area"].Value),
                            awayfromtown = Convert.ToInt32(row.Cells["away"].Value),
                            name = Convert.ToString(row.Cells["name"].Value).Trim(),
                            district_id = Convert.ToInt32(row.Cells["distName"].Value)
                        };
                        var dict2 = (dacha)rw.Tag;

                        if (row == rw || rw.IsNewRow)
                        {
                            continue;
                        }
                        if (dict1.area == dict2.area && dict1.awayfromtown == dict2.awayfromtown && dict1.name == dict2.name && dict1.district_id == dict2.district_id)
                        {
                            row.ErrorText = $"Значение в строке уже существует";
                            e.Cancel = true;
                            rep = 0;

                        }


                    }
                }


                if (!e.Cancel)
                {
                    using (var ctxx = new MyModel())
                    {
                        var ownId = (int?)row.Cells["id"].Value;
                        if (ownId.HasValue)
                        {
                            var ow = (dacha)row.Tag;
                            ctxx.dachas.Attach(ow);
                            ow.area = Convert.ToInt32(row.Cells["area"].Value);
                            ow.awayfromtown = Convert.ToInt32(row.Cells["away"].Value);
                            ow.district_id = Convert.ToInt32(row.Cells["distName"].Value);
                            ow.name = Convert.ToString(row.Cells["name"].Value).Trim();
                            ctxx.SaveChanges();


                        }
                        else
                        {
                            var ow = new dacha
                            {
                                area = Convert.ToInt32(row.Cells["area"].Value),
                                awayfromtown = Convert.ToInt32(row.Cells["away"].Value),
                                district_id = Convert.ToInt32(row.Cells["distName"].Value),
                                name = Convert.ToString(row.Cells["name"].Value).Trim()
                            };
                            ctxx.dachas.Add(ow);
                            ctxx.SaveChanges();
                            row.Tag = ow;
                        }
                        ctxx.dachas.Load();
                        dachaName.DataSource = ctxx.dachas.ToList();

                    }

                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                    // InitializeDgvMyOwn();
                    using (var ctx = new MyModel())
                    {
                      //  ctx.owners.Load();
                       // ownerFIO.DataSource = ctx.owners.ToList();
                        ctx.dachas.Load();
                        var districts = ctx.districts.ToList();
                        var dachas = ctx.dachas.ToList();
                        foreach (var dacha in dachas)
                        {
                            dacha.district = districts.First(district => district.id == dacha.district_id);
                        }
                        dachaName.DataSource = dachas;
                    }
                    //InitializeDgvMyDacash();
                    //InitializeDgvMyDach();
                }
            }
        }

        private void dgvMyDachas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvMyDachas.IsCurrentRowDirty)
            {
                dgvMyDachas.CancelEdit();
                if (dgvMyDachas.CurrentRow.Cells["id"].Value != null)
                {
                    var kvp = (dacha)dgvMyDachas.CurrentRow.Tag;
                    {
                        dgvMyDachas.CurrentRow.Cells[1].Value = kvp.area;
                        dgvMyDachas.CurrentRow.Cells[2].Value = kvp.awayfromtown;
                        dgvMyDachas.CurrentRow.Cells[3].Value = kvp.name;
                        dgvMyDachas.CurrentRow.Cells[4].Value = kvp.district_id;
                        dgvMyDachas.CurrentRow.Cells[1].ErrorText = "";
                        dgvMyDachas.CurrentRow.Cells[2].ErrorText = "";
                        dgvMyDachas.CurrentRow.Cells[3].ErrorText = "";
                        dgvMyDachas.CurrentRow.Cells[4].ErrorText = "";
                    }
                }
                else
                {
                    dgvMyDachas.Rows.Remove(dgvMyDach.CurrentRow);
                }
            }

        }

        private void dgvMyDachas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var ctx = new MyModel())
            {

                // (Dictionary<string, object>, dacha_owners) dc = (Tuple) e.Row.Tag;
                var dc = (dacha)e.Row.Tag;
                ctx.dachas.Attach(dc);
                ctx.dachas.Remove(dc);
              
                try
                {
                    ctx.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Нарушение внешнего ключа, у этой дачи есть владельцы");
                    e.Cancel = true;
                }
            }
        }

        private void dgvMyDachas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string txt = " ";


            if (!dgvMyDachas.Rows[e.RowIndex].IsNewRow)
            {

                dgvMyDachas[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                if (dgvMyDachas.Rows[e.RowIndex].Tag != null)
                {
                    var dc = (dacha)dgvMyDachas.Rows[e.RowIndex].Tag;
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            txt = Convert.ToString(dc.area);
                            break;
                        case 2:
                            txt = Convert.ToString(dc.awayfromtown);
                            break;
                        case 3:
                            txt = dc.name;
                            break;
                        case 4:
                            using (var ctx = new MyModel())
                            {
                                foreach (var dh in ctx.districts)
                                {
                                    if (dc.district_id == dh.id)
                                    {
                                        txt = dh.name;
                                        break;
                                    }
                                }
                            }
                            break;


                    }


                    dgvMyDachas[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                                                                      (txt);


                }
            }

        
        }

        private void dgvMyDachas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                addDist secondForm = new addDist();
                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    using (var sConn = new NpgsqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new NpgsqlCommand
                        {
                            Connection = sConn,
                            CommandText = @"INSERT INTO district (name, area, country_id)
                                        VALUES (@name, @area, @country)"
                        };



                        sCommand.Parameters.AddWithValue("@name", secondForm.NameDist);
                        sCommand.Parameters.AddWithValue("@area", Convert.ToInt32(secondForm.Area));
                        sCommand.Parameters.AddWithValue("@country", Convert.ToInt32(secondForm.Countr));
                        try
                        {
                            sCommand.ExecuteScalar();
                            using (var ctx = new MyModel())
                            {

                                ctx.districts.Load();
                                var districts = ctx.districts.ToList();
                                var cout = ctx.countries.ToList();
                                foreach (var dist in districts)
                                {
                                    dist.country = cout.First(country => country.id == dist.country_id);
                                }
                                distName.DataSource = districts;



                            }
                            InitializeDgvMyDach();
                            InitializeDgvMyDist();
                        }
                        catch
                        {
                            MessageBox.Show("Такой район уже есть");
                        }

                        //InitializeDgvMyDacash();

                    }
                }

            }
        }
        #endregion

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autentification autentification = new autentification();
            if(autentification.ShowDialog() == DialogResult.OK)
            {
               
                    switch (user)
                    {
                        case 1:
                            управлениеПользователямиToolStripMenuItem.Visible = true;
                            dgvMyOwn.ReadOnly = false;
                            dgvMyOwn.AllowUserToDeleteRows = true;
                            dgvMyDach.ReadOnly = false;
                            dgvMyDach.AllowUserToDeleteRows = true;
                            dgvMyDachas.ReadOnly = false;
                            dgvMyDachas.AllowUserToDeleteRows = true;
                            dgvMyDist.ReadOnly = false;
                            dgvMyDist.AllowUserToDeleteRows = true;
                            addDis.Visible = true;
                            addDach.Visible = true;
                            addOwn.Visible = true;
                            addCountry.Visible = true;
                            break;
                        case 2:
                            управлениеПользователямиToolStripMenuItem.Visible = false;
                            break;
                        case 3:
                            управлениеПользователямиToolStripMenuItem.Visible = false;
                            dgvMyOwn.ReadOnly = true;
                            dgvMyOwn.AllowUserToDeleteRows = false;
                            dgvMyDach.ReadOnly = true;
                            dgvMyDach.AllowUserToDeleteRows = false;
                            dgvMyDachas.ReadOnly = true;
                            dgvMyDachas.AllowUserToDeleteRows = false;
                            dgvMyDist.ReadOnly = true;
                            dgvMyDist.AllowUserToDeleteRows = false;
                            addDis.Visible = false;
                            addDach.Visible = false;
                            addOwn.Visible = false;
                            addCountry.Visible = false;
                            break;

                    }
                
            }
        }

        private void управлениеПользователямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.ShowDialog();
        }

        private void запросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ques ques = new ques();
            ques.ShowDialog();
        }

        private void dgvMyOwn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}