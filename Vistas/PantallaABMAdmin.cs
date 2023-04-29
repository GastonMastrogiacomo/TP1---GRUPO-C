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
            RefreshFunciones();
            RefreshPeliculas();
            RefreshSalas();

        }

        //DELEGADOS
        public delegate void volverPantallaPrincipal();
        public delegate void AbrirPantallaCargaFunciones(Usuario usuarioAuxiliar);

        //GENERALES
        private void PantallaABMAdmin_Load(object sender, EventArgs e)
        {
        }
        private void Pestañas_Selected(object sender, TabControlEventArgs e)
        {

            switch (Pestañas.SelectedIndex)
            {

                case 0:
                    {
                        //salas
                        RefreshSalas();
                        break;
                    }
                case 1:
                    {
                        //funciones
                        RefreshFunciones();
                        break;
                    }
                case 2:
                    {
                        // peliculas
                        RefreshPeliculas();
                        break;
                    }
                case 3:
                    {
                        //usuarios
                        RefreshUsuarios();
                        break;
                    }
            }



        }
        private void Pestañas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Btn_CerrarSesion(object sender, EventArgs e)
        {
            miCine.CerrarSesion();
            pantallaPrincipal();
        }

        //SALAS
        private void RefreshSalas()
        {
            dataGridSalas.Rows.Clear();

            foreach (Sala sal in miCine.MostrarSalas())
            {
                dataGridSalas.Rows.Add(sal.SalaToString());
            }
        }
        private void Btn_RefrescarSalas_Click(object sender, EventArgs e)
        {
            RefreshSalas();
        }
        private void DataGridSalas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string ID = dataGridSalas[0, e.RowIndex].Value.ToString();
                this.Label_SalaId.Text = dataGridSalas[0, e.RowIndex].Value.ToString();
                this.Input_Ubicacion.Text = dataGridSalas[1, e.RowIndex].Value.ToString();
                this.Input_Capacidad.Text = dataGridSalas[2, e.RowIndex].Value.ToString();

                List<Sala> salas = miCine.MostrarSalas();
                this.SalaAuxiliar = salas.FirstOrDefault(s => s.ID == int.Parse(ID));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("No existen filas en la tabla. Cree una!");
            }

        }
        private void Salas_Click(object sender, EventArgs e)
        {

        }

        private void Btn_NuevoSala_Click(object sender, EventArgs e)
        {

            string Ubicacion = this.Input_Ubicacion.Text;
            int.TryParse(this.Label_SalaId.Text, out int DNI);
            int.TryParse(this.Input_Capacidad.Text, out int Capacidad);

            Sala nuevo = new Sala(Ubicacion, Capacidad);

            if (miCine.AgregarSala(nuevo))
            {
                RefreshSalas();
            }





        }
        private void Btn_ModificarSala_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_SalaId.Text, out int ID);
            string Ubicacion = this.Input_Ubicacion.Text;
            int Capacidad = int.Parse(this.Input_Capacidad.Text);


            Sala nuevo = new Sala(Ubicacion, Capacidad, ID);
            if (miCine.ModificarSala(ID, nuevo))
            {
                RefreshSalas();
            }
        }
        private void Btn_EliminarSala_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_SalaId.Text, out int ID);

            Sala sala = miCine.ObtenerSalaPorId(ID);

            for (int i = 0; i < sala.MisFunciones.Count; i++)
            {
                Funcion funcionActual = sala.MisFunciones[i];
                funcionActual.MiSala = null;
                miCine.ModificarFuncion(funcionActual.ID, funcionActual);

            }

            if (miCine.EliminarSala(ID))
            {
                RefreshSalas();
            }
        }
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

        //PELICULAS
        private void RefreshPeliculas()
        {
            dataGridPeliculas.Rows.Clear();

            foreach (Pelicula pel in miCine.MostrarPeliculas())
            {
                this.dataGridPeliculas.Rows.Add(pel.PeliculaToString());
            }

            Cb_Funciones.Items.Clear();
            foreach (Funcion f in miCine.MostrarFunciones())
            {
                string stringFuncion = f.ID.ToString() + ", " + f.MiPelicula.Nombre + ". " + f.Fecha.ToString();
                this.Cb_Funciones.Items.Add(stringFuncion);
            }
        }
        private void Btn_RefrescarPeliculas(object sender, EventArgs e)
        {
            RefreshPeliculas();
        }
        private void DataGridPeliculas_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            this.Label_PeliculaId.Text = dataGridPeliculas[0, e.RowIndex].Value.ToString();
            this.Input_Nombre_Pelicula.Text = dataGridPeliculas[1, e.RowIndex].Value.ToString();
            this.Input_Descripcion.Text = dataGridPeliculas[2, e.RowIndex].Value.ToString();
            this.Input_Sinopsis.Text = dataGridPeliculas[3, e.RowIndex].Value.ToString();
            this.Input_Poster.Text = dataGridPeliculas[4, e.RowIndex].Value.ToString();
            this.Input_Duracion.Text = dataGridPeliculas[5, e.RowIndex].Value.ToString();
            this.Cb_Funciones.SelectedIndex = e.RowIndex;

            List<Pelicula> peliculas = miCine.MostrarPeliculas();
            this.PeliculaAuxiliar = peliculas.FirstOrDefault(p => p.ID == int.Parse(Label_PeliculaId.Text));
        }
        private void Btn_EliminarPelicula_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_PeliculaId.Text, out int ID);

            Pelicula peli = miCine.ObtenerPeliculaPorId(ID);

            for (int i = 0; i < peli.MisFunciones.Count; i++)
            {
                Funcion funcionActual = peli.MisFunciones[i];
                funcionActual.MiPelicula = null;
                miCine.ModificarFuncion(funcionActual.ID, funcionActual);

            }
            if (miCine.EliminarPelicula(ID))
            {
                RefreshPeliculas();
            }
        }
        private void Btn_ModificarPelicula_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_PeliculaId.Text, out int ID);
            string nombre = this.Input_Nombre_Pelicula.Text;
            string descripcion = this.Input_Descripcion.Text;
            string sinopsis = this.Input_Sinopsis.Text;
            string poster = this.Input_Poster.Text;
            int.TryParse(this.Input_Duracion.Text, out int duracion);

            Pelicula nuevo = new Pelicula(nombre, descripcion, sinopsis, poster, duracion, ID);

            if (miCine.ModificarPelicula(ID, nuevo))
            {
                RefreshPeliculas();
            }


        }
        private void Btn_NuevoPelicula_Click(object sender, EventArgs e)
        {

            string nombre = this.Input_Nombre_Pelicula.Text;
            string descripcion = this.Input_Descripcion.Text;
            string sinopsis = this.Input_Sinopsis.Text;
            string poster = this.Input_Poster.Text;

            int.TryParse(this.Input_Duracion.Text, out int duracion);



            Pelicula nuevo = new Pelicula(nombre, descripcion, sinopsis, poster, duracion);

            if (miCine.AgregarPelicula(nuevo))
            {
                RefreshPeliculas();
            }
        }

        //FUNCIONES
        private void RefreshFunciones()
        {
            dataGridFunciones.Rows.Clear();

            foreach (Funcion fun in miCine.MostrarFunciones())
            {
                dataGridFunciones.Rows.Add(fun.ToString());
            }

            this.Cb_Salas.Items.Clear();

            foreach (Sala s in miCine.MostrarSalas())
            {
                string salaDatos = s.ID.ToString() + ", " + s.Ubicacion.ToString();
                this.Cb_Salas.Items.Add(salaDatos);
            }

            this.Cb_Peliculas.Items.Clear();


            foreach (Pelicula pel in miCine.MostrarPeliculas())
            {
                string peliDatos = pel.ID.ToString() + ", " + pel.Nombre;
                this.Cb_Peliculas.Items.Add(peliDatos);
            }



        }
        private void Btn_RefrescarFunciones_Click(object sender, EventArgs e)
        {
            RefreshFunciones();
        }
        private void DataGridFunciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Label_FuncionId.Text = dataGridFunciones[0, e.RowIndex].Value.ToString();

            string fecha1 = dataGridFunciones[1, e.RowIndex].Value.ToString();
            DateTime fecha = DateTime.Parse(fecha1);
            this.Selec_Fecha.Value = fecha;
            this.Input_CantidadClientes.Text = dataGridFunciones[2, e.RowIndex].Value.ToString();
            this.Input_Costo.Text = dataGridFunciones[3, e.RowIndex].Value.ToString();

            string salaId = (string)dataGridFunciones[4, e.RowIndex].Value;
            if (salaId == "" || salaId == null)
            {
                this.Cb_Salas.SelectedIndex = 0;
            }
            else
            {
                this.Cb_Salas.SelectedIndex = int.Parse(dataGridFunciones[4, e.RowIndex].Value.ToString()) - 1;

            }

            string peliId = (string)dataGridFunciones[6, e.RowIndex].Value;

            if (peliId == "" || peliId == null)
            {
                this.Cb_Peliculas.SelectedIndex = 0;
            }
            else
            {
                this.Cb_Peliculas.SelectedIndex = int.Parse(dataGridFunciones[6, e.RowIndex].Value.ToString()) - 1;

            }

            List<Funcion> funciones = miCine.MostrarFunciones();
            this.FuncionAuxiliar = funciones.FirstOrDefault(f => f.ID == int.Parse(this.Label_FuncionId.Text));

        }
        private void Btn_NuevaFuncion_Click(object sender, EventArgs e)
        {


            string salaSelected = (string)this.Cb_Salas.SelectedItem;
            if (salaSelected != null && salaSelected != "")
            {
                string salaSelectedID = salaSelected.Split(",")[0];
                List<Sala> salas = miCine.MostrarSalas();
                Sala salaElegida = salas.FirstOrDefault(s => s.ID == int.Parse(salaSelectedID));

                if (salaElegida != null)
                {
                    string peliSelected = (string)this.Cb_Peliculas.SelectedItem;

                    if (peliSelected != null && peliSelected != "")
                    {
                        string peliSelectedID = peliSelected.Split(",")[0];
                        List<Pelicula> peliculas = miCine.MostrarPeliculas();


                        Pelicula peliElegida = peliculas.FirstOrDefault(p => p.ID == int.Parse(peliSelectedID));
                        if (peliElegida != null)
                        {

                            int.TryParse(this.Input_CantidadClientes.Text, out int CantidadClientes);
                            int.TryParse(this.Input_Costo.Text, out int Costo);

                            if (Costo != 0)
                            {
                                DateTime Fecha = this.Selec_Fecha.Value;

                                Funcion nuevo = new Funcion(salaElegida, peliElegida, Fecha, CantidadClientes, Costo);
                                if (miCine.AgregarFuncion(nuevo))
                                {
                                    RefreshFunciones();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Asegurece de cargar un costo", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("No se encontró la pelicula", "404 Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Asegurece de seleccionar una pelicula", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("No se encontró la sala.", "404 Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Asegurese de seleccionar una sala.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Btn_ModificarFuncion_Click(object sender, EventArgs e)
        {

            string salaSelected = (string)this.Cb_Salas.SelectedItem;
            if (salaSelected != null && salaSelected != "")
            {
                string salaSelectedID = salaSelected.Split(",")[0];
                List<Sala> salas = miCine.MostrarSalas();
                Sala salaElegida = salas.FirstOrDefault(s => s.ID == int.Parse(salaSelectedID));

                if (salaElegida != null)
                {
                    string peliSelected = (string)this.Cb_Peliculas.SelectedItem;

                    if (peliSelected != null && peliSelected != "")
                    {
                        string peliSelectedID = peliSelected.Split(",")[0];
                        List<Pelicula> peliculas = miCine.MostrarPeliculas();


                        Pelicula peliElegida = peliculas.FirstOrDefault(p => p.ID == int.Parse(peliSelectedID));
                        if (peliElegida != null)
                        {

                            int.TryParse(Label_FuncionId.Text, out int ID);
                            DateTime Fecha = this.Selec_Fecha.Value;
                            int.TryParse(this.Input_CantidadClientes.Text, out int CantidadClientes);
                            double.TryParse(this.Input_Costo.Text, out double Costo);

                            Funcion nuevo = new Funcion(salaElegida, peliElegida, Fecha, CantidadClientes, Costo, ID);

                            if (miCine.ModificarFuncion(ID, nuevo))
                            {
                                RefreshFunciones();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la pelicula", "404 Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Asegurece de seleccionar una pelicula", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("No se encontró la sala.", "404 Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Asegurese de seleccionar una sala.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Btn_EliminarFuncion_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_FuncionId.Text, out int ID);

            Funcion func = miCine.ObtenerFuncionPorId(ID);

            for (int i = 0; i < func.Clientes.Count; i++)
            {
                Usuario user = func.Clientes[i];

                for (int j = 0; j < user.ObtenerMisFunciones().Count; j++)
                {
                    if (user.ObtenerMisFunciones()[j].ID == ID)
                    {
                        user.EliminarFuncion(user.ObtenerMisFunciones()[j].ID);
                        miCine.ModificarFuncion(func.ID, func);
                        break;
                    }
                }
                break;
            }

            Pelicula peli = miCine.ObtenerPeliculaPorId(func.MiPelicula.ID);


            for (int i = 0; i < peli.ObtenerMisFunciones().Count; i++)
            {
                if (peli.ObtenerMisFunciones()[i].ID == ID)
                {
                    peli.EliminarFuncion(peli.ObtenerMisFunciones()[i].ID);
                    //miCine.Modifi
                }
            }

            if (miCine.EliminarFuncion(ID))
            {
                RefreshFunciones();
            }
        }
        private void Funciones_Click(object sender, EventArgs e)
        {

        }

        //USUARIOS
        private void RefreshUsuarios()
        {
            dataGridUsuarios.Rows.Clear();

            foreach (Usuario user in miCine.MostrarUsuarios())
            {
                dataGridUsuarios.Rows.Add(user.ToString());
            }
        }
        private void Btn_RefrescarUsuarios(object sender, EventArgs e)
        {
            RefreshUsuarios();
        }
        private void DataGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Label_IdUsuario.Text = dataGridUsuarios[0, e.RowIndex].Value.ToString();
            this.Input_DNI.Text = dataGridUsuarios[1, e.RowIndex].Value.ToString();
            this.Input_Nombre.Text = dataGridUsuarios[2, e.RowIndex].Value.ToString();
            this.Input_Apellido.Text = dataGridUsuarios[3, e.RowIndex].Value.ToString();
            this.Input_Mail.Text = dataGridUsuarios[4, e.RowIndex].Value.ToString();
            this.Input_Password.Text = dataGridUsuarios[5, e.RowIndex].Value.ToString();
            this.Input_IntentosFallidos.Text = dataGridUsuarios[6, e.RowIndex].Value.ToString();
            this.Cb_Bloqueado.Checked = bool.Parse(dataGridUsuarios[7, e.RowIndex].Value.ToString());

            List<Usuario> usuarios = miCine.MostrarUsuarios();

            this.UsuarioAuxiliar = usuarios.FirstOrDefault(u => u.ID == int.Parse(this.Label_IdUsuario.Text));

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
                RefreshUsuarios();
            }


        }
        private void Btn_ModificarUsuario_Click(object sender, EventArgs e)
        {

            int.TryParse(Label_IdUsuario.Text, out int ID);
            MessageBox.Show("ID: " + ID.ToString());
            string Nombres = this.Input_Nombre.Text;
            string Apellidos = this.Input_Apellido.Text;
            int.TryParse(this.Input_DNI.Text, out int DNI);
            string Mail = this.Input_Mail.Text;
            string Pass = this.Input_Password.Text;
            DateTime FechaNacimiento = this.Selec_FechaDeNacimiento.Value;
            bool esAdmin = this.Cb_EsAdmin.Checked;

            Usuario nuevo = new Usuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, ID);
            if (miCine.ModificarUsuario(ID, nuevo))
            {
                RefreshUsuarios();
            }
        }
        private void Btn_EliminarUsuario_Click(object sender, EventArgs e)
        {

            int.TryParse(Label_IdUsuario.Text, out int ID);

            Usuario user = miCine.ObtenerUsuarioPorId(ID);

            for (int i = 0; i < user.MisFunciones.Count; i++)
            {
                Funcion funcionActual = user.MisFunciones[i];
                funcionActual.EliminarCliente(ID);
                miCine.ModificarFuncion(funcionActual.ID, funcionActual);

            }

            if (miCine.EliminarUsuario(ID))
            {
                RefreshUsuarios();
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


    }
}
