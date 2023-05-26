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
            connectionString = Properties.Resources.ConnectionStr;
            //connectionString = "Data Source=DESKTOP-LR8KJAR\\SQLEXPRESS;Initial Catalog=20221017;Integrated Security=True";
        }

        #region Metodos Inicializar
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Usuarios";

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
                        aux = new Usuario(reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetBoolean(8));
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
                string queryString = "SELECT * from dbo.Salas";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Sala sal;
                    while (reader.Read())
                    {
                        sal = new Sala(reader.GetString(1), reader.GetInt32(2));
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

        public List<Pelicula> iniicalizarPeliculas()
        {
            List<Pelicula> misPeliculas = new List<Pelicula>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * from dbo.Peliculas";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Pelicula pel;
                    while (reader.Read())
                    {
                        // Esto hay que ver como lo hacemos porque recibe por parametros objetos Sala y Pelicula
                        pel = new Pelicula(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
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

        // Este hay que refa
        public List<Funcion> inicializarFunciones()
        {
            List<Funcion> misFunciones = new List<Funcion>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * from dbo.Funciones";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Funcion fun;
                    while (reader.Read())
                    {
                        // Esto hay que ver como lo hacemos porque recibe por parametros objetos Sala y Pelicula
                        fun = new Funcion(reader.GetDateTime(1), reader.GetDouble(2), reader.GetInt32(3), reader.GetInt32(4));
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

        //ESTE MÉTODO SE USARÍA PARA COMPLETAR LA LISTA QUE REPRESENTA LA TALBA INTERMEDIA ENTRE
        //USUARIO Y DOMICILIO SI SU RELACIÓN ES MANY TO MANY
        public List<UsuarioFuncion> inicializarUsuarioFuncion()
        {
            List<UsuarioFuncion> usuarioFuncion = new List<UsuarioFuncion>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * from dbo.UsuariosFunciones";
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
        public int agregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, int credito, bool bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuarios] ([dni],[nombre],[apellido],[mail],[password],[fecha_nacimiento],[credito],[es_admin],[bloqueado]) VALUES (@dni,@nombre,@apellido,@mail,@password,@fechaNacimiento,@credito,@esadm,@bloqueado);";
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
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));

                command.Parameters["@dni"].Value = DNI;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@fechaNacimiento"].Value = FechaNacimiento;
                command.Parameters["@esadm"].Value = EsAdmin;
                command.Parameters["@credito"].Value = credito;
                command.Parameters["@bloqueado"].Value = bloqueado;

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

        public int eliminarUsuario(int Id)
        {
            //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Usuarios] WHERE ID=@id";
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
            // HAY QUE VER COMO PODEMOS HACER PARA QUE INTENTOS FALLIDOS NO ESTE ACA, ver lo que escribi en Usuario porque me parece que conviene eliminar ese atributo
            // De momento lo dejo puesto y arreglo el codigo para que lo contemple  pero probablemente no funcione asi
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET dni = @dni, nombre =@nombre, apellido = @apellido , mail =@mail,password=@password,fecha_nacimiento = @fechaNacimiento, es_admin=@esadm,bloqueado=@bloqueado, credito = @credito WHERE ID=@id;";
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
                //command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
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

                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Salas]";
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
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Salas] WHERE ID=@id";
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
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Salas] SET ubicacion=@ubicacion,capacidad = @capacidad WHERE ID=@id;";
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

                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Peliculas]";
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
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Peliculas] WHERE ID=@id";
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
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Peliculas] SET nombre=@nombre,descripcion = @descripcion,sinopsis = @sinopsis, poster = @poster, duracion = @duracion WHERE ID=@id;";
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
                    string salaQuery = "SELECT * FROM Salas WHERE id = @salaId";
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
                    string peliculaQuery = "SELECT * FROM Peliculas WHERE id = @peliculaId";
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
                    command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Int));
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
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Funciones] WHERE ID=@id";
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

        public int modificarFuncion(int IDFuncion, int MiSalaId, int MiPeliculaId, DateTime Fecha, double Costo)
        {
            // HAY QUE VER COMO PODEMOS HACER PARA QUE INTENTOS FALLIDOS NO ESTE ACA, ver lo que escribi en Usuario porque me parece que conviene eliminar ese atributo
            // De momento lo dejo puesto y arreglo el codigo para que lo contemple  pero probablemente no funcione asi
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Funciones] SET fecha=@fecha,costo = @costo , id_sala=@id_sala,id_pelicula=@id_pelicula WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_sala", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_pelicula", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Int));



                command.Parameters["@id"].Value = IDFuncion;
                command.Parameters["@id_sala"].Value = MiSalaId;
                command.Parameters["@id_pelicula"].Value = MiPeliculaId;
                command.Parameters["@fecha"].Value = Fecha;
                command.Parameters["@costo"].Value = Costo;

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

        #region Metodos

        public int cargarCredito(int idUsuario, double importe)
        {
            // HAY QUE VER COMO PODEMOS HACER PARA QUE INTENTOS FALLIDOS NO ESTE ACA, ver lo que escribi en Usuario porque me parece que conviene eliminar ese atributo
            // De momento lo dejo puesto y arreglo el codigo para que lo contemple  pero probablemente no funcione asi
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET credito = @credito WHERE ID=@id;";
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

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET bloqueado = @bloqueado WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters["@id"].Value = idUsuario;
                command.Parameters["@bloqueado"].Value = 0;

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

        public int devolverEntrada(int idFuncion, int idUsuario, int cantidad)
        {
            string queryString = "DELETE FROM [dbo].[UsuarioFuncion] WHERE idFuncion = @idFuncion AND idUsuario = @idUsuario;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idFuncion", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

                command.Parameters["@idFuncion"].Value = idFuncion;
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

        public int actualizarCreditoUsuario(int idFuncion, int idUsuario, int credito)
        {
            string queryString = "UPDATE [dbo].[Usuarios] SET credito = @credito WHERE ID = @idUsuario;";
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

        #endregion

    }
}
