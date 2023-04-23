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
        //public List<Funcion> ObtenerFunciones()
        //{
            //Ver si esto esta bien o no

            //return MisFunciones.ToList();
       // }


        //ABM Reserva
        public bool AgregarReserva(Reserva reserva)
        {
            try
            {
                MisReservas.Add(reserva);
                CantidadClientes += reserva.CantidadEntradas;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool EliminarReserva(int IDReserva)
        {
            foreach (Reserva res in MisReservas)
            {
                if (res.ID == IDReserva)
                {
                    MisReservas.Remove(res);
                    CantidadClientes -= res.CantidadEntradas;
                    return true;

                }
            }
            return false;
        }


        public bool ModificarReserva(int IDReserva, Reserva reserva)
        {
            for (int i = 0; i < MisReservas.Count; i++)
            {
                if (MisReservas[i].ID == IDReserva)
                {
                    MisReservas[i] = reserva;
                    return true;
                }
            }
            return false;
        }
    }

}

