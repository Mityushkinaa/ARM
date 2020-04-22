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
    public partial class addDist : Form
    {
        public addDist()
        {
            InitializeComponent();
            using (var ctx = new MyModel())
            {
                cmCount.DisplayMember = "name";
                cmCount.ValueMember = "id";
                ctx.countries.Load();
                cmCount.DataSource = ctx.countries.ToList();

            }   
        }

        public string Area
        {
            get { return txArea.Text.Trim(); }
            set { txArea.Text = value; }
        }

        public string NameDist
        {
            get { return txName.Text.Trim(); }
            set { txName.Text = value; }
        }

        public object Countr => (cmCount.SelectedValue);

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        bool isArea, isName;


        void Sync()
        {
            if (isArea && isName)
            {
                btAddDist.Enabled = true;
            }
            else
                btAddDist.Enabled = false;
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
