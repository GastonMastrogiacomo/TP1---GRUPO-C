﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1___GRUPO_C.Model;
using static TP1___GRUPO_C.Form4;

namespace TP1___GRUPO_C
{
    public partial class Form2 : Form
    {
        internal Cine cine;
        public TransferenciaVentana TransfVen;

        internal Form2(Cine c)
        {
            InitializeComponent();
            cine = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {// boton iniciar sesion adm

        }

        private void button2_Click(object sender, EventArgs e)
        {//boton registrarse

        }

        private void button3_Click(object sender, EventArgs e)
        {// boton iniciar sesion user
            this.TransfVen();

        }

        public delegate void TransferenciaVentana();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}