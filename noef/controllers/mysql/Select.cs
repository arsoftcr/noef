using MySql.Data.MySqlClient;
using noef.models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.mysql
{
    public class Select
    {

        public async Task<List<List<object>>> SelectFromDatabase(ConexionMysql con, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

            List<object> columnas = new List<object>();

            try
            {
                using (var conexion = new MySqlConnection("server="+con.Server+";port="+con.Port+";username="+con.Username+";password="+con.Password+";SslMode = none;database="+con.Bd+""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {

                                    var anonimo = new { columna = item.GetName(i), valor = item.GetValue(i) };


                                    columnas.Add(anonimo);
                                }
                            }

                            resultados.Add(columnas);
                        }

                    }
                }


                return resultados;

            }
            catch (Exception e)
            {

                var anonimo = new { columna = "error", valor = e.ToString() };

                columnas.Add(anonimo);

                resultados.Add(columnas);

                return resultados;
            }


        }



        public async Task<List<List<object>>> SelectFromDatabase(string cadenaConexion, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

            List<object> columnas = new List<object>();

            try
            {
                using (var conexion = new MySqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {

                                    var anonimo = new { columna = item.GetName(i), valor = item.GetValue(i) };


                                    columnas.Add(anonimo);
                                }
                            }

                            resultados.Add(columnas);
                        }

                    }
                }


                return resultados;

            }
            catch (Exception e)
            {

                var anonimo = new { columna = "error", valor = e.ToString() };

                columnas.Add(anonimo);

                resultados.Add(columnas);

                return resultados;
            }


        }




    }
}
