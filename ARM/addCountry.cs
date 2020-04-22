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
    
    public partial class addCountry : Form
    {
        public addCountry()
        {
            InitializeComponent();

            using (var ctx = new MyModel())
            {
                cmLang.DisplayMember = "name";
                cmLang.ValueMember= "id";
                ctx.languages.Load();
                cmLang.DataSource = ctx.languages.ToList();
                
            }

        }
        public static int lang;
        public string countryName
        {
            get { return txCountry.Text.Trim(); }
            set { txCountry.Text = value; }
        }
       public object Lang => (cmLang.SelectedValue) ;


        private void addCountry_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txCountry_TextChanged(object sender, EventArgs e)
        {
            if (countryName.Length > 99 || countryName.Length == 0)
            {
                epMain.SetError(txCountry, "название не может быть такой длинны");
                btAddCount.Enabled = false;
            }
            else
            {

                epMain.SetError(txCountry, "");
                btAddCount.Enabled = true;
            }

        }

        private void cmLang_SelectedIndexChanged(object sender, EventArgs e)
        {
           //lang = cmLang.ValueMember;
        }
    }
}
