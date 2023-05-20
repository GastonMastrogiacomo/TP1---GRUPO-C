Consigna:
- Agregar persistencia de datos al Trabajo Pr�ctico 1, de modo que los mismos se almacenen en una base de datos (si bien en la c�tedra vemos SQL, pueden utilizar el motor que prefieran). Para ello se debe utilizar ADO.NET, queda prohibido el uso de cualquier otro tipo de tecnolog�a, incluyendo Entity Framework. NO se pueden utilizar Data Sets en esta entrega, la implementaci�n debe ser a trav�s de DataReader. Se recomienda crear una tabla por cada entidad y mapear las relaciones (Foreing Keys) seg�n corresponda.
- Se debe implementar de forma completa la l�gica del programa, es decir, se deben completar todos los circuitos descriptos previamente (en el TP1) como condici�n para aprobar.
- Se debe almacenar la cantidad de entradas compradas por usuario para una determinada funci�n en la tabla intermedia de la relaci�n muchos a muchos que existe entre las clases Usuario y Funci�n. Este valor almacenado se debe tener en cuenta a la hora de generar la devoluci�n de la entrada, de modo que si el usuario devuelve TODAS las entradas debe ser eliminado de la lista de clientes de esa funci�n y viceversa.
- Se debe deshabilitar la opci�n para registrarse como administrador, se podr�n crear usuarios administradores por defecto en el script que genera la base de datos.


Condiciones de entrega:
La soluci�n completa con todo el c�digo se debe entregar en un archivo .zip con nombre TP2 � Grupo X. Reemplazar X por identificador del grupo (nombre o n�mero).
Se debe incluir un script base.sql para la generaci�n de la base con el esquema implementado (incluir datos de prueba de ser posible). No entregar este script impide la correcci�n del trabajo.
Se debe incluir dentro del .zip un archivo �ReadMe� que explique c�mo utilizar ambos programas y cualquier aclaraci�n que consideren necesaria o decisi�n de dise�o que hayan tomado (puede ser en formato Word, txt, Excel, etc. No se eval�a presentaci�n pero si contenido del mismo).
La entrega se debe realizar por mail a mi casilla: walter.gomez@davinci.edu.ar
El sujeto debe ser: Plataformas de programaci�n: TP2 � Entrega grupo X. Reemplazar X por identificador del grupo (nombre o n�mero).
El cuerpo debe contener el detalle de los alumnos que componen el grupo, uno solo de ellos hace la entrega por el grupo pero debe poner en copia al resto, siendo responsabilidad de todos la entrega del trabajo.
La fecha de entrega es 19/05/23. Entregar fuera de t�rmino afecta sobre la nota del trabajo pr�ctico.
Tengan en cuenta que la entrega se puede complicar ya que el mail no acepta archivos .EXE aun si los mismos est�n dentro de otro archivo .zip. Tambi�n pueden compartir su proyecto por drive o enviarme el link de un repositorio.
El proyecto debe compilar tal como fue entregado, caso contrario, ser� desaprobado.

Quedo a su disposici�n ante cualquier consulta.





### Correcciones TP-1:
	
	//<s>Texto aca se ve tachado</s>

COSAS A COMPLETAR:

- En las clases modelo, por ejemplo, Usuario, lo que hicieron de devolver una lista de funciones clon 
y poner m�todos para Agregar o Quitar una funci�n est� correcto a 
nivel programaci�n ortodoxa pero desafortunadamente, puede que les complique las cosas m�s adelante.
Dejen que sea public List<Funcion> MisFunciones { get; set; } y que Cine se encargue del ABM de forma centralizada, despu�s de todo, Cine 
es la clase l�gica y est� bien que pueda modificar estas listas (no ser�a correcto que lo hagan las clases de vista). 



COSAS COMPLETADAS:

	- (ModificarFuncion aqu� est� dem�s, lo pueden sacar)

	- Clase Funci�n: No entiendo CantidadClientes, si lo usan como cantidad de entradas compradas, se deber�a inicializar en 0 
	y no pasar como par�metro del constructor.

	- EliminarFuncion: Para qu� buscan la pel�cula de la funci�n? Ya la tienen, es func.MiPelicula. Idem Sala.

	Se refiere a la linea 371 de PantallaABMAdmin con esto:
	- ModificarFuncion: El admin podr�a modificar todo menos la lista de clientes y CantidadClientes por consecuencia, dicho esto,
	no me gusta lo que hace la vista: 
	List<Funcion> funciones = miCine.MostrarFunciones();
	Funcion func = funciones.FirstOrDefault(f => f.ID == ID);
	No ser�a necesario hacer esto si tenemos en cuenta lo dicho.
	ModificarFuncion(ID, salaSelectedID, peliSelectedID, Fecha, Costo)
	es suficiente, el resto se mantiene de acuerdo al objeto original que maneja Cine. Lo marco aqu�, aplica para otros modificar , por ejemplo, 
	ModificarPelicula.

	- DevolverEntradaFuncionNotNull: Cuidado, deber�a eliminar el usuario s�lo si devuelve TODAS las entradas que compr� para esa funci�n.

	- EliminarSala: Cuidado, setear la Sala de la funci�n en null nos puede generar problemas, lo mejor en ese caso ser�a llamar a EliminarFuncion.
	Mismo para otros eliminar, cuidado con los null.

	- BuscarFuncion: Excelente pero estar�a bueno que sea opcional completar todos los campos. 
	Sin hacer la combinatoria de todas las opciones, traten de mandar flags desde la vista al cine (pueden ser nulls) para indicar si el
	usuario complet� o no ese campo de la b�squeda y entonces en los if filtran s�lo si ese campo no es flag.

PREGUNTAR AL PROFE:

	- Otro tema importante, las validaciones de Input bien las puede hacer la vista, es correcto que la vista valide 
	que el usuario haya completado todos los campos de un formulario, no es correcto que valide que el usuario tenga saldo 
	suficiente para comprar las entradas (eso le corresponde a Cine) pero s� todo lo que tiene que ver con inputs.

	- PantallaPrincipal: Los botones de iniciar sesi�n o registrarse no me anduvieron, no veo que tengan oyentes asignados, est� la
	implementaci�n hecha en la clase, es correcta pero no est�n vinculados los botones con los m�todos oyentes.


ANDY:
	
	- ObtenerFuncionPorId: No me gusta que pasemos un objeto a la vista, tienen otros "ObtenerPorID" definidos pero no los usan, este s� y la
	verdad no me gusta.


LUCKY:

    - Clase Cine: Traten de no usar MessageBox ac�, de �ltima pueden devolver un string y mostrarlo como cartel o 
    un flag, por ejemplo, 0 = ok, 1 = error, 2 = datos incompletos. STATUS CODES

GASTI: 


