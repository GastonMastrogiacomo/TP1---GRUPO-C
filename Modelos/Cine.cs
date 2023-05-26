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

namespace TP1___GRUPO_C.Model
{
    public class Cine
    {
        // Ver de poner esto en private ya que solo cine tiene que tener acceso
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

            //misUsuarioFuncion = new List<UsuarioFuncion>();
            DB = new DAL();
            inicializarAtributos();

            /*
            #region Datos Hardcodeados para pruebas

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

            Funcion funcion1 = new Funcion(sala1, toyStory, fecha, 10);
            Funciones.Add(funcion1);
            toyStory.AgregarFuncion(funcion1);
            sala1.AgregarFuncion(funcion1);
            comun.AgregarFuncion(funcion1);
            funcion1.AgregarCliente(comun);
            funcion1.AsientosDisponibles -= 1;
            funcion1.CantidadClientes += 1;

            Funcion funcion2 = new Funcion(sala1, marioBros, fecha, 15);
            Funciones.Add(funcion2);
            marioBros.AgregarFuncion(funcion2);
            sala1.AgregarFuncion(funcion2);
            comun.AgregarFuncion(funcion2);
            funcion2.AgregarCliente(comun);
            funcion2.AsientosDisponibles -= 1;
            funcion2.CantidadClientes += 1;


            Funcion funcion3 = new Funcion(sala2, marioBros, fecha, 20);
            Funciones.Add(funcion3);
            marioBros.AgregarFuncion(funcion3);
            sala2.AgregarFuncion(funcion3);

            Funcion funcion4 = new Funcion(sala2, marioBros, fecha2, 256);
            Funciones.Add(funcion4);
            marioBros.AgregarFuncion(funcion4);
            sala2.AgregarFuncion(funcion4);
            comun.AgregarFuncion(funcion4);
            funcion4.AgregarCliente(comun);
            funcion4.AsientosDisponibles -= 1;
            funcion4.CantidadClientes += 1;

            Funcion funcion5 = new Funcion(sala1, mario2, fecha2, 1500);
            Funciones.Add(funcion5);
            mario2.AgregarFuncion(funcion5);
            sala1.AgregarFuncion(funcion5);

            #endregion
            */
        }


        private void inicializarAtributos()
        {

            Usuarios = DB.inicializarUsuarios();
            Funciones = DB.inicializarFunciones();
            Salas = DB.inicializarSalas();
            Peliculas = DB.iniicalizarPeliculas();
            misUsuarioFuncion = DB.inicializarUsuarioFuncion();

            //SI FUESE MANY TO MANY
            //Esto depende de como creamos la base de datos, verificar que la logica esta bien

            //  Ejemplos de como tenemos que hacer las vinculaciones entre foreign keys para que se inicializen correctamente

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


        #region ABM Usuario

        //IMPLEMENTADO CON DB
        public int AgregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, int credito,bool bloqueado)
        {
            bool flagDni = false;

            #region Metodo Agregar Usuario con BD

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
                                            MessageBox.Show("El DNI Ingresado ya se encuentra dentro del sistema");
                                        }
                                    }

                                    // Si el DNI y el correo no están registrados, crear un nuevo usuario y agregarlo a la lista de usuarios
                                    if (!flagDni)
                                    {
                                        int idNuevoUsuario;
                                      
                                        idNuevoUsuario = DB.agregarUsuario(DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin, credito, false);

                                        if (idNuevoUsuario != -1)
                                        {
                                            Usuario otro = new Usuario(idNuevoUsuario, DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin);
                                            otro.Credito = credito;
                                            Usuarios.Add(otro);
                                            return 201;
                                        }

                                    }
                                    return 500;

                                }
                                else
                                {
                                    throw new InvalidOperationException("Password incorrecta");


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
                return 422;

            }


            #endregion

            /* Codigo Viejo
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
                                            MessageBox.Show("El DNI Ingresado ya se encuentra dentro del sistema");
                                        }
                                    }

                                    // Si el DNI y el correo no están registrados, crear un nuevo usuario y agregarlo a la lista de usuarios
                                    if (!flagDni)
                                    {

                                        Usuario otro = new Usuario(DNI, Nombre, Apellido, Mail, Password, FechaNacimiento, EsAdmin);
                                        otro.Credito = credito;
                                        Usuarios.Add(otro);
                                        return 201;

                                    }
                                    return 500;

                                }
                                else
                                {
                                    throw new InvalidOperationException("Password incorrecta");


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
                return 422;

            }
            */

        }

        //IMPLEMENTADO CON DB
        public int ModificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito)
        {
            #region Modificar Usuario con BD 


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


            #endregion


            /* Codigo Viejo

            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);
            List<Funcion> MisFunciones = user.MisFunciones;

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

            */
        }

        //IMPLEMENTADO CON DB
        public int EliminarUsuario(int idUsuario)
        {
            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);

            #region Metodo nuevo eliminar con DB implementado

            if (DB.eliminarUsuario(idUsuario) == 1)
            {

                if (user != null)
                {
                    try
                    {
                        // Se eliminan todas las funciones del cliente antes de eliminarlo completamente
                        // ESTO HAY QUE VER PORQUE ME PARECE QUE CON DB SI PONES ON DELETE CASCADE TE LO SOLUCIONA
                        for (int i = 0; i < user.MisFunciones.Count; i++)
                        {
                            Funcion funcionActual = user.MisFunciones[i];


                            if (funcionActual != null)

                            {
                                int cantidadEntradasSeleccionadas = user.EntradasCompradas[funcionActual.ID];
                                DevolverEntrada(user, funcionActual.ID, cantidadEntradasSeleccionadas);

                                // Aca hay una condicion que se fija si devuelve todas las entradas antes de eliminar al usuario
                                funcionActual.EliminarCliente(idUsuario);
                            }




                        }

                        Usuarios.Remove(user);

                        return 200;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
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

            #endregion

            /*
            if (user != null)
            {
                try
                {
                    // Se eliminan todas las funciones del cliente antes de eliminarlo completamente
                    // ESTO HAY QUE VER PORQUE ME PARECE QUE CON DB SI PONES ON DELETE CASCADE TE LO SOLUCIONA
                    for (int i = 0; i < user.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = user.MisFunciones[i];


                        if (funcionActual != null)

                        {
                            int cantidadEntradasSeleccionadas = user.EntradasCompradas[funcionActual.ID];
                            DevolverEntrada(user, funcionActual.ID, cantidadEntradasSeleccionadas);

                            // Aca hay una condicion que se fija si devuelve todas las entradas antes de eliminar al usuario
                            funcionActual.EliminarCliente(idUsuario);
                        }




                    }

                    Usuarios.Remove(user);

                    return 200;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                    return 500;
                }
            }
            else
            {
                return 500;
            }

            */

        }

        #endregion

        #region ABM Funcion
        public int AgregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            #region AgregarFuncion con DB

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
                                Funcion func = new Funcion(salaElegida, peliElegida, Fecha, Costo);

                                // Agregar la función a la lista de funciones
                                Funciones.Add(func);

                                // Agregar la función a la lista de funciones de la sala correspondiente
                                salaElegida.AgregarFuncion(func);

                                // Agregar la función a la lista de funciones de la película correspondiente
                                peliElegida.AgregarFuncion(func);

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

            #endregion

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

                            // Crear una nueva instancia de Funcion
                            Funcion func = new Funcion(salaElegida, peliElegida, Fecha, Costo);

                            // Agregar la función a la lista de funciones
                            Funciones.Add(func);

                            // Agregar la función a la lista de funciones de la sala correspondiente
                            salaElegida.AgregarFuncion(func);

                            // Agregar la función a la lista de funciones de la película correspondiente
                            peliElegida.AgregarFuncion(func);

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
            */
        }

        public int EliminarFuncion(int IDFuncion)

        {

            // Buscar la función con el ID correspondiente en la lista de funciones
            Funcion func = Funciones.FirstOrDefault(f => f.ID == IDFuncion);

            #region Eliminar Usuario con DB

            if (DB.eliminarFuncion(IDFuncion) == 1)
            {
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


                    Pelicula peli = func.MiPelicula;

                    for (int i = 0; i < peli.ObtenerMisFunciones().Count; i++)
                    {
                        if (peli.ObtenerMisFunciones()[i].ID == IDFuncion)
                        {
                            peli.EliminarFuncion(peli.ObtenerMisFunciones()[i].ID);
                            break;
                        }
                    }

                    Sala sala = func.MiSala;

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


                    return 200;
                }
                else
                {

                    return 404;

                }
            }
            else
            {
                return 500;
            }


            #endregion

            /*
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


                Pelicula peli = func.MiPelicula;

                for (int i = 0; i < peli.ObtenerMisFunciones().Count; i++)
                {
                    if (peli.ObtenerMisFunciones()[i].ID == IDFuncion)
                    {
                        peli.EliminarFuncion(peli.ObtenerMisFunciones()[i].ID);
                        break;
                    }
                }

                Sala sala = func.MiSala;

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


                return 200;
            }
            else
            {

                return 404;

            }
            */

        }

        public int ModificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo, int capacidad)
        {
            try
            {
                #region ModificarFuncion con DB

                Funcion func = Funciones.FirstOrDefault(f => f.ID == IDFuncion);

                if (DB.modificarFuncion(IDFuncion, MiSalaId, MiPeliculaId, Fecha, Costo, capacidad) == 1)
                {

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
                                    if (func.CantidadClientes >= 0 && Costo > 0 && func.Clientes != null)
                                    {

                                        func.MiSala.EliminarFuncion(func.ID);
                                        func.MiPelicula.EliminarFuncion(func.ID);

                                        func.MiSala = salaElegida;
                                        func.MiPelicula = peliElegida;

                                        func.Fecha = Fecha;

                                        func.Costo = Costo;

                                        func.MiSala.AgregarFuncion(func);
                                        func.MiPelicula.AgregarFuncion(func);


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

                }
                else
                {
                    return 500;
                }

                #endregion

                /* Codigo viejo
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
                                if (func.CantidadClientes >= 0 && Costo > 0 && func.Clientes != null)
                                {

                                    func.MiSala.EliminarFuncion(func.ID);
                                    func.MiPelicula.EliminarFuncion(func.ID);

                                    func.MiSala = salaElegida;
                                    func.MiPelicula = peliElegida;

                                    func.Fecha = Fecha;

                                    func.Costo = Costo;

                                    func.MiSala.AgregarFuncion(func);
                                    func.MiPelicula.AgregarFuncion(func);


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
                */
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
            #region Metodo Agregar Sala con DB

            try
            {
                // Verificamos que la capacidad sea valida
                if (Capacidad >= 0)
                {
                    // Verificamos que la ubicacion se a valida
                    if (Ubicacion != null && Ubicacion != "")
                    {

                        int idNuevaSala;
                        idNuevaSala = DB.agregarSala(Capacidad, Ubicacion);

                        if (idNuevaSala != -1)
                        {
                            // Se crea una nueva sala con los parametros para luego agregarla a la lista de salas
                            Sala nuevaSala = new Sala(Ubicacion, Capacidad);
                            Salas.Add(nuevaSala);
                            return 200;

                        }



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
                Console.WriteLine(e.Message);
            }
            return 500;

            #endregion


            /* Codigo Viejo
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
                        return 200;
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
                Console.WriteLine(e.Message);
            }
            return 500;
            */
        }

        public int EliminarSala(int IDSala)
        {
            #region EliminarSala con BD

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
                        sala.EliminarFuncion(funcionActual.ID);
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



            #endregion

            /* Codigo Viejo
             
            // Se busca la sala con el id pasado por parametro
            Sala sala = Salas.FirstOrDefault(s => s.ID == IDSala);

            if (sala != null)
            {
                // Se eliminan las funciones de la sala antes de eliminar dicha sala
                for (int i = 0; i < sala.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = sala.MisFunciones[i];
                    sala.EliminarFuncion(funcionActual.ID);
                    // funcionActual.MiSala = null;
                }

                Salas.Remove(sala);

                return 200;
            }
            else
            {

                return 500;
            }

            */
        }

        public int ModificarSala(int IDSala, string Ubicacion, int Capacidad)
        {

            #region Metodo ModificarSala con BD

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

            #endregion


            /*
            Sala salaElegida = Salas.FirstOrDefault(s => s.ID == IDSala);

            List<Funcion> MisFunciones = salaElegida.MisFunciones;
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
            return 422;
            */
        }

        #endregion

        #region ABM Pelicula
        public int AgregarPelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {

            #region AgregarPelicula con DB

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
                                    int idNuevaPelicula;
                                    idNuevaPelicula = DB.agregarPelicula(Nombre, Descripcion, Sinopsis, Poster, Duracion);
                                    if (idNuevaPelicula != -1)
                                    {
                                        // De ser correctas creamos una nueva pelicula y la agregamos a la lista de peliculas
                                        Pelicula NuevaPelicula = new Pelicula(Nombre, Descripcion, Sinopsis, Poster, Duracion);
                                        Peliculas.Add(NuevaPelicula);
                                        return 200;
                                    }
                                    else
                                    {
                                        return 500;
                                    }

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
                Console.WriteLine(e.Message);
            }
            return 500;

            #endregion

            /* Codigo Viejo
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


                                    return 200;
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
                Console.WriteLine(e.Message);
            }
            return 500;
            */
        }

        public int EliminarPelicula(int IDPelicula)
        {
            #region EliminarPelicula con DB

            // Se busca la pelicula con el id especificado
            Pelicula peli = Peliculas.FirstOrDefault(p => p.ID == IDPelicula);

            if (DB.eliminarPelicula(IDPelicula) == 1)
            {


                if (peli != null)
                {
                    // En el caso de que exista, se eliminan de las funciones la pelicula especificada antes de remover la pelicula
                    for (int i = 0; i < peli.MisFunciones.Count; i++)
                    {
                        Funcion funcionActual = peli.MisFunciones[i];
                        peli.EliminarFuncion(funcionActual.ID);
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

            #endregion


            /* Codigo Viejo
             
            // Se busca la pelicula con el id especificado
            Pelicula peli = Peliculas.FirstOrDefault(p => p.ID == IDPelicula);

            if (peli != null)
            {
                // En el caso de que exista, se eliminan de las funciones la pelicula especificada antes de remover la pelicula
                for (int i = 0; i < peli.MisFunciones.Count; i++)
                {
                    Funcion funcionActual = peli.MisFunciones[i];
                    peli.EliminarFuncion(funcionActual.ID);
                    //funcionActual.MiPelicula = null;
                }

                Peliculas.Remove(peli);

                return 204;
            }
            else
            {
                return 500;
            }
            */
        }

        public int ModificarPelicula(int IDPelicula, string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, List<string> IdFunciones)
        {

            #region ModificarPelicula DB

            List<Funcion> MisFunciones = new List<Funcion>();

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

            #endregion

            /* Codigo Viejo
            List<Funcion> MisFunciones = new List<Funcion>();

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


                        return 200;
                    }
                }
                return 500;
            }

            return 422;
            */

        }

        #endregion

        #region Metodos
        public int CargarCredito(int idUsuario, double importe)
        {

            #region CargarCredito con DB

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

            #endregion


            /* Codigo Viejo 
             
            foreach (Usuario user in Usuarios)
            {
                // se encuentra el usuario con el id pasado por parametro y se le agrega el credito correspondiente
                if (user.ID == idUsuario)
                {
                    if (importe > 0)
                    {   
                        user.Credito += importe;
                        return 200;
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

        public int ComprarEntrada(Usuario UsuarioActual, int idFuncion, int cantidadEntradas)
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
                        ComprarEntradaFuncionNotNull(UsuarioActual, cantidadEntradas, funcion, idFuncion);
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

        public int DevolverEntrada(Usuario user, int idFuncion, int cantidadEntradas)
        {
            try
            {
                Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion);

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

        public int IniciarSesion(string Mail, string Password)
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
                                /* ARREGLAR
                                if (user.EsAdmin == esAdmin)
                                {
                                    // Se establece el usuario como usuario actual
                                    UsuarioActual = user;
                                    user.IntentosFallidos = 0;
                                    return 200;

                                }
                                else
                                {
                                    // el usuario seleccion "administrador" sin serlo
                                    // o el administrador no puso el checkbox
                                    throw new InvalidOperationException("Has seleccionado una opción incorrecta.");
                                }
                                */


                                UsuarioActual = user;
                                user.IntentosFallidos = 0;
                                DB.modificarIntentosFallidos(user.ID, user.IntentosFallidos);
                                return 200;

                            }
                            else if (user.IntentosFallidos < 3)
                            {
                                user.IntentosFallidos += 1;
                                DB.modificarIntentosFallidos(user.ID, user.IntentosFallidos);
                                MessageBox.Show("tiene que sumar +1");
                                return 401;

                            }
                            else
                            {
                                DB.bloquearUsuario(user.ID);
                                user.Bloqueado = true;

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
            //else
            //{

            //    MessageBox.Show("No se puede filtar por una fecha anterior a hoy.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            return funcionesEncontradas;

        }

        private bool DevolverEntradaFuncionNotNull(Usuario user, int idFuncion, int cantidadEntradas)
        {
            Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion);

            #region DevolverEntrada con DB


            if (funcion.Fecha > DateTime.Now)
            {
                UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion);

                if (entrada != null)
                {
                    if (entrada.CantidadEntradasCompradas >= cantidadEntradas)
                    {
                        user.MisFunciones.Remove(funcion);
                        funcion.CantidadClientes -= cantidadEntradas;
                        funcion.AsientosDisponibles += cantidadEntradas;
                        funcion.EliminarCliente(user.ID);
                        entrada.CantidadEntradasCompradas -= cantidadEntradas;

                        double costoTotal = funcion.Costo * cantidadEntradas;
                        user.Credito += costoTotal;

                        if (entrada.CantidadEntradasCompradas <= 0)
                        {
                            DB.devolverEntrada(idFuncion, user.ID);
                        }else
                        {
                            DB.devolverEntradaMayorCero(idFuncion, user.ID, entrada.CantidadEntradasCompradas);
                        }

                        DB.actualizarCreditoUsuario(user.ID, user.Credito);
                        DB.actualizarAsientosDisponibles(idFuncion, cantidadEntradas);


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

            #endregion

            /* Codigo Viejo
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
            */
        }

        public int ComprarEntradaFuncionNotNull(Usuario user, int cantidadEntradas, Funcion funcion, int idFuncion)
        {
            #region ComprarEntrada con DB INCOMPLETO
            
            UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion);

            // Verificar si la cantidad de entradas es mayor a cero
            if (cantidadEntradas > 0)
            {
                double costoTotal = funcion.Costo * cantidadEntradas;

                // Verificar si el usuario tiene suficiente crédito
                if (user.Credito >= costoTotal)
                {
                    // Verificar si la capacidad de la sala es suficiente
                    if (funcion.AsientosDisponibles >= cantidadEntradas)
                    {
                        // Agregar la función a las funciones del usuario
                        user.MisFunciones.Add(funcion);

                        // Actualizar la cantidad de clientes de la función
                        funcion.CantidadClientes += cantidadEntradas;

                        funcion.AsientosDisponibles -= cantidadEntradas;

                        // Agregar al usuario como cliente de la función
                        funcion.AgregarCliente(user);

                        // Actualizar el crédito del usuario
                        user.Credito -= costoTotal;

                        entrada.CantidadEntradasCompradas += cantidadEntradas;
                        //DB.actualizarAsientosDisponibles();
                        //DB.actualizarCreditoUsuario();
                        //AGREGAR: Antes de hacer esto tengo que meter un insert a la tabla UsuariosFunciones, porque 
                        // no puedo modificar estas cosas si el registro no existe.

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
            else
            {
                return 500;
            }
            
            #endregion


            /* Codigo Viejo
             
            // Verificar si la cantidad de entradas es mayor a cero
            if (cantidadEntradas > 0)
            {
                double costoTotal = funcion.Costo * cantidadEntradas;

                // Verificar si el usuario tiene suficiente crédito
                if (user.Credito >= costoTotal)
                {
                    // Verificar si la capacidad de la sala es suficiente
                    if (funcion.AsientosDisponibles >= cantidadEntradas)
                    {
                        // Agregar la función a las funciones del usuario
                        user.MisFunciones.Add(funcion);

                        // Actualizar la cantidad de clientes de la función
                        funcion.CantidadClientes += cantidadEntradas;

                        funcion.AsientosDisponibles -= cantidadEntradas;

                        // Agregar al usuario como cliente de la función
                        funcion.AgregarCliente(user);

                        // Actualizar el crédito del usuario
                        user.Credito -= costoTotal;


                        // Actualizar las entradas compradas por el usuario
                        if (user.EntradasCompradas.ContainsKey(idFuncion))
                        {
                            user.EntradasCompradas[idFuncion] += cantidadEntradas;
                        }
                        else
                        {
                            user.EntradasCompradas.Add(idFuncion, cantidadEntradas);
                        }
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
            else
            {
                return 500;
            }
            */
        }

        #endregion

        public bool esAdmin ()
        {
            return UsuarioActual.EsAdmin;
        }


    }

}







