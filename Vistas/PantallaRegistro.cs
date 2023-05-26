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
using TP1___GRUPO_C.Modelos;

namespace TP1___GRUPO_C
{
    public partial class PantallaRegistro : Form
    {
        private Cine cine;
        public volverPantallaPrincipal pantallaPrincipal;

        public PantallaRegistro(Cine c)
        {
            InitializeComponent();
            cine = c;
        }

        public delegate void volverPantallaPrincipal();
        

        private void button1_Click(object sender, EventArgs e)
        {
            //registrar
            string Nombres = this.textBoxNombres.Text;
            string Apellidos = this.textBoxApellidos.Text;
            int.TryParse(textBoxDNI.Text, out int DNI);
            string Mail = this.textBoxMail.Text;
            string Pass = this.textBoxPass.Text;
            DateTime FechaNacimiento = dateTimePicker1.Value.Date;

            
           
            int peticion = cine.AgregarUsuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, false,0,false);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 201) { 
            this.pantallaPrincipal();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        #region Elementos no utilizados
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pantallaPrincipal();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {//nombres
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {//mail

        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {//password

        }

        private void textBoxApellidos_TextChanged(object sender, EventArgs e)
        {//apellidos

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {//dni

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {//fecha de nacimiento

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//checkbox adm

        }
        #endregion

    }
}
