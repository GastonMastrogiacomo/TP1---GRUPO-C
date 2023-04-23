namespace TP1___GRUPO_C
{
    public partial class Form1 : Form
    {
        internal Cine cine;
        internal Form2 pantallaPrincipal;
        public Form1()
        {
            InitializeComponent();
            cine = new Cine();
            pantallaPrincipal = new Form2(cine);
            pantallaPrincipal.MdiParent = this;
            //pantallaPrincipal.TransfEvento += TransfDelegado;
            pantallaPrincipal.Show();   
        }
    }
}