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
using static TP1___GRUPO_C.Vistas.PantallaABMAdmin;

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaCargaFunciones : Form
    {
        private Cine miCine;
        private Usuario UsuarioAuxiliar;
        public CerrarPantallaCargaFunciones cerrarPantallaCargaFunciones;
        public CerrarYGuardarPantallaCargaFunciones cerrarYGuardarPantallaCargaFunciones;
        public AbrirPantallaEdicionFunciones abrirPantallaEdicionFunciones;



        public PantallaCargaFunciones(Cine cine, Usuario UsuarioAuxiliar)
        {
            InitializeComponent();
            miCine = cine;
            this.UsuarioAuxiliar = UsuarioAuxiliar;
            CargarListaFuncionesUsuario();
            CargarListaFuncionesCine();

        }

        public delegate void CerrarPantallaCargaFunciones();
        public delegate void CerrarYGuardarPantallaCargaFunciones();
        public delegate void AbrirPantallaEdicionFunciones(Usuario UsuarioAuxiliar);

        private void CargarListaFuncionesUsuario()
        {

            this.Clb_FuncionesUsuario.Items.Clear();

            if (this.UsuarioAuxiliar.ObtenerMisFunciones().Count > 0)
            {
                for (int i = 0; i < this.UsuarioAuxiliar.ObtenerMisFunciones().Count; i++)
                {
                    Funcion func = this.UsuarioAuxiliar.ObtenerMisFunciones()[i];
                    string NombrePelicula = func.MiPelicula.Nombre.ToString();
                    string FechaFuncion = func.Fecha.ToString();
                    string Sala = func.MiSala.Ubicacion.ToString();

                    string Linea = NombrePelicula + " en " + Sala + ". Fecha: " + FechaFuncion;
                    this.Clb_FuncionesUsuario.Items.Insert(i, Linea);
                }
            }
        }

        private void CargarListaFuncionesCine()
        {
            foreach (Funcion func in miCine.MostrarFunciones())
            {
                string NombrePelicula = func.MiPelicula.Nombre.ToString();
                string FechaFuncion = func.Fecha.ToString();
                string Sala = func.MiSala.Ubicacion.ToString();

                string Linea = NombrePelicula + " en " + Sala + ". Fecha: " + FechaFuncion;
                // -1 porque los Id arrancan en 1 y el array en la pos 0
                this.Clb_FuncionesCine.Items.Insert(func.ID - 1, Linea);
            }
        }
        private void Btn_AgregarALista_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Clb_FuncionesCine.Items.Count; i++)
            {
                CheckState st = Clb_FuncionesCine.GetItemCheckState(i);
                if (st.ToString() == "Checked")
                {
                    if (!Clb_FuncionesUsuario.Items.Contains(Clb_FuncionesCine.Items[i]))
                    {
                        Clb_FuncionesUsuario.Items.Add(Clb_FuncionesCine.Items[i]);

                    }
                }
            }
            GuardarDatosUsuarioAuxiliar();
            abrirPantallaEdicionFunciones(UsuarioAuxiliar);

        }

        private void Btn_SacarDeLista_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Clb_FuncionesUsuario.Items.Count; i++)
            {
                CheckState st = Clb_FuncionesUsuario.GetItemCheckState(i);
                if (st.ToString() == "Checked")
                {
                    Clb_FuncionesUsuario.Items.RemoveAt(i);
                }
            }
        }

        private void Btn_SalirCargarLista_Click(object sender, EventArgs e)
        {
            Clb_FuncionesUsuario.Items.Clear();
            cerrarPantallaCargaFunciones();
        }


        private void Btn_GuardarYSalir_Click(object sender, EventArgs e)
        {

            if (Clb_FuncionesUsuario.Items.Count > 0)
            {
                for (int i = 0; i < Clb_FuncionesUsuario.Items.Count; i++)
                {
                    //le sumo 1 xq antes lo reste en el indice del item.
                    Funcion func = miCine.ObtenerFuncionPorId(i + 1);
                    UsuarioAuxiliar.AgregarFuncion(func);
                }
            }

            GuardarDatosUsuarioAuxiliar();
            Clb_FuncionesUsuario.Items.Clear();
            cerrarYGuardarPantallaCargaFunciones();


        }

        private void GuardarDatosUsuarioAuxiliar()
        {

            for (int i = 0; i < Clb_FuncionesUsuario.Items.Count; i++)
            {
                Funcion func = miCine.ObtenerFuncionPorId(i + 1);
                UsuarioAuxiliar.AgregarFuncion(func);
            }

            if (!miCine.ModificarUsuario(UsuarioAuxiliar.ID, UsuarioAuxiliar))
            {
                MessageBox.Show("No se pudo actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Se actualizaron correctamente las funciones de " + UsuarioAuxiliar.Nombre);
            }
        }


    }
}
