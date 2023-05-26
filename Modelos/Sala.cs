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
        //public static int ultimoID = 0;
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public List<Funcion> MisFunciones { get; set; }

        public Sala(int ID,string Ubicacion, int Capacidad)
        {
       
            this.ID = ID;
            this.Ubicacion = Ubicacion;
            this.Capacidad = Capacidad;
            MisFunciones = new List<Funcion>();
        }

        public List<Funcion> ObtenerMisFunciones()
        {
            return MisFunciones.ToList();
        }

     
        // obtenerUbicaciones
        public string[] SalaToString()
        {
         
            return new string[] { ID.ToString(), Ubicacion.ToString(), Capacidad.ToString() };
        }

    }
}
