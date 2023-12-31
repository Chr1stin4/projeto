﻿using CefSharp.WinForms;
using CefSharp;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            InitializeChromium();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
        }
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser("https://www.friv.com/new.html");
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
