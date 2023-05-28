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

        public int AgregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, float credito, bool bloqueado)
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

        }

        public int ModificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito)
        {

            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);
            List<Funcion> MisFunciones = user.ObtenerMisFunciones();

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

        public int EliminarUsuario(int idUsuario)
        {
            Usuario user = Usuarios.FirstOrDefault(u => u.ID == idUsuario);

            if (user != null)
            {
                try
                {
                    foreach (UsuarioFuncion uf in misUsuarioFuncion)
                    {
                        if (uf.idUsuario == user.ID)
                        {
                            if (DevolverEntrada(user, uf.idFuncion, uf.CantidadEntradasCompradas) == 200)
                            {

                                if (DB.eliminarUsuarioFuncion(idUsuario) >= 1)
                                {
                                    if (DB.eliminarUsuario(idUsuario) == 1)
                                    {
                                        Usuarios.Remove(user);
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
                return 200;
            }
            else
            {
                return 500;
            }

            #region  METODO VIEJO ELIMINAR

            /*
            if (DB.eliminarUsuarioFuncion(idUsuario) >= 1)
            {
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
                                    DevolverEntrada(user, funcionActual.ID, cantidadEntradasSeleccionadas);
                                    if (DB.devolverEntrada(funcionActual.ID, user.ID) == 1)
                                    {
                                        DevolverEntrada(user, funcionActual.ID, cantidadEntradasSeleccionadas);
                                    }

                                    // Aca hay una condicion que se fija si devuelve todas las entradas antes de eliminar al usuario
                                    funcionActual.Clientes.Remove(user);
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
            }
            else
            {
                return 500;
            }

           

            

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
            #endregion

        }

        #endregion

        #region ABM Funcion
        public int AgregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {

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

        }

        public int EliminarFuncion(int IDFuncion)
        {
            // Buscar la función con el ID correspondiente en la lista de funciones
            Funcion func = Funciones.FirstOrDefault(f => f.ID == IDFuncion);

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
                                user.MisFunciones.Remove(user.ObtenerMisFunciones()[j]);
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
                            peli.MisFunciones.Remove(peli.ObtenerMisFunciones()[i]);
                            break;
                        }
                    }

                    Sala sala = func.MiSala;

                    for (int i = 0; i < sala.ObtenerMisFunciones().Count; i++)
                    {
                        if (sala.ObtenerMisFunciones()[i].ID == IDFuncion)
                        {
                            sala.MisFunciones.Remove(sala.ObtenerMisFunciones()[i]);
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
  
        }

        public int ModificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo, int capacidad)
        {
            try
            {

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

                                        func.MiSala.MisFunciones.Remove(func);
                                        func.MiPelicula.MisFunciones.Remove(func);

                                        func.MiSala = salaElegida;
                                        func.MiPelicula = peliElegida;

                                        func.Fecha = Fecha;
                                        func.Costo = Costo;

                                        func.MiSala.MisFunciones.Add(func);
                                        func.MiPelicula.MisFunciones.Add(func);

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
                            Sala nuevaSala = new Sala(idNuevaSala, Ubicacion, Capacidad);
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

        }

        public int EliminarSala(int IDSala)
        {

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

        }

        public int ModificarSala(int IDSala, string Ubicacion, int Capacidad)
        {

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
                                        Pelicula NuevaPelicula = new Pelicula(idNuevaPelicula, Nombre, Descripcion, Sinopsis, Poster, Duracion);
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
            return funcionesEncontradas;
        }

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
                        user.MisFunciones.Remove(funcion);
                        funcion.CantidadClientes -= cantidadEntradas;
                        funcion.AsientosDisponibles += cantidadEntradas;
                        funcion.Clientes.Remove(user);
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

        }

        public int ComprarEntradaFuncionNotNull(Usuario user, int cantidadEntradas, Funcion funcion, int idFuncion)
        {

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
            else
            {
                return 500;
            }

        }

        public bool esAdmin()
        {
            return UsuarioActual.EsAdmin;
        }


        #endregion




    }

}







