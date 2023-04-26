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

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaABMAdmin : Form
    {

        private Cine miCine;

        public PantallaABMAdmin(Cine cine)
        {
            InitializeComponent();
            miCine = cine;

            this.LabelBienvenida.Text = "Bienvenido, " + miCine.UsuarioActual.Nombre;
        }


        private void PantallaABMAdmin_Load(object sender, EventArgs e)
        {
        }

        private void Salas_Click(object sender, EventArgs e)
        {

        }

        private void Btn_CerrarSesion(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pestañas_Selected(object sender, TabControlEventArgs e)
        {

            switch (Pestañas.SelectedIndex)
            {

                case 0:
                    {
                        //salas
                        break;
                    }
                case 1:
                    {
                        //funciones 
                        break;
                    }
                case 2:
                    {
                        // peliculas
                        break;
                    }
                case 3:
                    {
                        //usuarios
                        refreshUsuarios();
                        break;
                    }
            }



        }


        private void refreshUsuarios()
        {
            dataGridUsuarios.Rows.Clear();

            foreach (Usuario user in miCine.MostrarUsuarios())
            {
                //siempre necesito un arreglo
                dataGridUsuarios.Rows.Add(user.ToString());
            }
        }
    }
}
