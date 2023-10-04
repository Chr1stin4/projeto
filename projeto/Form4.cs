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
    public partial class Form4 : Form
    {
        Thread abc, C;

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

        private void novoForm1()
         {
             Application.Run(new Form6());
         }
    }
}
