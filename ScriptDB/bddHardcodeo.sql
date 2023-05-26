INSERT INTO Usuarios (dni,nombre,apellido,mail,password,fecha_nacimiento,credito,es_admin,bloqueado) VALUES(1111, 'Pepe', 'Perez', 'pepe@mail.com', '123', 11/02/1992, 1000,0,0);
INSERT INTO Usuarios (dni,nombre,apellido,mail,password,fecha_nacimiento,credito,es_admin,bloqueado) VALUES(2222,'El', 'Admin', 'admin@mail.com', '123', 08/06/1990, 0, 1,0); 
INSERT INTO Usuarios (dni,nombre,apellido,mail,password,fecha_nacimiento,credito,es_admin,bloqueado) VALUES(3333, 'Lucas', 'Rodriguez', 'lucas@mail.com', '123', 24/08/1995, 3000,0,0);


INSERT INTO Salas (ubicacion,capacidad) VALUES ('Olivos', 100);
INSERT INTO Salas (ubicacion,capacidad) VALUES ('San Isidro',200);


INSERT INTO Peliculas (nombre,descripcion,sinopsis,poster,duracion) VALUES ('Toy Story', 'Pelicula de juguetes.', 'Juguetes', ' ', 120);
INSERT INTO Peliculas (nombre,descripcion,sinopsis,poster,duracion) VALUES ('Mario Bros', 'Its me Mario!', 'Nintendo', ' ', 100);
INSERT INTO Peliculas (nombre,descripcion,sinopsis,poster,duracion) VALUES ('Mario 2', 'Its me Mario2!', 'Nintendo2', ' ', 110);


INSERT INTO Funciones (fecha,asientos_disponibles,costo,id_sala,id_pelicula) VALUES ('2023-06-15 09:00:00.000', 200, 200, 1,1);
INSERT INTO Funciones (fecha,asientos_disponibles,costo,id_sala,id_pelicula) VALUES ('2023-06-16 12:00:00.000', 250, 150, 1,2);
INSERT INTO Funciones (fecha,asientos_disponibles,costo,id_sala,id_pelicula) VALUES ('2023-06-17 16:30:00.000', 150, 250, 2,2);
INSERT INTO Funciones (fecha,asientos_disponibles,costo,id_sala,id_pelicula) VALUES ('2023-06-18 20:30:00.000', 100, 175, 2,2);
INSERT INTO Funciones (fecha,asientos_disponibles,costo,id_sala,id_pelicula) VALUES ('2023-06-14 21:00:00.000', 220, 300, 2,3);


INSERT INTO UsuariosFunciones (id_usuario,id_funcion,cantidad_entradas_compradas) VALUES (1,1,1);
INSERT INTO UsuariosFunciones (id_usuario,id_funcion,cantidad_entradas_compradas) VALUES (1,2,4);
INSERT INTO UsuariosFunciones (id_usuario,id_funcion,cantidad_entradas_compradas) VALUES (1,3,1);
INSERT INTO UsuariosFunciones (id_usuario,id_funcion,cantidad_entradas_compradas) VALUES (3,4,3);
INSERT INTO UsuariosFunciones (id_usuario,id_funcion,cantidad_entradas_compradas) VALUES (3,5,2);

