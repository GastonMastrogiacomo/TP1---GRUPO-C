
CORRECCIONES PARA TP3 (LOS QUE ESTEN EN AZUL ESTAN YA CORREGIDOS):
 
    -UsuarioFuncion: OJO no están guardando las referencias al objeto, falta el usuario y la función como referencia. 
    NO alcanza con sólo tener los IDs, cuidado con esto para el TP3.

    -vincularClases debería ser privado. Acá se deberían vincular los usuarios y las funciones con el objeto  UsuarioFuncion correspondiente.
     En TP3 esto se soluciona con los include, revisen esto.

 -AgregarUsuario: Las verificaciones de tipo ¿completó el usuario el campo? eso lo puede validar la vista! 
 ¿El usuario tiene crédito para comprar entradas? eso sí lo valida cine. La vista valida los inputs.

 -ModificarUsuario: Cuidado con el órden de las verificaciones, primero insertamos en la base y luego verificamos que los campos no estén vacíos? 
  Tocar la lista de mis funciones del usuario en este método no tiene sentido.

 -EliminarUsuario: Cuidado, DevolverEntrada no va a permitir ejecutar si el usuario tiene entradas ya vencidas, tiene sentido para 
  ese método pero miren el contexto, de verdad no queremos dejar eliminar un usuario sólo porque tiene entradas para funciones que ya pasaron?

     -EliminarFuncion: Ya tienen la referencia la función (func), entonces el doble for de abajo NO VA, simplemente recorren los 
      clientes y hacen user.MisFunciones.Remove(func); Falta devolver el dinero a los usuarios si la función todavía pasó.

 -ModificarFuncion: Cuidado, buscan nueva película y nueva sala pero no validan si es la misma que la anterior, si es la misma 
  no hay que hacer nada porque inserta duplicado sino hay que eliminar la función de la sala vieja y película vieja y 
  agregar lo nuevo (esto último sí lo están haciendo pero no la parte de eliminar lo viejo).

 -EliminarSala: De nuevo, orden de las comparaciones, en este caso el orden de los factores sí altera el producto. 
  Primero verifico null, luego opero con la DB. Falta eliminar la función, la están quitando de la lista de la sala, 
  esto está OK pero falta llamar a  EliminarFuncion.

 -EliminarPelicula: IDEM EliminarSala.

 -ModificarSala: De nuevo, modificar la lista de funciones aquí estaría demás.

 -ModificarPelicula: IDEM  ModificarSala.

 -cargarCredito EN DAL no SUMA crédito sino que sobreescribe, en ese caso tendrían que mandar importe+user.Credito como parámetro.

 -[CORREGIDO] ComprarEntrada: La vista tiene una referencia al usuario actual?! Como mucho podrá tener un ID pero 
  no el objeto y en todo caso, sería más simple que eso lo guarde Cine al momento de loguearse en un atributo privado, luego 
  las operaciones de compra, devolución, etc. no piden usuario porque se entiende que aplican sobre el usuario 
  actual (que ya cine tiene guardado en UsuarioActual).

     -MostrarUsuarios: NOOO! jaja error muy grave este. La inicialización se hace SOLO UNA VEZ, luego se muestra lo que hay 
      en memoria que debe ser lo mismo que hay en la base. OJO con esto para TP3, el LOAD en EF se hace sólo una vez. Acá era tan simple 
      como devolver Usuarios.ToList(); nada más. APLICA PARA TODOS LOS MOSTRAR DEBAJO.

    -ObtenerFuncionPorId: Más les vale que no lo usen.

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

 AHORA PIENSEN CÓMO LO HACEMOS CON LINQ! (recuerden que podemos concatenar varios WHERE).

 -DevolverEntradaFuncionNotNull: cuántas query con LinQ por aquí. a ver, esta query 
  está bien: UsuarioFuncion entrada = misUsuarioFuncion.FirstOrDefault(uf => uf.idUsuario == user.ID && uf.idFuncion == idFuncion); 
  Ahora, analicemos una de las tantas que hay: Funcion funcion = Funciones.FirstOrDefault(f => f.ID == idFuncion); MAL, directamente 
  entrada.función me debería dar la función (claro, ustedes no guardaron las referencias a los objetos) tengan esto en cuenta para el TP3, 
  con solo esa query alcanza, el resto lo tengo que poder sacar a través de las referencias.

 -Sigo en devolver entrada: Volvemos al primer parcial: funcion == userFunc? Da true o false? DA TRUE, ambos apuntan al mismo objeto! Entonces buscarla de nuevo no suma, no tiene sentido. PD: Que nombre complicado  userFunc no? suena a un objeto de tipo UsuarioFuncion pero en realidad es una función... Cuidado con los nombres de las variables.

 -Sigo en devolver entrada: userFunc.CantidadClientes -= cantidadEntradas; Y userFunc.AsientosDisponibles += cantidadEntradas; DUPLICADO, si entra en el ELSE, esto se ejecuta DOS VECES, claramente el ELSE está demás. Un IF NO debe tener OBLIGATORIAMENTE UN ELSE.

 -ComprarEntradaFuncionNotNull: La vista tiene la referencia a los objetos del sistema? NONO, cambiar, la vista tendrá que llamar a ComprarEntrada y con IDS solamente. Este método debe ser PRIVATE.

 -Sigo con comprar entrada: user.MisFunciones.Add(funcion); debería ir luego de funcion.Clientes.Add(user); de lo contrario corren el riesgo de DUPLICAR el elemento en la lista.

 -agregarUsuarioFuncion: No me convence mucho, esto es ComprarEntrada.


 
 COSAS GRANDES QUE HAY QUE CAMBIAR:

  - Buscar Funciones
  - Hay que ver como cambiar devolver entrada, nos estamos complicando una locura

 

 Se implementaron los ABM's de todo y teoricamente el MyContext esta hecho, ver que no 
 explota nada y ponerse a pulir los ABM con las correcciones