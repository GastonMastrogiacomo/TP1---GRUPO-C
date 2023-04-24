using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    internal class Sala
    {

        public int ID { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public Sala(int ID, string Ubicacion, int Capacidad)
        {
            ID = ID;
            Ubicacion = Ubicacion;
            Capacidad = Capacidad;
        }

        // obtenerUbicaciones


    }
}
