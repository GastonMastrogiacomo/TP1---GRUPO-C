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
        public List<Reserva> MisReservas { get; set; }

        public Funcion(int ID, Sala MiSala, Pelicula MiPelicula, DateTime Fecha,
            int CantidadClientes, Double Costo)
        {
            this.ID = ID;
            this.MiSala = MiSala;
            this.MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            this.Fecha = Fecha;
            this.CantidadClientes = CantidadClientes;
            this.Costo = Costo;
            MisReservas = new List<Reserva>();


        }
        public List<Funcion> ObtenerFunciones()
        {
            //Ver si esto esta bien o no

            return MisFunciones.ToList();
        }




    }
}
