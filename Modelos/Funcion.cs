using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Funcion
    {
        public int ID { get; set; }
        public Sala MiSala { get; set; }
        public Pelicula MiPelicula { get; set; }
        public int idSala { get; set; }
        public int idPelicula { get; set; }
        public List<Usuario> Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int AsientosDisponibles { get; set; }

        // Cantidad de entradas compradas, Asientos Disponibles depende de la capacidad - este valor
        public int CantidadClientes { get; set; }
        public double Costo { get; set; }

        public Funcion(int ID, DateTime fecha, double costo, int idSala, int idPelicula, int AsientosDisponibles)
        {
            this.ID = ID;
            this.idSala = idSala;
            this.idPelicula = idPelicula;
            Fecha = fecha;
            this.CantidadClientes = 0;
            Costo = costo;
            Clientes = new List<Usuario>();
            this.AsientosDisponibles = AsientosDisponibles;
        }

        #region Constructores no usados
        /*
        public Funcion(Sala MiSala, Pelicula MiPelicula, DateTime Fecha, double Costo)
        {
            this.MiSala = MiSala;
            this.MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            this.Fecha = Fecha;
            this.CantidadClientes = 0;
            this.Costo = Costo;
            this.AsientosDisponibles = MiSala.Capacidad;

        }
        public Funcion(Sala MiSala, Pelicula MiPelicula, DateTime Fecha, double Costo, int ID)
        {
            this.ID = ID;
            this.MiSala = MiSala;
            this.MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            this.Fecha = Fecha;
            this.CantidadClientes = 0;
            this.Costo = Costo;
            this.AsientosDisponibles = MiSala.Capacidad;

        }
        */
        #endregion

        public string[] ToString()
        {
            return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), AsientosDisponibles.ToString(), Costo.ToString(), idSala.ToString(), idPelicula.ToString() };

            #region To Strings no utilizados 
            /*
            if (MiSala != null && MiPelicula != null)
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), AsientosDisponibles.ToString(), Costo.ToString(), MiSala.ID.ToString(), MiPelicula.ID.ToString(), MiPelicula.Nombre.ToString() };

            }
            else if (MiSala == null && MiPelicula != null)
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), AsientosDisponibles.ToString(), Costo.ToString(), "", "", MiPelicula.ID.ToString(), MiPelicula.Nombre.ToString() };
            }
            else if (MiSala != null && MiPelicula == null)
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), AsientosDisponibles.ToString(), Costo.ToString(), MiSala.ID.ToString(), MiSala.Capacidad.ToString(), "", "", AsientosDisponibles.ToString() };
            }
            else
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), AsientosDisponibles.ToString(), Costo.ToString(), "", "", "", "", AsientosDisponibles.ToString() };

            }
            */
            #endregion

        }


    }

}

