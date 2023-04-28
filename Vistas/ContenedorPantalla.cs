using TP1___GRUPO_C.Model;
using TP1___GRUPO_C.Vistas;

namespace TP1___GRUPO_C
{
    public partial class ContenedorPantalla : Form
    {
        private Cine cine;
        private PantallaPrincipal pantallaPrincipal;
        private PantallaLogin pantallaLogin;
        private PantallaABMAdmin pantallaABMAdmin;
        private PantallaRegistro pantallaRegistro;
        private PantallaCargaFunciones pantallaCargaFunciones;
        private PantallaEdicionFunciones pantallaEdicionFunciones;
        private PantallaMiPerfil PantallaMIPerfil;

        public ContenedorPantalla()
        {
            InitializeComponent();

            cine = new Cine();
            pantallaPrincipal = new PantallaPrincipal(cine);
            pantallaPrincipal.MdiParent = this;
            pantallaPrincipal.iniciarVentanaLogin += IniciarLogin;
            pantallaPrincipal.abrirRegistro += AbrirRegistro;
           
            pantallaPrincipal.Show();
        
        }

        private void IniciarLogin()
        {

            pantallaPrincipal.Hide();

            pantallaLogin = new PantallaLogin(cine);
            pantallaLogin.MdiParent = this;
            pantallaLogin.pantallaPrincipal += volverPantallaPrincipal;
            pantallaLogin.usuarioComunLogueado += UsuarioComunLogueado;
            pantallaLogin.usuarioAdminLogueado += UsuarioAdminLogueado;
            pantallaLogin.Show();
            

        }

        private void UsuarioComunLogueado()
        {

            pantallaLogin.Close();
            pantallaPrincipal.Show();
        }

        private void UsuarioAdminLogueado()
        {
            pantallaLogin.Close();
            pantallaABMAdmin = new PantallaABMAdmin(cine);
            pantallaABMAdmin.MdiParent = this;
            pantallaABMAdmin.abrirPantallaCargaFunciones += AbrirPantallaCargaFunciones;
            pantallaABMAdmin.pantallaPrincipal += volverPantallaPrincipal;
            pantallaABMAdmin.Show();
            

        }

        private void AbrirRegistro()
        {
            
            pantallaRegistro = new PantallaRegistro(cine);
            pantallaRegistro.MdiParent = this;
            pantallaRegistro.pantallaPrincipal += volverPantallaPrincipal;
            pantallaPrincipal.Hide();
            pantallaRegistro.Show();

        }

        private void volverPantallaPrincipal()
        {   if (pantallaABMAdmin != null) 
            {
                pantallaABMAdmin.Close();
            }
            if (pantallaRegistro !=null)
            {
                pantallaRegistro.Close();
            }
            if (pantallaLogin != null)
            { 
            pantallaLogin.Close();
            }
            pantallaPrincipal.Refresh();
            pantallaPrincipal.Show();      
        }

        private void AbrirPantallaCargaFunciones(Usuario UsuarioAuxiliar)
        {
            pantallaABMAdmin.Hide();
            pantallaCargaFunciones = new PantallaCargaFunciones(cine, UsuarioAuxiliar);
            pantallaCargaFunciones.MdiParent = this;
            pantallaCargaFunciones.cerrarPantallaCargaFunciones += CerrarPantallaCargaFunciones;
            pantallaCargaFunciones.cerrarYGuardarPantallaCargaFunciones += CerrarYGuardarPantallaCargaFunciones;
            pantallaCargaFunciones.abrirPantallaEdicionFunciones += AbrirPantallaEdicionFunciones;
            pantallaCargaFunciones.Show();
        }

        private void AbrirPantallaEdicionFunciones(Usuario UsuarioAuxiliar)
        {
            pantallaCargaFunciones.Hide();
            pantallaEdicionFunciones = new PantallaEdicionFunciones(cine, UsuarioAuxiliar);
            pantallaEdicionFunciones.MdiParent = this;
            pantallaEdicionFunciones.cerrarYGuardarPantallaEdicionFunciones += CerrarPantallaEdicionFunciones;
            pantallaEdicionFunciones.Show();
        }

        private void CerrarPantallaEdicionFunciones()
        {
            pantallaEdicionFunciones.Close();
            pantallaCargaFunciones.Show();
        }

        private void CerrarPantallaCargaFunciones()
        {
            pantallaABMAdmin.Show();
            pantallaCargaFunciones.Close();
            
        }

        private void CerrarYGuardarPantallaCargaFunciones()
        {
            pantallaABMAdmin.Show();
            pantallaCargaFunciones.Close();

        }
        private void AbrirMiPerfil()
        {
            pantallaPrincipal.Hide();
            PantallaMIPerfil = new PantallaMiPerfil(cine);
            PantallaMIPerfil.MdiParent = this;

            //PantallaMiPerfil.pantallaPrincipal += volverPantallaPrincipal;
            PantallaMIPerfil.Show();
            

        }

    }
}