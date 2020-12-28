# noef  ![NuGet Version](http://img.shields.io/static/v1?label=Arsoftcr&message=La%20mejor%20tecnología&color=blue)

Realiza cualquier consulta  en mysql o postgres o sql server u oracle en forma asíncrona y retorna los resultados en un objeto JSON o alternativamente en un List<dynamic>()


Se debe instalar el paquete nuget en visual studio o por consola: https://www.nuget.org/packages/noef  ![NuGet Version](http://img.shields.io/static/v1?label=Nuget&message=3.0.1&color=blue)

### Bases de datos soportadas:

|Base de Datos|Operaciones soportadas|
| ------------------- | ------------------- |
|MYSQL|SELECT,INSERT,UPDATE,DELETE|
|SQL SERVER|SELECT,INSERT,UPDATE,DELETE|
|POSTGRES|SELECT,INSERT,UPDATE,DELETE|
|ORACLE|SELECT,INSERT,UPDATE,DELETE|


Se debe crear una instancia con los datos de conexión e indicar el tipo de base de datos, opcionalmente se puede pasar la cadena como un string:
  
         noef.models.Connection con= new noef.models.Connection
            {
                Server="localhost",
                Bd="nombre de la base de datos",
                User="usuario de la base de datos",
                Password=" clave de la base de datos",
               TypeConnection=noef.models.typeConnection.SQL //(puede ser sql, oracle, postgre sql o para mysql)
            };

      
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.Payloads payload = new noef.Payloads();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:

           // Se agregan los parámetros si son necesarios
           Dictionary<string,object> param = new Dictionary<string,object>();

            param.Add("@parametro","tests");
            
            //Este método recibe la lista de registros resultante en un JSON
            var json=await payloads.SelectFromDatabaseJSON(con,
                  "select * from nombreDeLaTabla where nombreColumna=@parametro");
             
             //Este método recibe los registros en una lista de dynamic (List<dynamic>)
            var expando=await payloads.SelectFromDatabaseGenericObject(con, 
                 "select * from nombreDeLaTabla where nombreColumna=@parametro");
            
          //nota: En oracle se utiliza dos puntos (:) en lugar de @, 
          ej: param.Add(":parametro","tests");
          (conexion,"select columna from loquesea  where         columna=:parametro",param)
   
Los resultados se podrian acceder de la siguiente forma:

          si se utiliza el método SelectFromDatabaseJSON() entonces se puede deserealizar el JSON en el objeto de clase deseado:
          ejemplo : JsonConvert.DeserealizeObject<T>(json)
          o si se utiliza el método SelectFromDatabaseGenericObject() 
          entonces se puede acceder directamente a las propiedades mediante dynamic:
          ejemplo : expando.FirstOrDefault().NombrePropiedad
          
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
          
          
          
     
          
       
