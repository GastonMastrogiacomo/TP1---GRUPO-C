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





    }
}
