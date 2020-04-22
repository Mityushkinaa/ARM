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
    public partial class addOwner : Form
    {
        public addOwner()
        {
            InitializeComponent();
        }
        public string Fio
        {
            get { return txFio.Text.Trim(); }
            set { txFio.Text = value; }
        }
        public string Age
        {
            get { return txAge.Text.Trim(); }
            set { txAge.Text = value; }
        }
        public string Number
        {
            get { return txNumber.Text.Trim(); }
            set { txNumber.Text = value; }
        }
        bool isFio, isAge, isNumber;


        void Sync()
        {
            if (isAge && isNumber && isFio)
            {
                btAdd.Enabled = true;
            }
            else
                btAdd.Enabled = false;
        }
        private void txAge_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!Int32.TryParse(Age, out x))
            {
                
                epMain.SetError(txAge, "Возраст должен быть целым числом от 16 до 200");
                isAge = false;
            }
            else
            {
                if(x<16 || x > 200)
                {
                    epMain.SetError(txAge, "Возраст должен быть целым числом от 16 до 200");
                    isAge = false;
                }
                else
                {
                    epMain.SetError(txAge, "");
                    isAge= true;
                }
            }
            Sync();
            

        }

        private void txNumber_TextChanged(object sender, EventArgs e)
        {
            long x;
            if (!Int64.TryParse(Number, out x))
            {

                epMain.SetError(txNumber, "Номер должен быть числом");
                isNumber = false;
            }
            else
            {
                if (x < 0)
                {
                    epMain.SetError(txNumber, "Номер должен быть положительным");
                    isNumber = false;

                }else              
                {
                    epMain.SetError(txNumber, "");
                    isNumber = true;
                }
            }
            Sync();
        }

        private void txFio_TextChanged(object sender, EventArgs e)
        {
            if (txFio.Text.Length > 99 || txFio.Text.Length == 0)
            {
                epMain.SetError(txFio, "название не может быть такой длинны");
                isFio = false;
            }
            else
            {

                epMain.SetError(txFio, "");
                isFio = true;
            }
            Sync();
        }
    }
}
