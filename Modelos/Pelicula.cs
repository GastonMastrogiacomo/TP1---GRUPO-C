﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Pelicula
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public int Duracion { get; set; }
        public List<Funcion> MisFunciones { get; set; }

        public Pelicula(int ID, string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, List<Funcion> MisFunciones)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Sinopsis = Sinopsis;
            this.Poster = Poster;
            this.Duracion = Duracion;
            this.MisFunciones = MisFunciones;
        }





    }
}