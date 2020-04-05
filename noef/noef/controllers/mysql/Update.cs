using MySql.Data.MySqlClient;
using noef.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.mysql
{
    public class Update
    {
        public async Task<int> UpdateDatabase(Conexion con, string consulta, Dictionary<string, object> paramts)
        {



            try
            {
                using (var conexion = new MySqlConnection("server=" + con.Servidor + ";port=" + con.Port + ";username=" + con.Usuario + ";password=" + con.Password + ";SslMode = none;database=" + con.BaseDatos + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new MySqlCommand(consulta, conexion))
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



        public async Task<int> UpdateDatabase(string cadenaConexion, string consulta, Dictionary<string, object> paramts)
        {


            try
            {
                using (var conexion = new MySqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new MySqlCommand(consulta, conexion))
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
