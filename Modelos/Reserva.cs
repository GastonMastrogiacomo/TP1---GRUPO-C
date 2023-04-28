using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Reserva
    {
        public int ID { get; set; }

        public static int ultimoID = 0;
        public int CantidadEntradas { get; set; }
        public int IDUsuario { get; set; }
        public int IDFuncion { get; set; }

        public Reserva (int CantidadEntradas, int IDUsuario, int IDFuncion)
        {
            ultimoID++;
            this.ID = ultimoID;
            this.CantidadEntradas = CantidadEntradas;
            this.IDUsuario = IDUsuario;
            this.IDFuncion = IDFuncion;
        }
    }
}
