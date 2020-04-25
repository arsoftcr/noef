# noef  ![NuGet Version](http://img.shields.io/static/v1?label=Arsoftcr&message=La%20mejor%20tecnología&color=blue)

Realiza cualquier consulta  en mysql o postgres o sql server u oracle en forma asíncrona y retorna los resultados en una lista de Dictionary<string,object>


Se debe instalar el paquete nuget en visual studio o por consola: https://www.nuget.org/packages/noef

### Bases de datos soportadas:

|Base de Datos|Operaciones soportadas|
| ------------------- | ------------------- |
|MYSQL|SELECT,INSERT,UPDATE,DELETE|
|SQL SERVER|SELECT,INSERT,UPDATE,DELETE|
|POSTGRES|SELECT,INSERT,UPDATE,DELETE|
|ORACLE|SELECT,INSERT,UPDATE,DELETE|


Se debe crear una instancia con los datos de conexión e indicar el tipo de base de datos:
  
         Conexion conexion = new Conexion
        {
            Server= "xxx",
            Port="xx",//opcional en sql
            BaseDatos="xxxx",//en oracle se pone el nombre del servicio
            Username= "xx",
            Password= "xxxx",
            Tipo=tipo.SQL // tipo.SQL, tipo.Oracle, tipo.Mysql, tipo.Postgres

        };

      
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.Payloads mysqlCon = new noef.Payloads();
        noef.Payloads sqlCon = new noef.Payloads();
        noef.Payloads oracleCon = new noef.Payloads();
        noef.Payloads postgresCon = new noef.Payloads();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:

          var resultado=await mysqlCon.SelectFromDatabase(conexion,"select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await sqlCon.SelectFromDatabase(conexion,"select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await oracleCon.SelectFromDatabase(conexion,"select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await postgresCon.SelectFromDatabase(conexion,"select columnaRequeridaEnLosResultados from loquesea");
          
  Nota:También se puede realizar la operación pasando la cadena de conexión como un string:
  
          var resultado=await mysqlCon.SelectFromDatabase("cadenaConexionMysql","select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await sqlCon.SelectFromDatabase("cadenaConexionSql","select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await oracleCon.SelectFromDatabase("cadenaConexionOracle","select columnaRequeridaEnLosResultados from loquesea");
          var resultado=await postgresCon.SelectFromDatabase("cadenaConexionPostgres","select columnaRequeridaEnLosResultados from loquesea");
         
         
         
Los resultados se podrian acceder de la siguiente forma:

          resultado.foreach((x)=>{Console.WriteLine($"{x["columnaRequeridaEnLosResultados"]}");});
          
Para realizar un insert,update o delete a la bd se necesita crear una instancia de la clase Payloads y pasarle un diccionario de datos con los parámetros y sus valores de la siguiente forma:


           noef.Payloads sqlInsert = new noef.Payloads();
           noef.Payloads mysqlInsert = new noef.Payloads();
           noef.Payloads postgresInsert = new noef.Payloads();
           noef.Payloads oracleInsert = new noef.Payloads();

            Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("@desc","testsql");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("@desc","testmysql");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("desc","testpostgres");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("desc","testoracle");

         var resultado = await sqlInsert.InsertOrUpdateOrDeleteDatabase(conexion,
         "insert into loquesea(Descripcion)values(@desc)",diccio);
         
              var resultado = await mysqlInsert.InsertOrUpdateOrDeleteDatabase(conexion,
              "insert into loquesea(Descripcion)values(@desc)",diccio);
              
                var resultado = await postgresInsert.InsertOrUpdateOrDeleteDatabase(conexion,
                "insert into loquesea(Descripcion)values(@desc)",diccio);
                
                  var resultado = await oracleInsert.InsertOrUpdateOrDeleteDatabase(conexion,
                  "insert into loquesea(Descripcion)values(@desc)",diccio);
                  

            if (resultado == 0)
            {
                // ERROR
            }
            else
            {
                // OK
            }
          
          
          
     
          
       
