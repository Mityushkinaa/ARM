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
    public partial class ques : Form
    {
        public ques()
        {
            InitializeComponent();
            using (var ctx = new MyModel())
            {
                ctx.owners.Load();
                cbName.DataSource = ctx.owners.ToList();
                var dachas = ctx.dachas.ToList();
                var districts = ctx.districts.ToList();
                foreach (var dacha in dachas)
                {
                    dacha.district = districts.First(district => district.id == dacha.district_id);
                }
                cmCountry.DataSource = dachas;
                dgvDach.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id",
                    Visible = false
                });
                dgvDach.Columns.Add("area", "Площадь участка");
                dgvDach.Columns.Add("away", "Удалённость от города");
                dgvDach.Columns.Add("name", "Населённый пункт");
                dgvDach.Columns.Add("district", "Район");
                dgvCountry.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id",
                    Visible = false
                });
                dgvCountry.Columns.Add("name", "Название страны");
                dgvCountry.Columns.Add("lang", "Язык");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSearchDach_Click(object sender, EventArgs e)
        {
            dgvCountry.Rows.Clear();
            int id_dc = 0;
            int id_c = 0;
            using (var ctx = new MyModel())
            {
                int id = (int)(cmCountry.SelectedValue);
                foreach (var ow in ctx.districts)
                {

                    if (ow.id == id)
                    {
                        id_dc = ow.id;


                    }                   //}

                }

                foreach (var dc in ctx.districts)
                {
                    if (id_dc == dc.id)
                    {
                        id_c = dc.country_id;
                    }
                }
                string dc_name = "";
                int lang_id = 0;
                foreach (var dc in ctx.countries)
                {
                    if (id_c == dc.id)
                    {
                        lang_id = dc.lang_id;
                        dc_name = dc.name;
                       
                    }
                }
                foreach (var dc in ctx.languages)
                {
                    if (lang_id == dc.id)
                    {

                        var rowIdx = dgvCountry.Rows.Add(dc.id, dc_name, dc.name);
                    }
                }
            }

        }

        private void btSearchCountry_Click(object sender, EventArgs e)
        {
            dgvDach.Rows.Clear();

            int id_dc=0;
            using (var ctx = new MyModel())
            {
                int id = (int)(cbName.SelectedValue);
                foreach (var ow in ctx.dacha_owners)
                {

                    if (ow.id_owners == id)
                    {
                         id_dc = ow.id_dacha;
                        
                       
                    }                   //}

                }
                foreach (var dc in ctx.dachas)
                {
                    if (id_dc == dc.id)
                    {
                        var rowIdx = dgvDach.Rows.Add(dc.id, dc.area, dc.awayfromtown, dc.name, dc.district_id);
                    }
                }
            }
        }
    }
}
