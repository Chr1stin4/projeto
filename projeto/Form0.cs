using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin tela = new FormLogin();
            tela.ShowDialog();
            this.Close();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            Form1 tela1 = new Form1();
            tela1.ShowDialog();
            this.Close();
        }
    }
}
