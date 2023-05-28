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
using static TP1___GRUPO_C.PantallaPrincipal;

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaABMAdmin : Form
    {

        private Cine miCine;
        public AbrirPantallaCargaFunciones abrirPantallaCargaFunciones;
        public volverPantallaPrincipal pantallaPrincipal;
        private Usuario UsuarioAuxiliar;
        private Sala SalaAuxiliar;
        private Funcion FuncionAuxiliar;
        private Pelicula PeliculaAuxiliar;

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
        //borrar
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

        private void RefreshPeliculas()
        {
            dataGridPeliculas.Rows.Clear();

            foreach (Pelicula pel in miCine.MostrarPeliculas())
            {
                this.dataGridPeliculas.Rows.Add(pel.PeliculaToString());
            }

            this.CLB_Funciones.Items.Clear();
            foreach (Funcion f in miCine.MostrarFunciones())
            {
                //string stringFunc = f.ID.ToString() + ", " + f.MiPelicula.Nombre + ". " + f.Fecha.ToString();
                string stringFunc = f.ID.ToString() + ", " + f.Fecha.ToString();
                this.CLB_Funciones.Items.Add(stringFunc);
            }
        }

        private void Btn_RefrescarPeliculas(object sender, EventArgs e)
        {
            RefreshPeliculas();
        }

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

        //TABLAS DATAGRID
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

        private void DataGridPeliculas_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            this.Label_PeliculaId.Text = dataGridPeliculas[0, e.RowIndex].Value.ToString();
            this.Input_Nombre_Pelicula.Text = dataGridPeliculas[1, e.RowIndex].Value.ToString();
            this.Input_Descripcion.Text = dataGridPeliculas[2, e.RowIndex].Value.ToString();
            this.Input_Sinopsis.Text = dataGridPeliculas[3, e.RowIndex].Value.ToString();
            this.Input_Poster.Text = dataGridPeliculas[4, e.RowIndex].Value.ToString();
            this.Input_Duracion.Text = dataGridPeliculas[5, e.RowIndex].Value.ToString();

            //string idfunciones = datagridpeliculas[6, e.rowindex].value.tostring();

            List<Pelicula> peliculas = miCine.MostrarPeliculas();
            this.PeliculaAuxiliar = peliculas.FirstOrDefault(p => p.ID == int.Parse(Label_PeliculaId.Text));

            List<Funcion> funcionesPeli = this.PeliculaAuxiliar.MisFunciones;

            foreach (Funcion func in funcionesPeli)
            {
                CLB_Funciones.SetItemChecked(func.ID - 1, true);
            }

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

            string peliId = (string)dataGridFunciones[5, e.RowIndex].Value;

            if (peliId == "" || peliId == null)
            {
                this.Cb_Peliculas.SelectedIndex = 0;
            }
            else
            {
                this.Cb_Peliculas.SelectedIndex = int.Parse(dataGridFunciones[5, e.RowIndex].Value.ToString()) - 1;

            }

            List<Funcion> funciones = miCine.MostrarFunciones();
            this.FuncionAuxiliar = funciones.FirstOrDefault(f => f.ID == int.Parse(this.Label_FuncionId.Text));
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

            this.Input_Credito.Text = dataGridUsuarios[8, e.RowIndex].Value.ToString();
            String fecha1 = dataGridUsuarios[9, e.RowIndex].Value.ToString();
            String[] fechaArray = fecha1.Split("/"); // 0 => 20 / 1 => mes / 2 => año
            DateTime fecha = new DateTime(int.Parse(fechaArray[2]), int.Parse(fechaArray[1]), int.Parse(fechaArray[0]));
            this.Selec_FechaDeNacimiento.Value = fecha;
            this.Cb_EsAdmin.Checked = bool.Parse(dataGridUsuarios[10, e.RowIndex].Value.ToString());
        }

        #region ABM Sala
        private void Btn_NuevoSala_Click(object sender, EventArgs e)
        {
            string Ubicacion = this.Input_Ubicacion.Text;
            int.TryParse(this.Input_Capacidad.Text, out int Capacidad);

            int peticion = miCine.AgregarSala(Capacidad, Ubicacion);
            String mensaje = StatusCode.ObtenerMensaje(peticion);

            if (peticion == 200)
            {
                RefreshSalas();
            }

            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Btn_ModificarSala_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_SalaId.Text, out int ID);
            string Ubicacion = this.Input_Ubicacion.Text;
            int Capacidad = int.Parse(this.Input_Capacidad.Text);

            int peticion = miCine.ModificarSala(ID, Ubicacion, Capacidad);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshSalas();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_EliminarSala_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_SalaId.Text, out int ID);
            int peticion = miCine.EliminarSala(ID);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshSalas();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region ABM Funcion
        private void Btn_NuevaFuncion_Click(object sender, EventArgs e)
        {
            string salaSelected = (string)this.Cb_Salas.SelectedItem;
            int.TryParse(salaSelected.Split(",")[0], out int salaSelectedID);
            string peliSelected = (string)this.Cb_Peliculas.SelectedItem;
            int.TryParse(peliSelected.Split(",")[0], out int peliSelectedID);
            float.TryParse(this.Input_Costo.Text, out float Costo);
            DateTime Fecha = this.Selec_Fecha.Value;

            int peticion = miCine.AgregarFuncion(salaSelectedID, peliSelectedID, Fecha, Costo);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshFunciones();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_ModificarFuncion_Click(object sender, EventArgs e)
        {
            string salaSelected = (string)this.Cb_Salas.SelectedItem;
            int.TryParse(salaSelected.Split(",")[0], out int salaSelectedID);
            string peliSelected = (string)this.Cb_Peliculas.SelectedItem;
            int.TryParse(peliSelected.Split(",")[0], out int peliSelectedID);
            int.TryParse(Label_FuncionId.Text, out int ID);
            DateTime Fecha = this.Selec_Fecha.Value;
            double.TryParse(this.Input_Costo.Text, out double Costo);
            int.TryParse(Input_CantidadClientes.Text, out int cantidadClientes);
            int peticion = miCine.ModificarFuncion(ID, salaSelectedID, peliSelectedID, Fecha, Costo, cantidadClientes);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshFunciones();

            }

            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Btn_EliminarFuncion_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_FuncionId.Text, out int ID);

            int peticion = miCine.EliminarFuncion(ID);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshFunciones();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ABM Pelicula

        private void Btn_EliminarPelicula_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_PeliculaId.Text, out int ID);
            int peticion = miCine.EliminarPelicula(ID);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshPeliculas();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_ModificarPelicula_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_PeliculaId.Text, out int ID);
            string nombre = this.Input_Nombre_Pelicula.Text;
            string descripcion = this.Input_Descripcion.Text;
            string sinopsis = this.Input_Sinopsis.Text;
            string poster = this.Input_Poster.Text;
            int.TryParse(this.Input_Duracion.Text, out int duracion);

            List<string> funcionesSelec = new List<string>();

            for (int i = 0; i < CLB_Funciones.Items.Count; i++)
            {
                CheckState st = CLB_Funciones.GetItemCheckState(i);
                if (st.ToString() == "Checked")
                {
                    string idFunc = CLB_Funciones.Items[i].ToString().Split(",")[0];
                    funcionesSelec.Add(idFunc);
                }
            }
            int peticion = miCine.ModificarPelicula(ID, nombre, descripcion, sinopsis, poster, duracion, funcionesSelec);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshPeliculas();
            }

            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Btn_NuevoPelicula_Click(object sender, EventArgs e)
        {

            string nombre = this.Input_Nombre_Pelicula.Text;
            string descripcion = this.Input_Descripcion.Text;
            string sinopsis = this.Input_Sinopsis.Text;
            string poster = this.Input_Poster.Text;
            int.TryParse(this.Input_Duracion.Text, out int duracion);

            int peticion = miCine.AgregarPelicula(nombre, descripcion, sinopsis, poster, duracion);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshPeliculas();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ABM Usuario
        private void Btn_NuevoUsuario_Click(object sender, EventArgs e)
        {
            string Nombres = this.Input_Nombre.Text;
            string Apellidos = this.Input_Apellido.Text;
            int.TryParse(this.Input_DNI.Text, out int DNI);
            string Mail = this.Input_Mail.Text;
            string Pass = this.Input_Password.Text;
            DateTime FechaNacimiento = this.Selec_FechaDeNacimiento.Value;
            bool esAdmin = this.Cb_EsAdmin.Checked;
            float.TryParse(this.Input_Credito.Text, out float credito);

            int peticion = miCine.AgregarUsuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, credito, false);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshUsuarios();
            }

            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_ModificarUsuario_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_IdUsuario.Text, out int ID);
            string Nombres = this.Input_Nombre.Text;
            string Apellidos = this.Input_Apellido.Text;
            int.TryParse(this.Input_DNI.Text, out int DNI);
            string Mail = this.Input_Mail.Text;
            string Pass = this.Input_Password.Text;
            DateTime FechaNacimiento = this.Selec_FechaDeNacimiento.Value;
            bool esAdmin = this.Cb_EsAdmin.Checked;
            int.TryParse(Input_Credito.Text, out int Credito);
            bool Bloqueda = this.Cb_Bloqueado.Checked;
            int.TryParse(this.Input_IntentosFallidos.Text, out int IntentosFallidos);

            int peticion = miCine.ModificarUsuario(ID, DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, IntentosFallidos, Bloqueda, Credito);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshUsuarios();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_EliminarUsuario_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_IdUsuario.Text, out int ID);
            int peticion = miCine.EliminarUsuario(ID);
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion == 200)
            {
                RefreshUsuarios();
            }
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

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
