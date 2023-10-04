using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace projeto
{
    public partial class Form2 : Form
    {
        Thread abc, PCoraline, PNoiva, PAlice, Pbarbie, Psanrio, Pmonsterhight;

        public Form2()
        {
            InitializeComponent();
        }

        private void novoForm()
        {
            Application.Run(new Form1());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            abc = new Thread(novoForm);
            abc.SetApartmentState(ApartmentState.STA);
            abc.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            PCoraline = new Thread(novoForm1);
            PCoraline.SetApartmentState(ApartmentState.STA);
            PCoraline.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            PNoiva = new Thread(novoForm2);
            PNoiva.SetApartmentState(ApartmentState.STA);
            PNoiva.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            PAlice = new Thread(novoForm3);
            PAlice.SetApartmentState(ApartmentState.STA);
            PAlice.Start();
        }
        private void novoForm3()
        {
            Application.Run(new Form5());
        }

        private void novoForm1()
        {
            Application.Run(new Form3());
        }
        private void novoForm2()
        {
            Application.Run(new Form4());
        }
    }
}
