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
    public partial class PantallaEdicionFunciones : Form
    {
        private Cine miCine;
        private Usuario usuarioAuxiliar;
        
        public PantallaEdicionFunciones(Cine cine, Usuario usuarioAuxiliar) 
        {
            InitializeComponent();
            miCine = cine; 
            this.usuarioAuxiliar = usuarioAuxiliar;
            createLabels();
        }

        private void createLabels()
        {
            List<Funcion> funciones = this.usuarioAuxiliar.ObtenerMisFunciones();
          for (int i = 1; i<= funciones.Count; i++)
                {
                    Label actual = new Label();
                    actual.AutoSize = true;
                    actual.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
                    actual.Location = new Point(12, 30*i);
                    actual.Name = "funcion-" + funciones[i-1].ID;
                    actual.Size = new Size(129, 28);
                    actual.TabIndex = 28;
                    actual.Text = "Pelicula: " + funciones[i-1].MiPelicula.Nombre;
                }
        }
    }
}
