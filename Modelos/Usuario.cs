using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Usuario
    {
        public int ID { get; }

        // Esto tendriamos que eliminarlo, una vez implementado DB el id es autoincremental y no lo tenemos que insertar nosotros
        //public static int ultimoID = 0;
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        // Esto podriamos cambiarlo para que no sea una propiedad del usuario y lo ponemos en Cine
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }

        public List<Funcion> MisFunciones { get; set; }
        public double Credito { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsAdmin { get; set; }

        // Esto tiene que ser reemplazado por una tabla de muchos a muchos entre usuarios y Funciones
        public Dictionary<int, int> EntradasCompradas { get; set; }

        // este es el orignal de base de datos
        public Usuario(int ID, int DNI, string Nombre, string Apellido,string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin)
        {
            //ultimoID++;
            this.ID = ID;
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Mail = Mail;
            this.Password = Password;
            IntentosFallidos = 0;
            Bloqueado = false;
            MisFunciones = new List<Funcion>();
            Credito = 0;
            this.FechaNacimiento = FechaNacimiento;
            this.EsAdmin = EsAdmin;

            // Esto tiene que ser reemplazado por una tabla de muchos a muchos entre usuarios y Funciones
            EntradasCompradas = new Dictionary<int, int>();
        }              

        public List<Funcion> ObtenerMisFunciones()
        {
            return MisFunciones.ToList();
        }

        public List<Funcion> MostrarFuncionesProximas()
        {

            List<Funcion> proximasFunciones = new List<Funcion>();

            DateTime fechaActual = DateTime.Now;


            foreach (Funcion funcion in MisFunciones)
            {

                if (funcion.Fecha > fechaActual)
                {
                    proximasFunciones.Add(funcion);
                }
            }

            return proximasFunciones;

        }

        public List<Funcion> MostrarFuncionesPasadas()
        {

            List<Funcion> pasadasFunciones = new List<Funcion>();

            DateTime fechaActual = DateTime.Now;


            foreach (Funcion funcion in MisFunciones)
            {

                if (funcion.Fecha < fechaActual)
                {
                    pasadasFunciones.Add(funcion);
                }
            }

            return pasadasFunciones;

        }




        public string[] ToString()
        {
            //string FuncionesIDs = ExtraerIDFunciones(); /*;*/
            return new string[] { ID.ToString(), DNI.ToString(), Nombre, Apellido, Mail, Password, IntentosFallidos.ToString(), Bloqueado.ToString(), Credito.ToString(), FechaNacimiento.ToString("dd/MM/yyyy"), EsAdmin.ToString() };
        }
    }
}

