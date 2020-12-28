using MySql.Data.MySqlClient;
using noef.models;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers
{
    public class Payloads
    {
        /// <summary>
        /// Ejecuta la consulta recibida en la base de datos.Recibe la conexión como un objeto
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public async Task<string> SelectFromDatabaseJSON(Connection con, string consulta, Dictionary<string, object> param = null)
        {

            string records = "";

            string pConexion = Miscellaneous.createConnection(con);

            try
            {
                switch (con.TypeConnection)
                {
                    case typeConnection.SQL:

                        using (var conexion = new SqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new SqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }

                                var reader = await comando.ExecuteReaderAsync();

                                records = await Miscellaneous.addResults(reader);

                            }

                        }


                        break;
                    case typeConnection.Oracle:

                        using (var conexion = new OracleConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new OracleCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResults(reader);

                            }
                        }


                        break;
                    case typeConnection.Postgres:

                        using (var conexion = new NpgsqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new NpgsqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResults(reader);

                            }
                        }

                        break;
                    case typeConnection.Mysql:

                        using (var conexion = new MySqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new MySqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResults(reader);

                            }
                        }


                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
            }


            return records;

        }

        /// <summary>
        /// Ejecuta la consulta recibida en la base de datos.Recibe la conexión como un objeto
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<dynamic>> SelectFromDatabaseGenericObject(Connection con, string consulta, Dictionary<string, object> param = null)
        {

            List<ExpandoObject> records = new List<ExpandoObject>();

            string pConexion = Miscellaneous.createConnection(con);

            try
            {
                switch (con.TypeConnection)
                {
                    case typeConnection.SQL:

                        using (var conexion = new SqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new SqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }

                                var reader = await comando.ExecuteReaderAsync();

                                records = await Miscellaneous.addResultsGenericObject(reader);

                            }

                        }


                        break;
                    case typeConnection.Oracle:

                        using (var conexion = new OracleConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new OracleCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResultsGenericObject(reader);

                            }
                        }


                        break;
                    case typeConnection.Postgres:

                        using (var conexion = new NpgsqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new NpgsqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResultsGenericObject(reader);

                            }
                        }

                        break;
                    case typeConnection.Mysql:

                        using (var conexion = new MySqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new MySqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscellaneous.addParameters(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                records = await Miscellaneous.addResultsGenericObject(reader);

                            }
                        }


                        break;
                    default:
                        break;
                }


            }
            catch (Exception e)
            {
            }

            return records.Cast<dynamic>().ToList();

        }


        /// <summary>
        /// Ejecuta un insert,update o delete en la base de datos. Recibe la conexión como un objeto
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <param name="paramts"></param>
        /// <returns></returns>
        public async Task<int> InsertOrUpdateOrDeleteDatabase(Connection con, string consulta, Dictionary<string, object> paramts)
        {


            string pConexion = Miscellaneous.createConnection(con);

            try
            {
                switch (con.TypeConnection)
                {
                    case typeConnection.SQL:

                        using (var conexion = new SqlConnection(pConexion))
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
                    case typeConnection.Oracle:

                        using (var conexion = new OracleConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new OracleCommand(consulta, conexion))
                            {
                                foreach (var item in paramts)
                                {
                                    comando.Parameters.Add(item.Key, item.Value);
                                }
                                var reader = await comando.ExecuteReaderAsync();




                            }
                        }

                        return 1;
                    case typeConnection.Postgres:

                        using (var conexion = new NpgsqlConnection(pConexion))
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
                    case typeConnection.Mysql:

                        using (var conexion = new MySqlConnection(pConexion))
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
                    default:
                        return 0;
                       
                }


            }
            catch (Exception e)
            {
                return 0;
            }


        }



    }
}
