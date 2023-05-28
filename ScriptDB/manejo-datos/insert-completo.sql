-- Tabla USUARIOS
INSERT INTO USUARIOS (dni, nombre, apellido, mail, password, fecha_nacimiento, credito, es_admin, bloqueado, Intentos_fallidos) 
VALUES
  (1111, 'Pepe', 'Perez', 'pepe@mail.com', '123', '1992-11-02', 1000, 0, 0, 0),
  (2222, 'El', 'Admin', 'admin@mail.com', '123', '1990-06-08', 0, 1, 0, 0),
  (3333, 'Lucas', 'Rodriguez', 'lucas@mail.com', '123', '1995-08-24', 3000, 0, 0, 0),
  (4444, 'Ana', 'Gonz�lez', 'ana@mail.com', '123', '1988-05-15', 500, 0, 0, 0),
  (5555, 'Mar�a', 'L�pez', 'maria@mail.com', '123', '1993-09-30', 200, 0, 0, 0),
  (6666, 'Luis', 'Fern�ndez', 'luis@mail.com', '123', '1994-12-10', 800, 0, 0, 0),
  (7777, 'Laura', 'Mart�nez', 'laura@mail.com', '123', '1991-07-18', 1500, 0, 0, 0),
  (8888, 'Carlos', 'G�mez', 'carlos@mail.com', '123', '1996-03-25', 1200, 0, 0, 0),
  (9999, 'Ana', 'Rodr�guez', 'ana.rodriguez@mail.com', '123', '1989-09-12', 2500, 0, 0, 0),
  (1010, 'Marcelo', 'L�pez', 'marcelo@mail.com', '123', '1997-11-28', 300, 0, 0, 0),
  (1112, 'Julia', 'Torres', 'julia@mail.com', '123', '1993-02-04', 1800, 0, 0, 0),
  (1213, 'Mariano', 'Garc�a', 'mariano@mail.com', '123', '1995-06-22', 5000, 0, 0, 0),
  (1314, 'Gabriela', 'L�pez', 'gabriela@mail.com', '123', '1990-10-08', 700, 0, 0, 0),
  (1415, 'Federico', 'P�rez', 'federico@mail.com', '123', '1994-04-16', 1000, 0, 0, 0),
  (1516, 'Carolina', 'Fern�ndez', 'carolina@mail.com', '123', '1991-08-14', 250, 0, 0, 0),
  (1617, 'Luciana', 'Gonz�lez', 'luciana@mail.com', '123', '1988-12-30', 3500, 0, 0, 0),
  (1718, 'Mart�n', 'Mart�nez', 'martin@mail.com', '123', '1997-03-17', 900, 0, 0, 0),
  (1819, 'Paula', 'G�mez', 'paula@mail.com', '123', '1992-09-24', 2000, 0, 0, 0),
  (1920, 'Diego', 'Rodr�guez', 'diego.rodriguez@mail.com', '123', '1996-01-11', 3000, 0, 0, 0),
  (2021, 'Sof�a', 'L�pez', 'sofia@mail.com', '123', '1993-05-28', 600, 0, 0, 0),
  (2122, 'Agust�n', 'Torres', 'agustin@mail.com', '123', '1989-11-01', 1400, 0,0,0)
   
-- Tabla SALAS
INSERT INTO SALAS (ubicacion, capacidad)
VALUES
  ('Olivos', 100),
  ('San Isidro', 200),
  ('Caballito', 500),
  ('Palermo', 300),
  ('Recoleta', 150),
  ('Belgrano', 100),
  ('La Plata', 200),
  ('Mar del Plata', 250),
  ('C�rdoba', 180),
  ('Rosario', 120),
  ('Mendoza', 160),
  ('Tigre', 80),
  ('Quilmes', 110),
  ('San Miguel', 140),
  ('Lomas de Zamora', 90),
  ('Mor�n', 130),
  ('Avellaneda', 100),
  ('Banfield', 70),
  ('La Matanza', 200)

-- Tabla PELICULAS
INSERT INTO PELICULAS (nombre, descripcion, sinopsis, poster, duracion)
VALUES
  ('Toy Story', 'Pelicula de juguetes.', 'Juguetes', ' ', 120),
  ('Mario Bros', 'Its me Mario!', 'Nintendo', ' ', 100),
  ('Mario 2', 'Its me Mario2!', 'Nintendo2', ' ', 110),
  ('Rapido y Furioso 10', 'Autitos chocadores', 'Carreras y Acci�n', ' ', 150),
 ('Avengers: Endgame', 'Los h�roes luchan contra Thanos', 'Acci�n y Superh�roes', ' ', 180),
  ('La La Land', 'Historia de amor y m�sica', 'Drama y Romance', ' ', 128),
  ('Jurassic Park', 'Parque tem�tico de dinosaurios', 'Aventura y Ciencia Ficci�n', ' ', 127),
  ('El Padrino', 'Mafia y crimen organizado', 'Drama y Crimen', ' ', 175),
  ('Harry Potter y la piedra filosofal', 'Magia y aventuras', 'Fantas�a y Aventura', ' ', 152),
  ('Titanic', 'Tr�gica historia de amor en el Titanic', 'Drama y Romance', ' ', 194),
  ('The Dark Knight', 'Batman contra el Joker', 'Acci�n y Superh�roes', ' ', 152),
  ('Forrest Gump', 'Historia de vida y superaci�n', 'Drama y Comedia', ' ', 142),
  ('Pulp Fiction', 'Historias entrelazadas de criminales', 'Drama y Crimen', ' ', 154),
  ('El Se�or de los Anillos: La Comunidad del Anillo', 'Aventuras en la Tierra Media', 'Fantas�a y Aventura', ' ', 178),
  ('Matrix', 'Realidad virtual y lucha contra las m�quinas', 'Ciencia Ficci�n y Acci�n', ' ', 136),
  ('El Rey Le�n', 'Historia de leones', 'Animaci�n y Aventura', ' ', 88),
  ('Interestelar', 'Viajes espaciales y agujeros negros', 'Ciencia Ficci�n y Aventura', ' ', 169),
  ('El Gran Gatsby', 'Ambici�n y decadencia en los a�os 20', 'Drama y Romance', ' ', 143),
  ('Gladiador', '�pica historia de un gladiador romano', 'Acci�n y Drama', ' ', 155),
  ('E.T. el Extraterrestre', 'Amistad entre un ni�o y un extraterrestre', 'Ciencia Ficci�n y Aventura', ' ', 115)

-- Tabla FUNCIONES
INSERT INTO FUNCIONES (fecha, asientos_disponibles, costo, id_sala, id_pelicula)
VALUES
  ('2023-06-15 09:00:00.000', 2000.0, 200, 1, 1),
  ('2023-06-16 12:00:00.000', 2500.50, 150, 1, 2),
  ('2023-06-17 16:30:00.000', 1500, 250, 2, 2),
  ('2023-06-18 20:30:00.000', 1000.25, 175, 2, 2),
  ('2023-06-14 21:00:00.000', 2200.50, 300, 2, 3),
  ('2023-05-27 21:00:00.000', 2200, 300, 2, 3),
  ('2023-06-19 14:00:00.000', 1800, 200, 3, 3),
  ('2023-06-20 17:30:00.000', 1500, 180, 3, 4),
  ('2023-06-21 19:45:00.000', 1200, 250, 4, 4),
  ('2023-06-22 21:15:00.000', 1000, 175, 4, 4),
  ('2023-06-23 18:30:00.000', 2000, 300, 1, 1),
  ('2023-06-24 15:45:00.000', 2200, 280, 1, 2),
  ('2023-06-25 20:00:00.000', 1900, 220, 2, 3),
  ('2023-06-26 12:30:00.000', 1700, 190, 2, 2),
  ('2023-06-27 16:15:00.000', 1400, 230, 3, 1),
  ('2023-06-28 19:30:00.000', 1200, 200, 3, 2),
  ('2023-06-29 21:45:00.000', 1000, 250, 4, 3),
  ('2023-06-30 15:00:00.000', 2200, 300, 4, 2),
  ('2023-07-01 18:15:00.000', 1900, 270, 1, 3),
  ('2023-07-02 13:30:00.000', 1700, 230, 1, 4),
  ('2023-07-03 17:45:00.000', 1400, 190, 2, 1)

-- Tabla USUARIOSFUNCIONES
INSERT INTO USUARIOSFUNCIONES (id_usuario, id_funcion, cantidad_entradas_compradas)
VALUES
  (1, 1, 1),
  (1, 2, 4),
  (1, 3, 1),
  (3, 4, 3),
  (3, 5, 2),
   (2, 6, 2),
  (2, 7, 3),
  (2, 8, 1),
  (4, 9, 2),
  (4, 10, 4),
  (4, 11, 2),
  (6, 12, 3),
  (6, 13, 1),
  (6, 14, 4),
  (8, 15, 2),
  (8, 16, 3),
  (8, 17, 1),
  (10, 18, 4),
  (10, 19, 2),
  (10, 20, 3)
