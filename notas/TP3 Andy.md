# cambios

## General
- Estuve agregando returns y throws donde faltaba (lo anoto en el sitio igual).
- Las notas qe Gasti puso preguntando si estaba ok, las borre si estaba de acuerdo o agregue otra nota sino (hasta ahora no vi ninguna que no este de acuerdo)


## Cine.cs
### EliminarUsuario():
- se agregan throws para evitar repeticion de try catch y se agrega validacion en caso de que haya un error al DevolverEntradasUsuario(user)
- se agregan returns para devolver response

### EliminarFuncion():
- agrego try catch por si no se encuenrta la funcion
- me parece que no deberiamos borrar una funcion pasada dado que se debe mantener un historial. Es correcto borrar funciones nuevas. Además tener en cuenta que si editamos datos de un usuario y luego no actualizamos el contexto, no se guardaria totalmente la gestion. user.MisFunciones.Remove --> deberia estar antes de contexto.Usuarios.Update(user) para impactar (*A001)

### ModificarFuncion():
- agrego tipos de codigo de estado de respuesta
- salaNueva.MisFunciones.Add(func);
                                  
- peliculaNueva.MisFunciones.Add(func);
- los pongo antes de asignar miSala y miPelicula a la funcion

### EliminarSala():
- descomento la linea de contexto.Funciones.Remove(funcionActual);
- a la sala no es necesario sacarle la funcionActual porque luego la eliminamos.
- agrego validacion de error al eliminar la funcion

### EliminarPelicula():
- agrego validacion de error al eliminar la funcion
- descomento contexto.Funciones.Remove(funcionActual);

### ModificarPelicula()