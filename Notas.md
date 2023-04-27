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
-Lucas 27/04:
	*PantallaRegistro: Ya genera alta de usuario. Se agrega pop-up confirmacion de alta.
	*PantallaLogin: Se modifica Label "Nombre" por "Email", se modifica boton "Registro" por "Volver", se agrega funcionalidad a
	                 este ultipo pero al ir y volver, en la pantalla principal desaparecen los botones y solo queda "Mi perfil" (Revisar hide de botones).
	*ContenedorPantalla: Se integra sentencia para la funcionalidad de boton "Volver" de PantallaLogin.