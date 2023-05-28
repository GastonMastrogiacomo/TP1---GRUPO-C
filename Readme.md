Readme TP-2:

IMPORTANTE!!!!!:
-Usar base.sql a la hora de cargar la base de datos con la informacion cargada.Esta se encuentra en la carpeta ScriptDB
-Cuando se crea la base de datos y se exporta el script , el directorio fue hecho en un disco F con un path que va a 
tener que  ser modificado!


-El Funcionamiento del sistema es en lineas generales el mismo (al menos desde un punto de vista visual) por lo que si 
se necesitan consignas de navegacion leer el Readme del TP-1 que se encuentra abajo de este cuerpo de texto.
-Tuvimos un problema con la conexion a la base de datos, no nos tomaba el valor de ConnectionStr dentro de Resources por lo que usamos un string para solucionarlo.
-Se integro la base de datos para todos los procedimientos, cuando hay algun tipo de ABM se hace una modificacion tanto en memoria como en base de datos.
-Al compilar, el sistema busca todos los datos guardados en la base de datos y va poblando los objetos con estos datos,luego
va creando las relaciones y haciendo las conecciones (Funcion se le agrega el objeto pelicula y sala, etc.)
-Ya no es necesario utilizar el checkbox de si es admin o no, si uno quiere modificar esto o ejecuta una query desde el SSMS o utiliza el ABM de los Admin.
-Se elimino el diccionario usado para ver la cantidad de entradas que tiene un usuario para cada funcion, ahora se utiliza
UsuariosFunciones como tabla intermedia que guarda este dato.
-Cantidad de clientes lo utilizamos para ver cuantas entradas se compraron, este dato luego se lo pasa a asientos disponibles
que es el resto de capacidad de sala y cantidad de clientes.Mantenemos estas dos propiedades al mismo tiempo para mas visibilidad pero no es estrictamente necesario.
-Cuando uno devuelve una entrada, ahora puede especificar cuantas quiere (antes te devolvia todas) si la cantidad devuelta
es igual a la cantidad total entonces se elimina la funcion de la lista de funciones del Usuario.
-Las Tablas estan vinculadas correctamente, cuando uno elimina una Sala o Pelicula se eliminan todas las Funciones que se daban
en dicha sala o que pasaban dicha pelicula.Tambien esto afecta la tabla UsuariosFunciones.
-Eliminar Sala y Pelicula no devuelven el costo al usuario ya que es algo que solo puede hacer el admin y no deberia suceder 
en un ambito real.
-Buscar Funcion ahora es opcional completar los campos.
-Se eliminaron todos los MessageBox del lado de la logica, se creo una clase Status Code que devuelve un codigo y
este lo toma la vista y devuelve un mensaje.
-Funcion y Usuario ya no tienen metodos de ABM dentro de sus clases, Cine se encarga de toda esa parte.
-A la hora de usar el filtro, muy de vez en cuando puede ser que se produzca un error, esto creemos que es por el debugger, 
cuando reinciamos el programa funciona correctamente.
-Es aconsejable a la hora de probar el sistema que se creen los objetos y se hagan pruebas con ellos, 
ya que puede haber un error en los datos que insertamos y no nos hayamos dado cuenta.
-Se corrigieron las observaciones hechas en el TP-1.





Readme TP-1:
	
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