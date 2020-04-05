using noef.models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.postgres
{
    public class Insert
    {
        public async Task<int> InsertDatabase(Conexion con, string consulta,Dictionary<string,object> paramts)
        {



            try
            {
                using (var conexion = new NpgsqlConnection("Host=" + con.Servidor + ";Port=" + con.Port + ";User ID=" + con.Usuario + ";Password=" + con.Password + ";Database=" + con.BaseDatos + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
                    {
                        foreach (var item in paramts)
                        {
                            comando.Parameters.AddWithValue(item.Key.Replace("@",""),item.Value);
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



        public async Task<int> InsertDatabase(string cadenaConexion, string consulta, Dictionary<string, object> paramts)
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
