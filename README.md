# noef
Realiza cualquier consulta  en mysql o postgres o sql server u oracle en forma asíncrona y retorna los resultados en una lista de objetos genéricos {columna=xxx,valor=xxx}


Se debe instalar el paquete nuget en visual studio o por consola: https://www.nuget.org/packages/CarouselView.FormsPlugin/ [![NuGet](https://img.shields.io/nuget/v/CarouselView.FormsPlugin.svg?label=NuGet)](https://www.nuget.org/packages/CarouselView.FormsPlugin/)

Se debe crear una instancia con los datos de conexión a la base de datos:
  
         ConexionMysql mysql = new ConexionMysql
        {
            Server= "xxx",
            Port="xx",
            Bd="xxxx",
            Username= "xx",
            Password= "xxxx"

        };

        ConexionPostgres postgres = new ConexionPostgres
        {
            Host="xxx",
            Port="xxx",
            UserId="xxx",
            Password="xxx",
            Database="xxx"
        };

        ConexionOracle oracle = new ConexionOracle
        {
            Datasource="xxx",
            Port="xxx",
            Password="xxxx",
            UserId="xxx",
            Servicio="xx"
        };

        ConexionSQL sql = new ConexionSQL
        {
            Servidor="xxx",
            Usuario="xxx",
            Password="xxx",
            BD="xxxx"
        };
   
   
 Seguidamente se instancia la clase para hacer las consultas:
 
        noef.controllers.mysql.Select mysqlCon = new noef.controllers.mysql.Select();
        noef.controllers.sql.Select sqlCon = new noef.controllers.sql.Select();
        noef.controllers.oracle.Select oracleCon = new noef.controllers.oracle.Select();
        noef.controllers.postgres.Select postgresCon = new noef.controllers.postgres.Select();
        
        
Y por último se hace la consulta pasando como parámetro la instancia de la conexión y la consulta sql:

          var resultado=await mysqlCon.SelectFromDatabase(mysql,"select * from loquesea");
          var resultado=await sqlCon.SelectFromDatabase(sql,"select * from loquesea");
          var resultado=await oracleCon.SelectFromDatabase(oracle,"select * from loquesea");
          var resultado=await postgresCon.SelectFromDatabase(postgres,"select * from loquesea");
          
  Nota:También se puede realizar la operación pasando la cadena de conexión como un string:
  
          var resultado=await mysqlCon.SelectFromDatabase("cadenaConexionMysql","select * from loquesea");
          var resultado=await sqlCon.SelectFromDatabase("cadenaConexionSql","select * from loquesea");
          var resultado=await oracleCon.SelectFromDatabase("cadenaConexionOracle","select * from loquesea");
          var resultado=await postgresCon.SelectFromDatabase("cadenaConexionPostgres","select * from loquesea");
          
          
Para realizar un insert a la bd se necesita crear una instancia de la clase Insert y pasarle un diccionario de datos con los parámetros y sus valores de la siguiente forma:


           noef.controllers.sql.Insert sqlInsert = new noef.controllers.sql.Insert();
           noef.controllers.mysql.Insert mysqlInsert = new noef.controllers.mysql.Insert();
           noef.controllers.postgres.Insert postgresInsert = new noef.controllers.postgres.Insert();
           noef.controllers.oracle.Insert oracleInsert = new noef.controllers.oracle.Insert();

            Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("@desc","testsql");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("@desc","testmysql");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("desc","testpostgres");
            
             Dictionary<string,object> diccio = new Dictionary<string,object>();

            diccio.Add("desc","testoracle");

            var resultado = await sqlInsert.InsertDatabase(sql,"insert into loquesea(Descripcion)values(@desc)",diccio);
              var resultado = await mysqlInsert.InsertDatabase(mysql,"insert into loquesea(Descripcion)values(@desc)",diccio);
                var resultado = await postgresInsert.InsertDatabase(postgres,"insert into loquesea(Descripcion)values(@desc)",diccio);
                  var resultado = await oracleInsert.InsertDatabase(oracle,"insert into loquesea(Descripcion)values(@desc)",diccio);
                  

            if (resultado == 0)
            {
                // ERROR
            }
            else
            {
                // OK
            }
          
          
          
Nota: Los métodos de consulta  a la base de datos devuelven una lista de una lista de objetos: List<List < object > >. Para convertir esto a una clase de algún tipo se puede hacer con Newtonsoft  o con un switch por medio de los valores de las columnas. Próximanente estaremos creando uno o varios métodos para facilitar esto ;).
          
       
