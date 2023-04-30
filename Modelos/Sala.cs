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
        public List<Funcion> MisFunciones;

        public Sala(string Ubicacion, int Capacidad)
        {
            ultimoID++;
            this.ID = ultimoID;
            this.Ubicacion = Ubicacion;
            this.Capacidad = Capacidad;
            MisFunciones = new List<Funcion>();
        }

        public Sala(string Ubicacion, int Capacidad, int ID)
        {
       
            this.ID = ID;
            this.Ubicacion = Ubicacion;
            this.Capacidad = Capacidad;
            MisFunciones = new List<Funcion>();
        }

        public bool AgregarFuncion(Funcion funcion)
        {
            try
            {
                MisFunciones.Add(funcion);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool EliminarFuncion(int IDFuncion)
        {
            foreach (Funcion fun in MisFunciones)
            {
                if (fun.ID == IDFuncion)
                {
                    MisFunciones.Remove(fun);
                    return true;

                }
            }
            return false;
        }

        public bool ModificarFuncion(int IDFuncion, Funcion funcion)
        {
            for (int i = 0; i < MisFunciones.Count; i++)
            {
                if (MisFunciones[i].ID == IDFuncion)
                {
                    MisFunciones[i].MiSala = funcion.MiSala;
                    MisFunciones[i].MiPelicula = funcion.MiPelicula;
                    MisFunciones[i].Clientes = funcion.Clientes;
                    MisFunciones[i].Fecha = funcion.Fecha;
                    MisFunciones[i].CantidadClientes = funcion.CantidadClientes;
                    MisFunciones[i].Costo = funcion.Costo;

                    return true;
                }
            }
            return false;
        }

        public List<Funcion> ObtenerMisFunciones()
        {
            return MisFunciones.ToList();
        }

        private string ExtraerIDFunciones()
        {
            string IDFunciones = "";
            foreach (Funcion func in MisFunciones)
            {
                if (IDFunciones == "")
                {
                    IDFunciones += func.ID;
                }
                else
                {
                    IDFunciones += ", " + func.ID;
                }
            }

            return IDFunciones;
        }

        // obtenerUbicaciones
        public string[] SalaToString()
        {
            string FuncionesIDs = ExtraerIDFunciones(); ;
            return new string[] { ID.ToString(), Ubicacion.ToString(), Capacidad.ToString(), FuncionesIDs };
        }

    }
}
