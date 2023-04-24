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
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<Funcion> MisFunciones { get; set; }
        public double Credito { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsAdmin { get; set; }
        public List<Reserva> MisReservas { get; set; }

        // Entrada

        public Usuario(int ID, int DNI, string Nombre, string Apellido,
            string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin)
        {
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
            MisReservas = new List<Reserva>();
        }

        //ABM Reserva
        public bool AgregarReserva(Reserva reserva)
        {
            try
            {
                MisReservas.Add(reserva);
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