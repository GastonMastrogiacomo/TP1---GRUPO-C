using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C
{
    internal class Usuario
    {
        public int ID { get; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<Funcion> MisFunciones { get; set; }
        public Double Credito { get; set; }
        public DateTime FechaNacimeinto { get; set; }
        public bool EsAdmin { get; set; }
        //public List<int> CantidadEntradas { get; set; } 

        // Entrada
    
        public Usuario(int ID, int DNI, string Nombre, String Apellido,
            String Mail, String Password, DateTime FechaNacimiento, bool EsAdmin)
        {
            ID = ID;
            DNI = DNI;
            Nombre = Nombre;
            Apellido = Apellido;
            Mail = Mail;
            Password = Password;
            IntentosFallidos = 0;
            Bloqueado = false;
            MisFunciones = new List<Funcion>();
            Credito = 0;
            FechaNacimiento = FechaNacimiento;
            EsAdmin = EsAdmin;
          }
    }
}
