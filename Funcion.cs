using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C
{
    internal class Funcion
    {


        public int ID { get; set; }
        public Sala MiSala { get; set; }
        public Pelicula MiPelicula { get; set; }
        public List<Usuario> Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadClientes { get; set; }
        public Double Costo { get; set; }

        public Funcion(int ID, Sala MiSala, Pelicula MiPelicula, DateTime Fecha,
            int CantidadClientes, Double Costo)
        {
            ID = ID;
            MiSala = MiSala;
            MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            Fecha = Fecha;
            CantidadClientes = CantidadClientes;
            Costo = Costo;


        }
        public List<Funcion> ObtenerFunciones()
        {
            //Ver si esto esta bien o no

            return MisFunciones.ToList();
        }




    }
}
