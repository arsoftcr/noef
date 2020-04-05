using noef.models;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.postgres
{
    public class Select
    {
        public async Task<List<Dictionary<string,object>>> SelectFromDatabase(Conexion con, string consulta)
        {


            List<Dictionary<string,object>> resultados = new List<Dictionary<string,object>>();



            try
            {
                using (var conexion = new NpgsqlConnection("Host=" + con.Servidor + ";Port=" + con.Port + ";User ID=" + con.Usuario + ";Password=" + con.Password + ";Database=" + con.BaseDatos + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
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
                using (var conexion = new NpgsqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
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

                columnas.Add("error", e.ToString());

                resultados.Add(columnas);

                return resultados;
            }


        }



        public async Task<List<Dictionary<string, object>>> SelectFromDatabase(Conexion con,
          string consulta, Dictionary<string, object> parameters)
        {


            List<Dictionary<string, object>> resultados =
                new List<Dictionary<string, object>>();



            try
            {
                using (var conexion = new NpgsqlConnection("Host=" + con.Servidor + ";Port=" + con.Port + ";User ID=" + con.Usuario + ";Password=" + con.Password + ";Database=" + con.BaseDatos + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
                    {

                        foreach (var item in parameters)
                        {
                            comando.Parameters.AddWithValue(item.Key.Replace("@", ""), item.Value);
                        }
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

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
                Dictionary<string, object> columnas = new Dictionary<string, object>();

                columnas.Add("error", e.ToString());

                resultados.Add(columnas);

                return resultados;
            }


        }





        public async Task<List<Dictionary<string, object>>> SelectFromDatabase(string cadenaConexion,
            string consulta, Dictionary<string, object> parameters)
        {


            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();



            try
            {
                using (var conexion = new NpgsqlConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
                    {
                        foreach (var item in parameters)
                        {
                            comando.Parameters.AddWithValue(item.Key.Replace("@", ""), item.Value);
                        }

                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();
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
                Dictionary<string, object> columnas = new Dictionary<string, object>();

                columnas.Add("error", e.ToString());

                resultados.Add(columnas);

                return resultados;
            }


        }



    }
}
