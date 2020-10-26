# noef  ![NuGet Version](http://img.shields.io/static/v1?label=Arsoftcr&message=La%20mejor%20tecnología&color=blue)

Realiza cualquier consulta  en mysql o postgres o sql server u oracle en forma asíncrona y retorna los resultados en una lista de Dictionary<string,object>


Se debe instalar el paquete nuget en visual studio o por consola: https://www.nuget.org/packages/noef  ![NuGet Version](http://img.shields.io/static/v1?label=Nuget&message=3.0.1&color=blue)

### Bases de datos soportadas:

|Base de Datos|Operaciones soportadas|
| ------------------- | ------------------- |
|MYSQL|SELECT,INSERT,UPDATE,DELETE|
|SQL SERVER|SELECT,INSERT,UPDATE,DELETE|
|POSTGRES|SELECT,INSERT,UPDATE,DELETE|
|ORACLE|SELECT,INSERT,UPDATE,DELETE|


Se debe crear una instancia con los datos de conexión e indicar el tipo de base de datos, opcionalmente se puede pasar la cadena como un string:
  
         Conexion conexion = new Conexion
        {
            Server= "xxx",
            Port="xx",//obligatorio, opcional solo  en sql
            BaseDatos="xxxx",//en oracle se pone el nombre del servicio
            Username= "xx",
            Password= "xxxx",
            Tipo=tipo.SQL // tipo.SQL, tipo.Oracle, tipo.Mysql, tipo.Postgres

        };

      
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.Payloads payload = new noef.Payloads();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:
           
           Dictionary<string,object> param = new Dictionary<string,object>();

            param.Add("@parametro","tests");
            
          var resultado=await payload.SelectFromDatabase(conexion,"select columna from loquesea  where columna=@parametro",param);
          //nota: En oracle se utiliza : en lugar de @
  Nota:También se puede realizar la operación pasando la cadena de conexión como un string:
  
          var resultado=await payload.SelectFromDatabase("cadenaConexion","select columna from loquesea  where columna=@parametro");
          //nota: En oracle se utiliza : en lugar de @
         
         
         
Los resultados se podrian acceder de la siguiente forma:

          resultado.foreach((x)=>{Console.WriteLine($"{x["columna"]}");});
          
Para realizar un insert,update o delete a la bd se necesita crear una instancia de la clase Payloads y pasarle un diccionario de datos con los parámetros y sus valores de la siguiente forma:


           noef.Payloads insert = new noef.Payloads();

            Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("@desc","testsql");

         var resultado = await insert.InsertOrUpdateOrDeleteDatabase(conexion,
         "insert into loquesea(Descripcion)values(@desc)",diccio);
         
         
         //nota: en oracle se deben utilizar los 2 puntos en lugar del arroba de la siguiente forma: diccio.Add(":desc","testsql");
         "insert into loquesea(Descripcion)values(:desc)"
                  

            if (resultado == 0)
            {
                // ERROR
            }
            else
            {
                // OK
            }
          
          
          
     
          
       
