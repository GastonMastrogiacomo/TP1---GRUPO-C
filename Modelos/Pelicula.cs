using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Pelicula
    {
        public int ID { get; set; }
        public static int ultimoID = 0;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public int Duracion { get; set; }
        public List<Funcion> MisFunciones { get; set; }

        public Pelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {
            ultimoID++;
            this.ID = ultimoID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Sinopsis = Sinopsis;
            this.Poster = Poster;
            this.Duracion = Duracion;
            this.MisFunciones = new List<Funcion>();
        }

        public Pelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, int ID)

        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Sinopsis = Sinopsis;
            this.Poster = Poster;
            this.Duracion = Duracion;
            this.MisFunciones = new List<Funcion>();
        }

        //ABM Funcion

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

        public string[] PeliculaToString()
        {
            string FuncionesIDs = ExtraerIDFunciones();
            return new string[] { ID.ToString(), Nombre.ToString(), Descripcion.ToString(), Sinopsis.ToString(), Poster.ToString(), Duracion.ToString(), FuncionesIDs };
        }
    }
}
