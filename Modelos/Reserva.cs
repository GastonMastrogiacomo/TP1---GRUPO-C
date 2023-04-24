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
        public int CantidadEntradas { get; set; }
        public int IDUsuario { get; set; }
        public int IDFuncion { get; set; }

        public Reserva(int ID, int CantidadEntradas, int IDUsuario, int IDFuncion)
        {
            this.ID = ID;
            this.CantidadEntradas = CantidadEntradas;
            this.IDUsuario = IDUsuario;
            this.IDFuncion = IDFuncion;
        }
    }
}
