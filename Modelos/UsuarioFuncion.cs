using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Modelos
{
    public class UsuarioFuncion
    {
        // ESTA ES LA CLASE QUE FUNCIONA COMO TABLA INTERMEDIA EN LA RELACION MANY TO MANY DE FUNCION-USUARIO

        public int idUsuario { get; set; }
        public int idFuncion { get; set; }

        //Cantidad de entradas tendria que ir aca
        public int cantidadEntradas { get; set; }

        public UsuarioFuncion(int idUsuario, int idFuncion, int cantidadEntradas)
        {
            this.idUsuario = idUsuario;
            this.idFuncion = idFuncion;
            this.cantidadEntradas = cantidadEntradas;
        }
    }
}
