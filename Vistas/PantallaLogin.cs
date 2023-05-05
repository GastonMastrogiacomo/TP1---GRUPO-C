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
using static TP1___GRUPO_C.PantallaRegistro;

namespace TP1___GRUPO_C
{
    public partial class PantallaLogin : Form
    {

        private Cine miCine;
        public UsuarioComunLogueado usuarioComunLogueado;
        public UsuarioAdminLogueado usuarioAdminLogueado;
        public volverPantallaPrincipal pantallaPrincipal;

        public PantallaLogin(Cine cine)
        {

            InitializeComponent();
            miCine = cine;

        }

        public delegate void UsuarioComunLogueado();

        public delegate void UsuarioAdminLogueado();

        public delegate void volverPantallaPrincipal();

        private void button1_Click(object sender, EventArgs e)
        {
            //boton login

            string mail = this.textBox1.Text;
            string pass = this.textBox2.Text;
            bool esAdmin = this.checkBox1.Checked;

            if (mail != null && mail != "" && pass != null & pass != "")
            {
                if (miCine.IniciarSesion(mail, pass, esAdmin))
                {
                    if (esAdmin)
                    {
                        this.usuarioAdminLogueado();
                    }
                    else
                    {
                        this.usuarioComunLogueado();
                        
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.pantallaPrincipal();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
