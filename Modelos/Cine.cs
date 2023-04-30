using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
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

            DateTime fecha = new DateTime(1986, 05, 12);
            DateTime fecha2 = new DateTime(2050, 05, 12);

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
            Pelicula mario2 = new Pelicula("Mario 2", "It's me Mario!", "Nintendo", "", 100);
            Peliculas.Add(mario2);

            Funcion funcion1 = new Funcion(sala1, toyStory, fecha, 0, 10);
            Funciones.Add(funcion1);
            toyStory.AgregarFuncion(funcion1);
            sala1.AgregarFuncion(funcion1);
            comun.AgregarFuncion(funcion1);
            funcion1.AgregarCliente(comun);
            funcion1.AsientosDisponibles -= 1;
            funcion1.CantidadClientes += 1;

            Funcion funcion2 = new Funcion(sala1, marioBros, fecha, 0, 15);
            Funciones.Add(funcion2);
            marioBros.AgregarFuncion(funcion2);
            sala1.AgregarFuncion(funcion2);
            comun.AgregarFuncion(funcion2);
            funcion2.AgregarCliente(comun);
            funcion2.AsientosDisponibles -= 1;
            funcion2.CantidadClientes += 1;


            Funcion funcion3 = new Funcion(sala2, marioBros, fecha, 0, 20);
            Funciones.Add(funcion3);
            marioBros.AgregarFuncion(funcion3);
            sala2.AgregarFuncion(funcion3);

            Funcion funcion4 = new Funcion(sala2, marioBros, fecha2, 0, 256);
            Funciones.Add(funcion4);
            marioBros.AgregarFuncion(funcion4);
            sala2.AgregarFuncion(funcion4);
            comun.AgregarFuncion(funcion4);
            funcion4.AgregarCliente(comun);
            funcion4.AsientosDisponibles -= 1;
            funcion4.CantidadClientes += 1;



            Funcion funcion5 = new Funcion(sala1, mario2, fecha2, 0, 1500);
            Funciones.Add(funcion5);
            mario2.AgregarFuncion(funcion5);
            sala1.AgregarFuncion(funcion5);

        }

        //ABM Usuario
        public bool AgregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, int credito)
        {
            bool flagDni = false;

            try
            {
                // Verificaciones correspondientes
                if (DNI != 0)
                {
                    if (Nombre != null && Nombre != "")
                    {
                        if (Apellido != null && Apellido != "")
                        {
                            if (Mail != null && Mail != "")
                            {
                                if (Password != null && Password != "")
                                {

                                    // Verifico si el DNI y correo ya estan registrados
                                    foreach (Usuario u in Usuarios)
                                    {
                                        if (DNI == u.DNI || Mail == u.Mail)
                                        {
                                            flagDni = true;
                                        }
                                    }

                                    // Si el DNI y el correo no están registrados, crear un nuevo usuario y agregarlo a la lista de usuarios
                                    if (!flagDni)
                                    {
                                        Usuario otro = new Usuario(DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin);
                                        otro.Credito = credito;
                                        Usuarios.Add(otro);
                                        MessageBox.Show("Usuario Registrado con exito! Revise su email para validar cuenta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return true;
                                    }


                                    MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    throw new InvalidOperationException("Password incorrecta")
    ;
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Mail Incorrecto");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Apellido Incorrecto");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Nombre Incorrecto");
                    }
                }
                else
                {
                    throw new InvalidOperationException("DNI Incorrecto");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Complete todos los campos" + e.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return false;
        }

        public bool ModificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito, List<Funcion> MisFunciones)
        {
            // Verificamos que los campos no sean nulos o vacios
            if (DNI != 0 && Nombre != null && Nombre != "" && Apellido != null && Apellido != "" && Mail != null && Mail != "" && Pass != null && Pass != "")
            {
                for (int i = 0; i < Usuarios.Count; i++)
                {
                    // Se busca el usuario con el ID correspondiente
                    if (Usuarios[i].ID == idUsuario)
                    {

                        // Modificamos los campos del usuario con los nuevos valores
                        Usuarios[i].Nombre = Nombre;
                        Usuarios[i].Apellido = Apellido;
                        Usuarios[i].Mail = Mail;
                        Usuarios[i].DNI = DNI;
                        Usuarios[i].Password = Pass;
                        Usuarios[i].IntentosFallidos = IntentosFallidos;
                        Usuarios[i].Bloqueado = Bloqueado;
                        Usuarios[i].MisFunciones = MisFunciones;
                        Usuarios[i].Credito = Credito;
                        Usuarios[i].FechaNacimiento = FechaNacimiento;
                        Usuarios[i].EsAdmin = esAdmin;


                        MessageBox.Show("Usuario modificado con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                }

                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                MessageBox.Show("Complete todos los campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            // Se busca el usuario que tiene el id pasado por parametro
            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);


            if (user != null)
            {
                try
                {
                    // Se eliminan todas las funciones del cliente antes de eliminarlo completamente
                    for (int i = 0; i < user.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = user.MisFunciones[i];
                        int cantidadEntradasSeleccionadas = user.EntradasCompradas[funcionActual.ID];

                        DevolverEntradaFuncionNotNull(user, funcionActual, funcionActual.ID, cantidadEntradasSeleccionadas);

                        funcionActual.EliminarCliente(idUsuario);

                    }

                    Usuarios.Remove(user);
                    MessageBox.Show("El usuario fue eliminado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        // ABM Funcion
        public bool AgregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, int CantidadClientes, double Costo)
        {
            try
            {
                // Buscar la sala correspondiente en la lista de salas
                Sala salaElegida = Salas.FirstOrDefault(s => s.ID == MiSalaId);

                if (salaElegida != null)
                {
                    // Buscar la película correspondiente en la lista de películas
                    Pelicula peliElegida = Peliculas.FirstOrDefault(p => p.ID == MiPeliculaId);
                    if (peliElegida != null)
                    {
                        // Verificar que el costo sea mayor a 0
                        if (Costo > 0)
                        {
                            // Crear una nueva instancia de Funcion
                            Funcion func = new Funcion(salaElegida, peliElegida, Fecha, CantidadClientes, Costo);

                            // Agregar la función a la lista de funciones
                            Funciones.Add(func);

                            // Agregar la función a la lista de funciones de la sala correspondiente
                            salaElegida.AgregarFuncion(func);

                            // Agregar la función a la lista de funciones de la película correspondiente
                            peliElegida.AgregarFuncion(func);
                            MessageBox.Show("Función Agregada correctamente", "Todo ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {
                            throw new ArgumentException("El costo debe ser mayor a 0.");

                        }

                    }
                    else
                    {
                        throw new ArgumentException("El ID de la pelicula es incorrecto.");
                    }

                }
                else
                {
                    throw new ArgumentException("El ID de la sala es incorrecto");
                }

                // Retornar true si no hubo errores
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "No se pudo guardar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarFuncion(int IDFuncion)

        {
            // Buscar la función con el ID correspondiente en la lista de funciones
            Funcion func = Funciones.FirstOrDefault(f => f.ID == IDFuncion);

            if (func != null)
            {
                // Eliminar la función de la lista de funciones de los clientes asociados
                for (int i = 0; i < func.Clientes.Count; i++)
                {
                    Usuario user = func.Clientes[i];

                    for (int j = 0; j < user.ObtenerMisFunciones().Count; j++)
                    {
                        if (user.ObtenerMisFunciones()[j].ID == IDFuncion)
                        {
                            user.EliminarFuncion(user.ObtenerMisFunciones()[j].ID);
                            break;
                        }
                    }
                    break;
                }

                // Buscar la película asociada a la función y eliminar la función de su lista de funciones
                Pelicula peli = Peliculas.FirstOrDefault(p => p.ID == func.MiPelicula.ID);

                for (int i = 0; i < peli.ObtenerMisFunciones().Count; i++)
                {
                    if (peli.ObtenerMisFunciones()[i].ID == IDFuncion)
                    {
                        peli.EliminarFuncion(peli.ObtenerMisFunciones()[i].ID);
                        break;
                    }
                }

                // Buscar la sala asociada a la función y eliminar la función de su lista de funciones
                Sala sala = Salas.FirstOrDefault(s => s.ID == func.MiSala.ID);

                for (int i = 0; i < sala.ObtenerMisFunciones().Count; i++)
                {
                    if (sala.ObtenerMisFunciones()[i].ID == IDFuncion)
                    {
                        sala.EliminarFuncion(sala.ObtenerMisFunciones()[i].ID);
                        break;
                    }
                }

                // Eliminar la función de la lista de funciones
                Funciones.Remove(func);
                MessageBox.Show("Función eliminada con éxito.", "Todo ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la funcion.", "404 Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

        }

        public bool ModificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, int CantidadClientes, double Costo, List<Usuario> Clientes)
        {
            try
            {


                Funcion func = Funciones.FirstOrDefault(f => f.ID == IDFuncion);
                if (func != null)
                {
                    Sala salaElegida = Salas.FirstOrDefault(s => s.ID == MiSalaId);
                    if (salaElegida != null)
                    {

                        Pelicula peliElegida = Peliculas.FirstOrDefault(p => p.ID == MiPeliculaId);
                        if (peliElegida != null)
                        {

                            if (Fecha >= DateTime.Today)
                            {
                                if (CantidadClientes >= 0 && Costo > 0 && Clientes != null)
                                {

                                    func.MiSala.EliminarFuncion(func.ID);
                                    func.MiPelicula.EliminarFuncion(func.ID);

                                    func.MiSala = salaElegida;
                                    func.MiPelicula = peliElegida;
                                    func.Clientes = Clientes;
                                    func.Fecha = Fecha;
                                    func.CantidadClientes = CantidadClientes;
                                    func.Costo = Costo;

                                    func.MiSala.AgregarFuncion(func);
                                    func.MiPelicula.AgregarFuncion(func);

                                    MessageBox.Show("Función modificada con éxito.", "Todo ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    throw new ArgumentException("Faltan datos");
                                }

                            }
                            else
                            {
                                throw new ArgumentException("La fecha no puede ser menor a hoy.");

                            }

                        }
                        else
                        {
                            throw new ArgumentException("Película no encontrada.");

                        }

                    }
                    else
                    {
                        throw new ArgumentException("Sala no encontrada.");

                    }

                }
                else
                {
                    throw new ArgumentException("Función no encontrada.");

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //ABM Sala 
        public bool AgregarSala(int Capacidad, string Ubicacion)
        {
            try
            {
                // Verificamos que la capacidad sea valida
                if (Capacidad >= 0)
                {
                    // Verificamos que la ubicacion se a valida
                    if (Ubicacion != null && Ubicacion != "")
                    {
                        // Se crea una nueva sala con los parametros para luego agregarla a la lista de salas
                        Sala nuevaSala = new Sala(Ubicacion, Capacidad);
                        Salas.Add(nuevaSala);

                        MessageBox.Show("Sala agregada con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException("Ubicacion Incorrecta");

                    }
                }
                else
                {
                    throw new InvalidOperationException("Capacidad Incorrecta");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Faltan datos" + e.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool EliminarSala(int IDSala)
        {
            // Se busca la sala con el id pasado por parametro
            Sala sala = Salas.FirstOrDefault(s => s.ID == IDSala);

            if (sala != null)
            {
                // Se eliminan las funciones de la sala antes de eliminar dicha sala
                for (int i = 0; i < sala.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = sala.MisFunciones[i];
                    funcionActual.MiSala = null;
                }

                Salas.Remove(sala);
                MessageBox.Show("La Sala fue eliminada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        public bool ModificarSala(int IDSala, string Ubicacion, int Capacidad, List<Funcion> MisFunciones)
        {
            // Verificamos que los valores sean validos
            if (IDSala != 0 && Capacidad >= 0 && Ubicacion != null && Ubicacion != "")
            {

                for (int i = 0; i < Salas.Count; i++)
                {
                    // Se busca la sala con el id correspondiente y se reemplazan los valores
                    if (Salas[i].ID == IDSala)
                    {
                        Salas[i].Capacidad = Capacidad;
                        Salas[i].Ubicacion = Ubicacion;
                        Salas[i].MisFunciones = MisFunciones;
                        MessageBox.Show("Sala Modificada correctamente", "Todo ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true;
                    }

                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return false;
        }

        // ABM Peliculas
        public bool AgregarPelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {
            try
            {
                // Hacemos las verificaciones correspondientes
                if (Nombre != null && Nombre != "")
                {
                    if (Descripcion != null && Descripcion != "")
                    {
                        if (Sinopsis != null && Sinopsis != "")
                        {
                            if (Poster != null && Poster != "")
                            {

                                if (Duracion >= 0)
                                {
                                    // De ser correctas creamos una nueva pelicula y la agregamos a la lista de peliculas
                                    Pelicula NuevaPelicula = new Pelicula(Nombre, Descripcion, Sinopsis, Poster, Duracion);
                                    Peliculas.Add(NuevaPelicula);
                                    MessageBox.Show("Pelicula agregada con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    return true;
                                }
                                else
                                {
                                    throw new InvalidOperationException("Duracion Incorrecta");
                                }

                            }
                            else
                            {
                                throw new InvalidOperationException("Poster Incorrecto");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Sinopsis Incorrecta");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Descripcion Incorrecta");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Nombre Incorrecto");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Parametros incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool EliminarPelicula(int IDPelicula)
        {

            // Se busca la pelicula con el id especificado
            Pelicula peli = Peliculas.FirstOrDefault(p => p.ID == IDPelicula);

            if (peli != null)
            {
                // En el caso de que exista, se eliminan de las funciones la pelicula especificada antes de remover la pelicula
                for (int i = 0; i < peli.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = peli.MisFunciones[i];
                    funcionActual.MiPelicula = null;
                }

                Peliculas.Remove(peli);
                MessageBox.Show("La Pelicula fue eliminada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ModificarPelicula(int IDPelicula, string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, List<Funcion> MisFunciones)
        {

            if (IDPelicula != 0 && Nombre != null && Nombre != "" && Descripcion != null && Descripcion != "" && Sinopsis != null && Sinopsis != "" && Poster != null && Poster != "" && Duracion >= 0)
            {

                for (int i = 0; i < Peliculas.Count; i++)
                {
                    for (int j = 0; j < MisFunciones.Count; j++)
                    {
                        Funcion func = Peliculas[i].MisFunciones.FirstOrDefault(f => f.ID == MisFunciones[j].ID);
                        if (func != null)
                        {
                            Peliculas[i].EliminarFuncion(func.ID);

                        }
                    }
                }

                for (int i = 0; i < Peliculas.Count; i++)
                {
                    if (Peliculas[i].ID == IDPelicula)
                    {

                        Peliculas[i].Nombre = Nombre;
                        Peliculas[i].Descripcion = Descripcion;
                        Peliculas[i].Sinopsis = Sinopsis;
                        Peliculas[i].Poster = Poster;
                        Peliculas[i].Duracion = Duracion;
                        Peliculas[i].MisFunciones = MisFunciones;

                        foreach (Funcion fun in Peliculas[i].MisFunciones)
                        {
                            fun.MiPelicula = Peliculas[i];
                        }


                        MessageBox.Show("Pelicula modificada con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Complete todos los campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

        }

        // METODOS
        public bool CargarCredito(int idUsuario, double importe)
        {
            foreach (Usuario user in Usuarios)
            {
                // se encuentra el usuario con el id pasado por parametro y se le agrega el credito correspondiente
                if (user.ID == idUsuario)
                {
                    if (importe > 0)
                    {
                        user.Credito += importe;
                        MessageBox.Show("Creditos cargados con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese una cantidad de créditos válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            return false;
            MessageBox.Show("Error al cargar los créditos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public bool ComprarEntrada(int idFuncion, int cantidadEntradas)
        {
            try
            {
                // Verificar si el usuario está logueado
                if (UsuarioActual != null)
                {
                    // Buscar la función correspondiente al idFuncion
                    Funcion funcion = Funciones.Find(f => f.ID == idFuncion);

                    if (funcion != null)
                    {
                        // Verificar si la cantidad de entradas es mayor a cero
                        if (cantidadEntradas > 0)
                        {
                            double costoTotal = funcion.Costo * cantidadEntradas;

                            // Verificar si el usuario tiene suficiente crédito
                            if (UsuarioActual.Credito >= costoTotal)
                            {
                                // Verificar si la capacidad de la sala es suficiente
                                if (funcion.AsientosDisponibles >= cantidadEntradas)
                                {
                                    // Agregar la función a las funciones del usuario
                                    UsuarioActual.MisFunciones.Add(funcion);

                                    // Actualizar la cantidad de clientes de la función
                                    funcion.CantidadClientes += cantidadEntradas;

                                    funcion.AsientosDisponibles -= cantidadEntradas;

                                    // Agregar al usuario como cliente de la función
                                    funcion.AgregarCliente(UsuarioActual);

                                    // Actualizar el crédito del usuario
                                    UsuarioActual.Credito -= costoTotal;


                                    // Actualizar las entradas compradas por el usuario
                                    if (UsuarioActual.EntradasCompradas.ContainsKey(idFuncion))
                                    {
                                        UsuarioActual.EntradasCompradas[idFuncion] += cantidadEntradas;
                                    }
                                    else
                                    {
                                        UsuarioActual.EntradasCompradas.Add(idFuncion, cantidadEntradas);
                                    }

                                    MessageBox.Show("Entrada comprada con éxito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }
                                else
                                {
                                    throw new InvalidOperationException("No hay suficiente capacidad en la sala.");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Créditos insuficientes.");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("La cantidad de entradas debe ser mayor a cero.");
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("No se encontró la función.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, inicia sesión.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool DevolverEntrada(int idFuncion, int cantidadEntradas)
        {
            try
            {
                Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion);

                if (funcion != null)
                {

                    return DevolverEntradaFuncionNotNull(UsuarioActual, funcion, idFuncion, cantidadEntradas);
                    //// Verificar si la función ya ha ocurrido
                    //if (funcion.Fecha > DateTime.Now)
                    //{
                    //    // Verificar si el usuario tiene compradas las entradas
                    //    if (UsuarioActual.EntradasCompradas.ContainsKey(idFuncion) && UsuarioActual.EntradasCompradas[idFuncion] >= cantidadEntradas)
                    //    {
                    //        // Remover la función de las funciones del usuario
                    //        UsuarioActual.MisFunciones.Remove(funcion);

                    //        // Actualizar la cantidad de clientes de la función
                    //        funcion.CantidadClientes -= cantidadEntradas;

                    //        funcion.AsientosDisponibles += cantidadEntradas;


                    //        // Eliminar al usuario como cliente de la función
                    //        funcion.EliminarCliente(UsuarioActual.ID);

                    //        // Actualizar las entradas compradas por el usuario
                    //        UsuarioActual.EntradasCompradas[idFuncion] -= cantidadEntradas;

                    //        MessageBox.Show("asientos disponibles: " + funcion.AsientosDisponibles);
                    //        MessageBox.Show("cantidad clientes: " + funcion.CantidadClientes);

                    //        // Verificar si se han devuelto todas las entradas
                    //        if (UsuarioActual.EntradasCompradas[idFuncion] <= 0)
                    //        {
                    //            UsuarioActual.EntradasCompradas.Remove(idFuncion);
                    //        }

                    //        // Calcular el reembolso y actualizar el crédito del usuario
                    //        double costoTotal = funcion.Costo * cantidadEntradas;
                    //        UsuarioActual.Credito += costoTotal;

                    //        MessageBox.Show("Entrada devuelta con éxito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        throw new InvalidOperationException("No tienes suficientes entradas compradas para devolver.");
                    //    }
                    //}
                    //else
                    //{
                    //    throw new InvalidOperationException("No es posible devolver una entrada de una función que ya ocurrió.");
                    //}

                }
                else
                {
                    throw new FileNotFoundException("No se encontró la función.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool IniciarSesion(string Mail, string Password, bool esAdmin)
        {
            try
            {
                foreach (Usuario user in Usuarios)
                {
                    // Se hacen las verificaciones correspondientes
                    if (user.Mail.Equals(Mail))

                    {
                        if (user.Bloqueado == false)
                        {
                            if (user.Password.Equals(Password))
                            {

                                if (user.EsAdmin == esAdmin)
                                {
                                    // Se establece el usuario como usuario actual
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
                                MessageBox.Show("Email o contraseña incorrecta, intentalo nuevamente");

                            }
                            else
                            {
                                user.Bloqueado = true;
                                MessageBox.Show("Ha alcanzado la cantidad de intentos. Usuario bloqueado");

                            }
                        }
                        else { throw new InvalidOperationException("No se puede acceder, el usuario se encuentra bloqueado"); }
                    }

                }
                throw new InvalidOperationException("Email o contraseña incorrecta, intentalo nuevamente");

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

        // Devuelven copias de las listas originales
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

        public List<Pelicula> MostrarPeliculas()
        {
            return Peliculas.ToList();
        }

        //MOSTRAR POR ID
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

        public Pelicula ObtenerPeliculaPorId(int ID)
        {
            foreach (Pelicula pel in Peliculas)
            {

                if (pel.ID == ID)
                {
                    return pel;
                }
            }

            throw new InvalidDataException("El ID no se encontró en la base de datos.");
        }

        public List<Funcion> BuscarFuncion(string pelicula, string ubicacion, DateTime fecha, int precioMinimo, int precioMaximo)
        {
            List<Funcion> funcionesEncontradas = new List<Funcion>();
            if (fecha >= DateTime.Today)
            {
              
                foreach (Funcion fun in Funciones)
                {
                    bool cumpleRequisitos = true;

                    if (fun.Fecha >= DateTime.Today)
                    {
                        // Verifico que si el input no esta en vacio entonces el valor tiene que ser igual o similar al de la pelicula;
                        if (!string.IsNullOrEmpty(pelicula))
                        {
                            Regex regularEx = new Regex(pelicula, RegexOptions.IgnoreCase);

                            if (!regularEx.IsMatch(fun.MiPelicula.Nombre))
                            {
                                cumpleRequisitos = false;
                            }
                        }

                        // Lo mismo con ubicacion
                        if (!string.IsNullOrEmpty(ubicacion))
                        {
                            if (fun.MiSala.Ubicacion != ubicacion)
                            {
                                cumpleRequisitos = false;
                            }

                        }

                        //todas las funciones que superen el minimo

                        if (precioMinimo >= 0)
                        {
                            if (fun.Costo < precioMinimo)
                            {
                                cumpleRequisitos = false;
                            }
                        }

                        if (precioMaximo > 0)
                        {
                            if (fun.Costo > precioMaximo)
                            {
                                cumpleRequisitos = false;
                            }
                        }
                    }
                    else
                    {
                        cumpleRequisitos = false;


                    }

                    if (cumpleRequisitos)
                    {
                        funcionesEncontradas.Add(fun);
                    }
                }

               
            }
            else
            {
                MessageBox.Show("No se puede filtar por una fecha anterior a hoy.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return funcionesEncontradas;

        }

        private bool DevolverEntradaFuncionNotNull(Usuario user, Funcion funcion, int idFuncion, int cantidadEntradas)
        {

            // Verificar si la función ya ha ocurrido
            if (funcion.Fecha > DateTime.Now)
            {
                // Verificar si el usuario tiene compradas las entradas
                if (user.EntradasCompradas.ContainsKey(idFuncion) && user.EntradasCompradas[idFuncion] >= cantidadEntradas)
                {
                    // Remover la función de las funciones del usuario
                    user.MisFunciones.Remove(funcion);

                    // Actualizar la cantidad de clientes de la función
                    funcion.CantidadClientes -= cantidadEntradas;

                    funcion.AsientosDisponibles += cantidadEntradas;


                    // Eliminar al usuario como cliente de la función
                    funcion.EliminarCliente(user.ID);

                    // Actualizar las entradas compradas por el usuario
                    user.EntradasCompradas[idFuncion] -= cantidadEntradas;

                    MessageBox.Show("asientos disponibles: " + funcion.AsientosDisponibles);
                    MessageBox.Show("cantidad clientes: " + funcion.CantidadClientes);

                    // Verificar si se han devuelto todas las entradas
                    if (user.EntradasCompradas[idFuncion] <= 0)
                    {
                        user.EntradasCompradas.Remove(idFuncion);
                    }

                    // Calcular el reembolso y actualizar el crédito del usuario
                    double costoTotal = funcion.Costo * cantidadEntradas;
                    user.Credito += costoTotal;


                    return true;
                }
                else
                {
                    throw new InvalidOperationException("No tienes suficientes entradas compradas para devolver.");

                }
            }
            else
            {
                throw new InvalidOperationException("No es posible devolver una entrada de una función que ya ocurrió.");
            }
        }

    }

}







