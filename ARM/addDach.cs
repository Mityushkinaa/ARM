using Npgsql;
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

namespace ARM
{
    public partial class addDach : Form
    {
        public addDach()
        {
            InitializeComponent();

            using (var ctx = new MyModel())
            {
                gbDist.DisplayMember = "info";
                gbDist.ValueMember = "id";
                

                    ctx.districts.Load();
                    var districts = ctx.districts.ToList();
                    var cout = ctx.countries.ToList();
                    foreach (var dist in districts)
                    {
                        dist.country = cout.First(country => country.id == dist.country_id);
                    }
                    gbDist.DataSource = districts;



                

            }
        }
        public string NameDch
        {
            get { return txName.Text.Trim(); }
            set { txName.Text = value; }
        }
        public string Away
        {
            get { return txAway.Text.Trim(); }
            set { txAway.Text = value; }
        }
        public string Area
        {
            get { return txArea.Text.Trim(); }
            set { txArea.Text = value; }
        }

        public object Dist => (gbDist.SelectedValue);

        bool isAway, isName, isArea;
        

        void Sync()
        {
            if (isArea && isAway && isName)
            {
                btAddDist.Enabled = true;
            }
            else
                btAddDist.Enabled = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txName_TextChanged(object sender, EventArgs e)
        {
            if (txName.Text.Length > 99 || txName.Text.Length == 0)
            {
                epMain.SetError(txName, "название не может быть такой длинны");
                isName = false;
            }
            else
            {

                epMain.SetError(txName, "");
                isName = true;
            }
            Sync();
        }

        private readonly string _sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = "postgres",
            Password = "210135",
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;

        private void button1_Click_1(object sender, EventArgs e)
        {
            addDist addDist = new addDist();
            if (addDist.ShowDialog() == DialogResult.OK)
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



                    sCommand.Parameters.AddWithValue("@name", addDist.NameDist);
                    sCommand.Parameters.AddWithValue("@area", Convert.ToInt32(addDist.Area));
                    sCommand.Parameters.AddWithValue("@country", Convert.ToInt32(addDist.Countr));
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
                            gbDist.DataSource = districts;



                        }
                       
                    }
                    catch
                    {
                        MessageBox.Show("Такой район уже есть");
                    }
                }
            }
        }

        private void txAway_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!Int32.TryParse(Away, out x))
            {

                epMain.SetError(txAway, "Расстояние должно быть числом вхожящим в int" +
                    "");
                isAway = false;
            }
            else
            {
                if (x < 0)
                {
                    epMain.SetError(txAway, "Расстояние должно быть положительной");
                    isAway = false;
                }
                else
                {
                    epMain.SetError(txAway, "");
                    isAway = true;
                }
            }
            Sync();
        }

        private void txArea_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!Int32.TryParse(Area, out x))
            {

                epMain.SetError(txArea, "Площадь должна быть числом вхожящим в int" +
                    "");
                isArea = false;
            }
            else
            {
                if (x < 0)
                {
                    epMain.SetError(txArea, "Площадь должна быть положительной");
                    isArea = false;
                }
                else
                {
                    epMain.SetError(txArea, "");
                    isArea = true;
                }
            }
            Sync();

        }
    }
}
