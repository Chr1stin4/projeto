﻿using System;
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
    public partial class Form6 : Form
    {
        Thread abc;
        public Form6()
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
        private void novoForm()
        {
            Application.Run(new Form2());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
