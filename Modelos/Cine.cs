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
using TP1___GRUPO_C.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Azure;

namespace TP1___GRUPO_C.Model
{
    public class Cine
    {
        private MyContext contexto;
        public Usuario UsuarioActual;

        public Cine()
        {
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                contexto = new MyContext();
                //Cargo los UsuariosFuncion
                contexto.Usuarios.Include(u => u.MisFunciones).Load();
                contexto.Funciones.Include(f => f.Clientes).Load();
                contexto.Salas.Include(s => s.MisFunciones).Load();
                contexto.Peliculas.Include(p => p.MisFunciones).Load();
                contexto.UF.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        #region ABM Usuario
        public int AgregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, float credito, bool bloqueado)
        {
            // Ahora el usuario solo valida que DNI y Mail no sean repetidos, si los campos estan vacios o no lo valida la vista
            try
            {
                // Verifico si el DNI y correo ya están registrados
                bool flagDni = contexto.Usuarios.Any(u => DNI == u.DNI || Mail == u.Mail);
                if (flagDni)
                {
                    MessageBox.Show("El DNI ingresado o el correo ya se encuentran registrados en el sistema");
                    return 500;
                }

                // Crear un nuevo usuario y agregarlo a la lista de usuarios
                Usuario otro = new Usuario
                {
                    DNI = DNI,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Mail = Mail,
                    Password = Password,
                    FechaNacimiento = FechaNacimiento,
                    EsAdmin = EsAdmin,
                    Credito = credito,

                };
                contexto.Usuarios.Add(otro);
                contexto.SaveChanges();

                return 201;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return 422;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 500;
            }
        }

        public int ModificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito)
        {
            // La vista verifica si son correctos los datos pasados por parametro
            Usuario user = contexto.Usuarios.Where(u => u.ID == idUsuario).FirstOrDefault();
            if (user != null)
            {
                user.DNI = DNI;
                user.Nombre = Nombre;
                user.Apellido = Apellido;
                user.Mail = Mail;
                user.Password = Pass;
                user.FechaNacimiento = FechaNacimiento;
                user.EsAdmin = esAdmin;
                user.IntentosFallidos = IntentosFallidos;
                user.Bloqueado = Bloqueado;
                user.Credito = Credito;
                //no pongo mis funciones porque no lo estamos modificando por parametro
                //List<Funcion> MisFunciones = user.MisFunciones;
                //user.MisFunciones = MisFunciones;
                contexto.Usuarios.Update(user);
                contexto.SaveChanges();
                return 200;
            }
            else
            {
                return 400;
            }

        }

        public int EliminarUsuario(int idUsuario)
        {
            Usuario user = contexto.Usuarios.Where(u => u.ID == idUsuario).FirstOrDefault();
            UsuarioFuncion entrada = contexto.UF.Where(uf => uf.idUsuario == idUsuario).FirstOrDefault();

            int response = 200;

            try
            {
                if (user != null)
                {
                    if (entrada != null)
                    {
                        // Se fija que todas las entradas hayan sido devueltas y procede a eliminar al usuario
                        response = DevolverEntradasUsuario(user);
                        contexto.Usuarios.Remove(user);
                        contexto.SaveChanges();
                        return response;
                    }
                    else
                    {
                        // En el caso de que no tenga ninguna entrada comprada elimina al usuario directamente
                        contexto.Usuarios.Remove(user);
                        contexto.SaveChanges();
                        return response;
                    }

                }
                else
                {
                    response = 500;
                    throw new Exception("Usuario no encontrado.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }

        }

        #endregion

        #region ABM Funcion


        public int AgregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            try
            {
                // Buscar la sala correspondiente en la lista de salas
                Sala salaElegida = contexto.Salas.Where(s => s.ID == MiSalaId).FirstOrDefault();
                int capacidad = salaElegida.Capacidad;

                if (salaElegida != null)
                {
                    // Buscar la película correspondiente en la lista de películas
                    Pelicula peliElegida = contexto.Peliculas.Where(p => p.ID == MiPeliculaId).FirstOrDefault();
                    if (peliElegida != null)
                    {
                        // Verificar que el costo sea mayor a 0
                        if (Costo > 0)
                        {
                            // Crear una nueva instancia de Funcion
                            //Funcion func = new Funcion(salaElegida, peliElegida, Fecha, Costo);
                            Funcion func = new Funcion(Fecha, Costo, MiSalaId, MiPeliculaId, capacidad);

                            // Agregar la función a la lista de funciones de la sala correspondiente
                            salaElegida.MisFunciones.Add(func);

                            // Agregar la función a la lista de funciones de la película correspondiente
                            peliElegida.MisFunciones.Add(func);

                            func.MiPelicula = peliElegida;
                            func.MiSala = salaElegida;

                            contexto.Funciones.Add(func);
                            contexto.SaveChanges();

                            return 200;
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 500;
            }
        }

        public int EliminarFuncion(int IDFuncion)
        {
            // Buscar la función con el ID correspondiente en la lista de funciones
            Funcion func = contexto.Funciones.Where(f => f.ID == IDFuncion).FirstOrDefault();
            try
            {
                if (func != null)
                {
                    // Eliminar la función de la lista de funciones de todos los clientes asociados
                    foreach (Usuario user in func.Clientes)
                    {

                        //Para cada Usuario en la lista de Clientes le eliminamos dicha funcion y le devolvemos el dinero
                        if (func.Fecha >= DateTime.Now)
                        {
                            user.Credito += func.Costo;
                            contexto.Usuarios.Update(user);
                        }

                        //Habria que ver si el hecho de que borremos una funcion que ya paso esta bien, yo creeria que no pero talvez se genera problemas
                        // a la hora de mostrar las funciones pasadas.
                        //*A001
                        user.MisFunciones.Remove(func);
                    }

                    // Eliminar la función de la lista de funciones
                    contexto.Funciones.Remove(func);
                    contexto.SaveChanges();
                    return 200;
                }

                throw new Exception("No se encontró la función.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 404;
            }
        }

        public int ModificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            // Se elimino cantidad de clientes como parametro porque no deberia estar
            int response = 200;
            try
            {
                Funcion func = contexto.Funciones.Where(f => f.ID == IDFuncion).FirstOrDefault();

                if (func != null)
                {

                    Sala salaVieja = func.MiSala;
                    Pelicula peliculaVieja = func.MiPelicula;

                    Sala salaNueva = contexto.Salas.Where(s => s.ID == MiSalaId).FirstOrDefault();
                    Pelicula peliculaNueva = contexto.Peliculas.Where(p => p.ID == MiPeliculaId).FirstOrDefault();


                    if (salaNueva != null && peliculaNueva != null)
                    {
                        if (salaNueva.ID != salaVieja.ID || peliculaNueva.ID != peliculaVieja.ID)
                        {
                            if (Fecha >= DateTime.Today)
                            {
                                if (func.CantidadClientes >= 0 && Costo > 0 && func.Clientes != null)
                                {
                                    func.MiSala.MisFunciones.Remove(func);
                                    func.MiPelicula.MisFunciones.Remove(func);

                                    salaNueva.MisFunciones.Add(func);
                                    peliculaNueva.MisFunciones.Add(func);

                                    func.MiSala = salaNueva;
                                    func.MiPelicula = peliculaNueva;
                                    func.Fecha = Fecha;
                                    func.Costo = Costo;

                                    contexto.Funciones.Update(func);
                                    contexto.SaveChanges();

                                    return response;
                                }
                                else
                                {
                                    response = 422;
                                    throw new ArgumentException("Faltan datos");
                                }
                            }
                            else
                            {
                                response = 500;
                                throw new ArgumentException("La fecha no puede ser menor a hoy.");

                            }
                        }
                        else
                        {
                            // Si es la misma sala y película, solo se cambia lo siguiente
                            func.Fecha = Fecha;
                            func.Costo = Costo;

                            contexto.Funciones.Update(func);
                            contexto.SaveChanges();
                            return response;
                        }
                    }
                    else
                    {
                        response = 500;
                        throw new ArgumentException("Sala o Pelicula no encontrada.");
                    }
                }
                else
                {
                    response = 404;
                    throw new Exception("Función no encontrada.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return response;
            }
        }

        #endregion

        #region ABM Sala

        public int AgregarSala(int Capacidad, string Ubicacion)
        {
            try
            {
                Sala nuevaSala = new Sala { Capacidad = Capacidad, Ubicacion = Ubicacion };
                contexto.Salas.Add(nuevaSala);
                contexto.SaveChanges();
                return 200;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 500;
            }


        }

        public int EliminarSala(int IDSala)
        {
            Sala sala = contexto.Salas.Where(s => s.ID == IDSala).FirstOrDefault();

            int response = 200;

            try
            {
                if (sala != null)
                {
                    for (int i = 0; i < sala.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = sala.MisFunciones[i];

                        // Hay que usar funcion actual en vez de remove creo
                        response = EliminarFuncion(funcionActual.ID);
                        if (response != 200)
                        {
                            throw new Exception("Ocurrió un error al eliminar la funcion " + funcionActual.ToString());

                        }
                    }
                    contexto.Salas.Remove(sala);
                    contexto.SaveChanges();
                    return response;
                }
                else
                {
                    response = 404;
                    throw new Exception("No se encontró la sala");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return response;
            }

        }

        public int ModificarSala(int IDSala, string Ubicacion, int Capacidad)
        {
            Sala sala = contexto.Salas.Where(s => s.ID == IDSala).FirstOrDefault();

            if (sala != null)
            {
                sala.Ubicacion = Ubicacion;
                sala.Capacidad = Capacidad;
                contexto.Salas.Update(sala);
                contexto.SaveChanges();
                return 200;
            }
            else
            {
                return 500;
            }
        }

        #endregion

        #region ABM Pelicula

        //Las verificaciones las hace la vista ahora
        public int AgregarPelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {
            try
            {
                Pelicula pelicula = new Pelicula
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Sinopsis = Sinopsis,
                    Poster = Poster,
                    Duracion = Duracion
                };

                contexto.Peliculas.Add(pelicula);
                contexto.SaveChanges();
                return 200;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 500;
            }

        }

        public int EliminarPelicula(int IDPelicula)
        {
            // Se busca la pelicula con el id especificado
            Pelicula pelicula = contexto.Peliculas.Where(p => p.ID == IDPelicula).FirstOrDefault();

            int response = 200;

            try
            {
                if (pelicula != null)
                {
                    // Como ya no existe dicha pelicula, se eliminan todas las Funciones que la daban
                    for (int i = 0; i < pelicula.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = pelicula.MisFunciones[i];
                        response = EliminarFuncion(funcionActual.ID);
                        if (response != 200)
                        {
                            throw new Exception("Ocurrió un error al eliminar la función.");
                        }

                    }
                    contexto.Peliculas.Remove(pelicula);
                    contexto.SaveChanges();
                    response = 204;
                    return response;
                }
                response = 404;
                throw new Exception("No se encontró la pelicula");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return response;
            }

        }

        public int ModificarPelicula(int IDPelicula, string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, List<string> IdFunciones)
        {

            Pelicula pelicula = contexto.Peliculas.Where(p => p.ID == IDPelicula).FirstOrDefault();
            List<Funcion> MisFunciones = new List<Funcion>();

            if (pelicula != null)
            {
                pelicula.Nombre = Nombre;
                pelicula.Descripcion = Descripcion;
                pelicula.Duracion = Duracion;
                pelicula.Sinopsis = Sinopsis;
                pelicula.Poster = Poster;

                foreach (String IdFun in IdFunciones)
                {
                    int.TryParse(IdFun, out int idFunc);
                    Funcion funcion = contexto.Funciones.Where(f => f.ID == idFunc).FirstOrDefault();
                    if (funcion != null)
                    {
                        pelicula.MisFunciones.Add(funcion);

                    }
                }

                contexto.Peliculas.Update(pelicula);
                contexto.SaveChanges();
                return 200;
            }
            return 404;
        }

        #endregion

        #region Metodos

        public int CargarCredito(int idUsuario, double importe)
        {
            Usuario usuario = contexto.Usuarios.Where(u => u.ID == idUsuario).FirstOrDefault();

            if (usuario != null)
            {
                // Si el credito es > 0 lo valida la vista
                usuario.Credito += importe;
                contexto.Usuarios.Update(usuario);
                contexto.SaveChanges();
                return 200;

            }
            return 500;

        }

        public int ComprarEntrada(int idFuncion, int cantidadEntradas)
        {
            try
            {
                // Verificar si el usuario está logueado
                if (UsuarioActual != null)
                {
                    // Buscar la función correspondiente al idFuncion
                    Funcion funcion = contexto.Funciones.Where(f => f.ID == idFuncion).FirstOrDefault();

                    if (funcion != null && funcion.Fecha > DateTime.Now)
                    {
                        ComprarEntradaFuncionNotNull(UsuarioActual, cantidadEntradas, funcion);
                        return 200;
                    }
                    else
                    {
                        throw new FileNotFoundException("No se encontró la función.");
                    }
                }
                else
                {
                    return 403;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 500;
            }
        }

        public int ComprarEntradaFuncionNotNull(Usuario user, int cantidadEntradas, Funcion funcion)
        {
            //NO ES NECESARIO PASAR EL OBJETO COMPLET, CON PASAR SOLO EL ID ESTA OK 
            UsuarioFuncion entrada = contexto.UF.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == funcion.ID);

            try
            {
                if (entrada != null)
                {
                    double costoTot = entrada.funcion.Costo * cantidadEntradas;
                    if (entrada.usuario.Credito >= costoTot)
                    {
                        if (entrada.funcion.AsientosDisponibles >= cantidadEntradas)
                        {
                            entrada.funcion.CantidadClientes += cantidadEntradas;
                            entrada.funcion.AsientosDisponibles -= cantidadEntradas;
                            entrada.CantidadEntradasCompradas += cantidadEntradas;
                            contexto.UF.Update(entrada);
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
                    Funcion fun = contexto.Funciones.FirstOrDefault(f => f.ID == funcion.ID);
                    if (fun != null)
                    {
                        Usuario usr = contexto.Usuarios.FirstOrDefault(u => u.ID == user.ID);
                        if (usr != null)
                        {

                            fun.CantidadClientes += cantidadEntradas;
                            fun.AsientosDisponibles -= cantidadEntradas;
                            contexto.Funciones.Update(fun);

                            usr.Credito -= fun.Costo * cantidadEntradas;
                            usr.MisFunciones.Add(funcion);
                            contexto.Usuarios.Update(usr);


                            entrada = new UsuarioFuncion(usr.ID, fun.ID, cantidadEntradas);
                            contexto.UF.Add(entrada);
                        }
                        else
                        {
                            throw new InvalidOperationException("No se encontró el usuario");

                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("No se encontró la funcíon");
                    }
                }


                contexto.SaveChanges();

                return 200;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 500;
            }

        }

        /*
         *  SEGUNDA FORMA DE HACERLO
         *  
        public int ComprarEntradaFuncionNotNull(Usuario user, int cantidadEntradas, Funcion funcion)
        {
            UsuarioFuncion entrada = contexto.UF.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == funcion.ID);

            double costoTotal = funcion.Costo * cantidadEntradas;
            // Verificar si el usuario tiene suficiente crédito
            if (user.Credito >= costoTotal)
            {
                // Verificar si la capacidad de la sala es suficiente
                if (funcion.AsientosDisponibles >= cantidadEntradas)
                {
                    // Agregar la función a las funciones del usuario
                    Funcion fun = user.MisFunciones.FirstOrDefault(f => f.ID == funcion.ID);

                    // Actualizar la cantidad de clientes de la lista de funciones del cine
                    funcion.CantidadClientes += cantidadEntradas;
                    funcion.AsientosDisponibles -= cantidadEntradas;

                    if (entrada != null)
                    {
                        // Entra aquí si el usuario ya tiene al menos 1 entrada para dicha función
                        entrada.CantidadEntradasCompradas += cantidadEntradas;
                        contexto.UF.Update(entrada);
                    }
                    else
                    {
                        // Entra aquí si el usuario nunca compró para esta función
                        // Agregar al usuario como cliente de la función
                        funcion.Clientes.Add(user);

                        entrada = new UsuarioFuncion(user.ID, funcion.ID, cantidadEntradas);

                        contexto.UF.Add(entrada);
                    }

                    if (fun == null)
                    {
                        user.MisFunciones.Add(funcion);
                    }
                    else
                    {
                        // Actualizar la cantidad de clientes de la lista de funciones del cliente
                        fun.CantidadClientes += cantidadEntradas;
                        fun.AsientosDisponibles -= cantidadEntradas;
                    }

                    // Actualizar el crédito del usuario
                    user.Credito -= costoTotal;

                    // Se updatea funcion y usuarios para relfejar la nueva cantidad de asientos disponibles y clientes, y el credito del usuario
                    contexto.Usuarios.Update(user);
                    contexto.Funciones.Update(funcion);
                    contexto.SaveChanges();

                    return 200;
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
        */

        public int DevolverEntradasUsuario(Usuario user)
        {
            int result = 200;

            // Filtrar las funciones del usuario que sean mayores o iguales a la fecha actual
            List<Funcion> funcionesValidas = user.MisFunciones.Where(f => f.Fecha >= DateTime.Now).ToList();

            foreach (Funcion f in funcionesValidas)
            {
                UsuarioFuncion entrada = contexto.UF.Where(uf => uf.idUsuario == user.ID && uf.idFuncion == f.ID).FirstOrDefault();
                if (entrada != null)
                {
                    result = DevolverEntrada(user, f.ID, entrada.CantidadEntradasCompradas);
                    if (result == 500)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public int DevolverEntrada(Usuario user, int idFuncion, int cantidadEntradas)
        {
            try
            {
                Funcion funcion = contexto.Funciones.Where(f => f.ID == idFuncion).FirstOrDefault();

                if (funcion != null)
                {
                    DevolverEntradaFuncionNotNull(user, idFuncion, cantidadEntradas);
                    return 200;
                }
                else
                {
                    throw new FileNotFoundException("No se encontró la función.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 500;
            }
        }

        private bool DevolverEntradaFuncionNotNull(Usuario user, int idFuncion, int cantidadEntradas)
        {
            UsuarioFuncion entrada = contexto.UF.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion);

            if (entrada.funcion.Fecha > DateTime.Now && entrada != null)
            {

                if (entrada.CantidadEntradasCompradas >= cantidadEntradas)
                {

                    entrada.funcion.CantidadClientes -= cantidadEntradas;
                    entrada.funcion.AsientosDisponibles += cantidadEntradas;
                    entrada.CantidadEntradasCompradas -= cantidadEntradas;
                    double costoTotal = entrada.funcion.Costo * cantidadEntradas;
                    user.Credito += costoTotal;

                    if (entrada.CantidadEntradasCompradas <= 0)
                    {
                        contexto.UF.Remove(entrada);
                        user.MisFunciones.Remove(entrada.funcion);
                        entrada.funcion.Clientes.Remove(user);
                    }
                    else
                    {
                        contexto.UF.Update(entrada);
                    }

                    contexto.Usuarios.Update(user);
                    contexto.Funciones.Update(entrada.funcion);
                    contexto.SaveChanges();

                    return true;

                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }

        }

        public int IniciarSesion(string Mail, string Password)
        {
            try
            {
                foreach (Usuario user in contexto.Usuarios)
                {
                    // Se hacen las verificaciones correspondientes
                    if (user.Mail.Equals(Mail))
                    {
                        if (user.Bloqueado == false)
                        {
                            if (user.Password.Equals(Password))
                            {
                                UsuarioActual = user;
                                user.IntentosFallidos = 0;
                                contexto.Usuarios.Update(user);
                                contexto.SaveChanges();
                                return 200;

                            }
                            else if (user.IntentosFallidos < 3)
                            {
                                user.IntentosFallidos += 1;
                                contexto.Usuarios.Update(user);
                                // Ver si no es excesivo guardar aca, ya que te lo guarda si se bloquea o si metes la pass correcta
                                contexto.SaveChanges();
                                return 401;
                            }
                            else
                            {
                                user.Bloqueado = true;
                                contexto.Usuarios.Update(user);
                                contexto.SaveChanges();
                                return 429;
                            }
                        }
                        return 423;
                    }
                }
                return 401;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 500;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public List<Usuario> MostrarUsuarios()
        {
            return contexto.Usuarios.ToList();
        }

        public List<Funcion> MostrarFunciones()
        {
            return contexto.Funciones.ToList();
        }

        public List<Sala> MostrarSalas()
        {
            return contexto.Salas.ToList();
        }

        public List<Pelicula> MostrarPeliculas()
        {
            return contexto.Peliculas.ToList();
        }

        //// Devuelven copias de las listas originales


        /*
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
                        if (!string.IsNullOrWhiteSpace(pelicula))
                        {
                            Regex regularEx = new Regex(pelicula, RegexOptions.IgnoreCase);

                            if (!regularEx.IsMatch(fun.MiPelicula.Nombre))
                            {
                                cumpleRequisitos = false;
                            }
                        }
                        else
                        {
                            cumpleRequisitos = cumpleRequisitos && (fun.MiPelicula.Nombre != null);
                        }

                        // Lo mismo con ubicacion
                        // IsNullOrEmpty(ubicacion) --> devuelve true si no encuenrta valor en el campo
                        // si esto es false entonces es porque tengo un valor

                        if (!string.IsNullOrWhiteSpace(ubicacion))
                        {
                            // yo quiero que esto sea igual para no modificar el flag
                            if (fun.MiSala.Ubicacion != ubicacion)
                            {
                                cumpleRequisitos = false;
                            }
                        }
                        else
                        {
                            cumpleRequisitos = cumpleRequisitos && (fun.MiSala.Ubicacion != null);
                        }

                        //todas las funciones que superen el minimo
                        if (precioMinimo >= 0)
                        {
                            if (fun.Costo < precioMinimo)
                            {
                                cumpleRequisitos = false;
                            }
                        }
                        else
                        {
                            cumpleRequisitos = cumpleRequisitos && (fun.Costo >= 0);
                        }

                        if (precioMaximo > 0)
                        {
                            if (fun.Costo > precioMaximo)
                            {
                                cumpleRequisitos = false;
                            }
                        }
                        else
                        {
                            cumpleRequisitos = cumpleRequisitos && (fun.Costo <= 0);
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
            return funcionesEncontradas;
        }
        */

 
        public List<Funcion> BuscarFuncion(string pelicula, string ubicacion, DateTime fecha, int precioMinimo, int precioMaximo)
        {
            List<Funcion> funcionesEncontradas = new List<Funcion>();

            if (fecha >= DateTime.Today)
            {

                funcionesEncontradas = contexto.Funciones.Where(fun =>
                    fun.Fecha >= DateTime.Today &&
                    (
                        !string.IsNullOrWhiteSpace(pelicula) || fun.MiPelicula.Nombre.Contains(pelicula)
                   ||
                        !string.IsNullOrWhiteSpace(ubicacion) || fun.MiSala.Ubicacion.Equals(ubicacion)
                    )
                    && (precioMinimo >= 0 && fun.Costo >= precioMinimo)
                    && (precioMaximo >= 0 && fun.Costo <= precioMaximo)

                    ).ToList();

                //no sea nulo o espacio (pelicula) &&
            }
            return funcionesEncontradas;

        }


        public bool esAdmin()
        {
            return UsuarioActual.EsAdmin;
        }

        #endregion

        //Ver de borrarlo
        public int agregarUsuarioFuncion(int idUsuario, int idFuncion)
        {
            // Este metodo es innecesario, comprar entrada deberia agregar a esta tabla, ver de cambiar adonde se implementa
            /* 
            if (DB.agregarUsuarioFuncion(idUsuario, idFuncion) != -1)
            {
                return 200;
            }
            else
            {
                return 500;
            }
            */
            return 0;
        }

        public void cerrar()
        {
            contexto.Dispose();
        }

    }

}







