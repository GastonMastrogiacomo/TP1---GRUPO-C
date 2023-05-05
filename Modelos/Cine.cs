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

            Funcion funcion1 = new Funcion(sala1, toyStory, fecha, 0, 10);
            Funciones.Add(funcion1);
            toyStory.AgregarFuncion(funcion1);
            sala1.AgregarFuncion(funcion1);
            comun.AgregarFuncion(funcion1);
            funcion1.AgregarCliente(comun);

            Funcion funcion2 = new Funcion(sala1, marioBros, fecha, 0, 15);
            Funciones.Add(funcion2);
            marioBros.AgregarFuncion(funcion2);
            sala1.AgregarFuncion(funcion2);
            comun.AgregarFuncion(funcion2);
            funcion2.AgregarCliente(comun);

            Funcion funcion3 = new Funcion(sala2, marioBros, fecha, 0, 15);
            Funciones.Add(funcion3);
            marioBros.AgregarFuncion(funcion3);
            sala2.AgregarFuncion(funcion3);

            Funcion funcion4 = new Funcion(sala2, marioBros, fecha2, 0, 15);
            Funciones.Add(funcion4);
            marioBros.AgregarFuncion(funcion4);
            sala2.AgregarFuncion(funcion4);
            comun.AgregarFuncion(funcion4);
            funcion4.AgregarCliente(comun);


        }

        //ABM Usuario

        public bool AgregarUsuario(Usuario user)
        {
            bool flagDni = false;


            try
            {

                if (user.DNI != 0)
                {
                    if (user.Nombre != null && user.Nombre != "")
                    {
                        if (user.Apellido != null && user.Apellido != "")
                        {
                            if (user.Mail != null && user.Mail != "")
                            {
                                if (user.Password != null && user.Password != "")
                                {


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
        public bool ModificarUsuario(int idUsuario, Usuario user)
        {
            if (user.DNI != 0 && user.Nombre != null && user.Nombre != "" && user.Apellido != null && user.Apellido != "" && user.Mail != null && user.Mail != "" && user.Password != null && user.Password != "")
            {
                for (int i = 0; i < Usuarios.Count; i++)
                {
                    if (Usuarios[i].ID == idUsuario)
                    {


                        Usuarios[i].Nombre = user.Nombre;
                        Usuarios[i].Apellido = user.Apellido;
                        Usuarios[i].Mail = user.Mail;
                        Usuarios[i].DNI = user.DNI;
                        Usuarios[i].Password = user.Password;
                        Usuarios[i].IntentosFallidos = user.IntentosFallidos;
                        Usuarios[i].Bloqueado = user.Bloqueado;
                        Usuarios[i].MisFunciones = user.MisFunciones;
                        //Usuarios[i].Credito = user.Credito;
                        Usuarios[i].FechaNacimiento = user.FechaNacimiento;
                        Usuarios[i].EsAdmin = user.EsAdmin;
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
                    Funciones[i].MiSala = funcion.MiSala;
                    Funciones[i].MiPelicula = funcion.MiPelicula;
                    Funciones[i].Clientes = funcion.Clientes;
                    Funciones[i].Fecha = funcion.Fecha;
                    Funciones[i].CantidadClientes = funcion.CantidadClientes;
                    Funciones[i].Costo = funcion.Costo;

                    return true;
                }
            }
            return false;
        }

        //ABM Sala 
        public bool AgregarSala(Sala sala)
        {
            try
            {
                if (sala.ID != null && sala.ID != 0)
                {
                    if (sala.Capacidad != null && sala.Capacidad >= 0)
                    {
                        if (sala.Ubicacion != null && sala.Ubicacion != "")
                        {
                            Sala nuevaSala = new Sala(sala.Ubicacion, sala.Capacidad);
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
        public bool EliminarSala(int IDSala)
        {
            foreach (Sala sal in Salas)
            {

                if (sal.ID == IDSala)
                {
                    Salas.Remove(sal);
                    MessageBox.Show("La Sala fue eliminada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

            }
            return false;
            MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool ModificarSala(int IDSala, Sala sala)
        {
            if (sala.ID != null && sala.ID != 0 && sala.Capacidad != null && sala.Capacidad >= 0 && sala.Ubicacion != null && sala.Ubicacion != "")
            {

                for (int i = 0; i < Salas.Count; i++)
                {
                    if (Salas[i].ID == IDSala)
                    {

                        Salas[i].Capacidad = sala.Capacidad;
                        Salas[i].Ubicacion = sala.Ubicacion;
                        Salas[i].MisFunciones = sala.MisFunciones;
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
        public bool AgregarPelicula(Pelicula pelicula)
        {
            try
            {

                if (pelicula.ID != null && pelicula.ID != 0)
                {
                    if (pelicula.Nombre != null && pelicula.Nombre != "")
                    {

                        if (pelicula.Descripcion != null && pelicula.Descripcion != "")
                        {
                            if (pelicula.Sinopsis != null && pelicula.Sinopsis != "")
                            {
                                if (pelicula.Poster != null && pelicula.Poster != "")
                                {

                                    if (pelicula.Duracion != null && pelicula.Duracion >= 0)
                                    {

                                        Pelicula NuevaPelicula = new Pelicula(pelicula.Nombre, pelicula.Descripcion, pelicula.Sinopsis, pelicula.Poster, pelicula.Duracion);
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
                else
                {
                    throw new InvalidOperationException("ID Incorrecto");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public bool EliminarPelicula(int IDPelicula)
        {
            foreach (Pelicula pel in Peliculas)
            {
                if (pel.ID == IDPelicula)
                {
                    Peliculas.Remove(pel);
                    MessageBox.Show("La Pelicula fue eliminada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                }
            }
            return false;
            MessageBox.Show("Error, intentelo nuevamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool ModificarPelicula(int IDPelicula, Pelicula pelicula)
        {

            if (pelicula.ID != null && pelicula.ID != 0 && pelicula.Nombre != null && pelicula.Nombre != "" && pelicula.Descripcion != null && pelicula.Descripcion != "" && pelicula.Sinopsis != null && pelicula.Sinopsis != "" && pelicula.Poster != null && pelicula.Poster != "" && pelicula.Duracion != null && pelicula.Duracion >= 0)
            {
                for (int i = 0; i < Peliculas.Count; i++)
                {
                    if (Peliculas[i].ID == IDPelicula)
                    {
                        Peliculas[i].Nombre = pelicula.Nombre;
                        Peliculas[i].Descripcion = pelicula.Descripcion;
                        Peliculas[i].Sinopsis = pelicula.Sinopsis;
                        Peliculas[i].Poster = pelicula.Poster;
                        Peliculas[i].Duracion = pelicula.Duracion;

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
        public bool ComprarEntrada(int IDFuncion, int CantidadEntradas)
        {
            try
            {
                //bool FuncionExiste = false;

                //IDFuncion++;
                if(UsuarioActual != null)
                {

                   
                for(int i = 0; i < Funciones.Count; i++)
                {
                        if (Funciones[i].ID == IDFuncion)
                        {
                            MessageBox.Show("credito x aca: " + UsuarioActual.Credito);
                            MessageBox.Show("costo x aca: " + Funciones[i].Costo);
                        }
                }

                }
                if (UsuarioActual != null)
                {
                    foreach (Funcion fun in Funciones)
                    {

                        if (fun.ID == IDFuncion)

                        {
                            MessageBox.Show("estoy aca con el Id match");
                            if (CantidadEntradas > 0)
                            {

                                MessageBox.Show("credito x aca: " + UsuarioActual.Credito);
                                MessageBox.Show("costo x aca: " + fun.Costo);

                                double valorReal = fun.Costo * CantidadEntradas;
                                //FuncionExiste = true;
                                if (UsuarioActual.Credito >= fun.Costo)
                                {
                                    if (fun.MiSala.Capacidad <= CantidadEntradas)
                                    {
                                        UsuarioActual.MisFunciones.Add(fun);
                                        fun.CantidadClientes += CantidadEntradas;
                                        fun.AgregarCliente(UsuarioActual);




                                        if (UsuarioActual.EntradasCompradas.ContainsKey(IDFuncion))
                                        {
                                            UsuarioActual.EntradasCompradas[IDFuncion] += CantidadEntradas;
                                            UsuarioActual.Credito -= fun.Costo * CantidadEntradas;

                                            MessageBox.Show("credito x aca: " + UsuarioActual.Credito);
                                            MessageBox.Show("enrtadas cli: " + UsuarioActual.EntradasCompradas[IDFuncion].ToString());

                                            MessageBox.Show("Entrada comprada con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                        else
                                        {
                                            UsuarioActual.EntradasCompradas.Add(IDFuncion, CantidadEntradas);
                                            UsuarioActual.Credito -= fun.Costo * CantidadEntradas;
                                            MessageBox.Show("Entrada comprada con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }



                                    }
                                    return true;

                                }
                                else
                                {
                                    throw new InvalidOperationException("No hay la cantidad solicitada de asientos");
                                }

                            }
                            else
                            {
                                throw new InvalidOperationException("No podes comprar 0 entradas");

                            }


                        }
                        else
                        {
                            throw new InvalidOperationException("Créditos insuficientes");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor logueate", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                //if (!FuncionExiste) { throw new FileNotFoundException("No se econtró la función."); }



                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



                            if (UsuarioActual.EntradasCompradas.ContainsKey(IDFuncion))
                            {
                                UsuarioActual.EntradasCompradas[IDFuncion] -= CantidadEntradas;

                                UsuarioActual.Credito += CantidadEntradas * (fun.Costo);
                                MessageBox.Show("Entrada devuelta con exito!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            }
                            if (UsuarioActual.EntradasCompradas[IDFuncion] <= 0)
                            {
                                UsuarioActual.EntradasCompradas.Remove(IDFuncion);
                            }

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
                                throw new InvalidOperationException("Email o contraseña incorrecta, intentalo nuevamente");

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

        //MOSTRAR
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

        public void Busqueda(string Pelicula, DateTime Fecha, int PrecioMax, int PrecioMin, string Ubicacion)
        {
            //pelicula>nombre MostrarPelicula();
            // funcion> fecha, Costo  MostrarFunciones();
            //sala>ubicacion MostrarSala();
            List<Pelicula> Peliculas = MostrarPeliculas();
            List<Funcion> Funciones = MostrarFunciones();
            List<Sala> Salas = MostrarSalas();

            
            List<int> IDFechaFuncionFiltrada = new List<int>();
            List<int> IDCostoFuncionFiltrada = new List<int>();
            List<int> IDFuncionFiltrada = new List<int>();

            List<Sala> SalaFiltrada = new List<Sala>();
            List<Pelicula> PeliculaFiltrada = new List<Pelicula>();
            List<Funcion> FuncionResultado = new List<Funcion>();

            //obtengo lista de peliculas con campo
            foreach (Pelicula p in Peliculas)
            {
                if (p.Nombre == Pelicula)
                {
                    PeliculaFiltrada.Add(p);
                }
            }
            foreach (Funcion f in Funciones)
            {
                if (f.Fecha == Fecha)
                {
                    IDFechaFuncionFiltrada.Add(f.ID);
                }
                if (f.Costo > PrecioMin && f.Costo < PrecioMax)
                {
                    IDCostoFuncionFiltrada.Add(f.ID);
                }
            }
            foreach (Sala s in Salas)
            {
                if (s.Ubicacion == Ubicacion)
                {
                    SalaFiltrada.Add(s);
                }
            }

            //if (PeliculaFiltrada.Count == 0) { IDPeliculaFiltrada.Add(0); }
            if (IDFechaFuncionFiltrada.Count == 0) { IDFechaFuncionFiltrada.Add(0); }
            if (IDCostoFuncionFiltrada.Count == 0) { IDCostoFuncionFiltrada.Add(0); }
            //if (IDUbicacionSalaFiltrada.Count == 0) { IDUbicacionSalaFiltrada.Add(0); }
            
            var Intersec = IDFechaFuncionFiltrada.Intersect(IDCostoFuncionFiltrada);

            foreach (var i in Intersec)
            {
                IDFuncionFiltrada.Add(i);
            }

             for (int i = 0; i < IDFuncionFiltrada.Count; i++) {
                Funcion fun = ObtenerFuncionPorId(IDFuncionFiltrada[i]);
                for(int j = 0; j< SalaFiltrada.Count; j++) {  
                    if (fun.MiSala == SalaFiltrada[j])
                    {
                        for(int k = 0; k< PeliculaFiltrada.Count; k++)
                        {
                            //if()
                            FuncionResultado.Add(fun);
                        }
                    }
                {

                }
             }
            

        }
        //TODO
        //public List<Funcion> BuscarFuncion(string Ubicacion, DateTime Fecha, double Costo, string NombrePelicula)
        //{

        //    List<Funcion> funcionEncontradas = new List<Funcion>();

        //    foreach (Funcion funcion in Funciones)
        //    {
        //        if (funcion.MiPelicula.Nombre == NombrePelicula)
        //        {

        //            if (funcion.MiSala.Ubicacion == Ubicacion && funcion.Fecha.Date == Fecha.Date && funcion.Costo == Costo)
        //            {
        //                funcionEncontradas.Add(new Funcion(funcion.MiSala, funcion.MiPelicula, funcion.Fecha, funcion.CantidadClientes, funcion.Costo));
        //            }
        //            else
        //            {
        //                Console.WriteLine("No se encuentra Funcion con los datos ingresados");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No se encuentra Funcion con ese nombre");
        //        }

        //    }

        //    return funcionEncontradas;
        //}


    }
}
