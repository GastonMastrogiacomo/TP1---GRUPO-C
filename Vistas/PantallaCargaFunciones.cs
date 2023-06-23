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
        public AbrirPantallaEdicionFunciones abrirPantallaEdicionFunciones;

        public PantallaCargaFunciones(Cine cine, Usuario UsuarioAuxiliar)
        {
            InitializeComponent();
            miCine = cine;
            this.UsuarioAuxiliar = UsuarioAuxiliar;
            this.Label_CreditoUsuarioCargaFuncion.Text = UsuarioAuxiliar.Credito.ToString();
            CargarListaFuncionesUsuario();
            CargarListaFuncionesCine();
        }

        public delegate void CerrarPantallaCargaFunciones();
        public delegate void CerrarYGuardarPantallaCargaFunciones();
        public delegate void AbrirPantallaEdicionFunciones(Usuario UsuarioAuxiliar);

        private void CargarListaFuncionesUsuario()
        {
            this.FL_FuncionesUsuarioAdmin.Controls.Clear();

            if (this.UsuarioAuxiliar != null)
            {
                List<Funcion> FuncionesUsuario = this.UsuarioAuxiliar.MisFunciones.ToList();
                for (int i = 0; i < FuncionesUsuario.Count; i++)
                {
                    Pelicula p = miCine.MostrarPeliculas().FirstOrDefault(p => p.ID == FuncionesUsuario[i].idPelicula);
                    string nombrePelicula = "";

                    if (p != null)
                    {
                        nombrePelicula = p.Nombre.ToString();
                    }

                    string fecha = FuncionesUsuario[i].Fecha.ToString();

                    Sala s = miCine.MostrarSalas().FirstOrDefault(s => s.ID == FuncionesUsuario[i].idSala);
                    string ubicacion = "";

                    if (s != null)
                    {
                        ubicacion = s.Ubicacion.ToString();
                    }

                    string Linea = FuncionesUsuario[i].ID + ". " + nombrePelicula + " en " + ubicacion + ". Fecha: " + fecha;
                    RadioButton rb = new RadioButton();
                    rb.Text = Linea;
                    rb.Width = (TextRenderer.MeasureText(rb.Text, rb.Font)).Width + 20;
                    this.FL_FuncionesUsuarioAdmin.Controls.Add(rb);
                }
            }
        }

        private void CargarListaFuncionesCine()
        {
            this.FL_FuncionesDisponiblesAdmin.Controls.Clear();

            foreach (Funcion func in miCine.MostrarFunciones())
            {
                if (func.Fecha >= DateTime.Now)
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
                    string Linea = func.ID + ". " + NombrePelicula + " en " + Sala + ". Fecha: " + FechaFuncion;

                    RadioButton rb = new RadioButton();
                    rb.Text = Linea;
                    rb.Width = TextRenderer.MeasureText(rb.Text, rb.Font).Width + 20;
                    rb.Click += new EventHandler(this.radioButtonClickPrice);

                    this.FL_FuncionesDisponiblesAdmin.Controls.Add(rb);

                }
            }
        }

        private void radioButtonClickPrice(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int.TryParse(rb.Text.Split(".")[0], out int IDFuncion);
            Funcion fun = miCine.MostrarFunciones().FirstOrDefault(f => f.ID == IDFuncion);
            if (fun != null)
            {
                this.Label_CostoUnitarioFuncion.Text = fun.Costo.ToString();

            }
        }

        private void Btn_AgregarALista_Click(object sender, EventArgs e)
        {

            int response = 0;

            RadioButton seleccionado = FL_FuncionesDisponiblesAdmin.Controls
                        .OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

            try
            {

                if (seleccionado != null)
                {
                    int.TryParse(seleccionado.Text.ToString().Split(".")[0], out int IDFuncion);

                    
                   

                    int cantidadEntradas = 1;
                    if (TB_CantidadEntradasFuncionUsuario.Text != "")
                    {
                        int.TryParse(TB_CantidadEntradasFuncionUsuario.Text, out cantidadEntradas);
                    }

                    response = miCine.ComprarEntradaFuncionNotNull(UsuarioAuxiliar.ID, cantidadEntradas, IDFuncion);
                    if (response != 200) throw new Exception("Error en la compra de entradas");

                    if (!FL_FuncionesUsuarioAdmin.Controls.Contains(seleccionado))
                    {
                        seleccionado.Checked = false;
                        FL_FuncionesUsuarioAdmin.Controls.Add(seleccionado);
                        CargarListaFuncionesCine();
                    }
                }

                GuardarDatosUsuarioAuxiliar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Oops no se pudo realizar la compra de entradas...");
            }
        }


        private void Btn_SacarDeLista_Click(object sender, EventArgs e)
        {
            RadioButton seleccionado = FL_FuncionesUsuarioAdmin.Controls
                         .OfType<RadioButton>()
                         .FirstOrDefault(r => r.Checked);
            if (seleccionado != null)
            {
                FL_FuncionesUsuarioAdmin.Controls.Remove(seleccionado);
            }

        }


        private void Btn_SalirCargarLista_Click(object sender, EventArgs e)
        {
            FL_FuncionesUsuarioAdmin.Controls.Clear();
            cerrarPantallaCargaFunciones();
        }

        private void Btn_GuardarYSalir_Click(object sender, EventArgs e)
        {
            //TODO modificar esto asi se guardan las funciones del usuario seleccionadas
            if (FL_FuncionesUsuarioAdmin.Controls.Count > 0)
            {
                for (int i = 0; i < FL_FuncionesUsuarioAdmin.Controls.Count; i++)
                {
                    //le sumo 1 xq antes lo reste en el indice del item. (en la vista)
                    Funcion func = miCine.MostrarFunciones().FirstOrDefault(f => f.ID == (i + 1));
                    if (func != null)
                    {
                        UsuarioAuxiliar.MisFunciones.Add(func);
                    }
                }
            }


            FL_FuncionesUsuarioAdmin.Controls.Clear();
            cerrarYGuardarPantallaCargaFunciones();
        }

        private void GuardarDatosUsuarioAuxiliar()
        {
            for (int i = 0; i < FL_FuncionesUsuarioAdmin.Controls.Count; i++)
            {
                List<Funcion> funciones = miCine.MostrarFunciones();
                int.TryParse(FL_FuncionesUsuarioAdmin.Controls[i].ToString().Split(".")[0], out int IDFuncion);

                Funcion func = funciones.FirstOrDefault(f => f.ID == IDFuncion);
                if (func != null)
                {
                    UsuarioAuxiliar.MisFunciones.Add(func);
                    miCine.agregarUsuarioFuncion(UsuarioAuxiliar.ID, func.ID);
                    //miCine.ComprarEntradaFuncionNotNull(UsuarioAuxiliar.ID,cam)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void FL_FuncionesDisponiblesAdmin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
