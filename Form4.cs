using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1___GRUPO_C
{
    public partial class Form4 : Form
    {

        private Cine miCine;

        public TransfDelegado TransfEvento;

        public Form4(Cine cine)
        {

            miCine = cine;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton login
            string mail = this.textBox1.Text;
            string pass = this.textBox2.Text;

            if (mail != null && mail != "" && pass != null & pass != "")
            {
                if (miCine.IniciarSesion(mail,pass))
                {
                    this.TransfEvento();
                }
                else
                {
                    MessageBox.Show("Error, datos incorrectos!");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario y contraseña!");
            }
        }

        public delegate void TransfDelegado();

        private void button2_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
