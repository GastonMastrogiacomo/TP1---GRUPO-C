using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP1___GRUPO_C.Model;

namespace TP1___GRUPO_C.Modelos
{
    class MyContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        //TODO VER SI ESTO VA O NO
        public DbSet<UsuarioFuncion> UF { get; set; }

        public MyContext() { }

        //private string connectionStr;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionStr = "Data Source=DESKTOP-4S2EH6K\\SQLEXPRESS01;Initial Catalog=cine;Integrated Security=True";
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.ID);
            //Agregamos las tablas nuevas
            modelBuilder.Entity<Funcion>()
                .ToTable("Funciones")
                .HasKey(f => f.ID);
            modelBuilder.Entity<Sala>()
                .ToTable("Salas")
                .HasKey(s => s.ID);
            modelBuilder.Entity<Pelicula>()
                .ToTable("Peliculas")
                .HasKey(p => p.ID);

            /*
            //==================== RELACIONES============================
            //DEFINICIÓN DE LA RELACIÓN ONE TO ONE USUARIO -> DNI
            modelBuilder.Entity<Usuario>()
                .HasOne(U => U.dni)
                .WithOne(D => D.user)
                .HasForeignKey<DNI>(D => D.idUsuario)
                .OnDelete(DeleteBehavior.Cascade);
           



            ////DEFINICIÓN DE LA RELACIÓN ONE TO MANY USUARIO -> DOMICILIO

            modelBuilder.Entity<Domicilio>()
            .HasOne(D => D.user)
            .WithMany(U => U.domicilios)
            .HasForeignKey(D => D.idUsuario)
            .OnDelete(DeleteBehavior.Cascade);

            ////DEFINICIÓN DE LA RELACIÓN MANY TO MANY USUARIO <-> PAIS
            //usario fucnion
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.Nacionalidad)
                .WithMany(P => P.users)
                .UsingEntity<UsuarioPais>(
                    eup => eup.HasOne(up => up.pais).WithMany(p => p.UserPais).HasForeignKey(u => u.idPais),
                    eup => eup.HasOne(up => up.user).WithMany(u => u.UserPais).HasForeignKey(u => u.idUsuario),
                    eup => eup.HasKey(k => new { k.idUsuario, k.idPais })
                );

             */

            //DEFINICIÓN DE LA RELACIÓN 
            //ONE TO MANY FUNCION -> SALAS

            modelBuilder.Entity<Funcion>()
            .HasOne(f => f.MiSala)
            .WithMany(s => s.MisFunciones)
            .HasForeignKey(f => f.idSala)
            .OnDelete(DeleteBehavior.Cascade);


            //ONE TO MANY FUNCION -> PELICULAS
            modelBuilder.Entity<Funcion>()
            .HasOne(f => f.MiPelicula)
            .WithMany(p => p.MisFunciones)
            .HasForeignKey(f => f.idPelicula)
            .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN MANY TO MANY USUARIO <-> FUNCION
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.MisFunciones)
                .WithMany(f => f.Clientes)
                .UsingEntity<UsuarioFuncion>(
                    euf => euf.HasOne(uf => uf.funcion).WithMany(f => f.UserFuncion).HasForeignKey(u => u.idFuncion),
                    euf => euf.HasOne(uf => uf.usuario).WithMany(u => u.UserFuncion).HasForeignKey(u => u.idUsuario),
                    euf => euf.HasKey(k => new { k.idUsuario, k.idFuncion })
                );


            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.DNI).HasColumnType("bigint");
                    usr.Property(u => u.Nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.Apellido).HasColumnType("varchar(50)");
                    usr.Property(u => u.Mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.Password).HasColumnType("varchar(50)");
                    usr.Property(u => u.IntentosFallidos).HasColumnType("int");
                    usr.Property(u => u.Bloqueado).HasColumnType("bit");
                    usr.Property(u => u.Credito).HasColumnType("decimal");
                    usr.Property(u => u.FechaNacimiento).HasColumnType("datetime2");
                    usr.Property(u => u.EsAdmin).HasColumnType("bit");
                });

            modelBuilder.Entity<Funcion>(
                usr =>
                {
                    usr.Property(f => f.idSala).HasColumnType("integer");
                    usr.Property(f => f.idPelicula).HasColumnType("integer");
                    usr.Property(f => f.Fecha).HasColumnType("datetime2");
                    usr.Property(f => f.AsientosDisponibles).HasColumnType("integer");
                    usr.Property(f => f.CantidadClientes).HasColumnType("integer");
                    usr.Property(f => f.Costo).HasColumnType("decimal(18,2)");
                });


            modelBuilder.Entity<Sala>(
               usr =>
               {
                   usr.Property(s => s.Ubicacion).HasColumnType("varchar(50)");
                   usr.Property(s => s.Capacidad).HasColumnType("integer");
               });

            modelBuilder.Entity<Pelicula>(
               usr =>
               {
                   usr.Property(p => p.Nombre).HasColumnType("varchar(50)");
                   usr.Property(p => p.Descripcion).HasColumnType("varchar(150)");
                   usr.Property(p => p.Sinopsis).HasColumnType("varchar(255)");
                   usr.Property(p => p.Poster).HasColumnType("varchar(255)");
                   usr.Property(p => p.Duracion).HasColumnType("integer");
               });

            modelBuilder.Entity<UsuarioFuncion>(
               uf =>
               {
                   uf.Property(s => s.idUsuario).HasColumnType("integer");
                   uf.Property(s => s.idFuncion).HasColumnType("integer");
                   uf.Property(s => s.CantidadEntradasCompradas).HasColumnType("integer");
               });



            //AGREGO ALGUNOS DATOS DE PRUEBA
            modelBuilder.Entity<Funcion>().HasData(
                new { id = 1, fecha = "2023 - 06 - 15T09:00:00.000", asientos_disponibles = 200, costo = 2000, id_sala = 1, id_pelicula = 1 },
                new { id = 2, fecha = "2023-06-16T12:00:00.000", asientos_disponibles = 150, costo = 2500, id_sala = 1, id_pelicula = 2 },
                new { id = 3, fecha = "2023-06-17T16:30:00.000", asientos_disponibles = 250, costo = 1500, id_sala = 2, id_pelicula = 2 },
                new { id = 4, fecha = "2023-06-18T20:30:00.000", asientos_disponibles = 175, costo = 1000, id_sala = 2, id_pelicula = 2 },
                new { id = 5, fecha = "2023-06-14T21:00:00.000", asientos_disponibles = 300, costo = 2200, id_sala = 2, id_pelicula = 3 },
                new { id = 6, fecha = "2023-05-27T21:00:00.000", asientos_disponibles = 300, costo = 2200, id_sala = 2, id_pelicula = 3 },
                new { id = 7, fecha = "2023-06-19T14:00:00.000", asientos_disponibles = 200, costo = 1800, id_sala = 3, id_pelicula = 3 },
                new { id = 8, fecha = "2023-06-20T17:30:00.000", asientos_disponibles = 180, costo = 1500, id_sala = 3, id_pelicula = 4 },
                new { id = 9, fecha = "2023-06-21T19:45:00.000", asientos_disponibles = 250, costo = 1200, id_sala = 4, id_pelicula = 4 },
                new { id = 10, fecha = "2023-06-22T21:15:00.000", asientos_disponibles = 175, costo = 1000, id_sala = 4, id_pelicula = 4 },
                new { id = 11, fecha = "2023-06-23T18:30:00.000", asientos_disponibles = 300, costo = 2000, id_sala = 1, id_pelicula = 4 },
                new { id = 12, fecha = "2023-06-24T15:45:00.000", asientos_disponibles = 280, costo = 2200, id_sala = 1, id_pelicula = 1 },
                new { id = 13, fecha = "2023-06-25T20:00:00.000", asientos_disponibles = 220, costo = 1900, id_sala = 2, id_pelicula = 2 },
                new { id = 14, fecha = "2023-06-26T12:30:00.000", asientos_disponibles = 190, costo = 1700, id_sala = 2, id_pelicula = 3 },
                new { id = 15, fecha = "2023-06-27T16:15:00.000", asientos_disponibles = 230, costo = 1400, id_sala = 3, id_pelicula = 2 },
                new { id = 16, fecha = "2023-06-28T19:30:00.000", asientos_disponibles = 200, costo = 1200, id_sala = 3, id_pelicula = 1 },
                new { id = 17, fecha = "2023-06-28T19:30:00.000", asientos_disponibles = 250, costo = 1000, id_sala = 4, id_pelicula = 2 },
                new { id = 18, fecha = "2023-06-29T21:45:00.000", asientos_disponibles = 300, costo = 2200, id_sala = 4, id_pelicula = 2 },
                new { id = 19, fecha = "2023-06-30T15:00:00.000", asientos_disponibles = 270, costo = 1900, id_sala = 1, id_pelicula = 3 },
                new { id = 20, fecha = "2023-07-01T18:15:00.000", asientos_disponibles = 230, costo = 1700, id_sala = 1, id_pelicula = 4 },
                new { id = 21, fecha = "2023-07-02T13:30:00.000", asientos_disponibles = 190, costo = 1400, id_sala = 2, id_pelicula = 1 });

            modelBuilder.Entity<Sala>().HasData(
                new { id = 1, ubicacion = "Olivos", capacidad = 100 },
                new { id = 2, ubicacion = "San Isidro", capacidad = 200 },
                new { id = 3, ubicacion = "Caballito", capacidad = 500 },
                new { id = 4, ubicacion = "Palermo", capacidad = 300 },
                new { id = 5, ubicacion = "Recoleta", capacidad = 150 },
                new { id = 6, ubicacion = "Belgrano", capacidad = 100 },
                new { id = 7, ubicacion = "La Plata", capacidad = 200 },
                new { id = 8, ubicacion = "Mar del Plata", capacidad = 150 },
                new { id = 9, ubicacion = "Córdoba", capacidad = 120 },
                new { id = 10, ubicacion = "Rosario", capacidad = 200 },
                new { id = 11, ubicacion = "Mendoza", capacidad = 130 },
                new { id = 12, ubicacion = "Tigre", capacidad = 150 },
                new { id = 13, ubicacion = "Quilmes", capacidad = 200 },
                new { id = 14, ubicacion = "San Miguel", capacidad = 170 },
                new { id = 15, ubicacion = "Lomas de Zamora", capacidad = 180 },
                new { id = 16, ubicacion = "Morón", capacidad = 200 },
                new { id = 17, ubicacion = "Avellaneda", capacidad = 120 },
                new { id = 18, ubicacion = "Banfield", capacidad = 110 },
                new { id = 19, ubicacion = "E.T. el Extraterrestre", capacidad = 1 });

            modelBuilder.Entity<Usuario>().HasData(
                new { id = 1, dni = 1, nombre = "Pepe", apellido = "Perez", mail = "pepe@mail.com", password = "123", fecha_nacimiento = "1992-11-02", credito = 100, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 2, dni = 2, nombre = "El", apellido = "Admin", mail = "admin@mail.com", password = "123", fecha_nacimiento = "1990-06-08", credito = 0, es_admin = true, bloqueado = false, intentos_fallidos = 0 },
                new { id = 3, dni = 3, nombre = "Lucas", apellido = "Rodriguez", mail = "lucas@mail.com", password = "123", fecha_nacimiento = "1995-08-24", credito = 3000, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 4, dni = 4, nombre = "Ana", apellido = "González", mail = "ana@mail.com", password = "123", fecha_nacimiento = "1988-05-15", credito = 500, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 5, dni = 5, nombre = "María", apellido = "López", mail = "maria@mail.com", password = "123", fecha_nacimiento = "1993-09-30", credito = 200, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 6, dni = 6, nombre = "Luis", apellido = "Fernández", mail = "luis@mail.com", password = "123", fecha_nacimiento = "1994-12-10", credito = 800, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 7, dni = 7, nombre = "Laura", apellido = "Martínez", mail = "laura@mail.com", password = "123", fecha_nacimiento = "1991-07-18", credito = 1500, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 8, dni = 8, nombre = "Carlos", apellido = "Gómez", mail = "carlos@mail.com", password = "123", fecha_nacimiento = "1996-03-25", credito = 1200, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 9, dni = 9, nombre = "Ana", apellido = "Rodríguez", mail = "ana.rodriguez@mail.com", password = "123", fecha_nacimiento = "1989-09-12", credito = 2500, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 10, dni = 10, nombre = "Marcelo", apellido = "López", mail = "marcelo@mail.com", password = "123", fecha_nacimiento = "1997-11-28", credito = 300, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 11, dni = 11, nombre = "Julia", apellido = "Torres", mail = "julia@mail.com", password = "123", fecha_nacimiento = "1993-02-04", credito = 1800, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 12, dni = 12, nombre = "Mariano", apellido = "García", mail = "mariano@mail.com", password = "123", fecha_nacimiento = "1995-06-22", credito = 5000, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 13, dni = 13, nombre = "Gabriela", apellido = "López", mail = "gabriela@mail.com", password = "123", fecha_nacimiento = "1990-10-08", credito = 700, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 14, dni = 14, nombre = "Federico", apellido = "Pérez", mail = "federico@mail.com", password = "123", fecha_nacimiento = "1994-04-16", credito = 1000, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 15, dni = 15, nombre = "Carolina", apellido = "Fernández", mail = "carolina@mail.com", password = "123", fecha_nacimiento = "1991-08-14", credito = 250, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 16, dni = 16, nombre = "Luciana", apellido = "González", mail = "luciana@mail.com", password = "123", fecha_nacimiento = "1988-12-30", credito = 3500, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 17, dni = 17, nombre = "Martín", apellido = "Martínez", mail = "martin@mail.com", password = "123", fecha_nacimiento = "1997-03-17", credito = 900, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 18, dni = 18, nombre = "Paula", apellido = "Gómez", mail = "paula@mail.com", password = "123", fecha_nacimiento = "1992-09-24", credito = 2000, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 19, dni = 19, nombre = "Diego", apellido = "Rodríguez", mail = "diego.rodriguez@mail.com", password = "123", fecha_nacimiento = "1996-01-11", credito = 3000, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 20, dni = 20, nombre = "Sofía", apellido = "López", mail = "sofia@mail.com", password = "123", fecha_nacimiento = "1993-05-28", credito = 600, es_admin = false, bloqueado = false, intentos_fallidos = 0 },
                new { id = 21, dni = 21, nombre = "Agustín", apellido = "Torres", mail = "agustin@mail.com", password = "123", fecha_nacimiento = "1989-11-01", credito = 1400, es_admin = false, bloqueado = false, intentos_fallidos = 0 });

            modelBuilder.Entity<UsuarioFuncion>().HasData(
                new { id_usuario = 1, id_funcion = 1, cantidad_entradas_compradas = 1 },
                new { id_usuario = 1, id_funcion = 2, cantidad_entradas_compradas = 4 },
                new { id_usuario = 1, id_funcion = 3, cantidad_entradas_compradas = 1 },
                new { id_usuario = 3, id_funcion = 4, cantidad_entradas_compradas = 3 },
                new { id_usuario = 3, id_funcion = 5, cantidad_entradas_compradas = 2 },
                new { id_usuario = 4, id_funcion = 9, cantidad_entradas_compradas = 2 },
                new { id_usuario = 4, id_funcion = 10, cantidad_entradas_compradas = 4 },
                new { id_usuario = 4, id_funcion = 11, cantidad_entradas_compradas = 2 },
                new { id_usuario = 6, id_funcion = 12, cantidad_entradas_compradas = 3 },
                new { id_usuario = 6, id_funcion = 13, cantidad_entradas_compradas = 1 },
                new { id_usuario = 6, id_funcion = 14, cantidad_entradas_compradas = 4 },
                new { id_usuario = 8, id_funcion = 15, cantidad_entradas_compradas = 2 },
                new { id_usuario = 8, id_funcion = 16, cantidad_entradas_compradas = 3 },
                new { id_usuario = 8, id_funcion = 17, cantidad_entradas_compradas = 1 },
                new { id_usuario = 10, id_funcion = 18, cantidad_entradas_compradas = 4 },
                new { id_usuario = 10, id_funcion = 19, cantidad_entradas_compradas = 2 },
                new { id_usuario = 10, id_funcion = 20, cantidad_entradas_compradas = 3 });

            //Ignoro, no agrego la clase Cine ni Status Code a la base de datos
            modelBuilder.Ignore<Cine>();
            modelBuilder.Ignore<StatusCode>();
            
            //BORRAR ESTO, de momento la dejo por si queremos revisar el codigo 
            modelBuilder.Ignore<DAL>();

        }
    }
}
