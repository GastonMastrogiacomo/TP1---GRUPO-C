# TP1 - GRUPO C

 En la vista no podes hacer nada sino estas logueado

 La clase Cine la interpretaremos como Hoyts (dueño del cine completo)

## TODO

- ver si los métodos de ABM de todos los tipos deberian retornar un bool, string o void para que el front actue en base a eso.
- todos los metodos de modificacion de una base de datos deberian estar encapsulados en bloques try catch
- ver las funciones de admin para diferenciarlas del usuario comun
- un admin no deberia ni que cargar credito
- supongamos que no tengo credito suficiente para comprar la entrada, entonces sale una advertencia que me da la opcion de cargarCreditos()
- ver los metodos get de devolucion de listas.
- falta finalizar pantalla ABM Admin
- Importante -> en la pantalla ABM Admin hasta que no se haga click en "modificar" no se va a guardar la nueva lsita de funciones
- falta implementar los metodos ABM en pantalla Admin
- falta actualizar la funcion con el usuario
- falta crear pantalla de "mi perfil"

## Updates

- Andy 22/04: Se crea la clase Reserva para la compra de entradas. ver lo de la compra de entradas. Que compra el usuario? -> LISTO 22/04
- Lucas 23/04: Se agrega un primer diseño de form's, totalmente a modificar... form 1->contenedor padre, form2-> pantalla princial, form3->pantalla de registro.
  Se modifica iniciar sesion() en cine, se comenta metodo de mostrarfuncion para poder correr prog
- Andy 24/04: 
	* agrega separación en carpetas y reorganizaación de información en notas
	* usuarios de prueba
	* validación de checkbox admin en IniciarSesion()
	* Renombra método de login a UsuarioComunLogueado()
	* agrega AbrirLoginAdmin() --> abre Form6
	* agrega validaciones al botón de Login en Form 4 para que inicie el componente correspondiente dependiendo si es admin o no
	* crea form6
- Lucas 25/04 se implemento Form3 (pantalla de registro) al boton "Registro" de la pantalla principal.
 Tambien se agrego boton "Volver "para regresar, y se modifico constructor y atributo ID de Usuario, agregando un autoincremental y para que este setee ID.
- Andy 26/04 Parte 1:
	* Clase cine: se agrega el metodo mostrarUsuarios()
	* Clase usuari: se agrega metodo toString() que devuelve un string []
	* PantallaABMAdmin:
		* se agrega las pestañas
		* el datagrid de usuarios 
		* se carga el datagrid con informacion pre-cargada
		* Se modifica la visualizacion de datos
		* se agrega funcionalidad de doble click en lista para que guarde el formulario
- Andy 26/04 Parte 2:
	* Clase Usuario: se agrega ABM de funcion y se modifica Alta de Reserva
	* Clase Sala: se le agrega UltimoID
	* Clase Pelicula: se le agrega UltimoID
	* Clase Funcion: se le agrega UltimoID
	* Clase Cine: Se agregan objetos de prueba y se agregan metodos para obtener Funcion y Usuario por ID
	* Front: 
		* se agrega una pantalla nueva para cargar las funciones al usuario
		* se agrega UsuarioAuxiliar a la pantalla de ABM de admin para poder cargar la lsita en la nueva pantalla
		* se codea toda la pantalla nueva entera y se agregan las funcionalidades.
		* se agregan posiblidades de volver para atras en la pantalla nueva y todos los metodos delegados se linkean con el contendor de pantallas.
- Lucas 27/04:
	* PantallaRegistro: Ya genera alta de usuario. Se agrega pop-up confirmacion de alta.
	* PantallaLogin: Se modifica Label "Nombre" por "Email", se modifica boton "Registro" por "Volver", se agrega funcionalidad a
	                 este ultipo pero al ir y volver, en la pantalla principal desaparecen los botones y solo queda "Mi perfil" (Revisar hide de botones).
	* ContenedorPantalla: Se integra sentencia para la funcionalidad de boton "Volver" de PantallaLogin.

- Andy 27/04:
	* Corrige un bug en la modificacion de usuarios que pisaba al primero de la lista siempre.
	* Crea PantallaEdicionFunciones para la edicion de las funciones xD

FALTA CORREGIR:
	- mover MostrarFuncionesProximas() y MostrarFuncionesPasadas() a Usuario ya que son metodos de esta clase.


Pantalla principal:
	-En esta pantalla se pueden ver una lista de Peliculas, Salas y Funciones. Hacer doble click en una pelicula especifica 
	,clickear la ventana de funciones te mostrara estas funciones filtradas;Lo mismo sucede con Salas.
	-Hacer doble click en una funcion selecciona dicha funcion, por lo que uno puede hacer click en el 
	boton de comprar entrada (Uno debe estar logueado y solo puede comprar hasta 50 entradas)
	-El boton de Refrescar actualiza todas las listas de Salas,Funciones y Peliculas , por lo que si uno utiliza el filtro debe tocar refrescar para volver a la visualizacion normal.
	-Al mismo tiempo, el boton de refrescar actualiza la cantidad de credito que tiene un usuario si es que se realizo una compra previamente.
	-En la parte superior se puede ver una barra donde uno puede completarla con la busqueda de funciones que desea ver.
	Esta puede ser buscada por ubicacion, fecha , rango de precio y no es necesario que se completen todos los campos (se pueden ingresar nombres parciales).
	- Si el usuario esta logueado ahora apareceran dos botones, uno que te deriva a la pantalla de MiPerfil y otro que permite cerrar sesion.

Pantalla Login:
	-En esta pantalla uno tiene que ingresar los datos correctos de login, si se equivoca al ingresar la contraseña se van aumentando la cantidad
	de intentos fallidos, cuando supera los 3 intentos la cuenta se bloquea.Si un usuario es administrador debe clickear en la opcion correspondiente ya que 
	es necesario para que le permita loguearse.
	-Si el Usuario no tiene una cuenta puede clicekar el boton de Registrarse lo cual lo deriva a la pantalla correspondiente donde ingresa
	sus datos y selecciona si es administrador o no (implementacion que se cambiara a medida que se avanza con la materia)

Pantalla Mi Perfil:
	
	Lado Usuario Normal:
		-Si el usuario no es administrador , se podran ver sus datos de registro (Los cuales pueden ser modificados) y la cantidad 
		de credito (actualmente se puede agregar credito sin repercusiones).
		-Debajo aparecen dos tablas con las funciones pasadas del usuario y las proximas, clickear en una funcion proxima y luego en el boton de devolver entrada
		devuelve todas las entradas que el cliente tiene para la funcion.

	Lado Usuario Administrador:
		-Si el usuario tiene el rol de administrador y selecciona el boton de mi perfil es derivado a una pantalla donde puede hacer el Alta,Baja y Modificacion
		de todas las Salas,Peliculas,Funciones y hasta Usuarios. Modificando todos los valores que sean necesarios.

Observaciones:
	-Las funciones tienen Una capacidad que es fija y muestra el maximo de personas que pueden ingresar , una cantidad de clientes que muestra
	cuantos han comprado entradas para dicha funcion y una llamada asientos disponibles que es la resta de estas dos.No es posible mas entradas
	que la cantidad de los asientos disponibles.
	-Logicamente cuando se devuelve una entrada la cantidad de clientes y asientos disponibles aumenta y se le devuelve el credito gastado al cliente.
	-El administrador puede agregar o quitarle funciones a un usuario cliente.