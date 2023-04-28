using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Funcion
    {


        public int ID { get; set; }

        public static int ultimoID = 0;
        public Sala MiSala { get; set; }
        public Pelicula MiPelicula { get; set; }
        public List<Usuario> Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadClientes { get; set; } //CantidadEntradasCompradas
        public double Costo { get; set; }
        public List<Reserva> MisReservas { get; set; }

        public Funcion(Sala MiSala, Pelicula MiPelicula, DateTime Fecha,
            int CantidadClientes, double Costo)
        {
            ultimoID++;
            this.ID = ultimoID;
            this.MiSala = MiSala;
            this.MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            this.Fecha = Fecha;
            this.CantidadClientes = CantidadClientes;
            this.Costo = Costo;
            MisReservas = new List<Reserva>();


        }
  

        // ABM Clientes

        public bool AgregarCliente(Usuario usuario)
        {

            //faltaria corroborar que el cliente no exista ya
            try
            {
                Clientes.Add(usuario);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;

            }
        }


        public bool EliminarCliente(int IDCliente)
        {
            foreach (Usuario cli in Clientes)
            {
                if (cli.ID == IDCliente)
                {
                    Clientes.Remove(cli);

                    return true;

                }
            }
            return false;
        }


        public bool ModificarCliente(int IDCliente, Usuario cliente)
        {
            for (int i = 0; i < Clientes.Count; i++)
            {
                if (Clientes[i].ID == IDCliente)
                {
                    Clientes[i] = cliente;
                    return true;
                }
            }
            return false;
        }

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

