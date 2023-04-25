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
            pantallaPrincipal.TransfVen += TransfDelegado;
            //pantallaPrincipal.TransfVen = TransferenciaVentana;
            pantallaPrincipal.Show();


            /**
             * hijoLogin.logued = false;
             * andy: el show deberia mostrar la clase que yo quiero mosrtar
             * hay que agregar un onClick para que se active el TransfDelegado() Este metodo
             * cerraria el Form actualmente activo y activaria el nuevo
             * osea form2 tiene que tener un metodo que se llame Transfdelegado() . 
             * Ese metodo en form2 llama al metodo de transfDelegado() de form 1 y ahí se hace el cambio
            */

        }


        private void TransfDelegado()
        {

            pantallaPrincipal.Close();


            hijoLogin = new Form4(cine);
            hijoLogin.MdiParent = this;
            //hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.Show();

            //MessageBox.Show("Log in correcto", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //pantallaPrincipal.Close();

            //Ahora sí creo la pantalla principal Form3
            /*
            hijoLogin = new Form4(cine);
            hijoLogin.MdiParent = this;
            hijoLogin.Show();
            */

            //pantallaPrincipal = new Form2(cine);
            //pantallaPrincipal.MdiParent = this;
            //pantallaPrincipal.Show();
        }

        private void TransferenciaVentana()
        {
            pantallaPrincipal.Close();
            hijoLogin = new Form4(cine);
            hijoLogin.MdiParent = this;
            hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.Show();
        }




    }
}