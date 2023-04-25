using TP1___GRUPO_C.Model;

namespace TP1___GRUPO_C
{
    public partial class Form1 : Form
    {
        private Cine cine;
        private Form2 pantallaPrincipal;
        private Form4 hijoLogin;

        public Form1()
        {
            InitializeComponent();

            cine = new Cine();
            pantallaPrincipal = new Form2(cine);
            pantallaPrincipal.MdiParent = this;
            pantallaPrincipal.iniciarVentanaLogin += IniciarLogin;
            pantallaPrincipal.Show();
        
        }

        private void IniciarLogin()
        {

            pantallaPrincipal.Hide();

            hijoLogin = new Form4(cine);
            hijoLogin.MdiParent = this;
            hijoLogin.volverLoggeado += Loggear;
            hijoLogin.Show();

        }

        private void Loggear()
        {

            hijoLogin.Close();
            pantallaPrincipal.Show();
        }


    }
}