
CORRECCIONES PARA TP3 (LOS QUE ESTEN EN AZUL ESTAN YA CORREGIDOS):
 
    -UsuarioFuncion: OJO no est�n guardando las referencias al objeto, falta el usuario y la funci�n como referencia. 
    NO alcanza con s�lo tener los IDs, cuidado con esto para el TP3.

    -vincularClases deber�a ser privado. Ac� se deber�an vincular los usuarios y las funciones con el objeto  UsuarioFuncion correspondiente.
     En TP3 esto se soluciona con los include, revisen esto.

 -AgregarUsuario: Las verificaciones de tipo �complet� el usuario el campo? eso lo puede validar la vista! 
 �El usuario tiene cr�dito para comprar entradas? eso s� lo valida cine. La vista valida los inputs.

 -ModificarUsuario: Cuidado con el �rden de las verificaciones, primero insertamos en la base y luego verificamos que los campos no est�n vac�os? 
  Tocar la lista de mis funciones del usuario en este m�todo no tiene sentido.

 -EliminarUsuario: Cuidado, DevolverEntrada no va a permitir ejecutar si el usuario tiene entradas ya vencidas, tiene sentido para 
  ese m�todo pero miren el contexto, de verdad no queremos dejar eliminar un usuario s�lo porque tiene entradas para funciones que ya pasaron?

     -EliminarFuncion: Ya tienen la referencia la funci�n (func), entonces el doble for de abajo NO VA, simplemente recorren los 
      clientes y hacen user.MisFunciones.Remove(func); Falta devolver el dinero a los usuarios si la funci�n todav�a pas�.

 -ModificarFuncion: Cuidado, buscan nueva pel�cula y nueva sala pero no validan si es la misma que la anterior, si es la misma 
  no hay que hacer nada porque inserta duplicado sino hay que eliminar la funci�n de la sala vieja y pel�cula vieja y 
  agregar lo nuevo (esto �ltimo s� lo est�n haciendo pero no la parte de eliminar lo viejo).

 -EliminarSala: De nuevo, orden de las comparaciones, en este caso el orden de los factores s� altera el producto. 
  Primero verifico null, luego opero con la DB. Falta eliminar la funci�n, la est�n quitando de la lista de la sala, 
  esto est� OK pero falta llamar a  EliminarFuncion.

 -EliminarPelicula: IDEM EliminarSala.

 -ModificarSala: De nuevo, modificar la lista de funciones aqu� estar�a dem�s.

 -ModificarPelicula: IDEM  ModificarSala.

 -cargarCredito EN DAL no SUMA cr�dito sino que sobreescribe, en ese caso tendr�an que mandar importe+user.Credito como par�metro.

 -[CORREGIDO] ComprarEntrada: La vista tiene una referencia al usuario actual?! Como mucho podr� tener un ID pero 
  no el objeto y en todo caso, ser�a m�s simple que eso lo guarde Cine al momento de loguearse en un atributo privado, luego 
  las operaciones de compra, devoluci�n, etc. no piden usuario porque se entiende que aplican sobre el usuario 
  actual (que ya cine tiene guardado en UsuarioActual).

     -MostrarUsuarios: NOOO! jaja error muy grave este. La inicializaci�n se hace SOLO UNA VEZ, luego se muestra lo que hay 
      en memoria que debe ser lo mismo que hay en la base. OJO con esto para TP3, el LOAD en EF se hace s�lo una vez. Ac� era tan simple 
      como devolver Usuarios.ToList(); nada m�s. APLICA PARA TODOS LOS MOSTRAR DEBAJO.

    -ObtenerFuncionPorId: M�s les vale que no lo usen.

 -BuscarFuncion: Rebuscado je.

  foreach (Funcion fun in Funciones)

  {
    if (!string.IsNullOrWhiteSpace(pelicula) && fun.MiPelicula.Nombre.Contains(pelicula))
    {
        funcionesEncontradas.Add(fun);
    }
    if (!string.IsNullOrWhiteSpace(ubicacion)&& fun.MiSala.Ubicacion.Equals(ubicacion))
    {
        funcionesEncontradas.Add(fun);
    }
    ....... SIGAN CON EL RESTO
   }
   return funcionesEncontradas;

 AHORA PIENSEN C�MO LO HACEMOS CON LINQ! (recuerden que podemos concatenar varios WHERE).

 -DevolverEntradaFuncionNotNull: cu�ntas query con LinQ por aqu�. a ver, esta query 
  est� bien: UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion); 
  Ahora, analicemos una de las tantas que hay: Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion); MAL, directamente 
  entrada.funci�n me deber�a dar la funci�n (claro, ustedes no guardaron las referencias a los objetos) tengan esto en cuenta para el TP3, 
  con solo esa query alcanza, el resto lo tengo que poder sacar a trav�s de las referencias.

 -Sigo en devolver entrada: Volvemos al primer parcial: funcion == userFunc? Da true o false? DA TRUE, ambos apuntan al mismo objeto! Entonces buscarla de nuevo no suma, no tiene sentido. PD: Que nombre complicado  userFunc no? suena a un objeto de tipo UsuarioFuncion pero en realidad es una funci�n... Cuidado con los nombres de las variables.

 -Sigo en devolver entrada: userFunc.CantidadClientes -= cantidadEntradas; Y userFunc.AsientosDisponibles += cantidadEntradas; DUPLICADO, si entra en el ELSE, esto se ejecuta DOS VECES, claramente el ELSE est� dem�s. Un IF NO debe tener OBLIGATORIAMENTE UN ELSE.

 -ComprarEntradaFuncionNotNull: La vista tiene la referencia a los objetos del sistema? NONO, cambiar, la vista tendr� que llamar a ComprarEntrada y con IDS solamente. Este m�todo debe ser PRIVATE.

 -Sigo con comprar entrada: user.MisFunciones.Add(funcion); deber�a ir luego de funcion.Clientes.Add(user); de lo contrario corren el riesgo de DUPLICAR el elemento en la lista.

 -agregarUsuarioFuncion: No me convence mucho, esto es ComprarEntrada.


 
 COSAS GRANDES QUE HAY QUE CAMBIAR:

  - Buscar Funciones
  - Hay que ver como cambiar devolver entrada, nos estamos complicando una locura

 

 Se implementaron los ABM's de todo y teoricamente el MyContext esta hecho, ver que no 
 explota nada y ponerse a pulir los ABM con las correcciones