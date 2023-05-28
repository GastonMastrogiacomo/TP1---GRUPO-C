using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using TP1___GRUPO_C.Model;
using System.Net;

namespace TP1___GRUPO_C.Modelos
{
    class DAL
    {

        private string connectionString;
        public DAL()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            //connectionString = Properties.Resources.ConnectionStr;
            connectionString = "Data Source=DESKTOP-88BRRQU\\SQLEXPRESS;Initial Catalog=cine;Integrated Security=True";
            //connectionString = "Data Source=localhost;Initial Catalog=cine;Integrated Security=True";
            //este de abajo es el que estaba antes de andy
            //connectionString  = "Data Source=DESKTOP-4S2EH6K\SQLEXPRESS01;Initial Catalog=cine;Integrated Security=True"

        }

        #region Metodos Inicializar
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * FROM [dbo].[Usuarios];";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6),reader.GetBoolean(8));
                        aux.Credito = reader.GetDouble(7);
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }

        public List<Sala> inicializarSalas()
        {
            List<Sala> misSalas = new List<Sala>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * FROM [dbo].[Salas];";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Sala sal;
                    while (reader.Read())
                    {
                        sal = new Sala(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        misSalas.Add(sal);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return misSalas;
        }

        public List<Pelicula> inicializarPeliculas()
        {
            List<Pelicula> misPeliculas = new List<Pelicula>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM [dbo].[Peliculas];";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Pelicula pel;
                    while (reader.Read())
                    {
                        pel = new Pelicula(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                        misPeliculas.Add(pel);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return misPeliculas;
        }

        public List<Funcion> inicializarFunciones()
        {
            List<Funcion> misFunciones = new List<Funcion>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM [dbo].[Funciones];";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Funcion fun;
                    while (reader.Read())
                    {
                        fun = new Funcion(reader.GetInt32(0),reader.GetDateTime(1), reader.GetDouble(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(2));
                       misFunciones.Add(fun);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return misFunciones;
        }


        public List<UsuarioFuncion> inicializarUsuarioFuncion()
        {
            List<UsuarioFuncion> usuarioFuncion = new List<UsuarioFuncion>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * from dbo.UsuariosFunciones;";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuarioFuncion.Add(new UsuarioFuncion(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return usuarioFuncion;
        }

        #endregion

        #region ABM Usuario lado DB
        public int agregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, float credito, bool bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario;
            string queryString = "INSERT INTO [dbo].[Usuarios] ([dni],[nombre],[apellido],[mail],[password],[fecha_nacimiento],[credito],[es_admin],[bloqueado],[intentos_fallidos]) VALUES (@dni,@nombre,@apellido,@mail,@password,@fechaNacimiento,@credito,@esadm,@bloqueado,@intentos);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentos", SqlDbType.Int));


                command.Parameters["@dni"].Value = DNI;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@fechaNacimiento"].Value = FechaNacimiento;
                command.Parameters["@esadm"].Value = EsAdmin;
                command.Parameters["@credito"].Value = credito;
                command.Parameters["@bloqueado"].Value = bloqueado;
                command.Parameters["@intentos"].Value = 0;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuarios];";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                    return idNuevoUsuario;
                }
                catch (Exception ex)
                {
                    //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
        }

        public int eliminarUsuario(int Id)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Usuarios] WHERE id=@id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int modificarUsuario(int idUsuario, int DNI, string Nombre, string Apellido, string Mail, string Pass, DateTime FechaNacimiento, bool esAdmin, int IntentosFallidos, bool Bloqueado, double Credito)
        {

            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET dni = @dni, nombre =@nombre, apellido = @apellido , mail =@mail,password=@password,fecha_nacimiento = @fechaNacimiento, es_admin=@esadm,intentos_fallidos = @intentosFallidos , bloqueado=@bloqueado, credito = @credito WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Int));


                command.Parameters["@id"].Value = idUsuario;
                command.Parameters["@dni"].Value = DNI;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Pass;
                command.Parameters["@fechaNacimiento"].Value = FechaNacimiento;
                command.Parameters["@esadm"].Value = esAdmin;
                command.Parameters["@intentosFallidos"].Value = IntentosFallidos;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@credito"].Value = Credito;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        #endregion

        #region ABM Sala lado DB

        public int agregarSala(int Capacidad, string Ubicacion)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaSala = -1;
            string queryString = "INSERT INTO [dbo].[Salas] ([ubicacion],[capacidad]) VALUES (@ubicacion,@capacidad);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                command.Parameters["@capacidad"].Value = Capacidad;
                command.Parameters["@ubicacion"].Value = Ubicacion;

                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();

                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Salas];";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaSala = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaSala;
            }
        }

        public int eliminarSala(int id)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Salas] WHERE id=@id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int modificarSala(int idSala, string ubicacion, int capacidad)
        {
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Salas] SET ubicacion=@ubicacion,capacidad = @capacidad WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                command.Parameters["@id"].Value = idSala;
                command.Parameters["@ubicacion"].Value = ubicacion;
                command.Parameters["@capacidad"].Value = capacidad;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        #endregion

        #region ABM Pelicula lado DB

        public int agregarPelicula(string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaPelicula = -1;
            string queryString = "INSERT INTO [dbo].[Peliculas] ([nombre],[descripcion],[sinopsis],[poster],[duracion]) VALUES (@nombre,@descripcion,@sinopsis,@poster,@duracion);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@sinopsis", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@poster", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@duracion", SqlDbType.Int));
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@descripcion"].Value = Descripcion;
                command.Parameters["@sinopsis"].Value = Sinopsis;
                command.Parameters["@poster"].Value = Poster;
                command.Parameters["@duracion"].Value = Duracion;

                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();

                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Peliculas];";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaPelicula = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaPelicula;
            }
        }

        public int eliminarPelicula(int IDPelicula)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Peliculas] WHERE id=@id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = IDPelicula;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int modificarPelicula(int IDPelicula, string Nombre, string Descripcion, string Sinopsis, string Poster, int Duracion, List<string> IdFunciones)
        {
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Peliculas] SET nombre=@nombre,descripcion = @descripcion,sinopsis = @sinopsis, poster = @poster, duracion = @duracion WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@sinopsis", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@poster", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@duracion", SqlDbType.Int));

                command.Parameters["@id"].Value = IDPelicula;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@descripcion"].Value = Descripcion;
                command.Parameters["@sinopsis"].Value = Sinopsis;
                command.Parameters["@poster"].Value = Poster;
                command.Parameters["@duracion"].Value = Duracion;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        #endregion

        #region ABM Funcion lado DB

        public int agregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo, int capacidad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Buscar la sala correspondiente en la base de datos
                    string salaQuery = "SELECT * FROM Salas WHERE id = @salaId;";
                    SqlCommand salaCommand = new SqlCommand(salaQuery, connection);
                    salaCommand.Parameters.AddWithValue("@salaId", MiSalaId);
                    connection.Open();
                    SqlDataReader salaReader = salaCommand.ExecuteReader();
                    if (!salaReader.HasRows)
                    {
                        salaReader.Close();
                        return -1; // ID de sala no encontrado
                    }
                    salaReader.Close();

                    // Buscar la película correspondiente en la base de datos
                    string peliculaQuery = "SELECT * FROM Peliculas WHERE id = @peliculaId;";
                    SqlCommand peliculaCommand = new SqlCommand(peliculaQuery, connection);
                    peliculaCommand.Parameters.AddWithValue("@peliculaId", MiPeliculaId);
                    SqlDataReader peliculaReader = peliculaCommand.ExecuteReader();
                    if (!peliculaReader.HasRows)
                    {
                        peliculaReader.Close();
                        return -1; // ID de película no encontrado
                    }
                    peliculaReader.Close();

                    // Verificar que el costo sea mayor a 0
                    if (Costo <= 0)
                    {
                        return -1; // Costo inválido
                    }

                    // Insertar la nueva función en la base de datos
                    int resultadoQuery;
                    int idNuevoUsuario = -1;
                    string queryString = "INSERT INTO Funciones (fecha,asientos_disponibles,costo, id_sala, id_pelicula) VALUES (@fecha, @asientos_disponibles, @costo, @id_sala, @id_pelicula);";


                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
                    command.Parameters.Add(new SqlParameter("@asientos_disponibles", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                    command.Parameters.Add(new SqlParameter("@id_sala", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@id_pelicula", SqlDbType.Int));

                    command.Parameters["@fecha"].Value = Fecha;
                    command.Parameters["@asientos_disponibles"].Value = capacidad;
                    command.Parameters["@costo"].Value = Costo;
                    command.Parameters["@id_sala"].Value = MiSalaId;
                    command.Parameters["@id_pelicula"].Value = MiPeliculaId;


                    try
                    {
                        connection.Open();
                        //esta consulta NO espera un resultado para leer, es del tipo NON Query
                        resultadoQuery = command.ExecuteNonQuery();

                        //*******************************************
                        //Ahora hago esta query para obtener el ID
                        string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuarios]";
                        command = new SqlCommand(ConsultaID, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        idNuevoUsuario = reader.GetInt32(0);
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
                        Console.WriteLine(ex.Message);
                        return -1;
                    }
                    return idNuevoUsuario;

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 500; // Error desconocido
            }
        }

        public int eliminarFuncion(int IDFuncion)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Funciones] WHERE id=@id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = IDFuncion;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int modificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo, int capacidad)
        {
            // HAY QUE VER COMO PODEMOS HACER PARA QUE INTENTOS FALLIDOS NO ESTE ACA, ver lo que escribi en Usuario porque me parece que conviene eliminar ese atributo
            // De momento lo dejo puesto y arreglo el codigo para que lo contemple  pero probablemente no funcione asi
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Funciones] SET fecha=@fecha,asientos_disponibles = @asientos, costo = @costo , id_sala=@id_sala,id_pelicula=@id_pelicula WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_sala", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_pelicula", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@asientos", SqlDbType.Int));



                command.Parameters["@id"].Value = IDFuncion;
                command.Parameters["@id_sala"].Value = MiSalaId;
                command.Parameters["@id_pelicula"].Value = MiPeliculaId;
                command.Parameters["@fecha"].Value = Fecha;
                command.Parameters["@costo"].Value = Costo;
                command.Parameters["@asientos"].Value = capacidad;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        #endregion

        #region ABM UsuarioFuncion lado DB
        public int agregarUsuarioFuncion(int idUsuario, int idFuncion)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNueva = -1;
            string queryString = "INSERT INTO [dbo].[UsuariosFunciones] ([id_usuario],[id_funcion],[cantidad_entradas_compradas]) VALUES (@id_usuario,@id_funcion,@cantidad);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_funcion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

                command.Parameters["@id_usuario"].Value = idUsuario;
                command.Parameters["@id_funcion"].Value = idFuncion;
                command.Parameters["@cantidad"].Value = 0;

                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Salas];";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNueva = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNueva;
            }
        }

        public int eliminarUsuarioFuncion(int idUsuario)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[UsuariosFunciones] WHERE id_usuario=@id_usuario;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters["@id_usuario"].Value = idUsuario;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        #endregion

        #region Metodos

        public int cargarCredito(int idUsuario, double importe)
        {
            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET credito = @credito WHERE id=@id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Int));
                command.Parameters["@id"].Value = idUsuario;
                command.Parameters["@credito"].Value = importe;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int bloquearUsuario(int idUsuario)
        {

            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET bloqueado = @bloqueado WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters["@id"].Value = idUsuario;
                command.Parameters["@bloqueado"].Value = true;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        public int modificarIntentosFallidos(int idUsuario, int intentos)
        {

            //string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET intentos_fallidos = @intentos WHERE id=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@intentos", SqlDbType.Int));
                command.Parameters["@id"].Value = idUsuario;
                command.Parameters["@intentos"].Value = intentos;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                    //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        public int devolverEntrada(int idFuncion, int idUsuario)
        {
            string queryString = "DELETE FROM [dbo].[UsuariosFunciones] WHERE id_funcion = @id_funcion AND id_usuario = @id_usuario;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_funcion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));

                command.Parameters["@id_funcion"].Value = idFuncion;
                command.Parameters["@id_usuario"].Value = idUsuario;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        public int devolverEntradaMayorCero(int idFuncion, int idUsuario, int entradasRestantes)
        {
            string queryString = "UPDATE [dbo].[UsuariosFunciones] SET cantidad_entradas_compradas = @cantidad WHERE id_funcion = @idFuncion AND id_usuario = @idUsuario;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idFuncion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

                command.Parameters["@idFuncion"].Value = idFuncion;
                command.Parameters["@idUsuario"].Value = idUsuario;
                command.Parameters["@cantidad"].Value = entradasRestantes;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }

        public int actualizarCreditoUsuario(int idUsuario, double credito)
        {
            string queryString = "UPDATE [dbo].[Usuarios] SET credito = @credito WHERE id = @idUsuario;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

                command.Parameters["@credito"].Value = credito;
                command.Parameters["@idUsuario"].Value = idUsuario;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int actualizarAsientosDisponibles(int idFuncion, int cantidadEntradas)
        {
            string queryString = "UPDATE [dbo].[Funciones] SET asientos_disponibles = @asientos_disponibles  WHERE id = @idFuncion;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@asientos_disponibles", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idFuncion", SqlDbType.Int));

                command.Parameters["@asientos_disponibles"].Value = cantidadEntradas;
                command.Parameters["@idFuncion"].Value = idFuncion;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int sumarEntrada(int idFuncion, int idUsuario, int cantidad)
        {
           
            string queryString = "UPDATE [dbo].[UsuariosFunciones] SET cantidad_entradas_compradas = @cantidadEntradas WHERE id_usuario = @idUsuario AND id_funcion= @idFuncion;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idFuncion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@cantidadEntradas", SqlDbType.Int));

                command.Parameters["@idUsuario"].Value = idUsuario;
                command.Parameters["@idFuncion"].Value = idFuncion;
                command.Parameters["@cantidadEntradas"].Value = cantidad;

                try
                {
                    connection.Open();
                  
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }


        }

        public int cargarEntradas(int idFuncion, int idUsuario, int cantidad)
        {
            string queryString = "INSERT INTO [dbo].[UsuariosFunciones] ([id_usuario],[id_funcion],[cantidad_entradas_compradas]) VALUES (@idUsuario, @idFuncion, @cantidadEntradas);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idFuncion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@cantidadEntradas", SqlDbType.Int));

                command.Parameters["@idUsuario"].Value = idUsuario;
                command.Parameters["@idFuncion"].Value = idFuncion;
                command.Parameters["@cantidadEntradas"].Value = cantidad;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }


        }



        #endregion

    }
}
