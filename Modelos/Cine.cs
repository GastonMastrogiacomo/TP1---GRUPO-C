using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1___GRUPO_C.Model
{
    public class Cine
    {
        public List<Usuario> Usuarios;
        public List<Funcion> Funciones;
        public List<Sala> Salas;
        public List<Pelicula> Peliculas;
        public Usuario UsuarioActual;

        public Cine()
        {
            Usuarios = new List<Usuario>();
            Funciones = new List<Funcion>();
            Salas = new List<Sala>();
            Peliculas = new List<Pelicula>();

            //andy: Agrego usuarios de prueba 

            Usuario comun = new Usuario(99999999, "Pepe", "Perez", "pepe@mail.com", "123", new DateTime(), false);
            Usuarios.Add(comun);

            Usuario admin = new Usuario(99999998, "El", "Admin", "admin@mail.com", "123", new DateTime(), true);
            Usuarios.Add(admin);
        
        }

        //ABM Usuario
        public bool AgregarUsuario(Usuario user)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.ID != user.ID)
                {
                    Usuario otro = new Usuario(user.DNI, user.Nombre, user.Apellido, user.Mail, user.Password, user.FechaNacimiento, user.EsAdmin);
                    Usuarios.Add(otro);
                    return true;
                }

            }
            return false;

        }

        public bool ModificarUsuario(int idUsuario, Usuario user)
        {
            for (int i = 0; i < Usuarios.Count; i++)
            {
                if (idUsuario == user.ID)
                {
                    Usuarios[i] = user;
                    return true;
                }
            }
            return false;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.ID == idUsuario)
                {
                    Usuarios.Remove(u);
                    return true;
                }
            }
            return false;
        }

        // ABM Funcion
        public bool AgregarFuncion(Funcion funcion)
        {
            try
            {
                Funcion NuevaFuncion = new Funcion(funcion.ID, funcion.MiSala, funcion.MiPelicula, funcion.Fecha, funcion.CantidadClientes, funcion.Costo);
                Funciones.Add(NuevaFuncion);
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
            foreach (Funcion fun in Funciones)
            {
                if (fun.ID == IDFuncion)
                {
                    Funciones.Remove(fun);
                    return true;

                }
            }
            return false;
        }

        public bool ModificarFuncion(int IDFuncion, Funcion funcion)
        {
            for (int i = 0; i < Funciones.Count; i++)
            {
                if (Funciones[i].ID == IDFuncion)
                {
                    Funciones[i] = funcion;
                    return true;
                }
            }
            return false;
        }

        //ABM Sala 
        public void AgregarSala(Sala sala)
        {
            try
            {
                Sala nuevaSala = new Sala(sala.ID, sala.Ubicacion, sala.Capacidad);
                Salas.Add(nuevaSala);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
            }

        }

        public bool EliminarSala(int IDSala)
        {
            foreach (Sala sal in Salas)
            {

                if (sal.ID == IDSala)
                {
                    Salas.Remove(sal);
                    return true;
                }

            }
            return false;
        }

        public bool ModificarSala(int IDSala, Sala sala)
        {

            for (int i = 0; i < Salas.Count; i++)
            {

                if (Salas[i].ID == IDSala)
                {

                    Salas[i] = sala;
                    return true;
                }

            }

            return false;
        }

        // ABM Peliculas
        public bool AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                Pelicula NuevaPelicula = new Pelicula(pelicula.ID, pelicula.Nombre, pelicula.Descripcion, pelicula.Sinopsis, pelicula.Poster, pelicula.Duracion, pelicula.MisFunciones);
                Peliculas.Add(NuevaPelicula);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public bool EliminarPelicula(int IDPelicula)
        {
            foreach (Pelicula pel in Peliculas)
            {
                if (pel.ID == IDPelicula)
                {
                    Peliculas.Remove(pel);
                    return true;

                }
            }
            return false;
        }

        public bool ModificarPelicula(int IDPelicula, Pelicula pelicula)
        {
            for (int i = 0; i < Peliculas.Count; i++)
            {
                if (Peliculas[i].ID == IDPelicula)
                {
                    Peliculas[i] = pelicula;
                    return true;
                }
            }
            return false;
        }

        public bool CargarCredito(int idUsuario, double importe)
        {
            foreach (Usuario user in Usuarios)
            {
                if (user.ID == idUsuario)
                {
                    user.Credito = importe;
                    return true;
                }
            }
            return false;
        }

        public bool ComprarEntrada(int IDFuncion, int CantidadEntradas)
        {
            try
            {
                bool FuncionExiste = false;

                foreach (Funcion fun in Funciones)
                {
                    if (fun.ID == IDFuncion)

                    {
                        FuncionExiste = true;
                        if (UsuarioActual.Credito >= fun.Costo)
                        {
                            if (fun.MiSala.Capacidad <= CantidadEntradas)
                            {
                                //REVISAR HARDCODEO DE ID DE RESERVA
                                Reserva reserva = new Reserva(1, CantidadEntradas, UsuarioActual.ID, fun.ID);

                                UsuarioActual.AgregarReserva(reserva);
                                fun.AgregarReserva(reserva);

                            }
                            else
                            {
                                throw new InvalidOperationException("No hay la cantidad solicitada de asientos");
                            }


                        }
                        else
                        {
                            throw new InvalidOperationException("Créditos insuficientes");
                        }
                    }
                }

                if (!FuncionExiste) { throw new FileNotFoundException("No se econtró la función."); }



                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }



        }

        //TODO
        public void DevolverEntrada(int idUsuario, int cant)
        {

        }

        public bool IniciarSesion(string Mail, string Password, bool esAdmin)
        {
            try
            {
                foreach (Usuario user in Usuarios)
                {

                 if (user.Mail.Equals(Mail))
                    {
                        if (user.Bloqueado == false)
                        {
                            if (user.Password.Equals(Password))
                            {

                                if (user.EsAdmin == esAdmin) {
                                    UsuarioActual = user;
                                    user.IntentosFallidos = 0;
                                    return true;

                                }
                                else
                                {
                                    // el usuario seleccion "administrador" sin serlo
                                    // o el administrador no puso el checkbox
                                    throw new InvalidOperationException("Has seleccionado una opción incorrecta.");
                                }
                               
                            }
                            else if (user.IntentosFallidos < 3)
                            {
                                user.IntentosFallidos += 1;
                                throw new InvalidOperationException("Password incorrecta, intentalo nuevamente");

                            }
                            else
                            {
                                user.Bloqueado = true;
                                throw new InvalidOperationException("Ha alcanzado la cantidad de intentos. Usuario bloqueado");

                            }
                        }
                        else { throw new InvalidOperationException("No se puede acceder, el usuario se encuentra bloqueado"); }
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;

        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public List<Funcion> MostrarFunciones()
        {
            return Funciones.ToList();
        }

        public List<Sala> MostrarSalas()
        {
            return Salas.ToList();
        }

        public List<Pelicula> MostrarPeliculas() // en diagrama decia List<Post>
        {
            return Peliculas.ToList();
        }

        //TODO
        public List<Funcion> BuscarFuncion(string Ubicacion, DateTime Fecha, double Costo, string NombrePelicula)
        {

            List<Funcion> funcionEncontradas = new List<Funcion>();

            foreach (Funcion funcion in Funciones)
            {
                if (funcion.MiPelicula.Nombre == NombrePelicula)
                {

                    if (funcion.MiSala.Ubicacion == Ubicacion && funcion.Fecha.Date == Fecha.Date && funcion.Costo == Costo)
                    {
                        funcionEncontradas.Add(new Funcion(funcion.ID, funcion.MiSala, funcion.MiPelicula, funcion.Fecha, funcion.CantidadClientes, funcion.Costo));
                    }
                }
                else
                {
                    Console.WriteLine("No se encuentra Funcion con ese nombre");
                }

            }

            return funcionEncontradas;
        }


    }
}
