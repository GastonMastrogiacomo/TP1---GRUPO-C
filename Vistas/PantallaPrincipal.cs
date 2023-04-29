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
            MostrarPeliculasEnDataGridView();
            MostrarSalasEnDataGridView();
            MostrarFuncionesEnDataGridView();
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

                if (funcion.Fecha >=  fechaActual)
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

        private int idPeliculaSeleccionada;

        private void dataGridPeliculas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idPeliculaSeleccionada = int.Parse(dataGridPeliculasPpal[0, e.RowIndex].Value.ToString());



            dataGridFuncionesPpal.Rows.Clear();

            foreach (Funcion f in cine.MostrarFunciones())
            {
                if (f.MiPelicula.ID == idPeliculaSeleccionada)
                {
                    //string fecha = f.Fecha.ToString("dd/MM/yyyy");
                    //string cantidadClientes = f.CantidadClientes.ToString();
                    //string costo = f.Costo.ToString();
                    //string idMiSala = f.MiSala.ID.ToString();
                    //string capacidadMiSala = f.MiSala.Capacidad.ToString();
                    //string idPelicula = f.MiPelicula.ID.ToString();
                    //string nombrePelicula = f.MiPelicula.Nombre.ToString();
                    //string idsClientesArr = ObtenerIdsClientes(f);


                    //dataGridFuncionesPpal.Rows.Add(fecha, cantidadClientes, costo, idMiSala, capacidadMiSala, idPelicula, nombrePelicula, idsClientesArr);

                    dataGridFuncionesPpal.Rows.Add(f.ToString());


                    // dataGridViewTextBoxColumn3, Fecha, Cant_Clientes, Costo, Id_MiSala, Capacidad_MiSala, Id_Pelicula, Nombre_Pelicula, IDS_Clientes_Arr }
                }

            }

        }

        private int idSalaSeleccionada;

        private void dataGridSalas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void Btn_BuscarPpal_Click(object sender, EventArgs e)
        {
            string Ubicacion = Input_UbicacionPpal.Text;
            DateTime Fecha = Input_FechaPpal.Value;
            int.TryParse(Input_PrecioMinimoPpal.Text, out int PrecioMin);
            int.TryParse(Input_PrecioMaximoPpal.Text, out int PrecioMax);
            string Pelicula = Input_PeliculaPpal.Text;

            cine.Busqueda(Pelicula, Fecha, PrecioMax, PrecioMin, Ubicacion);



        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            switch (tabControl1.SelectedIndex)
            {

                case 0:
                    {
                        //peliculas
                        MostrarPeliculasEnDataGridView();
                        break;
                    }
                case 1:
                    {
                        //salas
                        MostrarSalasEnDataGridView();
                        break;
                    }
                case 2:
                    {
                        //funciones
                        MostrarFuncionesEnDataGridView();
                       
                        break;
                    }
            }

        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
