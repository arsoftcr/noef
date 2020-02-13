# noef
Realiza cualquier consulta sql en forma asíncrona y retorna los resultados en una lista de un objeto genérico {columna=xxx,valor=xxx}


Se debe instalar el paquete nuget en visual studio o por consola: Install-Package noef -Version 1.0.0

Se debe crear una instancia con los datos de conexión a la base de datos:
  
        noef.models.Conexion con = new noef.models.Conexion { Servidor="localhost",BD="test",Usuario="sa",Password="sa" };
   
   
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.controllers.selects sel = new noef.controllers.selects();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:

          var result=await sel.SelectFromDatabase(con,"select * from tabla");
          
          
          
          
       
