using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public partial class Form3 : Form
    {
        Thread abc, C;
        private bool radioButtonLigado1 = false;
        private bool radioButtonLigado2 = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void novoForm()
        {
            Application.Run(new Form2());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            abc = new Thread(novoForm);
            abc.SetApartmentState(ApartmentState.STA);
            abc.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            C = new Thread(novoForm1);
            C.SetApartmentState(ApartmentState.STA);
            C.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            C = new Thread(novoForm1);
            C.SetApartmentState(ApartmentState.STA);
            C.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (radioButtonLigado1)
                {
                    radioButtonLigado1 = false;
                }
                else
                {
                    radioButtonLigado1 = true;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (radioButtonLigado2)
                {
                    radioButtonLigado2 = false;
                }
                else
                {
                    radioButtonLigado2 = true;
                }
            }
        }

        private void novoForm1()
        {
            Application.Run(new Form6());
        }
    }
}
