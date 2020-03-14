
using noef.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace noef.controllers.sql
{
   
    public class Update
    {
        public async Task<int> UpdateDatabase(ConexionSQL con, string consulta, Dictionary<string, object> paramts)
        {




            try
            {
                using (var conexion = new SqlConnection("Server=" + con.Servidor + ";Initial Catalog=" + con.BD + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";Persist Security Info=True;MultipleActiveResultSets=True;"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
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
                using (var conexion = new SqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
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
