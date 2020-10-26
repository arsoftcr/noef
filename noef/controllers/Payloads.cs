using MySql.Data.MySqlClient;
using noef.models;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
        public async Task<List<Dictionary<string, object>>> SelectFromDatabase(Conexion con, string consulta,Dictionary<string,object> param=null)
        {

            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();

            string pConexion = Miscelaneos.crearCadena(con);

            try
            {
                switch (con.Tipo)
                {
                    case tipo.SQL:

                        using (var conexion = new SqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new SqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }


                                var reader = await comando.ExecuteReaderAsync();

                                resultados=await Miscelaneos.agregarResultados(reader);

                            }
                        
                        }


                        break;
                    case tipo.Oracle:

                        using (var conexion = new OracleConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new OracleCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }


                                var reader = await comando.ExecuteReaderAsync();


                                resultados=await Miscelaneos.agregarResultados(reader);

                            }
                        }


                        break;
                    case tipo.Postgres:

                        using (var conexion = new NpgsqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new NpgsqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }


                                
                                var reader = await comando.ExecuteReaderAsync();


                                resultados=await Miscelaneos.agregarResultados(reader);

                            }
                        }

                        break;
                    case tipo.Mysql:
                    
                        using (var conexion = new MySqlConnection(pConexion))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new MySqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }


                                var reader = await comando.ExecuteReaderAsync();


                                resultados=await Miscelaneos.agregarResultados(reader);

                            }
                        }


                        break;
                    default:
                        break;
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

        /// <summary>
        /// Ejecuta la consulta recibida en la base de datos. Recibe la conexión como un string
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> SelectFromDatabase(string con, 
            string consulta,tipo tipo, Dictionary<string, object> param = null)
        {

            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();

           
            try
            {
                switch (tipo)
                {
                    case tipo.SQL:

                        using (var conexion = new SqlConnection(con))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new SqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }

                                var reader = await comando.ExecuteReaderAsync();

                                resultados = await Miscelaneos.agregarResultados(reader);

                            }

                        }


                        break;
                    case tipo.Oracle:

                        using (var conexion = new OracleConnection(con))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new OracleCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                resultados = await Miscelaneos.agregarResultados(reader);

                            }
                        }


                        break;
                    case tipo.Postgres:

                        using (var conexion = new NpgsqlConnection(con))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new NpgsqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                resultados = await Miscelaneos.agregarResultados(reader);

                            }
                        }

                        break;
                    case tipo.Mysql:

                        using (var conexion = new MySqlConnection(con))
                        {

                            await conexion.OpenAsync();

                            using (var comando = new MySqlCommand(consulta, conexion))
                            {
                                if (param != null)
                                {
                                    Miscelaneos.agregarParametros(comando, param);
                                }
                                var reader = await comando.ExecuteReaderAsync();


                                resultados = await Miscelaneos.agregarResultados(reader);

                            }
                        }


                        break;
                    default:
                        break;
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


        /// <summary>
        /// Ejecuta un insert,update o delete en la base de datos. Recibe la conexión como un objeto
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <param name="paramts"></param>
        /// <returns></returns>
        public async Task<int> InsertOrUpdateOrDeleteDatabase(Conexion con, string consulta, Dictionary<string, object> paramts)
        {


            string pConexion = Miscelaneos.crearCadena(con);

            try
            {
                switch (con.Tipo)
                {
                    case tipo.SQL:

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
                    case tipo.Oracle:

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
                    case tipo.Postgres:

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
                    case tipo.Mysql:

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


        /// <summary>
        /// Ejecuta un insert,update o delete en la base de datos. Recibe la conexión como un string
        /// </summary>
        /// <param name="con"></param>
        /// <param name="consulta"></param>
        /// <param name="paramts"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public async Task<int> InsertOrUpdateOrDeleteDatabase(string con, 
            string consulta, Dictionary<string, object> paramts,tipo tipo)
        {


            try
            {
                switch (tipo)
                {
                    case tipo.SQL:

                        using (var conexion = new SqlConnection(con))
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
                    case tipo.Oracle:

                        using (var conexion = new OracleConnection(con))
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
                    case tipo.Postgres:

                        using (var conexion = new NpgsqlConnection(con))
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
                    case tipo.Mysql:

                        using (var conexion = new MySqlConnection(con))
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
