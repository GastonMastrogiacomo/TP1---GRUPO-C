using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Modelos
{
    public class UsuarioFuncion
    {
        public int idUsuario { get; set; }
        public int idFuncion { get; set; }
        public int CantidadEntradasCompradas { get; set; }

        public UsuarioFuncion(int idUsuario, int idFuncion, int cantidadEntradas)
        {
            this.idUsuario = idUsuario;
            this.idFuncion = idFuncion;
            this.CantidadEntradasCompradas = cantidadEntradas;
        }
    }
}
