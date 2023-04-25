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
    public partial class Form6 : Form
    {

        private Cine miCine;

        public Form6(Cine cine)
        {
            InitializeComponent();
             miCine = cine;
        }

      
    }
}
