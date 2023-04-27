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
            CreateLabels();
        }

        private void CreateLabels()
        {
            List<Funcion> funciones = this.usuarioAuxiliar.ObtenerMisFunciones();
          for (int i = 0; i< funciones.Count; i++)
                {
                    Label actual = new Label();
                    actual.AutoSize = true;
                    actual.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
                int y = (i+1) * 30;
                    actual.Location = new Point(12,y);
                    actual.Name = "funcion-" + funciones[i].ID;
                    actual.Size = new Size(129, 28);
                    actual.TabIndex = i;
                    actual.Text = "Pelicula: " + funciones[i].MiPelicula.Nombre;

                this.Controls.Add(actual);
                }
        }
    }
}
