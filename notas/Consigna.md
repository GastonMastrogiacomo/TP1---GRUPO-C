Consigna:
- Agregar persistencia de datos al Trabajo Práctico 1, de modo que los mismos se almacenen en una base de datos (si bien en la cátedra vemos SQL, pueden utilizar el motor que prefieran). Para ello se debe utilizar ADO.NET, queda prohibido el uso de cualquier otro tipo de tecnología, incluyendo Entity Framework. NO se pueden utilizar Data Sets en esta entrega, la implementación debe ser a través de DataReader. Se recomienda crear una tabla por cada entidad y mapear las relaciones (Foreing Keys) según corresponda.
- Se debe implementar de forma completa la lógica del programa, es decir, se deben completar todos los circuitos descriptos previamente (en el TP1) como condición para aprobar.
- Se debe almacenar la cantidad de entradas compradas por usuario para una determinada función en la tabla intermedia de la relación muchos a muchos que existe entre las clases Usuario y Función. Este valor almacenado se debe tener en cuenta a la hora de generar la devolución de la entrada, de modo que si el usuario devuelve TODAS las entradas debe ser eliminado de la lista de clientes de esa función y viceversa.
- Se debe deshabilitar la opción para registrarse como administrador, se podrán crear usuarios administradores por defecto en el script que genera la base de datos.


Condiciones de entrega:
La solución completa con todo el código se debe entregar en un archivo .zip con nombre TP2 – Grupo X. Reemplazar X por identificador del grupo (nombre o número).
Se debe incluir un script base.sql para la generación de la base con el esquema implementado (incluir datos de prueba de ser posible). No entregar este script impide la corrección del trabajo.
Se debe incluir dentro del .zip un archivo “ReadMe” que explique cómo utilizar ambos programas y cualquier aclaración que consideren necesaria o decisión de diseño que hayan tomado (puede ser en formato Word, txt, Excel, etc. No se evalúa presentación pero si contenido del mismo).
La entrega se debe realizar por mail a mi casilla: walter.gomez@davinci.edu.ar
El sujeto debe ser: Plataformas de programación: TP2 – Entrega grupo X. Reemplazar X por identificador del grupo (nombre o número).
El cuerpo debe contener el detalle de los alumnos que componen el grupo, uno solo de ellos hace la entrega por el grupo pero debe poner en copia al resto, siendo responsabilidad de todos la entrega del trabajo.
La fecha de entrega es 19/05/23. Entregar fuera de término afecta sobre la nota del trabajo práctico.
Tengan en cuenta que la entrega se puede complicar ya que el mail no acepta archivos .EXE aun si los mismos están dentro de otro archivo .zip. También pueden compartir su proyecto por drive o enviarme el link de un repositorio.
El proyecto debe compilar tal como fue entregado, caso contrario, será desaprobado.

Quedo a su disposición ante cualquier consulta.





### Correcciones TP-1:
	
	//<s>Texto aca se ve tachado</s>

COSAS A COMPLETAR:

- En las clases modelo, por ejemplo, Usuario, lo que hicieron de devolver una lista de funciones clon 
y poner métodos para Agregar o Quitar una función está correcto a 
nivel programación ortodoxa pero desafortunadamente, puede que les complique las cosas más adelante.
Dejen que sea public List<Funcion> MisFunciones { get; set; } y que Cine se encargue del ABM de forma centralizada, después de todo, Cine 
es la clase lógica y está bien que pueda modificar estas listas (no sería correcto que lo hagan las clases de vista). 



COSAS COMPLETADAS:

	- (ModificarFuncion aquí está demás, lo pueden sacar)

	- Clase Función: No entiendo CantidadClientes, si lo usan como cantidad de entradas compradas, se debería inicializar en 0 
	y no pasar como parámetro del constructor.

	- EliminarFuncion: Para qué buscan la película de la función? Ya la tienen, es func.MiPelicula. Idem Sala.

	Se refiere a la linea 371 de PantallaABMAdmin con esto:
	- ModificarFuncion: El admin podría modificar todo menos la lista de clientes y CantidadClientes por consecuencia, dicho esto,
	no me gusta lo que hace la vista: 
	List<Funcion> funciones = miCine.MostrarFunciones();
	Funcion func = funciones.FirstOrDefault(f => f.ID == ID);
	No sería necesario hacer esto si tenemos en cuenta lo dicho.
	ModificarFuncion(ID, salaSelectedID, peliSelectedID, Fecha, Costo)
	es suficiente, el resto se mantiene de acuerdo al objeto original que maneja Cine. Lo marco aquí, aplica para otros modificar , por ejemplo, 
	ModificarPelicula.

	- DevolverEntradaFuncionNotNull: Cuidado, debería eliminar el usuario sólo si devuelve TODAS las entradas que compró para esa función.

	- EliminarSala: Cuidado, setear la Sala de la función en null nos puede generar problemas, lo mejor en ese caso sería llamar a EliminarFuncion.
	Mismo para otros eliminar, cuidado con los null.

	- BuscarFuncion: Excelente pero estaría bueno que sea opcional completar todos los campos. 
	Sin hacer la combinatoria de todas las opciones, traten de mandar flags desde la vista al cine (pueden ser nulls) para indicar si el
	usuario completó o no ese campo de la búsqueda y entonces en los if filtran sólo si ese campo no es flag.

PREGUNTAR AL PROFE:

	- Otro tema importante, las validaciones de Input bien las puede hacer la vista, es correcto que la vista valide 
	que el usuario haya completado todos los campos de un formulario, no es correcto que valide que el usuario tenga saldo 
	suficiente para comprar las entradas (eso le corresponde a Cine) pero sí todo lo que tiene que ver con inputs.

	- PantallaPrincipal: Los botones de iniciar sesión o registrarse no me anduvieron, no veo que tengan oyentes asignados, está la
	implementación hecha en la clase, es correcta pero no están vinculados los botones con los métodos oyentes.


ANDY:
	
	- ObtenerFuncionPorId: No me gusta que pasemos un objeto a la vista, tienen otros "ObtenerPorID" definidos pero no los usan, este sí y la
	verdad no me gusta.


LUCKY:

    - Clase Cine: Traten de no usar MessageBox acá, de última pueden devolver un string y mostrarlo como cartel o 
    un flag, por ejemplo, 0 = ok, 1 = error, 2 = datos incompletos. STATUS CODES

GASTI: 


