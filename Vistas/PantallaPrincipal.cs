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
using static TP1___GRUPO_C.PantallaLogin;
using static TP1___GRUPO_C.PantallaRegistro;

namespace TP1___GRUPO_C
{
    public partial class PantallaPrincipal : Form
    {
        internal Cine cine;
        public IniciarVentanaLogin iniciarVentanaLogin;
        public AbrirRegistro abrirRegistro;
        public AbrirMiPerfil abrirMiPerfil;


        internal PantallaPrincipal(Cine c)
        {
            InitializeComponent();
            cine = c;
            Btn_MiPerfil.Hide();
            Btn_CerrarSesion.Hide();


        }

        public void Refresh()
        {
            Btn_MiPerfil.Hide();
            Btn_CerrarSesion.Hide();
            btnRegistrarse.Show();
            button3.Show();

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
            Btn_MiPerfil.Show();
            Btn_CerrarSesion.Show();
            btnRegistrarse.Hide();
            button3.Hide();
            this.iniciarVentanaLogin();

        }

        public delegate void IniciarVentanaLogin();
        public delegate void AbrirRegistro();
        public delegate void AbrirMiPerfil();


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

        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            cine.CerrarSesion();
            Refresh();

        }

        private void Btn_MiPerfil_Click(object sender, EventArgs e)
        {
            abrirMiPerfil();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
