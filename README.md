# noef
Realiza cualquier consulta sql en mysql,sql server,postgres y oracle en forma asíncrona y retorna los resultados en una lista de  objetos genéricos {columna=xxx,valor=xxx}


Se debe instalar el paquete nuget en visual studio o por consola: Install-Package noef -Version 1.0.0

Se debe crear una instancia con los datos de conexión a la base de datos, en este caso SQL Server:
  
        noef.models.ConexionSQL con = new noef.models.ConexionSQL { Servidor="localhost",BD="test",Usuario="sa",Password="sa" };
   
   
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.controllers.sql.Select consulta = new noef.controllers.sql.Select();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:

          var result=await consulta.SelectFromDatabase(con,"select * from nombreTabla");
          
          
          
          
       
