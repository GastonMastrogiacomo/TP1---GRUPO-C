using TP1___GRUPO_C.Model;
using TP1___GRUPO_C.Vistas;

namespace TP1___GRUPO_C
{
    public partial class Form1 : Form
    {
        private Cine cine;
        private Form2 pantallaPrincipal;
        private Form4 hijoLogin;
        private Form6 pantallaAdmin;
        private Form3 pantallaRegistro;

        public Form1()
        {
            InitializeComponent();

            cine = new Cine();
            pantallaPrincipal = new Form2(cine);
            pantallaPrincipal.MdiParent = this;
            pantallaPrincipal.iniciarVentanaLogin += IniciarLogin;
            pantallaPrincipal.abrirRegistro += AbrirRegistro;
           
            pantallaPrincipal.Show();
        
        }

        private void IniciarLogin()
        {

            pantallaPrincipal.Hide();

            hijoLogin = new Form4(cine);
            hijoLogin.MdiParent = this;
            hijoLogin.usuarioComunLogueado += UsuarioComunLogueado;
            hijoLogin.abrirLoginAdmin += AbrirLoginAdmin;
            hijoLogin.Show();

        }

        private void UsuarioComunLogueado()
        {

            hijoLogin.Close();
            pantallaPrincipal.Show();
        }

        private void AbrirLoginAdmin()
        {
            hijoLogin.Close();
            pantallaAdmin = new Form6(cine);
            pantallaAdmin.MdiParent = this;

            pantallaAdmin.Show();
            

        }

        private void AbrirRegistro()
        {
            
            pantallaRegistro = new Form3(cine);
            pantallaRegistro.MdiParent = this;
            pantallaRegistro.pantallaPrincipal += volverPantallaPrincipal;
            pantallaPrincipal.Hide();
            pantallaRegistro.Show();

        }

        private void volverPantallaPrincipal()
        {
            pantallaRegistro.Close();
            pantallaPrincipal.Show();      
        }

    }
}