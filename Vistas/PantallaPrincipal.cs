using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1___GRUPO_C.Model;
using TP1___GRUPO_C.Modelos;
using static System.Net.Mime.MediaTypeNames;
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

        private int idPeliculaSeleccionada;
        private int idFuncionSeleccionada;
        private int idSalaSeleccionada;


        internal PantallaPrincipal(Cine c)
        {
            InitializeComponent();
            cine = c;
            this.Input_FechaPpal.Value = DateTime.Now;
            Btn_MiPerfil.Hide();
            Btn_CerrarSesion.Hide();
            MostrarPeliculasEnDataGridView();
            MostrarSalasEnDataGridView();
            MostrarFuncionesEnDataGridView();
            CargarListaUbicacion();

            if (cine.UsuarioActual == null)
            {
                Label_MiCredito_Principal.Hide();
                label8.Hide();
            }
            else if (cine.UsuarioActual != null)
            {

                this.Label_MiCredito_Principal.Text = cine.UsuarioActual.Credito.ToString();
            }

        }

        //DELEGADOS
        public delegate void IniciarVentanaLogin();
        public delegate void AbrirRegistro();
        public delegate void AbrirMiPerfil();

        //REFRESH
        public void Refresh()
        {
            Btn_MiPerfil.Hide();
            Btn_CerrarSesion.Hide();
            btnRegistrarse.Show();
            button3.Show();
            this.Input_FechaPpal.Value = DateTime.Now;


        }

        private void Btn_RefrescarPpal_Click(object sender, EventArgs e)
        {
            MostrarPeliculasEnDataGridView();
            MostrarSalasEnDataGridView();
            MostrarFuncionesEnDataGridView();
            this.Input_FechaPpal.Value = DateTime.Now;
            if (cine.UsuarioActual != null)
            {

                this.Label_MiCredito_Principal.Text = cine.UsuarioActual.Credito.ToString();
            }

        }

        //MOSTRAR
        private void MostrarPeliculasEnDataGridView()
        {

            List<Pelicula> peliculas = cine.MostrarPeliculas();

            // Limpiar el DataGridView
            dataGridPeliculasPpal.Rows.Clear();

            // Agregar las películas al DataGridView
            foreach (Pelicula pelicula in peliculas)
            {
                // Agregar una nueva fila al DataGridView con los datos de la película
                dataGridPeliculasPpal.Rows.Add(pelicula.PeliculaToString());
            }


        }

        private void MostrarFuncionesEnDataGridView()
        {
            List<Funcion> funciones = cine.MostrarFunciones();

            // Limpiar el DataGridView
            dataGridFuncionesPpal.Rows.Clear();

            // Agregar las películas al DataGridView
            foreach (Funcion funcion in funciones)
            {
                DateTime fechaActual = DateTime.Now;

                if (funcion.Fecha >= fechaActual)
                {
                    // Agregar una nueva fila al DataGridView con los datos de la película
                    dataGridFuncionesPpal.Rows.Add(funcion.ToString());
                }

            }

        }

        private void MostrarSalasEnDataGridView()
        {

            List<Sala> salas = cine.MostrarSalas();

            // Limpiar el DataGridView
            dataGridSalasPpal.Rows.Clear();

            // Agregar las películas al DataGridView
            foreach (Sala sala in salas)
            {
                // Agregar una nueva fila al DataGridView con los datos de la película
                dataGridSalasPpal.Rows.Add(sala.SalaToString());
            }

        }

        private void CargarListaUbicacion()
        {
            this.Input_UbicacionPpal.Items.Clear();

            foreach (Sala s in cine.MostrarSalas())
            {
                string salaDatos = s.Ubicacion.ToString();
                this.Input_UbicacionPpal.Items.Add(salaDatos);
            }

        }

        //TABLAS DATAGRID
        private void PestañasPpal_SelectedIndexChange(object sender, EventArgs e)
        {

        }

        private void DataGridPeliculasPpal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idPeliculaSeleccionada = int.Parse(dataGridPeliculasPpal[0, e.RowIndex].Value.ToString());

            dataGridFuncionesPpal.Rows.Clear();

            bool flagFuncionOk = false;

            foreach (Funcion f in cine.MostrarFunciones())
            {
                if (f.MiPelicula.ID == idPeliculaSeleccionada)
                {
                    if (f.Fecha >= DateTime.Today)
                    {
                        dataGridFuncionesPpal.Rows.Add(f.ToString());
                        flagFuncionOk = true;
                    }
                }

            }

            if (!flagFuncionOk)
            {
                MessageBox.Show("No hay funciones para la pelicula seleccionada actualmente.", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            PestañasPpal.SelectedIndex = 2;
        }

        private void DataGridSalasPpal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idSalaSeleccionada = int.Parse(dataGridSalasPpal[0, e.RowIndex].Value.ToString());

            dataGridFuncionesPpal.Rows.Clear();

            foreach (Funcion f in cine.MostrarFunciones())
            {
                if (f.MiSala.ID == idSalaSeleccionada)
                {
                    dataGridFuncionesPpal.Rows.Add(f.ToString());
                }
            }
        }

        private void DataGridFuncionesPpal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idFuncionSeleccionada = int.Parse(dataGridFuncionesPpal.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        //LOGIN
        private void Btn_AbrirRegistro(object sender, EventArgs e)
        {
            this.abrirRegistro();
        }

        private void Btn_IniciarSesion(object sender, EventArgs e)
        {
            Btn_MiPerfil.Show();
            Btn_CerrarSesion.Show();
            btnRegistrarse.Hide();
            button3.Hide();
            Label_MiCredito_Principal.Show();
            label8.Show();
            this.iniciarVentanaLogin();

        }

        private void Btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            cine.CerrarSesion();
            Refresh();
        }

        //OPCIONES USUARIO LOGUEADO
        private void Btn_MiPerfil_Click(object sender, EventArgs e)
        {
            abrirMiPerfil();
        }

        private void Btn_ComprarEntradas_Click(object sender, EventArgs e)
        {

            if (int.TryParse(this.Input_CantEntradas.Text, out int cantEntradas))
            {
                // Realizar la compra de entradas
                //@modificar esto
                int peticion = cine.ComprarEntrada(cine.UsuarioActual, idFuncionSeleccionada, cantEntradas);
                if (peticion == 200)
                {
                    MostrarFuncionesEnDataGridView();
                    MessageBox.Show("Entrada comprada con exito.");

                }
                else
                {
                    MessageBox.Show("No se pudo realizar la compra de entradas.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida de entradas.");
            }

        }

        //OPCIONES SIN LOGUEO
        private void Btn_BuscarPpal_Click(object sender, EventArgs e)
        {

            string pelicula = Input_PeliculaPpal.Text;
            string ubicacion = Input_UbicacionPpal.Text;
            DateTime fecha = DateTime.Parse(Input_FechaPpal.Text);
            int.TryParse(Input_PrecioMinimoPpal.Text, out int PrecioMin);
            int.TryParse(Input_PrecioMaximoPpal.Text, out int PrecioMax);


            List<Funcion> funcionEncontrada = cine.BuscarFuncion(pelicula, ubicacion, fecha, PrecioMin, PrecioMax);

            dataGridFuncionesPpal.Rows.Clear();

            foreach (Funcion funcion in funcionEncontrada)
            {
                dataGridFuncionesPpal.Rows.Add(funcion.ToString());
            }

            if (funcionEncontrada.Count == 0)
            {
                MessageBox.Show("Oops! No se encontraron las funciones seleccionadas.");
            }




        }
    }
}
