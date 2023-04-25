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
-Lucas 25/04 se implemento Form3 (pantalla de registro) al boton "Registro" de la pantalla principal.
 Tambien se agrego boton "Volver "para regresar, y se modifico constructor y atributo ID de Usuario, agregando un autoincremental y para que este setee ID.

//TODO
falta crear pantalla de admin (form 6)
falta crear pantalla de "mi perfil"

- 
