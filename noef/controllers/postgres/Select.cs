using noef.models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.postgres
{
    public class Select
    {
        public async Task<List<List<object>>> SelectFromDatabase(ConexionPostgres con, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

           

            try
            {
                using (var conexion = new NpgsqlConnection("Host="+con.Host+";Port="+con.Port+";User ID="+con.UserId+";Password="+con.Password+";Database="+con.Database+""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
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



        public async Task<List<List<object>>> SelectFromDatabase(string cadenaConexion, string consulta)
        {


            List<List<object>> resultados = new List<List<object>>();

            

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




        public async Task<List<List<Generico>>> SelectFromDatabaseGeneric(ConexionPostgres con, string consulta)
        {


            List<List<Generico>> resultados = new List<List<Generico>>();



            try
            {
                using (var conexion = new NpgsqlConnection("Host=" + con.Host + ";Port=" + con.Port + ";User ID=" + con.UserId + ";Password=" + con.Password + ";Database=" + con.Database + ""))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
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




        public async Task<List<List<Generico>>> SelectFromDatabaseGeneric(string con, string consulta)
        {


            List<List<Generico>> resultados = new List<List<Generico>>();



            try
            {
                using (var conexion = new NpgsqlConnection(con))
                {

                    await conexion.OpenAsync();

                    using (var comando = new NpgsqlCommand(consulta, conexion))
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


    }
}
