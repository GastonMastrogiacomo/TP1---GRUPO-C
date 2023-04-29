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
    public partial class PantallaMiPerfil : Form
    {
        private Cine miCine;
        public VolverPantallaPrincipal volverPantallaPrincipal;
        public VolverAtras volverAtras;

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

        //Label_UserCredito.Text= miCine.UsuarioActual.Credito.ToString()




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
            double Credito=double.Parse(this.Label_MiCredito.Text);

            Usuario nuevo = new Usuario(DNI, Nombres, Apellidos, Mail, Pass, FechaNacimiento, esAdmin, ID);
            nuevo.Credito = miCine.UsuarioActual.Credito;
            foreach(Funcion fun in miCine.UsuarioActual.ObtenerMisFunciones())
            {
                nuevo.AgregarFuncion(fun);
            }
            if (miCine.ModificarUsuario(ID, nuevo))
            {

                // Actualizar la visualización del nuevo usuario en los inputs

                Label_IDPerfil.Text = nuevo.ID.ToString();
                Input_NombrePerfil.Text = nuevo.Nombre;
                Input_ApellidoPerfil.Text = nuevo.Apellido;
                Input_DNIPerfil.Text = nuevo.DNI.ToString();
                Input_MailPerfil.Text = nuevo.Mail;
                Input_PasswordPerfil.Text = nuevo.Password;
                DateTime_MiPerfil.Value = nuevo.FechaNacimiento;

                MostrarDatosUsuario();

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


            if (miCine.CargarCredito(usuarioActual.ID, cantidadCreditos))
            {
                Label_MiCredito.Text = usuarioActual.Credito.ToString();

            }


        }


        private void MostrarFuncionesProximas()
        {

            dataGridPasadasFunciones.Rows.Clear();

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
            Usuario usuarioActual = miCine.UsuarioActual;
            int cantidadEntradasSeleccionadas = usuarioActual.EntradasCompradas[idFuncionSeleccionada];

            //ver porque creo que devovler entrada no elimina la funcion del usuario
            if (miCine.DevolverEntrada(idFuncionSeleccionada,cantidadEntradasSeleccionadas)) {
                MessageBox.Show("Devolvemos la entrada.");
                MostrarFuncionesProximas();
            }
            else
            {
                MessageBox.Show("No se pudo realizar la devolucion de entradas.");

            }

        }

        private int idFuncionSeleccionada;

        private void dataGridProximasFunciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // dataGridFunciones[0, e.RowIndex].Value.ToString();
            idFuncionSeleccionada = int.Parse(dataGridProximasFunciones[0, e.RowIndex].Value.ToString());

        }
    }
}






