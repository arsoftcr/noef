using MySql.Data.MySqlClient;
using noef.models;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers
{
    public class Miscelaneos
    {
        /// <summary>
        /// Crea la cadena de conexión
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static string crearCadena(Conexion con)
        {
            string pConexion = string.Empty;

            switch ((con ?? new Conexion()).Tipo)
            {
                case tipo.SQL:
                    pConexion = $"Server={con.Servidor};Initial Catalog={con.BaseDatos};User Id={con.Usuario};Password={con.Password};Persist Security Info=True;MultipleActiveResultSets=True;";
                    break;
                case tipo.Oracle:
                    pConexion = $"Data Source={con.Servidor}:{con.Port}/{con.BaseDatos};User Id={con.Usuario};Password={con.Password};";
                    break;
                case tipo.Postgres:
                    pConexion = $"Host={con.Servidor};Port={con.Port};User ID={con.Usuario};Password={con.Password};Database={con.BaseDatos}";
                    break;
                case tipo.Mysql:
                    pConexion = $"server={con.Servidor};port={con.Port};username={con.Usuario};password={con.Password};SslMode = none;database={con.BaseDatos}";
                    break;
                default:
                    break;
            }

            return pConexion;
        }


        public static async Task<List<Dictionary<string, object>>> agregarResultados(object reader)
        {
            List<Dictionary<string, object>> keyValuePairs = new List<Dictionary<string, object>>();

            string tipoReader = reader != null ? reader.GetType().Name : "";

            switch (tipoReader)
            {
                case "SqlDataReader":
                    foreach (var item in (reader as SqlDataReader).Cast<DbDataRecord>())
                    {
                        Dictionary<string, object> columnas = new Dictionary<string, object>();

                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                columnas.Add(item.GetName(i), item.GetValue(i));
                            }
                        }

                        keyValuePairs.Add(columnas);
                    }

                    //Múltiple result sets
                    while (await (reader as SqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as SqlDataReader).Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i), item.GetValue(i));
                                }
                            }

                            keyValuePairs.Add(columnas);
                        }
                    }

                    break;
                case "MySqlDataReader":
                    foreach (var item in (reader as MySqlDataReader).Cast<DbDataRecord>())
                    {
                        Dictionary<string, object> columnas = new Dictionary<string, object>();

                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                columnas.Add(item.GetName(i), item.GetValue(i));
                            }
                        }

                        keyValuePairs.Add(columnas);
                    }


                    //Múltiple result sets
                    while (await (reader as  MySqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as MySqlDataReader).Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i), item.GetValue(i));
                                }
                            }

                            keyValuePairs.Add(columnas);
                        }
                    }
                    break;
                case "NpgsqlDataReader":
                    foreach (var item in (reader as NpgsqlDataReader).Cast<DbDataRecord>())
                    {
                        Dictionary<string, object> columnas = new Dictionary<string, object>();

                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                columnas.Add(item.GetName(i), item.GetValue(i));
                            }
                        }

                        keyValuePairs.Add(columnas);
                    }

                    //Múltiple result sets
                    while (await (reader as NpgsqlDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as NpgsqlDataReader).Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i), item.GetValue(i));
                                }
                            }

                            keyValuePairs.Add(columnas);
                        }
                    }
                    break;
                case "OracleDataReader":
                    foreach (var item in (reader as OracleDataReader).Cast<DbDataRecord>())
                    {
                        Dictionary<string, object> columnas = new Dictionary<string, object>();

                        for (int i = 0; i < item.FieldCount; i++)
                        {
                            if (item.GetValue(i) != null)
                            {
                                columnas.Add(item.GetName(i), item.GetValue(i));
                            }
                        }

                        keyValuePairs.Add(columnas);
                    }


                    //Múltiple result sets
                    while (await (reader as OracleDataReader).NextResultAsync())
                    {
                        foreach (var item in (reader as OracleDataReader).Cast<DbDataRecord>())
                        {
                            Dictionary<string, object> columnas = new Dictionary<string, object>();

                            for (int i = 0; i < item.FieldCount; i++)
                            {
                                if (item.GetValue(i) != null)
                                {
                                    columnas.Add(item.GetName(i), item.GetValue(i));
                                }
                            }

                            keyValuePairs.Add(columnas);
                        }
                    }
                    break;
                default:
                    break;
            }

            return keyValuePairs;

        }




    }
}
