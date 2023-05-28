# TP2 - GRUPO C

Cambios hechos por gaston el 21/5:

-Empiezo a integrar los cambios para implementar base de datos,creo la clase DAL que lo que va a hacer es ocuparse de todos los metodos ABM
pero del lado de la comunicacion con la base de datos, asi tenemos tanto en BD como Memoria los datos.

-Cree la carpeta properties con Resources, despues una vez que andy o lucas se descarguen los programas necesarios
hay que cambiar el Connection String de resources

-Cuando deje de trabajar en el tp voy a comentar todo asi no los confundo porque probablemente se va a romper todo y no va a compilar una mierda,
voy a anotar aca abajo que metodos implemente asi se entiende un poco mas.

-Los metodos cambiados voy a dejar en una region metido el codigo nuevo comentado porque si solo comento los cambios es un quilombo de formato

- Implemente el ABM para Usuarios,Peliculas y Salas.Falta el de Funciones pero hay que ver como hacemos con el tema de foreign keys y cosas a cambiar

-Implemente algunos de los metodos de Inicializar, ver el de funcion porque lo que pasamos por parametro puede ser un problema

AVISO:Muchos de estos metodos van a estar a medio terminar porque no pude crear la base de datos, va a ser medio un quilombo
pensar las relaciones y modificar algunas cosas pero la integracion es bastante facil una vez se entiende.



LISTO
    - ABM Usuario anda bien
    -Iniciar Sesion anda bien
    -Registrarse anda bien
    -Cargar Credito anda bien
    -Eliminar
    -ABM internos de funcion, usuario, sala y peliculas corregido
    -El refrescar de todos los metodos en la vista ABM admin no refresca a lo que tengo en la base de datos
    -    public List<Pelicula> MostrarPeliculas()
            {
                return Peliculas.ToList();
            }
    - Estos deberian refrescarse en base a lo que tengo en la BD
    -ABM Sala funciona correctamente
    -Comprar Entrada
    -Devolver Entrada


TESTEAR


FALTA
-ABM Funcion verificar y aplicar on delete cascade (o hardcodearlo)
-ABM Pelicula verificar (este creo que estaba bien ya)
- Hacer que el ABM se desencadene correctamente en las otras clases.
-Eliminar ObtenerFuncionPorID
-Ver que los filtros anden bien


Gaston: 
-Hice un poco de limpieza de comentarios y codigo innecesario, el ABM Funcion deberia funcionar, 
 hay que ver si anda el on delete cascade para que elimine las peliculas y salas vinculadas por id con funcioens.
-En caso de que no se pueda hacer es hacer un for loop que en el caso de que se elimine
una sala o funcion, busca en las Funciones las salas y peliculas con el mismo id y llamas a los metodos eliminar.

https://www.sqlshack.com/delete-cascade-and-update-cascade-in-sql-server-foreign-key/
https://stackoverflow.com/questions/4454861/how-do-i-edit-a-table-in-order-to-enable-cascade-delete