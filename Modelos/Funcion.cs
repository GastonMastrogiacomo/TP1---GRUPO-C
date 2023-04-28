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

        public static int ultimoID = 0;
        
        public Sala MiSala { get; set; }
        public Pelicula MiPelicula { get; set; }
        public List<Usuario> Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadClientes { get; set; } //CantidadEntradasCompradas
        public double Costo { get; set; }

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
            


        }

        public Funcion(Sala MiSala, Pelicula MiPelicula, DateTime Fecha,
           int CantidadClientes, double Costo, int ID)
        {
            this.ID = ID;
            this.MiSala = MiSala;
            this.MiPelicula = MiPelicula;
            Clientes = new List<Usuario>();
            this.Fecha = Fecha;
            this.CantidadClientes = CantidadClientes;
            this.Costo = Costo;



        }

        // ABM Clientes

        public bool AgregarCliente(Usuario usuario)
        {

            //faltaria corroborar que el cliente no exista ya o quizas no dado que un cliente puede comprar mas entradas
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

        private string ExtraerIdClientes()
        {
            string IDClientes = "";
            foreach (Usuario cli in Clientes)
            {
                if (IDClientes == "")
                {
                    IDClientes += cli.ID;
                }
                else
                {
                    IDClientes += ", " + cli.ID;
                }
            }

            return IDClientes;
        }

        public string[] ToString()
        {
            string IdClientes = ExtraerIdClientes();
            if(MiSala != null)
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), CantidadClientes.ToString(), Costo.ToString(), MiSala.ID.ToString(), MiSala.Capacidad.ToString(), MiPelicula.ID.ToString(), MiPelicula.Nombre.ToString(), IdClientes };

            }
            else
            {
                return new string[] { ID.ToString(), Fecha.ToString("dd/MM/yyyy"), CantidadClientes.ToString(), Costo.ToString(), "", "", MiPelicula.ID.ToString(), MiPelicula.Nombre.ToString(), IdClientes };

            }
        }


    }

}

