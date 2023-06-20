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

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaMiPerfil : Form
    {
        private Cine miCine;
        public VolverPantallaPrincipal volverPantallaPrincipal;
        public VolverAtras volverAtras;
        private int idFuncionSeleccionada;


        public PantallaMiPerfil(Cine cine)
        {
            InitializeComponent();
            miCine = cine;
            MostrarDatosUsuario();
            MostrarFuncionesProximas();
            MostrarFuncionesPasadas();
        }

        public delegate void VolverPantallaPrincipal();
        public delegate void VolverAtras();

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Btn_CerrarSesionPerfil_Click(object sender, EventArgs e)
        {
            miCine.CerrarSesion();
            volverPantallaPrincipal();
        }

        private void PantallaMiPerfil_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        /*
        private void Btn_ModificarPerfil_Click(object sender, EventArgs e)
        {

            int.TryParse(Label_IDPerfil.Text, out int ID);
            string Nombres = this.Input_NombrePerfil.Text;
            string Apellidos = this.Input_ApellidoPerfil.Text;
            int.TryParse(this.Input_DNIPerfil.Text, out int DNI);
            string Mail = this.Input_MailPerfil.Text;
            string Pass = this.Input_PasswordPerfil.Text;
            DateTime FechaNacimiento = this.DateTime_MiPerfil.Value;
            bool esAdmin = false;
            double Credito = double.Parse(this.Label_MiCredito.Text);


            List<Usuario> usuarios = miCine.MostrarUsuarios();
            Usuario user = usuarios.FirstOrDefault(u => u.ID == ID);


            user.Credito = miCine.UsuarioActual.Credito;
            foreach (Funcion fun in miCine.UsuarioActual.ObtenerMisFunciones())
            {
                user.MisFunciones.Add(fun);
            }

            int peticion = miCine.ModificarUsuario(ID, DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, user.IntentosFallidos, user.Bloqueado, user.Credito);
            if (peticion == 200)
            {

                // Actualizar la visualización del nuevo usuario en los inputs

                Label_IDPerfil.Text = user.ID.ToString();
                Input_NombrePerfil.Text = user.Nombre;
                Input_ApellidoPerfil.Text = user.Apellido;
                Input_DNIPerfil.Text = user.DNI.ToString();
                Input_MailPerfil.Text = user.Mail;
                Input_PasswordPerfil.Text = user.Password;
                DateTime_MiPerfil.Value = user.FechaNacimiento;

                MostrarDatosUsuario();

            }

        }

        */

        private void Btn_ModificarPerfil_Click(object sender, EventArgs e)
        {
            int.TryParse(Label_IDPerfil.Text, out int ID);
            string Nombres = this.Input_NombrePerfil.Text;
            string Apellidos = this.Input_ApellidoPerfil.Text;
            int.TryParse(this.Input_DNIPerfil.Text, out int DNI);
            string Mail = this.Input_MailPerfil.Text;
            string Pass = this.Input_PasswordPerfil.Text;
            DateTime FechaNacimiento = this.DateTime_MiPerfil.Value;
            bool esAdmin = false;
            double Credito = double.Parse(this.Label_MiCredito.Text);

            // Validar campos en la vista
            if (ID == 0 || string.IsNullOrEmpty(Nombres) || string.IsNullOrEmpty(Apellidos) ||
                DNI == 0 || string.IsNullOrEmpty(Mail) || string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<Usuario> usuarios = miCine.MostrarUsuarios();
                Usuario user = usuarios.FirstOrDefault(u => u.ID == ID);

                user.Credito = miCine.UsuarioActual.Credito;
                foreach (Funcion fun in miCine.UsuarioActual.ObtenerMisFunciones())
                {
                    user.MisFunciones.Add(fun);
                }

                int peticion = miCine.ModificarUsuario(ID, DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, user.IntentosFallidos, user.Bloqueado, user.Credito);
                if (peticion == 200)
                {
                    // Actualizar la visualización del nuevo usuario en los inputs
                    Label_IDPerfil.Text = user.ID.ToString();
                    Input_NombrePerfil.Text = user.Nombre;
                    Input_ApellidoPerfil.Text = user.Apellido;
                    Input_DNIPerfil.Text = user.DNI.ToString();
                    Input_MailPerfil.Text = user.Mail;
                    Input_PasswordPerfil.Text = user.Password;
                    DateTime_MiPerfil.Value = user.FechaNacimiento;

                    MostrarDatosUsuario();
                }
            }

           
        }


        //Me parece que esta mal tener el mismo metodo pero en otra clase, despues ver como llamar al de PantallaABM
        private void MostrarDatosUsuario()
        {
            Usuario usuarioActual = miCine.UsuarioActual;

            Label_IDPerfil.Text = usuarioActual.ID.ToString();
            Input_NombrePerfil.Text = usuarioActual.Nombre;
            Input_ApellidoPerfil.Text = usuarioActual.Apellido;
            Input_DNIPerfil.Text = usuarioActual.DNI.ToString();
            Input_MailPerfil.Text = usuarioActual.Mail;
            Input_PasswordPerfil.Text = usuarioActual.Password;
            DateTime_MiPerfil.Value = usuarioActual.FechaNacimiento;
            Label_MiCredito.Text = usuarioActual.Credito.ToString();

        }

        private void Btn_ComprarCreditos_Click(object sender, EventArgs e)
        {

            Usuario usuarioActual = miCine.UsuarioActual;
            double cantidadCreditos;
            double.TryParse(Input_NuevoCreditoPerfil.Text, out cantidadCreditos);

            if (cantidadCreditos > 0 )
            {
                int peticion = miCine.CargarCredito(usuarioActual.ID, cantidadCreditos);
                String Mensaje = StatusCode.ObtenerMensaje(peticion);
                if (peticion == 200)
                {
                    Label_MiCredito.Text = usuarioActual.Credito.ToString();
                    MessageBox.Show(Mensaje + " Credito cargado con exito!");
                }
                else
                {
                    MessageBox.Show(Mensaje + "No se pudo cargar el credito!");
                }
            }
            else
            {
                MessageBox.Show("Credito tiene que ser > 0!");

            }




        }

        private void MostrarFuncionesProximas()
        {
            dataGridProximasFunciones.Rows.Clear();

            List<Funcion> funcionesProximas = miCine.UsuarioActual.MostrarFuncionesProximas();

            foreach (Funcion fun in funcionesProximas)
            {
                this.dataGridProximasFunciones.Rows.Add(fun.ToString());
            }

        }

        private void MostrarFuncionesPasadas()
        {
            dataGridPasadasFunciones.Rows.Clear();

            List<Funcion> pasadasFunciones = miCine.UsuarioActual.MostrarFuncionesPasadas();
            foreach (Funcion fun in pasadasFunciones)
            {
                this.dataGridPasadasFunciones.Rows.Add(fun.ToString());
            }
        }

        private void Btn_VolverAtrasPerfil_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void Btn_DevolverEntradas_Click(object sender, EventArgs e)
        {

            if (int.TryParse(this.Input_CantEntradas.Text, out int cantEntradas) && cantEntradas >= 1)
            {
                Usuario usuarioActual = miCine.UsuarioActual;

                int peticion = miCine.DevolverEntrada(usuarioActual, idFuncionSeleccionada, cantEntradas);
                if (peticion == 200)
                {
                    MessageBox.Show("Devolvemos la entrada.");
                    MostrarFuncionesProximas();
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la devolucion de entradas.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida de entradas.");
            }



        }

        private void dataGridProximasFunciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtengo el valor de ID Funcion para luego pasarselo a devolver entrada

            idFuncionSeleccionada = int.Parse(dataGridProximasFunciones.Rows[e.RowIndex].Cells[0].Value.ToString());

        }

     
    }
}






