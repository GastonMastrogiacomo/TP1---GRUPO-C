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
using static TP1___GRUPO_C.PantallaPrincipal;

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaABMAdmin : Form
    {

        private Cine miCine;
        private Usuario UsuarioAuxiliar;
        private Sala SalaAuxiliar;
        private Funcion FuncionAuxiliar;
        private Pelicula PeliculaAuxiliar;
        public AbrirPantallaCargaFunciones abrirPantallaCargaFunciones;
        public volverPantallaPrincipal pantallaPrincipal;



        public PantallaABMAdmin(Cine cine)
        {
            InitializeComponent();
            miCine = cine;
            this.LabelBienvenida.Text = "Bienvenido, " + miCine.UsuarioActual.Nombre;
        }

        public delegate void volverPantallaPrincipal();

        public delegate void AbrirPantallaCargaFunciones(Usuario usuarioAuxiliar);

        private void PantallaABMAdmin_Load(object sender, EventArgs e)
        {
        }

        private void Salas_Click(object sender, EventArgs e)
        {

        }

        private void Btn_CerrarSesion(object sender, EventArgs e)
        {
            miCine.CerrarSesion();
            pantallaPrincipal();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Pestañas_Selected(object sender, TabControlEventArgs e)
        {

            switch (Pestañas.SelectedIndex)
            {

                case 0:
                    {
                        //salas
                        refreshSalas();
                        break;
                    }
                case 1:
                    {
                        //funciones
                        refreshFunciones();
                        break;
                    }
                case 2:
                    {
                        // peliculas
                        refreshPeliculas();
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
        private void refreshSalas()
        {
            dataGridSalas.Rows.Clear();

            foreach (Sala sal in miCine.MostrarSalas())
            {
                dataGridSalas.Rows.Add(sal.SalaToString());
            }
        }


        //Voy creando los metodos para mostrar el ABM de Salas como en Usuarios

        private void dataGridSalas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string ID = dataGridSalas[0, e.RowIndex].Value.ToString();
            //this.Input_ID_Sala.Text = dataGridSalas[0, e.RowIndex].Value.ToString();
            this.Input_Ubicacion.Text = dataGridSalas[1, e.RowIndex].Value.ToString();
            this.Input_Capacidad.Text = dataGridSalas[2, e.RowIndex].Value.ToString();



            List<Sala> salas = miCine.MostrarSalas();
            this.SalaAuxiliar = salas.FirstOrDefault(s => s.ID == int.Parse(ID));

        }


        //Ver como implementar lo siguiente: "muestra el listado de salas, seleccionar una, lo lleva asla vista de FUnciones filtradas para esa sala." 
        private void Btn_VerFuncionesEnSalas_Click(object sender, EventArgs e)
        {
            if (SalaAuxiliar == null)
            {
                MessageBox.Show("Debe seleccionar una Sala primero.", "Sala not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                //abrirPantallaCargaSalas(this.SalaAuxiliar);
            }
        }





        // Voy creando los metodos para mostrar el ABM de Funciones como en Usuarios



        private void dataGridFunciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string ID = dataGridFunciones[0, e.RowIndex].Value.ToString();
            this.Cb_Peliculas.SelectedIndex = e.RowIndex;
            this.Cb_Salas.SelectedIndex = e.RowIndex;
            //this.Selec_Fecha.Value = dataGridSalas[3, e.RowIndex].Value.ToString();
            this.Input_CantidadClientes.Text = dataGridFunciones[4, e.RowIndex].Value.ToString();
            this.Input_Costo.Text = dataGridFunciones[5, e.RowIndex].Value.ToString();




            List<Funcion> funciones = miCine.MostrarFunciones();
            this.FuncionAuxiliar = funciones.FirstOrDefault(f => f.ID == int.Parse(ID));

        }





        // Voy creando los metodos para mostrar el ABM de Peliculas como en Usuarios


        private void Btn_RefrescarPeliculas(object sender, EventArgs e)
        {
            refreshPeliculas();
        }

        private void dataGridPeliculas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string ID = dataGridPeliculas[0, e.RowIndex].Value.ToString();
            this.Input_Nombre_Pelicula.Text = dataGridPeliculas[1, e.RowIndex].Value.ToString();
            this.Input_Descripcion.Text = dataGridPeliculas[2, e.RowIndex].Value.ToString();
            this.Input_Sinopsis.Text = dataGridPeliculas[3, e.RowIndex].Value.ToString();
            this.Input_Poster.Text = dataGridPeliculas[4, e.RowIndex].Value.ToString();
            this.Input_Duracion.Text = dataGridPeliculas[5, e.RowIndex].Value.ToString();
            this.Cb_Funciones.SelectedIndex = e.RowIndex;





            //Ver si esta forma no es mejor en ya que no estariamos usando los clones:
            List<Pelicula> peliculas = miCine.MostrarPeliculas();
            this.PeliculaAuxiliar = peliculas.FirstOrDefault(p => p.ID == int.Parse(ID));

        }


        private void refreshPeliculas()
        {
            dataGridSalas.Rows.Clear();

            foreach (Pelicula pel in miCine.MostrarPeliculas())
            {
                dataGridSalas.Rows.Add(pel.ToString());
            }
        }

        private void refreshFunciones()
        {
            dataGridFunciones.Rows.Clear();

            foreach (Funcion fun in miCine.MostrarFunciones())
            {
                dataGridFunciones.Rows.Add(fun.ToString());
            }

            foreach (Sala s in miCine.MostrarSalas())
            {
                this.Cb_Salas.Items.Add(s.Ubicacion);
            }

            foreach (Pelicula pel in miCine.MostrarPeliculas())
            {
                this.Cb_Peliculas.Items.Add(pel.Nombre);
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

        private void Btn_RefrescarUsuarios(object sender, EventArgs e)
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

            List<Usuario> usuarios = miCine.MostrarUsuarios();

            this.UsuarioAuxiliar = usuarios.FirstOrDefault(u => u.ID == int.Parse(ID));

            this.Input_Credito.Text = dataGridUsuarios[9, e.RowIndex].Value.ToString();
            String fecha1 = dataGridUsuarios[10, e.RowIndex].Value.ToString();
            DateTime fecha = DateTime.Parse(fecha1);
            this.Selec_FechaDeNacimiento.Value = fecha;
            this.Cb_EsAdmin.Checked = bool.Parse(dataGridUsuarios[11, e.RowIndex].Value.ToString());
        }

        private void Btn_NuevoUsuario_Click(object sender, EventArgs e)
        {

            string Nombres = this.Input_Nombre.Text;
            string Apellidos = this.Input_Apellido.Text;
            int.TryParse(this.Input_DNI.Text, out int DNI);
            string Mail = this.Input_Mail.Text;
            string Pass = this.Input_Password.Text;
            DateTime FechaNacimiento = this.Selec_FechaDeNacimiento.Value;
            bool esAdmin = this.Cb_EsAdmin.Checked;

            Usuario nuevo = new Usuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin);

            if (miCine.AgregarUsuario(nuevo))
            {
                refreshUsuarios();
            }


        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {

            int.TryParse(Label_IdUsuario.Text, out int ID);
            string Nombres = this.Input_Nombre.Text;
            string Apellidos = this.Input_Apellido.Text;
            int.TryParse(this.Input_DNI.Text, out int DNI);
            string Mail = this.Input_Mail.Text;
            string Pass = this.Input_Password.Text;
            DateTime FechaNacimiento = this.Selec_FechaDeNacimiento.Value;
            bool esAdmin = this.Cb_EsAdmin.Checked;

            Usuario nuevo = new Usuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin);
            if (miCine.ModificarUsuario(ID, nuevo))
            {
                refreshUsuarios();
            }
        }

        private void Btn_EliminarUsuario_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_IdUsuario.Text, out int ID);
            if (miCine.EliminarUsuario(ID))
            {
                refreshUsuarios();
            }
        }

        private void Btn_VerFunciones_Click(object sender, EventArgs e)
        {
            if (UsuarioAuxiliar == null)
            {
                MessageBox.Show("Debe seleccionar un usuario primero.", "Usuario not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                abrirPantallaCargaFunciones(this.UsuarioAuxiliar);
            }
        }

        private void Btn_RefrescarSalas_Click(object sender, EventArgs e)
        {
            refreshSalas();
        }

        private void Btn_NuevoSala_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ModificarSala_Click(object sender, EventArgs e)
        {

        }

        private void Btn_EliminarSala_Click(object sender, EventArgs e)
        {

        }

        private void Funciones_Click(object sender, EventArgs e)
        {

        }

        private void Btn_RefrescarFunciones_Click(object sender, EventArgs e)
        {
            refreshFunciones();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Pestañas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
