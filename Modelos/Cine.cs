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

        /*
        public List<Usuario> Usuarios;
        public List<Funcion> Funciones;
        public List<Sala> Salas;
        public List<Pelicula> Peliculas;
        public Usuario UsuarioActual;
        public List<UsuarioFuncion> misUsuarioFuncion;
        private DAL DB;

        public Cine()
        {
            Usuarios = new List<Usuario>();
            Funciones = new List<Funcion>();
            Salas = new List<Sala>();
            Peliculas = new List<Pelicula>();
            misUsuarioFuncion = new List<UsuarioFuncion>();
            DB = new DAL();
            inicializarAtributos();

        }

        private void inicializarAtributos()
        {

            Usuarios = DB.inicializarUsuarios();
            Funciones = DB.inicializarFunciones();
            Salas = DB.inicializarSalas();
            Peliculas = DB.inicializarPeliculas();
            misUsuarioFuncion = DB.inicializarUsuarioFuncion();
            vincularClases();
        }

        public void vincularClases()
        {
            //SI FUESE MANY TO MANY
            foreach (UsuarioFuncion uf in misUsuarioFuncion)
            {
                foreach (Funcion fun in Funciones)
                {
                    foreach (Usuario u in Usuarios)
                        if (uf.idUsuario == u.ID && uf.idFuncion == fun.ID)
                        {
                            u.MisFunciones.Add(fun);
                            fun.Clientes.Add(u);
                        }
                }
            }

            // Relacion one to many Funciones por Pelicula
            foreach (Funcion fun in Funciones)
            {
                foreach (Pelicula p in Peliculas)
                    if (p.ID == fun.idPelicula)
                    {
                        p.MisFunciones.Add(fun);
                        fun.MiPelicula = p;
                    }
            }

            //Relacion one to many Funciones por Sala
            foreach (Funcion fun in Funciones)
            {
                foreach (Sala s in Salas)
                    if (s.ID == fun.idSala)
                    {
                        s.MisFunciones.Add(fun);
                        fun.MiSala = s;
                    }
            }
        }
        */

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
                    Credito = credito
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


        // Metodo Viejo
        //public int AgregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, float credito, bool bloqueado)
        //{
        //    bool flagDni = false;

        //    try
        //    {
        //        // Verificaciones correspondientes
        //        if (DNI != 0)
        //        {
        //            if (Nombre != null && Nombre != "")
        //            {
        //                if (Apellido != null && Apellido != "")
        //                {
        //                    if (Mail != null && Mail != "")
        //                    {
        //                        if (Password != null && Password != "")
        //                        {
        //                            // Verifico si el DNI y correo ya estan registrados
        //                            foreach (Usuario u in Usuarios)
        //                            {
        //                                if (DNI == u.DNI || Mail == u.Mail)
        //                                {
        //                                    flagDni = true;
        //                                    MessageBox.Show("El DNI Ingresado ya se encuentra dentro del sistema");
        //                                }
        //                            }

        //                            // Si el DNI y el correo no están registrados, crear un nuevo usuario y agregarlo a la lista de usuarios
        //                            if (!flagDni)
        //                            {
        //                                int idNuevoUsuario;

        //                                idNuevoUsuario = DB.agregarUsuario(DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin, credito, false);

        //                                if (idNuevoUsuario != -1)
        //                                {
        //                                    Usuario otro = new Usuario(idNuevoUsuario, DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin);
        //                                    otro.Credito = credito;
        //                                    Usuarios.Add(otro);
        //                                    return 201;
        //                                }

        //                            }
        //                            return 500;
        //                        }
        //                        else
        //                        {
        //                            throw new InvalidOperationException("Password incorrecta");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        throw new InvalidOperationException("Mail Incorrecto");
        //                    }
        //                }
        //                else
        //                {
        //                    throw new InvalidOperationException("Apellido Incorrecto");
        //                }
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("Nombre Incorrecto");
        //            }
        //        }
        //        else
        //        {
        //            throw new InvalidOperationException("DNI Incorrecto");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return 422;

        //    }

        //}

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

        /* Metodo Viejo
         * 
        public int ModificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito)
        {

            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);
            List<Funcion> MisFunciones = user.MisFunciones;

            if (DB.modificarUsuario(idUsuario, DNI, Nombre, Apellido, Mail, Pass, FechaNacimiento, esAdmin, IntentosFallidos, Bloqueado, Credito) == 1)
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


                            return 200;
                        }

                    }

                    return 500;

                }
                else
                {
                    return 400;
                }
            }
            else
            {
                return 400;
            }

        }
        */

        public int EliminarUsuario(int idUsuario)
        {
            /*
            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);
            UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID);

            if (user != null)
            {
                if(entrada != null)
                {
                    try
                    {
                        foreach (UsuarioFuncion uf in misUsuarioFuncion)
                        {
                            if (uf.idUsuario == user.ID)
                            {
                                if (DevolverEntrada(user, uf.idFuncion, uf.CantidadEntradasCompradas) == 200)
                                {

                                    if (DB.eliminarUsuarioFuncion(idUsuario, true) >= 1)
                                    {
                                        if (DB.eliminarUsuario(idUsuario) == 1)
                                        {
                                            Usuarios.Remove(user);
                                            return 200;
                                        }
                                        else
                                        {
                                            return 500;
                                        }
                                    }
                                    else
                                    {
                                        return 500;
                                    }

                                }
                                else
                                {
                                    return 500;
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 500;
                    }
                }
                else
                {
                    try
                    {
                        if (DB.eliminarUsuario(idUsuario) == 1)
                        {
                            Usuarios.Remove(user);
                            return 200;
                        }
                        else
                        {
                            return 500;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 500;
                    }
                }
              
                return 200;
            }
            else
            {
                return 500;
            }
            */

            Usuario user = contexto.Usuarios.Where(u => u.ID == idUsuario).FirstOrDefault();
            UsuarioFuncion entrada = contexto.UF.Where(uf => uf.idUsuario == idUsuario).FirstOrDefault();

            if (user != null)
            {
                if (entrada != null)
                {
                    try
                    {
                        // Se fija que todas las entradas hayan sido devueltas y procede a eliminar al usuario
                        DevolverEntradasUsuario(user);
                        contexto.Usuarios.Remove(user);
                        contexto.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 500;
                    }
                }
                else
                {
                    try
                    {
                        // En el caso de que no tenga ninguna entrada comprada elimina al usuario directamente
                        contexto.Usuarios.Remove(user);
                        contexto.SaveChanges();
                        return 200;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 500;
                    }
                }
                return 200;
            }
            else
            {
                return 500;
            }
        }

        #endregion

        #region ABM Funcion

        public int AgregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            /*
            try
            {
                // Buscar la sala correspondiente en la lista de salas
                Sala salaElegida = Salas.FirstOrDefault(s => s.ID == MiSalaId);
                int capacidad = salaElegida.Capacidad;

                if (salaElegida != null)
                {
                    // Buscar la película correspondiente en la lista de películas
                    Pelicula peliElegida = Peliculas.FirstOrDefault(p => p.ID == MiPeliculaId);
                    if (peliElegida != null)
                    {
                        // Verificar que el costo sea mayor a 0
                        if (Costo > 0)
                        {

                            int idNuevaFuncion;
                            idNuevaFuncion = DB.agregarFuncion(MiSalaId, MiPeliculaId, Fecha, Costo, capacidad);

                            if (idNuevaFuncion != -1)
                            {
                                // Crear una nueva instancia de Funcion
                                //Funcion func = new Funcion(salaElegida, peliElegida, Fecha, Costo);
                                Funcion func = new Funcion(idNuevaFuncion, Fecha, Costo, MiSalaId, MiPeliculaId, capacidad);

                                // Agregar la función a la lista de funciones
                                Funciones.Add(func);

                                // Agregar la función a la lista de funciones de la sala correspondiente
                                salaElegida.MisFunciones.Add(func);

                                // Agregar la función a la lista de funciones de la película correspondiente
                                peliElegida.MisFunciones.Add(func);

                                func.MiPelicula = peliElegida;
                                func.MiSala = salaElegida;


                                return 200;
                            }
                            else
                            {
                                return 500;
                            }

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
            */

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

            if (func != null)
            {
                // Eliminar la función de la lista de funciones de todos los clientes asociados
                foreach (Usuario user in func.Clientes)
                {

                    //Para cada Usuario en la lista de Clientes le eliminamos dicha funcion y le devolvemos el dinero
                    if (func.Fecha >= DateTime.Now)
                    {
                        user.Credito += func.Costo;
                        // Esta bien esto? creeria que si pero habria que ver
                        contexto.Usuarios.Update(user);
                    }

                    //Habria que ver si el hecho de que borremos una funcion que ya paso esta bien, yo creeria que no pero talvez se genera problemas
                    // a la hora de mostrar las funciones pasadas.
                    user.MisFunciones.Remove(func);
                }

                // Eliminar la función de la lista de funciones
                contexto.Funciones.Remove(func);
                contexto.SaveChanges();
                return 200;
            }
            else
            {
                return 404;
            }
        }

        public int ModificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            // Se elimino cantidad de clientes como parametro porque no deberia estar
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

                                    func.MiSala = salaNueva;
                                    func.MiPelicula = peliculaNueva;

                                    salaNueva.MisFunciones.Add(func);
                                    peliculaNueva.MisFunciones.Add(func);

                                    func.Fecha = Fecha;
                                    func.Costo = Costo;

                                    contexto.Funciones.Update(func);
                                    contexto.SaveChanges();

                                    return 200;
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
                            // Si es la misma sala y película, solo se cambia lo siguiente
                            func.Fecha = Fecha;
                            func.Costo = Costo;

                            contexto.Funciones.Update(func);
                            contexto.SaveChanges();
                            return 200;
                        }


                    }
                    else
                    {
                        throw new ArgumentException("Sala o Pelicula no encontrada.");
                    }

                }
                else
                {
                    throw new ArgumentException("Función no encontrada.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 500;
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

                //int idNuevaSala;
                //idNuevaSala = DB.agregarSala(Capacidad, Ubicacion);
                //if (idNuevaSala != -1)
                //{
                //    // Se crea una nueva sala con los parametros para luego agregarla a la lista de salas
                //    Sala nuevaSala = new Sala(idNuevaSala, Ubicacion, Capacidad);
                //    Salas.Add(nuevaSala);
                //    return 200;
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 500;

        }

        public int EliminarSala(int IDSala)
        {
            Sala sala = contexto.Salas.Where(s => s.ID == IDSala).FirstOrDefault();

            if (sala != null)
            {
                // VER! ESTO NO SE PORQUE ESTABA EN EL CODIGO ANTERIOR PORQUE ME PARECE QUE ES RECONTRA INNECESARIO
                // Si uno elimina la Sala no hace falta vaciar la lista de Funciones en dicha sala porque esta ya no existe
                // Creo que ahi tiene mas sentido con contexto.Funciones.Remove(funcionActual);
                // Agregado, si no existe la Sala se eliminan todas las funciones que se daban ahi

                for (int i = 0; i < sala.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = sala.MisFunciones[i];

                    // Hay que usar funcion actual en vez de remove creo
                    EliminarFuncion(funcionActual.ID);
                    //contexto.Funciones.Remove(funcionActual);

                    //sala.MisFunciones.Remove(funcionActual);
                    funcionActual.MiSala = null;
                }

                contexto.Salas.Remove(sala);
                contexto.SaveChanges();
                return 200;
            }
            else
            {
                return 500;
            }

            /*
            Sala sala = Salas.FirstOrDefault(s => s.ID == IDSala);
            if (DB.eliminarSala(IDSala) == 1)
            {
                // Se busca la sala con el id pasado por parametro
                if (sala != null)
                {
                    // Se eliminan las funciones de la sala antes de eliminar dicha sala
                    for (int i = 0; i < sala.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = sala.MisFunciones[i];
                        sala.MisFunciones.Remove(funcionActual);
                        // funcionActual.MiSala = null;
                    }

                    Salas.Remove(sala);

                    return 200;
                }
                else
                {

                    return 500;
                }
            }
            else
            {
                return 500;
            }
            */

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

            /*
             
            Sala salaElegida = Salas.FirstOrDefault(s => s.ID == IDSala);
            List<Funcion> MisFunciones = salaElegida.MisFunciones;

            if (DB.modificarSala(IDSala, Ubicacion, Capacidad) == 1)
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

                            return 200;
                        }

                    }
                }
            }
            else
            {
                return 500;
            }
            return 422;

            */
        }

        #endregion

        #region ABM Pelicula

        public int AgregarPelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {
            try
            {   //Las verificaciones las hace la vista ahora

                /*
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
                                    Pelicula pelicula = new Pelicula { Nombre = Nombre, Descripcion = Descripcion, Sinopsis = Sinopsis, Poster = Poster, Duracion = Duracion };
                                    contexto.Peliculas.Add(pelicula);
                                    contexto.SaveChanges();
                                    return 200;

                                    //int idNuevaPelicula;
                                    //idNuevaPelicula = DB.agregarPelicula(Nombre, Descripcion, Sinopsis, Poster, Duracion);
                                    //if (idNuevaPelicula != -1)
                                    //{
                                    //    // De ser correctas creamos una nueva pelicula y la agregamos a la lista de peliculas
                                    //    Pelicula NuevaPelicula = new Pelicula(idNuevaPelicula, Nombre, Descripcion, Sinopsis, Poster, Duracion);
                                    //    Peliculas.Add(NuevaPelicula);
                                    //    return 200;
                                    //}
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
                */

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
            }
            return 500;
        }

        public int EliminarPelicula(int IDPelicula)
        {
            // Se busca la pelicula con el id especificado
            Pelicula pelicula = contexto.Peliculas.Where(p => p.ID == IDPelicula).FirstOrDefault();

            if (pelicula != null)
            {
                // Como ya no existe dicha pelicula, se eliminan todas las Funciones que la daban
                for (int i = 0; i < pelicula.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = pelicula.MisFunciones[i];
                    EliminarFuncion(funcionActual.ID);
                    //contexto.Funciones.Remove(funcionActual);
                }
                contexto.Peliculas.Remove(pelicula);
                contexto.SaveChanges();
                return 204;
            }
            else
            {
                return 500;
            }

            /*
            if (DB.eliminarPelicula(IDPelicula) == 1)
            {


                if (peli != null)
                {
                    // En el caso de que exista, se eliminan de las funciones la pelicula especificada antes de remover la pelicula
                    for (int i = 0; i < peli.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = peli.MisFunciones[i];
                        peli.MisFunciones.Remove(funcionActual);
                        //funcionActual.MiPelicula = null;
                    }

                    Peliculas.Remove(peli);

                    return 204;
                }
                else
                {
                    return 500;
                }

            }
            else
            {
                return 500;
            }
            */
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
                    MisFunciones.Add(funcion);
                }

                //pelicula.MisFunciones = MisFunciones;
                contexto.Peliculas.Update(pelicula);
                contexto.SaveChanges();
                return 200;
            }
            return 404;
        }

        /*

        if (DB.modificarPelicula(IDPelicula, Nombre, Descripcion, Sinopsis, Poster, Duracion, IdFunciones) == 1)
        {
            for (int i = 0; i < IdFunciones.Count; i++)
            {
                int.TryParse(IdFunciones[i], out int idFunc);
                Funcion func = MisFunciones.FirstOrDefault(f => f.ID == idFunc);
                MisFunciones.Add(func);
            }

            if (IDPelicula != 0 && Nombre != null && Nombre != "" && Descripcion != null && Descripcion != "" && Sinopsis != null && Sinopsis != "" && Poster != null && Poster != "" && Duracion >= 0)
            {

                for (int i = 0; i < Peliculas.Count; i++)
                {
                    for (int j = 0; j < MisFunciones.Count; j++)
                    {
                        Funcion func = Peliculas[i].MisFunciones.FirstOrDefault(f => f.ID == MisFunciones[j].ID);
                        if (func != null)
                        {
                            Peliculas[i].MisFunciones.Remove(func);
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


                        return 200;
                    }
                }
                return 500;
            }

            return 422;

        }
        else
        {
            return 500;
        }

        */

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

            /*
            foreach (Usuario user in Usuarios)
            {
                // se encuentra el usuario con el id pasado por parametro y se le agrega el credito correspondiente
                if (user.ID == idUsuario)
                {
                    if (importe > 0)
                    {
                        if (DB.cargarCredito(idUsuario, importe) == 1)
                        {
                            user.Credito += importe;
                            return 200;
                        }
                        else
                        {
                            return 500;
                        }

                    }
                    else
                    {
                        return 400;
                    }

                }
            }

            return 500;
            */

        }

        public int ComprarEntrada(int idFuncion, int cantidadEntradas) //CORREGIDO
        {
            try
            {
                // Verificar si el usuario está logueado
                if (UsuarioActual != null)
                {
                    // Buscar la función correspondiente al idFuncion
                    Funcion funcion = contexto.Funciones.Where(f => f.ID == idFuncion).FirstOrDefault();

                    if (funcion != null)
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

                        // PRESTAR ATENCION A ESTO! Puede ser que tire un error porque ahora UF tiene un objeto Usuario y Funcion, tal vez hay
                        // que cambiar los constructores y pasarlo por aca. Tal vez se solucione con como esta hecho contexto no tengo idea ]
                        // habria que probar
                        entrada = new UsuarioFuncion(user.ID, funcion.ID, 0);
                        entrada.CantidadEntradasCompradas += cantidadEntradas;
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

        /*
        public int ComprarEntradaFuncionNotNull(Usuario user, int cantidadEntradas, Funcion funcion)
        {   
            // CAMBIE LA FIRMA DEL METODO PORQUE ES INNECESARIO PASARLE COMO PARAMETRO UNA FUNCION Y UN ID DE FUNCION

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

                    // Actualizar la cantidad de clientes de la lista de funcion del cine
                    funcion.CantidadClientes += cantidadEntradas;
                    funcion.AsientosDisponibles -= cantidadEntradas;

                    if (fun == null)
                    {
                        user.MisFunciones.Add(funcion);
                    }
                    else
                    {
                        // Actualizar la cantidad de clientes de la lista de funcion del cliente
                        fun.CantidadClientes += cantidadEntradas;
                        fun.AsientosDisponibles -= cantidadEntradas;
                    }

                    // Actualizar el crédito del usuario
                    user.Credito -= costoTotal;

                    if (entrada != null)
                    {   //Entra aca si el usuario ya tiene al menos 1 entrada para dicha funcion
                        entrada.CantidadEntradasCompradas += cantidadEntradas;
                        DB.sumarEntrada(idFuncion, user.ID, entrada.CantidadEntradasCompradas);
                    }
                    else
                    {   //Entra aca si el usuario nunca compro para esta funcion

                        // Agregar al usuario como cliente de la función
                        funcion.Clientes.Add(user);
                        entrada = new UsuarioFuncion(user.ID, idFuncion, 0);
                        entrada.CantidadEntradasCompradas += cantidadEntradas;
                        misUsuarioFuncion.Add(entrada);
                        DB.cargarEntradas(idFuncion, user.ID, cantidadEntradas);
                    }

                    DB.actualizarAsientosDisponibles(idFuncion, funcion.AsientosDisponibles);
                    DB.actualizarCreditoUsuario(user.ID, user.Credito);

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
            int result = 0;

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

        /*
        private bool DevolverEntradaFuncionNotNull(Usuario user, int idFuncion, int cantidadEntradas)
        {
            Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion);

            if (funcion.Fecha > DateTime.Now)
            {
                UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion);

                if (entrada != null)
                {
                    if (entrada.CantidadEntradasCompradas >= cantidadEntradas)
                    {
                        Funcion userFunc = user.MisFunciones.FirstOrDefault(f => f.ID == idFuncion);
                        if (entrada.CantidadEntradasCompradas == cantidadEntradas)
                        {
                            user.MisFunciones.Remove(userFunc);
                            userFunc.Clientes.Remove(user);
                            funcion.Clientes.Remove(user);
                        }
                        else
                        {
                            userFunc.CantidadClientes -= cantidadEntradas;
                            userFunc.AsientosDisponibles += cantidadEntradas;
                        }
                        funcion.CantidadClientes -= cantidadEntradas;
                        funcion.AsientosDisponibles += cantidadEntradas;
                        entrada.CantidadEntradasCompradas -= cantidadEntradas;

                        double costoTotal = funcion.Costo * cantidadEntradas;
                        user.Credito += costoTotal;

                        if (entrada.CantidadEntradasCompradas <= 0)
                        {
                            DB.devolverEntrada(idFuncion, user.ID);
                            misUsuarioFuncion.Remove(entrada);
                        }
                        else
                        {
                            DB.devolverEntradaMayorCero(idFuncion, user.ID, entrada.CantidadEntradasCompradas);

                        }

                        DB.actualizarCreditoUsuario(user.ID, user.Credito);
                        DB.actualizarAsientosDisponibles(idFuncion, funcion.AsientosDisponibles);


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
            else
            {
                return false;
            }

        }
        */

        public int IniciarSesion(string Mail, string Password) // Aplicado
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

        public List<Usuario> MostrarUsuarios()
        {
            Usuarios.Clear();
            Usuarios = DB.inicializarUsuarios();
            return Usuarios.ToList();
        }

        public List<Funcion> MostrarFunciones()
        {
            Funciones.Clear();
            Funciones = DB.inicializarFunciones();
            return Funciones.ToList();
        }

        public List<Sala> MostrarSalas()
        {
            Salas.Clear();
            Salas = DB.inicializarSalas();
            return Salas.ToList();

        }

        public List<Pelicula> MostrarPeliculas()
        {
            Peliculas.Clear();
            Peliculas = DB.inicializarPeliculas();
            return Peliculas.ToList();
        }

        */

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
                foreach (Funcion fun in contexto.Funciones)
                {

                    if (fun.Fecha >= DateTime.Today)
                    {
                        funcionesEncontradas = contexto.Funciones.Where(fun =>
                            (!string.IsNullOrWhiteSpace(pelicula) && fun.MiPelicula.Nombre.Contains(pelicula))
                            || (!string.IsNullOrWhiteSpace(ubicacion) && fun.MiSala.Ubicacion.Equals(ubicacion))
                            && (precioMinimo >= 0 && fun.Costo >= precioMinimo)
                            && (precioMaximo > 0 && fun.Costo <= precioMaximo)).ToList();

                    }
                }
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







