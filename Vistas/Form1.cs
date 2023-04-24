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
            hijoLogin.TransfEvento += TransfDelegado;
            pantallaPrincipal.Show();   
        }


        private void TransfDelegado()
        {
            MessageBox.Show("asd");
        }


        

    }
}