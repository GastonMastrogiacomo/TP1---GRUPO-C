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

            //andy: Agrego objetos prueba 

            DateTime fecha = new DateTime(1986, 05, 12);
            Usuario comun = new Usuario(99999999, "Pepe", "Perez", "pepe@mail.com", "123", fecha, false);
            comun.Credito = 1000;
            Usuarios.Add(comun);
            Usuario admin = new Usuario(99999998, "El", "Admin", "admin@mail.com", "123", fecha, true);
            Usuarios.Add(admin);

            Sala sala1 = new Sala("Olivos", 100);
            Salas.Add(sala1);
            Sala sala2 = new Sala("San Isidro", 200);
            Salas.Add(sala2);

            Pelicula toyStory = new Pelicula("Toy Story", "Pelicula de juguetes.", "Juguetes", "", 120);
            Peliculas.Add(toyStory);
            Pelicula marioBros = new Pelicula("Mario Bros.", "It's me Mario!", "Nintendo", "", 100);
            Peliculas.Add(marioBros);

            Funcion funcion1 = new Funcion(sala1, toyStory, new DateTime(), 0, 10);
            Funciones.Add(funcion1);
            Funcion funcion2 = new Funcion(sala1, marioBros, new DateTime(), 0, 15);
            Funciones.Add(funcion2);
            Funcion funcion3 = new Funcion(sala2, marioBros, new DateTime(), 0, 15);
            Funciones.Add(funcion3);

        }

        //ABM Usuario

        public bool AgregarUsuario(Usuario user)
        {
            bool flagDni = false;
        if((user.DNI !=null && user.Nombre != null&& user.Apellido != null&& user.Mail != null&& user.Password != null&& user.FechaNacimiento != null&& user.EsAdmin != null)) { 
            foreach (Usuario u in Usuarios)
            {
                if (user.DNI == u.DNI || user.Mail == u.Mail)
                {
                    flagDni = true;
                }
            }

            if (!flagDni)
            {
                Usuario otro = new Usuario(user.DNI, user.Nombre, user.Apellido, user.Mail, user.Password, user.FechaNacimiento, user.EsAdmin);
                Usuarios.Add(otro);
                MessageBox.Show("Usuario Registrado con exito! Revise su email para validar cuenta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
            MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Complete todos los campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        public bool ModificarUsuario(int idUsuario, Usuario user)
        {
            if ((user.DNI != null && user.Nombre != null && user.Apellido != null && user.Mail != null && user.Password != null && user.FechaNacimiento != null && user.EsAdmin != null))
            {
                for (int i = 0; i < Usuarios.Count; i++)
                {
                    if (Usuarios[i].ID == idUsuario)
                    {

                        Usuarios[i] = user;
                        MessageBox.Show("Usuario Registrado con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                return false;
                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Complete todos los campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.ID == idUsuario)
                {
                    Usuarios.Remove(u);
                    MessageBox.Show("El usuario fue eliminado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
            MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ABM Funcion
        public bool AgregarFuncion(Funcion funcion)
        {
            try
            {
                Funcion NuevaFuncion = new Funcion(funcion.MiSala, funcion.MiPelicula, funcion.Fecha, funcion.CantidadClientes, funcion.Costo);
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
                Sala nuevaSala = new Sala(sala.Ubicacion, sala.Capacidad);
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
                Pelicula NuevaPelicula = new Pelicula(pelicula.Nombre, pelicula.Descripcion, pelicula.Sinopsis, pelicula.Poster, pelicula.Duracion);
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
                                UsuarioActual.MisFunciones.Add(fun);
                                fun.CantidadClientes += CantidadEntradas;
                                fun.AgregarCliente(UsuarioActual);
                                return true;

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
                MessageBox.Show(e.Message);
                return false;
            }



        }


        public bool DevolverEntrada(int IDFuncion, int CantidadEntradas)
        {

            List<Funcion> funciones = MostrarFunciones();
            Funcion funcion = funciones.FirstOrDefault(u => u.ID == IDFuncion);

            if (funcion != null)
            {
                foreach (Funcion fun in funciones)
                {
                    if (fun.ID == IDFuncion)

                    {
                        if (fun.Fecha > DateTime.Now)
                        {

                            UsuarioActual.MisFunciones.Remove(fun);
                            fun.CantidadClientes -= CantidadEntradas;
                            fun.EliminarCliente(UsuarioActual.ID);
                            return true;



                        }
                        else if (fun.Fecha < DateTime.Now)
                        {
                            Console.WriteLine("No es posible devolver entrada de una fecha que ya ocurrio.");
                            return false;
                        }
                    }

                }


            }

            return false;

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

                                if (user.EsAdmin == esAdmin)
                                {
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
                MessageBox.Show(e.Message);
            }
            return false;

        }

        public void CerrarSesion()
        {
            UsuarioActual = null;

        }

        public List<Usuario> MostrarUsuarios()
        {
            return Usuarios.ToList();
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

        public Usuario ObtenerUsuarioPorId(int ID)
        {
            foreach (Usuario user in Usuarios)
            {

                if (user.ID == ID)
                {
                    return user;
                }
            }

            throw new InvalidDataException("El ID no se encontró en la base de datos.");
        }

        public Sala ObtenerSalaPorId(int ID)
        {
            foreach (Sala sal in Salas)
            {

                if (sal.ID == ID)
                {
                    return sal;
                }
            }

            throw new InvalidDataException("El ID no se encontró en la base de datos.");
        }

        public Funcion ObtenerFuncionPorId(int ID)
        {
            foreach (Funcion func in Funciones)
            {
                if (func.ID == ID)
                {
                    return func;
                }
            }

            throw new InvalidDataException("El ID no se encontró en la base de datos.");

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
                        funcionEncontradas.Add(new Funcion(funcion.MiSala, funcion.MiPelicula, funcion.Fecha, funcion.CantidadClientes, funcion.Costo));
                    }
                    else
                    {
                        Console.WriteLine("No se encuentra Funcion con los datos ingresados");
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
