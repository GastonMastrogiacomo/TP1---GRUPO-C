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
                dataGridSalas.Rows.Add(sal.ToString());
            }
        }


        /* Voy creando los metodos para mostrar el ABM de Salas como en Usuarios


            private void Btn_RefrescarSalas(object sender, EventArgs e)
            {
                refreshSalas();
            }

            private void dataGridSalas_CellDoubleClick(object sender , DataGridViewCellEventArgs e){
                
                string ID = dataGridSalas[0,e.RowIndex].Value.ToString();
                this.Input_ID_Salas.Text = dataGridSalas[0,e.RowIndex].Value.ToString();
                this.Input_Ubicacion.Text = dataGridSalas[1,e.RowIndex].Value.ToString();
                this.Input_Capacidad.Text = dataGridSalas[2,e.RowIndex].Value.ToString();

                //Crear SalaAuxiliar?
                Sala SalaAuxiliar = miCine.ObtenerSalaPorID(int.Parse(ID));

                Sala<Sala> salas = miCine.MostrarSalas();
                This.SalaAuxiliar = salas.FirstOrDefault(s => s.ID == int.Parse(ID));

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

                        abrirPantallaCargaFunciones(this.SalaAuxiliar);
                    }
            }

        */



        /* Voy creando los metodos para mostrar el ABM de Funciones como en Usuarios


       private void Btn_RefrescarFunciones(object sender, EventArgs e)
           {
               refreshFunciones();
           }

       private void dataGridFunciones_CellDoubleClick(object sender , DataGridViewCellEventArgs e){

               string ID = dataGridFunciones[0,e.RowIndex].Value.ToString();
               this.Input_ID_Funciones.Text = dataGridFunciones[0,e.RowIndex].Value.ToString();
               this.Input_MiSala.Text = dataGridFunciones[1,e.RowIndex].Value.ToString();
               this.Input_MiPelicula.Text = dataGridFunciones[2,e.RowIndex].Value.ToString();
               this.Input_Clientes.Text = dataGridFunciones[3,e.RowIndex].Value.ToString();
               this.Selec_Fecha.Value = dataGridSalas[4,e.RowIndex].Value.ToString();
               this.Input_CantidadClientes.Text = dataGridFunciones[5,e.RowIndex].Value.ToString();
               this.Input_Costo.Text = dataGridFunciones[6,e.RowIndex].Value.ToString();


               //Crear FuncionAuxiliar?
               Funcion FuncionAuxiliar = miCine.ObtenerFuncionPorID(int.Parse(ID));

               List<Funcion> funciones = miCine.MostrarFunciones();
               this.FuncionAuxiliar = funciones.FirstOrDefault(f => f.ID == int.Parse(ID));

           }


       */


        /* Voy creando los metodos para mostrar el ABM de Peliculas como en Usuarios


        private void Btn_RefrescarPeliculas(object sender, EventArgs e)
           {
               refreshPeliculas();
           }

        private void dataGridPeliculas_CellDoubleClick(object sender , DataGridViewCellEventArgs e){

               string ID = dataGridPeliculas[0,e.RowIndex].Value.ToString();
               this.Input_ID_Peliculas.Text = dataGridPeliculas[0,e.RowIndex].Value.ToString();
               this.Input_Nombre_Pelicula.Text = dataGridPeliculas[1,e.RowIndex].Value.ToString();
               this.Input_Descripcion.Text = dataGridPeliculas[2,e.RowIndex].Value.ToString();
               this.Input_Sinopsis.Text = dataGridPeliculas[3,e.RowIndex].Value.ToString();
               this.Input_Poster.Text = dataGridPeliculas[4,e.RowIndex].Value.ToString();
               this.Input_Duracion.Text = dataGridPeliculas[5,e.RowIndex].Value.ToString();


               //Crear PeliculaAuxiliar?
               Pelicula PeliculaAuxiliar = miCine.ObtenerFuncionPorID(int.Parse(ID));
                

               Ver si esta forma no es mejor en ya que no estariamos usando los clones:
               List<Pelicula> peliculas = miCine.MostrarPeliculas();
               this.PeliculaAuxiliar = peliculas.FirstOrDefault(p => p.ID == int.Parse(ID));

           }


        */



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
            dataGridSalas.Rows.Clear();

            foreach (Funcion fun in miCine.MostrarFunciones())
            {
                dataGridSalas.Rows.Add(fun.ToString());
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
            //string Reservas = dataGridUsuarios[12, e.RowIndex].Value.ToString();
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
    }
}
