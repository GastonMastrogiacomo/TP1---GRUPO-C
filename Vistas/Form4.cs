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

namespace TP1___GRUPO_C
{
    public partial class Form4 : Form
    {

        private Cine miCine;

        public UsuarioComunLogueado usuarioComunLogueado;
        public AbrirLoginAdmin abrirLoginAdmin;

        public Form4(Cine cine)
        {

            InitializeComponent();
            miCine = cine;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton login

            string mail = this.textBox1.Text;
            string pass = this.textBox2.Text;

            bool esAdmin = this.checkBox1.Checked;

            if (mail != null && mail != "" && pass != null & pass != "")
            {
                if (miCine.IniciarSesion(mail, pass,esAdmin))
                {
                    if(esAdmin)
                    {
                        this.abrirLoginAdmin();
                    }
                    else
                    {
                        this.usuarioComunLogueado();

                    }
                }
                else
                {
                    MessageBox.Show("Error, datos incorrectos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public delegate void UsuarioComunLogueado();

        public delegate void AbrirLoginAdmin();

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
