using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using noef.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.sql
{
    public class Select
    {
        public async Task<List<Dictionary<string,object>>> SelectFromDatabase(Conexion con, string consulta)
        {


            List<Dictionary<string, object>> resultados =
                new List<Dictionary<string, object>>();



            try
            {
                using (var conexion = new SqlConnection("Server=" + con.Servidor + ";Initial Catalog=" + con.BaseDatos + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";Persist Security Info=True;MultipleActiveResultSets=True;"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();

                 
                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i),item.GetValue(i));
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
                Dictionary<string,object> columnas = new Dictionary<string, object>();

                columnas.Add("error", e.ToString());

                resultados.Add(columnas);

                return resultados;
            }


        }


       


        public async Task<List<Dictionary<string,object>>> SelectFromDatabase(string cadenaConexion, string consulta)
        {


            List<Dictionary<string,object>> resultados = new List<Dictionary<string,object>>();

            

            try
            {
                using (var conexion = new SqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            Dictionary<string,object> columnas = new Dictionary<string,object>();
                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i), item.GetValue(i));
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
                Dictionary<string,object> columnas = new Dictionary<string,object>();
             
                columnas.Add("error",e.ToString());

                resultados.Add(columnas);

                return resultados;
            }


        }


       

     

    }
}
