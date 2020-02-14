# noef
Realiza cualquier consulta  en mysql o postgres o sql server u oracle en forma asíncrona y retorna los resultados en una lista de objetos genéricos {columna=xxx,valor=xxx}


Se debe instalar el paquete nuget en visual studio o por consola: Install-Package noef -Version 2.0.4

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
          
          
          
          
       
