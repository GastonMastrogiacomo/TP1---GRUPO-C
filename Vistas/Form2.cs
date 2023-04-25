using System;
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
using static TP1___GRUPO_C.Form3;

namespace TP1___GRUPO_C
{
    public partial class Form2 : Form
    {
        internal Cine cine;
        public IniciarVentanaLogin iniciarVentanaLogin;
        public AbrirRegistro abrirRegistro;
        
        // atributo = string / int / bool
        // atributo = referencia funcion

        internal Form2(Cine c)
        {
            InitializeComponent();
            cine = c;
            button1.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {// boton iniciar sesion adm

        }

        private void button2_Click(object sender, EventArgs e)
        {//boton registrarse
           this.abrirRegistro();
        }

        private void button3_Click(object sender, EventArgs e)
        {// boton iniciar sesion user
            button1.Show();
            btnRegistrarse.Hide();
            button3.Hide();
            this.iniciarVentanaLogin();

        }

        public delegate void IniciarVentanaLogin();
        public delegate void AbrirRegistro();
        

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
