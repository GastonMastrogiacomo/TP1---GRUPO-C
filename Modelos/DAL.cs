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
                        aux = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5), reader.GetBoolean(6));
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
                        // Esto hay que ver como lo hacemos porque recibe por parametros objetos Sala y Pelicula
                        sal = new Sala(reader.GetString(0), reader.GetInt32(1));
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
                        pel = new Pelicula(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetInt32(4));
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
                        //fun = new Funcion(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                        //misFunciones.Add(fun);
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
                string queryString = "SELECT * from dbo.UsuarioFuncion";
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
        public int agregarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, DateTime FechaNacimiento, bool EsAdmin, int credito)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuarios] ([DNI],[Nombre],[Apellido],[Mail],[Password],[FechaNacimiento],[EsADM],[credito]) VALUES (@dni,@nombre,@apellido,@mail,@password,@fechaNacimiento,@esadm,@credito);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Int));
                command.Parameters["@dni"].Value = DNI;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@fechaNacimiento"].Value = FechaNacimiento;
                command.Parameters["@esadm"].Value = EsAdmin;
                command.Parameters["@credito"].Value = credito;
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
            string queryString = "UPDATE [dbo].[Usuarios] SET DNI = @dni, Nombre=@nombre,Apellido = @apellido , Mail=@mail,Password=@password,FechaNacimiento = @fechaNacimiento,EsADM=@esadm,IntentosFallidos = @intentosFallidos, Bloqueado=@bloqueado, Credito = @credito WHERE ID=@id;";
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
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", SqlDbType.DateTime));
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
            string queryString = "INSERT INTO [dbo].[Salas] ([capacidad],[ubicacion]) VALUES (@capacidad,@ubicacion);";
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

        public int modificarSala(int idSala,string ubicacion, int capacidad)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Salas] SET Ubicacion=@ubicacion,Capacidad = @capacidad WHERE ID=@id;";
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
            string queryString = "UPDATE [dbo].[Peliculas] SET Nombre=@nombre,Descripcion = @descripcion,Sinopsis = @sinopsis, Poster = @poster, Duracion = @duracion WHERE ID=@id;";
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

        public int agregarFuncion(int MiSalaId, int MiPeliculaId, DateTime Fecha, int CantidadClientes, double Costo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Buscar la sala correspondiente en la base de datos
                    string salaQuery = "SELECT * FROM Salas WHERE ID = @salaId";
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
                    string peliculaQuery = "SELECT * FROM Peliculas WHERE ID = @peliculaId";
                    SqlCommand peliculaCommand = new SqlCommand(peliculaQuery, connection);
                    peliculaCommand.Parameters.AddWithValue("@peliculaId", MiPeliculaId);
                    SqlDataReader peliculaReader = peliculaCommand.ExecuteReader();
                    if (!peliculaReader.HasRows)
                    {
                        peliculaReader.Close();
                        return -2; // ID de película no encontrado
                    }
                    peliculaReader.Close();

                    // Verificar que el costo sea mayor a 0
                    if (Costo <= 0)
                    {
                        return -3; // Costo inválido
                    }

                    // Insertar la nueva función en la base de datos
                    string insertQuery = "INSERT INTO Funciones (MiSalaId, MiPeliculaId, Fecha, CantidadClientes, Costo) VALUES (@salaId, @peliculaId, @fecha, @cantidad, @costo);";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@salaId", MiSalaId);
                    insertCommand.Parameters.AddWithValue("@peliculaId", MiPeliculaId);
                    insertCommand.Parameters.AddWithValue("@fecha", Fecha);
                    insertCommand.Parameters.AddWithValue("@cantidad", CantidadClientes);
                    insertCommand.Parameters.AddWithValue("@costo", Costo);
                    int newFuncId = Convert.ToInt32(insertCommand.ExecuteScalar());

                    return newFuncId; // ID de la nueva función agregada
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
            string queryString = "UPDATE [dbo].[Usuarios] SET MiSalaId=@misalaid,MiPeliculaID = @mipeliculaid , Fecha=@fecha,Costo=@costo WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@misalaid", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@mipeliculaid", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                command.Parameters.Add(new SqlParameter("@costo", SqlDbType.Int));



                command.Parameters["@id"].Value = IDFuncion;
                command.Parameters["@misalaid"].Value = MiSalaId;
                command.Parameters["@mipeliculaid"].Value = MiPeliculaId;
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

    }
}
