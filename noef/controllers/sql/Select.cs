using noef.models;
using System;
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
        public async Task<List<List<object>>> SelectFromDatabase(ConexionSQL con, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

           

            try
            {
                using (var conexion = new SqlConnection("Server=" + con.Servidor + ";Initial Catalog=" + con.BD + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";Persist Security Info=True;MultipleActiveResultSets=True;"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            List<object> columnas = new List<object>();

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
                List<object> columnas = new List<object>();

                var anonimo = new { columna = "error", valor = e.ToString() };

                columnas.Add(anonimo);

                resultados.Add(columnas);

                return resultados;
            }


        }


        public async Task<List<List<Generico>>> SelectFromDatabaseGeneric(ConexionSQL con, string consulta)
        {


            List<List<Generico>> resultados = new List<List<Generico>>();



            try
            {
                using (var conexion = new SqlConnection("Server=" + con.Servidor + ";Initial Catalog=" + con.BD + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";Persist Security Info=True;MultipleActiveResultSets=True;"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            List<Generico> columnas = new List<Generico>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    Generico celda = new Generico
                                    {
                                        Columna = item.GetName(i),
                                        Valor=item.GetValue(i)
                                    };

                                    columnas.Add(celda);
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
                List<Generico> columnas = new List<Generico>();

                Generico celda = new Generico
                {
                    Columna = "error",
                    Valor = e.ToString()
                };
                
                columnas.Add(celda);

                resultados.Add(columnas);

                return resultados;
            }


        }

        public async Task<List<List<Generico>>> SelectFromDatabaseGeneric(string con, string consulta)
        {


            List<List<Generico>> resultados = new List<List<Generico>>();



            try
            {
                using (var conexion = new SqlConnection(con))
                {

                    await conexion.OpenAsync();

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        var reader = await comando.ExecuteReaderAsync();


                        foreach (var item in reader.Cast<DbDataRecord>())
                        {
                            List<Generico> columnas = new List<Generico>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    Generico celda = new Generico
                                    {
                                        Columna = item.GetName(i),
                                        Valor = item.GetValue(i)
                                    };

                                    columnas.Add(celda);
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
                List<Generico> columnas = new List<Generico>();

                Generico celda = new Generico
                {
                    Columna = "error",
                    Valor = e.ToString()
                };

                columnas.Add(celda);

                resultados.Add(columnas);

                return resultados;
            }


        }


        public async Task<List<List<object>>> SelectFromDatabase(string cadenaConexion, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

            

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
                            List<object> columnas = new List<object>();
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
                List<object> columnas = new List<object>();
                var anonimo = new { columna = "error", valor = e.ToString() };

                columnas.Add(anonimo);

                resultados.Add(columnas);

                return resultados;
            }


        }




    }
}
