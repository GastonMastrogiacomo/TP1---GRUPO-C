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
                dataGridUsuarios.Rows.Add(user.ToString());
            }
        }

        private void Click_RefrescarUsuarios(object sender, EventArgs e)
        {
            refreshUsuarios();
        }

        private void dataGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridUsuarios[0, e.RowIndex].Value.ToString();
            this.Input_DNI.Text = dataGridUsuarios[1, e.RowIndex].Value.ToString();
            this.Input_Nombre.Text = dataGridUsuarios[2, e.RowIndex].Value.ToString();
            this.Input_Apellido.Text = dataGridUsuarios[3, e.RowIndex].Value.ToString();
            this.Input_Mail.Text = dataGridUsuarios[4, e.RowIndex].Value.ToString();
            this.Input_Password.Text = dataGridUsuarios[5, e.RowIndex].Value.ToString();
            this.Input_IntentosFallidos.Text = dataGridUsuarios[6, e.RowIndex].Value.ToString();
            this.Cb_Bloqueado.Checked = bool.Parse(dataGridUsuarios[7, e.RowIndex].Value.ToString());
            string Funciones = dataGridUsuarios[8, e.RowIndex].Value.ToString();
            this.Input_Credito.Text = dataGridUsuarios[9, e.RowIndex].Value.ToString();
            string FechaNacimiento = dataGridUsuarios[10, e.RowIndex].Value.ToString();
            this.Cb_EsAdmin.Checked =bool.Parse(dataGridUsuarios[11, e.RowIndex].Value.ToString());
            string Reservas = dataGridUsuarios[12, e.RowIndex].Value.ToString();
        }
    }
}
