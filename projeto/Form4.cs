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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace projeto
{
    public partial class Form4 : Form
    {
        Thread abc, C;
        private bool radioButtonLigado1 = false;
        private bool radioButtonLigado2 = false;
        private bool radioButtonLigado3 = false;

        private void novoForm()
        {
            Application.Run(new Form2());
        }
        public Form4()
        {
            InitializeComponent();
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
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            C = new Thread(novoForm1);
            C.SetApartmentState(ApartmentState.STA);
            C.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            C = new Thread(novoForm1);
            C.SetApartmentState(ApartmentState.STA);
            C.Start();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

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
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (radioButtonLigado3)
                {
                    radioButtonLigado3 = false;
                }
                else
                {
                    radioButtonLigado3 = true;
                }
            }
        }

        private void novoForm1()
        {
             Application.Run(new Form9());
        }
    }
}
