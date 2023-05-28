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
using static TP1___GRUPO_C.Vistas.PantallaABMAdmin;

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaCargaFunciones : Form
    {
        private Cine miCine;
        private Usuario UsuarioAuxiliar;
        public CerrarPantallaCargaFunciones cerrarPantallaCargaFunciones;
        public CerrarYGuardarPantallaCargaFunciones cerrarYGuardarPantallaCargaFunciones;
        //public AbrirPantallaEdicionFunciones abrirPantallaEdicionFunciones;

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
        //public delegate void AbrirPantallaEdicionFunciones(Usuario UsuarioAuxiliar);

        private void CargarListaFuncionesUsuario()
        {
            this.Clb_FuncionesUsuario.Items.Clear();

            if (this.UsuarioAuxiliar.MisFunciones.Count > 0)
            {
                for (int i = 0; i < this.UsuarioAuxiliar.MisFunciones.Count; i++)
                {
                    Funcion func = this.UsuarioAuxiliar.MisFunciones[i];
                    Pelicula p = miCine.MostrarPeliculas().FirstOrDefault(p => p.ID == func.idPelicula);
                    string NombrePelicula = "";
                    if (p != null)
                    {
                        NombrePelicula = p.Nombre.ToString();
                    }
                  
                    string FechaFuncion = func.Fecha.ToString();

                    Sala s = miCine.MostrarSalas().FirstOrDefault(s => s.ID == func.idSala);
                    string Ubicacion = "";
                    if (s != null)
                    {
                        Ubicacion = s.Ubicacion;
                    }
                    string Sala = Ubicacion.ToString();

                    string Linea = NombrePelicula + " en " + Sala + ". Fecha: " + FechaFuncion;
                    this.Clb_FuncionesUsuario.Items.Insert(i, Linea);
                }
            }
        }

        private void CargarListaFuncionesCine()
        {
            foreach (Funcion func in miCine.MostrarFunciones())
            {
                Pelicula p = miCine.MostrarPeliculas().FirstOrDefault(p => p.ID == func.idPelicula);
                string NombrePelicula = "";
                if (p != null)
                {
                    NombrePelicula = p.Nombre.ToString();
                }
              
                string FechaFuncion = func.Fecha.ToString();

                Sala s = miCine.MostrarSalas().FirstOrDefault(s => s.ID == func.idSala);
                string Ubicacion = "";
                if (s != null)
                {
                    Ubicacion = s.Ubicacion.ToString();
                }

                string Sala = Ubicacion.ToString();
                string Linea = func.ID+ ". "  +  NombrePelicula + " en " + Sala + ". Fecha: " + FechaFuncion;
               
                this.Clb_FuncionesCine.Items.Insert(this.Clb_FuncionesCine.Items.Count, Linea);
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
            //abrirPantallaEdicionFunciones(UsuarioAuxiliar);
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
                    //le sumo 1 xq antes lo reste en el indice del item. (en la vista)
                    Funcion func = miCine.MostrarFunciones().FirstOrDefault(f => f.ID == (i + 1));
                    if (func != null)
                    {
                        UsuarioAuxiliar.MisFunciones.Add(func);
                     }                  
                }
            }

            
            Clb_FuncionesUsuario.Items.Clear();
            cerrarYGuardarPantallaCargaFunciones();
        }

        private void GuardarDatosUsuarioAuxiliar()
        {
            for (int i = 0; i < Clb_FuncionesUsuario.Items.Count; i++)
            {
                List<Funcion> funciones = miCine.MostrarFunciones();
                int.TryParse(Clb_FuncionesUsuario.Items[i].ToString().Split(".")[0], out int IDFuncion);
                
                Funcion func = funciones.FirstOrDefault(f => f.ID == IDFuncion);
                if (func != null)
                {
                    UsuarioAuxiliar.MisFunciones.Add(func);
                    miCine.agregarUsuarioFuncion(UsuarioAuxiliar.ID,func.ID);
                }
            }
            int peticion = miCine.ModificarUsuario(UsuarioAuxiliar.ID, UsuarioAuxiliar.DNI, UsuarioAuxiliar.Nombre, UsuarioAuxiliar.Apellido, UsuarioAuxiliar.Mail, UsuarioAuxiliar.Password, UsuarioAuxiliar.FechaNacimiento, UsuarioAuxiliar.EsAdmin, UsuarioAuxiliar.IntentosFallidos, UsuarioAuxiliar.Bloqueado, UsuarioAuxiliar.Credito);

           
            String mensaje = StatusCode.ObtenerMensaje(peticion);
            if (peticion != 200)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Se actualizaron correctamente las funciones de " + UsuarioAuxiliar.Nombre);
            }
        }


    }
}
