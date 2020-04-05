using noef.models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.oracle
{
    public class Insert
    {
        public async Task<int> InsertDatabase(Conexion con, string consulta,Dictionary<string,object> paramts)
        {


            try
            {
                using (var conexion = new OracleConnection("Data Source=" + con.Servidor + ":" + con.Port + "/" + con.BaseDatos + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new OracleCommand(consulta, conexion))
                    {
                        foreach (var item in paramts)
                        {
                            comando.Parameters.Add(item.Key,item.Value);
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



        public async Task<int> InsertDatabase(string cadenaConexion, string consulta,Dictionary<string,object> paramts)
        {


            try
            {
                using (var conexion = new OracleConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new OracleCommand(consulta, conexion))
                    {
                        foreach (var item in paramts)
                        {
                            comando.Parameters.Add(item.Key.Replace(":", ""), item.Value);
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
