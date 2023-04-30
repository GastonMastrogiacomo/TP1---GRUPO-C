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