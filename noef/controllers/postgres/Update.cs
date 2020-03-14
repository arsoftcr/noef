using noef.models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.postgres
{
    public class Update
    {
        public async Task<int> UpdateDatabase(ConexionPostgres con, string consulta, Dictionary<string, object> paramts)
        {



            try
            {
                using (var conexion = new NpgsqlConnection("Host=" + con.Host + ";Port=" + con.Port + ";User ID=" + con.UserId + ";Password=" + con.Password + ";Database=" + con.Database + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
                    {
                        foreach (var item in paramts)
                        {
                            comando.Parameters.AddWithValue(item.Key.Replace("@", ""), item.Value);
                        }
                        var reader = await comando.ExecuteReaderAsync();




                    }
                }


                return 1;

            }
            catch (Exception e)
            {


                return 0;
            }


        }



        public async Task<int> UpdateDatabase(string cadenaConexion, string consulta, Dictionary<string, object> paramts)
        {



            try
            {
                using (var conexion = new NpgsqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
                    {
                        foreach (var item in paramts)
                        {
                            comando.Parameters.AddWithValue(item.Key, item.Value);
                        }
                        var reader = await comando.ExecuteReaderAsync();




                    }
                }


                return 1;

            }
            catch (Exception e)
            {


                return 0;
            }


        }
    }
}
