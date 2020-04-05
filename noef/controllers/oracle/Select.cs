using noef.models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noef.controllers.oracle
{
    public class Select
    {
        public async Task<List<Dictionary<string,object>>> SelectFromDatabase(Conexion con, string consulta)
        {


            List<Dictionary<string,object>> resultados = new List<Dictionary<string,object>>();



            try
            {
                using (var conexion = new OracleConnection("Data Source=" + con.Servidor + ":" + con.Port + "/" + con.BaseDatos + ";User Id=" + con.Usuario + ";Password=" + con.Password + ";"))
                {

                    await conexion.OpenAsync();

                    using (var comando = new OracleCommand(consulta, conexion))
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
                using (var conexion = new OracleConnection(cadenaConexion))
                {

                    await conexion.OpenAsync();

                    using (var comando = new OracleCommand(consulta, conexion))
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



   


    }
}
