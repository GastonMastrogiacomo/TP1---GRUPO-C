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
using static TP1___GRUPO_C.Vistas.PantallaCargaFunciones;

namespace TP1___GRUPO_C.Vistas
{
    public partial class PantallaEdicionFunciones : Form
    {
        private Cine miCine;
        private Usuario usuarioAuxiliar;
        public CerrarYGuardarPantallaEdicionFunciones cerrarYGuardarPantallaEdicionFunciones;

        public PantallaEdicionFunciones(Cine cine, Usuario usuarioAuxiliar)
        {
            InitializeComponent();
            miCine = cine;
            this.usuarioAuxiliar = usuarioAuxiliar;
            this.Label_Credito.Text = this.usuarioAuxiliar.Credito.ToString();
            CreateComponents();
        }

        public delegate void CerrarYGuardarPantallaEdicionFunciones();

        private void CreateComponents()
        {
            List<Funcion> funciones = this.usuarioAuxiliar.ObtenerMisFunciones();
            for (int i = 0; i < funciones.Count; i++)
            {

                int Y_Label = (i + 1) * 40;

                Label labelActual = new Label();
                labelActual.AutoSize = true;
                labelActual.Font = new Font("Segoe UI", 11, FontStyle.Regular, GraphicsUnit.Point);
                labelActual.Location = new Point(20, Y_Label);
                labelActual.Name = "funcionLabel-" + funciones[i].ID;
                labelActual.TabIndex = 100 + i;
                labelActual.Text = funciones[i].MiPelicula.Nombre + " el " + funciones[i].Fecha + ". Costo: " + funciones[i].Costo;

                Label textBoxLabel = new Label();
                textBoxLabel.AutoSize = true;
                textBoxLabel.Font = new Font("Segoe UI", 11, FontStyle.Regular, GraphicsUnit.Point);
                textBoxLabel.Location = new Point(420, Y_Label);
                textBoxLabel.Name = "funcionLabel-" + funciones[i].ID;
                textBoxLabel.TabIndex = 200 + i;
                textBoxLabel.Text = "Cant. Entradas: ";

                NumericUpDown numericUpdownActual = new NumericUpDown();
                numericUpdownActual.Maximum = 1000;
                numericUpdownActual.Minimum = 1;
                int Y_TextBox = (i + 1) * 40;
                numericUpdownActual.Location = new Point(530, Y_TextBox);
                numericUpdownActual.Name = "funcionNumUpDown-" + funciones[i].ID;
                numericUpdownActual.TabIndex = 300 + i;
                numericUpdownActual.DecimalPlaces = 0;

                this.Controls.Add(labelActual);
                this.Controls.Add(textBoxLabel);
                this.Controls.Add(numericUpdownActual);
            }
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {

            try
            {
                // ya tengo una copia de la base de datos
                List<Funcion> funciones = this.usuarioAuxiliar.ObtenerMisFunciones();

                bool flagAlcanza = false;
                double costoEntradas = 0.0;
                for (int i = 0; i < funciones.Count; i++)
                {
                    List<Funcion> funcionesCine = miCine.MostrarFunciones();
                    Funcion func = funcionesCine.FirstOrDefault(f => f.ID == funciones[i].ID);

                    if (func != null)
                    {
                        NumericUpDown CantEntradas = this.Controls.Find("funcionNumUpDown-" + funciones[i].ID, true).FirstOrDefault() as NumericUpDown;
                        if (CantEntradas != null)
                        {
                            this.Label_Credito.Text = usuarioAuxiliar.Credito.ToString();
                            miCine.ComprarEntradaFuncionNotNull(usuarioAuxiliar, int.Parse(CantEntradas.Value.ToString()), func, func.ID);

                        }
                        else
                        {
                            throw new Exception("No se ingresaron cantidad de entradas para la funcion " + func.MiPelicula.Nombre);
                        }
                    }
                }

                cerrarYGuardarPantallaEdicionFunciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
