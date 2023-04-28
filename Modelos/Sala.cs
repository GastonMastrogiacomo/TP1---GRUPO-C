using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Sala
    {

        public int ID { get; set; }
        public static int ultimoID = 0;
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public List<Funcion> MisFunciones { get; set; }

        public Sala(string Ubicacion, int Capacidad)
        {
            ultimoID++;
            this.ID = ultimoID;
            this.Ubicacion = Ubicacion;
            this.Capacidad = Capacidad;
            MisFunciones = new List<Funcion>();
        }

        // obtenerUbicaciones


    }
}
